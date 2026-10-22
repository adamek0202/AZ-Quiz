using System.Collections.Generic;

namespace AZ_Kviz
{
    internal class ImportResult
    {
        public bool Success { get; set; }
        public int LoadedRowsCount { get; set; }
        public int ErrorCount => Errors.Count;
        public List<string> Errors { get; set; } = new List<string>();
    }
}