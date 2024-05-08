namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterBondeLivarison : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BondeLivraisons",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Reference = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateBonDeCommande = c.DateTime(nullable: false),
                        Timbre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Currency = c.String(),
                        TVA = c.Int(nullable: false),
                        Total_BonDeCommandeHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_BonDeCommandeTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModePaiment = c.Int(nullable: false),
                        NomChauffeur = c.String(),
                        CinChauffeur = c.String(),
                        Depart = c.String(),
                        Destination = c.String(),
                        Client_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .Index(t => t.Client_Code);
            
            CreateTable(
                "dbo.ligneBonLivraisons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Qty = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TVA = c.Int(nullable: false),
                        BonDeCommande_Code = c.String(maxLength: 128),
                        BondeLivraison_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BonDeSorties", t => t.BonDeCommande_Code)
                .ForeignKey("dbo.BondeLivraisons", t => t.BondeLivraison_Code)
                .Index(t => t.BonDeCommande_Code)
                .Index(t => t.BondeLivraison_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ligneBonLivraisons", "BondeLivraison_Code", "dbo.BondeLivraisons");
            DropForeignKey("dbo.ligneBonLivraisons", "BonDeCommande_Code", "dbo.BonDeSorties");
            DropForeignKey("dbo.BondeLivraisons", "Client_Code", "dbo.Clients");
            DropIndex("dbo.ligneBonLivraisons", new[] { "BondeLivraison_Code" });
            DropIndex("dbo.ligneBonLivraisons", new[] { "BonDeCommande_Code" });
            DropIndex("dbo.BondeLivraisons", new[] { "Client_Code" });
            DropTable("dbo.ligneBonLivraisons");
            DropTable("dbo.BondeLivraisons");
        }
    }
}
