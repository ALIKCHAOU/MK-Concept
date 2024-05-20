namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateDatelivraison : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devis", "Datelivraison", c => c.DateTime(nullable: false));
            DropColumn("dbo.Devis", "DateValiditeDevis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devis", "DateValiditeDevis", c => c.DateTime(nullable: false));
            DropColumn("dbo.Devis", "Datelivraison");
        }
    }
}
