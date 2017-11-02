namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datecreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeMileage", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeMileage", "DateCreated");
        }
    }
}
