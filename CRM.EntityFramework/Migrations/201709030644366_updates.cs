namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Place", "Latitude", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Place", "Longitude", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Place", "City");
            DropColumn("dbo.Place", "State");
            DropColumn("dbo.Place", "Zip");
            DropColumn("dbo.Place", "ZipExtension");
            DropColumn("dbo.Place", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Place", "Country", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Place", "ZipExtension", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Place", "Zip", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Place", "State", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Place", "City", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Place", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Place", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
