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
        private uint _selectedSetId;
        private string _playerOneName, _playerTwoName;
        private Color _playerOneColor, _playerTwoColor;
        public MyAppContext()
        {
            ShowQuestionSetSelect();
        }

        private void ShowQuestionSetSelect()
        {
            var selectForm = new QuestionSetSelectForm();

            this.MainForm = selectForm;

            selectForm.FormClosed += (s, e) =>
            {
                if(selectForm.DialogResult == DialogResult.OK)
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
            var setupForm = new PlayersSetupForm();
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
            };

            setupForm.Show();
        }

        private void StartGame()
        {
            Game.Init(_playerOneName, _playerOneColor, _playerTwoName, _playerTwoColor);
            DatabaseFunctions.ResetQuestionUsage(_selectedSetId);

            MainForm mainGameForm;
            try
            {
                mainGameForm = new MainForm(_selectedSetId);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Chyba při inicializaci hry.");
                MsgBoxes.ErrorBox($"Během přípravy hry došlo k chybě");
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