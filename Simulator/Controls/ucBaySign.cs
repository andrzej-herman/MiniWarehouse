using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.Controls
{
    public partial class ucBaySign : UserControl
    {
        public ucBaySign(int number)
        {
            InitializeComponent();
            lblBay.Text = number.ToString();
        }
    }
}
