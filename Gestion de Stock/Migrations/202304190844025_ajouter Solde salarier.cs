namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterSoldesalarier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salariers", "Solde", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.Salariers", "MontantPosteJour");
            DropColumn("dbo.Salariers", "MontantPosteNuit");
            DropColumn("dbo.Salariers", "NbrPosteNuit");
            DropColumn("dbo.Salariers", "NbrPosteJour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salariers", "NbrPosteJour", c => c.Int(nullable: false));
            AddColumn("dbo.Salariers", "NbrPosteNuit", c => c.Int(nullable: false));
            AddColumn("dbo.Salariers", "MontantPosteNuit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "MontantPosteJour", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.Salariers", "Solde");
        }
    }
}
