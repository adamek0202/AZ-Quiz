using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class QuestionForm : Form
    {
        private int id;
        private bool isReplacement;
        private bool timerStarted = false;

        internal Answers Answer;

        public QuestionForm(int id, uint setId, bool isReplacement = false)
        {
            InitializeComponent();
            WindowUtils.ReallyCenterToScreen(this);

            this.id = id;
            this.isReplacement = isReplacement;
            this.Text = $"Otázka číslo {id}";

            Countdown.TimerTicked += Countdown_TimerTicked;
            Countdown.Finished += Countdown_Finished;

            LoadData(setId);
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

        private void LoadData(uint setId)
        {
            try
            {
                // Použije se setId určené pro tuto konkrétní hru
                var question = DatabaseFunctions.GetQuestion(setId, isReplacement);

                questionTextBox.Text = question.Text;
                answerTextBox.Text = question.Answer;
                playerTextBox.Text = Player.CurrentPlayer.GetText();
                questionTypeTextBox.Text = !isReplacement ? "Normální" : "Náhradní";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání otázky: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Pokud selže načtení otázky z DB, zavřeme form s Cancel, ať se hra nekousne
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void Exit(Answers answer)
        {
            // Oprava: Už nečekáme na doběhnutí timeru do nuly
            if (timerStarted)
            {
                Answer = answer;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Nejdříve musíte spustit odpočet času!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!timerStarted)
            {
                Countdown.StartTimer();
                timerStarted = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Zastavení odpočtu a korektní odhlášení eventů
            Countdown.StopTimer();
            Countdown.TimerTicked -= Countdown_TimerTicked;
            Countdown.Finished -= Countdown_Finished;
        }

        private void IncorrectButton_Click(object sender, EventArgs e) => Exit(Answers.Incorrect);
        private void CorrectButton_Click(object sender, EventArgs e) => Exit(Answers.Correct);
        private void SecondCorrectButton_Click(object sender, EventArgs e) => Exit(Answers.SecondCorrect);
        private void SecondIncorrectButton_Click(object sender, EventArgs e) => Exit(Answers.SecondIncorrect);
    }
}
