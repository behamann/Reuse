namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_videos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "anuncioID", "dbo.Anuncios");
            DropIndex("dbo.Videos", new[] { "anuncioID" });
            AddColumn("dbo.Anuncios", "video", c => c.String());
            DropTable("dbo.Videos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        videoID = c.Int(nullable: false, identity: true),
                        link = c.String(),
                        host = c.String(),
                        anuncioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.videoID);
            
            DropColumn("dbo.Anuncios", "video");
            CreateIndex("dbo.Videos", "anuncioID");
            AddForeignKey("dbo.Videos", "anuncioID", "dbo.Anuncios", "anuncioID", cascadeDelete: true);
        }
    }
}
