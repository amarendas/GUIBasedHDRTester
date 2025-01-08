using System.ComponentModel;

namespace GUISocket
{
    public partial class TimerClock : UserControl
    {
        #region Properties
        
        [Category("HDR")]
        private int size1 = 100;
        private int ctValue = 25;
        private int MaxValue = 100;
        private int brushThickness = 6;
        private Color _circleColor = Color.Aqua;




        public int Size1
        {
            get => size1;
            set
            {
                if (value < 100)
                    value = 100;
                size1 = value;
                this.Invalidate();
            }
        }

        public int CtValue
        {
            get => ctValue;
            set
            {
                if (value < 0) value = 0;
                if (value > MaxValue) value = MaxValue;
                ctValue = value;
                this.Invalidate();
            }
        }

        public int MaxValue1
        {
            get => MaxValue;
            set
            {
                if (value < ctValue) value = ctValue;
                MaxValue = value;
                this.Invalidate();
            }
        }

        public int BrushThickness
        {
            get => brushThickness;
            set
            {
                brushThickness = value;
                this.Invalidate();
            }
        }
        [TypeConverter(typeof(ColorConverter))]
        public Color CircleColor 
        {
            get => _circleColor;
            set
            {
                _circleColor = value;
                this.Invalidate();
            }
        }


        #endregion


        public TimerClock()
        {
            InitializeComponent();
            this.Width = Size1;
            this.Height = Size1;
            this.BackColor = Color.Aqua;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PointF CenterPt = new PointF(this.Width / 2f, this.Height / 2f);
            int r1 = (int)(size1 / 2f * (80f / 100f));
            int r2 = (int)(size1 / 2f * (60f / 100f));
            float startingAngle = ctValue * 360f / MaxValue+90f;

            Rectangle rect = new Rectangle((int)CenterPt.X - r1, (int)CenterPt.Y - r1, 2 * r1, 2 * r1);
            g.DrawArc(new Pen(_circleColor, BrushThickness), rect, startingAngle, (float)(360-startingAngle+90f));
            g.DrawEllipse(new Pen(Color.Black,1), rect);

            string text = ctValue.ToString();

            var textSize = TextRenderer.MeasureText(text, this.Font);
            var rectText = new Rectangle((int)(CenterPt.X - textSize.Width / 2f), (int)(CenterPt.Y - textSize.Height / 2f),
                                                            textSize.Width + 2, textSize.Height + 2);
            using (var brushText = new SolidBrush(this.ForeColor))
            using (var textFormat = new StringFormat())
            {
                textFormat.Alignment = StringAlignment.Center;
                g.DrawString(text, this.Font, brushText, rectText, textFormat);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            size1 = Math.Max(this.Width, this.Height);
            if (size1 < 100) size1 = 100;
            this.Width = size1;
            this.Height = size1;
            base.OnResize(e);
        }
    }
}
