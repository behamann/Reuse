namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensagemRemString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagems", "AnuncioID", c => c.Int(nullable: false));
            AddColumn("dbo.Mensagems", "PessoaDes", c => c.String());
            DropColumn("dbo.Mensagems", "PessoaIDDes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagems", "PessoaIDDes", c => c.Int(nullable: false));
            DropColumn("dbo.Mensagems", "PessoaDes");
            DropColumn("dbo.Mensagems", "AnuncioID");
        }
    }
}
