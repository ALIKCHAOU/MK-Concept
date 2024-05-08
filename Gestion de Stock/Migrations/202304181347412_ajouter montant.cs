﻿namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutermontant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointageJournaliers", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointageJournaliers", "Montant");
        }
    }
}