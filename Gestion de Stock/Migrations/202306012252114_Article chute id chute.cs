namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articlechuteidchute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IdArticlechute", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "IdArticle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "IdArticle", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "IdArticlechute");
        }
    }
}
