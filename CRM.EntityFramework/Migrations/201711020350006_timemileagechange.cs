namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timemileagechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeMileage", "PlaceId", "dbo.Place");
            DropIndex("dbo.TimeMileage", new[] { "PlaceId" });
            DropColumn("dbo.TimeMileage", "PlaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeMileage", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.TimeMileage", "PlaceId");
            AddForeignKey("dbo.TimeMileage", "PlaceId", "dbo.Place", "Id");
        }
    }
}
