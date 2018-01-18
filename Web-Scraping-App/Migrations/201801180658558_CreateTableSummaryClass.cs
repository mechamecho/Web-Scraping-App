namespace Web_Scraping_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableSummaryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableSummaries",
                c => new
                    {
                        TableSummaryId = c.Int(nullable: false, identity: true),
                        ScrapeTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableSummaryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TableSummaries");
        }
    }
}
