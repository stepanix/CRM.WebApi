namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeMileage", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeMileage", "Duration", c => c.Double(nullable: false));
        }
    }
}
