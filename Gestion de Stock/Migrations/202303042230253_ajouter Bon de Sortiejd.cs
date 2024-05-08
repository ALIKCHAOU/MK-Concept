namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterBondeSortiejd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coffrecheques", "StatutVirement", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coffrecheques", "StatutVirement");
        }
    }
}
