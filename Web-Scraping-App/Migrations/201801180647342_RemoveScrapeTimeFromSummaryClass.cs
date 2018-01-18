namespace Web_Scraping_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveScrapeTimeFromSummaryClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Summaries", "SummaryScrapeTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Summaries", "SummaryScrapeTime", c => c.DateTime(nullable: false));
        }
    }
}
