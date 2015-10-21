namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        pessoaID = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        email = c.String(nullable: false),
                        endereco = c.String(nullable: false),
                        cep = c.String(nullable: false),
                        bairro = c.String(),
                        cidade = c.String(),
                        estado = c.String(),
                        telefone = c.String(),
                        celular = c.String(nullable: false),
                        itensDoados = c.Int(),
                        itensPedidos = c.Int(),
                        medalha = c.Boolean(),
                    })
                .PrimaryKey(t => t.pessoaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
