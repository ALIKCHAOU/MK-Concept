namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmetrageLigneBondeSortie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ligneBonLivraisons", "Metrage", c => c.Int(nullable: false));
            AddColumn("dbo.ligneBonSorties", "Metrage", c => c.Int(nullable: false));
            AddColumn("dbo.ligneDevis", "Metrage", c => c.Int(nullable: false));
            AddColumn("dbo.ligneFactures", "Metrage", c => c.Int(nullable: false));
            AddColumn("dbo.LigneVentes", "Metrage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LigneVentes", "Metrage");
            DropColumn("dbo.ligneFactures", "Metrage");
            DropColumn("dbo.ligneDevis", "Metrage");
            DropColumn("dbo.ligneBonSorties", "Metrage");
            DropColumn("dbo.ligneBonLivraisons", "Metrage");
        }
    }
}
