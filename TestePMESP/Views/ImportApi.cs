using System;

namespace TestePMESP.Views
{
    public class ImportApi
    {
        public DateTime ImportDate { get; set; }
        public int ImportId { get; set; }
        public int NumItems { get; set; }
        public double TotalImport { get; set; }
        public DateTime CloserDate { get; internal set; }
    }
}