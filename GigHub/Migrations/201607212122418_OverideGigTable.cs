namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverideGigTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Gerne_Id", "dbo.Gernes");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropIndex("dbo.Gigs", new[] { "Gerne_Id" });
            AlterColumn("dbo.Gernes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "Gerne_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "Artist_Id");
            CreateIndex("dbo.Gigs", "Gerne_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "Gerne_Id", "dbo.Gernes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Gerne_Id", "dbo.Gernes");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Gerne_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.Gigs", "Gerne_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Gernes", "Name", c => c.String());
            CreateIndex("dbo.Gigs", "Gerne_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Gerne_Id", "dbo.Gernes", "Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
