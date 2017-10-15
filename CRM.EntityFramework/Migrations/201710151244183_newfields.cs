namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductRetailAudit", "Available", c => c.Boolean());
            AddColumn("dbo.ProductRetailAudit", "Promoted", c => c.Boolean());
            AddColumn("dbo.ProductRetailAudit", "Price", c => c.Double());
            AddColumn("dbo.ProductRetailAudit", "StockLevel", c => c.Double());
            AddColumn("dbo.ProductRetailAudit", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductRetailAudit", "Note");
            DropColumn("dbo.ProductRetailAudit", "StockLevel");
            DropColumn("dbo.ProductRetailAudit", "Price");
            DropColumn("dbo.ProductRetailAudit", "Promoted");
            DropColumn("dbo.ProductRetailAudit", "Available");
        }
    }
}
