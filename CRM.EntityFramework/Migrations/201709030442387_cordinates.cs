namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cordinates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Place", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Place", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Place", "Longitude");
            DropColumn("dbo.Place", "Latitude");
        }
    }
}
