namespace CircularWafer
{
    partial class WaferPoints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.point_count = new System.Windows.Forms.TextBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // point_count
            // 
            this.point_count.HideSelection = false;
            this.point_count.Location = new System.Drawing.Point(15, 348);
            this.point_count.Name = "point_count";
            this.point_count.Size = new System.Drawing.Size(212, 20);
            this.point_count.TabIndex = 0;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(15, 374);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(75, 23);
            this.draw_button.TabIndex = 1;
            this.draw_button.Text = "Draw Points";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter number of points below:";
            // 
            // WaferPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.point_count);
            this.Name = "WaferPoints";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox point_count;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.Label label1;
    }
}

