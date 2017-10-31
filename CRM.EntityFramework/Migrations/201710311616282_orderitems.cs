namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class orderitems : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "ProductId" });
            RenameColumn(table: "dbo.Order", name: "ProductId", newName: "Product_Id");
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
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
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            AlterColumn("dbo.Order", "Product_Id", c => c.Int());
            CreateIndex("dbo.Order", "Product_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.OrderItem", "CreatorUserId", "dbo.User");
            DropIndex("dbo.Order", new[] { "Product_Id" });
            DropIndex("dbo.OrderItem", new[] { "TenantId" });
            DropIndex("dbo.OrderItem", new[] { "LastModifierUserId" });
            DropIndex("dbo.OrderItem", new[] { "CreatorUserId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            AlterColumn("dbo.Order", "Product_Id", c => c.Int(nullable: false));
            DropTable("dbo.OrderItem",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            RenameColumn(table: "dbo.Order", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Order", "ProductId");
        }
    }
}
