namespace EmakinaTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DisplayInfoes",
                c => new
                    {
                        InfoID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Browser = c.String(),
                    })
                .PrimaryKey(t => t.InfoID)
                .ForeignKey("dbo.BoardGames", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisplayInfoes", "GameID", "dbo.BoardGames");
            DropIndex("dbo.DisplayInfoes", new[] { "GameID" });
            DropTable("dbo.DisplayInfoes");
        }
    }
}
