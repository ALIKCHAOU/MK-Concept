namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterNaturedeponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coffrecheques", "Nature", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coffrecheques", "Nature");
        }
    }
}
