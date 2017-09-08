namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenantupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenant", "Address", c => c.String(maxLength: 2000, unicode: false));
            AddColumn("dbo.Tenant", "Phone", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Tenant", "Email", c => c.String(maxLength: 500, unicode: false));
            AddColumn("dbo.Tenant", "WebSite", c => c.String(maxLength: 500, unicode: false));
            AddColumn("dbo.Tenant", "ContactPerson", c => c.String(maxLength: 500, unicode: false));
            AddColumn("dbo.Tenant", "ContactNumber", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Tenant", "Name", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenant", "Name", c => c.String());
            DropColumn("dbo.Tenant", "ContactNumber");
            DropColumn("dbo.Tenant", "ContactPerson");
            DropColumn("dbo.Tenant", "WebSite");
            DropColumn("dbo.Tenant", "Email");
            DropColumn("dbo.Tenant", "Phone");
            DropColumn("dbo.Tenant", "Address");
        }
    }
}
