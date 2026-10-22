using System.Collections.Generic;

namespace AZ_Kviz.Importers
{
    internal sealed class ImportData
    {
        public ImportResult Result { get; set; }
        public List<ImportRow> Rows { get; set; } = new List<ImportRow>();
    }
}
