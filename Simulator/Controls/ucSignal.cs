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
    public partial class ucSignal : UserControl
    {
        public ucSignal()
        {
            InitializeComponent();           
        }

        public void Off()
        {
            pbSignal.Image = Properties.Resources.powerOff;
        }

        public void Green()
        {
            pbSignal.Image = Properties.Resources.green;
        }

        public void Red()
        {
            pbSignal.Image = Properties.Resources.red;
        }

        public void Blue()
        {
            pbSignal.Image = Properties.Resources.blue;
        }

        public void SetName(string text)
        {
            lblSignal.Text = text;
        }

    }
}
