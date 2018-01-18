namespace Web_Scraping_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstablishOneToManyRelationshipBetweenSummaryAndTableSummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Summaries", "TableSummary_TableSummaryId", c => c.Int());
            CreateIndex("dbo.Summaries", "TableSummary_TableSummaryId");
            AddForeignKey("dbo.Summaries", "TableSummary_TableSummaryId", "dbo.TableSummaries", "TableSummaryId");
            CreateTable(
                    "dbo.TableSummaries",
                    c => new
                    {
                        TableSummaryId = c.Int(nullable: false, identity: true),
                        ScrapeTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TableSummaryId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Summaries", "TableSummary_TableSummaryId", "dbo.TableSummaries");
            DropIndex("dbo.Summaries", new[] { "TableSummary_TableSummaryId" });
            DropColumn("dbo.Summaries", "TableSummary_TableSummaryId");
        }
    }
}
