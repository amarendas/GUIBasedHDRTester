namespace GUISocket
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backWorkerTreatment = new System.ComponentModel.BackgroundWorker();
            tbRecieved = new TextBox();
            groupBox1 = new GroupBox();
            lblUser = new Label();
            lblStatServer = new Label();
            panel1 = new Panel();
            btnDisconnect = new Button();
            tbPort = new TextBox();
            tbIP = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tbSend = new TextBox();
            btnSend = new Button();
            label3 = new Label();
            btnConnect = new Button();
            label24 = new Label();
            indIndexCalibrated = new WinFormsControlLibrary1.Indicator();
            indCmdProgress = new WinFormsControlLibrary1.Indicator();
            lblCmdInProg = new Label();
            label9 = new Label();
            indSourcOut = new WinFormsControlLibrary1.Indicator();
            label4 = new Label();
            menuStrip1 = new MenuStrip();
            loginToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            indexerDataToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            tbSrcEnc = new TextBox();
            tbDmyEnc = new TextBox();
            indIndexLock = new WinFormsControlLibrary1.Indicator();
            indAdapterSensor = new WinFormsControlLibrary1.Indicator();
            indiIndexHome = new WinFormsControlLibrary1.Indicator();
            indiSourceOut = new WinFormsControlLibrary1.Indicator();
            indicSOver = new WinFormsControlLibrary1.Indicator();
            indiSHome = new WinFormsControlLibrary1.Indicator();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            indiDOverShoot = new WinFormsControlLibrary1.Indicator();
            indiDHome = new WinFormsControlLibrary1.Indicator();
            label16 = new Label();
            label17 = new Label();
            IndexerPosition = new TimerClock();
            progressBarD = new ProgressBar();
            tbIndxCount = new TextBox();
            btnIndxCW = new Button();
            btnIndxCCW = new Button();
            btnHome = new Button();
            Indexer = new GroupBox();
            btnRight = new Button();
            btnLeft = new Button();
            btnI_EReset = new Button();
            label6 = new Label();
            lblIndexerCount = new Label();
            label20 = new Label();
            btAE = new Button();
            btAs = new Button();
            indexTo = new Button();
            numericUpDown1 = new NumericUpDown();
            gpSDrive = new GroupBox();
            btnMSS = new Button();
            lblSEnc = new Label();
            label31 = new Label();
            btnS_Ereset = new Button();
            label18 = new Label();
            tbScount = new TextBox();
            btnS_home = new Button();
            btnS_in = new Button();
            btnS_out = new Button();
            gpDDrive = new GroupBox();
            btnMDS = new Button();
            lblDEnc = new Label();
            label33 = new Label();
            btnD_Ereset = new Button();
            label19 = new Label();
            tbDcount = new TextBox();
            btnD_home = new Button();
            btnD_in = new Button();
            btnD_out = new Button();
            progressBarS = new ProgressBar();
            label21 = new Label();
            label22 = new Label();
            lblIndexSlotNo = new Label();
            lblTimeElapsed = new Label();
            label8 = new Label();
            tmrSourceOUT = new System.Windows.Forms.Timer(components);
            btnEmgStop = new Button();
            btnEmgReset = new Button();
            label5 = new Label();
            panel2 = new Panel();
            label25 = new Label();
            btnStartCycle = new Button();
            numMaxcycles = new NumericUpDown();
            btnStopCycle = new Button();
            lblcyclesCompleted = new Label();
            pbDwell = new ProgressBar();
            groupBox2 = new GroupBox();
            cbDummy = new CheckBox();
            cbSource = new CheckBox();
            label28 = new Label();
            label27 = new Label();
            indTretSw = new WinFormsControlLibrary1.Indicator();
            indEmgSw = new WinFormsControlLibrary1.Indicator();
            indDoorSw = new WinFormsControlLibrary1.Indicator();
            indPwrSw = new WinFormsControlLibrary1.Indicator();
            gbSafety = new GroupBox();
            lblSysFault = new Label();
            indSysFault = new WinFormsControlLibrary1.Indicator();
            lblACPower = new Label();
            lblDoor = new Label();
            lblEmgSw = new Label();
            lblKeySw = new Label();
            btnSaveRawData = new Button();
            label32 = new Label();
            lblErrorcode = new Label();
            pBCmdInProgress = new ProgressBar();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            Indexer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            gpSDrive.SuspendLayout();
            gpDDrive.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxcycles).BeginInit();
            groupBox2.SuspendLayout();
            gbSafety.SuspendLayout();
            SuspendLayout();
            // 
            // backWorkerTreatment
            // 
            backWorkerTreatment.DoWork += backWorkerTreatment_DoWork;
            // 
            // tbRecieved
            // 
            tbRecieved.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tbRecieved.Cursor = Cursors.No;
            tbRecieved.Location = new Point(1011, 110);
            tbRecieved.MaxLength = 25;
            tbRecieved.Multiline = true;
            tbRecieved.Name = "tbRecieved";
            tbRecieved.ReadOnly = true;
            tbRecieved.Size = new Size(241, 505);
            tbRecieved.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblUser);
            groupBox1.Controls.Add(lblStatServer);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(tbSend);
            groupBox1.Controls.Add(btnSend);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(0, 679);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1252, 81);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 52);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(36, 15);
            lblUser.TabIndex = 1;
            lblUser.Text = "User: ";
            // 
            // lblStatServer
            // 
            lblStatServer.AutoSize = true;
            lblStatServer.ForeColor = Color.Red;
            lblStatServer.Location = new Point(1, 19);
            lblStatServer.Name = "lblStatServer";
            lblStatServer.Size = new Size(110, 15);
            lblStatServer.TabIndex = 0;
            lblStatServer.Text = "Server: Disconected";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDisconnect);
            panel1.Controls.Add(tbPort);
            panel1.Controls.Add(tbIP);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(135, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 56);
            panel1.TabIndex = 49;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(266, 15);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(130, 35);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Dis-Connect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += Form1_Closing;
            // 
            // tbPort
            // 
            tbPort.Location = new Point(156, 30);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(59, 23);
            tbPort.TabIndex = 3;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(3, 30);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(147, 23);
            tbIP.TabIndex = 2;
            tbIP.Text = "200.100.2.4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 15);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 15);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "ServerIP";
            // 
            // tbSend
            // 
            tbSend.Location = new Point(956, 41);
            tbSend.Name = "tbSend";
            tbSend.Size = new Size(151, 23);
            tbSend.TabIndex = 8;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(1113, 19);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(107, 52);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(956, 19);
            label3.Name = "label3";
            label3.Size = new Size(143, 15);
            label3.TabIndex = 10;
            label3.Text = "Command To send (RAW)";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(1113, 59);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(130, 35);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(403, 51);
            label24.Name = "label24";
            label24.Size = new Size(145, 15);
            label24.TabIndex = 86;
            label24.Text = "Indexer Calibrated (Green)";
            // 
            // indIndexCalibrated
            // 
            indIndexCalibrated.Location = new Point(355, 40);
            indIndexCalibrated.Name = "indIndexCalibrated";
            indIndexCalibrated.Size = new Size(40, 40);
            indIndexCalibrated.TabIndex = 85;
            indIndexCalibrated.Value = false;
            // 
            // indCmdProgress
            // 
            indCmdProgress.Location = new Point(666, 29);
            indCmdProgress.Name = "indCmdProgress";
            indCmdProgress.Size = new Size(29, 29);
            indCmdProgress.TabIndex = 76;
            indCmdProgress.Value = false;
            // 
            // lblCmdInProg
            // 
            lblCmdInProg.AutoSize = true;
            lblCmdInProg.Location = new Point(699, 40);
            lblCmdInProg.Name = "lblCmdInProg";
            lblCmdInProg.Size = new Size(51, 15);
            lblCmdInProg.TabIndex = 77;
            lblCmdInProg.Text = "M/c Idle";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(76, 48);
            label9.Name = "label9";
            label9.Size = new Size(87, 32);
            label9.TabIndex = 79;
            label9.Text = "Source";
            label9.Click += label9_Click;
            // 
            // indSourcOut
            // 
            indSourcOut.Location = new Point(25, 43);
            indSourcOut.Name = "indSourcOut";
            indSourcOut.Size = new Size(44, 44);
            indSourcOut.TabIndex = 78;
            indSourcOut.Value = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1026, 628);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 11;
            label4.Text = "Data Recieved";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { loginToolStripMenuItem, aboutToolStripMenuItem, helpToolStripMenuItem, indexerDataToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.Size = new Size(49, 20);
            loginToolStripMenuItem.Text = "Login";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // indexerDataToolStripMenuItem
            // 
            indexerDataToolStripMenuItem.Name = "indexerDataToolStripMenuItem";
            indexerDataToolStripMenuItem.Size = new Size(82, 20);
            indexerDataToolStripMenuItem.Text = "IndexerData";
            indexerDataToolStripMenuItem.Click += indexerDataToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            // 
            // tbSrcEnc
            // 
            tbSrcEnc.Location = new Point(146, 549);
            tbSrcEnc.Name = "tbSrcEnc";
            tbSrcEnc.Size = new Size(86, 23);
            tbSrcEnc.TabIndex = 27;
            // 
            // tbDmyEnc
            // 
            tbDmyEnc.Location = new Point(146, 497);
            tbDmyEnc.Name = "tbDmyEnc";
            tbDmyEnc.Size = new Size(86, 23);
            tbDmyEnc.TabIndex = 28;
            // 
            // indIndexLock
            // 
            indIndexLock.Location = new Point(607, 596);
            indIndexLock.Name = "indIndexLock";
            indIndexLock.Size = new Size(47, 47);
            indIndexLock.TabIndex = 29;
            indIndexLock.Value = false;
            // 
            // indAdapterSensor
            // 
            indAdapterSensor.Location = new Point(471, 596);
            indAdapterSensor.Name = "indAdapterSensor";
            indAdapterSensor.Size = new Size(47, 47);
            indAdapterSensor.TabIndex = 30;
            indAdapterSensor.Value = false;
            // 
            // indiIndexHome
            // 
            indiIndexHome.Location = new Point(544, 596);
            indiIndexHome.Name = "indiIndexHome";
            indiIndexHome.Size = new Size(47, 47);
            indiIndexHome.TabIndex = 31;
            indiIndexHome.Value = false;
            // 
            // indiSourceOut
            // 
            indiSourceOut.Location = new Point(740, 596);
            indiSourceOut.Name = "indiSourceOut";
            indiSourceOut.Size = new Size(47, 47);
            indiSourceOut.TabIndex = 32;
            indiSourceOut.Value = false;
            // 
            // indicSOver
            // 
            indicSOver.Location = new Point(291, 596);
            indicSOver.Name = "indicSOver";
            indicSOver.Size = new Size(47, 47);
            indicSOver.TabIndex = 33;
            indicSOver.Value = false;
            // 
            // indiSHome
            // 
            indiSHome.Location = new Point(216, 596);
            indiSHome.Name = "indiSHome";
            indiSHome.Size = new Size(47, 47);
            indiSHome.TabIndex = 34;
            indiSHome.Value = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(607, 646);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 35;
            label10.Text = "Index Lock";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(478, 646);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 36;
            label11.Text = "Rot_C";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(533, 646);
            label12.Name = "label12";
            label12.Size = new Size(69, 15);
            label12.TabIndex = 38;
            label12.Text = "IndexHome";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(742, 646);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 39;
            label13.Text = "S Out";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(280, 646);
            label14.Name = "label14";
            label14.Size = new Size(71, 15);
            label14.TabIndex = 40;
            label14.Text = "S Overshoot";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(214, 646);
            label15.Name = "label15";
            label15.Size = new Size(49, 15);
            label15.TabIndex = 41;
            label15.Text = "S Home";
            // 
            // indiDOverShoot
            // 
            indiDOverShoot.Location = new Point(93, 596);
            indiDOverShoot.Name = "indiDOverShoot";
            indiDOverShoot.Size = new Size(47, 47);
            indiDOverShoot.TabIndex = 42;
            indiDOverShoot.Value = false;
            // 
            // indiDHome
            // 
            indiDHome.Location = new Point(22, 596);
            indiDHome.Name = "indiDHome";
            indiDHome.Size = new Size(47, 47);
            indiDHome.TabIndex = 43;
            indiDHome.Value = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(72, 646);
            label16.Name = "label16";
            label16.Size = new Size(73, 15);
            label16.TabIndex = 44;
            label16.Text = "D Overshoot";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(18, 646);
            label17.Name = "label17";
            label17.Size = new Size(51, 15);
            label17.TabIndex = 45;
            label17.Text = "D Home";
            // 
            // IndexerPosition
            // 
            IndexerPosition.BackColor = SystemColors.ActiveBorder;
            IndexerPosition.BrushThickness = 6;
            IndexerPosition.CircleColor = Color.Aqua;
            IndexerPosition.CtValue = 0;
            IndexerPosition.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            IndexerPosition.Location = new Point(7, 36);
            IndexerPosition.Margin = new Padding(7, 7, 7, 7);
            IndexerPosition.MaxValue1 = 360;
            IndexerPosition.Name = "IndexerPosition";
            IndexerPosition.Size = new Size(156, 156);
            IndexerPosition.Size1 = 156;
            IndexerPosition.TabIndex = 50;
            // 
            // progressBarD
            // 
            progressBarD.Location = new Point(238, 497);
            progressBarD.Maximum = 60000;
            progressBarD.Name = "progressBarD";
            progressBarD.Size = new Size(548, 28);
            progressBarD.Step = 1;
            progressBarD.TabIndex = 51;
            // 
            // tbIndxCount
            // 
            tbIndxCount.Location = new Point(12, 43);
            tbIndxCount.MaxLength = 10;
            tbIndxCount.Name = "tbIndxCount";
            tbIndxCount.Size = new Size(136, 23);
            tbIndxCount.TabIndex = 52;
            tbIndxCount.TabStop = false;
            tbIndxCount.Text = "1000";
            tbIndxCount.TextAlign = HorizontalAlignment.Center;
            tbIndxCount.WordWrap = false;
            // 
            // btnIndxCW
            // 
            btnIndxCW.Location = new Point(6, 132);
            btnIndxCW.Name = "btnIndxCW";
            btnIndxCW.Size = new Size(136, 36);
            btnIndxCW.TabIndex = 55;
            btnIndxCW.Text = "Move CW";
            btnIndxCW.UseVisualStyleBackColor = true;
            btnIndxCW.Click += btnIndxCW_Click;
            // 
            // btnIndxCCW
            // 
            btnIndxCCW.Location = new Point(9, 80);
            btnIndxCCW.Name = "btnIndxCCW";
            btnIndxCCW.Size = new Size(136, 36);
            btnIndxCCW.TabIndex = 56;
            btnIndxCCW.Text = "Move CCW";
            btnIndxCCW.UseVisualStyleBackColor = true;
            btnIndxCCW.Click += btnIndxCCW_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(5, 188);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(140, 56);
            btnHome.TabIndex = 57;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // Indexer
            // 
            Indexer.Controls.Add(btnRight);
            Indexer.Controls.Add(btnLeft);
            Indexer.Controls.Add(btnI_EReset);
            Indexer.Controls.Add(label6);
            Indexer.Controls.Add(lblIndexerCount);
            Indexer.Controls.Add(tbIndxCount);
            Indexer.Controls.Add(label20);
            Indexer.Controls.Add(btnHome);
            Indexer.Controls.Add(btAE);
            Indexer.Controls.Add(btnIndxCCW);
            Indexer.Controls.Add(btAs);
            Indexer.Controls.Add(btnIndxCW);
            Indexer.Controls.Add(indexTo);
            Indexer.Controls.Add(numericUpDown1);
            Indexer.Location = new Point(18, 110);
            Indexer.Name = "Indexer";
            Indexer.Size = new Size(295, 301);
            Indexer.TabIndex = 58;
            Indexer.TabStop = false;
            Indexer.Text = "Indexer Motion";
            // 
            // btnRight
            // 
            btnRight.Location = new Point(236, 109);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(34, 32);
            btnRight.TabIndex = 86;
            btnRight.Text = ">>";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnLeft
            // 
            btnLeft.Location = new Point(163, 109);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(34, 32);
            btnLeft.TabIndex = 85;
            btnLeft.Text = "<<";
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // btnI_EReset
            // 
            btnI_EReset.Location = new Point(5, 262);
            btnI_EReset.Name = "btnI_EReset";
            btnI_EReset.Size = new Size(140, 33);
            btnI_EReset.TabIndex = 60;
            btnI_EReset.Text = "E Reset";
            btnI_EReset.UseVisualStyleBackColor = true;
            btnI_EReset.Click += btn_EReset_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 21);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 58;
            label6.Text = "Motor Counts";
            // 
            // lblIndexerCount
            // 
            lblIndexerCount.AutoSize = true;
            lblIndexerCount.Location = new Point(257, 19);
            lblIndexerCount.Name = "lblIndexerCount";
            lblIndexerCount.Size = new Size(13, 15);
            lblIndexerCount.TabIndex = 84;
            lblIndexerCount.Text = "0";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(163, 21);
            label20.Name = "label20";
            label20.Size = new Size(78, 15);
            label20.TabIndex = 83;
            label20.Text = "Indx E.Count.";
            // 
            // btAE
            // 
            btAE.Location = new Point(163, 80);
            btAE.Name = "btAE";
            btAE.Size = new Size(107, 23);
            btAE.TabIndex = 82;
            btAE.Text = "AE";
            btAE.UseVisualStyleBackColor = true;
            btAE.Click += btAE_Click;
            // 
            // btAs
            // 
            btAs.Location = new Point(163, 42);
            btAs.Name = "btAs";
            btAs.Size = new Size(107, 23);
            btAs.TabIndex = 81;
            btAs.Text = "AS";
            btAs.UseVisualStyleBackColor = true;
            btAs.Click += btAs_Click;
            // 
            // indexTo
            // 
            indexTo.Location = new Point(163, 165);
            indexTo.Name = "indexTo";
            indexTo.Size = new Size(107, 35);
            indexTo.TabIndex = 68;
            indexTo.Text = "Indexer To";
            indexTo.UseVisualStyleBackColor = true;
            indexTo.Click += indexTo_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(163, 211);
            numericUpDown1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(107, 23);
            numericUpDown1.TabIndex = 66;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // gpSDrive
            // 
            gpSDrive.Controls.Add(btnMSS);
            gpSDrive.Controls.Add(lblSEnc);
            gpSDrive.Controls.Add(label31);
            gpSDrive.Controls.Add(btnS_Ereset);
            gpSDrive.Controls.Add(label18);
            gpSDrive.Controls.Add(tbScount);
            gpSDrive.Controls.Add(btnS_home);
            gpSDrive.Controls.Add(btnS_in);
            gpSDrive.Controls.Add(btnS_out);
            gpSDrive.Location = new Point(333, 110);
            gpSDrive.Name = "gpSDrive";
            gpSDrive.Size = new Size(152, 301);
            gpSDrive.TabIndex = 60;
            gpSDrive.TabStop = false;
            gpSDrive.Text = "Source Drive";
            // 
            // btnMSS
            // 
            btnMSS.Location = new Point(6, 170);
            btnMSS.Name = "btnMSS";
            btnMSS.Size = new Size(136, 36);
            btnMSS.TabIndex = 63;
            btnMSS.Text = "S_OUT";
            btnMSS.UseVisualStyleBackColor = true;
            btnMSS.Click += button1_Click_1;
            // 
            // lblSEnc
            // 
            lblSEnc.AutoSize = true;
            lblSEnc.Location = new Point(97, 22);
            lblSEnc.Name = "lblSEnc";
            lblSEnc.Size = new Size(13, 15);
            lblSEnc.TabIndex = 62;
            lblSEnc.Text = "0";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(11, 24);
            label31.Name = "label31";
            label31.Size = new Size(67, 15);
            label31.TabIndex = 61;
            label31.Text = "Enc Counts";
            // 
            // btnS_Ereset
            // 
            btnS_Ereset.Location = new Point(4, 260);
            btnS_Ereset.Name = "btnS_Ereset";
            btnS_Ereset.Size = new Size(136, 36);
            btnS_Ereset.TabIndex = 60;
            btnS_Ereset.Text = "E Reset";
            btnS_Ereset.UseVisualStyleBackColor = true;
            btnS_Ereset.Click += btnS_Ereset_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(9, 46);
            label18.Name = "label18";
            label18.Size = new Size(81, 15);
            label18.TabIndex = 58;
            label18.Text = "Motor Counts";
            // 
            // tbScount
            // 
            tbScount.Location = new Point(98, 42);
            tbScount.MaxLength = 10;
            tbScount.Name = "tbScount";
            tbScount.Size = new Size(47, 23);
            tbScount.TabIndex = 52;
            tbScount.TabStop = false;
            tbScount.Text = "100";
            tbScount.TextAlign = HorizontalAlignment.Center;
            tbScount.WordWrap = false;
            // 
            // btnS_home
            // 
            btnS_home.Location = new Point(4, 215);
            btnS_home.Name = "btnS_home";
            btnS_home.Size = new Size(136, 36);
            btnS_home.TabIndex = 57;
            btnS_home.Text = "Home";
            btnS_home.UseVisualStyleBackColor = true;
            btnS_home.Click += btnS_home_Click;
            // 
            // btnS_in
            // 
            btnS_in.Location = new Point(6, 80);
            btnS_in.Name = "btnS_in";
            btnS_in.Size = new Size(136, 36);
            btnS_in.TabIndex = 56;
            btnS_in.Text = "Move IN";
            btnS_in.UseVisualStyleBackColor = true;
            btnS_in.Click += btnS_in_Click;
            // 
            // btnS_out
            // 
            btnS_out.Location = new Point(6, 125);
            btnS_out.Name = "btnS_out";
            btnS_out.Size = new Size(136, 36);
            btnS_out.TabIndex = 55;
            btnS_out.Text = "Move OUT";
            btnS_out.UseVisualStyleBackColor = true;
            btnS_out.Click += btnS_out_Click;
            // 
            // gpDDrive
            // 
            gpDDrive.Controls.Add(btnMDS);
            gpDDrive.Controls.Add(lblDEnc);
            gpDDrive.Controls.Add(label33);
            gpDDrive.Controls.Add(btnD_Ereset);
            gpDDrive.Controls.Add(label19);
            gpDDrive.Controls.Add(tbDcount);
            gpDDrive.Controls.Add(btnD_home);
            gpDDrive.Controls.Add(btnD_in);
            gpDDrive.Controls.Add(btnD_out);
            gpDDrive.Location = new Point(502, 110);
            gpDDrive.Name = "gpDDrive";
            gpDDrive.Size = new Size(152, 301);
            gpDDrive.TabIndex = 61;
            gpDDrive.TabStop = false;
            gpDDrive.Text = "Dummy Drive";
            // 
            // btnMDS
            // 
            btnMDS.Location = new Point(9, 170);
            btnMDS.Name = "btnMDS";
            btnMDS.Size = new Size(136, 36);
            btnMDS.TabIndex = 63;
            btnMDS.Text = "S_OUT";
            btnMDS.UseVisualStyleBackColor = true;
            btnMDS.Click += btnMDS_Click;
            // 
            // lblDEnc
            // 
            lblDEnc.AutoSize = true;
            lblDEnc.Location = new Point(98, 19);
            lblDEnc.Name = "lblDEnc";
            lblDEnc.Size = new Size(13, 15);
            lblDEnc.TabIndex = 62;
            lblDEnc.Text = "0";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(6, 18);
            label33.Name = "label33";
            label33.Size = new Size(67, 15);
            label33.TabIndex = 61;
            label33.Text = "Enc Counts";
            // 
            // btnD_Ereset
            // 
            btnD_Ereset.Location = new Point(9, 260);
            btnD_Ereset.Name = "btnD_Ereset";
            btnD_Ereset.Size = new Size(136, 36);
            btnD_Ereset.TabIndex = 60;
            btnD_Ereset.Text = "E Reset";
            btnD_Ereset.UseVisualStyleBackColor = true;
            btnD_Ereset.Click += btnD_Ereset_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 46);
            label19.Name = "label19";
            label19.Size = new Size(81, 15);
            label19.TabIndex = 58;
            label19.Text = "Motor Counts";
            // 
            // tbDcount
            // 
            tbDcount.Location = new Point(90, 42);
            tbDcount.MaxLength = 10;
            tbDcount.Name = "tbDcount";
            tbDcount.Size = new Size(55, 23);
            tbDcount.TabIndex = 52;
            tbDcount.TabStop = false;
            tbDcount.Text = "100";
            tbDcount.TextAlign = HorizontalAlignment.Center;
            tbDcount.WordWrap = false;
            tbDcount.TextChanged += tbDcount_TextChanged;
            // 
            // btnD_home
            // 
            btnD_home.Location = new Point(9, 215);
            btnD_home.Name = "btnD_home";
            btnD_home.Size = new Size(136, 36);
            btnD_home.TabIndex = 57;
            btnD_home.Text = "Home";
            btnD_home.UseVisualStyleBackColor = true;
            btnD_home.Click += btnD_home_Click;
            // 
            // btnD_in
            // 
            btnD_in.Location = new Point(9, 80);
            btnD_in.Name = "btnD_in";
            btnD_in.Size = new Size(136, 36);
            btnD_in.TabIndex = 56;
            btnD_in.Text = "Move IN";
            btnD_in.UseVisualStyleBackColor = true;
            btnD_in.Click += btnD_in_Click;
            // 
            // btnD_out
            // 
            btnD_out.Location = new Point(9, 125);
            btnD_out.Name = "btnD_out";
            btnD_out.Size = new Size(136, 36);
            btnD_out.TabIndex = 55;
            btnD_out.Text = "Move OUT";
            btnD_out.UseVisualStyleBackColor = true;
            btnD_out.Click += btnD_out_Click;
            // 
            // progressBarS
            // 
            progressBarS.Location = new Point(239, 549);
            progressBarS.Maximum = 60000;
            progressBarS.Name = "progressBarS";
            progressBarS.Size = new Size(548, 26);
            progressBarS.Step = 1;
            progressBarS.TabIndex = 70;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(29, 549);
            label21.Name = "label21";
            label21.Size = new Size(89, 15);
            label21.TabIndex = 71;
            label21.Text = "Source Position";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(29, 497);
            label22.Name = "label22";
            label22.Size = new Size(96, 15);
            label22.TabIndex = 72;
            label22.Text = "Dummy Position";
            // 
            // lblIndexSlotNo
            // 
            lblIndexSlotNo.AutoSize = true;
            lblIndexSlotNo.Location = new Point(98, 202);
            lblIndexSlotNo.Name = "lblIndexSlotNo";
            lblIndexSlotNo.Size = new Size(55, 15);
            lblIndexSlotNo.TabIndex = 74;
            lblIndexSlotNo.Text = "Initilizing";
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimeElapsed.ForeColor = Color.Red;
            lblTimeElapsed.Location = new Point(93, 426);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(46, 54);
            lblTimeElapsed.TabIndex = 76;
            lblTimeElapsed.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 445);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 77;
            label8.Text = "Dwel Time";
            // 
            // tmrSourceOUT
            // 
            tmrSourceOUT.Interval = 1500;
            tmrSourceOUT.Tick += tmrSourceOUT_Tick;
            // 
            // btnEmgStop
            // 
            btnEmgStop.Location = new Point(453, 425);
            btnEmgStop.Name = "btnEmgStop";
            btnEmgStop.Size = new Size(77, 55);
            btnEmgStop.TabIndex = 85;
            btnEmgStop.Text = "Emg Stop";
            btnEmgStop.UseVisualStyleBackColor = true;
            btnEmgStop.Click += btnEmgStop_Click;
            // 
            // btnEmgReset
            // 
            btnEmgReset.Location = new Point(555, 426);
            btnEmgReset.Name = "btnEmgReset";
            btnEmgReset.Size = new Size(76, 55);
            btnEmgReset.TabIndex = 86;
            btnEmgReset.Text = "Reset Emg";
            btnEmgReset.UseVisualStyleBackColor = true;
            btnEmgReset.Click += btnEmgReset_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(23, 1);
            label5.Name = "label5";
            label5.Size = new Size(118, 28);
            label5.TabIndex = 87;
            label5.Text = "Indexer Arm";
            label5.Click += label5_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label25);
            panel2.Controls.Add(IndexerPosition);
            panel2.Controls.Add(lblIndexSlotNo);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(830, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 232);
            panel2.TabIndex = 88;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(19, 202);
            label25.Name = "label25";
            label25.Size = new Size(44, 15);
            label25.TabIndex = 88;
            label25.Text = "Ch No.";
            // 
            // btnStartCycle
            // 
            btnStartCycle.Location = new Point(7, 239);
            btnStartCycle.Name = "btnStartCycle";
            btnStartCycle.Size = new Size(131, 51);
            btnStartCycle.TabIndex = 90;
            btnStartCycle.Text = "Start Cycle";
            btnStartCycle.UseVisualStyleBackColor = true;
            btnStartCycle.Click += btnStartCycle_Click;
            // 
            // numMaxcycles
            // 
            numMaxcycles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numMaxcycles.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numMaxcycles.Location = new Point(7, 118);
            numMaxcycles.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numMaxcycles.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numMaxcycles.Name = "numMaxcycles";
            numMaxcycles.Size = new Size(120, 29);
            numMaxcycles.TabIndex = 91;
            numMaxcycles.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnStopCycle
            // 
            btnStopCycle.Location = new Point(6, 302);
            btnStopCycle.Name = "btnStopCycle";
            btnStopCycle.Size = new Size(132, 51);
            btnStopCycle.TabIndex = 92;
            btnStopCycle.Text = "Stop Cycle";
            btnStopCycle.UseVisualStyleBackColor = true;
            btnStopCycle.Click += btnStopCycle_Click;
            // 
            // lblcyclesCompleted
            // 
            lblcyclesCompleted.AutoSize = true;
            lblcyclesCompleted.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            lblcyclesCompleted.Location = new Point(67, 22);
            lblcyclesCompleted.Name = "lblcyclesCompleted";
            lblcyclesCompleted.Size = new Size(38, 46);
            lblcyclesCompleted.TabIndex = 93;
            lblcyclesCompleted.Text = "0";
            // 
            // pbDwell
            // 
            pbDwell.Location = new Point(145, 445);
            pbDwell.Maximum = 5;
            pbDwell.Name = "pbDwell";
            pbDwell.Size = new Size(291, 23);
            pbDwell.Step = 1;
            pbDwell.TabIndex = 94;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbDummy);
            groupBox2.Controls.Add(cbSource);
            groupBox2.Controls.Add(label28);
            groupBox2.Controls.Add(label27);
            groupBox2.Controls.Add(numMaxcycles);
            groupBox2.Controls.Add(btnStartCycle);
            groupBox2.Controls.Add(lblcyclesCompleted);
            groupBox2.Controls.Add(btnStopCycle);
            groupBox2.Location = new Point(660, 110);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(153, 371);
            groupBox2.TabIndex = 95;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cycle Generator";
            // 
            // cbDummy
            // 
            cbDummy.AutoSize = true;
            cbDummy.Checked = true;
            cbDummy.CheckState = CheckState.Checked;
            cbDummy.Location = new Point(21, 191);
            cbDummy.Name = "cbDummy";
            cbDummy.Size = new Size(69, 19);
            cbDummy.TabIndex = 97;
            cbDummy.Text = "Dummy";
            cbDummy.UseVisualStyleBackColor = true;
            // 
            // cbSource
            // 
            cbSource.AutoSize = true;
            cbSource.Location = new Point(21, 166);
            cbSource.Name = "cbSource";
            cbSource.Size = new Size(62, 19);
            cbSource.TabIndex = 96;
            cbSource.Text = "Source";
            cbSource.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label28.Location = new Point(7, 22);
            label28.Name = "label28";
            label28.Size = new Size(68, 46);
            label28.TabIndex = 95;
            label28.Text = "N=";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label27.Location = new Point(7, 86);
            label27.Name = "label27";
            label27.Size = new Size(101, 21);
            label27.TabIndex = 94;
            label27.Text = "Target Count:";
            // 
            // indTretSw
            // 
            indTretSw.Location = new Point(11, 22);
            indTretSw.Name = "indTretSw";
            indTretSw.Size = new Size(48, 48);
            indTretSw.TabIndex = 96;
            indTretSw.Value = false;
            // 
            // indEmgSw
            // 
            indEmgSw.Location = new Point(14, 77);
            indEmgSw.Name = "indEmgSw";
            indEmgSw.Size = new Size(45, 45);
            indEmgSw.TabIndex = 97;
            indEmgSw.Value = false;
            // 
            // indDoorSw
            // 
            indDoorSw.Location = new Point(15, 130);
            indDoorSw.Name = "indDoorSw";
            indDoorSw.Size = new Size(44, 44);
            indDoorSw.TabIndex = 98;
            indDoorSw.Value = false;
            // 
            // indPwrSw
            // 
            indPwrSw.Location = new Point(14, 180);
            indPwrSw.Name = "indPwrSw";
            indPwrSw.Size = new Size(44, 44);
            indPwrSw.TabIndex = 99;
            indPwrSw.Value = false;
            // 
            // gbSafety
            // 
            gbSafety.Controls.Add(lblSysFault);
            gbSafety.Controls.Add(indSysFault);
            gbSafety.Controls.Add(lblACPower);
            gbSafety.Controls.Add(lblDoor);
            gbSafety.Controls.Add(lblEmgSw);
            gbSafety.Controls.Add(lblKeySw);
            gbSafety.Controls.Add(indTretSw);
            gbSafety.Controls.Add(indPwrSw);
            gbSafety.Controls.Add(indEmgSw);
            gbSafety.Controls.Add(indDoorSw);
            gbSafety.Location = new Point(819, 360);
            gbSafety.Name = "gbSafety";
            gbSafety.Size = new Size(181, 283);
            gbSafety.TabIndex = 100;
            gbSafety.TabStop = false;
            gbSafety.Text = "Safety Int Lock";
            // 
            // lblSysFault
            // 
            lblSysFault.AutoSize = true;
            lblSysFault.Location = new Point(77, 242);
            lblSysFault.Name = "lblSysFault";
            lblSysFault.Size = new Size(74, 15);
            lblSysFault.TabIndex = 105;
            lblSysFault.Text = "System Fault";
            // 
            // indSysFault
            // 
            indSysFault.Location = new Point(14, 230);
            indSysFault.Name = "indSysFault";
            indSysFault.Size = new Size(44, 44);
            indSysFault.TabIndex = 104;
            indSysFault.Value = false;
            // 
            // lblACPower
            // 
            lblACPower.AutoSize = true;
            lblACPower.Location = new Point(80, 194);
            lblACPower.Name = "lblACPower";
            lblACPower.Size = new Size(40, 15);
            lblACPower.TabIndex = 103;
            lblACPower.Text = "Power";
            // 
            // lblDoor
            // 
            lblDoor.AutoSize = true;
            lblDoor.Location = new Point(75, 143);
            lblDoor.Name = "lblDoor";
            lblDoor.Size = new Size(36, 15);
            lblDoor.TabIndex = 102;
            lblDoor.Text = "Door ";
            // 
            // lblEmgSw
            // 
            lblEmgSw.AutoSize = true;
            lblEmgSw.Location = new Point(70, 83);
            lblEmgSw.Name = "lblEmgSw";
            lblEmgSw.Size = new Size(59, 15);
            lblEmgSw.TabIndex = 101;
            lblEmgSw.Text = "EMG Stop";
            // 
            // lblKeySw
            // 
            lblKeySw.AutoSize = true;
            lblKeySw.Location = new Point(68, 36);
            lblKeySw.Name = "lblKeySw";
            lblKeySw.Size = new Size(76, 15);
            lblKeySw.TabIndex = 100;
            lblKeySw.Text = "Treatment En";
            // 
            // btnSaveRawData
            // 
            btnSaveRawData.Location = new Point(1136, 621);
            btnSaveRawData.Name = "btnSaveRawData";
            btnSaveRawData.Size = new Size(116, 30);
            btnSaveRawData.TabIndex = 101;
            btnSaveRawData.Text = "Save Raw Data";
            btnSaveRawData.UseVisualStyleBackColor = true;
            btnSaveRawData.Click += btnSaveRawData_Click;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(238, 40);
            label32.Name = "label32";
            label32.Size = new Size(69, 15);
            label32.TabIndex = 102;
            label32.Text = "Error Code: ";
            // 
            // lblErrorcode
            // 
            lblErrorcode.AutoSize = true;
            lblErrorcode.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorcode.Location = new Point(254, 55);
            lblErrorcode.Name = "lblErrorcode";
            lblErrorcode.Size = new Size(28, 32);
            lblErrorcode.TabIndex = 103;
            lblErrorcode.Text = "0";
            // 
            // pBCmdInProgress
            // 
            pBCmdInProgress.Location = new Point(592, 64);
            pBCmdInProgress.Name = "pBCmdInProgress";
            pBCmdInProgress.Size = new Size(355, 23);
            pBCmdInProgress.Style = ProgressBarStyle.Marquee;
            pBCmdInProgress.TabIndex = 104;
            pBCmdInProgress.Value = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1264, 761);
            Controls.Add(label24);
            Controls.Add(btnConnect);
            Controls.Add(pBCmdInProgress);
            Controls.Add(lblErrorcode);
            Controls.Add(indCmdProgress);
            Controls.Add(lblCmdInProg);
            Controls.Add(indIndexCalibrated);
            Controls.Add(label32);
            Controls.Add(btnSaveRawData);
            Controls.Add(gbSafety);
            Controls.Add(groupBox2);
            Controls.Add(pbDwell);
            Controls.Add(label9);
            Controls.Add(panel2);
            Controls.Add(indSourcOut);
            Controls.Add(btnEmgReset);
            Controls.Add(btnEmgStop);
            Controls.Add(label8);
            Controls.Add(lblTimeElapsed);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(progressBarS);
            Controls.Add(gpDDrive);
            Controls.Add(gpSDrive);
            Controls.Add(Indexer);
            Controls.Add(progressBarD);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(indiDHome);
            Controls.Add(indiDOverShoot);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(indiSHome);
            Controls.Add(indicSOver);
            Controls.Add(indiSourceOut);
            Controls.Add(indiIndexHome);
            Controls.Add(indAdapterSensor);
            Controls.Add(indIndexLock);
            Controls.Add(tbDmyEnc);
            Controls.Add(tbSrcEnc);
            Controls.Add(label4);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox1);
            Controls.Add(tbRecieved);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "My Application Client";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            Indexer.ResumeLayout(false);
            Indexer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            gpSDrive.ResumeLayout(false);
            gpSDrive.PerformLayout();
            gpDDrive.ResumeLayout(false);
            gpDDrive.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxcycles).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gbSafety.ResumeLayout(false);
            gbSafety.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backWorkerTreatment;
        private TextBox tbRecieved;
        private GroupBox groupBox1;
        private Label lblStatServer;
        private Label lblUser;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox tbSrcEnc;
        private TextBox tbDmyEnc;
        private WinFormsControlLibrary1.Indicator indIndexLock;
        private WinFormsControlLibrary1.Indicator indAdapterSensor;
        private WinFormsControlLibrary1.Indicator indiIndexHome;
        private WinFormsControlLibrary1.Indicator indiSourceOut;
        private WinFormsControlLibrary1.Indicator indicSOver;
        private WinFormsControlLibrary1.Indicator indiSHome;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private WinFormsControlLibrary1.Indicator indiDOverShoot;
        private WinFormsControlLibrary1.Indicator indiDHome;
        private Label label16;
        private Label label17;
        private Label label1;
        private Label label2;
        private TextBox tbIP;
        private TextBox tbPort;
        private Button btnConnect;
        private Button btnSend;
        private TextBox tbSend;
        private Label label3;
        private Panel panel1;

        private TimerClock IndexerPosition;
        private ProgressBar progressBarD;
        private Button btnIndxCW;
        private Button btnIndxCCW;
        public TextBox tbIndxCount;
        private Button btnHome;
        private GroupBox Indexer;
        private Label label6;
        private Button btnI_EReset;
        private GroupBox gpSDrive;
        private Button btnS_Ereset;
        private Label label18;
        public TextBox tbScount;
        private Button btnS_home;
        private Button btnS_in;
        private Button btnS_out;
        private GroupBox gpDDrive;
        private Button btnD_Ereset;
        private Label label19;
        public TextBox tbDcount;
        private Button btnD_home;
        private Button btnD_in;
        private Button btnD_out;
        private Button btnDisconnect;
        private NumericUpDown numericUpDown1;
        private Button indexTo;
        private ProgressBar progressBarS;
        private Label label21;
        private Label label22;
        private Label lblIndexSlotNo;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label lblTimeElapsed;
        private Label label8;
        private WinFormsControlLibrary1.Indicator indSourcOut;
        private Label label9;
        private System.Windows.Forms.Timer tmrSourceOUT;
        private Button btAs;
        private Button btAE;
        private Label label20;
        private Label lblIndexerCount;
        private WinFormsControlLibrary1.Indicator indIndexCalibrated;
        private Label lblCmdInProg;
        private Label label24;
        private Button btnEmgStop;
        private Button btnEmgReset;
        private WinFormsControlLibrary1.Indicator indCmdProgress;
        private Label label5;
        private Panel panel2;
        private Label label25;
        private Button btnRight;
        private Button btnLeft;
        private ToolStripMenuItem indexerDataToolStripMenuItem;
        private Button btnStartCycle;
        private NumericUpDown numMaxcycles;
        private Button btnStopCycle;
        private Label lblcyclesCompleted;
        private ProgressBar pbDwell;
        private GroupBox groupBox2;
        private Label label28;
        private Label label27;
        private WinFormsControlLibrary1.Indicator indTretSw;
        private WinFormsControlLibrary1.Indicator indEmgSw;
        private WinFormsControlLibrary1.Indicator indDoorSw;
        private WinFormsControlLibrary1.Indicator indPwrSw;
        private GroupBox gbSafety;
        private Label lblACPower;
        private Label lblDoor;
        private Label lblEmgSw;
        private Label lblKeySw;
        private CheckBox cbDummy;
        private CheckBox cbSource;
        private Label lblSEnc;
        private Label label31;
        private Label lblDEnc;
        private Label label33;
        private Button btnSaveRawData;
        private Label label32;
        private Label lblErrorcode;
        private ProgressBar pBCmdInProgress;
        private Label lblSysFault;
        private WinFormsControlLibrary1.Indicator indSysFault;
        private Button btnMSS;
        private Button btnMDS;
    }
}