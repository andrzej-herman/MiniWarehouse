using Simulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Simulator.Siemens
{
    public class Plc
    {
        PlcContext dbContext;
        private Timer positionsTimer;
        private Timer masterTimer;
        public delegate void Activation(object sender);
        public event Activation PositionTime;
        public event Activation MasterTime;

        public Plc()
        {
            dbContext = new PlcContext();
            State = PlcState.OFF;
            positionsTimer = new Timer(2000d);
            masterTimer = new Timer(1000d);
            positionsTimer.Elapsed += PositionTimer_Elapsed;
            masterTimer.Elapsed += MasterTimer_Elapsed;
            positionsTimer.Stop();
            masterTimer.Stop();
        }

        private void MasterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MasterTime?.Invoke(this);
        }

        private void PositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StartAliveCommunication();
            PositionTime?.Invoke(this);
        }

        public PlcState State { get; set; }

        public void TurnOn()
        {
            State = PlcState.ON;
            positionsTimer.Start();
            masterTimer.Start();
        }

        public void TurnOff()
        {
            State = PlcState.OFF;
            positionsTimer.Stop();
            masterTimer.Stop();
        }

        public void EnablePositions()
        {
            positionsTimer.Enabled = true;
        }

        public void DisablePositions()
        {
            positionsTimer.Enabled = false;
        }

        public void EnableMaster()
        {
            masterTimer.Enabled = true;
        }

        public void DisableMaster()
        {
            masterTimer.Enabled = false;
        }

        #region PlcCommunication

        private void StartAliveCommunication()
        {
            dbContext.Alive.FirstOrDefault(a => a.Id == 0).PlcCounter++;
            dbContext.SaveChanges();
        }

        public bool IsPcAlive
        {
            get
            {
                try
                {
                    var plc = dbContext.Alive.FirstOrDefault(a => a.Id == 0).PlcCounter;
                    var pc = dbContext.Alive.FirstOrDefault(a => a.Id == 0).PcCounter;
                    return plc == pc;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool StartControlCommunication(string barcode, PalletState state)
        {
            try
            {
                dbContext.Control.FirstOrDefault(a => a.Id == 0).Barcode = barcode;
                dbContext.Control.FirstOrDefault(a => a.Id == 0).PalletState = (int)state;
                dbContext.Control.FirstOrDefault(a => a.Id == 0).PlcCounter++;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public int CheckControlResult(out string destination)
        {
            int res = 0;
            destination = null;
            try
            {
                var plc = dbContext.Control.FirstOrDefault(a => a.Id == 0).PlcCounter;
                var pc = dbContext.Control.FirstOrDefault(a => a.Id == 0).PcCounter;
                if (plc == pc)
                {
                    if (dbContext.Control.FirstOrDefault(a => a.Id == 0).PalletId.HasValue)
                    {
                        res = dbContext.Control.FirstOrDefault(a => a.Id == 0).PalletId.Value;
                        destination = dbContext.Control.FirstOrDefault(a => a.Id == 0).Destination;
                    }
                }

                if (res != 0)
                {
                    dbContext.Control.FirstOrDefault(a => a.Id == 0).PalletId = null;
                    dbContext.Control.FirstOrDefault(a => a.Id == 0).Destination = null;
                    dbContext.Control.FirstOrDefault(a => a.Id == 0).PalletState = null;
                    dbContext.SaveChanges();
                }

                return res;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }



        #endregion



    }
}
