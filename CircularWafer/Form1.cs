using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CircularWafer
{
    public partial class WaferPoints : Form
    {
        public WaferPoints()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Parse textbox to in as the number of points to draw
            int num_points = Int32.Parse(point_count.Text);

            int radius = 150;  // radius of the wafer
            int padding = 3;  // padding to keep points from being on edge of wafer
            int spokes = 8;  // number of radial spokes to place points along

            // calculate the number of concentric circles
            int ring_counter = 1;
            double num_rings = (double)num_points / (double)spokes;
            double radius_interval = (double)(radius - padding) / num_rings;


            double current_radius = 0;
            double Tau = 6.2831853071795862;

            double angle_slice = Tau / (double) spokes;

            Graphics g = this.CreateGraphics();
            
            // Clear the drawing
            g.Clear(Color.AntiqueWhite);

            // Create the pens for drawing dots and circles
            Pen red_pen = new Pen(Color.Red, 3);
            Pen black_pen = new Pen(Color.Black, 1);

            // Draw the circle and center
            g.DrawEllipse(black_pen, 0, 0, 300, 300); ;
            g.DrawEllipse(red_pen, 150, 150, 3, 3);

            // While there are still points to be drawn, place points and draw circles
            while (num_points > 1) {
                current_radius = ring_counter * radius_interval;
                float offset = 150 - (float)current_radius;
                float current_diameter = 2 * (float)current_radius;
                g.DrawEllipse(black_pen, offset, offset, current_diameter, current_diameter);

                // This is the "meat" of the algorithm, draw points along a single radius, 
                // depending on the number of radial spokes
                for (int i = 0; i < spokes; ++i) {
                    if (num_points == 1) {
                        break;
                    }

                    // This converts polar to cartesian coordiantes
                    double theta = angle_slice * i;
                    double x = current_radius * Math.Cos(theta);
                    double y = current_radius * Math.Sin(theta);

                    // offset the xy coordinates so the full circle is draw to the window
                    x += 150;
                    y += 150;
                    
                    // Draw the "point" as a small circle and decrement the number of points to draw
                    g.DrawEllipse(red_pen, (float) x, (float) y, 3, 3);
                    num_points--;
                }
                // increment the ring level
                ring_counter++;
            }
        }
    }
}
