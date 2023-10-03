using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Real_planet_sim
{
    public class Timer
    {
        DispatcherTimer dispatcherTimer;
        private int h, m, s;
        public event Action<string> TimeChanged;

        public Timer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);

            dispatcherTimer.Tick += OnTimerTick;
        }

        public void Start()
        {

            dispatcherTimer.Start();
        }

        public void Stop()
        {

            dispatcherTimer.Stop();
        }
        public void reset()
        {
           s = 0;
 
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            s++;
            TimeChanged?.Invoke(s.ToString());

        }
    }
}

