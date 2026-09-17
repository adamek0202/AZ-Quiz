using AZ_Kviz.Utils;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AZ_Kviz.Configuration
{
    internal static class XmlConfigStore
    {
        public static T Load<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                MsgBoxes.ErrorBox("Konfigurační soubor nebyl nalezen. Bude vytvořen nový s výchozími paprametry");
                T newConfig = new T();
                Save(filePath, newConfig);
                return newConfig;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using(StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                string backupPath = filePath + ".bak";
                if (File.Exists(filePath))
                {
                    File.Copy(filePath, backupPath, true);
                }

                T defaultConfig = new T();
                Save(filePath, defaultConfig);
                return defaultConfig;
            }
        }

        public static void Save<T>(string filePath, T config) where T :class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = false
            };

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using(XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, config, namespaces);
            }
        }
    }
}
