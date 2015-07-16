namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensagens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(),
                        DataPostada = c.DateTime(nullable: false),
                        PessoaRem = c.String(),
                        PessoaIDDes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MensagemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mensagems");
        }
    }
}
