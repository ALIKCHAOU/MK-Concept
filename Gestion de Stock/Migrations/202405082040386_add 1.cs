namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ArticleChutes");
        }
        
        public override void Down()
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
                        idArticle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
