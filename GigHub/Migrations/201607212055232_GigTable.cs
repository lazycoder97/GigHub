namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gernes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artist_Id = c.String(maxLength: 128),
                        Gerne_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Gernes", t => t.Gerne_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Gerne_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Gerne_Id", "dbo.Gernes");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Gerne_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Gernes");
        }
    }
}
