namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TVALignedevis : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ligneDevis", "Metrage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ligneDevis", "Metrage", c => c.Int(nullable: false));
        }
    }
}
