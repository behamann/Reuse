namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anuncios", "condicao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Anuncios", "condicao", c => c.String(nullable: false));
        }
    }
}
