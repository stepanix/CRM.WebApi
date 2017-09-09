namespace CRM.EntityFramework.Migrations
{
    
    using System.Collections.Generic;
    
    using System.Data.Entity.Migrations;
    
    public partial class timemileage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeMileage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.Tenant", t => t.TenantId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeMileage", "UserId", "dbo.User");
            DropForeignKey("dbo.TimeMileage", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.TimeMileage", "LastModifierUserId", "dbo.User");
            DropForeignKey("dbo.TimeMileage", "CreatorUserId", "dbo.User");
            DropIndex("dbo.TimeMileage", new[] { "TenantId" });
            DropIndex("dbo.TimeMileage", new[] { "LastModifierUserId" });
            DropIndex("dbo.TimeMileage", new[] { "CreatorUserId" });
            DropIndex("dbo.TimeMileage", new[] { "UserId" });
            DropTable("dbo.TimeMileage",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_IsDeleted", "EntityFramework.Filters.FilterDefinition" },
                });
        }
    }
}
