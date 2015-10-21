namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagens_videos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imagems",
                c => new
                    {
                        imagemID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        anuncioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.imagemID)
                .ForeignKey("dbo.Anuncios", t => t.anuncioID, cascadeDelete: true)
                .Index(t => t.anuncioID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        videoID = c.Int(nullable: false, identity: true),
                        link = c.String(),
                        host = c.String(),
                        anuncioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.videoID)
                .ForeignKey("dbo.Anuncios", t => t.anuncioID, cascadeDelete: true)
                .Index(t => t.anuncioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "anuncioID", "dbo.Anuncios");
            DropForeignKey("dbo.Imagems", "anuncioID", "dbo.Anuncios");
            DropIndex("dbo.Videos", new[] { "anuncioID" });
            DropIndex("dbo.Imagems", new[] { "anuncioID" });
            DropTable("dbo.Videos");
            DropTable("dbo.Imagems");
        }
    }
}
