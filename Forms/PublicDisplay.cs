using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal partial class PublicDisplay : Form
    {
        private readonly Font activeFont = new Font("Segoe UI", 12, FontStyle.Underline);
        private readonly Font inactiveFont = new Font("Segoe UI", 12, FontStyle.Regular);
        private readonly GameState gameState;
        private readonly Countdown countdown;

        public PublicDisplay(GameState gameState, Countdown countdown)
        {
            InitializeComponent();
            this.gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            this.countdown = countdown ?? throw new ArgumentNullException(nameof(countdown));
            gameBoard.SetPlayerColors(gameState.PlayerOne.Color, gameState.PlayerTwo.Color);

            countdown.Start += Countdown_Start;
            countdown.TimerTicked += Countdown_TimerTicked;
            countdown.Finished += Countdown_Finished;

            gameState.PlayerChanged += Game_PlayerChanged;
            gameState.StatsChanged += Game_StatsChanged;

            // Nastavení reálných jmen hráčů pro zobrazení na veřejném monitoru
            playerOneLabel.Text = gameState.PlayerOne.Name;
            playerTwoLabel.Text = gameState.PlayerTwo.Name;

            // Inicializace výchozího stavu
            Game_PlayerChanged();
            Game_StatsChanged();
        }

        public void Conclude()
        {
            if (conclusionPanel.Visible) return;
            conclusionPanel.Visible = true;

            // Statistiky na konci hry taháme přímo z instancí hráčů
            playerOneCorrectBox.Text = gameState.PlayerOne.Correct.ToString();
            playerOneIncorrectBox.Text = gameState.PlayerOne.Incorrect.ToString();
            playerTwoCorrectBox.Text = gameState.PlayerTwo.Correct.ToString();
            playerTwoIncorrectBox.Text = gameState.PlayerTwo.Incorrect.ToString();
        }

        private void Game_StatsChanged()
        {
            // Průběžné skóre během hry na tabuli diváků
            playerOneScoreLabel.Text = gameState.PlayerOne.Correct.ToString();
            playerTwoScoreLabel.Text = gameState.PlayerTwo.Correct.ToString();
        }

        private void Game_PlayerChanged()
        {
            // Zvýraznění podtržením podle toho, kdo je aktuálně na řadě
            if (gameState.CurrentPlayer == gameState.PlayerOne)
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
                    timeIndicator.Value = countdown.Remaining;
                    timeIndicator.Maximum = countdown.Remaining;
                    timeIndicator.Text = countdown.Remaining.ToString();
                    timeIndicator.AnimationSpeed = 1000;
                }));
            }
        }

        public void UpdateTile(uint ind, TileManager.TileStates state)
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
            countdown.Start -= Countdown_Start;
            countdown.TimerTicked -= Countdown_TimerTicked;
            countdown.Finished -= Countdown_Finished;

            gameState.PlayerChanged -= Game_PlayerChanged;
            gameState.StatsChanged -= Game_StatsChanged;
        }

        private void UpdateCountdown(int seconds)
        {
            timeIndicator.Text = seconds.ToString();
            timeIndicator.Value = seconds;
        }
    }
}