using System;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal class BaseForm : Form
    {
        public BaseForm() { }

        protected override void OnLoad(EventArgs e)
        {
            WindowUtils.ReallyCenterToScreen(this);

            base.OnLoad(e);
        }
    }
}
