namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFodekdevisClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devis", "Total_FactureHT", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Devis", "Total_FactureTTC", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devis", "Total_FactureTTC");
            DropColumn("dbo.Devis", "Total_FactureHT");
        }
    }
}
