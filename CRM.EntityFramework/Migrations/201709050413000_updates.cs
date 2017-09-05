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
            
            AddColumn("dbo.Schedule", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Schedule", "IsRepeat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedule", "RepeatCycle", c => c.Int());
            AddColumn("dbo.Schedule", "IsVisited", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedule", "IsScheduled", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Schedule", "UserId");
            AddForeignKey("dbo.Schedule", "UserId", "dbo.User", "Id");
            DropColumn("dbo.Schedule", "Recurring");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedule", "Recurring", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropForeignKey("dbo.VisitLog", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.VisitLog", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.VisitLog", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.VisitLog", "CreatorUserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "UserId", "dbo.User");
            DropIndex("dbo.VisitLog", new[] { "TenantId" });
            DropIndex("dbo.VisitLog", new[] { "LastModifierUserId" });
            DropIndex("dbo.VisitLog", new[] { "CreatorUserId" });
            DropIndex("dbo.VisitLog", new[] { "ScheduleId" });
            DropIndex("dbo.Schedule", new[] { "UserId" });
            DropColumn("dbo.Schedule", "IsScheduled");
            DropColumn("dbo.Schedule", "IsVisited");
            DropColumn("dbo.Schedule", "RepeatCycle");
            DropColumn("dbo.Schedule", "IsRepeat");
            DropColumn("dbo.Schedule", "UserId");
            DropTable("dbo.VisitLog",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
