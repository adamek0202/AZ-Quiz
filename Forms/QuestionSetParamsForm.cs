using System;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class QuestionSetParamsForm : BaseForm
    {
        public string SetName { get; private set; }
        public string SetScope { get; private set; }
        public uint SetDifficulty { get; private set; }
        public QuestionSetParamsForm()
        {
            InitializeComponent();
            WindowUtils.ReallyCenterToScreen(this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string scope = scopeTextBox.Text;

            if (!(String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(scope))){
                SetName = name;
                SetScope = scope;
                SetDifficulty = (uint)difficultyNumeric.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Musí být vyplněna všechna pole", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
