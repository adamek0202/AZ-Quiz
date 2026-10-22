using System;
using Serilog;
using System.Data;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace AZ_Kviz.Importers
{
    internal static class XLSXImporter
    {
        public static ImportResult ImportToDataTable(string filePath, DataTable targetTable)
        {
            Log.Information("Zahájen import z XLSX souboru: {FilePath}", filePath);

            try
            {
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);

                var rows = new List<ImportRow>();

                foreach(var row in worksheet.RowsUsed())
                {
                    rows.Add(new ImportRow
                    {
                        RowNumber = row.RowNumber(),
                        Text = row.Cell(1).GetFormattedString(),
                        Answer = row.Cell(2).GetFormattedString()
                    });
                }

                return ImportProcessor.Process(rows, targetTable);
            } catch(Exception ex)
            {
                Log.Error(ex, "Chyba při importu XLSX.");

                var result = new ImportResult();
                result.Errors.Add("Při importu došlo k chybě");
                return result;
            }
        }
    }
}
