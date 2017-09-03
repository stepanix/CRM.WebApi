namespace CRM.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class streetAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Place", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Place", "StreetAddress", c => c.String(maxLength: 1000, unicode: false));
        }
    }
}
