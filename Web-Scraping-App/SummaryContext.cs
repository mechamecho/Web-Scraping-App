using System.Data.Entity;

namespace Web_Scraping_App
{
    public class SummaryContext : DbContext
    {
        public SummaryContext()
            :base()
        {
            
        }
        public DbSet<Summary> Summaries { get; set; }
    }
}
