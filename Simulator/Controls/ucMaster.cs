using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using Simulator.WarehouseData;
using Simulator.Helpers;

namespace Simulator.Controls
{
    public partial class ucMaster : UserControl
    {
        public ucMaster()
        {
            InitializeComponent();
            panel1.Parent = this;
            panel2.Parent = this;
            panCapacity.Parent = panel2;
        }

        public void UpdateCapacity(Master m)
        {
            this.Invoke(new Action(delegate ()
            {
                if (m.Capacity >= 375)
                    panCapacity.BackColor = Color.Lime;
                else if (m.Capacity >= 250 && m.Capacity < 375)
                    panCapacity.BackColor = Color.LightGreen;
                else if (m.Capacity >= 125 && m.Capacity < 250)
                    panCapacity.BackColor = Color.Yellow;
                else
                    panCapacity.BackColor = Color.Red;

                int szer = Convert.ToInt32(Convert.ToDouble(m.Capacity) / 7.69d);
                panCapacity.SetBounds(0, 0, szer, 5);
                panel1.BringToFront();
                panel2.BringToFront();
                panCapacity.BringToFront();
            }));
        }

        public void UpdateCharging(Master m)
        {
            this.Invoke(new Action(delegate ()
            {
                if (m.CurrentPosition.Type != PositionType.BatteryOne && m.CurrentPosition.Type != PositionType.BatteryZero)
                    panCharge.BackColor = Color.Gray;
                else
                {
                    if (m.Capacity == 500)
                        panCharge.BackColor = Color.Lime;
                    else
                        panCharge.BackColor = Color.Red;
                }
            }));
        }
    }
}
