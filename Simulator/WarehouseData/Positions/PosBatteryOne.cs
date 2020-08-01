using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData.Positions
{
    public class PosBatteryOne : Position
    {
        public PosBatteryOne(int id, int width, int height, int x, int y, int level, PositionType type,
              int? forward, int? back, int? left, int? right, int? up, int? down, string bay, string ramp, int? pid, int? mid)
               : base(id, width, height, x, y, level, type, forward, back, left, right, up, down, bay, ramp, pid, mid)
        {

        }

        public override void ShowMaster(Master master)
        {
            Master = master;
            master.SetCurrentPosition(this);
            Display.MapMaster(master);
            master.UpdateCapacity();
            master.UpdateCharging();
        }

        public override void Move()
        {
            if (Master != null)
                Master.Charge();
        }
    }
}
