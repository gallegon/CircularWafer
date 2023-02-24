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
            // Parse textbox to int as the number of points to draw
            int num_points;
            bool is_int = int.TryParse(point_count.Text, out num_points);

            if (is_int)
            {
                // Check if the number of points is of form 8N+1
                if (((num_points -1) % 8) == 0)
                {
                    Wafer wafer = new Wafer(num_points);
                    Form2 wafer_display = new Form2(wafer);
                    wafer_display.Show();
                }
                else
                {
                    errorProvider1.SetError(point_count, "Enter an integer of form 8N+1");
                }
            }
            else 
            {
                errorProvider1.SetError(point_count, "Please enter a valid integer");
            }
        }
    }
}
