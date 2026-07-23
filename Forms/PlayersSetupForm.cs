using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static AZ_Kviz.Forms.BasicTheme;

namespace AZ_Kviz.Forms
{
    public partial class PlayersSetupForm : Form
    {
        private Color firstPlayerColor = Color.Orange;
        private Color secondPlayerColor = Color.DeepSkyBlue;
        public PlayersSetupForm()
        {
            InitializeComponent();
            ReallyCenterToScreen(this);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DWMNCRENDERINGPOLICY renderingPolicy = DWMNCRENDERINGPOLICY.DWMNCRP_DISABLED;
            int hr = DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, renderingPolicy, sizeof(DWMNCRENDERINGPOLICY));
            if (hr != 0)
            {
                throw Marshal.GetExceptionForHR(hr);
            }
        }

        private bool ValidateInput()
        {
            if(firstPlayerNameBox.Text == string.Empty || secondPlayerNameBox.Text == string.Empty)
            {
                ShowWarning("Nejsou vyplněna jména hráčů");
                return false;
            }
            if(firstPlayerNameBox.Text == secondPlayerNameBox.Text)
            {
                ShowWarning("Hráči nemůžou mít stejná jména");
                return false;
            }
            if(firstPlayerColor == secondPlayerColor)
            {
                ShowWarning("Hráči nemůžou mít stejné barvy");
                return false;
            }
            if(!firstPlayerRadio.Checked && !secondPlayerRadio.Checked)
            {
                ShowWarning("Musí být vybráno, který hráč začíná");
                return false;
            }
            return true;
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show("Hru nelze spustit: " + message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            Player.SetPlayerNames(firstPlayerNameBox.Text, secondPlayerNameBox.Text);
            TileManager.Colors.PlayerOneColor = firstPlayerColor;
            TileManager.Colors.PlayerTwoColor = secondPlayerColor;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FirstPlayerColorPanel_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                firstPlayerColorPanel.BackColor = colorDialog.Color;
                firstPlayerColor = colorDialog.Color;
            }
        }

        private void SecondPlayerColorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                secondPlayerColorPanel.BackColor = colorDialog.Color;
                secondPlayerColor = colorDialog.Color;
            }
        }
    }
}
