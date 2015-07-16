namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncioImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "img");
        }
    }
}
