namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articlechuteid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IdArticle", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "Articlechute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Articlechute", c => c.Boolean(nullable: false));
            DropColumn("dbo.Articles", "IdArticle");
        }
    }
}
