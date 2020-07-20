namespace Simulator.Controls
{
    partial class ucMaster
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panCapacity = new System.Windows.Forms.Panel();
            this.panCharge = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.panCharge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 60);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.panCapacity);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 5);
            this.panel2.TabIndex = 1;
            // 
            // panCapacity
            // 
            this.panCapacity.BackColor = System.Drawing.Color.Yellow;
            this.panCapacity.Dock = System.Windows.Forms.DockStyle.Left;
            this.panCapacity.Location = new System.Drawing.Point(0, 0);
            this.panCapacity.Margin = new System.Windows.Forms.Padding(0);
            this.panCapacity.Name = "panCapacity";
            this.panCapacity.Size = new System.Drawing.Size(65, 5);
            this.panCapacity.TabIndex = 0;
            // 
            // panCharge
            // 
            this.panCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panCharge.Location = new System.Drawing.Point(0, 0);
            this.panCharge.Name = "panCharge";
            this.panCharge.Size = new System.Drawing.Size(7, 7);
            this.panCharge.TabIndex = 0;
            // 
            // ucMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaster";
            this.Size = new System.Drawing.Size(65, 65);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panCapacity;
        private System.Windows.Forms.Panel panCharge;
    }
}
