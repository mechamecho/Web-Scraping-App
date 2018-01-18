using System;

namespace Web_Scraping_App
{
    public class Summary
    {
        public int SummaryId { get; set; }

        public string SymbolName { get; set; }
        public string LastPrice { get; set; }
        public string ChangePercentage { get; set; }
        public string Volume { get; set; }
        public string AverageVolume { get; set; }
        public TableSummary TableSummary { get; set; }
    }
}
