namespace Simulator.Controls
{
    partial class ucPosition
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
            this.panMain = new System.Windows.Forms.Panel();
            this.panNumber = new System.Windows.Forms.Panel();
            this.panPallet = new System.Windows.Forms.Panel();
            this.lblPallet = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.panMain.SuspendLayout();
            this.panNumber.SuspendLayout();
            this.panPallet.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panNumber);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(25, 25);
            this.panMain.TabIndex = 0;
            // 
            // panNumber
            // 
            this.panNumber.Controls.Add(this.panPallet);
            this.panNumber.Controls.Add(this.lblNumber);
            this.panNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panNumber.Location = new System.Drawing.Point(0, 0);
            this.panNumber.Name = "panNumber";
            this.panNumber.Size = new System.Drawing.Size(25, 25);
            this.panNumber.TabIndex = 1;
            // 
            // panPallet
            // 
            this.panPallet.BackColor = System.Drawing.Color.SkyBlue;
            this.panPallet.Controls.Add(this.lblPallet);
            this.panPallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPallet.Location = new System.Drawing.Point(0, 0);
            this.panPallet.Name = "panPallet";
            this.panPallet.Size = new System.Drawing.Size(25, 25);
            this.panPallet.TabIndex = 1;
            // 
            // lblPallet
            // 
            this.lblPallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPallet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPallet.Location = new System.Drawing.Point(0, 0);
            this.lblPallet.Name = "lblPallet";
            this.lblPallet.Size = new System.Drawing.Size(25, 25);
            this.lblPallet.TabIndex = 0;
            this.lblPallet.Text = "W";
            this.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber
            // 
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumber.Location = new System.Drawing.Point(0, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(25, 25);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "8888";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPosition";
            this.Size = new System.Drawing.Size(25, 25);
            this.panMain.ResumeLayout(false);
            this.panNumber.ResumeLayout(false);
            this.panPallet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel panPallet;
        private System.Windows.Forms.Label lblPallet;
    }
}
