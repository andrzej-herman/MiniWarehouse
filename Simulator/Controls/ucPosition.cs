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
            master.UpdateCapacity();
            master.UpdateCharging();
            master.Display.SetBounds(0, 0, 65, 65);
            this.Controls.Add(master.Display);
            master.Display.BringToFront();
            this.BringToFront();
        }


        private void ShowPallet(Pallet p)
        {
            //Production = 1,
            //Standard = 2,
            //WarehouseEnter = 3,
            //LiftEnter = 4,
            //Lift = 5,             ==> OK
            //Control = 6,          ==> OK
            //Repair = 7,           ==> OK
            //Inspection = 8,       ==> OK
            //Warehouse = 9,
            //Master = 10,
            //BatteryZero = 11,
            //Cross = 12,
            //Ramp = 13,
            //MainEnter = 14,
            //RampEnter = 15,
            //BatteryOne = 16

            //if (_pos.Type == PositionType.Control || _pos.Type == PositionType.Repair || _pos.Type == PositionType.Inspection || _pos.Type == PositionType.Lift)
            //{
            //    panPallet.Dock = DockStyle.None;
            //    panPallet.SetBounds(10, 10, 25, 25);
            //}
            //else
            //    panPallet.Dock = DockStyle.Fill;

            //lblPallet.Text = p.Symbol;
            //panPallet.BackColor = lblPallet.BackColor = p.Type == PalletType.HR ? Color.LightPink : Color.LightSkyBlue;
            //if (p.State != PalletState.OK)
            //    panPallet.BackColor = lblPallet.BackColor = Color.Red;

            //panPallet.BringToFront();
        }


        public void MapPallet(Pallet p, bool invoke)
        {
            //if (invoke)
            //{
            //    lblPallet.Invoke(new Action(delegate ()
            //    {
            //        ShowPallet(p);
            //    }));
            //}
            //else
            //    ShowPallet(p);
        }

        public void RemovePallet()
        {
            //if (_numberVisible)
            //{
            //    panNumber.Invoke(new Action(delegate ()
            //    {
            //        panNumber.BringToFront();
            //    }));
            //}
            //else
            //{
            //    panMain.Invoke(new Action(delegate ()
            //    {
            //        panMain.BringToFront();
            //    }));
            //}
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
