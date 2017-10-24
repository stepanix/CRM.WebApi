namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime());
            AlterColumn("dbo.Order", "DueDays", c => c.Int());
            AlterColumn("dbo.Order", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "DueDays", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
