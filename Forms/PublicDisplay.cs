using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal partial class PublicDisplay : Form
    {
        private readonly Font activeFont = new Font("Segoe UI", 12, FontStyle.Underline);
        private readonly Font inactiveFont = new Font("Segoe UI", 12, FontStyle.Regular);

        public PublicDisplay()
        {
            InitializeComponent();

            // Navázání odpočtu zůstává stejné
            Countdown.Start += Countdown_Start;
            Countdown.TimerTicked += Countdown_TimerTicked;
            Countdown.Finished += Countdown_Finished;

            // Změna na novou třídu Game
            Game.PlayerChanged += Game_PlayerChanged;
            Game.StatsChanged += Game_StatsChanged;

            // Nastavení reálných jmen hráčů pro zobrazení na veřejném monitoru
            playerOneLabel.Text = Game.PlayerOne.Name;
            playerTwoLabel.Text = Game.PlayerTwo.Name;

            // Inicializace výchozího stavu
            Game_PlayerChanged();
            Game_StatsChanged();
        }

        public void Conclude()
        {
            if (conclusionPanel.Visible) return;
            conclusionPanel.Visible = true;

            // Statistiky na konci hry taháme přímo z instancí hráčů
            playerOneCorrectBox.Text = Game.PlayerOne.Correct.ToString();
            playerOneIncorrectBox.Text = Game.PlayerOne.Incorrect.ToString();
            playerTwoCorrectBox.Text = Game.PlayerTwo.Correct.ToString();
            playerTwoIncorrectBox.Text = Game.PlayerTwo.Incorrect.ToString();
        }

        private void Game_StatsChanged()
        {
            // Průběžné skóre během hry na tabuli diváků
            playerOneScoreLabel.Text = Game.PlayerOne.Correct.ToString();
            playerTwoScoreLabel.Text = Game.PlayerTwo.Correct.ToString();
        }

        private void Game_PlayerChanged()
        {
            // Zvýraznění podtržením podle toho, kdo je aktuálně na řadě
            if (Game.CurrentPlayer == Game.PlayerOne)
            {
                playerOneLabel.Font = activeFont;
                playerTwoLabel.Font = inactiveFont;
            }
            else
            {
                playerOneLabel.Font = inactiveFont;
                playerTwoLabel.Font = activeFont;
            }
        }

        private void Countdown_Finished()
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() => timeIndicator.Visible = false));
            }
        }

        private void Countdown_TimerTicked(int secondsLeft)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() => UpdateCountdown(secondsLeft)));
            }
        }

        private void Countdown_Start()
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    timeIndicator.Visible = true;
                    timeIndicator.AnimationSpeed = 0;
                    timeIndicator.Value = Countdown.MaxTime;
                    timeIndicator.Maximum = Countdown.MaxTime;
                    timeIndicator.Text = Countdown.MaxTime.ToString();
                    timeIndicator.AnimationSpeed = 1000;
                }));
            }
        }

        public void UpdateTile(int ind, TileManager.TileStates state)
        {
            gameBoard.UpdateTile(ind, state);
        }

        public void Reset()
        {
            conclusionPanel.Visible = false;
            gameBoard.Reset();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var screens = Screen.AllScreens;

            if (screens.Length > 1)
            {
                // Druhý monitor (projektor / televize)
                var external = screens[1];

                this.StartPosition = FormStartPosition.Manual;
                this.Location = external.WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Korektní odhlášení všech eventů pro zamezení memory leaků
            Countdown.Start -= Countdown_Start;
            Countdown.TimerTicked -= Countdown_TimerTicked;
            Countdown.Finished -= Countdown_Finished;

            Game.PlayerChanged -= Game_PlayerChanged;
            Game.StatsChanged -= Game_StatsChanged;
        }

        private void UpdateCountdown(int seconds)
        {
            timeIndicator.Text = seconds.ToString();
            timeIndicator.Value = seconds;
        }
    }
}