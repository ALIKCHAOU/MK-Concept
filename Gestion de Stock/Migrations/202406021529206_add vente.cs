namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvente : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LigneVentes", "Metrage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LigneVentes", "Metrage", c => c.Int(nullable: false));
        }
    }
}
