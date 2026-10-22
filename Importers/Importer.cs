using System;
using System.Data;
using System.IO;

namespace AZ_Kviz.Importers
{
    internal static class Importer
    {
        public const int MaxRows = 28;
        public const int MaxTextLength = 500;
        public const int RequiredFieldCount = 2;

        public static ImportResult ImportFile(string filePath, DataTable targetTable)
        {
            var result = new ImportResult();

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                result.Errors.Add("Soubor neexistuje nebo nebyl zadán.");
                return result;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (extension != ".csv" && extension != ".xlsx")
            {
                result.Errors.Add("Nepodporovaný formát souboru.");
                return result;
            }

            if (!CanReadFile(filePath))
            {
                result.Errors.Add(
                    "Soubor nelze otevřít pro čtení. " +
                    "Může být uzamčen jinou aplikací nebo nemáte dostatečná oprávnění.");

                return result;
            }

            switch (extension)
            {
                case ".csv":
                    return CSVImporter.ImportToDataTable(filePath, targetTable);

                case ".xlsx":
                    return XLSXImporter.ImportToDataTable(filePath, targetTable);

                default:
                    throw new InvalidOperationException();
            }
        }

        private static bool CanReadFile(string filePath)
        {
            try
            {
                using (var stream = new FileStream(
                           filePath,
                           FileMode.Open,
                           FileAccess.Read,
                           FileShare.ReadWrite | FileShare.Delete))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}