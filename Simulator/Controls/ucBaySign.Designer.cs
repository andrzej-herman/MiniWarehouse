namespace Simulator.Controls
{
    partial class ucBaySign
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
            this.lblBay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBay
            // 
            this.lblBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBay.ForeColor = System.Drawing.Color.White;
            this.lblBay.Location = new System.Drawing.Point(0, 0);
            this.lblBay.Margin = new System.Windows.Forms.Padding(0);
            this.lblBay.Name = "lblBay";
            this.lblBay.Size = new System.Drawing.Size(33, 50);
            this.lblBay.TabIndex = 0;
            this.lblBay.Text = "8888";
            this.lblBay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucBaySign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblBay);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucBaySign";
            this.Size = new System.Drawing.Size(33, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBay;
    }
}
