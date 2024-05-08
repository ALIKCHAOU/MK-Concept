namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutermerttragelignedeproduction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LigneProductions", "Metrage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LigneProductions", "Metrage");
        }
    }
}
