using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static GUISocket.Form2;
using static System.Windows.Forms.AxHost;


namespace GUISocket
{

    public partial class Form1 : Form
    {

        class TreatmentState
        {
            bool active;
            bool stopIssued = false;
            int state;
            int subState;
            string? lastCommandSent;


            public TreatmentState()
            {
                Active = false;
                State = 0;
                SubState = 0;
                LastCommandSent = "";
                StopIssued = false;


            }

            public bool Active { get => active; set => active = value; }
            public int State { get => state; set => state = value; }
            public int SubState { get => subState; set => subState = value; }
            public String LastCommandSent { get => lastCommandSent; set => lastCommandSent = value; }
            public bool StopIssued { get => stopIssued; set => stopIssued = value; }
        }

        Boolean Fault = false; // indiactes if Eng is pressed or AC power is not there or System fault or Door open
        Stopwatch stopTime = new Stopwatch();
        Stopwatch totalTime = new Stopwatch();
        Int32 NoOfCycles = 0;
        Int32 TotalCycles = 0;
        int missedConnectioncounter = 0;// increments if request sent but no reply recieved
        int maxMissedConnection = 10; // Max no of such replies misssed
        int currentSourcPos = 0;
        bool SourceOut = false;
        Boolean dummystarted = false;
        System.Data.DataSet dataSet;
        System.Data.DataTable ChannelTable = new DataTable("ChannelData");
        int[] indexerPosition = { 0, 515, 3741, 6955, 10142, 13352, 16506, 19677, 22856, 26036, 29231, 32424, 35708, 38914, 42120, 45326, 48532, 51738, 54944, 58148, 61353 };
        int[] indexerEncPosition = new int[21];// = { 0, 880, 5879, 10873, 15869, 20822, 25834, 30792,35808,40729,45740,50755,55728,60751,65744, 70725,75705, 80794,85871, 90870,95870};  // This is default positiondata, applicable when not able to read indexer Config file.
        TreatmentState ts = new TreatmentState();
        HDRResponce ResponceData = new HDRResponce();

        IPAddress ip;
        IPEndPoint remoteEP;
        Socket clientSocket;
        int port = 2321;
        string ipno = "192.168.99.253";
        byte[] buffer = new byte[1024];
        int ZeroSize_count = 0;
        Int32 mean;

        const string dirpath = "C:\\HDR\\";
        string path;
        const string pathcyclelog = "C:\\HDR\\CycleLog.txt";
        const string rawDatalog = "C:\\HDR\\RawDataLog.txt";


        StreamWriter log;

        private void MakeChannelTable()
        {

            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = false;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            ChannelTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Position";
            column.AutoIncrement = false;
            column.Caption = "Position";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            ChannelTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "TreatmentTime";
            column.AutoIncrement = false;
            column.Caption = "Treatment Time";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            ChannelTable.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = ChannelTable.Columns["id"];
            ChannelTable.PrimaryKey = PrimaryKeyColumns;

            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(ChannelTable);

            // Create three new DataRow objects and add
            // them to the DataTable
            for (int i = 0; i <= 5; i++)
            {
                row = ChannelTable.NewRow();
                row["id"] = i;
                row["Position"] = Convert.ToInt32(30 * 2.8);
                row["TreatmentTime"] = 5000;
                ChannelTable.Rows.Add(row);
            }
        }


        public Form1()
        {
            InitializeComponent();
            ip = IPAddress.Parse(ipno);
            remoteEP = new IPEndPoint(ip, port);
            //MakeChannelTable();
            //dataGridView1.DataSource = ChannelTable;
            path = dirpath + "IndexePosData.txt";
            ReadIndexerConfigFile(path);
        }

        private void ReadIndexerConfigFile(string path)
        {

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = reader.ReadLine(); // Read the first line
                    if (line != null)
                    {
                        string[] subStr = line.Split(",");
                        for (int i = 0; i < subStr.Length; i++)
                        {
                            indexerEncPosition[i] = int.Parse(subStr[i]);
                            Debug.WriteLine(i + " > " + indexerEncPosition[i]);

                        }
                        reader.Close();
                    }
                    else MessageBox.Show("Indexer config could not be loaded.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Indexer config file could not be loaded.\n\n" + ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string Send_to_client(string Data2send)
        {
            try
            {
                string toSend = "#," + Data2send + ",?";
                byte[] msg1 = Encoding.ASCII.GetBytes(toSend);
                int bytesSent = clientSocket.Send(msg1);
                int bytesReceived = clientSocket.Receive(buffer);
                string dtRecievd = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                String timeStamp = (DateTime.Now).ToString("HHmmssffff");
                tbRecieved.AppendText($"{timeStamp}:< {dtRecievd}> \r\n");

                //Debug.WriteLine($"{timeStamp}: <{dtRecievd}>: {bytesReceived}: byte [0]={(int)buffer[0]}, byte[1]= {(int)buffer[1]}");
                return dtRecievd;
            }
            catch (NullReferenceException e1)
            {
                MessageBox.Show(" The client is not connected.");
                //throw e1;
                return "E";

            }
            catch (ArgumentNullException e1)
            {
                MessageBox.Show(e1.Message, "Buffer empty ");
                return "E";
                throw;
            }
            catch (Exception e1)
            {

                timer1.Enabled = false;
                lblStatServer.ForeColor = System.Drawing.Color.Red;
                lblStatServer.Text = "Server:Disconnected";
                timer1.Enabled = false;
                clientSocket.Close();
                btnConnect.Enabled = true;
                btnSend.Enabled = false;
                MessageBox.Show(e1.Message, "All Send button Other Exception");
                return "E";


            }

        }

        private string[] CommandParser(string dtRecievd)
        {
            //Parsing of command
            string[] words = dtRecievd.Split(",");
            ResponceData.Update(dtRecievd);

            //Update GUI -------
            UpdateGUI(words);

            return words;

        }

        private void UpdateGUI(string[] words)
        {
            if (words.Length > 8)
            {
                missedConnectioncounter = 0; // Reset missed counter
                //Debug.WriteLine(words.Length);
                //Debug.WriteLine("DSensor :" + Convert.ToString(dSensor, 2));
                //SensorUdate(byte.Parse(words[1]), byte.Parse(words[2])); // update the sensor display
                byte s1 = ResponceData.Sensor1;
                byte s2 = ResponceData.Sensor2;
                if (ResponceData.ErrCode != 0)
                {
                    ts.Active = false;
                    WriteLogfile("cycle aborted Due to Fauly : " + ResponceData.ErrCode);

                }
                SensorUdate(s1, s2);
                if (indiSourceOut.Value)
                    label9.Text = "Source OUT";
                else
                    label9.Text = "Source IN";
                if (ts.Active && (ts.LastCommandSent == "W"))
                {
                    double v = ResponceData.DwellT / 1000;
                    pbDwell.Value = ResponceData.DwellT > 5000 ? 5 : ResponceData.DwellT / 1000;
                    lblTimeElapsed.Text = Math.Round(v, 1).ToString();
                }

                else
                    pbDwell.Value = 0;

                lblErrorcode.Text = words[8].ToString();
                if (lblErrorcode.Text != "0")
                    lblErrorcode.BackColor = Color.Red;
                progressBarS.Value = (-1 * int.Parse(words[4])) < 0 ? 0 : -1 * (int.Parse(words[4]));
                //progressBarD.Value = int.Parse(words[5]) < 0 ? 0 : int.Parse(words[5]);
                tbSrcEnc.Text = ResponceData.SourcePosMM().ToString();
                tbDmyEnc.Text = ResponceData.DummyPosMM().ToString();
                IndexerPosition.CtValue = int.Parse(words[3]) * 360 / 100000;
                indSourcOut.Value = SourceOut;
                if (indSourcOut.Value)
                    label9.Text = "Source OUT";
                else
                    label9.Text = "Source IN";
                lblIndexSlotNo.Text = ((int.Parse(words[3]) - 656) / 5000 + 1).ToString();
                lblDEnc.Text = ResponceData.DmyEnc.ToString();
                lblSEnc.Text = ResponceData.SrcEnc.ToString();
                if (!indCmdProgress.Value)
                {
                    lblIndexerCount.Text = words[3];
                }
                else
                    lblIndexerCount.Text = "-- NA --";
            }
            else
            {
                missedConnectioncounter++;
                Debug.WriteLine(" Wrong Data recieved from Server.");
            }

        }

        void SensorUdate(byte dSensor, byte dSensor2)
        {
            byte mask = 0x02;
            indicSOver.Value = (dSensor & mask) != 0;

            mask = 0x80;
            indIndexLock.Value = (dSensor & mask) != 0;

            mask = 0x04;
            indiSHome.Value = (dSensor & mask) != 0;

            mask = 0x01;
            indiSourceOut.Value = (dSensor & mask) != 0;

            mask = 0x10;
            indiIndexHome.Value = (dSensor & mask) != 0;

            mask = 0x08;
            indAdapterSensor.Value = (dSensor & mask) != 0;

            mask = 0x40;
            indiDHome.Value = (dSensor & mask) != 0;

            mask = 0x20;
            indiDOverShoot.Value = (dSensor & mask) != 0;


            // ----------------------




            mask = 0x02;
            bool temp = indCmdProgress.Value;
            indCmdProgress.Value = (dSensor2 & mask) != 0;
            if (indCmdProgress.Value)
            {
                lblCmdInProg.Text = "Cmd In Progress";
                pBCmdInProgress.Visible = true;
            }
            else
            {
                lblCmdInProg.Text = "M/c Idle";
                pBCmdInProgress.Visible = false;
            }


            mask = 0x04;
            indPwrSw.Value = (dSensor2 & mask) != 0;
            if (indPwrSw.Value)
            {
                Fault = true;
                lblACPower.Text = "AC POWER OFF";
            }

            else
            {
                Fault = false;
                lblACPower.Text = "AC Power ON";
            }


            mask = 0x08;
            indIndexCalibrated.Value = (dSensor2 & mask) == 0;


            mask = 0x10;
            indDoorSw.Value = !((dSensor2 & mask) != 0);
            if (indDoorSw.Value)
                lblDoor.Text = "DOOR OPEN";
            else
                lblDoor.Text = "DOOR CLOSED";


            mask = 0x20;
            indSysFault.Value = !((dSensor2 & mask) != 0);
            if (indSysFault.Value)
                lblSysFault.Text = "System Faulted";
            else lblSysFault.Text = "System Ready";

            mask = 0x40;
            indEmgSw.Value = !((dSensor2 & mask) != 0);
            if (indEmgSw.Value)
                lblEmgSw.Text = "Emg Pressed";
            else
                lblEmgSw.Text = "Emg Armed ";

            mask = 0x80;
            indTretSw.Value = (dSensor2 & mask) != 0;
            if (!indTretSw.Value)
                lblKeySw.Text = "Key Sw ON";
            else
                lblKeySw.Text = "Key Sw OFF";


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tbIP.Text = ip.ToString();
            tbPort.Text = port.ToString();
            btnSend.Enabled = false;
            btnSend.Text = "Send";
            pBCmdInProgress.Visible = false;
            bool exists = System.IO.Directory.Exists(dirpath);

            if (!exists)
                System.IO.Directory.CreateDirectory(dirpath);


        }
        private void Form1_Closing(object sender, EventArgs e)
        {
            //release socket
            timer1.Enabled = false;
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            lblStatServer.ForeColor = System.Drawing.Color.Red;
            lblStatServer.Text = "Server:Disconnected";
            btnConnect.Enabled = true;
            btnSend.Enabled = false;
            Indexer.Enabled = false;
            if (log != null)
                log.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ip = IPAddress.Parse(tbIP.Text);
                port = int.Parse(tbPort.Text);
                remoteEP = new IPEndPoint(ip, port);
                clientSocket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the server

                try
                {
                    clientSocket.Connect(remoteEP);
                    btnSend.Enabled = true;
                    btnConnect.Enabled = false;
                    Indexer.Enabled = true;
                    lblStatServer.Text = "Server:Connected (" + ipno + ":" + port.ToString() + ")";
                    lblStatServer.ForeColor = System.Drawing.Color.Green;
                    MessageBox.Show("Socket Connected", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer1.Enabled = true;
                    //Send_to_client("OD");
                    //System.Threading.Thread.Sleep(1000);
                    //Send_to_client("OS");


                }
                catch (ArgumentNullException e1)
                {

                    MessageBox.Show(e1.Message, "Argument Null ");
                    throw;
                }
                catch (SocketException e1)
                {

                    MessageBox.Show(e1.Message, "Socket Connection Execption");

                }
                catch (Exception e1)
                {

                    MessageBox.Show(e1.Message, "All Other Exception");

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Socket Creation Exceprton");

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            string data = Send_to_client(tbSend.Text);
            CommandParser(data);
            Debug.WriteLine(tbSend.Text);

        }


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 childForm = new Form2();
            childForm.DataSent += ParentForm_DataSent;
            childForm.ShowDialog();


        }
        private void ParentForm_DataSent(object sender, DataEventArgs e)
        {
            string receivedData = e.Data;
            // Process the received data from the child form
            lblUser.Text = "User: " + receivedData;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Send heart beat HB pulse here.
            string cmdStr = "HB";
            string data = Send_to_client(cmdStr);
            string[] parList = CommandParser(data); // UpdateGui
            //Beeper Action
            if (indiSHome.Value == false)
            {
                tmrSourceOUT.Enabled = true;
                SourceOut = true;
            }
            else
            {
                tmrSourceOUT.Enabled = false;
                SourceOut = false;
            }
            //Beeper Action over

            if (ts.Active)
            {
                btnStartCycle.Text = "Cycle On";
                btnStartCycle.Enabled = false;
                btnStopCycle.Enabled = true;
                cbSource.Enabled = false;
                cbDummy.Enabled = false;
                if (Fault) // If any fault is there, stop the cycle
                {
                    ts.Active = false;
                    WriteLogfile("Cycle Aborted due to Fault.");
                }
                else
                {
                    if (cbDummy.Checked && cbSource.Checked)
                        Combinedcycle();
                    if (!cbDummy.Checked && cbSource.Checked)
                        Sourcecycle();
                    if (cbDummy.Checked && !cbSource.Checked)
                        Dummycycle();
                }

            }
            else
            {
                btnStartCycle.Text = "Cycle Start";
                btnStopCycle.Enabled = false;
                btnStartCycle.Enabled = true;
                cbSource.Enabled = true;
                cbDummy.Enabled = true;
            }





        }
        private void Sourcecycle()
        {

            string cmdStr;
            string data;
            int tipPosition = 4200;

            if (ts.Active)
            {
                switch (ts.State)
                {
                    case 0://Send Dummy out
                        if (ts.StopIssued)
                        {
                            ts.Active = false;
                            WriteLogfile("--------Cycle manually halted. ------------");
                            break;
                        }
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            //cmdStr = "MSF" + tipPosition + ",";
                            cmdStr = "S25800" + ",";
                            ts.LastCommandSent = "M";
                            data = Send_to_client(cmdStr);
                            WriteLogfile("Source Sent Out.");
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 1:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Tip position." + ResponceData.DummyPosMM());
                            cmdStr = "W30";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 2:
                        if (!indCmdProgress.Value)
                        {
                            // Send Dummy home ie to origin
                            data = Send_to_client("OS");
                            //data = Send_to_client("OD");
                            ts.LastCommandSent = "O";
                            WriteLogfile("Source Sent to Home.");
                            Debug.WriteLine("OS");
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 3:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Home.");
                            NoOfCycles++;
                            lblcyclesCompleted.Text = NoOfCycles.ToString();
                            WriteLogfile("Cycles Completed: " + NoOfCycles.ToString());
                            Debug.WriteLine("Cycles Completed: " + NoOfCycles.ToString());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 4:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed

                            if (NoOfCycles >= TotalCycles)
                            {
                                ts.Active = false; // stop the cycle
                                WriteLogfile("xxxxx   Total cycles completed. " + NoOfCycles.ToString() + "  xxxx");
                            }
                            ts.State = 0; // Start another cycle

                        }
                        break;

                } // End of switch.
            }
        }
        private void Dummycycle()
        {

            string cmdStr;
            string data;
            int tipPosition = 4200;

            if (ts.Active)
            {
                switch (ts.State)
                {
                    case 0://Send Dummy out
                        if (ts.StopIssued)
                        {
                            ts.Active = false;
                            WriteLogfile("--------Cycle manually halted. ------------");
                            break;
                        }
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            cmdStr = "D25800" + ",";
                            //cmdStr = "MDF" + tipPosition + ",";
                            ts.LastCommandSent = "MDF";
                            data = Send_to_client(cmdStr);
                            WriteLogfile("Dummy Sent Out.");
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 1:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Tip position." + ResponceData.DummyPosMM());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 2:
                        if (!indCmdProgress.Value)
                        {
                            // Send Dummy home ie to origin
                            data = Send_to_client("OD");
                            //data = Send_to_client("OD");
                            ts.LastCommandSent = "O";
                            WriteLogfile("Dummy Sent to Home.");
                            Debug.WriteLine("OS");
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 3:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Home.");
                            NoOfCycles++;
                            lblcyclesCompleted.Text = NoOfCycles.ToString();
                            WriteLogfile("Cycles Completed: " + NoOfCycles.ToString());
                            Debug.WriteLine("Cycles Completed: " + NoOfCycles.ToString());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 4:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed

                            if (NoOfCycles >= TotalCycles)
                            {
                                ts.Active = false; // stop the cycle
                                WriteLogfile("xxxxx   Total cycles completed. " + NoOfCycles.ToString() + "  xxxx");
                            }
                            ts.State = 0; // Start another cycle

                        }
                        break;

                } // End of switch.
            }
        }
        private void Combinedcycle()
        {

            string cmdStr;
            string data;
            int tipPosition = 4200;

            if (ts.Active)
            {
                switch (ts.State)
                {
                    case 0://Send Dummy out
                        if (ts.StopIssued)
                        {
                            ts.Active = false;
                            WriteLogfile("--------Cycle manually halted. ------------");
                            break;

                        }
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            cmdStr = "MDF" + tipPosition + ",";
                            //cmdStr = "MDF" + tipPosition + ",";
                            ts.LastCommandSent = "MDF";
                            data = Send_to_client(cmdStr);
                            WriteLogfile("Dummy Sent Out.");
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 1:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Tip position." + ResponceData.DummyPosMM());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 2:
                        if (!indCmdProgress.Value)
                        {
                            // Send Dummy home ie to origin
                            data = Send_to_client("OD");
                            //data = Send_to_client("OD");
                            ts.LastCommandSent = "O";
                            WriteLogfile("Dummy Sent to Home.");
                            Debug.WriteLine("OS");
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 3:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Home.");
                            //NoOfCycles++;
                            //lblcyclesCompleted.Text = NoOfCycles.ToString();
                            WriteLogfile("Cycles Completed: " + NoOfCycles.ToString());
                            Debug.WriteLine("Cycles Completed: " + NoOfCycles.ToString());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 4:
                        if (ts.StopIssued)
                        {
                            ts.Active = false;
                            WriteLogfile("--------Cycle manually halted. ------------");
                            break;
                        }
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            cmdStr = "MSF" + tipPosition + ",";
                            //cmdStr = "MDF" + tipPosition + ",";
                            ts.LastCommandSent = "M";
                            data = Send_to_client(cmdStr);
                            WriteLogfile("Source Sent Out.");
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 5:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Tip position." + ResponceData.DummyPosMM());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 6:
                        if (!indCmdProgress.Value)
                        {
                            // Send Dummy home ie to origin
                            data = Send_to_client("OS");
                            //data = Send_to_client("OD");
                            ts.LastCommandSent = "O";
                            WriteLogfile("Source Sent to Home.");
                            Debug.WriteLine("OS");
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 7:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed
                            WriteLogfile("Source Reached Home.");
                            NoOfCycles++;
                            lblcyclesCompleted.Text = NoOfCycles.ToString();
                            WriteLogfile("Cycles Completed: " + NoOfCycles.ToString());
                            Debug.WriteLine("Cycles Completed: " + NoOfCycles.ToString());
                            cmdStr = "W5";
                            ts.LastCommandSent = "W";
                            data = Send_to_client(cmdStr);
                            Debug.WriteLine(cmdStr);
                            ts.State = ts.State + 1;
                        }
                        break;
                    case 8:
                        if (!indCmdProgress.Value)
                        {  // if previous command is completed

                            if (NoOfCycles >= TotalCycles)
                            {
                                ts.Active = false; // stop the cycle
                                WriteLogfile("xxxxx   Total cycles completed. " + NoOfCycles.ToString() + "  xxxx");
                            }
                            ts.State = 0; // Start another cycle

                        }
                        break;



                } // End of switch.
            }
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 abtForm = new Form3();
            abtForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            abtForm.Show();
        }


        private void btnIndxCCW_Click(object sender, EventArgs e)
        {

            string countStr = tbIndxCount.Text;
            string cmdStr = "MIF" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);


        }

        private void btnIndxCW_Click(object sender, EventArgs e)
        {
            string countStr = tbIndxCount.Text;
            string cmdStr = "MIR" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }
        private void btnD_out_Click(object sender, EventArgs e)
        {
            string countStr = tbDcount.Text;
            string cmdStr = "MDF" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnD_in_Click(object sender, EventArgs e)
        {
            string countStr = tbDcount.Text;
            string cmdStr = "MDR" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);



        }
        private void btnS_out_Click(object sender, EventArgs e)
        {
            string countStr = tbScount.Text;
            string cmdStr = "MSF" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }
        private void btnS_in_Click(object sender, EventArgs e)
        {
            string countStr = tbScount.Text;
            string cmdStr = "MSR" + countStr + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);

        }




        private void btnHome_Click(object sender, EventArgs e)
        {

            string cmdStr = "O" + "I"; // Send Indexer to origin
            if (indIndexCalibrated.Value)
                cmdStr = "I";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }
        private void btnS_home_Click(object sender, EventArgs e)
        {
            string cmdStr = "O" + "S"; // Send Indexer to origin
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnD_home_Click(object sender, EventArgs e)
        {
            string cmdStr = "O" + "D"; // Send Indexer to origin
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }



        private void btn_EReset_Click(object sender, EventArgs e) //Indexer encoder Reset
        {
            string cmdStr = "E" + "I"; //
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnS_Ereset_Click(object sender, EventArgs e)
        {
            string cmdStr = "E" + "S";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnD_Ereset_Click(object sender, EventArgs e)// Dummy Encoder Reset to Zero
        {
            string cmdStr = "E" + "D";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }




        private void tbDcount_TextChanged(object sender, EventArgs e)
        {

        }



        private void backWorkerTreatment_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void lblHelpCmd_Click(object sender, EventArgs e)
        {

        }

        private void indexTo_Click(object sender, EventArgs e)
        {
            int v = indexerEncPosition[(int)numericUpDown1.Value];
            string data = Send_to_client("P" + v.ToString());


        }

        private void button1_Click(object sender, EventArgs e)
        {


            ts.Active = true;


        }

        private void listOfCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpSheet helpSheet = new HelpSheet();
            helpSheet.Show();
        }

        private void tmrSourceOUT_Tick(object sender, EventArgs e)
        {

            Console.Beep();
        }

        private void btAs_Click(object sender, EventArgs e)
        {

            string cmdStr = "AS";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btAE_Click(object sender, EventArgs e)
        {

            string cmdStr = "AE";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnEmgStop_Click(object sender, EventArgs e)
        {

            string cmdStr = "Q";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnEmgReset_Click(object sender, EventArgs e)
        {

            string cmdStr = "R";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            string cmdStr = "MIR" + "10" + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            string cmdStr = "MIF" + "10" + ",";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void indexerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexerData frm = new IndexerData();
            frm.ShowDialog();
        }

        private void btnStartCycle_Click(object sender, EventArgs e)
        {


            WriteLogfile("--------Cycle started. (N= " + numMaxcycles.Value + " ) ------------");

            TotalCycles = Convert.ToInt32(numMaxcycles.Value);
            ts.Active = true;
            ts.StopIssued = false;
            NoOfCycles = 0;

        }
        private void WriteLogfile(string msg)
        {
            //string pathcyclelog = Application.StartupPath + "CycleLog.txt";

            log = new StreamWriter(pathcyclelog, append: true);
            //String timeStamp = (DateTime.Now).ToString("yyyyMMddHHmmssffff");
            String timeStamp = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.f");
            log.WriteLine("{0,25}. {1} ", timeStamp, msg);
            log.Close();
        }


        private void btnStopCycle_Click(object sender, EventArgs e)
        {
            ts.StopIssued = true;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveRawData_Click(object sender, EventArgs e)
        {
            StreamWriter log1 = new StreamWriter(rawDatalog, append: true);
            log1.WriteLine(tbRecieved.Text);
            log1.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string cmdStr = "MSS,";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void btnMDS_Click(object sender, EventArgs e)
        {
            string cmdStr = "MDS,";
            string data = Send_to_client(cmdStr);
            CommandParser(data);
            Debug.WriteLine(cmdStr);
        }

        private void lblcyclesCompleted_Click(object sender, EventArgs e)
        {

        }

        private void tbSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbRecieved_TextChanged(object sender, EventArgs e)
        {

        }
    }
}