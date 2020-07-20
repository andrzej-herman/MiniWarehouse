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
using Simulator.Siemens;
using Simulator.Production;
using Simulator.WarehouseData;

namespace Simulator.Controls
{
    public partial class ucPlc : UserControl
    {
        public delegate void Activation(object sender, ActionType command);
        public event Activation Activated;

        public ucPlc()
        {
            InitializeComponent();
        }

        public void RefreshState(Warehouse warehouse, Plc plc, ProductionGenerator productionGenarator, bool turnOff = false)
        {
            if (turnOff)
            {
                Init();
                return;
            }

            if (plc.State == PlcState.OFF)
                sigPower.Red();
            else
                sigPower.Green();

            if (plc.State == PlcState.ON)
            {
                if (productionGenarator.IsRunning)
                    sigProduction.Green();
                else
                    sigProduction.Red();


                if (productionGenarator.ActiveBatch != null)
                {
                    sigBatch.Green();
                    statBatch.SetValue(productionGenarator.ActiveBatch.Status, true);
                }
                else
                {
                    sigBatch.Red();
                    statBatch.SetValue("--/--", true);
                }


                statMaster1.SetValue(warehouse.Masters[0].BatteryLevel, true);
                statMaster2.SetValue(warehouse.Masters[1].BatteryLevel, true);
                statMaster3.SetValue(warehouse.Masters[2].BatteryLevel, true); 
                statMaster4.SetValue(warehouse.Masters[3].BatteryLevel, true);
            }       
        }

        public void Init()
        {
            sigPower.Red();
            sigPower.SetName("POWER");
            sigServer.Off();
            sigServer.SetName("SERVER");
            butPowerOn.SetName("ON");
            butPowerOn.Activated += SetPowerOn;
            butPowerOff.SetName("OFF");
            butPowerOff.Activated += SetPowerOff;
            sigProduction.Off();
            sigProduction.SetName("PRODUCT");
            sigBatch.Off();
            sigBatch.SetName("BATCH");
            butProductionOn.SetName("ON");
            butProductionOn.Activated += SetProductionOn;
            butProductionOff.SetName("OFF");
            butProductionOff.Activated += SetProductionOff;
            statBatch.SetName("STATUS");
            statBatch.SetValue("--/--", false);
            statMaster1.SetName("MASTER 1");
            statMaster2.SetName("MASTER 2");
            statMaster3.SetName("MASTER 3");
            statMaster4.SetName("MASTER 4");
            statMaster1.SetValue("-----", false);
            statMaster2.SetValue("-----", false);
            statMaster3.SetValue("-----", false);
            statMaster4.SetValue("-----", false);
        }

        private void SetProductionOff(object sender)
        {
            Activated?.Invoke(this, ActionType.PRODUCTION_OFF);
        }

        private void SetProductionOn(object sender)
        {
            Activated?.Invoke(this, ActionType.PRODUCTION_ON);
        }

        private void SetPowerOn(object sender)
        {
            Activated?.Invoke(this, ActionType.POWER_ON);
        }

        private void SetPowerOff(object sender)
        {
            Activated?.Invoke(this, ActionType.POWER_OFF);
        }
    }
}
