using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class QuestionForm : Form
    {
        private int ID;
        private bool Replacement;
        public QuestionForm(int id, bool replacement = false)
        {
            InitializeComponent();
            CreateHandle();
            WindowUtils.ReallyCenterToScreen(this);
            ID = id;
            Countdown.TimerTicked += Countdown_TimerTicked;
            Countdown.Finished += Countdown_Finished;
            Replacement = replacement;
            Text = $"Otázka číslo {id}";
            LoadData();
        }

        private void Countdown_Finished()
        {
            Invoke(new Action(() =>
            {
                timeTextBox.Text = "0";
            }));
        }

        private void Countdown_TimerTicked(int obj)
        {
            Invoke(new Action(() =>
            {
                timeTextBox.Text = obj.ToString();
            }));
        }

        private void LoadData()
        {
            var question = DatabaseFunctions.GetQuestion((uint)new Random(ID).Next(1, 6));
            questionTextBox.Text = question.Text;
            answerTextBox.Text = question.Answer;
            playerTextBox.Text = Player.currentPlayer.GetText();
            questionTypeTextBox.Text = !Replacement ? "Normální" : "Náhradní";
        }

        private void IncorrectButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            Countdown.StartTimer();
        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Countdown.StopTimer();
        }
    }
}
