using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class QuestionForm : Form
    {
        private int ID;
        public QuestionForm(int id)
        {
            InitializeComponent();;
            ID = id;
            Text = $"Otázka číslo {id}";
        }

        private void LoadData()
        {
        }

        private void incorrectButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
