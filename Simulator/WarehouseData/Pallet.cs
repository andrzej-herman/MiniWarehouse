using Simulator.Controls;
using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData
{
    public class Pallet
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Barcode { get; set; }
        public PalletType Type { get; set; }
        public string ProductName { get; set; }
        public PalletState State { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Destination { get; set; }
        public int? PcId { get; set; }
        public ucPallet Display { get; set; }

        public void InitDisplay()
        {
            Display = new ucPallet();
            Display.Init(this);
        }
    }
}








