namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        Surname = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TenantId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.TenantId)
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
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Address = c.String(maxLength: 2000, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 500, unicode: false),
                        WebSite = c.String(maxLength: 500, unicode: false),
                        ContactPerson = c.String(maxLength: 500, unicode: false),
                        ContactNumber = c.String(maxLength: 500, unicode: false),
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
                        ScheduleId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        FormFieldValues = c.String(),
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
                .ForeignKey("dbo.Form", t => t.FormId)
                .ForeignKey("dbo.User", t => t.LastModifierUserId)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PlaceId)
                .Index(t => t.FormId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        StreetAddress = c.String(),
                        StatusId = c.Int(),
                        Email = c.String(maxLength: 500, unicode: false),
                        WebSite = c.String(maxLength: 1000, unicode: false),
                        ContactName = c.String(maxLength: 500, unicode: false),
                        ContactTitle = c.String(maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        CellPhone = c.String(maxLength: 200, unicode: false),
                        Comment = c.String(maxLength: 2000, unicode: false),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        Longitude = c.Decimal(precision: 18, scale: 2),
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
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.StatusId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        VisitDate = c.DateTime(nullable: false, storeType: "date"),
                        VisitTime = c.DateTime(),
                        VisitNote = c.String(maxLength: 1000, unicode: false),
                        CreatorUserId = c.String(nullable: false, maxLength: 128),
                        LastModifierUserId = c.String(nullable: false, maxLength: 128),
                        TenantId = c.Int(nullable: false),
                        IsRepeat = c.Boolean(nullable: false),
                        RepeatCycle = c.Int(),
                        IsVisited = c.Boolean(nullable: false),
                        IsScheduled = c.Boolean(nullable: false),
                        IsMissed = c.Boolean(nullable: false),
                        IsUnScheduled = c.Boolean(nullable: false),
                        VisitStatus = c.String(maxLength: 10, unicode: false),
                        CheckInTime = c.DateTime(),
                        CheckOutTime = c.DateTime(),
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
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.UserId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, unicode: false),
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
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PlaceId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PlaceId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.ProductRetailAudit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        RetailAuditFormId = c.Int(nullable: false),
                        RetailAuditFormFieldValues = c.String(),
                        IsSaved = c.Boolean(nullable: false),
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
                .ForeignKey("dbo.RetailAuditForm", t => t.RetailAuditFormId)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PlaceId)
                .Index(t => t.RetailAuditFormId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.RetailAuditForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500, unicode: false),
                        Description = c.String(maxLength: 2000, unicode: false),
                        Available = c.Boolean(),
                        Promoted = c.Boolean(),
                        Price = c.Boolean(),
                        StockLevel = c.Boolean(),
                        Note = c.Boolean(),
                        Fields = c.String(),
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500, unicode: false),
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
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
                "dbo.RepresentativePlace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
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
                "dbo.TimeMileage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PlaceId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        Duration = c.Double(nullable: false),
                        Mileage = c.Double(nullable: false),
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
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.VisitLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
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
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .Index(t => t.ScheduleId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitLog", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.VisitLog", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.VisitLog", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.VisitLog", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.TimeMileage", "UserId", "dbo.User");
            DropForeignKey("dbo.TimeMileage", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.TimeMileage", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.TimeMileage", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.TimeMileage", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RepresentativePlace", "UserId", "dbo.User");
            DropForeignKey("dbo.RepresentativePlace", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.RepresentativePlace", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.RepresentativePlace", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.RepresentativePlace", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Product", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Product", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Product", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.ProductRetailAudit", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.ProductRetailAudit", "RetailAuditFormId", "dbo.RetailAuditForm");
            DropForeignKey("dbo.RetailAuditForm", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.RetailAuditForm", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.RetailAuditForm", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.ProductRetailAudit", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.ProductRetailAudit", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Photo", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Photo", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Photo", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Photo", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Photo", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Note", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Note", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Note", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Note", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Note", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.FormValue", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Schedule", "UserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Schedule", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Schedule", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Place", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Place", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Status", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Status", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Status", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Place", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Place", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.FormValue", "FormId", "dbo.Form");
            DropForeignKey("dbo.FormValue", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Form", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.Form", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.Form", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.User", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropIndex("dbo.VisitLog", new[] { "TenantId" });
            DropIndex("dbo.VisitLog", new[] { "LastModifierUserId" });
            DropIndex("dbo.VisitLog", new[] { "CreatorUserId" });
            DropIndex("dbo.VisitLog", new[] { "ScheduleId" });
            DropIndex("dbo.TimeMileage", new[] { "TenantId" });
            DropIndex("dbo.TimeMileage", new[] { "LastModifierUserId" });
            DropIndex("dbo.TimeMileage", new[] { "CreatorUserId" });
            DropIndex("dbo.TimeMileage", new[] { "PlaceId" });
            DropIndex("dbo.TimeMileage", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.RepresentativePlace", new[] { "TenantId" });
            DropIndex("dbo.RepresentativePlace", new[] { "LastModifierUserId" });
            DropIndex("dbo.RepresentativePlace", new[] { "CreatorUserId" });
            DropIndex("dbo.RepresentativePlace", new[] { "PlaceId" });
            DropIndex("dbo.RepresentativePlace", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "TenantId" });
            DropIndex("dbo.Product", new[] { "LastModifierUserId" });
            DropIndex("dbo.Product", new[] { "CreatorUserId" });
            DropIndex("dbo.RetailAuditForm", new[] { "TenantId" });
            DropIndex("dbo.RetailAuditForm", new[] { "LastModifierUserId" });
            DropIndex("dbo.RetailAuditForm", new[] { "CreatorUserId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "TenantId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "LastModifierUserId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "CreatorUserId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "RetailAuditFormId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "PlaceId" });
            DropIndex("dbo.ProductRetailAudit", new[] { "ScheduleId" });
            DropIndex("dbo.Photo", new[] { "TenantId" });
            DropIndex("dbo.Photo", new[] { "LastModifierUserId" });
            DropIndex("dbo.Photo", new[] { "CreatorUserId" });
            DropIndex("dbo.Photo", new[] { "PlaceId" });
            DropIndex("dbo.Photo", new[] { "ScheduleId" });
            DropIndex("dbo.Note", new[] { "TenantId" });
            DropIndex("dbo.Note", new[] { "LastModifierUserId" });
            DropIndex("dbo.Note", new[] { "CreatorUserId" });
            DropIndex("dbo.Note", new[] { "PlaceId" });
            DropIndex("dbo.Note", new[] { "ScheduleId" });
            DropIndex("dbo.Schedule", new[] { "TenantId" });
            DropIndex("dbo.Schedule", new[] { "LastModifierUserId" });
            DropIndex("dbo.Schedule", new[] { "CreatorUserId" });
            DropIndex("dbo.Schedule", new[] { "UserId" });
            DropIndex("dbo.Schedule", new[] { "PlaceId" });
            DropIndex("dbo.Status", new[] { "TenantId" });
            DropIndex("dbo.Status", new[] { "LastModifierUserId" });
            DropIndex("dbo.Status", new[] { "CreatorUserId" });
            DropIndex("dbo.Place", new[] { "TenantId" });
            DropIndex("dbo.Place", new[] { "LastModifierUserId" });
            DropIndex("dbo.Place", new[] { "CreatorUserId" });
            DropIndex("dbo.Place", new[] { "StatusId" });
            DropIndex("dbo.FormValue", new[] { "TenantId" });
            DropIndex("dbo.FormValue", new[] { "LastModifierUserId" });
            DropIndex("dbo.FormValue", new[] { "CreatorUserId" });
            DropIndex("dbo.FormValue", new[] { "FormId" });
            DropIndex("dbo.FormValue", new[] { "PlaceId" });
            DropIndex("dbo.FormValue", new[] { "ScheduleId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "TenantId" });
            DropIndex("dbo.Form", new[] { "TenantId" });
            DropIndex("dbo.Form", new[] { "LastModifierUserId" });
            DropIndex("dbo.Form", new[] { "CreatorUserId" });
            DropTable("dbo.VisitLog",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.TimeMileage",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Role");
            DropTable("dbo.RepresentativePlace",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
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
            DropTable("dbo.Photo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Note",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.Schedule",
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
            DropTable("dbo.Tenant",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Form",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
