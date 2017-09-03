namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "TenantId" });
            AlterColumn("dbo.User", "TenantId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "TenantId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "TenantId" });
            AlterColumn("dbo.User", "TenantId", c => c.Int());
            CreateIndex("dbo.User", "TenantId");
        }
    }
}
