namespace WarehouseSimulator.Kontrolki
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
            this.panLewy = new System.Windows.Forms.Panel();
            this.panPrawy = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panLewy
            // 
            this.panLewy.BackColor = System.Drawing.Color.Red;
            this.panLewy.Location = new System.Drawing.Point(0, 0);
            this.panLewy.Margin = new System.Windows.Forms.Padding(0);
            this.panLewy.Name = "panLewy";
            this.panLewy.Size = new System.Drawing.Size(5, 90);
            this.panLewy.TabIndex = 0;
            // 
            // panPrawy
            // 
            this.panPrawy.BackColor = System.Drawing.Color.Red;
            this.panPrawy.Location = new System.Drawing.Point(85, 0);
            this.panPrawy.Margin = new System.Windows.Forms.Padding(0);
            this.panPrawy.Name = "panPrawy";
            this.panPrawy.Size = new System.Drawing.Size(5, 90);
            this.panPrawy.TabIndex = 1;
            // 
            // ucMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.panPrawy);
            this.Controls.Add(this.panLewy);
            this.Name = "ucMaster";
            this.Size = new System.Drawing.Size(90, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLewy;
        private System.Windows.Forms.Panel panPrawy;
    }
}
