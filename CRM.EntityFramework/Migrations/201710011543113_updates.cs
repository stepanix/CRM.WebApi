namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormValue", "PlaceRepoId", c => c.String());
            AddColumn("dbo.FormValue", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.Place", "RepoId", c => c.String());
            AddColumn("dbo.Schedule", "RepoId", c => c.String());
            AddColumn("dbo.Note", "PlaceRepoId", c => c.String());
            AddColumn("dbo.Note", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.Photo", "PlaceRepoId", c => c.String());
            AddColumn("dbo.Photo", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.ProductRetailAudit", "PlaceRepoId", c => c.String());
            AddColumn("dbo.ProductRetailAudit", "ScheduleRepoId", c => c.String());
            AddColumn("dbo.TimeMileage", "RepoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeMileage", "RepoId");
            DropColumn("dbo.ProductRetailAudit", "ScheduleRepoId");
            DropColumn("dbo.ProductRetailAudit", "PlaceRepoId");
            DropColumn("dbo.Photo", "ScheduleRepoId");
            DropColumn("dbo.Photo", "PlaceRepoId");
            DropColumn("dbo.Note", "ScheduleRepoId");
            DropColumn("dbo.Note", "PlaceRepoId");
            DropColumn("dbo.Schedule", "RepoId");
            DropColumn("dbo.Place", "RepoId");
            DropColumn("dbo.FormValue", "ScheduleRepoId");
            DropColumn("dbo.FormValue", "PlaceRepoId");
        }
    }
}
