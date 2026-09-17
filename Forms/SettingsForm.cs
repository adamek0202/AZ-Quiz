using AZ_Kviz.Configuration;
using AZ_Kviz.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class SettingsForm : BaseForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadValues();
        }

        private void LoadValues() {
            var settings = SettingsManager.GetCurrentEditableSettings();
            endGameAfterWinCheck.Checked = settings.EndGameAfterWin;
            playSoundsCheck.Checked = settings.PlaySounds;
            randomQuestionsCheck.Checked = settings.RandomQuestions;
            allowReplacementsCheck.Checked = settings.AllowReplacementQuestions;
            practiceModeCheck.Checked = settings.PracticeMode;
            noPlayerScreenCheck.Checked = settings.DisablePlayerScreen;
            showResultsToPlayersCheck.Checked = settings.ShowPlayerDisplayConclusion;
            gameTimeLimitNumeric.Value = settings.GameTimeoutSeconds;
            normalQuestionTimeLimitNumeric.Value = settings.AnswerTimeoutSeconds;
            replacementQuestionTimeLimitNumeric.Value = settings.ReplacementAnswerTimeout;
            playerOneColorPanel.BackColor = settings.PlayerOneDefaultColor;
            playerTwoColorPanel.BackColor = settings.PlayerTwoDefaultColor;
        }


        private void SaveValues() {
            var settings = new SettingsManager.EditableSettings
            {
                EndGameAfterWin = endGameAfterWinCheck.Checked,
                PlaySounds = playSoundsCheck.Checked,
                RandomQuestions = randomQuestionsCheck.Checked,
                AllowReplacementQuestions = allowReplacementsCheck.Checked,
                PracticeMode = practiceModeCheck.Checked,
                DisablePlayerScreen = noPlayerScreenCheck.Checked,
                ShowPlayerDisplayConclusion = showResultsToPlayersCheck.Checked,
                GameTimeoutSeconds = (int)gameTimeLimitNumeric.Value,
                AnswerTimeoutSeconds = (int)normalQuestionTimeLimitNumeric.Value,
                ReplacementAnswerTimeout = (int)replacementQuestionTimeLimitNumeric.Value,
                PlayerOneDefaultColor = playerOneColorPanel.BackColor,
                PlayerTwoDefaultColor = playerTwoColorPanel.BackColor
            };
            SettingsManager.SaveSettings(settings, out string error);
            if(error != string.Empty)
            {
                MsgBoxes.ErrorBox(error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void RandomQuestionsCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            bool currentVal = randomQuestionsCheck.Checked;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveValues();
            Close();
        }

        private void NoPlayerScreenCheck_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            if (check.Checked)
            {
                showResultsToPlayersCheck.Checked = false;
                showResultsToPlayersCheck.Enabled = false;
            }
            else
            {
                showResultsToPlayersCheck.Enabled = true;
            }
        }

        private void PracticeModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            if (check.Checked)
            {
                endGameAfterWinCheck.Checked = false;
                endGameAfterWinCheck.Enabled = false;
                allowReplacementsCheck.Checked = false;
                allowReplacementsCheck.Enabled = false;
            }
            else
            {
                endGameAfterWinCheck.Enabled = true;
                allowReplacementsCheck.Enabled = true;
            }
        }

        private void PlayerOneColorPanel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                panel.BackColor = colorDialog.Color;
            }
        }
    }
}
