using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AZ_Kviz
{
    internal static class Countdown
    {
        private static System.Timers.Timer Timer;
        private static int Elapsed = 0;
        public static event Action<int>? TimerTicked;
        public static event Action? Finished;

        public static void InitTimer()
        {
            Timer = new System.Timers.Timer(1000)
            {
                AutoReset = false
            };
        }

        public static void StartTimer()
        {

        }

        private static void OnTimerEvent(Object source, ElapsedEventArgs e)
        {
            if(Elapsed == 15)
            {

            }
        }
    }
}
