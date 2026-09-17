using AZ_Kviz.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class PlayersSetupForm : BaseForm
    {
        public string PlayerOneName => playerOneNameBox.Text.Trim();
        public string PlayerTwoName => playerTwoNameBox.Text.Trim();
        public Color PlayerOneColor => firstPlayerColorPanel.BackColor;
        public Color PlayerTwoColor => secondPlayerColorPanel.BackColor;

        public PlayersSetupForm()
        {
            InitializeComponent();

            firstPlayerColorPanel.BackColor = ColorTranslator.FromHtml(AppServices.Config.AudioVisual.Colors.Player1DefaultColorHex);
            secondPlayerColorPanel.BackColor = ColorTranslator.FromHtml(AppServices.Config.AudioVisual.Colors.Player2DefaultColorHex);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerOneName) || string.IsNullOrEmpty(PlayerTwoName))
            {
                MsgBoxes.WarningBox("Zadejte jména obou hráčů!");
                return;
            }

            if(playerOneNameBox.Text.Length > 12 || playerTwoNameBox.Text.Length > 12)
            {
                MsgBoxes.WarningBox("Jména hráčů nesmí být delší než 12 znaků");
            }

            if (PlayerOneColor == PlayerTwoColor)
            {
                MsgBoxes.WarningBox("Hráči nemohou mít stejnou barvu!");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FirstPlayerColorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                firstPlayerColorPanel.BackColor = colorDialog.Color;
            }
        }

        // OPRAVA: Změněno z Paint na Click!
        private void SecondPlayerColorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                secondPlayerColorPanel.BackColor = colorDialog.Color;
            }
        }
    }
}
