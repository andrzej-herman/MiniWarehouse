namespace Simulator.Controls
{
    partial class ucButton
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
            this.lblCommand = new System.Windows.Forms.Label();
            this.pbButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbButton)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCommand
            // 
            this.lblCommand.BackColor = System.Drawing.Color.White;
            this.lblCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCommand.Location = new System.Drawing.Point(0, 44);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(68, 22);
            this.lblCommand.TabIndex = 3;
            this.lblCommand.Text = "ON";
            this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbButton
            // 
            this.pbButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbButton.ErrorImage = null;
            this.pbButton.Image = global::Simulator.Properties.Resources.button;
            this.pbButton.Location = new System.Drawing.Point(0, 0);
            this.pbButton.Name = "pbButton";
            this.pbButton.Size = new System.Drawing.Size(68, 40);
            this.pbButton.TabIndex = 2;
            this.pbButton.TabStop = false;
            this.pbButton.DoubleClick += new System.EventHandler(this.pbButton_DoubleClick);
            // 
            // ucButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.pbButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ucButton";
            this.Size = new System.Drawing.Size(68, 68);
            ((System.ComponentModel.ISupportInitialize)(this.pbButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbButton;
        private System.Windows.Forms.Label lblCommand;
    }
}
