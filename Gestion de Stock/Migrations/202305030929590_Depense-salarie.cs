namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Depensesalarie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Depenses", "DateDepense", c => c.DateTime(nullable: false));
            AddColumn("dbo.Salariers", "MontantJournalie", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salariers", "MontantJournalie");
            DropColumn("dbo.Depenses", "DateDepense");
        }
    }
}
