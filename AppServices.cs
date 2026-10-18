using AZ_Kviz.Configuration;

namespace AZ_Kviz
{
    internal sealed class AppServices
    {
        public AppConfig Config { get; }

        public AppServices(AppConfig config)
        {
            Config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        public static AppServices Load()
        {
            return new AppServices(XmlConfigStore.Load<AppConfig>("Config.xml"));
        }

        public void SaveConfig()
        {
            XmlConfigStore.Save("Config.xml", Config);
        }
    }
}
