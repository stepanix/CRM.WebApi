namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedule", "VisitStatus", c => c.String());
            AddColumn("dbo.Schedule", "CheckInTime", c => c.DateTime());
            AddColumn("dbo.Schedule", "CheckOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedule", "CheckOutTime");
            DropColumn("dbo.Schedule", "CheckInTime");
            DropColumn("dbo.Schedule", "VisitStatus");
        }
    }
}
