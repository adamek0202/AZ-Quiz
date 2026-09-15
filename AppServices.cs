using AZ_Kviz.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal static class AppServices
    {
        public static AppConfig Config { get; private set; }

        public static void Initialize()
        {
            Config = XmlConfigStore.Load<AppConfig>("Config.xml");
        }

        public static void SaveConfig()
        {
            XmlConfigStore.Save("Config.xml", Config);
        }
    }
}
