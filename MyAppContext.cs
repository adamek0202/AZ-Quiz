using AZ_Kviz.Forms;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal class MyAppContext : ApplicationContext
    {
        public MyAppContext()
        {
            if (ShowSelectionForm() == DialogResult.OK)
            {
                if (ShowSetupForm() == DialogResult.OK)
                {

                }
                else
                {
                    ExitThread();
                }
            }
            else
            {
                ExitThread();
            }
        }

        private DialogResult ShowSelectionForm()
        {
            using(var selectForm = new QuestionSetSelectForm())
            {
                return selectForm.ShowDialog();
            }
        }

        private DialogResult ShowSetupForm()
        {
            using(var setupForm = new PlayersSetupForm())
            {
                return setupForm.ShowDialog();
            }

        }
    }
}
