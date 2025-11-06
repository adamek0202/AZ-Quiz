using AZ_Kviz.Forms;
using System;
using System.Collections.Generic;
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
            Countdown.InitTimer();
            DatabaseFunctions.InitDatabase();
            Application.Run(new MainForm());
        }
    }

    internal static class LocalEvents
    {
        internal static event Action<int, TileManager.TileStates>? UpdateField;
    }
}
