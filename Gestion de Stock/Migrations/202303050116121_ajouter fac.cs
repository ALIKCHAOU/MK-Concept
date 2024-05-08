namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterfac : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BonDeSorties", "ModePaiment");
            DropColumn("dbo.Factures", "FileName");
            DropColumn("dbo.Factures", "FileSize");
            DropColumn("dbo.Factures", "Attachment");
            DropColumn("dbo.Factures", "Currency");
            DropColumn("dbo.Factures", "ModePaiment");
            DropColumn("dbo.Factures", "Emitteur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Factures", "Emitteur", c => c.String());
            AddColumn("dbo.Factures", "ModePaiment", c => c.Int(nullable: false));
            AddColumn("dbo.Factures", "Currency", c => c.String());
            AddColumn("dbo.Factures", "Attachment", c => c.Binary());
            AddColumn("dbo.Factures", "FileSize", c => c.Int(nullable: false));
            AddColumn("dbo.Factures", "FileName", c => c.String());
            AddColumn("dbo.BonDeSorties", "ModePaiment", c => c.Int(nullable: false));
        }
    }
}
