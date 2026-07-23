using System;
using System.Timers;

namespace AZ_Kviz
{
    internal static class Countdown
    {
        private static Timer TimerDown;

        public const int MaxTime = 10;
        public static int Remaining { get; set; } = MaxTime;

        public static event Action<int>? TimerTicked;
        public static event Action? Start;
        public static event Action? Finished;

        public static bool TimerRunning => TimerDown.Enabled;

        static Countdown()
        {
            TimerDown = new Timer(1000)
            {
                AutoReset = true
            };
            TimerDown.Elapsed += OnTimerEvent;
        }

        public static void StartTimer()
        {
            Remaining = MaxTime;
            Start?.Invoke(); // Bezpečné vyvolání
            TimerDown.Start();
        }

        public static void StopTimer()
        {
            TimerDown.Stop();
        }

        private static void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            if (Remaining > 1)
            {
                Remaining -= 1;
                TimerTicked?.Invoke(Remaining); // Bezpečné vyvolání
            }
            else
            {
                StopTimer();
                Finished?.Invoke(); // Bezpečné vyvolání
            }
        }
    }
}
