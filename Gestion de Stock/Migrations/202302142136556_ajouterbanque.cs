namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterbanque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Depenses", "Banque", c => c.String());
            DropColumn("dbo.Depenses", "Bank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Depenses", "Bank", c => c.String());
            DropColumn("dbo.Depenses", "Banque");
        }
    }
}
