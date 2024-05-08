namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutermegration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Depenses", "NumVente", c => c.String());
            AddColumn("dbo.Depenses", "NumAchat", c => c.String());
            AddColumn("dbo.Depenses", "NomSalarier", c => c.String());
            AddColumn("dbo.Depenses", "Frounisseur", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Depenses", "Frounisseur");
            DropColumn("dbo.Depenses", "NomSalarier");
            DropColumn("dbo.Depenses", "NumAchat");
            DropColumn("dbo.Depenses", "NumVente");
        }
    }
}
