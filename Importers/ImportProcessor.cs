using Serilog;
using System;
using System.Collections.Generic;
using System.Data;

namespace AZ_Kviz.Importers
{
    internal static class ImportProcessor
    {
        public static ImportResult Process(IEnumerable<ImportRow> rows, DataTable targetTable)
        {
            var result = new ImportResult();

            if(targetTable == null)
            {
                throw new NullReferenceException("Cílová DataTable je null.");
            }

            if (targetTable.Rows.Count < Importer.MaxRows ||
                !targetTable.Columns.Contains("text") ||
                !targetTable.Columns.Contains("answer"))
            {
                result.Errors.Add(
                    "Cílová tabulka nemá očekávané řádky nebo sloupce.");
                return result;
            }

            var importedRows = new List<ImportRow>();

            foreach(var row in rows)
            {
                string text = row.Text?.Trim();
                string answer = row.Answer?.Trim();

                if(string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(answer))
                {
                    continue;
                }

                if(string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(answer))
                {
                    result.Errors.Add($"Řádek {row.RowNumber}: Neúplná data.");
                    continue;
                }

                if(text.Length > Importer.MaxTextLength || answer.Length > Importer.MaxTextLength)
                {
                    result.Errors.Add($"Řádek {row.RowNumber}: Příliš dlouhý text.");
                    continue;
                }

                if(importedRows.Count >= Importer.MaxRows)
                {
                    result.Errors.Add($"Překročen maximální počet {Importer.MaxRows} záznamů.");
                    break;
                }

                importedRows.Add(new ImportRow
                {
                    RowNumber = row.RowNumber,
                    Text = text,
                    Answer = answer
                });
            }

            for (var i = 0; i < importedRows.Count; i++)
            {
                targetTable.Rows[i]["text"] = importedRows[i].Text;
                targetTable.Rows[i]["answer"] = importedRows[i].Answer;
            }

            result.LoadedRowsCount = importedRows.Count;
            result.Success = true;

            Log.Information(
                "Import dokončen. Načteno {Count} řádků, chyb: {Errors}",
                result.LoadedRowsCount,
                result.ErrorCount);

            return result;
        }
    }
}