using System;
using System.Timers;

namespace AZ_Kviz
{
    internal sealed class Countdown : IDisposable
    {
        private readonly Timer timer;
        private readonly int timeoutSeconds;
        private bool disposed;

        public int Remaining { get; private set; }

        public event Action<int>? TimerTicked;
        public event Action? Start;
        public event Action? Finished;

        public bool TimerRunning => timer.Enabled;

        public Countdown(int timeoutSeconds)
        {
            if (timeoutSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(timeoutSeconds));
            }

            this.timeoutSeconds = timeoutSeconds;
            Remaining = timeoutSeconds;
            timer = new Timer(1000) { AutoReset = true };
            timer.Elapsed += OnTimerEvent;
        }

        public void StartTimer()
        {
            ThrowIfDisposed();
            timer.Stop();
            Remaining = timeoutSeconds;
            Start?.Invoke();
            timer.Start();
        }

        public void StopTimer()
        {
            if (!disposed)
            {
                timer.Stop();
            }
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            if (Remaining > 1)
            {
                Remaining -= 1;
                TimerTicked?.Invoke(Remaining);
            }
            else
            {
                StopTimer();
                Finished?.Invoke();
            }
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            timer.Stop();
            timer.Elapsed -= OnTimerEvent;
            timer.Dispose();
            disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Countdown));
            }
        }
    }
}
