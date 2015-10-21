namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reuse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        anuncioID = c.Int(nullable: false, identity: true),
                        pessoaID = c.Int(nullable: false),
                        categoriaID = c.Int(nullable: false),
                        subCategoria = c.String(),
                        condicao = c.String(),
                        titulo = c.String(),
                        descricao = c.String(),
                        img = c.String(),
                        tipo = c.Boolean(nullable: false),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.anuncioID)
                .ForeignKey("dbo.Categorias", t => t.categoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.pessoaID, cascadeDelete: true)
                .Index(t => t.pessoaID)
                .Index(t => t.categoriaID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        categoriaID = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                    })
                .PrimaryKey(t => t.categoriaID);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        tipoID = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                    })
                .PrimaryKey(t => t.tipoID);
            
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        AnuncioID = c.Int(nullable: false),
                        RemID = c.Int(nullable: false),
                        TipoAnuncio = c.String(),
                        Conteudo = c.String(),
                        DataPostada = c.DateTime(nullable: false),
                        PessoaRem = c.String(),
                        PessoaDes = c.String(),
                    })
                .PrimaryKey(t => t.MensagemID);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        subCategoriaID = c.Int(nullable: false, identity: true),
                        categoriaID = c.Int(nullable: false),
                        titulo = c.String(),
                    })
                .PrimaryKey(t => t.subCategoriaID)
                .ForeignKey("dbo.Categorias", t => t.categoriaID, cascadeDelete: true)
                .Index(t => t.categoriaID);
            
            AddColumn("dbo.Pessoas", "nomeContato", c => c.String());
            AddColumn("dbo.Pessoas", "cnpj", c => c.String());
            AddColumn("dbo.Pessoas", "tipoID", c => c.Int());
            AddColumn("dbo.Pessoas", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Pessoas", "tipoID");
            AddForeignKey("dbo.Pessoas", "tipoID", "dbo.Tipoes", "tipoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategorias", "categoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Anuncios", "pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Pessoas", "tipoID", "dbo.Tipoes");
            DropForeignKey("dbo.Anuncios", "categoriaID", "dbo.Categorias");
            DropIndex("dbo.SubCategorias", new[] { "categoriaID" });
            DropIndex("dbo.Pessoas", new[] { "tipoID" });
            DropIndex("dbo.Anuncios", new[] { "categoriaID" });
            DropIndex("dbo.Anuncios", new[] { "pessoaID" });
            DropColumn("dbo.Pessoas", "Discriminator");
            DropColumn("dbo.Pessoas", "tipoID");
            DropColumn("dbo.Pessoas", "cnpj");
            DropColumn("dbo.Pessoas", "nomeContato");
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Mensagems");
            DropTable("dbo.Tipoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Anuncios");
        }
    }
}
