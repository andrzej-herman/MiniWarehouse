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
        private Timer positionsTimer;
        private Timer masterTimer;
        public delegate void Activation(object sender);
        public event Activation PositionTime;
        public event Activation MasterTime;

        public Plc()
        {
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

    }
}
