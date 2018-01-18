using System.Data.Entity;

namespace Web_Scraping_App
{
    public class StockSummaryContext : DbContext
    {
        public DbSet<StockSummary> StockSummaries { get; set; }

        public StockSummaryContext()
            :base()
        {
            
        }
    }
}
