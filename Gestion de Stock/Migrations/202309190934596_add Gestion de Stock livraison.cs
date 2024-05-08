namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGestiondeStocklivraison : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BondeLivraisons", "TypeBonDeLivraison", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BondeLivraisons", "TypeBonDeLivraison");
        }
    }
}
