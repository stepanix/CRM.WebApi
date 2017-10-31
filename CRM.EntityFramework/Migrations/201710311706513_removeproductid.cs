namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeproductid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "Product_Id", "dbo.Product");
            DropIndex("dbo.Order", new[] { "Product_Id" });
            DropColumn("dbo.Order", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Product_Id", c => c.Int());
            CreateIndex("dbo.Order", "Product_Id");
            AddForeignKey("dbo.Order", "Product_Id", "dbo.Product", "Id");
        }
    }
}
