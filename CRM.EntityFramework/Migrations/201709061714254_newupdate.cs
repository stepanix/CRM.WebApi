namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedule", "VisitNote", c => c.String(maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedule", "VisitNote", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
    }
}
