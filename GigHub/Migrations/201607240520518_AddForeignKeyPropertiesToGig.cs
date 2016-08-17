namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToGig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Gigs", name: "Gerne_Id", newName: "GerneId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Gerne_Id", newName: "IX_GerneId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_GerneId", newName: "IX_Gerne_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Gigs", name: "GerneId", newName: "Gerne_Id");
            RenameColumn(table: "dbo.Gigs", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
