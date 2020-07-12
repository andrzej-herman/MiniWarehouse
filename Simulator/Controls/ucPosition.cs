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

namespace Simulator.Controls
{
    public partial class ucPosition : UserControl
    {
        private Position _pos;
        private bool _numberVisible = false;

        public ucPosition(Position pos)
        {
            InitializeComponent();
            panMain.Parent = this;
            panNumber.Parent = this;
            panPallet.Parent = this;
            lblNumber.Parent = panNumber;
            lblPallet.Parent = panPallet;
            lblNumber.ForeColor = lblPallet.ForeColor = Color.Black;
            _numberVisible = false;
            _pos = pos;
        }

        public void Init(TabPage level_0, TabPage level_1)
        {
            switch (_pos.Type)
            {
                case PositionType.Lift:
                case PositionType.Control:
                case PositionType.Repair:
                case PositionType.Inspection:
                    panMain.BackColor = panNumber.BackColor = lblNumber.BackColor = Color.Gray;
                    lblNumber.ForeColor = Color.White;
                    break;
                case PositionType.Warehouse:
                    break;
                case PositionType.Master:
                    panMain.BackColor = panNumber.BackColor = lblNumber.BackColor = Color.White;
                    break;
                case PositionType.Battery:
                    panMain.BackColor = panNumber.BackColor = lblNumber.BackColor = Color.MediumAquamarine;
                    break;
                case PositionType.Cross:
                case PositionType.Ramp:
                case PositionType.Production:
                case PositionType.Standard:
                case PositionType.WarehouseEnter:
                case PositionType.LiftEnter:
                default:
                    panMain.BackColor = panNumber.BackColor = lblNumber.BackColor = Color.Gainsboro;
                    break;
            }

            lblNumber.Text = _pos.Id.ToString();
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

            panMain.BringToFront();
        }

        public void MapPallet(Pallet p, bool invoke)
        {

                //Production = 1,
                //Standard = 2,
                //WarehouseEnter = 3,
                //LiftEnter = 4,
                //Lift = 5,
                //Control = 6,
                //Repair = 7,
                //Inspection = 8,
                //Warehouse = 9,
                //Master = 10,
                //Battery = 11,
                //Cross = 12,
                //Ramp = 13



            if (invoke)
            {
                lblPallet.Invoke(new Action(delegate ()
                {
                    if (_pos.Type == PositionType.Control)
                    {
                        panPallet.Dock = DockStyle.None;
                        panPallet.SetBounds(10, 10, 25, 25);
                    }
                    else
                        panPallet.Dock = DockStyle.Fill;

                    lblPallet.Text = p.Symbol;
                    panPallet.BackColor = lblPallet.BackColor = p.Type == PalletType.HR ? Color.LightPink : Color.LightSkyBlue;
                    if (p.State != PalletState.OK)
                        panPallet.BackColor = lblPallet.BackColor = Color.Red;

                    panPallet.BringToFront();
                }));
            }
            else
            {
                if (_pos.Type == PositionType.Control)
                {
                    panPallet.Dock = DockStyle.None;
                    panPallet.SetBounds(10, 10, 25, 25);
                }
                else
                    panPallet.Dock = DockStyle.Fill;

                lblPallet.Text = p.Symbol;
                panPallet.BackColor = lblPallet.BackColor = p.Type == PalletType.HR ? Color.LightPink : Color.LightSkyBlue;
                if (p.State != PalletState.OK)
                    panPallet.BackColor = lblPallet.BackColor = Color.Red;

                panPallet.BringToFront();
            }
        }

        public void RemovePallet()
        {
            if (_numberVisible)
            {
                panNumber.Invoke(new Action(delegate ()
                {
                    panNumber.BringToFront();
                }));
            }              
            else
            {
                panMain.Invoke(new Action(delegate ()
                {
                    panMain.BringToFront();
                }));
            }
        }

        public void ShowNumber()
        {
            if (_pos.Pallet == null)
                panNumber.BringToFront();

            _numberVisible = true;
        }

        public void HideNumber()
        {
            if (_pos.Pallet == null)
                panMain.BringToFront();

            _numberVisible = false;
        }
    }
}
