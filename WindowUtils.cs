using System;
using System.Drawing;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal static class WindowUtils
    {
        public static void ReallyCenterToScreen(Form form)
        {
            Screen screen = Screen.FromControl(form);

            Rectangle workingArea = screen.WorkingArea;
            form.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - form.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - form.Height) / 2)
            };
        }
    }
}
