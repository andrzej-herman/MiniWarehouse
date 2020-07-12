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
        private Timer plcTimer;
        public delegate void Activation(object sender);
        public event Activation Time;

        public Plc()
        {
            State = PlcState.OFF;
            plcTimer = new Timer(2000d);
            plcTimer.Elapsed += PlcTimer_Elapsed;
            plcTimer.Stop();
        }

        private void PlcTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time?.Invoke(this);
        }

        public PlcState State { get; set; }

        public void TurnOn()
        {
            State = PlcState.ON;
            plcTimer.Start();
        }

        public void TurnOff()
        {
            State = PlcState.OFF;
            plcTimer.Stop();
        }

        public void Enable()
        {
            plcTimer.Enabled = true;
        }

        public void Disable()
        {
            plcTimer.Enabled = false;
        }

    }
}
