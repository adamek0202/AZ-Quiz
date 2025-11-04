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
    public partial class QuestionsSetSelectForm : Form
    {
        public QuestionsSetSelectForm()
        {
            InitializeComponent();
            LoadData();
        }

        private static void LoadData() {

        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && listView.SelectedItems.Count == 1)
            {

            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count == 1)
            {

            }
        }
    }
}
