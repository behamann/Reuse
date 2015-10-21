namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images_usuarios3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imagems", "usuario_pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Imagems", "Pessoa_pessoaID", "dbo.Pessoas");
            DropIndex("dbo.Imagems", new[] { "usuario_pessoaID" });
            DropIndex("dbo.Imagems", new[] { "Pessoa_pessoaID" });
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        avatarID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        usuarioID = c.Int(nullable: false),
                        usuario_pessoaID = c.Int(),
                        Pessoa_pessoaID = c.Int(),
                    })
                .PrimaryKey(t => t.avatarID)
                .ForeignKey("dbo.Pessoas", t => t.usuario_pessoaID)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_pessoaID)
                .Index(t => t.usuario_pessoaID)
                .Index(t => t.Pessoa_pessoaID);
            
            DropColumn("dbo.Imagems", "usuarioID");
            DropColumn("dbo.Imagems", "usuario_pessoaID");
            DropColumn("dbo.Imagems", "Pessoa_pessoaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagems", "Pessoa_pessoaID", c => c.Int());
            AddColumn("dbo.Imagems", "usuario_pessoaID", c => c.Int());
            AddColumn("dbo.Imagems", "usuarioID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Avatars", "Pessoa_pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Avatars", "usuario_pessoaID", "dbo.Pessoas");
            DropIndex("dbo.Avatars", new[] { "Pessoa_pessoaID" });
            DropIndex("dbo.Avatars", new[] { "usuario_pessoaID" });
            DropTable("dbo.Avatars");
            CreateIndex("dbo.Imagems", "Pessoa_pessoaID");
            CreateIndex("dbo.Imagems", "usuario_pessoaID");
            AddForeignKey("dbo.Imagems", "Pessoa_pessoaID", "dbo.Pessoas", "pessoaID");
            AddForeignKey("dbo.Imagems", "usuario_pessoaID", "dbo.Pessoas", "pessoaID");
        }
    }
}
