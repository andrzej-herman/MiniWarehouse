using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Symulator;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.Kontrolki
{
    public partial class ucMaster : UserControl
    { 
        public ucMaster()
        {
            InitializeComponent();
            this.BackColor = Color.RoyalBlue;
            this.SetBounds(0, 0, 90, 90);
        }

        public void PokazKierunekRuchuMastera(RuchMastera ruchMastera)
        {
            switch (ruchMastera)
            {
                case RuchMastera.BrakRuchu:
                    panPrawy.BackColor = panLewy.BackColor = Color.Red;
                    break;
                case RuchMastera.WPrawo:
                    panPrawy.BackColor = Color.SpringGreen;
                    panLewy.BackColor = Color.RoyalBlue;
                    break;
                case RuchMastera.WLewo:
                    panPrawy.BackColor = Color.RoyalBlue;
                    panLewy.BackColor = Color.SpringGreen;
                    break;
            }
        }

        public void MapujPalete(Paleta p)
        {
            p.Interfejs.SetBounds(20, 20, 50, 50);
            this.Controls.Add(p.Interfejs);          
        }

        public void UsunPalete()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ucPaleta)
                    this.Controls.Remove(ctrl);
            }
        }
    }
}
