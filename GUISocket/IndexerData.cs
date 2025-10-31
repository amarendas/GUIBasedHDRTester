using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUISocket
{
    public partial class IndexerData : Form
    {
        string path, pathOld;
        public class indexPoint
        {
            public int index { get; set; }
            public int left { get; set; }
            public int right { get; set; }

            public int mean { get; }
            public int range { get; }

            public indexPoint(int i, int l, int r)
            {
                index = i; left = l; right = r; mean = (l + r) / 2;
                range = Math.Abs(l - r);
            }
            public indexPoint(int i, int m)
            {
                index = i; left = 0; right = 0; mean = m;
                range = 0;
            }

        }
        public int[] indexerEncPosition= new int[21];

        List<indexPoint> pointlist = new List<indexPoint>();

        public IndexerData()
        {
            path= "C:\\HDR\\" + "IndexePosData.txt";
            pathOld = "C:\\HDR\\" + "IndexePosDataOld.txt";
            InitializeComponent();
        }

        private void IndexerData_Load(object sender, EventArgs e)
        {
            //List<indexArray> list = new List<indexArray>() { new indexArray(0, 0, 2), };

        }

        

        private void btmReadCalibFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|(*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        pointlist.Clear();
                        do
                        {
                            fileContent = reader.ReadLine();
                            string[] substrings = fileContent.Split(",");
                            Debug.WriteLine("1>{0} 2>{1} 3>{2}", substrings[0], substrings[1], substrings[2]);
                            pointlist.Add(new indexPoint(int.Parse(substrings[0]), int.Parse(substrings[1]), int.Parse(substrings[2])));
                        } while (reader.Peek() != -1);
                        //fileContent = reader.ReadToEnd();
                    }
                }
            }

            dgvIndexer.DataSource = null;
            dgvIndexer.Rows.Clear();
            dgvIndexer.DataSource = pointlist;
        }

        private void write_Click(object sender, EventArgs e)
        {
            //string path = Application.StartupPath + "IndexePosData.txt";
            StreamWriter writer;
            StreamWriter writerOld=new StreamWriter(pathOld, append: true);
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine(); // Read the first line
                if (line != null) writerOld.WriteLine(line);
                reader.Close();
                writerOld.Close();
            }
            try
            {
                writer = new StreamWriter(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            writer.Write("0"); // First elementis always zero. My convention
            if (pointlist.Count != 0)
            {
                foreach (indexPoint p in pointlist)
                {
                    writer.Write(",");
                    writer.Write(p.mean);

                }
                writer.WriteLine();
                writer.Close();
                MessageBox.Show(" File Written at : \n" + path);
            }
            else
                MessageBox.Show(" List is empty.");

        }

        private void btnReadIndexerData_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line =reader.ReadLine(); // Read the first line
                    if (line != null)
                    {
                        string[] subStr = line.Split(",");
                        for (int i = 0; i < subStr.Length ; i++)
                        {
                            indexerEncPosition[i] = int.Parse(subStr[i]);
                            Debug.WriteLine(i+" > "+indexerEncPosition[i]);
                            string s = String.Format("#{0,3} -- {1,-10} \n", i, indexerEncPosition[i]);
                            richTextBox1.Text = richTextBox1.Text + s;
                        }
                        MessageBox.Show("Total No of " + subStr.Length + " recorded.");
                        reader.Close();
                        

                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            


        }
    }
}
