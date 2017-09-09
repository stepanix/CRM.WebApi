namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormValue", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.Note", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.Photo", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductRetailAudit", "ScheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.FormValue", "ScheduleId");
            CreateIndex("dbo.Note", "ScheduleId");
            CreateIndex("dbo.Photo", "ScheduleId");
            CreateIndex("dbo.ProductRetailAudit", "ScheduleId");
            AddForeignKey("dbo.FormValue", "ScheduleId", "dbo.Schedule", "Id");
            AddForeignKey("dbo.Note", "ScheduleId", "dbo.Schedule", "Id");
            AddForeignKey("dbo.Photo", "ScheduleId", "dbo.Schedule", "Id");
            AddForeignKey("dbo.ProductRetailAudit", "ScheduleId", "dbo.Schedule", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRetailAudit", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Photo", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Note", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.FormValue", "ScheduleId", "dbo.Schedule");
            DropIndex("dbo.ProductRetailAudit", new[] { "ScheduleId" });
            DropIndex("dbo.Photo", new[] { "ScheduleId" });
            DropIndex("dbo.Note", new[] { "ScheduleId" });
            DropIndex("dbo.FormValue", new[] { "ScheduleId" });
            DropColumn("dbo.ProductRetailAudit", "ScheduleId");
            DropColumn("dbo.Photo", "ScheduleId");
            DropColumn("dbo.Note", "ScheduleId");
            DropColumn("dbo.FormValue", "ScheduleId");
        }
    }
}
