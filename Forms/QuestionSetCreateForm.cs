using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static AZ_Kviz.Forms.BasicTheme;

namespace AZ_Kviz.Forms
{
    public partial class QuestionSetCreateForm : Form
    {
        public QuestionSetCreateForm()
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
            if(nameTextBox.Text == string.Empty)
            {
                ShowWarning("Není zadán název sady otázek");
                return false;
            } else if(scopeTextBox.Text == string.Empty)
            {
                ShowWarning("Není zadán okruh otázek");
                return false;
            }
            return true;
        }

        private void ShowWarning(string text)
        {
            MessageBox.Show("Chyba: " + text, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
        }
    }
}
