namespace Web_Scraping_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Summaries",
                c => new
                    {
                        SummaryId = c.Int(nullable: false, identity: true),
                        SymbolName = c.String(),
                        LastPrice = c.String(),
                        ChangePercentage = c.String(),
                        Volume = c.String(),
                        AverageVolume = c.String(),
                    })
                .PrimaryKey(t => t.SummaryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Summaries");
        }
    }
}
