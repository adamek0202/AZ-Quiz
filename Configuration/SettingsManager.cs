using Serilog;
using System.Drawing;

namespace AZ_Kviz.Configuration
{
    internal class SettingsManager
    {
        private readonly AppServices services;

        public SettingsManager(AppServices services)
        {
            this.services = services ?? throw new System.ArgumentNullException(nameof(services));
        }

        public class EditableSettings
        {
            public int AnswerTimeoutSeconds { get; set; }
            public int ReplacementAnswerTimeout { get; set; }
            public int GameTimeoutSeconds { get; set; }
            public bool PlaySounds { get; set; }
            public bool RandomQuestions { get; set; }
            public bool ShuffleQuestions { get; set; }
            public bool EndGameAfterWin { get; set; }
            public bool AllowReplacementQuestions { get; set; }
            public bool PracticeMode { get; set; }
            public bool DisablePlayerScreen { get; set; }
            public bool ShowPlayerDisplayConclusion { get; set; }
            public Color PlayerOneDefaultColor { get; set; }
            public Color PlayerTwoDefaultColor { get; set; }
        }

        public EditableSettings GetCurrentEditableSettings()
        {
            return new EditableSettings
            {
                AnswerTimeoutSeconds = services.Config.Gameplay.Timeouts.AnswerTimeoutSeconds,
                ReplacementAnswerTimeout = services.Config.Gameplay.Timeouts.ReplacementTimeoutSeconds,
                GameTimeoutSeconds = services.Config.Gameplay.Timeouts.GameTimeoutSeconds,
                PlaySounds = services.Config.AudioVisual.EnableSound,
                RandomQuestions = services.Config.Database.ShuffleQuestions,
                ShuffleQuestions = services.Config.Database.ShuffleQuestions,
                EndGameAfterWin = services.Config.Gameplay.EndGameAfterWin,
                AllowReplacementQuestions = services.Config.Gameplay.EnableReplacementQuestions,
                PracticeMode = services.Config.Gameplay.PracticeMode,
                DisablePlayerScreen = services.Config.AudioVisual.DisablePlayerFacingDisplay,
                ShowPlayerDisplayConclusion = services.Config.AudioVisual.ShowPlayerDisplayConclusion,
                PlayerOneDefaultColor = ColorTranslator.FromHtml(services.Config.AudioVisual.Colors.Player1DefaultColorHex),
                PlayerTwoDefaultColor = ColorTranslator.FromHtml(services.Config.AudioVisual.Colors.Player2DefaultColorHex)
            };
        }

        public bool SaveSettings(EditableSettings newSettings, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (newSettings.AnswerTimeoutSeconds < 1 || newSettings.AnswerTimeoutSeconds > 60)
            {
                errorMessage = "Délka času na odpověď musí být v rozmezí 1 až 60 sekund.";
                return false;
            }

            services.Config.Gameplay.Timeouts.AnswerTimeoutSeconds = newSettings.AnswerTimeoutSeconds;
            services.Config.Gameplay.Timeouts.ReplacementTimeoutSeconds = newSettings.ReplacementAnswerTimeout;
            services.Config.Gameplay.Timeouts.GameTimeoutSeconds = newSettings.GameTimeoutSeconds;
            services.Config.AudioVisual.EnableSound = newSettings.PlaySounds;
            services.Config.Database.ShuffleQuestions = newSettings.ShuffleQuestions;
            services.Config.Gameplay.EndGameAfterWin = newSettings.EndGameAfterWin;
            services.Config.Gameplay.EnableReplacementQuestions = newSettings.AllowReplacementQuestions;
            services.Config.Gameplay.PracticeMode = newSettings.PracticeMode;
            services.Config.AudioVisual.DisablePlayerFacingDisplay = newSettings.DisablePlayerScreen;
            services.Config.AudioVisual.ShowPlayerDisplayConclusion = newSettings.ShowPlayerDisplayConclusion;
            services.Config.AudioVisual.Colors.Player1DefaultColorHex = ColorTranslator.ToHtml(newSettings.PlayerOneDefaultColor);
            services.Config.AudioVisual.Colors.Player2DefaultColorHex = ColorTranslator.ToHtml(newSettings.PlayerTwoDefaultColor);
            services.SaveConfig();

            Log.Information("Uživatel upravil a uložil konfiguraci. Nový timeout: {Timeout}s", newSettings.AnswerTimeoutSeconds);
            return true;
        }
    }
}
