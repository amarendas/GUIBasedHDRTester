namespace ToTestUsecontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VPB.SetColor(2, Color.Yellow);
            VPB.SetColor(6, Color.Red);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VPB.SetColor(2, Color.WhiteSmoke);
            VPB.SetColor(6, Color.WhiteSmoke);
        }
    }
}