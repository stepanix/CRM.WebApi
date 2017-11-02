namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "EanCode", c => c.String());            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "BarCode", c => c.String());            
        }
    }
}
