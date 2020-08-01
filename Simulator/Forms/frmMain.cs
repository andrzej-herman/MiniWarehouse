using Simulator.Controls;
using Simulator.Database;
using Simulator.Forms;
using Simulator.Production;
using Simulator.Siemens;
using Simulator.WarehouseData;
using Simulator.WarehouseData.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class frmMain : Form
    {
       
        public frmMain()
        {
            InitializeComponent();
            this.Shown += StartApplication;
        }

        #region Start Application

        private frmWelcome _startScreen;

        private void ShowStartScreen()
        {
            _startScreen = new frmWelcome();
            _startScreen.Show();
        }


        private void HideCover()
        {
            _startScreen.Close();
            _startScreen.Dispose();
            panCover1.Visible = false;
        }

        private void StartApplication(object sender, EventArgs e)
        {
            ShowStartScreen();
            CreateDb();
            CreateWarehouse(_dbContext);
            CreateProductionGenerator(_dbContext);
            CreatePlc();
            CreateCabinet();
            HideCover();
        }

        #endregion

        #region DbContext

        private SimulatorContext _dbContext;
        private void CreateDb()
        {
            _dbContext = new SimulatorContext();
        }

        #endregion

        #region Warehouse

        private Warehouse _warehouse;
        private void CreateWarehouse(SimulatorContext dbContext)
        {
            _warehouse = new Warehouse(dbContext);
            _warehouse.SetNeighbours();
            _warehouse.CreatePositions(tabLevel0, tabLevel1);
            _warehouse.CreateBayNumbers(tabLevel0, tabLevel1);
            _warehouse.ShowMasters();
            _warehouse.ShowPallets();
        }

        #endregion

        #region Plc

        private Plc _plc;
        private void CreatePlc()
        {
            _plc = new Plc();
            _plc.PositionTime += Positions_Run;
            _plc.MasterTime += Master_Run;
        }

        private void Master_Run(object sender)
        {
            _plc.DisableMaster();
            _warehouse.MoveMasters();
            RefreshCabinet();
            _plc.EnableMaster();
        }

        private void Positions_Run(object sender)
        {
            _plc.DisablePositions();
            _warehouse.MovePositions();
            RefreshCabinet();
            _plc.EnablePositions();
        }

        private void PowerOn()
        {   
            if (_plc.State == Helpers.PlcState.OFF)
                _plc.TurnOn();
        }

        private void PowerOff()
        {
            _warehouse.SaveData();
            _plc.TurnOff();
            _productionGenerator.TurnOff();

        }

        #endregion

        #region Production

        private ProductionGenerator _productionGenerator;

        private void ProductionOn()
        {
            if (_plc.State == Helpers.PlcState.ON)
            {
                if (_productionGenerator.CanRun)
                    _productionGenerator.TurnOn();
            }
        }

        private void ProductionOff()
        {
            _productionGenerator.TurnOff();
        }

        private void CreateProductionGenerator(SimulatorContext context)
        {
            _productionGenerator = new ProductionGenerator(context);
            _productionGenerator.Time += Production_Run;
        }

        private void Production_Run(object sender)
        {
            _productionGenerator.Disable();
            var position = _warehouse.Positions.FirstOrDefault(p => p.Type == Helpers.PositionType.Production);
            if (position.CanHostPallet)
            {
                var pallet = _productionGenerator.CreateNewPallet();
                if (pallet != null)
                {
                    position.MapPallet(pallet);
                    RefreshCabinet();
                }
            }

            _productionGenerator.Enable();
        }

        private void CreateProductionBatch()
        {
            if (_productionGenerator.CanCreateBatch)
            {
                frmGenerateBatch batchGenerator = new frmGenerateBatch(_productionGenerator.Products);
                var result = batchGenerator.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _productionGenerator.CreateBatch(batchGenerator.SelectedProduct.Id, batchGenerator.NumberOfPallets);
                }
            }
            else
                MessageBox.Show("Nie można utworzyć partii produkcyjnej, ponieważ istnieje aktywna partia produkcyjna", "Symulator magazynu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void mitCreateBatch_Click(object sender, EventArgs e)
        {
            CreateProductionBatch();
            RefreshCabinet();
        }



        #endregion

        #region Cabinet

        private ucPlc _cabinet;

        private void CreateCabinet()
        {
            _cabinet = new ucPlc();
            _cabinet.Init();
            _cabinet.Activated += CommandReleased;
            tabLevel0.Controls.Add(_cabinet);
            _cabinet.SetBounds(1496, 16, 390, 445);
        }

        private void RefreshCabinet(bool turnoff = false)
        {
            _cabinet.RefreshState(_warehouse, _plc, _productionGenerator, turnoff);
        }

        private void CommandReleased(object sender, Helpers.ActionType command)
        {
            switch (command)
            {
                case Helpers.ActionType.POWER_ON:
                    PowerOn();
                    RefreshCabinet();
                    break;
                case Helpers.ActionType.POWER_OFF:
                    PowerOff();
                    RefreshCabinet(true);
                    break;
                case Helpers.ActionType.PRODUCTION_ON:
                    ProductionOn();
                    RefreshCabinet();
                    break;
                case Helpers.ActionType.PRODUCTION_OFF:
                    ProductionOff();
                    RefreshCabinet();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Menu

        private void mitShowNumbers_Click(object sender, EventArgs e)
        {
            _warehouse.ShowNumbers();
            mitShowNumbers.Enabled = false;
            mitHideNumbers.Enabled = true;
        }

        private void mitHideNumbers_Click(object sender, EventArgs e)
        {
            _warehouse.HideNumbers();
            mitShowNumbers.Enabled = true;
            mitHideNumbers.Enabled = false;
        }

        #endregion


    }
}
