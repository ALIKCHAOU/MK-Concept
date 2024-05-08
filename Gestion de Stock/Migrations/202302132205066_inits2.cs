namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inits2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Achats", "Retenue_id", "dbo.Retenues");
            DropIndex("dbo.Achats", new[] { "Retenue_id" });
            DropColumn("dbo.Achats", "Retenue_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achats", "Retenue_id", c => c.Int());
            CreateIndex("dbo.Achats", "Retenue_id");
            AddForeignKey("dbo.Achats", "Retenue_id", "dbo.Retenues", "id");
        }
    }
}
