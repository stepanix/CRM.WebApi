namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class activitytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PlaceId = c.Int(nullable: false),
                        ActivityLog = c.String(),
                        TenantId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "UserId", "dbo.User");
            DropForeignKey("dbo.Activity", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Activity", "PlaceId", "dbo.Place");
            DropIndex("dbo.Activity", new[] { "TenantId" });
            DropIndex("dbo.Activity", new[] { "PlaceId" });
            DropIndex("dbo.Activity", new[] { "UserId" });
            DropTable("dbo.Activity",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
