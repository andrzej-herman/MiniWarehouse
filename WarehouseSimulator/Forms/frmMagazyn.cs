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
        public frmMagazyn()
        {
            InitializeComponent();
            this.Shown += PokazSymulator;
        }

        private void PokazSymulator(object sender, EventArgs e)
        {
            
            //frmOperacja.WykonajWTle("Tworzenie magazynu", () =>
            //{
                
            //});

            UtworzMagazyn();
        }

        void UtworzMagazyn()
        {
            Magazyn magazyn = new Magazyn(this);
            magazyn.UtworzMagazyn();       
        }
    }
}
