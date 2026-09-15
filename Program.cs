using Serilog;
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
        [MTAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File(
                path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-.log"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning
                ).CreateLogger();

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
                MessageBox.Show("Nastala kritická chyba aplikace. Podrobnosti naleznete v logu.",
                                "Kritická chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
