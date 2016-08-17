namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGernesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Gernes (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Gernes (Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO Gernes (Id, Name) VALUES (3, 'Rock')");
            Sql("INSERT INTO Gernes (Id, Name) VALUES (4, 'Country')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Gernes WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
