namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateApplication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BondeLivraisons", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.BonDeSorties", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.ligneBonSorties", "BonDeCommande_Code", "dbo.BonDeSorties");
            DropForeignKey("dbo.ligneBonLivraisons", "BonDeCommande_Code", "dbo.BonDeSorties");
            DropForeignKey("dbo.ligneBonLivraisons", "BondeLivraison_Code", "dbo.BondeLivraisons");
            DropForeignKey("dbo.LigneProductions", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.ListeMatierePermierUtilisers", "Production_Id", "dbo.Productions");
            DropIndex("dbo.BondeLivraisons", new[] { "Client_Code" });
            DropIndex("dbo.ligneBonLivraisons", new[] { "BonDeCommande_Code" });
            DropIndex("dbo.ligneBonLivraisons", new[] { "BondeLivraison_Code" });
            DropIndex("dbo.BonDeSorties", new[] { "Client_Code" });
            DropIndex("dbo.ligneBonSorties", new[] { "BonDeCommande_Code" });
            DropIndex("dbo.LigneProductions", new[] { "Production_Id" });
            DropIndex("dbo.ListeMatierePermierUtilisers", new[] { "Production_Id" });
            DropTable("dbo.BondeLivraisons");
            DropTable("dbo.ligneBonLivraisons");
            DropTable("dbo.BonDeSorties");
            DropTable("dbo.ligneBonSorties");
            DropTable("dbo.LigneProductions");
            DropTable("dbo.LigneProductionUsine2");
            DropTable("dbo.ListeMatierePermierUtilisers");
            DropTable("dbo.MatierePremieres");
            DropTable("dbo.MouvementStockMatierePremieres");
            DropTable("dbo.MouvementStockPacks");
            DropTable("dbo.Productions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        QuantiteNonconforme = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalArticle = c.Int(nullable: false),
                        TotalPoids = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MouvementStockPacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Intitulé = c.String(),
                        Article = c.String(),
                        QuantiteProduite = c.Int(nullable: false),
                        QuantiteVendue = c.Int(nullable: false),
                        Sens = c.Int(nullable: false),
                        Commentaire = c.String(),
                        Date = c.DateTime(nullable: false),
                        QuantiteStockInitial = c.Int(nullable: false),
                        QuantiteStockFinal = c.Int(nullable: false),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MouvementStockMatierePremieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Intitulé = c.String(),
                        Article = c.String(),
                        QuantiteAchetee = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QuantiteUtilisee = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Sens = c.Int(nullable: false),
                        Commentaire = c.String(),
                        Date = c.DateTime(nullable: false),
                        QuantiteStockInitial = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QuantiteStockFinal = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixMouvement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PMP = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatierePremieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Nom = c.String(nullable: false),
                        Description = c.String(),
                        Unite = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 3),
                        DernierPirxAchat = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixMoyen = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListeMatierePermierUtilisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Code = c.String(),
                        Nom = c.String(nullable: false),
                        Quantite = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Production_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneProductionUsine2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomArticle = c.String(),
                        NomArticleFini = c.String(),
                        code = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Poste = c.String(),
                        QteUtiliser = c.Int(nullable: false),
                        QteProduite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneProductions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomArticle = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Poste = c.String(),
                        Chaine = c.String(),
                        Quantite = c.Int(nullable: false),
                        Poids = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                        Production_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ligneBonSorties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Qty = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                        TVA = c.Int(nullable: false),
                        BonDeCommande_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BonDeSorties",
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
                        NomClientPassager = c.String(),
                        PrenomClientPassager = c.String(),
                        RaisonSociale = c.String(),
                        NomChauffeur = c.String(),
                        CinChauffeur = c.String(),
                        MatriculeCamion = c.String(),
                        MatriculeClient = c.String(),
                        Depart = c.String(),
                        Destination = c.String(),
                        TypeBonDeSortie = c.Int(nullable: false),
                        Client_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ligneBonLivraisons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Qty = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                        TVA = c.Int(nullable: false),
                        BonDeCommande_Code = c.String(maxLength: 128),
                        BondeLivraison_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BondeLivraisons",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Reference = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateBonDeCommande = c.DateTime(nullable: false),
                        TypeBonDeLivraison = c.Int(nullable: false),
                        Timbre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Currency = c.String(),
                        TVA = c.Int(nullable: false),
                        Total_BonDeCommandeHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_BonDeCommandeTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModePaiment = c.Int(nullable: false),
                        NomChauffeur = c.String(),
                        CinChauffeur = c.String(),
                        MatriculeCamion = c.String(),
                        MatriculeClient = c.String(),
                        RaisonSocialeClient = c.String(),
                        Depart = c.String(),
                        Destination = c.String(),
                        Client_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateIndex("dbo.ListeMatierePermierUtilisers", "Production_Id");
            CreateIndex("dbo.LigneProductions", "Production_Id");
            CreateIndex("dbo.ligneBonSorties", "BonDeCommande_Code");
            CreateIndex("dbo.BonDeSorties", "Client_Code");
            CreateIndex("dbo.ligneBonLivraisons", "BondeLivraison_Code");
            CreateIndex("dbo.ligneBonLivraisons", "BonDeCommande_Code");
            CreateIndex("dbo.BondeLivraisons", "Client_Code");
            AddForeignKey("dbo.ListeMatierePermierUtilisers", "Production_Id", "dbo.Productions", "Id");
            AddForeignKey("dbo.LigneProductions", "Production_Id", "dbo.Productions", "Id");
            AddForeignKey("dbo.ligneBonLivraisons", "BondeLivraison_Code", "dbo.BondeLivraisons", "Code");
            AddForeignKey("dbo.ligneBonLivraisons", "BonDeCommande_Code", "dbo.BonDeSorties", "Code");
            AddForeignKey("dbo.ligneBonSorties", "BonDeCommande_Code", "dbo.BonDeSorties", "Code");
            AddForeignKey("dbo.BonDeSorties", "Client_Code", "dbo.Clients", "Code");
            AddForeignKey("dbo.BondeLivraisons", "Client_Code", "dbo.Clients", "Code");
        }
    }
}
