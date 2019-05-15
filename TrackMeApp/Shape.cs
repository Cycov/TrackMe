using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackMeApp
{
    public partial class Shape : UserControl
    {
        public enum ShapeType
        {
            Triangle,
            Circle,
            Square
        }

        public ShapeType Type = ShapeType.Triangle;

        private SolidBrush brush;

        public Color Color { get => brush.Color; set => brush.Color = value; }

        public Shape()
        {
            InitializeComponent();
            brush = new SolidBrush(ForeColor);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (Type)
            {   
                case ShapeType.Triangle:
                    {
                        e.Graphics.FillPolygon(brush, new[] { new Point(0, 0), new Point(Width, Height / 2), new Point(0, Height), new Point(0, 0) });
                    }
                    break;
                case ShapeType.Circle:
                    break;
                case ShapeType.Square:
                    break;
                default:
                    break;
            }
        }
    }
}
