using System.Data.Entity;

namespace Web_Scraping_App
{
    public class SummaryContext : DbContext
    {
        public DbSet<Summary> Summaries { get; set; }
    }
}
