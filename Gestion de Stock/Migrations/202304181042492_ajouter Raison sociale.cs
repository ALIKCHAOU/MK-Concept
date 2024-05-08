namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterRaisonsociale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonDeSorties", "RaisonSociale", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BonDeSorties", "RaisonSociale");
        }
    }
}
