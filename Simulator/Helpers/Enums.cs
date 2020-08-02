using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Helpers
{
    public enum ActionType
    {
       POWER_ON,
       POWER_OFF,
       PRODUCTION_ON,
       PRODUCTION_OFF
    }

    public enum PlcState
    {
        OFF,
        ON
    }

    public enum PalletState
    {
        OK = 1,
        Broken = 2,
        UnreadableBarcode = 3
    }

    public enum PalletType
    {
        HR = 1,
        DS = 2
    }

    public enum Site
    {
        Forward = 1,
        Back = 2,
        Left = 3,
        Right = 4,
        Up = 5,
        Down = 6
    }

    public enum PositionType
    {
        Production = 1,
        Standard = 2,
        WarehouseEnter = 3,
        LiftEnter = 4,
        Lift = 5,
        Control = 6,
        Repair = 7,
        Inspection = 8,
        Warehouse = 9,
        Master = 10,
        BatteryZero = 11,
        Cross = 12,
        Ramp = 13,
        MainEnter = 14,
        RampEnter = 15,
        BatteryOne = 16
    }

    public enum PositionDirection
    {
        Normal = 1,
        Reverse = 2
    }

    public enum Level
    {
        Zero = 0,
        One = 1
    }

    public enum MissionType
    {
        Technical = 0,
        Shipping = 1,
        Order = 2
    }

    public enum MissionStatus
    {
        Planned = 0,
        Active = 1,
        Finished = 2
    }

    public enum PlcCommunicationStatus
    {
        Pending,
        WaitingForResponse,
        ResponseRecived,
        Finished,
    }
}
