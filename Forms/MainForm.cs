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
        private bool _skipCloseConfirmation;

        public MainForm(uint setId)
        {
            InitializeComponent();

            currentSetId = setId;

            // Navázání eventů na novou statickou třídu Game
            gameBoard.TileClicked += OnGameBoardTileClicked;
            Game.StatsChanged += Game_StatsChanged;
            Game.PlayerChanged += Game_PlayerChanged;

            if (!AppServices.Config.AudioVisual.DisablePlayerFacingDisplay)
            {
                pd = new PublicDisplay();
                pd.Show();
            }

            // Nastavení jmen do Labelů z dat, která přišla ze SetupFormu
            playerOneLabel.Text = Game.PlayerOne.Name;
            playerTwoLabel.Text = Game.PlayerTwo.Name;

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
                if (!AppServices.Config.Gameplay.EnableReplacementQuestions)
                {
                    MsgBoxes.InfoBox("Náhradní otázky nejsou v této hře povoleny.");
                }
                else if (Game.CurrentPlayer.Correct < 3)
                {
                    MsgBoxes.InfoBox($"Hráč {Game.CurrentPlayer.Name} nemá dost bodů (alespoň 3 správné odpovědi) k tomu, aby si vzal náhradní otázku.");
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
            using (var qf = new QuestionForm(index + 1, currentSetId, isAlternativeQuestion))
            {
                if (qf.ShowDialog() == DialogResult.OK)
                {
                    DatabaseFunctions.MarkQuestionUsed(qf.QuestionId);
                    ProcessScoring(index, qf.Answer);
                    Game.NextPlayer();
                }
            }
        }

        private void Game_PlayerChanged()
        {
            // Jednoduché porovnání referencí objektů
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

        private void Game_StatsChanged()
        {
            playerOneCorrectBox.Text = Game.PlayerOne.Correct.ToString();
            playerOneIncorrectBox.Text = Game.PlayerOne.Incorrect.ToString();
            playerTwoCorrectBox.Text = Game.PlayerTwo.Correct.ToString();
            playerTwoIncorrectBox.Text = Game.PlayerTwo.Incorrect.ToString();
        }

        private void ProcessScoring(uint id, Answers answer)
        {
            var current = Game.CurrentPlayer;
            var other = Game.OtherPlayer;
            TileManager.TileStates state;

            switch (answer)
            {
                case Answers.Correct:
                    state = current == Game.PlayerOne ? TileManager.TileStates.FirstPlayer_Used : TileManager.TileStates.SecondPlayer_Used;
                    current.Correct += 1;
                    break;

                case Answers.Incorrect:
                    state = TileManager.TileStates.Incorrect;
                    current.Incorrect += 1;
                    break;

                case Answers.SecondCorrect:
                    // Pole získává ten druhý hráč (other)
                    state = other == Game.PlayerOne ? TileManager.TileStates.FirstPlayer_Used : TileManager.TileStates.SecondPlayer_Used;
                    // OPRAVA LOGIKY: Bod dostává pouze ten, kdo odpověděl správně. Current hráč body nemění.
                    other.Correct += 1;
                    break;

                case Answers.SecondIncorrect:
                    // Pokud oba odpověděli špatně na stejném políčku, pole zčerná (Blocked)
                    state = TileManager.TileStates.Blocked;
                    current.Incorrect += 1;
                    other.Incorrect += 1;
                    break;

                default:
                    return;
            }

            UpdateBoards(id, state);
            Game.UpdateStats();
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
                    ? Game.PlayerOne
                    : Game.PlayerTwo;

                if (AppServices.Config.Gameplay.EndGameAfterWin && GameWinner.GameWinAnounce(winner.Name))
                {
                    if (pd != null && AppServices.Config.AudioVisual.ShowPlayerDisplayConclusion)
                    {
                        pd.Conclude();
                    }
                    var cf = new ConclusionForm();
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
                DatabaseFunctions.ResetQuestionUsage(currentSetId);
                Cursor.Current = Cursors.WaitCursor;
                Game.ResetScore();
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
            Game.NextPlayer();
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            if (Game.PlayerOne.Points == 0 || Game.PlayerTwo.Points == 0)
            {
                MsgBoxes.ErrorBox("Pro vyhodnocení musí mít každý hráč\nzodpovězenou alespoň jednu otázku.");
                return;
            }

            if (!MsgBoxes.QuestionBox("Opravdu chcete hru vyhodnotit a ukončit?"))
            {
                return;
            }

            if (pd != null && AppServices.Config.AudioVisual.ShowPlayerDisplayConclusion)
            {
                pd.Conclude();
            }
            var cf = new ConclusionForm();
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

            DatabaseFunctions.ResetQuestionUsage(currentSetId);
            if (pd != null && !pd.IsDisposed)
            {
                pd.Close();
            }
            gameBoard.TileClicked -= OnGameBoardTileClicked;
            Game.StatsChanged -= Game_StatsChanged;
            Game.PlayerChanged -= Game_PlayerChanged;
        }
    }
}