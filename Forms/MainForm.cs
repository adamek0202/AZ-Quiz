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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            gameBoard1.TileClicked += (index, tile) =>
            {
                int n = index + 1;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    gameBoard1.SetTileColor(index, colorDialog1.Color);
                    gameBoard1.Invalidate();
                }
                //MessageBox.Show($"Dlaždice {n} byla kliknuta", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameBoard1.Reset();
        }
    }
}
