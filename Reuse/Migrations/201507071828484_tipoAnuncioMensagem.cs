namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoAnuncioMensagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagems", "TipoAnuncio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensagems", "TipoAnuncio");
        }
    }
}
