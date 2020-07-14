using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData.Positions
{
    public class PosLift : Position
    {
        public PosLift(int id, int width, int height, int x, int y, int level, PositionType type,
                      int? forward, int? back, int? left, int? right, int? up, int? down, string bay, string ramp, int? pid, int? mid)
          : base(id, width, height, x, y, level, type, forward, back, left, right, up, down, bay, ramp, pid, mid)
        {

        }
    }
}
