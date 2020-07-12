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
    public partial class ucButton : UserControl
    {
        public delegate void Activation(object sender);
        public event Activation Activated;


        public ucButton()
        {
            InitializeComponent();
        }

        public void SetName(string text)
        {
            lblCommand.Text = text;
        }

        private void pbButton_DoubleClick(object sender, EventArgs e)
        {
            Activated?.Invoke(this);
        }
    }
}
