namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedule", "IsMissed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedule", "IsUnScheduled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedule", "IsUnScheduled");
            DropColumn("dbo.Schedule", "IsMissed");
        }
    }
}
