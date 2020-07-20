using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData
{
    public class Mission
    {
        public int Id { get; set; }
        public MissionType Type { get; set; }
        public int PickPositionId { get; set; }
        public int DropPositionId { get; set; }
        public int PalletId { get; set; }
        public int MasterId { get; set; }
        public MissionStatus Status { get; set; }
    }
}
