using AZ_Kviz.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class PlayersSetupForm : BaseForm
    {
        private readonly AppServices services;
        public string PlayerOneName => playerOneNameBox.Text.Trim();
        public string PlayerTwoName => playerTwoNameBox.Text.Trim();
        public Color PlayerOneColor => firstPlayerColorPanel.BackColor;
        public Color PlayerTwoColor => secondPlayerColorPanel.BackColor;

        public PlayersSetupForm(AppServices services)
        {
            InitializeComponent();
            this.services = services ?? throw new ArgumentNullException(nameof(services));

            firstPlayerColorPanel.BackColor = ColorTranslator.FromHtml(services.Config.AudioVisual.Colors.Player1DefaultColorHex);
            secondPlayerColorPanel.BackColor = ColorTranslator.FromHtml(services.Config.AudioVisual.Colors.Player2DefaultColorHex);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerOneName) || string.IsNullOrEmpty(PlayerTwoName))
            {
                MsgBoxes.WarningBox("Zadejte jména obou hráčů!");
                return;
            }

            if (playerOneNameBox.Text.Length > 12 || playerTwoNameBox.Text.Length > 12)
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

        private void PlayerColorPanel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (panel != null) panel.BackColor = colorDialog.Color;
            }
        }
    }
}
