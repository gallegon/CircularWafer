using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CircularWafer
{
    public class PointCircle
    {
        private List<(float, float)> coordinates;
        private float radius { get; set; }
        private float diameter;
        public const float RADIAL_POINTS = 8;
        public const float TAU = 6.28318f;
        public const float THETA = TAU / RADIAL_POINTS;

        public PointCircle(float r) {
            radius = r;
            diameter = 2 * r;
            float current_angle = 0.0f;
            float x, y;

            coordinates = new List<(float, float)>();

            for (int i = 0; i < RADIAL_POINTS; i++) {
                current_angle = THETA * i;
                x = (float) (radius * Math.Cos(current_angle));
                y = (float) (radius * Math.Sin(current_angle));

                this.coordinates.Add((x, y));
            }
        }

        public List<(float, float)> GetPoints()
        {
            return coordinates;
        }

        
        
    }
}
