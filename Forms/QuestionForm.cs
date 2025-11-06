using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class QuestionForm : Form
    {
        private int ID;
        private bool Replacement;
        private bool TimerStarted = false;

        internal Answers Answer;

        public QuestionForm(int id, bool replacement = false)
        {
            InitializeComponent();
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
            var question = DatabaseFunctions.GetQuestion((uint)new Random().Next(1, 6), Replacement);
            questionTextBox.Text = question.Text;
            answerTextBox.Text = question.Answer;
            playerTextBox.Text = Player.CurrentPlayer.GetText();
            questionTypeTextBox.Text = !Replacement ? "Normální" : "Náhradní";
        }

        private void Exit(Answers answer)
        {
            if ( TimerStarted && !Countdown.TimerRunning)
            {
                DialogResult = DialogResult.OK;
                Answer = answer;
                Close();
            }
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            if (!TimerStarted)
            {
                Countdown.StartTimer();
                TimerStarted = true; 
            }
        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Countdown.StopTimer();
            Countdown.TimerTicked -= Countdown_TimerTicked;
            Countdown.Finished -= Countdown_Finished;
        }
        private void IncorrectButton_Click(object sender, System.EventArgs e)
        {
            Exit(Answers.Incorrect);
        }

        private void CorrectButton_Click(object sender, EventArgs e)
        {
            Exit(Answers.Correct);
        }

        private void SecondCorrectButton_Click(object sender, EventArgs e)
        {
            Exit(Answers.SecondCorrect);
        }

        private void SecondIncorrectButton_Click(object sender, EventArgs e)
        {
            Exit(Answers.SecondIncorrect);
        }
    }
}
