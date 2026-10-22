using AZ_Kviz.Utils;
using Serilog;
using System;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class QuestionForm : BaseForm
    {
        private bool isReplacement;
        private bool timerStarted = false;
        private readonly GameState gameState;
        private readonly Countdown countdown;
        private readonly DatabaseFunctions database;

        internal Answers Answer;
        internal uint QuestionId { get; private set; }

        public QuestionForm(uint id, uint setId, bool isReplacement, GameState gameState, Countdown countdown, DatabaseFunctions database)
        {
            InitializeComponent();

            this.gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            this.countdown = countdown ?? throw new ArgumentNullException(nameof(countdown));
            this.database = database ?? throw new ArgumentNullException(nameof(database));
            this.isReplacement = isReplacement;
            this.Text = $"Otázka číslo {id}";

            countdown.TimerTicked += Countdown_TimerTicked;
            countdown.Finished += Countdown_Finished;

            LoadData(setId, id);
        }

        private void Countdown_Finished()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                Invoke(new Action(() =>
                {
                    timeTextBox.Text = "0";
                }));
            }
        }

        private void Countdown_TimerTicked(int obj)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                Invoke(new Action(() =>
                {
                    timeTextBox.Text = obj.ToString();
                }));
            }
        }

        private void LoadData(uint setId, uint id)
        {
            try
            {
                var question = database.GetQuestion(setId, id, isReplacement);
                if (question == null)
                {
                    throw new Exception("DB Logika vrátila prázdný objekt");
                }
                QuestionId = question.Id;
                questionTextBox.Text = question.Text;
                answerTextBox.Text = question.Answer;
                playerTextBox.Text = gameState.CurrentPlayer.ToString();
                questionTypeTextBox.Text = !isReplacement ? "Normální" : "Náhradní";
            }
            catch (Exception ex)
            {
                MsgBoxes.ErrorBox("Při načítání otázky došlo k chybě");
                Log.Error(ex, "Selhalo načtení otázky {@id}", id);
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
                MsgBoxes.WarningBox("Nejdříve musíte spustit odpočet času!", "Upozornění");
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!timerStarted)
            {
                countdown.StartTimer();
                timerStarted = true;

                startButton.Enabled = false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            countdown.StopTimer();

            countdown.TimerTicked -= Countdown_TimerTicked;
            countdown.Finished -= Countdown_Finished;

            base.OnFormClosed(e);
        }

        private void IncorrectButton_Click(object sender, EventArgs e) => Exit(Answers.Incorrect);
        private void CorrectButton_Click(object sender, EventArgs e) => Exit(Answers.Correct);
        private void SecondCorrectButton_Click(object sender, EventArgs e) => Exit(Answers.SecondCorrect);
        private void SecondIncorrectButton_Click(object sender, EventArgs e) => Exit(Answers.SecondIncorrect);
    }
}
