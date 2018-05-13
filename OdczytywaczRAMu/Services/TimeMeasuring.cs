using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace OdczytywaczRAMu.Services
{
    public class TimeMeasuring
    {
        Timer timer;
        Action onElapsed;

        public TimeMeasuring(int milisecounds, Action onTimerElapsed)
        {
            this.timer = new Timer(milisecounds);
            this.onElapsed = onTimerElapsed;
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            onElapsed?.Invoke();
        }
    }
}
