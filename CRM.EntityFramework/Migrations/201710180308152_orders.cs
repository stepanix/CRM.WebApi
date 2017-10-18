namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        DiscountRate = c.Double(nullable: false),
                        DiscountAmount = c.Double(nullable: false),
                        TaxRate = c.Double(nullable: false),
                        TaxAmount = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DueDays = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        signature = c.String(),
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
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PlaceId)
                .Index(t => t.ProductId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            AddColumn("dbo.Product", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Order", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Order", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Order", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Order", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Order", "CreatorUserId", "dbo.User");
            DropIndex("dbo.Order", new[] { "TenantId" });
            DropIndex("dbo.Order", new[] { "LastModifierUserId" });
            DropIndex("dbo.Order", new[] { "CreatorUserId" });
            DropIndex("dbo.Order", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "PlaceId" });
            DropIndex("dbo.Order", new[] { "ScheduleId" });
            DropColumn("dbo.Product", "Price");
            DropTable("dbo.Order",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
