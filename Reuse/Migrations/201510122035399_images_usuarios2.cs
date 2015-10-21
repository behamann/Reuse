namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images_usuarios2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagems", "usuarioID", c => c.Int(nullable: false));
            AddColumn("dbo.Imagems", "usuario_pessoaID", c => c.Int());
            CreateIndex("dbo.Imagems", "usuario_pessoaID");
            AddForeignKey("dbo.Imagems", "usuario_pessoaID", "dbo.Pessoas", "pessoaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imagems", "usuario_pessoaID", "dbo.Pessoas");
            DropIndex("dbo.Imagems", new[] { "usuario_pessoaID" });
            DropColumn("dbo.Imagems", "usuario_pessoaID");
            DropColumn("dbo.Imagems", "usuarioID");
        }
    }
}
