using Simulator.Controls;
using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData
{
    public class Master
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public int Capacity { get; set; }
        public int? ActiveMissionId { get; set; }
        public Mission ActiveMission { get; set; }
        public List<Mission> Missions { get; set; }
        public Position CurrentPosition { get; set; }
        public ucMaster Display { get; set; }
        public string BatteryLevel
        {
            get 
            {
                var level = Convert.ToInt32(Convert.ToDouble(Capacity) / 5d);
                return $"{level}%";
            }
        }

        public void SetCurrentPosition(Position pos)
        {
            CurrentPosition = pos;
        }

        public bool IsReady
        {
            get { return Capacity == 500; }
        }

        public bool ChargingRequired
        {
            get { return Capacity < 50; }
        }

        public void Discharge()
        {
            Capacity--;
            UpdateCapacity();
        }

        public void Charge()
        {
            Capacity += 5;
            if (Capacity > 500)
                Capacity = 500;

            UpdateCapacity();
            UpdateCharging();
        }

        
        public void UpdateCapacity()
        {
            Display.UpdateCapacity(this);
        }

        public void UpdateCharging()
        {
            Display.UpdateCharging(this);
        }
    }
}
