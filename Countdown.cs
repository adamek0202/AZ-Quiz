using System;
using System.Timers;

namespace AZ_Kviz
{
    internal static class Countdown
    {
        private static System.Timers.Timer TimerDown;
        public static int Remaining = 5;
        public static event Action<int>? TimerTicked;
        public static event Action? Start;
        public static event Action? Finished;
        public static bool TimerRunning {
            get
            {
                return TimerDown.Enabled;
            }
        }

        public static void InitTimer()
        {
            TimerDown = new System.Timers.Timer(1000)
            {
                AutoReset = true
            };
            TimerDown.Elapsed += OnTimerEvent;
        }

        private static void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            if(Remaining > 1)
            {
                Remaining -= 1;
                TimerTicked(Remaining);
            }
            else
            {
                Finished();
                StopTimer();
            }
        }

        public static void StopTimer()
        {
            TimerDown.Stop();
        }

        public static void StartTimer()
        {
            Remaining = 15;
            Start();
            TimerDown.Enabled = true;
        }
    }
}
