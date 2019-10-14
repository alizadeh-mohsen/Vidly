namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDiscountRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DiscountRate", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DiscountRate");
        }
    }
}
