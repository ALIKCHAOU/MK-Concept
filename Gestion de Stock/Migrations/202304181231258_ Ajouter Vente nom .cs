namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjouterVentenom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonDeSorties", "NomClientPassager", c => c.String());
            AddColumn("dbo.BonDeSorties", "PrenomClientPassager", c => c.String());
            DropColumn("dbo.BonDeSorties", "NomClient");
            DropColumn("dbo.BonDeSorties", "PrenomClient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BonDeSorties", "PrenomClient", c => c.String());
            AddColumn("dbo.BonDeSorties", "NomClient", c => c.String());
            DropColumn("dbo.BonDeSorties", "PrenomClientPassager");
            DropColumn("dbo.BonDeSorties", "NomClientPassager");
        }
    }
}
