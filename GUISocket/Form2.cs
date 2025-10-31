using System.Diagnostics;
using System.Windows.Forms;

namespace GUISocket
{
    public partial class Form2 : Form
    {
        PictureBox picturebox = new PictureBox();
        Panel panel;
        public Form2()
        {
            InitializeComponent();
        }
        public class DataEventArgs : EventArgs
        {
            public string Data { set; get; }

        }
        public event EventHandler<DataEventArgs> DataSent;
        protected virtual void OnDataSent(DataEventArgs e)
        {
            DataSent?.Invoke(this, e);
        }

        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            DataEventArgs args = new DataEventArgs { Data = textBox1.Text };
            OnDataSent(args);
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createPbox(panel1);
        }

        public void createPbox(Panel _panel) {

            this.panel = _panel;
            picturebox.Width = panel.Width - 6;
            picturebox.Height = panel.Height - 6;
            picturebox.Location = new Point(3, 3);
            picturebox.BackColor = Color.White;
            //picturebox.Dock= DockStyle.Fill;

            int h1 = picturebox.ClientSize.Height;

            panel.Controls.Add(picturebox);
            Debug.WriteLine("pic.w:{0} pic.H:{1}, pan.W:{2}  pan.H:{3}", picturebox.Width, picturebox.Height, panel.Width, panel.Height);
        }
    }
}
