using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularWafer
{
    public partial class Form2 : Form
    {
        public Wafer wafer;

        public Form2(Wafer w)
        {
            InitializeComponent();
            wafer = w;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen red_pen = new Pen(Color.Red, 6);
            Pen black_pen = new Pen(Color.Black, 1);

            var adjusted_points = wafer.AdjustPoints(this.ClientSize.Height, this.ClientSize.Width);

            foreach (var radius in wafer.adjusted_radii)
            {
                e.Graphics.DrawEllipse(black_pen, wafer.x_center - radius, wafer.y_center - radius, radius * 2.0f, radius * 2.0f);
            }

            foreach (var point in adjusted_points)
            {
                e.Graphics.DrawEllipse(red_pen, (float)point.Item1 - 3.0f, (float)point.Item2 -3.0f, 6, 6);
            }

            red_pen.Dispose();
            black_pen.Dispose();

        }
    }
}
