using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class PlayersSetupForm : Form
    {
        public PlayersSetupForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FirstPlayerColorPanel_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                firstPlayerColorPanel.BackColor = colorDialog.Color;
            }
        }

        private void SecondPlayerColorPanel_Paint(object sender, PaintEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                secondPlayerColorPanel.BackColor = colorDialog.Color;
            }
        }
    }
}
