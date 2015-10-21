namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images_usuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagems", "Pessoa_pessoaID", c => c.Int());
            CreateIndex("dbo.Imagems", "Pessoa_pessoaID");
            AddForeignKey("dbo.Imagems", "Pessoa_pessoaID", "dbo.Pessoas", "pessoaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imagems", "Pessoa_pessoaID", "dbo.Pessoas");
            DropIndex("dbo.Imagems", new[] { "Pessoa_pessoaID" });
            DropColumn("dbo.Imagems", "Pessoa_pessoaID");
        }
    }
}
