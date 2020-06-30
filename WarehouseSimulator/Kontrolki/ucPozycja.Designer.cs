namespace WarehouseSimulator.Kontrolki
{
    partial class ucPozycja
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
            this.lblNumer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumer
            // 
            this.lblNumer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumer.ForeColor = System.Drawing.Color.Gray;
            this.lblNumer.Location = new System.Drawing.Point(0, 0);
            this.lblNumer.Name = "lblNumer";
            this.lblNumer.Size = new System.Drawing.Size(50, 50);
            this.lblNumer.TabIndex = 0;
            this.lblNumer.Text = "748";
            this.lblNumer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPozycja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblNumer);
            this.Name = "ucPozycja";
            this.Size = new System.Drawing.Size(50, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumer;
    }
}
