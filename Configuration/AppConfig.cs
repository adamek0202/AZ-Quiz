using System.Xml.Serialization;

namespace AZ_Kviz.Configuration
{
    [XmlRoot("Configuration")]
    public class AppConfig
    {
        [XmlElement("DatabaseFileName")]
        public string DatabaseFileName { get; set; } = "data.db";

        [XmlElement("TimeoutSeconds")]
        public int TimeoutSeconds { get; set; } = 10;

        [XmlElement("Serilog")]
        public SerilogConfig Serilog { get; set; } = new SerilogConfig();
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
