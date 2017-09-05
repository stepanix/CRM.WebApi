namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitTimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedule", "VisitTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedule", "VisitTime", c => c.DateTime(nullable: false));
        }
    }
}
