namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedForMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("update membershiptypes set name='Pay as you go' where Id=1");
            Sql("update membershiptypes set name='Monthly' where Id=2");
            Sql("update membershiptypes set name='Quarterly' where Id=3");
            Sql("update membershiptypes set name='Yearly' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
