namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensagens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "Name", c => c.String());
            AddColumn("dbo.Mensagems", "Anuncio_anuncioID", c => c.Int());
            AddColumn("dbo.Mensagems", "Destinatario_pessoaID", c => c.Int());
            AddColumn("dbo.Mensagems", "Remetente_pessoaID", c => c.Int());
            CreateIndex("dbo.Mensagems", "Anuncio_anuncioID");
            CreateIndex("dbo.Mensagems", "Destinatario_pessoaID");
            CreateIndex("dbo.Mensagems", "Remetente_pessoaID");
            AddForeignKey("dbo.Mensagems", "Anuncio_anuncioID", "dbo.Anuncios", "anuncioID");
            AddForeignKey("dbo.Mensagems", "Destinatario_pessoaID", "dbo.Pessoas", "pessoaID");
            AddForeignKey("dbo.Mensagems", "Remetente_pessoaID", "dbo.Pessoas", "pessoaID");
            DropColumn("dbo.Pessoas", "nome");
            DropColumn("dbo.Mensagems", "AnuncioID");
            DropColumn("dbo.Mensagems", "RemID");
            DropColumn("dbo.Mensagems", "TipoAnuncio");
            DropColumn("dbo.Mensagems", "Conteudo");
            DropColumn("dbo.Mensagems", "PessoaRem");
            DropColumn("dbo.Mensagems", "PessoaDes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagems", "PessoaDes", c => c.String());
            AddColumn("dbo.Mensagems", "PessoaRem", c => c.String());
            AddColumn("dbo.Mensagems", "Conteudo", c => c.String());
            AddColumn("dbo.Mensagems", "TipoAnuncio", c => c.String());
            AddColumn("dbo.Mensagems", "RemID", c => c.Int(nullable: false));
            AddColumn("dbo.Mensagems", "AnuncioID", c => c.Int(nullable: false));
            AddColumn("dbo.Pessoas", "nome", c => c.String());
            DropForeignKey("dbo.Mensagems", "Remetente_pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Mensagems", "Destinatario_pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Mensagems", "Anuncio_anuncioID", "dbo.Anuncios");
            DropIndex("dbo.Mensagems", new[] { "Remetente_pessoaID" });
            DropIndex("dbo.Mensagems", new[] { "Destinatario_pessoaID" });
            DropIndex("dbo.Mensagems", new[] { "Anuncio_anuncioID" });
            DropColumn("dbo.Mensagems", "Remetente_pessoaID");
            DropColumn("dbo.Mensagems", "Destinatario_pessoaID");
            DropColumn("dbo.Mensagems", "Anuncio_anuncioID");
            DropColumn("dbo.Pessoas", "Name");
        }
    }
}
