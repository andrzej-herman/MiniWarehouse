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
    public partial class ucDisplay : UserControl
    {
        public ucDisplay()
        {
            InitializeComponent();
        }

        public void SetName(string text)
        {
            lblCommand.Text = text;
        }

        public void SetValue(string text, bool invoke)
        {
            if (invoke)
            {
                label1.Invoke(new Action(delegate ()
                {
                    label1.Text = text;
                }));
            }
            else
                label1.Text = text;
        }

    }
}
