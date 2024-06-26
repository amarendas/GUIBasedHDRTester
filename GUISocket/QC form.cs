using System.Data;
using System.Diagnostics;

namespace GUISocket
{
    public partial class frmQC : Form
    {

        public System.Data.DataTable ChannelTable = new DataTable("ChannelData");
        private DataTable[] AllChannels = new DataTable[20];


        public frmQC()
        {
            InitializeComponent();
            dataGridView1.DataSource = ChannelTable;
            radioButton1.Checked = true;
            MakeChannelTable(); FillTable(2.5);
            btnSave.DialogResult = DialogResult.OK;

        }

        private void Form3_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        LinkedList<GroupBox> groupboxList = new LinkedList<GroupBox>();
        private void button1_Click(object sender, EventArgs e)
        {
            int chNo = int.Parse(tbChNo.Text);
            AllChannels[chNo] = ChannelTable;
            DisplayChannelData();

        }

        private void DisplayChannelData()
        {
            foreach (GroupBox group in groupboxList)
            {
                if (group.Name == tbChNo.Text)
                {
                    MessageBox.Show(" Channel No alrady Prsent");

                    return;
                }
            }
            if (groupboxList.Count == 0)
            {
                GroupBox g = new GroupBox();
                g.Text = " Channel " + tbChNo.Text;
                g.Parent = splitContainer1.Panel2;
                //g.Location = new Point(splitContainer1.Panel2.Location.X, splitContainer1.Panel2.Location.Y + 15);
                g.Height = 100;
                g.Width = splitContainer1.Panel2.Width - 50;
                g.Name = tbChNo.Text;
                g.AutoSize = true;
                g.AutoSizeMode = AutoSizeMode.GrowOnly;
                groupboxList.AddLast(g);
                FillControlPoints(g);
            }
            else
            {
                GroupBox glast = new GroupBox();
                glast = groupboxList.Last();
                GroupBox g = new GroupBox();
                g.Text = " Channel " + tbChNo.Text;
                g.Parent = splitContainer1.Panel2;
                g.Location = new Point(glast.Location.X, glast.Location.Y + glast.Height + 20);
                g.Height = 100;
                g.Width = splitContainer1.Panel2.Width - 50;
                g.Name = tbChNo.Text;
                g.AutoSize = true;
                g.AutoSizeMode = AutoSizeMode.GrowOnly;
                groupboxList.AddLast(g);
                FillControlPoints(g);

            }
        }

        private void MakeChannelTable()
        {

            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;


            // Create new DataColumn, set DataType,


            // Create First column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Position";
            column.AutoIncrement = false;
            column.Caption = "Position";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            ChannelTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "TreatmentTime";
            column.AutoIncrement = false;
            column.Caption = "Treatment Time";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            ChannelTable.Columns.Add(column);

        }

        private void tbChNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var a = int.TryParse(tbChNo.Text, out var b);
            if (!a)
            {
                MessageBox.Show(" Only numerial value between 1 and 20");
                return;
            }
            if ((b < 1) || (b > 20))
            {
                MessageBox.Show(" Only numerial value between 1 and 20");
                return;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tbCLength_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var a = int.TryParse(tbChNo.Text, out var b);
            if (!a)
            {
                MessageBox.Show(" Only numerial value between 1 and 20");
                return;
            }
            if ((b < 150) || (b > 300))
            {
                MessageBox.Show(" Only numerial value between 1 and 20");
                return;

            }
        }

        private void tbCLength_Validated(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (groupboxList == null)
            {
                MessageBox.Show(" At Least one channel is to be added.");
                return;
            }
            bool found=false;
            foreach (GroupBox g in groupboxList)
            {

                if (g.Name == tbChNo.Text)
                {
                    found = true;
                    int chNo = int.Parse(tbChNo.Text);
                    FillControlPoints(g);
                    AllChannels[chNo] = ChannelTable;
                    break;
                }


            }
            if (!found) MessageBox.Show(" First add Channel " + tbChNo.Text);


            
        }

        private void FillControlPoints(GroupBox g)
        {
            g.Controls.Clear();
            int i = 0;
            foreach (DataRow r in ChannelTable.Rows)
            {
                int lblWidth = 30;
                int pitch = lblWidth + 5;
                Label lbl = new Label(); Label lbl1 = new Label();
                lbl.Text = r["Position"].ToString(); lbl1.Text = r["TreatmentTime"].ToString();
                lbl.Parent = lbl1.Parent = groupboxList.First();
                lbl.Width = lbl1.Width = lblWidth;
                lbl.Location = new Point(5 + i * pitch, 20);
                lbl1.Location = new Point(5 + i * pitch, 45);
                g.Controls.Add(lbl);
                g.Controls.Add(lbl1);
                i++;
            }
        }

        private void FillTable(double stepSize)
        {

            ChannelTable.Clear();

            double chLength = double.Parse(tbCLength.Text);
            int counts = (int)(chLength / stepSize);
            DataRow row;
            for (int i = 0; i <= counts; i++)
            {
                row = ChannelTable.NewRow();
                row["Position"] = Convert.ToDouble(i * stepSize);
                row["TreatmentTime"] = 0;
                ChannelTable.Rows.Add(row);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            FillTable(2.5);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            FillTable(5);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            FillTable(10);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int chNo = int.Parse(tbChNo.Text);
            ChannelTable=AllChannels[chNo] ;
            foreach(DataRow r in ChannelTable.Rows)
            {
                Debug.WriteLine(r[1]);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            button2_Click_1(sender, e);

        }
    }
}