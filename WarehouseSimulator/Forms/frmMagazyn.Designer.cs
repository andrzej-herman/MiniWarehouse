namespace WarehouseSimulator.Forms
{
    partial class frmMagazyn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMagazyn));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symulacjaProdukcjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rampyTowaroweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.numeryPozycjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuPokazNumeryPalet = new System.Windows.Forms.ToolStripMenuItem();
            this.manuUkryjNumeryPalet = new System.Windows.Forms.ToolStripMenuItem();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel46 = new System.Windows.Forms.Panel();
            this.timerGlowny = new System.Windows.Forms.Timer(this.components);
            this.timerProdukcja = new System.Windows.Forms.Timer(this.components);
            this.menuStartSymulatora = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStopSymulatora = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuKoniec = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel45.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.symulacjaProdukcjiToolStripMenuItem,
            this.rampyTowaroweToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.ustawieniaToolStripMenuItem1,
            this.ustawieniaToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStartSymulatora,
            this.menuStopSymulatora,
            this.toolStripSeparator1,
            this.menuKoniec});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "Plik";
            // 
            // symulacjaProdukcjiToolStripMenuItem
            // 
            this.symulacjaProdukcjiToolStripMenuItem.Name = "symulacjaProdukcjiToolStripMenuItem";
            this.symulacjaProdukcjiToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.symulacjaProdukcjiToolStripMenuItem.Text = "Symulacja produkcji";
            // 
            // rampyTowaroweToolStripMenuItem
            // 
            this.rampyTowaroweToolStripMenuItem.Name = "rampyTowaroweToolStripMenuItem";
            this.rampyTowaroweToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.rampyTowaroweToolStripMenuItem.Text = "Rampy towarowe";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.ustawieniaToolStripMenuItem.Text = "Naprawa i inspekcja palet";
            // 
            // ustawieniaToolStripMenuItem1
            // 
            this.ustawieniaToolStripMenuItem1.Name = "ustawieniaToolStripMenuItem1";
            this.ustawieniaToolStripMenuItem1.Size = new System.Drawing.Size(95, 20);
            this.ustawieniaToolStripMenuItem1.Text = "Sterownik PLC";
            // 
            // ustawieniaToolStripMenuItem2
            // 
            this.ustawieniaToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numeryPozycjiToolStripMenuItem});
            this.ustawieniaToolStripMenuItem2.Name = "ustawieniaToolStripMenuItem2";
            this.ustawieniaToolStripMenuItem2.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem2.Text = "Ustawienia";
            // 
            // numeryPozycjiToolStripMenuItem
            // 
            this.numeryPozycjiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuPokazNumeryPalet,
            this.manuUkryjNumeryPalet});
            this.numeryPozycjiToolStripMenuItem.Name = "numeryPozycjiToolStripMenuItem";
            this.numeryPozycjiToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.numeryPozycjiToolStripMenuItem.Text = "Numery pozycji";
            // 
            // manuPokazNumeryPalet
            // 
            this.manuPokazNumeryPalet.Name = "manuPokazNumeryPalet";
            this.manuPokazNumeryPalet.Size = new System.Drawing.Size(105, 22);
            this.manuPokazNumeryPalet.Text = "Pokaż";
            this.manuPokazNumeryPalet.Click += new System.EventHandler(this.menuPokazNumeryPalet);
            // 
            // manuUkryjNumeryPalet
            // 
            this.manuUkryjNumeryPalet.Name = "manuUkryjNumeryPalet";
            this.manuUkryjNumeryPalet.Size = new System.Drawing.Size(105, 22);
            this.manuUkryjNumeryPalet.Text = "Ukryj";
            this.manuUkryjNumeryPalet.Click += new System.EventHandler(this.menuUkryjNumeryPalet);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.Blue;
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Location = new System.Drawing.Point(234, 91);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(90, 90);
            this.panel45.TabIndex = 46;
            // 
            // panel46
            // 
            this.panel46.BackColor = System.Drawing.Color.Gainsboro;
            this.panel46.Location = new System.Drawing.Point(20, 20);
            this.panel46.Name = "panel46";
            this.panel46.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel46.Size = new System.Drawing.Size(50, 50);
            this.panel46.TabIndex = 7;
            // 
            // timerGlowny
            // 
            this.timerGlowny.Interval = 2000;
            // 
            // timerProdukcja
            // 
            this.timerProdukcja.Interval = 5000;
            // 
            // menuStartSymulatora
            // 
            this.menuStartSymulatora.Name = "menuStartSymulatora";
            this.menuStartSymulatora.Size = new System.Drawing.Size(182, 22);
            this.menuStartSymulatora.Text = "Uruchom symulator";
            this.menuStartSymulatora.Click += new System.EventHandler(this.menuStartSymulatora_Click);
            // 
            // menuStopSymulatora
            // 
            this.menuStopSymulatora.Name = "menuStopSymulatora";
            this.menuStopSymulatora.Size = new System.Drawing.Size(182, 22);
            this.menuStopSymulatora.Text = "Zatrzymaj symulator";
            this.menuStopSymulatora.Click += new System.EventHandler(this.menuStopSymulatora_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // menuKoniec
            // 
            this.menuKoniec.Name = "menuKoniec";
            this.menuKoniec.Size = new System.Drawing.Size(182, 22);
            this.menuKoniec.Text = "Zakończ program";
            this.menuKoniec.Click += new System.EventHandler(this.menuKoniec_Click);
            // 
            // frmMagazyn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1001);
            this.Controls.Add(this.panel45);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1646, 913);
            this.Name = "frmMagazyn";
            this.Text = "Symulator magazynu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.ToolStripMenuItem symulacjaProdukcjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rampyTowaroweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem numeryPozycjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuPokazNumeryPalet;
        private System.Windows.Forms.ToolStripMenuItem manuUkryjNumeryPalet;
        private System.Windows.Forms.Timer timerGlowny;
        private System.Windows.Forms.Timer timerProdukcja;
        private System.Windows.Forms.ToolStripMenuItem menuStartSymulatora;
        private System.Windows.Forms.ToolStripMenuItem menuStopSymulatora;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuKoniec;
    }
}

