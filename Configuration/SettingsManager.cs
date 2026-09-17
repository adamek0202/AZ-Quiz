using Serilog;
using System.Drawing;

namespace AZ_Kviz.Configuration
{
    internal class SettingsManager
    {
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

        public static EditableSettings GetCurrentEditableSettings()
        {
            return new EditableSettings
            {
                AnswerTimeoutSeconds = AppServices.Config.Gameplay.Timeouts.AnswerTimeoutSeconds,
                ReplacementAnswerTimeout = AppServices.Config.Gameplay.Timeouts.ReplacementTimeoutSeconds,
                GameTimeoutSeconds = AppServices.Config.Gameplay.Timeouts.GameTimeoutSeconds,
                PlaySounds = AppServices.Config.AudioVisual.EnableSound,
                RandomQuestions = AppServices.Config.Database.ShuffleQuestions,
                ShuffleQuestions = AppServices.Config.Database.ShuffleQuestions,
                EndGameAfterWin = AppServices.Config.Gameplay.EndGameAfterWin,
                AllowReplacementQuestions = AppServices.Config.Gameplay.EnableReplacementQuestions,
                PracticeMode = AppServices.Config.Gameplay.PracticeMode,
                DisablePlayerScreen = AppServices.Config.AudioVisual.DisablePlayerFacingDisplay,
                ShowPlayerDisplayConclusion = AppServices.Config.AudioVisual.ShowPlayerDisplayConclusion,
                PlayerOneDefaultColor = ColorTranslator.FromHtml(AppServices.Config.AudioVisual.Colors.Player1DefaultColorHex),
                PlayerTwoDefaultColor = ColorTranslator.FromHtml(AppServices.Config.AudioVisual.Colors.Player2DefaultColorHex)
            };
        }

        public static bool SaveSettings(EditableSettings newSettings, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (newSettings.AnswerTimeoutSeconds < 1 || newSettings.AnswerTimeoutSeconds > 60)
            {
                errorMessage = "Délka času na odpověď musí být v rozmezí 1 až 60 sekund.";
                return false;
            }

            AppServices.Config.Gameplay.Timeouts.AnswerTimeoutSeconds = newSettings.AnswerTimeoutSeconds;
            AppServices.Config.Gameplay.Timeouts.ReplacementTimeoutSeconds = newSettings.ReplacementAnswerTimeout;
            AppServices.Config.Gameplay.Timeouts.GameTimeoutSeconds = newSettings.GameTimeoutSeconds;
            AppServices.Config.AudioVisual.EnableSound = newSettings.PlaySounds;
            AppServices.Config.Database.ShuffleQuestions = newSettings.ShuffleQuestions;
            AppServices.Config.Gameplay.EndGameAfterWin = newSettings.EndGameAfterWin;
            AppServices.Config.Gameplay.EnableReplacementQuestions = newSettings.AllowReplacementQuestions;
            AppServices.Config.Gameplay.PracticeMode = newSettings.PracticeMode;
            AppServices.Config.AudioVisual.DisablePlayerFacingDisplay = newSettings.DisablePlayerScreen;
            AppServices.Config.AudioVisual.ShowPlayerDisplayConclusion = newSettings.ShowPlayerDisplayConclusion;
            AppServices.Config.AudioVisual.Colors.Player1DefaultColorHex = ColorTranslator.ToHtml(newSettings.PlayerOneDefaultColor);
            AppServices.Config.AudioVisual.Colors.Player2DefaultColorHex = ColorTranslator.ToHtml(newSettings.PlayerTwoDefaultColor);
            AppServices.SaveConfig();

            Log.Information("Uživatel upravil a uložil konfiguraci. Nový timeout: {Timeout}s", newSettings.AnswerTimeoutSeconds);
            return true;
        }
    }
}
