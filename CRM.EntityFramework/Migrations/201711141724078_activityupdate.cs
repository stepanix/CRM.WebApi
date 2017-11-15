namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activityupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "ActivityContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "ActivityContent");
        }
    }
}
