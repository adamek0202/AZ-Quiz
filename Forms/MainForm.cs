using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class MainForm : Form
    {
        private readonly PublicDisplay pd;

        public MainForm()
        {
            InitializeComponent();
            gameBoard1.TileClicked += (index, tile) =>
            {
                if (tile.State == TileManager.TileStates.Clear || (tile.State == TileManager.TileStates.Incorrect && Player.CurrentPlayer.Stats().Correct >= 3))
                {
                    int n = index + 1;
                    var qf = new QuestionForm(n, tile.State == TileManager.TileStates.Incorrect);
                    if (qf.ShowDialog() == DialogResult.OK)
                    {
                        ProcessScoring(n, qf.Answer);
                        Player.NextPlayer();
                    }
                }
                else
                {
                    MessageBox.Show("Hráč nemá dost bodů k tomu, aby si vzal náhradní otázku", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            Player.StatsChanged += Player_StatsChanged;
            Player.PlayerChanged += Player_PlayerChanged;
            pd = new PublicDisplay();
            pd.Show();
        }

        private void Player_PlayerChanged()
        {
            if (Player.CurrentPlayer == Player.Players.PlayerOne)
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

        private void Player_StatsChanged()
        {
            playerOneCorrectBox.Text = Player.Players.PlayerOne.Stats().Correct.ToString();
            playerOneIncorrectBox.Text = Player.Players.PlayerOne.Stats().Incorrect.ToString();
            playerTwoCorrectBox.Text = Player.Players.PlayerTwo.Stats().Correct.ToString();
            playerTwoIncorrectBox.Text = Player.Players.PlayerTwo.Stats().Incorrect.ToString();
        }

        private void ProcessScoring(int id, Answers answer)
        {
            switch (answer)
            {
                case Answers.Correct:
                    TileManager.UpdateTile(id, Player.CurrentPlayer == Player.Players.PlayerOne ? TileManager.TileStates.FirtstPlayer_Used : TileManager.TileStates.SecondPlayer_Used);
                    Player.CurrentPlayer.Stats().Correct += 1;
                    break;
                case Answers.Incorrect:
                    TileManager.UpdateTile(id, TileManager.TileStates.Incorrect);
                    Player.CurrentPlayer.Stats().Incorrect += 1;
                    break;
                case Answers.SecondCorrect:
                    TileManager.UpdateTile(id, Player.CurrentPlayer == Player.Players.PlayerOne ? TileManager.TileStates.SecondPlayer_Used : TileManager.TileStates.FirtstPlayer_Used);
                    Player.CurrentPlayer.Stats().Incorrect += 1;
                    Player.OtherPlayer.Stats().Correct += 1;
                    break;
                case Answers.SecondIncorrect:
                    TileManager.UpdateTile(id, TileManager.TileStates.Incorrect);
                    Player.CurrentPlayer.Stats().Incorrect += 1;
                    Player.OtherPlayer.Stats().Incorrect += 1;
                    break;
            }
            Player.UpdateStats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete resetovat hru?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Player.ResetScore();
                gameBoard1.Reset();
                pd.Reset();

            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player.NextPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Player.Players.PlayerOne.Stats().Points != 0 && Player.Players.PlayerTwo.Stats().Points != 0)
            {
                LocalEvents.Conclude();
            }
            else
            {
                MessageBox.Show("Pro vyhodnocení musí mít každý tým\nzodpovězenou alespoň jednu otázku", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
