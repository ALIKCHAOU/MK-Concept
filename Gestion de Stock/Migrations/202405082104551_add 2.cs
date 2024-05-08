namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Prelevements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prelevements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Num = c.String(),
                        Date = c.DateTime(nullable: false),
                        Banque = c.String(),
                        Commentaire = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
