using AZ_Kviz.Forms;
using AZ_Kviz.Utils;
using Serilog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal class MyAppContext : ApplicationContext
    {
        private readonly DatabaseFunctions database;
        private readonly AppServices services;
        private uint _selectedSetId;
        private string _playerOneName, _playerTwoName;
        private Color _playerOneColor, _playerTwoColor;
        public MyAppContext(DatabaseFunctions database, AppServices services)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            ShowQuestionSetSelect();
        }

        private void ShowQuestionSetSelect()
        {
            var selectForm = new QuestionSetSelectForm(database, services);

            this.MainForm = selectForm;

            selectForm.FormClosed += (s, e) =>
            {
                if (selectForm.DialogResult == DialogResult.OK)
                {
                    _selectedSetId = selectForm.SelectedSetId;
                    ShowPlayersSetup();
                }
                else
                {
                    ExitThread();
                }
            };

            selectForm.Show();
        }

        private void ShowPlayersSetup()
        {
            var setupForm = new PlayersSetupForm(services);
            this.MainForm = setupForm;

            setupForm.FormClosed += (s, e) =>
            {
                if (setupForm.DialogResult == DialogResult.OK)
                {
                    _playerOneName = setupForm.PlayerOneName;
                    _playerOneColor = setupForm.PlayerOneColor;
                    _playerTwoName = setupForm.PlayerTwoName;
                    _playerTwoColor = setupForm.PlayerTwoColor;

                    StartGame();
                }
                else
                {
                    ShowQuestionSetSelect();
                }
            };

            setupForm.Show();
        }

        private void StartGame()
        {
            var gameState = new GameState(_playerOneName, _playerOneColor, _playerTwoName, _playerTwoColor);
            var countdown = new Countdown(services.Config.Gameplay.Timeouts.AnswerTimeoutSeconds);

            MainForm mainGameForm;
            try
            {
                database.ResetQuestionUsage(_selectedSetId);
                mainGameForm = new MainForm(_selectedSetId, gameState, countdown, database, services);
            }
            catch (Exception ex)
            {
                countdown.Dispose();
                Log.Error(ex, "Chyba při inicializaci hry.");
                MsgBoxes.ErrorBox("Během přípravy hry došlo k chybě");
                ShowQuestionSetSelect();
                return;
            }

            this.MainForm = mainGameForm;

            mainGameForm.FormClosed += (s, e) =>
            {
                ShowQuestionSetSelect();
            };

            mainGameForm.Show();
        }
    }
}