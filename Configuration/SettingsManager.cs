using Serilog;

namespace AZ_Kviz.Configuration
{
    internal class SettingsManager
    {
        public class EditableSettings
        {
            public int TimeoutSeconds { get; set; }
        }

        public EditableSettings GetCurrentEditableSettings()
        {
            return new EditableSettings
            {
                TimeoutSeconds = AppServices.Config.TimeoutSeconds
            };
        }

        public bool SaveSettings(EditableSettings newSettings, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (newSettings.TimeoutSeconds < 1 || newSettings.TimeoutSeconds > 60)
            {
                errorMessage = "Délka času na odpověď musí být v rozmezí 1 až 60 sekund.";
                return false;
            }

                AppServices.Config.TimeoutSeconds = newSettings.TimeoutSeconds;
                AppServices.SaveConfig();

                Log.Information("Uživatel upravil a uložil konfiguraci. Nový timeout: {Timeout}s", newSettings.TimeoutSeconds);
                return true;
        }
    }
}
