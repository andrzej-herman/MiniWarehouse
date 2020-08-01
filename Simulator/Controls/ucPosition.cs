using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator.Helpers;
using Simulator.WarehouseData;
using Simulator.WarehouseData.Positions;

namespace Simulator.Controls
{
    public partial class ucPosition : UserControl
    {
        private Position _pos;
        private bool _numberVisible = false;

        public ucPosition(Position pos)
        {
            InitializeComponent();
            lblCharge.Dock = lblNumber.Dock = DockStyle.Fill;
            _pos = pos;
            _numberVisible = false;
        }

        public void Init(TabPage level_0, TabPage level_1)
        {
            if (_pos.Type == PositionType.Control || _pos.Type == PositionType.Repair || _pos.Type == PositionType.Inspection
                || _pos.Type == PositionType.Lift)
            {
                this.BackColor = Color.Gray;
            }
            else if (_pos.Type == PositionType.Master)
            {
                this.BackColor = Color.White;
            }
            else if (_pos.Type == PositionType.BatteryOne || _pos.Type == PositionType.BatteryZero)
            {
                this.BackColor = Color.MediumAquamarine;
            }
            else
            {
                this.BackColor = Color.Gainsboro;
            }

            lblNumber.Text = _pos.Id.ToString();
            lblNumber.Visible = lblCharge.Visible = false;
            if (_pos.Level == Level.Zero)
            {
                level_0.Controls.Add(this);
                this.SetBounds(_pos.X, _pos.Y, _pos.Width, _pos.Height);
            }
            else
            {
                level_1.Controls.Add(this);
                this.SetBounds(_pos.X, _pos.Y, _pos.Width, _pos.Height);
            }

            if (_pos.Type == PositionType.BatteryOne || _pos.Type == PositionType.BatteryZero)
            {
                lblCharge.Visible = true;
                this.BringToFront();
            }       
        }

        public void MapMaster(Master master)
        {
            master.Display.SetBounds(0, 0, 65, 65);
            this.Controls.Add(master.Display);
            master.Display.BringToFront();
            this.BringToFront();
        }

        private void DisplayPallet(Pallet p)
        {
            switch (_pos.Type)
            {
                case PositionType.Lift:
                    p.Display.Dock = DockStyle.None;
                    p.Display.SetBounds(5, 5, 25, 25);
                    this.Controls.Add(p.Display);
                    p.Display.BringToFront();
                    break;
                case PositionType.Control:
                case PositionType.Repair:
                case PositionType.Inspection:
                    p.Display.Dock = DockStyle.None;
                    p.Display.SetBounds(10, 10, 25, 25);
                    this.Controls.Add(p.Display);
                    p.Display.BringToFront();
                    break;
                case PositionType.Master:
                    break;
                case PositionType.BatteryZero:
                    break;
                case PositionType.BatteryOne:
                    break;
                case PositionType.Production:
                case PositionType.Standard:
                case PositionType.Cross:
                case PositionType.WarehouseEnter:
                case PositionType.LiftEnter:
                case PositionType.Warehouse:
                case PositionType.Ramp:
                case PositionType.MainEnter:
                case PositionType.RampEnter:
                default:
                    p.Display.Dock = DockStyle.Fill;
                    this.Controls.Add(p.Display);
                    p.Display.BringToFront();
                    break;
            }
        }


        public void ShowPallet(Pallet p)
        {
            DisplayPallet(p);
        }


        public void MapPallet(Pallet p)
        {
            this.Invoke(new Action(delegate ()
            {
                DisplayPallet(p);
            }));
        }



        public void RemovePallet()
        {
            this.Invoke(new Action(delegate ()
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is ucPallet)
                        this.Controls.Remove(ctrl);
                }

            }));      
        }

        public void ShowNumber()
        {
            if (_pos.Pallet == null && _pos.Master == null)
            {
                lblNumber.Visible = true;
                lblNumber.BringToFront();
            }
                

            _numberVisible = true;
        }

        public void HideNumber()
        {
            if (_pos.Pallet == null && _pos.Master == null)
            {
                lblNumber.Visible = false;
                lblNumber.SendToBack();
            }
               

            _numberVisible = false;
        }
    }
}
