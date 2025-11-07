using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz
{
    public partial class PublicDisplay : Form
    {
        public PublicDisplay()
        {
            InitializeComponent();
            LocalEvents.UpdateField += PublicDisplay_UpdateField;
            Countdown.Start += Countdown_Start;
            Countdown.TimerTicked += Countdown_TimerTicked;
            Countdown.Finished += Countdown_Finished;
            Player.PlayerChanged += Player_PlayerChanged;
            Player.StatsChanged += Player_StatsChanged;
        }

        private void Player_StatsChanged()
        {
            playerOneScoreLabel.Text = Player.Players.PlayerOne.Stats().Correct.ToString();
            playerTwoScoreLabel.Text = Player.Players.PlayerTwo.Stats().Correct.ToString();
        }

        private void Player_PlayerChanged()
        {
            if(Player.CurrentPlayer == Player.Players.PlayerOne)
            {
                playerOneLabel.Font = new Font(playerOneLabel.Font, FontStyle.Underline);
                playerTwoLabel.Font = new Font(playerTwoLabel.Font, FontStyle.Regular);
            }
            else
            {
                playerOneLabel.Font = new Font(playerOneLabel.Font, FontStyle.Regular);
                playerTwoLabel.Font = new Font(playerTwoLabel.Font, FontStyle.Underline);
            }
        }

        private void Countdown_Finished()
        {
            Invoke(new Action(() =>
            {
                timeIndicator.Visible = false;
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
                timeIndicator.Visible = true;
                timeIndicator.AnimationSpeed = 0;
                timeIndicator.Value = Countdown.Time;
                timeIndicator.Maximum = Countdown.Time;
                timeIndicator.Text = Countdown.Time.ToString();
                timeIndicator.AnimationSpeed = 1000;
            }));
        }

        private void PublicDisplay_UpdateField(int ind, TileManager.TileStates state)
        {
            gameBoard.SetTileColor(ind, state.TileColor());
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
            timeIndicator.Text = seconds.ToString();
            timeIndicator.Value = seconds;
        }
    }
}
