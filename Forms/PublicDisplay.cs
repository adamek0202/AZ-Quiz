using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal partial class PublicDisplay : Form
    {
        private readonly Font activeFont = new Font("Arial", 99.75f, FontStyle.Underline);
        private readonly Font inactiveFont = new Font("Arial", 99.75f, FontStyle.Regular);
        private readonly GameState gameState;
        private readonly Countdown countdown;

        public PublicDisplay(GameState gameState, Countdown countdown)
        {
            InitializeComponent();
            this.gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            this.countdown = countdown ?? throw new ArgumentNullException(nameof(countdown));

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

        public void HighlightField(uint fieldId) => gameBoard.HighlightField(fieldId);

        public void ClearHighlight() => gameBoard.ClearHighlight();


        private void Game_StatsChanged()
        {
            // Průběžné skóre během hry na tabuli diváků
            playerOneScoreLabel.Text = gameState.PlayerOne.Points.ToString();
            playerTwoScoreLabel.Text = gameState.PlayerTwo.Points.ToString();
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var external = Screen.AllScreens.FirstOrDefault(s => !s.Primary);
            if(external == null)
            {
                return;
            }

            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = external.Bounds;
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