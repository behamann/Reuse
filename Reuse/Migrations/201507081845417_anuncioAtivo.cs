namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncioAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "ativo");
        }
    }
}
