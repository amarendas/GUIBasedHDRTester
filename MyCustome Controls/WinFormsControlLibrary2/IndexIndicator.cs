using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace VerticalProgressBar

{
    public partial class IndexIndicator : UserControl
    {
        Label[] l;
        private Color[] c0;        

        private int dia = 30;

        [
            Category("Vertical"),
            Description("The ending color of the bar.")
        ]
        public void  SetColor (int i, Color C0)
        {
            c0[i]= C0;
            Invalidate();
            
        }
        public Color GetColor(int i)
        {
            return c0[i];
        }

        




        public IndexIndicator()
        {


            InitializeComponent();

            Rectangle circle = new Rectangle(0, 0, dia-5, dia-5);
            var path = new GraphicsPath();
            path.AddEllipse(circle);

            c0 = new Color[20];
            for (int i = 0; i < 20; i++)
            {
                c0[i] = Color.AntiqueWhite;
            }

            l = new Label[20];
            for (int i = 0; i < 20; i++)
            {
                l[i] = new Label();
                l[i].Width = dia;
                l[i].Height = dia;
                l[i].BackColor = c0[i];
                l[i].Region= new Region(path);
                l[i].Text = string.Format("  {0}", i+1);
                double theta = i * (2 * Math.PI / 20);
                Locate(l[i],theta);
            }

            
            


            


        }

        private void VerticalProgressBar_Load(object sender, EventArgs e)
        {
            for (int i = 0;i < 20;i++)
            {
                Controls.Add(l[i]);
            }
            
            

        }


        private void Locate(Label l1, double theta)
        {
            int cx = Size.Width / 2;
            int cy = Size.Height / 2;
            double radius = cy - dia / 2;
            int x, y;
            CalCenter( theta, out x, out y);
            l1.Location = new Point(x, y);
            

            void CalCenter( double theta, out int x, out int y)
            {
                x = cx + (int)(radius * Math.Cos(theta)) - dia / 2;
                y = cy + (int)(radius * Math.Sin(theta)) - dia / 2;
            }
        }

        private void VerticalProgressBar_Resize(object sender, EventArgs e)
        {

            //Locate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
            Graphics g = e.Graphics;
            for (int i = 0; i < 20;i++)
            {
                l[i].BackColor = c0[i];
            }
            
        }
    }
}