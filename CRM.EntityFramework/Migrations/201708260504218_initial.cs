namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Form",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500, unicode: false),
                        Description = c.String(maxLength: 2000, unicode: false),
                        Fields = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        FormFieldValues = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Form", t => t.FormId)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .Index(t => t.PlaceId)
                .Index(t => t.FormId);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        StreetAddress = c.String(maxLength: 1000, unicode: false),
                        City = c.String(maxLength: 500, unicode: false),
                        State = c.String(maxLength: 200, unicode: false),
                        Zip = c.String(maxLength: 200, unicode: false),
                        ZipExtension = c.String(maxLength: 200, unicode: false),
                        Country = c.String(maxLength: 200, unicode: false),
                        StatusId = c.Int(),
                        Email = c.String(maxLength: 500, unicode: false),
                        WebSite = c.String(maxLength: 1000, unicode: false),
                        ContactName = c.String(maxLength: 500, unicode: false),
                        ContactTitle = c.String(maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        CellPhone = c.String(maxLength: 200, unicode: false),
                        Comment = c.String(maxLength: 2000, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, unicode: false),
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
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.ProductRetailAudit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        RetailAuditFormId = c.Int(nullable: false),
                        RetailAuditFormFieldValues = c.String(),
                        IsSaved = c.Boolean(nullable: false),
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
                .ForeignKey("dbo.RetailAuditForm", t => t.RetailAuditFormId)
                .Index(t => t.PlaceId)
                .Index(t => t.RetailAuditFormId);
            
            CreateTable(
                "dbo.RetailAuditForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500, unicode: false),
                        Description = c.String(maxLength: 2000, unicode: false),
                        Available = c.Boolean(),
                        Promoted = c.Boolean(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        StockLevel = c.Int(),
                        Note = c.String(maxLength: 2000, unicode: false),
                        Fields = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false, storeType: "date"),
                        VisitTime = c.DateTime(nullable: false),
                        Recurring = c.String(nullable: false, maxLength: 10, unicode: false),
                        VisitNote = c.String(nullable: false, maxLength: 1000, unicode: false),
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
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ProductRetailAudit", "RetailAuditFormId", "dbo.RetailAuditForm");
            DropForeignKey("dbo.ProductRetailAudit", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Note", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.FormValue", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Place", "StatusId", "dbo.Status");
            DropForeignKey("dbo.FormValue", "FormId", "dbo.Form");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Schedule", new[] { "PlaceId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.ProductRetailAudit", new[] { "RetailAuditFormId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "PlaceId" });
            DropIndex("dbo.Note", new[] { "PlaceId" });
            DropIndex("dbo.Place", new[] { "StatusId" });
            DropIndex("dbo.FormValue", new[] { "FormId" });
            DropIndex("dbo.FormValue", new[] { "PlaceId" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Schedule",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.QuestionType",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Product",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.RetailAuditForm",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.ProductRetailAudit",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Note",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Status",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Place",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.FormValue",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Form",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
