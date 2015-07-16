namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoaBairro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "bairro", c => c.String());
            DropColumn("dbo.Pessoas", "senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoas", "senha", c => c.String());
            DropColumn("dbo.Pessoas", "bairro");
        }
    }
}
