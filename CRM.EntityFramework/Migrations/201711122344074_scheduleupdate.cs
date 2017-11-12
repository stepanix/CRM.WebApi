namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedule", "CheckInDistance", c => c.Single());
            AddColumn("dbo.Schedule", "CheckOutDistance", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedule", "CheckOutDistance");
            DropColumn("dbo.Schedule", "CheckInDistance");
        }
    }
}
