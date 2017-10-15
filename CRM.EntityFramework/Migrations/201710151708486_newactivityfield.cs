namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newactivityfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "DateCreated");
        }
    }
}
