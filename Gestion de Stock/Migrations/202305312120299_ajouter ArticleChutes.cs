namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterArticleChutes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleChutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        NomArticle = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Origine = c.String(),
                        Quantite = c.Int(nullable: false),
                        Poids = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleChutes");
        }
    }
}
