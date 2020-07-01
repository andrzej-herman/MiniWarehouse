using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Properties;
using WarehouseSimulator.Symulator;

namespace WarehouseSimulator.Forms
{
    public partial class frmMagazyn : Form
    {
        private Magazyn magazyn;

        public frmMagazyn()
        {
            InitializeComponent();
            this.Shown += UtworzSymulator;
        }

        #region Ruch symulatora

        #endregion

        #region Tworzenie symulatora
        private void UtworzSymulator(object sender, EventArgs e)
        {
            UtworzMagazyn();
            UstawMenu();
            UstawTimery();
        }

        private void UstawTimery()
        {
            timerGlowny.Interval = 2000;
            timerGlowny.Tick += TimerGlowny_Tick;
            timerProdukcja.Interval = 5000;
            timerProdukcja.Tick += TimerProdukcja_Tick;
        }

        private void TimerProdukcja_Tick(object sender, EventArgs e)
        {
           
        }

        private void TimerGlowny_Tick(object sender, EventArgs e)
        {
            timerGlowny.Enabled = false;
            magazyn.WykonajRuch();
            magazyn.ResetujRuch();
            timerGlowny.Enabled = true;
        }

        private void UtworzMagazyn()
        {
            magazyn = new Magazyn(this);
            magazyn.UtworzMagazyn();
        }
        #endregion

        #region Menu główne
        private void UstawMenu()
        {
            manuUkryjNumeryPalet.Enabled = false;
            menuStopSymulatora.Enabled = false;
        }

        private void menuPokazNumeryPalet(object sender, EventArgs e)
        {
            magazyn.PokazNumeryPozycji();
            manuPokazNumeryPalet.Enabled = false;
            manuUkryjNumeryPalet.Enabled = true;
        }

        private void menuUkryjNumeryPalet(object sender, EventArgs e)
        {
            magazyn.UkryjNumeryPozycji();
            manuPokazNumeryPalet.Enabled = true;
            manuUkryjNumeryPalet.Enabled = false;
        }
       

        private void menuStartSymulatora_Click(object sender, EventArgs e)
        {
            timerGlowny.Enabled = true;
            menuStopSymulatora.Enabled = true;
            menuStartSymulatora.Enabled = false;
        }

        private void menuStopSymulatora_Click(object sender, EventArgs e)
        {
            timerGlowny.Enabled = false;
            menuStopSymulatora.Enabled = false;
            menuStartSymulatora.Enabled = true;
        }

        private void menuKoniec_Click(object sender, EventArgs e)
        {
            magazyn = null;
            Application.Exit();
        }

        #endregion
    }
}
