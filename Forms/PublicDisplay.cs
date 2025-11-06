using System;
using System.Windows.Forms;

namespace AZ_Kviz
{
    public partial class PublicDisplay : Form
    {
        public PublicDisplay()
        {
            InitializeComponent();
            EventManager.UpdateField += PublicDisplay_UpdateField;
            Countdown.Start += Countdown_Start;
            Countdown.TimerTicked += Countdown_TimerTicked;
            Countdown.Finished += Countdown_Finished;

        }

        private void Countdown_Finished()
        {
            Invoke(new Action(() =>
            {
                circularProgressBar.Visible = false;
            }));
        }

        private void Countdown_TimerTicked(int obj)
        {
            Invoke(new Action(() => UpdateCountdown(obj)));
        }

        private void Countdown_Start()
        {
            Invoke(new Action(() =>
            {
                circularProgressBar.Visible = true;
                circularProgressBar.AnimationSpeed = 0;
                circularProgressBar.Value = 15;
                circularProgressBar.AnimationSpeed = 1000;
            }));
        }

        private void PublicDisplay_UpdateField(int ind, TileManager.TileStates state)
        {
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var screens = Screen.AllScreens;

            if(screens.Length > 1)
            {
                var external = screens[1];

                this.StartPosition = FormStartPosition.Manual;
                this.Location = external.WorkingArea.Location;
            }
        }

        private void UpdateCountdown(int seconds)
        {
            circularProgressBar.Text = seconds.ToString();
            circularProgressBar.Value = seconds;
        }
    }
}
