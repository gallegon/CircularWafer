using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularWafer
{
    public class Wafer
    {
        private List<PointCircle> rings;
        private List<(float, float)> points;
        private int point_count;
        private int ring_count;
        private float ring_spacing;
        public const float RADIUS = 150.0f;
        public float x_center { get; set; }
        public float y_center { get; set; }

        private List<float> radii;
        public List<float> adjusted_radii { get; set; }

        public Wafer(int point_count)
        {
            this.point_count = point_count;
            ring_count = (point_count - 1) / 8;
            float current_radius;

            rings = new List<PointCircle>();
            points = new List<(float, float)>();
            radii = new List<float>();
            adjusted_radii = new List<float>();

            radii.Add(RADIUS);

            if (ring_count == 0)
            {
                ring_spacing = 0;
            }
            else
            {
                ring_spacing = RADIUS / (float) (ring_count + 1);
                
                for (int i = 1; i < (ring_count + 1); i++) {
                    current_radius = (float)i * ring_spacing;
                    if (current_radius > (RADIUS - 2.0f))
                    {
                        current_radius = RADIUS - 2.0f;
                    }
                    radii.Add(current_radius);
                    PointCircle p = new PointCircle(current_radius);
                    rings.Add(p);
                }
            }

            
        }

        public List<(float, float)> GetPoints(float scale, float offset_x, float offset_y)
        {
            float x, y;
            points.Add((offset_x, offset_y));
            foreach(var ring in rings)
            {
                List<(float, float)> coordinates = ring.GetPoints();
                foreach(var coord in coordinates)
                {
                    x = coord.Item1 * scale;
                    y = coord.Item2 * scale;

                    x += offset_x;
                    y += offset_y;
                    points.Add((x, y));
                }

            }
            return points;
        }

        public List<(float, float)> AdjustPoints(float window_height, float window_width)
        {
            List<(float, float)> adjusted_points = new List<(float, float)>();

            float width_diff = window_width - window_height;

            var min_dimension = Math.Min(window_height, window_width);

            float scaled_radius = (float)min_dimension / 2.0f;
            float short_side_offset = scaled_radius;

            float scale = (float)min_dimension / 300.0f;

            float x_offset, y_offset;

            // Check which window dimension is longer and set x/y offsets accordingly
            if (width_diff > 0.0f) // The window is wider than it is tall
            {
                x_offset = window_width / 2.0f;
                y_offset = short_side_offset;
            }
            else  // The window is taller than it is wide
            {

                x_offset = short_side_offset;
                y_offset = window_height / 2.0f;
            }

            this.x_center = x_offset;
            this.y_center= y_offset;

            foreach (var point in this.GetPoints(scale, x_offset, y_offset))
            {
                adjusted_points.Add(point);
            }

            foreach (var radius in this.radii)
            {
                adjusted_radii.Add(radius * scale);
            }

            return adjusted_points;
        }
    }
}
