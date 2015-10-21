namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemSeiOQueMexi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "nome", c => c.String());
            AlterColumn("dbo.Pessoas", "email", c => c.String());
            AlterColumn("dbo.Pessoas", "endereco", c => c.String());
            AlterColumn("dbo.Pessoas", "cep", c => c.String());
            AlterColumn("dbo.Pessoas", "celular", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "celular", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "cep", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "nome", c => c.String(nullable: false));
        }
    }
}
