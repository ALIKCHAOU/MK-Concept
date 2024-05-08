namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterSalarierPointage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salariers", "MontantPosteJour", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "MontantPosteNuit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "NbrPosteNuit", c => c.Int(nullable: false));
            AddColumn("dbo.Salariers", "NbrPosteJour", c => c.Int(nullable: false));
            AddColumn("dbo.Salariers", "TotalSolde", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "MontantReglé", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "MontantRestReglé", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "EtatSalarie", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salariers", "EtatSalarie");
            DropColumn("dbo.Salariers", "MontantRestReglé");
            DropColumn("dbo.Salariers", "MontantReglé");
            DropColumn("dbo.Salariers", "TotalSolde");
            DropColumn("dbo.Salariers", "NbrPosteJour");
            DropColumn("dbo.Salariers", "NbrPosteNuit");
            DropColumn("dbo.Salariers", "MontantPosteNuit");
            DropColumn("dbo.Salariers", "MontantPosteJour");
        }
    }
}
