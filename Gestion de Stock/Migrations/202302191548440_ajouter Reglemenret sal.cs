namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterReglemenretsal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Salariers", "MontantRestReglé");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salariers", "MontantRestReglé", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}
