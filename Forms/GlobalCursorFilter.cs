using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public class SqlCursorManager : IMessageFilter, IDisposable
    {
        private const int WM_SETCURSOR = 0x0020;
        private static SqlCursorManager _instance;
        private static Cursor _sqlCursor;
        private static int _lockCount = 0;

        // Statický konstruktor - načte kurzor z prostředků při prvním přístupu
        static SqlCursorManager()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = "AZ_Kviz.Resources.sqlwait.cur";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        _sqlCursor = new Cursor(stream);
                    }
                    else
                    {
                        // Fallback na klasické přesýpací hodiny, pokud se soubor nenajde
                        _sqlCursor = Cursors.WaitCursor;
                    }
                }
            }
            catch
            {
                _sqlCursor = Cursors.WaitCursor;
            }
        }

        // Metoda, kterou budeme volat v aplikaci: using (SqlCursorManager.Show()) { ... }
        public static IDisposable Show()
        {
            if (_instance == null)
            {
                _instance = new SqlCursorManager();
                Application.AddMessageFilter(_instance);
            }

            _lockCount++;
            Cursor.Current = _sqlCursor; // Okamžitá změna kurzoru

            return _instance;
        }

        // Implementace IMessageFilter - odchytává zprávy Windows a vnucuje náš kurzor
        public bool PreFilterMessage(ref Message m)
        {
            if (_lockCount > 0 && m.Msg == WM_SETCURSOR)
            {
                Cursor.Current = _sqlCursor;
                return true; // Zprávu jsme vyřídili, WinForms ji nebude měnit zpět
            }
            return false;
        }

        // Implementace IDisposable - automaticky se zavolá na konci 'using' bloku
        public void Dispose()
        {
            _lockCount--;
            if (_lockCount <= 0)
            {
                _lockCount = 0;
                Cursor.Current = Cursors.Default;

                if (_instance != null)
                {
                    Application.RemoveMessageFilter(_instance);
                    _instance = null;
                }
            }
        }
    }
}