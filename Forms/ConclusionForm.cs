using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class ConclusionForm : Form
    {
        public bool RepeatGame { get; private set; } = false;
        public ConclusionForm()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            playerOneCorrect.Text = Game.PlayerOne.Correct.ToString();
            playerOneIncorrect.Text = Game.PlayerOne.Incorrect.ToString();
            playerTwoCorrect.Text = Game.PlayerTwo.Correct.ToString();
            playerTwoIncorrect.Text = Game.PlayerTwo.Incorrect.ToString();
            playerOneGroupBox.Text = Game.PlayerOne.Name;
            playerTwoGroupBox.Text = Game.PlayerTwo.Name;
        }

        private void EndButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void RepeatButton_Click(object sender, System.EventArgs e)
        {
            RepeatGame = true;
            Close();
        }
    }
}
