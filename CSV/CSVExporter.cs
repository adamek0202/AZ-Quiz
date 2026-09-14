using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal static class CSVExporter
    {
        public static bool ExportFromDataTable(string filePath, DataTable sourceTable, out string errorMessage)
        {
            errorMessage = string.Empty;

            if(sourceTable == null || sourceTable.Rows.Count == 0)
            {
                errorMessage = "Zdrojová tabulka neobsahuje žádná data k exportu.";
                return false;
            }

            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = false,
                    Encoding = Encoding.UTF8,
                };

                using(var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                using(var csv = new CsvWriter(writer, config))
                {
                    foreach(DataRow row in sourceTable.Rows)
                    {
                        if (row.RowState == DataRowState.Deleted) continue;

                        string questionText = row["text"] != DBNull.Value ? row["text"].ToString() : string.Empty;
                        string answerText = row["answer"] != DBNull.Value ? row["answer"].ToString() : string.Empty;

                        csv.WriteField(questionText);
                        csv.WriteField(answerText);

                        csv.NextRecord();
                    }
                }

                return true;
            }
            catch(IOException ex)
            {
                errorMessage = $"Soubor nelze přepsat. Pravděpodobně je otevřen v jiném programu (např. Excel). Zavřete jej a zkuste to znovu.\n\nDetail: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Neočekávaná chyba při exportu: {ex.Message}";
                return false;
            }
        }
    }
}
