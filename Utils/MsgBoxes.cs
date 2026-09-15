using System.Windows.Forms;

namespace AZ_Kviz.Utils
{
    internal static class MsgBoxes
    {
        private static IWin32Window? ActiveOwner => Form.ActiveForm;
        public static bool QuestionBox(string text, string title = "Dotaz") => MessageBox.Show(ActiveOwner, text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        public static void InfoBox(string text, string title = "Info") => MessageBox.Show(ActiveOwner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static void WarningBox(string text, string title = "Varování") => MessageBox.Show(ActiveOwner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public static void ErrorBox(string text, string title = "Chyba") => MessageBox.Show(ActiveOwner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public static void FatalBox(string text, string title = "Kritická chyba") => MessageBox.Show(ActiveOwner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
