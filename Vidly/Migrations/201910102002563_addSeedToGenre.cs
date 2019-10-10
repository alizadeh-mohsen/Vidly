namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSeedToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Name) VALUES ('Darama')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Crime')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Thriller')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Animation')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Adventure')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Family')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Horro')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Mystery')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Sci-fi')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Biography')");
            Sql("INSERT INTO GENRES (Name) VALUES ('History')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Romance')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Action')");
        }
        
        public override void Down()
        {
        }
    }
}
