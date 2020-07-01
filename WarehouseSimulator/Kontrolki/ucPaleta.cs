using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Symulator.Palety;
using WarehouseSimulator.Symulator;

namespace WarehouseSimulator.Kontrolki
{
    public partial class ucPaleta : UserControl
    {
        public ucPaleta()
        {
            InitializeComponent();
        }

        public void UtworzPalete(Paleta p)
        {
            this.BackColor = lblNazwa.BackColor = lblKod.BackColor = lblData.BackColor = p.Produkt.KolorTla;
            lblNazwa.ForeColor = lblKod.ForeColor = lblData.ForeColor = p.Produkt.KolorCzcionki;
            lblNazwa.Text = p.Produkt.Nazwa;
            lblKod.Text = p.KodKreskowy;
            lblData.Text = $"{p.DataPrzydatnosci.Day:00}/{p.DataPrzydatnosci.Month:00}/{p.DataPrzydatnosci.Year.ToString().Substring(2 , 2)}";
            if (p.Stan == StanPalety.NieczytelnyKodKreskowy)
            {
                lblData.Text = lblNazwa.Text = "---";
                lblKod.Text = string.Empty;
            }

            if (p.Stan == StanPalety.Uszkodzona)
            {
                this.BackColor = Color.Red;
                lblKod.BackColor = Color.Red;
            }
        }

    }
}
