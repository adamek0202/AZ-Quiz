using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace AZ_Kviz.Importers
{
    internal static class CSVImporter
    {
        public static ImportResult ImportToDataTable(string filePath, DataTable targetTable)
        {
            Log.Information("Zahájen import CSV ze souboru: {FilePath}", filePath);

            

            try
            {
                Encoding encoding = DetectEncoding(filePath);
                Log.Information(
                "CSV Import: Detekováno kódování {Encoding}",
                encoding.EncodingName);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    DetectDelimiter = true,
                    MissingFieldFound = null,
                    BadDataFound = context =>
                    {
                        
                    }
                };

                using var reader = new StreamReader(filePath, encoding, true);
                using var csv = new CsvReader(reader, config);

                var rows = new List<ImportRow>();
                var readErrors = new List<string>();

                config.BadDataFound = context =>
                {
                    int row = context.Context.Parser.Row;
                    Log.Warning("CSV Import: Chybný formát dat na řádku {RowNumber}", row);
                    readErrors.Add($"Chybný formát dat na řádku {context.Context.Reader.Context.Parser.Row}.");
                };

                while (csv.Read())
                {
                    var record = csv.Parser.Record;
                    int rowNumber = csv.Context.Parser.Row;

                    // 1. Kontrola počtu sloupců
                    if (record == null || record.Length < Importer.RequiredFieldCount)
                    {
                        Log.Warning("CSV Import: Řádek {RowNumber} neobsahuje dostatečný počet sloupců (nalezeno: {Count}, očekáváno: {Required})",
                            rowNumber, record?.Length ?? 0, Importer.RequiredFieldCount);

                        readErrors.Add($"Řádek {rowNumber}: Chybí sloupce.");
                        continue;
                    }

                    rows.Add(new ImportRow
                    {
                        RowNumber = rowNumber,
                        Text = record[0],
                        Answer = record[1]
                    });
                }

                var result = ImportProcessor.Process(rows, targetTable);
                result.Errors.AddRange(readErrors);

                return result;
            }
            catch (IOException ex)
            {
                var result = new ImportResult();
                Log.Error(ex, "CSV Import: Soubor {FilePath} nelze otevřít nebo přečíst", filePath);
                result.Errors.Add("Soubor nelze přečíst (může být otevřen v jiném programu).");
                return result;
            }
            catch (Exception ex)
            {
                var result = new ImportResult();
                Log.Error(ex, "CSV Import: Neočekávaná výjimka při zpracování souboru {FilePath}", filePath);
                result.Errors.Add("Chyba importu");
                return result;
            }
        }

        private static Encoding DetectEncoding(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);

            if (bytes.Length >= 3 &&
                bytes[0] == 0xEF &&
                bytes[1] == 0xBB &&
                bytes[2] == 0xBF)
            {
                return new UTF8Encoding(false);
            }

            if (bytes.Length >= 2 &&
                bytes[0] == 0xFF &&
                bytes[1] == 0xFE)
            {
                return Encoding.Unicode;
            }

            // UTF-16 BE BOM
            if (bytes.Length >= 2 &&
                bytes[0] == 0xFE &&
                bytes[1] == 0xFF)
            {
                return Encoding.BigEndianUnicode;
            }

            // Kontrola platnosti UTF-8
            try
            {
                var utf8 = new UTF8Encoding(false, true);
                utf8.GetString(bytes);

                return utf8;
            }
            catch (DecoderFallbackException)
            {
                // Neplatné UTF-8 -> předpoklad Windows-1250
                Log.Warning("CSV má neplatné UTF-8 kódování, používám Windows-1250");
                return Encoding.GetEncoding(1250);
            }
        }
    }
}
