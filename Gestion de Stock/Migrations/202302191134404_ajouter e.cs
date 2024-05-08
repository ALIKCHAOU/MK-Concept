namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutere : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BonDeSorties", "Emitteur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BonDeSorties", "Emitteur", c => c.String());
        }
    }
}
