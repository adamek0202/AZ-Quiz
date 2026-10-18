using AZ_Kviz.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class MainForm : Form
    {
        private readonly PublicDisplay pd;
        private readonly Font activeFont = new Font("Segoe UI", 12, FontStyle.Underline);
        private readonly Font inactiveFont = new Font("Segoe UI", 12, FontStyle.Regular);

        private readonly uint currentSetId;
        private readonly GameState gameState;
        private readonly Countdown countdown;
        private readonly DatabaseFunctions database;
        private readonly AppServices services;
        private bool _skipCloseConfirmation;

        internal MainForm(uint setId, GameState gameState, Countdown countdown, DatabaseFunctions database, AppServices services)
        {
            InitializeComponent();

            currentSetId = setId;
            this.gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            this.countdown = countdown ?? throw new ArgumentNullException(nameof(countdown));
            this.database = database ?? throw new ArgumentNullException(nameof(database));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            gameBoard.SetPlayerColors(gameState.PlayerOne.Color, gameState.PlayerTwo.Color);

            // Navázání událostí na stav aktuální hry
            gameBoard.TileClicked += OnGameBoardTileClicked;
            gameState.StatsChanged += Game_StatsChanged;
            gameState.PlayerChanged += Game_PlayerChanged;

            if (!services.Config.AudioVisual.DisablePlayerFacingDisplay)
            {
                pd = new PublicDisplay(gameState, countdown);
                pd.Show();
            }

            // Nastavení jmen do Labelů z dat, která přišla ze SetupFormu
            playerOneLabel.Text = gameState.PlayerOne.Name;
            playerTwoLabel.Text = gameState.PlayerTwo.Name;

            // Inicializace výchozího vzhledu (fonty aktivního hráče)
            Game_PlayerChanged();
            Game_StatsChanged();
        }

        private void OnGameBoardTileClicked(uint index, HexTile tile)
        {
            if (tile.State == TileManager.TileStates.Clear)
            {
                OpenQuestionForm(index, false);
                return;
            }

            if (tile.State == TileManager.TileStates.Incorrect)
            {
                if (!services.Config.Gameplay.EnableReplacementQuestions)
                {
                    MsgBoxes.InfoBox("Náhradní otázky nejsou v této hře povoleny.");
                }
                else if (gameState.CurrentPlayer.Correct < 3)
                {
                    MsgBoxes.InfoBox($"Hráč {gameState.CurrentPlayer.Name} nemá dost bodů (alespoň 3 správné odpovědi) k tomu, aby si vzal náhradní otázku.");
                }
                else
                {
                    OpenQuestionForm(index, true);
                }
                return;
            }
            MsgBoxes.InfoBox("Toto políčko již je obsazené.");
        }

        private void OpenQuestionForm(uint index, bool isAlternativeQuestion)
        {
            using (var qf = new QuestionForm(index + 1, currentSetId, isAlternativeQuestion, gameState, countdown, database))
            {
                if (qf.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        database.MarkQuestionUsed(qf.QuestionId);
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Error(ex, "Nepodařilo se označit otázku jako použitou.");
                        MsgBoxes.ErrorBox("Odpověď se nepodařilo uložit do databáze.");
                        return;
                    }
                    ProcessScoring(index, qf.Answer);
                    gameState.NextPlayer();
                }
            }
        }

        private void Game_PlayerChanged()
        {
            // Jednoduché porovnání referencí objektů
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

        private void Game_StatsChanged()
        {
            playerOneCorrectBox.Text = gameState.PlayerOne.Correct.ToString();
            playerOneIncorrectBox.Text = gameState.PlayerOne.Incorrect.ToString();
            playerTwoCorrectBox.Text = gameState.PlayerTwo.Correct.ToString();
            playerTwoIncorrectBox.Text = gameState.PlayerTwo.Incorrect.ToString();
        }

        private void ProcessScoring(uint id, Answers answer)
        {
            TileManager.TileStates state = gameState.ApplyAnswer(answer);
            UpdateBoards(id, state);
        }

        private void UpdateBoards(uint id, TileManager.TileStates state)
        {
            bool isWinner = gameBoard.UpdateTile(id, state);
            if (pd != null)
            {
                pd.UpdateTile(id, state);
            }

            if (isWinner)
            {
                Player winner = state == TileManager.TileStates.FirstPlayer_Used
                    ? gameState.PlayerOne
                    : gameState.PlayerTwo;

                if (services.Config.Gameplay.EndGameAfterWin && GameWinner.GameWinAnounce(winner.Name))
                {
                    if (pd != null && services.Config.AudioVisual.ShowPlayerDisplayConclusion)
                    {
                        pd.Conclude();
                    }
                    var cf = new ConclusionForm(gameState);
                    if (cf.ShowDialog() == DialogResult.OK)
                    {
                        _skipCloseConfirmation = true;
                        Close();
                    }
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            if (MsgBoxes.QuestionBox("Opravdu chcete resetovat hru?"))
            {
                try
                {
                    database.ResetQuestionUsage(currentSetId);
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "Nepodařilo se resetovat použití otázek.");
                    MsgBoxes.ErrorBox("Hru se nepodařilo resetovat, protože nelze upravit databázi.");
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                gameState.ResetScore();
                gameBoard.Reset();
                if (pd != null)
                {
                    pd.Reset();
                }
                concludeButton.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SkipPlayerButton_Click(object sender, EventArgs e)
        {
            gameState.NextPlayer();
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            if (gameState.PlayerOne.Points == 0 || gameState.PlayerTwo.Points == 0)
            {
                MsgBoxes.ErrorBox("Pro vyhodnocení musí mít každý hráč\nzodpovězenou alespoň jednu otázku.");
                return;
            }

            if (!MsgBoxes.QuestionBox("Opravdu chcete hru vyhodnotit a ukončit?"))
            {
                return;
            }

            if (pd != null && services.Config.AudioVisual.ShowPlayerDisplayConclusion)
            {
                pd.Conclude();
            }
            var cf = new ConclusionForm(gameState);
            cf.ShowDialog();
            if (cf.RepeatGame)
            {
                ResetGame();
            }
            else
            {
                _skipCloseConfirmation = true;
                Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.Cancel)
            {
                return;
            }

            if (!_skipCloseConfirmation && e.CloseReason == CloseReason.UserClosing &&
                !MsgBoxes.QuestionBox("Opravdu chcete ukončit aktuální hru?"))
            {
                e.Cancel = true;
                return;
            }

            try
            {
                database.ResetQuestionUsage(currentSetId);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Nepodařilo se resetovat použití otázek při ukončení hry.");
            }
            if (pd != null && !pd.IsDisposed)
            {
                pd.Close();
            }
            gameBoard.TileClicked -= OnGameBoardTileClicked;
            gameState.StatsChanged -= Game_StatsChanged;
            gameState.PlayerChanged -= Game_PlayerChanged;
            countdown.Dispose();
        }
    }
}