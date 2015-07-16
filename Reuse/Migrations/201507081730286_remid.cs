namespace Reuse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagems", "RemID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensagems", "RemID");
        }
    }
}
