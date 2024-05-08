namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterCoffre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coffrecheques", "Depense_Id", "dbo.Depenses");
            DropIndex("dbo.Coffrecheques", new[] { "Depense_Id" });
            DropColumn("dbo.Coffrecheques", "Depense_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coffrecheques", "Depense_Id", c => c.Int());
            CreateIndex("dbo.Coffrecheques", "Depense_Id");
            AddForeignKey("dbo.Coffrecheques", "Depense_Id", "dbo.Depenses", "Id");
        }
    }
}
