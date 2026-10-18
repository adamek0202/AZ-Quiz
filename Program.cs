using AZ_Kviz.Utils;
using Serilog;
using Serilog.Events;
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
            AppServices services = AppServices.Load();
            InitLogger(services);
            var database = new DatabaseFunctions(services.Config.Database.DatabaseFileName, services.Config);
            try
            {
                Log.Information("Aplikace AZ-Kvíz se spouští...");

                Application.SetCompatibleTextRenderingDefault(false);
                if (database.InitDatabase())
                {
                    Application.Run(new MyAppContext(database, services));
                }
                else
                {
                    MsgBoxes.FatalBox("Integrita databáze byla porušena!", "Chyba databáze");
                    if (MsgBoxes.QuestionBox("Chcete vytvořit novou (prázdnou) databázi?"))
                    {
                        database.RecreateDatabase();
                        Application.Run(new MyAppContext(database, services));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Aplikace neočekávaně spadla při startu nebo během běhu.");
                MsgBoxes.FatalBox("Nastala kritická chyba aplikace. Podrobnosti naleznete v logu.");
            }
            finally
            {
                database.Dispose();
                Log.CloseAndFlush();
            }
        }

        private static void InitLogger(AppServices services)
        {
            var cfg = services.Config.System.Serilog;
            Enum.TryParse(cfg.MinimumLevel, true, out LogEventLevel minLevel);
            Enum.TryParse(cfg.RollingInterval, true, out RollingInterval interval);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(LogEventLevel.Debug)
                .WriteTo.File(
                path: cfg.LogFilePath,
                rollingInterval: interval,
                restrictedToMinimumLevel: minLevel,
                retainedFileCountLimit: cfg.RetainDays).WriteTo.Debug()
                .CreateLogger();
        }
    }
}
