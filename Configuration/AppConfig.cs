using System.Xml.Serialization;

namespace AZ_Kviz.Configuration
{
    [XmlRoot("Configuration")]
    public class AppConfig
    {
        [XmlElement("Gameplay")]
        public GameplayConfig Gameplay { get; set; } = new GameplayConfig();

        [XmlElement("Database")]
        public DatabaseConfig Database { get; set; } = new DatabaseConfig();

        [XmlElement("AudioVisual")]
        public AudioVisualConfig AudioVisual { get; set; } = new AudioVisualConfig();

        [XmlElement("System")]
        public SystemConfig System { get; set; } = new SystemConfig();
    }

    public class GameplayConfig
    {
        [XmlElement("EndGameAfterWin")]
        public bool EndGameAfterWin { get; set; } = false;

        [XmlElement("EnableReplacementQuestions")]
        public bool EnableReplacementQuestions { get; set; } = true;

        [XmlElement("ShowAnswerBeforeTimeout")]
        public bool ShowAnswerBeforeTimeout { get; set; } = true;

        [XmlElement("PracticeMode")]
        public bool PracticeMode { get; set; } = false;

        [XmlElement("ScoreMultiplier")]
        public double ScoreMultiplier { get; set; } = 1.0;

        [XmlElement("Timeouts")]
        public TimeoutsConfig Timeouts { get; set; } = new TimeoutsConfig();
    }

    public class TimeoutsConfig
    {
        [XmlElement("AnswerTimeoutSeconds")]
        public int AnswerTimeoutSeconds { get; set; } = 10;

        [XmlElement("SelectionTimeoutSeconds")]
        public int GameTimeoutSeconds { get; set; } = 450;

        [XmlElement("ReplacementTimeoutSeconds")]
        public int ReplacementTimeoutSeconds { get; set; } = 15;
    }

    public class DatabaseConfig
    {
        [XmlElement("DatabaseFileName")]
        public string DatabaseFileName { get; set; } = "data.db";

        [XmlElement("DoDbCheck")]
        public bool DoDbCheck { get; set; } = true;

        [XmlElement("ShuffleQuestions")]
        public bool ShuffleQuestions { get; set; } = true;
    }

    public class AudioVisualConfig
    {
        [XmlElement("EnableSound")]
        public bool EnableSound { get; set; } = true;

        [XmlElement("DisablePlayerFacingDisplay")]
        public bool DisablePlayerFacingDisplay { get; set; } = false;

        [XmlElement("ShowPlayerDisplayConclusion")]
        public bool ShowPlayerDisplayConclusion { get; set; } = true;

        [XmlElement("TargetDisplayIndex")]
        public int TargetDisplayIndex { get; set; } = 1;

        [XmlElement("Colors")]
        public PlayerColorsConfig Colors { get; set; } = new PlayerColorsConfig();
    }

    public class PlayerColorsConfig
    {
        [XmlElement("Player1DefaultColorHex")]
        public string Player1DefaultColorHex { get; set; } = "#FFFFA500";

        [XmlElement("Player2DefaultColorHex")]
        public string Player2DefaultColorHex { get; set; } = "#FF00BFFF";
    }

    public class SystemConfig
    {
        [XmlElement("SoundsFolder")]
        public string SoundsFolders { get; set; } = "Sounds";

        [XmlElement("RandomGeneratorSeed")]
        public int? RandomGeneratorSeed { get; set; } = 0;

        [XmlElement("Serilog")]
        public SerilogConfig Serilog { get; set; } = new SerilogConfig();
    }

    public class SerilogConfig
    {
        [XmlElement("DisableLogging")]
        public bool DisableLogging { get; set; } = false;
        [XmlElement("MinimumLevel")]
        public string MinimumLevel { get; set; } = "Error";

        [XmlElement("LogFilePath")]
        public string LogFilePath { get; set; } = "logs/AZKVIZ-.log";

        [XmlElement("RollingInterval")]
        public string RollingInterval { get; set; } = "Day";

        [XmlElement("RetainDays")]
        public int RetainDays { get; set; } = 30;
    }
}
