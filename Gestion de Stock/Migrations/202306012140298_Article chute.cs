namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articlechute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleChutes", "idArticle", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "Articlechute", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Articlechute");
            DropColumn("dbo.ArticleChutes", "idArticle");
        }
    }
}
