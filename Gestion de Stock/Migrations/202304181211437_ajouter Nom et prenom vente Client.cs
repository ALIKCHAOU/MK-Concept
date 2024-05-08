namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterNometprenomventeClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventes", "NomClientPassager", c => c.String());
            AddColumn("dbo.Ventes", "PrenomClientPassager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventes", "PrenomClientPassager");
            DropColumn("dbo.Ventes", "NomClientPassager");
        }
    }
}
