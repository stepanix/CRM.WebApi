namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "TenantId", c => c.Int());
            CreateIndex("dbo.User", "TenantId");
            AddForeignKey("dbo.User", "TenantId", "dbo.Tenant", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "TenantId", "dbo.Tenant");
            DropIndex("dbo.User", new[] { "TenantId" });
            DropColumn("dbo.User", "TenantId");
        }
    }
}
