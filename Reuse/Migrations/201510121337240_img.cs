namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anuncios", "subCategoria", c => c.String(nullable: false));
            AlterColumn("dbo.Anuncios", "condicao", c => c.String(nullable: false));
            AlterColumn("dbo.Anuncios", "titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Anuncios", "descricao", c => c.String(nullable: false));
            DropColumn("dbo.Anuncios", "img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncios", "img", c => c.String());
            AlterColumn("dbo.Anuncios", "descricao", c => c.String());
            AlterColumn("dbo.Anuncios", "titulo", c => c.String());
            AlterColumn("dbo.Anuncios", "condicao", c => c.String());
            AlterColumn("dbo.Anuncios", "subCategoria", c => c.String());
        }
    }
}
