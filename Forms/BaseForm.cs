using System;
using System.Runtime.InteropServices;
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

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            try
            {
                int renderingPolicy = 1; // DWMNCRP_DISABLED
                DwmSetWindowAttribute(Handle, 2, ref renderingPolicy, sizeof(int));
            }
            catch (Exception ex)
            {
                Serilog.Log.Warning(ex, "Nepodařilo se aplikovat DWM politiku pro okno {FormName}", Name);
            }
        }

        // P/Invoke deklarace zabudovaná přímo v základu
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
    }
}
