using System;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseFunctions.InitDatabase();
            Application.Run(new MainForm());
        }
    }
}
