namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterSalarierPointageSale : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Salariers", "TotalSolde");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salariers", "TotalSolde", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}
