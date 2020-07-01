namespace WarehouseSimulator.Kontrolki
{
    partial class ucPaleta
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblData = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.lblNazwa = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKod, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNazwa, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(50, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblData.ForeColor = System.Drawing.Color.Black;
            this.lblData.Location = new System.Drawing.Point(3, 33);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(44, 17);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "13/09/20";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKod
            // 
            this.lblKod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKod.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKod.ForeColor = System.Drawing.Color.Black;
            this.lblKod.Location = new System.Drawing.Point(3, 17);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(44, 16);
            this.lblKod.TabIndex = 1;
            this.lblKod.Text = "010001";
            this.lblKod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNazwa
            // 
            this.lblNazwa.BackColor = System.Drawing.Color.White;
            this.lblNazwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNazwa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNazwa.ForeColor = System.Drawing.Color.Black;
            this.lblNazwa.Location = new System.Drawing.Point(3, 0);
            this.lblNazwa.Name = "lblNazwa";
            this.lblNazwa.Size = new System.Drawing.Size(44, 17);
            this.lblNazwa.TabIndex = 0;
            this.lblNazwa.Text = "ABC";
            this.lblNazwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPaleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucPaleta";
            this.Size = new System.Drawing.Size(50, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label lblNazwa;
    }
}
