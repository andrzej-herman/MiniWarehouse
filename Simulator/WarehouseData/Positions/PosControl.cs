using Simulator.Helpers;
using Simulator.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.WarehouseData.Positions
{
    public class PosControl : Position
    {
        private Plc _plc;
        private PlcCommunicationStatus _communicationStatus;
        public PosControl(int id, int width, int height, int x, int y, int level, PositionType type,
                       int? forward, int? back, int? left, int? right, int? up, int? down, string bay, string ramp, int? pid, int? mid, bool plc)
           : base(id, width, height, x, y, level, type, forward, back, left, right, up, down, bay, ramp, pid, mid, plc)
        {
            _communicationStatus = PlcCommunicationStatus.Pending;
        }

        public override void SetPlc(Plc plc)
        {
            _plc = plc;
        }


        public override void Move()
        {
            if (Pallet != null)
            {
                if (_communicationStatus == PlcCommunicationStatus.Pending)
                {
                    if (_plc.StartControlCommunication(Pallet.Barcode, Pallet.State))
                    {
                        _communicationStatus = PlcCommunicationStatus.WaitingForResponse;
                        return;
                    }
                }

                if (_communicationStatus == PlcCommunicationStatus.WaitingForResponse)
                {
                    int pcId = _plc.CheckControlResult(out string destination);
                    if (pcId != 0)
                    {
                        Pallet.PcId = pcId;
                        Pallet.Destination = destination;
                        _communicationStatus = PlcCommunicationStatus.ResponseRecived;
                        return;
                    }
                }

                if (_communicationStatus == PlcCommunicationStatus.ResponseRecived)
                {
                    if (Pallet.Destination != null)
                    {
                        // create master mission
                    }
                    else
                    {
                        if (Neighbours[Site.Right].CanHostPallet)
                        {
                            Neighbours[Site.Right].MapPallet(Pallet);
                            RemovePallet();
                            _communicationStatus = PlcCommunicationStatus.Finished;
                        }
                    }
                }


                if (_communicationStatus == PlcCommunicationStatus.Finished)
                    _communicationStatus = PlcCommunicationStatus.Pending;

            }
        }
    }
}
