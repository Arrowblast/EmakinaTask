namespace EmakinaTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RangeValues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BoardGames", "GameName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BoardGames", "GameName", c => c.String(nullable: false));
        }
    }
}
