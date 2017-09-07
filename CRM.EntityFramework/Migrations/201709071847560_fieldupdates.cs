namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldupdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RetailAuditForm", "Price", c => c.Boolean());
            AlterColumn("dbo.RetailAuditForm", "StockLevel", c => c.Boolean());
            AlterColumn("dbo.RetailAuditForm", "Note", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RetailAuditForm", "Note", c => c.String(maxLength: 2000, unicode: false));
            AlterColumn("dbo.RetailAuditForm", "StockLevel", c => c.Int());
            AlterColumn("dbo.RetailAuditForm", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
