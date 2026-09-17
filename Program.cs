using AZ_Kviz.Utils;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
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
            AppServices.Initialize();
            InitLogger();
            try
            {
                Log.Information("Aplikace AZ-Kvíz se spouští...");

                Application.SetCompatibleTextRenderingDefault(false);
                if (DatabaseFunctions.InitDatabase()){
                    Application.Run(new MyAppContext());
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Aplikace neočekávaně spadla při startu nebo během běhu.");
                MsgBoxes.FatalBox("Nastala kritická chyba aplikace. Podrobnosti naleznete v logu.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void InitLogger()
        {
            var cfg = AppServices.Config.System.Serilog;
            Enum.TryParse(cfg.MinimumLevel, true, out LogEventLevel minLevel);
            Enum.TryParse(cfg.RollingInterval, true, out RollingInterval interval);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(LogEventLevel.Debug)
                .WriteTo.File(
                path: cfg.LogFilePath,
                rollingInterval: interval,
                restrictedToMinimumLevel: LogEventLevel.Error,
                retainedFileCountLimit: cfg.RetainDays).WriteTo.Debug()
                .CreateLogger();
        }
    }
}
