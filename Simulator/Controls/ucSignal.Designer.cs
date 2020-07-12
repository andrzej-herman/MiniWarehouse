namespace Simulator.Controls
{
    partial class ucSignal
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
            this.lblSignal = new System.Windows.Forms.Label();
            this.pbSignal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSignal
            // 
            this.lblSignal.BackColor = System.Drawing.Color.White;
            this.lblSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSignal.Location = new System.Drawing.Point(0, 44);
            this.lblSignal.Name = "lblSignal";
            this.lblSignal.Size = new System.Drawing.Size(68, 22);
            this.lblSignal.TabIndex = 2;
            this.lblSignal.Text = "POWER";
            this.lblSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSignal
            // 
            this.pbSignal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSignal.ErrorImage = null;
            this.pbSignal.Image = global::Simulator.Properties.Resources.powerOff;
            this.pbSignal.Location = new System.Drawing.Point(0, 0);
            this.pbSignal.Name = "pbSignal";
            this.pbSignal.Size = new System.Drawing.Size(68, 40);
            this.pbSignal.TabIndex = 1;
            this.pbSignal.TabStop = false;
            // 
            // ucSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblSignal);
            this.Controls.Add(this.pbSignal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ucSignal";
            this.Size = new System.Drawing.Size(68, 68);
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSignal;
        private System.Windows.Forms.Label lblSignal;
    }
}
