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
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumber.Location = new System.Drawing.Point(19, 15);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(65, 65);
            this.lblNumber.TabIndex = 5;
            this.lblNumber.Text = "8888";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCharge
            // 
            this.lblCharge.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblCharge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCharge.Location = new System.Drawing.Point(104, 15);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(65, 65);
            this.lblCharge.TabIndex = 6;
            this.lblCharge.Text = "CHARGE";
            this.lblCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblCharge);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPosition";
            this.Size = new System.Drawing.Size(371, 326);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCharge;
    }
}
