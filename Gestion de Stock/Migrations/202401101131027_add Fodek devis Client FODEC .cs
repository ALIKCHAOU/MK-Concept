namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFodekdevisClientFODEC : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Devis", "Total_FactureHT");
            DropColumn("dbo.Devis", "Total_FactureTTC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devis", "Total_FactureTTC", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Devis", "Total_FactureHT", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}
