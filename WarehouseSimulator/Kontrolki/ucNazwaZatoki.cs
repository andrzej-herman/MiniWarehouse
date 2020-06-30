using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSimulator.Kontrolki
{
    public partial class ucNazwaZatoki : UserControl
    {
        public ucNazwaZatoki(int number)
        {
            InitializeComponent();
            label1.Text = number.ToString();
        }
    }
}
