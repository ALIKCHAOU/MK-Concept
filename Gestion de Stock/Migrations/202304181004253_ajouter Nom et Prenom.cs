namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterNometPrenom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonDeSorties", "NomClient", c => c.String());
            AddColumn("dbo.BonDeSorties", "PrenomClient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BonDeSorties", "PrenomClient");
            DropColumn("dbo.BonDeSorties", "NomClient");
        }
    }
}
