using System.ComponentModel;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal class ReadOnlyTextBox : TextBox
    {
        public ReadOnlyTextBox()
        {
            SelectionHighlightEnabled = false;
        }
        const int WM_SETFOCUS = 0x007;
        const int WM_KILLFOCUS = 0x0008;
        [DefaultValue(true)]
        public bool SelectionHighlightEnabled { get; set; }
        protected override void DefWndProc(ref Message m)
        {
            if(m.Msg == WM_SETFOCUS && !SelectionHighlightEnabled)
            {
                m.Msg = WM_KILLFOCUS;
            }
            base.DefWndProc(ref m);
        }
    }
}
