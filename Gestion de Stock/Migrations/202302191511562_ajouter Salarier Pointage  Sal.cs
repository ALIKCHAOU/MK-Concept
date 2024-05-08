namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterSalarierPointageSal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointageJournaliers", "Poste", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointageJournaliers", "Poste");
        }
    }
}
