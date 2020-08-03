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
            bool res = false;
            while (!res)
            {
                res = StartAliveCommunication();
            }

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

        private bool StartAliveCommunication()
        {
            try
            {
                dbContext.Alive.FirstOrDefault(a => a.Id == 0).PlcCounter++;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }       
        }

        public bool IsPcAlive
        {
            get
            {
                try
                {
                    var query = dbContext.Alive.AsNoTracking().FirstOrDefault(a => a.Id == 0);
                    var plc = query.PlcCounter;
                    var pc = query.PcCounter;
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
                var query = dbContext.Control.AsNoTracking().FirstOrDefault(a => a.Id == 0);
                var plc = query.PlcCounter;
                var pc = query.PcCounter;
                if (plc == pc)
                {
                    if (query.PalletId.HasValue)
                    {
                        res = query.PalletId.Value;
                        destination = query.Destination;
                    }
                }

                if (res != 0)
                {
                    dbContext.Control.FirstOrDefault(a => a.Id == 0).Barcode = null;
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
