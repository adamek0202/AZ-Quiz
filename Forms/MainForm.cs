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

        public MainForm(uint setId)
        {
            InitializeComponent();

            currentSetId = setId;

            // Navázání eventů na novou statickou třídu Game
            gameBoard.TileClicked += OnGameBoardTileClicked;
            Game.StatsChanged += Game_StatsChanged;
            Game.PlayerChanged += Game_PlayerChanged;

            pd = new PublicDisplay();
            pd.Show();

            // Nastavení jmen do Labelů z dat, která přišla ze SetupFormu
            playerOneLabel.Text = Game.PlayerOne.Name;
            playerTwoLabel.Text = Game.PlayerTwo.Name;

            // Inicializace výchozího vzhledu (fonty aktivního hráče)
            Game_PlayerChanged();
            Game_StatsChanged();
        }

        private void OnGameBoardTileClicked(int index, HexTile tile)
        {
            bool isAlternativeQuestion = tile.State == TileManager.TileStates.Incorrect;

            if (tile.State == TileManager.TileStates.Clear || (isAlternativeQuestion && Game.CurrentPlayer.Correct >= 3))
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
            else if (isAlternativeQuestion)
            {
                MessageBox.Show("Hráč nemá dost bodů (alespoň 3 správné odpovědi) k tomu, aby si vzal náhradní otázku.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Toto políčko již je obsazené.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ProcessScoring(int id, Answers answer)
        {
            var current = Game.CurrentPlayer;
            var other = Game.OtherPlayer;

            switch (answer)
            {
                case Answers.Correct:
                    UpdateBoards(id, current == Game.PlayerOne ? TileManager.TileStates.FirstPlayer_Used : TileManager.TileStates.SecondPlayer_Used);
                    current.Correct += 1;
                    break;

                case Answers.Incorrect:
                    UpdateBoards(id, TileManager.TileStates.Incorrect);
                    current.Incorrect += 1;
                    break;

                case Answers.SecondCorrect:
                    // Pole získává ten druhý hráč (other)
                    UpdateBoards(id, other == Game.PlayerOne ? TileManager.TileStates.FirstPlayer_Used : TileManager.TileStates.SecondPlayer_Used);
                    // OPRAVA LOGIKY: Bod dostává pouze ten, kdo odpověděl správně. Current hráč body nemění.
                    other.Correct += 1;
                    break;

                case Answers.SecondIncorrect:
                    // Pokud oba odpověděli špatně na stejném políčku, pole zčerná (Blocked)
                    UpdateBoards(id, TileManager.TileStates.Blocked);
                    current.Incorrect += 1;
                    other.Incorrect += 1;
                    break;
            }
            Game.UpdateStats();
        }

        private void UpdateBoards(int id, TileManager.TileStates state)
        {
            bool isWinner = gameBoard.UpdateTile(id, state);
            if (isWinner)
            {
                string winnerName = state == TileManager.TileStates.FirstPlayer_Used
                    ? Game.PlayerOne.Name
                    : Game.PlayerTwo.Name;
                MessageBox.Show($"{winnerName} spojil všechny tři strany a vítězí!", "Konec hry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pd.UpdateTile(id, state);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete resetovat hru?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseFunctions.ResetQuestionUsage(currentSetId);
                Cursor.Current = Cursors.WaitCursor;
                Game.ResetScore();
                gameBoard.Reset();
                pd.Reset();
                concludeButton.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete ukončit aktuální hru?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseFunctions.ResetQuestionUsage(currentSetId);
                pd.Close();
                Close();
            }
        }

        private void SkipPlayerButton_Click(object sender, EventArgs e)
        {
            Game.NextPlayer();
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            if (Game.PlayerOne.Points != 0 && Game.PlayerTwo.Points != 0)
            {
                pd.Conclude();
                concludeButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Pro vyhodnocení musí mít každý tým\nzodpovězenou alespoň jednu otázku.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Odhlášení statických událostí, aby zavřený formulář nezůstal viset v paměti
            Game.StatsChanged -= Game_StatsChanged;
            Game.PlayerChanged -= Game_PlayerChanged;
        }
    }
}