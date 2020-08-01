using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator.WarehouseData;

namespace Simulator.Controls
{
    public partial class ucPallet : UserControl
    {
        public ucPallet()
        {
            InitializeComponent();
        }

        public void Init(Pallet p)
        {
            lblSymbol.Text = p.Symbol;
            lblSymbol.BackColor = p.Type == Helpers.PalletType.DS ? Color.Wheat : Color.Violet;
        }
    }
}
