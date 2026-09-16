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

        [XmlElement("Serilog")]
        public SerilogConfig Serilog { get; set; } = new SerilogConfig();
    }

    public class GameplayConfig
    {
        [XmlElement("AnswerTimeoutSeconds")]
        public int AnswerTimeoutSeconds { get; set; } = 10;

        [XmlElement("SelectionTimeoutSeconds")]
        public int SelectionTimeoutSeconds { get; set; } = 15;
    }

    public class DatabaseConfig
    {
        [XmlElement("DatabaseFileName")]
        public string DatabaseFileName { get; set; } = "data.db";

        [XmlElement("ShuffleQuestions")]
        public bool ShuffleQuestions { get; set; } = true;
    }

    public class AudioVisualConfig
    {
        [XmlElement("EnableSound")]
        public bool EnableSound { get; set; } = true;

        [XmlElement("Player1DefaultColorHex")]
        public string Player1DefaultColorHex { get; set; } = "#FFFFA500";

        [XmlElement("Player2DefaultColorHex")]
        public string Player2DefaultColorHex { get; set; } = "#FF00BFFF";

        [XmlElement("TargetDisplayIndex")]
        public int TargetDisplayIndex { get; set; } = 1;
    }

    public class SerilogConfig
    {
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
