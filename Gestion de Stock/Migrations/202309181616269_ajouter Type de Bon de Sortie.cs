namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterTypedeBondeSortie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BonDeSorties", "TypeBonDeSortie", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BonDeSorties", "TypeBonDeSortie");
        }
    }
}
