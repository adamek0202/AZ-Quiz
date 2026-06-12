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

        private uint currentSetId = 1;

        public MainForm()
        {
            InitializeComponent();

            gameBoard.TileClicked += OnGameBoardTileClicked;
            Player.StatsChanged += Player_StatsChanged;
            Player.PlayerChanged += Player_PlayerChanged;

            pd = new PublicDisplay();
            pd.Show();

            // Inicializace výchozího vzhledu
            Player_PlayerChanged();
        }

        private void OnGameBoardTileClicked(int index, HexTile tile)
        {
            bool isAlternativeQuestion = tile.State == TileManager.TileStates.Incorrect;

            if (tile.State == TileManager.TileStates.Clear || (isAlternativeQuestion && Player.CurrentPlayer.Stats().Correct >= 3))
            {
                // Korektní disposal dialogu, index + 1 posíláme jen pro lidi do okna
                using (var qf = new QuestionForm(index + 1,currentSetId, isAlternativeQuestion))
                {
                    if (qf.ShowDialog() == DialogResult.OK)
                    {
                        ProcessScoring(index, qf.Answer);
                        Player.NextPlayer();
                    }
                }
            }
            else
            {
                MessageBox.Show("Hráč nemá dost bodů k tomu, aby si vzal náhradní otázku.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Player_PlayerChanged()
        {
            if (Player.CurrentPlayer == Player.Players.PlayerOne)
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

        private void Player_StatsChanged()
        {
            playerOneCorrectBox.Text = Player.Players.PlayerOne.Stats().Correct.ToString();
            playerOneIncorrectBox.Text = Player.Players.PlayerOne.Stats().Incorrect.ToString();
            playerTwoCorrectBox.Text = Player.Players.PlayerTwo.Stats().Correct.ToString();
            playerTwoIncorrectBox.Text = Player.Players.PlayerTwo.Stats().Incorrect.ToString();
        }

        private void ProcessScoring(int id, Answers answer)
        {
            var current = Player.CurrentPlayer;
            var other = Player.OtherPlayer;

            switch (answer)
            {
                case Answers.Correct:
                    UpdateBoards(id, current == Player.Players.PlayerOne ? TileManager.TileStates.FirtstPlayer_Used : TileManager.TileStates.SecondPlayer_Used);
                    current.Stats().Correct += 1;
                    break;

                case Answers.Incorrect:
                    UpdateBoards(id, TileManager.TileStates.Incorrect);
                    current.Stats().Incorrect += 1;
                    break;

                case Answers.SecondCorrect:
                    UpdateBoards(id, current == Player.Players.PlayerOne ? TileManager.TileStates.SecondPlayer_Used : TileManager.TileStates.FirtstPlayer_Used);
                    current.Stats().Incorrect += 1;
                    other.Stats().Correct += 1;
                    break;

                case Answers.SecondIncorrect:
                    // Pokud oba odpověděli špatně, pole se zablokuje (zčerná)
                    UpdateBoards(id, TileManager.TileStates.Blocked);
                    current.Stats().Incorrect += 1;
                    other.Stats().Incorrect += 1;
                    break;
            }
            Player.UpdateStats();
        }

        private void UpdateBoards(int id, TileManager.TileStates state)
        {
            gameBoard.UpdateTile(id, state);
            pd.UpdateTile(id, state);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete resetovat hru?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Player.ResetScore();
                gameBoard.Reset();
                pd.Reset();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete program ukončit?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void SkipPlayerButton_Click(object sender, EventArgs e)
        {
            Player.NextPlayer();
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            if (Player.Players.PlayerOne.Stats().Points != 0 && Player.Players.PlayerTwo.Stats().Points != 0)
            {
                pd.Conclude();
            }
            else
            {
                MessageBox.Show("Pro vyhodnocení musí mít každý tým\nzodpovězenou alespoň jednu otázku.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}