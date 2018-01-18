using System.Data.Entity;

namespace Web_Scraping_App
{
    public class SummaryContext : System.Data.Entity.DbContext
    {
        public SummaryContext()
            :base()
        {
            
        }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<TableSummary> TableSummaries { get; set; }

    }
}
