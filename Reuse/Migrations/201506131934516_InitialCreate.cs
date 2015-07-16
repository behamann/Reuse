namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        tipo = c.Boolean(nullable: false),
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
                "dbo.Pessoas",
                c => new
                    {
                        pessoaID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        email = c.String(),
                        senha = c.String(),
                        endereco = c.String(),
                        cep = c.String(),
                        cidade = c.String(),
                        estado = c.String(),
                        telefone = c.String(),
                        celular = c.String(),
                        nomeContato = c.String(),
                        cnpj = c.String(),
                        tipoID = c.Int(),
                        itensDoados = c.Int(),
                        itensPedidos = c.Int(),
                        medalha = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.pessoaID)
                .ForeignKey("dbo.Tipoes", t => t.tipoID, cascadeDelete: true)
                .Index(t => t.tipoID);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        tipoID = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                    })
                .PrimaryKey(t => t.tipoID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategorias", "categoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Pessoas", "tipoID", "dbo.Tipoes");
            DropForeignKey("dbo.Anuncios", "pessoaID", "dbo.Pessoas");
            DropForeignKey("dbo.Anuncios", "categoriaID", "dbo.Categorias");
            DropIndex("dbo.SubCategorias", new[] { "categoriaID" });
            DropIndex("dbo.Pessoas", new[] { "tipoID" });
            DropIndex("dbo.Anuncios", new[] { "categoriaID" });
            DropIndex("dbo.Anuncios", new[] { "pessoaID" });
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Tipoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Categorias");
            DropTable("dbo.Anuncios");
        }
    }
}
