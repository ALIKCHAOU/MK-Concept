namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterBondeSortiej : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BondeLivraisons", "RaisonSocialeClient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BondeLivraisons", "RaisonSocialeClient");
        }
    }
}
