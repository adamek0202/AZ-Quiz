using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AZ_Kviz.Forms.BasicTheme;

namespace AZ_Kviz.Forms
{
    public partial class QuestionSetSelectForm : Form
    {
        internal Actions Action { get; private set; }

        internal int ID { get; private set; }
        public QuestionSetSelectForm()
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete aplikaci ukončit?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var form = new QuestionSetCreateForm();
            if(form.ShowDialog() == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private void EditButon_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ID = int.Parse((string)listView.SelectedItems[0].Tag);
                Action = Actions.Edit;
                Close();
            }
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count == 1)
            {
                ID = int.Parse((string)listView.SelectedItems[0].Tag);
                DialogResult = DialogResult.OK;
                Action = Actions.Play;
                Close();
            }
        }

        private void ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && listView.SelectedItems.Count == 1)
            {
                Action = Actions.Play;
                DialogResult = DialogResult.OK;
                ID = int.Parse((string)listView.SelectedItems[0].Tag);
                Close();
            }
        }
    }
}
