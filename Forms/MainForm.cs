using System;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class MainForm : Form
    {
        public static int PlayerOne_Points { get; private set; }
        public static int PlayerTwo_Points { get; private set; }

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
            pd = new PublicDisplay();
            pd.Show();
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
                    TileManager.UpdateTile(id, Player.CurrentPlayer == Player.Players.PlayerTwo ? TileManager.TileStates.SecondPlayer_Used : TileManager.TileStates.FirtstPlayer_Used);
                    Player.OtherPlayer.Stats().Correct += 1;
                    break;
                case Answers.SecondIncorrect:
                    TileManager.UpdateTile(id, TileManager.TileStates.Incorrect);
                    Player.OtherPlayer.Stats().Incorrect += 1;
                    break;
            }
            Player.UpdateStats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameBoard1.Reset();
        }
    }
}
