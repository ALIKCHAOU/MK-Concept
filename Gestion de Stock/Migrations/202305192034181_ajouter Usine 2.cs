namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterUsine2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LigneProductionUsine2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomArticle = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Poste = c.String(),
                        QteUtiliser = c.Int(nullable: false),
                        QteProduite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LigneProductionUsine2");
        }
    }
}
