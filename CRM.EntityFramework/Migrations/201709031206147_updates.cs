namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Form", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Form", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Form", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.FormValue", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FormValue", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FormValue", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Place", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Place", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Place", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Status", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Status", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Note", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Note", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Note", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductRetailAudit", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ProductRetailAudit", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ProductRetailAudit", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.RetailAuditForm", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RetailAuditForm", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RetailAuditForm", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Product", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Product", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.RepresentativePlace", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RepresentativePlace", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RepresentativePlace", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedule", "CreatorUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Schedule", "LastModifierUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Schedule", "TenantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Form", "CreatorUserId");
            CreateIndex("dbo.Form", "LastModifierUserId");
            CreateIndex("dbo.Form", "TenantId");
            CreateIndex("dbo.FormValue", "CreatorUserId");
            CreateIndex("dbo.FormValue", "LastModifierUserId");
            CreateIndex("dbo.FormValue", "TenantId");
            CreateIndex("dbo.Place", "CreatorUserId");
            CreateIndex("dbo.Place", "LastModifierUserId");
            CreateIndex("dbo.Place", "TenantId");
            CreateIndex("dbo.Status", "CreatorUserId");
            CreateIndex("dbo.Status", "LastModifierUserId");
            CreateIndex("dbo.Status", "TenantId");
            CreateIndex("dbo.Note", "CreatorUserId");
            CreateIndex("dbo.Note", "LastModifierUserId");
            CreateIndex("dbo.Note", "TenantId");
            CreateIndex("dbo.ProductRetailAudit", "CreatorUserId");
            CreateIndex("dbo.ProductRetailAudit", "LastModifierUserId");
            CreateIndex("dbo.ProductRetailAudit", "TenantId");
            CreateIndex("dbo.RetailAuditForm", "CreatorUserId");
            CreateIndex("dbo.RetailAuditForm", "LastModifierUserId");
            CreateIndex("dbo.RetailAuditForm", "TenantId");
            CreateIndex("dbo.Product", "CreatorUserId");
            CreateIndex("dbo.Product", "LastModifierUserId");
            CreateIndex("dbo.Product", "TenantId");
            CreateIndex("dbo.RepresentativePlace", "CreatorUserId");
            CreateIndex("dbo.RepresentativePlace", "LastModifierUserId");
            CreateIndex("dbo.RepresentativePlace", "TenantId");
            CreateIndex("dbo.Schedule", "CreatorUserId");
            CreateIndex("dbo.Schedule", "LastModifierUserId");
            CreateIndex("dbo.Schedule", "TenantId");
            AddForeignKey("dbo.Form", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Form", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Form", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.FormValue", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.FormValue", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Place", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Place", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Status", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Status", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Status", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.Place", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.FormValue", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.Note", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Note", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Note", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.ProductRetailAudit", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.ProductRetailAudit", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.RetailAuditForm", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.RetailAuditForm", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.RetailAuditForm", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.ProductRetailAudit", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.Product", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Product", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Product", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.RepresentativePlace", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.RepresentativePlace", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.RepresentativePlace", "TenantId", "dbo.Tenant", "Id");
            AddForeignKey("dbo.Schedule", "CreatorUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Schedule", "LastModifierUserId", "dbo.User", "Id");
            AddForeignKey("dbo.Schedule", "TenantId", "dbo.Tenant", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Schedule", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.RepresentativePlace", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.RepresentativePlace", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.RepresentativePlace", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Product", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Product", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Product", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.RetailAuditForm", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.RetailAuditForm", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.RetailAuditForm", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Note", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Note", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Note", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Place", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Status", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Status", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Status", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Place", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Place", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Form", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Form", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Form", "CreatorUserId", "dbo.User");
            DropIndex("dbo.Schedule", new[] { "TenantId" });
            DropIndex("dbo.Schedule", new[] { "LastModifierUserId" });
            DropIndex("dbo.Schedule", new[] { "CreatorUserId" });
            DropIndex("dbo.RepresentativePlace", new[] { "TenantId" });
            DropIndex("dbo.RepresentativePlace", new[] { "LastModifierUserId" });
            DropIndex("dbo.RepresentativePlace", new[] { "CreatorUserId" });
            DropIndex("dbo.Product", new[] { "TenantId" });
            DropIndex("dbo.Product", new[] { "LastModifierUserId" });
            DropIndex("dbo.Product", new[] { "CreatorUserId" });
            DropIndex("dbo.RetailAuditForm", new[] { "TenantId" });
            DropIndex("dbo.RetailAuditForm", new[] { "LastModifierUserId" });
            DropIndex("dbo.RetailAuditForm", new[] { "CreatorUserId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "TenantId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "LastModifierUserId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "CreatorUserId" });
            DropIndex("dbo.Note", new[] { "TenantId" });
            DropIndex("dbo.Note", new[] { "LastModifierUserId" });
            DropIndex("dbo.Note", new[] { "CreatorUserId" });
            DropIndex("dbo.Status", new[] { "TenantId" });
            DropIndex("dbo.Status", new[] { "LastModifierUserId" });
            DropIndex("dbo.Status", new[] { "CreatorUserId" });
            DropIndex("dbo.Place", new[] { "TenantId" });
            DropIndex("dbo.Place", new[] { "LastModifierUserId" });
            DropIndex("dbo.Place", new[] { "CreatorUserId" });
            DropIndex("dbo.FormValue", new[] { "TenantId" });
            DropIndex("dbo.FormValue", new[] { "LastModifierUserId" });
            DropIndex("dbo.FormValue", new[] { "CreatorUserId" });
            DropIndex("dbo.Form", new[] { "TenantId" });
            DropIndex("dbo.Form", new[] { "LastModifierUserId" });
            DropIndex("dbo.Form", new[] { "CreatorUserId" });
            DropColumn("dbo.Schedule", "TenantId");
            DropColumn("dbo.Schedule", "LastModifierUserId");
            DropColumn("dbo.Schedule", "CreatorUserId");
            DropColumn("dbo.User", "IsActive");
            DropColumn("dbo.RepresentativePlace", "TenantId");
            DropColumn("dbo.RepresentativePlace", "LastModifierUserId");
            DropColumn("dbo.RepresentativePlace", "CreatorUserId");
            DropColumn("dbo.Product", "TenantId");
            DropColumn("dbo.Product", "LastModifierUserId");
            DropColumn("dbo.Product", "CreatorUserId");
            DropColumn("dbo.RetailAuditForm", "TenantId");
            DropColumn("dbo.RetailAuditForm", "LastModifierUserId");
            DropColumn("dbo.RetailAuditForm", "CreatorUserId");
            DropColumn("dbo.ProductRetailAudit", "TenantId");
            DropColumn("dbo.ProductRetailAudit", "LastModifierUserId");
            DropColumn("dbo.ProductRetailAudit", "CreatorUserId");
            DropColumn("dbo.Note", "TenantId");
            DropColumn("dbo.Note", "LastModifierUserId");
            DropColumn("dbo.Note", "CreatorUserId");
            DropColumn("dbo.Status", "TenantId");
            DropColumn("dbo.Status", "LastModifierUserId");
            DropColumn("dbo.Status", "CreatorUserId");
            DropColumn("dbo.Place", "TenantId");
            DropColumn("dbo.Place", "LastModifierUserId");
            DropColumn("dbo.Place", "CreatorUserId");
            DropColumn("dbo.FormValue", "TenantId");
            DropColumn("dbo.FormValue", "LastModifierUserId");
            DropColumn("dbo.FormValue", "CreatorUserId");
            DropColumn("dbo.Form", "TenantId");
            DropColumn("dbo.Form", "LastModifierUserId");
            DropColumn("dbo.Form", "CreatorUserId");
            DropTable("dbo.Tenant",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
