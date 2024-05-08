namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventes", "QteVendue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventes", "QteVendue");
        }
    }
}
