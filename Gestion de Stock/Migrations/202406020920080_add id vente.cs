namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addidvente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factures", "IdVentes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factures", "IdVentes");
        }
    }
}
