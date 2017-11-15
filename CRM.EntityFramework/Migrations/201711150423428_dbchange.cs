namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "ActivityTypeId", c => c.String());
            AddColumn("dbo.FormValue", "RepoId", c => c.String());
            AddColumn("dbo.Note", "RepoId", c => c.String());
            AddColumn("dbo.OrderItem", "RepoId", c => c.String());
            AddColumn("dbo.Photo", "RepoId", c => c.String());
            AddColumn("dbo.ProductRetailAudit", "RepoId", c => c.String());
            DropColumn("dbo.Activity", "ActivityContent");
            DropColumn("dbo.FormValue", "PlaceRepoId");
            DropColumn("dbo.FormValue", "ScheduleRepoId");
            DropColumn("dbo.Note", "PlaceRepoId");
            DropColumn("dbo.Note", "ScheduleRepoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.Note", "PlaceRepoId", c => c.String());
            AddColumn("dbo.FormValue", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.FormValue", "PlaceRepoId", c => c.String());
            AddColumn("dbo.Activity", "ActivityContent", c => c.String());
            DropColumn("dbo.ProductRetailAudit", "RepoId");
            DropColumn("dbo.Photo", "RepoId");
            DropColumn("dbo.OrderItem", "RepoId");
            DropColumn("dbo.Note", "RepoId");
            DropColumn("dbo.FormValue", "RepoId");
            DropColumn("dbo.Activity", "ActivityTypeId");
        }
    }
}
