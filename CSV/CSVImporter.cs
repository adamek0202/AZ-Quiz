using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace AZ_Kviz
{
    internal class ImportResult{
        public bool Success { get; set; }
        public int LoadedRowsCount { get; set; }
        public int ErrorCount => Errors.Count;
        public List<string> Errors { get; set; } = new List<string>();
    }
    internal static class CSVImporter
    {
        private const int MaxRows = 28;
        private const int MaxTextLength = 500;
        private const int RequiredFieldCount = 2;

        public static ImportResult ImportToDataTable(string filePath, DataTable targetTable)
        {
            var result = new ImportResult();
            Log.Information("Zahájen import CSV ze souboru: {FilePath}", filePath);

            if (targetTable == null)
            {
                Log.Error("CSV Import selhal: Cílová DataTable je null.");
                return result;
            }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = false,
                    Encoding = Encoding.UTF8,
                    MissingFieldFound = null,
                    BadDataFound = context =>
                    {
                        int row = context.Context.Reader.Context.Parser.Row;
                        Log.Warning("CSV Import: Chybný formát dat na řádku {RowNumber}", row);
                        result.Errors.Add($"Chybný formát dat na řádku {context.Context.Reader.Context.Parser.Row}.");
                    }
                };

                try
                {
                    using var reader = new StreamReader(filePath, Encoding.UTF8);
                    using var csv = new CsvReader(reader, config);

                    int loadedCount = 0;

                    while (csv.Read() && loadedCount < MaxRows)
                    {
                        int currentRowNum = csv.Context.Parser.Row;
                        var record = csv.Parser.Record;

                        // 1. Kontrola počtu sloupců
                        if (record == null || record.Length < RequiredFieldCount)
                        {
                            Log.Warning("CSV Import: Řádek {RowNumber} neobsahuje dostatečný počet sloupců (nalezeno: {Count}, očekáváno: {Required})",
                                currentRowNum, record?.Length ?? 0, RequiredFieldCount);

                            result.Errors.Add($"Řádek {currentRowNum}: Chybí sloupce.");
                            continue;
                        }

                        string questionText = record[0]?.Trim();
                        string answerText = record[1]?.Trim();

                        // Ignorování prázdných řádků (bez zápisu chyby)
                        if (string.IsNullOrWhiteSpace(questionText) && string.IsNullOrWhiteSpace(answerText))
                        {
                            continue;
                        }

                        // 2. Validace chybějících hodnot
                        if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(answerText))
                        {
                            Log.Warning("CSV Import: Na řádku {RowNumber} chybí text otázky nebo odpovědi", currentRowNum);
                            result.Errors.Add($"Řádek {currentRowNum}: Neúplná data.");
                            continue;
                        }

                        // 3. Validace délky textu
                        if (questionText.Length > MaxTextLength || answerText.Length > MaxTextLength)
                        {
                            Log.Warning("CSV Import: Řádek {RowNumber} přesahuje maximální délku {MaxLength} znaků", currentRowNum, MaxTextLength);
                            result.Errors.Add($"Řádek {currentRowNum}: Příliš dlouhý text.");
                            continue;
                        }

                        // Zápis do DataTable
                        targetTable.Rows.Add(questionText, answerText);
                        loadedCount++;
                    }

                    result.LoadedRowsCount = loadedCount;
                    result.Success = true;

                    Log.Information("CSV import dokončen. Načteno řádků: {LoadedCount}, Počet chyb: {ErrorCount}",
                        loadedCount, result.ErrorCount);
                }
                catch (IOException ex)
                {
                    Log.Error(ex, "CSV Import: Soubor {FilePath} nelze otevřít nebo přečíst", filePath);
                    result.Errors.Add("Soubor nelze přečíst (může být otevřen v jiném programu).");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "CSV Import: Neočekávaná výjimka při zpracování souboru {FilePath}", filePath);
                    result.Errors.Add($"Chyba importu: {ex.Message}");
                }
            return result;
        }
    }
}
