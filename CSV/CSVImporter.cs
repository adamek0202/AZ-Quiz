using CsvHelper;
using CsvHelper.Configuration;
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
        public List<string> Errors { get; set; } = new List<string>();
    }
    internal static class CSVImporter
    {
        private const int MaxRows = 28;
        private const int MaxTextLength = 500;
        
        public static ImportResult ImportToDataTable(string filePath, DataTable targetTable)
        {
            var result = new ImportResult();

            if(targetTable == null)
            {
                result.Errors.Add("Cílová tabulka dat neexistuje.");
                return result;
            }

            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = false,
                    Encoding = Encoding.UTF8,
                    MissingFieldFound = null,
                    BadDataFound = context =>
                    {
                        result.Errors.Add($"Chybný formát dat na řádku {context.Context.Reader.Context.Parser.Row}.");
                    }
                };

                using(var reader = new StreamReader(filePath, Encoding.UTF8))
                using(var csv = new CsvReader(reader, config))
                {
                    int rowIndex = 0;

                    while(csv.Read() && rowIndex < MaxRows)
                    {
                        int currentRowNum = csv.Context.Parser.Row;

                        string questionText = null;
                        string answerText = null;

                        try
                        {
                            questionText = csv.GetField<string>(0)?.Trim();
                            answerText = csv.GetField<string>(1)?.Trim();
                        }
                        catch (CsvHelperException)
                        {
                            result.Errors.Add($"Řádek {currentRowNum}: Neobsahuje dostatečný počet sloupců (očekávány 2).");
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(questionText) && string.IsNullOrWhiteSpace(answerText))
                        {
                            continue;
                        }

                        // Validace validity dat uvnitř CSV
                        if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(answerText))
                        {
                            result.Errors.Add($"Řádek {currentRowNum}: Chybí buď text otázky, nebo odpověď.");
                            continue;
                        }

                        if (questionText.Length > MaxTextLength || answerText.Length > MaxTextLength)
                        {
                            result.Errors.Add($"Řádek {currentRowNum}: Text je příliš dlouhý (maximum je {MaxTextLength} znaků).");
                            continue;
                        }

                        // Bezpečnostní kontrola, zda máme v DataTable reálně dostatek řádků pro přepsání
                        if (rowIndex >= targetTable.Rows.Count)
                        {
                            result.Errors.Add("Vnitřní chyba: Cílová tabulka nemá dostatek předgenerovaných řádků.");
                            break;
                        }

                        // Vše je v pořádku, zapíšeme do DataTable
                        DataRow row = targetTable.Rows[rowIndex];
                        row["text"] = questionText;
                        row["answer"] = answerText;

                        rowIndex++;
                    }

                    result.LoadedRowsCount = rowIndex;
                    result.Success = true;
                }
            }
            catch (IOException ex)
            {
                result.Errors.Add($"Soubor nelze přečíst. Možná je otevřen v jiném programu (např. Excel). Detail: {ex.Message}");
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Neočekávaná chyba importu: {ex.Message}");
            }
            return result;
        }
    }
}
