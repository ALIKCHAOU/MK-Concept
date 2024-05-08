namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterBondeSortie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BondeLivraisons", "MatriculeCamion", c => c.String());
            AddColumn("dbo.BondeLivraisons", "MatriculeClient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BondeLivraisons", "MatriculeClient");
            DropColumn("dbo.BondeLivraisons", "MatriculeCamion");
        }
    }
}
