namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterBondeLivraison : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonDeSorties", "MatriculeCamion", c => c.String());
            AddColumn("dbo.BonDeSorties", "MatriculeClient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BonDeSorties", "MatriculeClient");
            DropColumn("dbo.BonDeSorties", "MatriculeCamion");
        }
    }
}
