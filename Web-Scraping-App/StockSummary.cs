using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Scraping_App
{
    public class StockSummary
    {
        [Key]
        public int SummaryId { get; set; }
        public DateTime SummaryScrapeTime { get; set; }
        public string SymbolName { get; set; }
        public string LastPrice { get; set; }
        public string ChangePercentage { get; set; }
        public string Volume { get; set; }
        public string AverageVolume { get; set; }
    }
}
