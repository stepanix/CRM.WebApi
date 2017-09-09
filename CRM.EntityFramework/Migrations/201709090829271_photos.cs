namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class photos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureUrl = c.String(),
                        Note = c.String(),
                        PlaceId = c.Int(nullable: false),
                        CreatorUserId = c.String(nullable: false, maxLength: 128),
                        LastModifierUserId = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.User", t => t.CreatorUserId)
                .ForeignKey("dbo.User", t => t.LastModifierUserId)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.PlaceId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Photo", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Photo", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Photo", "CreatorUserId", "dbo.User");
            DropIndex("dbo.Photo", new[] { "TenantId" });
            DropIndex("dbo.Photo", new[] { "LastModifierUserId" });
            DropIndex("dbo.Photo", new[] { "CreatorUserId" });
            DropIndex("dbo.Photo", new[] { "PlaceId" });
            DropTable("dbo.Photo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
