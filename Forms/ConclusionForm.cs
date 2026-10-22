using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class ConclusionForm : Form
    {
        private readonly GameState gameState;
        public bool RepeatGame { get; private set; } = false;
        internal ConclusionForm(GameState gameState)
        {
            InitializeComponent();
            this.gameState = gameState ?? throw new System.ArgumentNullException(nameof(gameState));
            FillData();
        }

        private void FillData()
        {
            Text = $"Výsledky hry — {gameState.PlayerOne.Points} : {gameState.PlayerTwo.Points}";
            playerOneCorrect.Text = gameState.PlayerOne.Correct.ToString();
            playerOneIncorrect.Text = gameState.PlayerOne.Incorrect.ToString();
            playerTwoCorrect.Text = gameState.PlayerTwo.Correct.ToString();
            playerTwoIncorrect.Text = gameState.PlayerTwo.Incorrect.ToString();
            playerOneGroupBox.Text = gameState.PlayerOne.Name;
            playerTwoGroupBox.Text = gameState.PlayerTwo.Name;
        }

        private void EndButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RepeatButton_Click(object sender, System.EventArgs e)
        {
            RepeatGame = true;
            Close();
        }
    }
}
