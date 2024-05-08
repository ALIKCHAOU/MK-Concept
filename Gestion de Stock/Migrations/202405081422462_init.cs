namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        TVA = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        CodeFournisseur = c.String(),
                        RaisonSociale = c.String(),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        Attachment = c.Binary(),
                        EtatAchat = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_AchatHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_AchatTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NFactureFounisseur = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.LigneAchats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomArticle = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 3),
                        unite = c.String(),
                        TVA = c.Int(nullable: false),
                        PrixUnitaire = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Achat_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_id)
                .Index(t => t.Achat_id);
            
            CreateTable(
                "dbo.Alimentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Source = c.Int(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Commentaire = c.String(),
                        Tiers = c.String(),
                        Client_Code = c.String(maxLength: 128),
                        Fournisseur_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_Code)
                .Index(t => t.Client_Code)
                .Index(t => t.Fournisseur_Code);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        RaisonSociale = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Telephone = c.String(),
                        MatriculeFiscale = c.String(),
                        Email = c.String(),
                        FAX = c.String(),
                        Status = c.Int(nullable: false),
                        Activie = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        RaisonSociale = c.String(),
                        Activite = c.String(),
                        MatriculeFiscale = c.String(),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Fax = c.String(),
                        NomResponsable = c.String(),
                        PrenomResponsable = c.String(),
                        TelResponsable = c.String(),
                        EmailResponsable = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Banque = c.String(),
                        RIB = c.String(),
                        FileName_Battante = c.String(),
                        FileSize_Battante = c.Int(nullable: false),
                        Attachment_Battante = c.Binary(),
                        FileName_RC = c.String(),
                        FileSize_RC = c.Int(nullable: false),
                        Attachment_RC = c.Binary(),
                        FileName_Attestation_exonération = c.String(),
                        FileSize__Attestation_exonération = c.Int(nullable: false),
                        Attachment__Attestation_exonération = c.Binary(),
                        Devise = c.String(),
                        TVA = c.Int(nullable: false),
                        Nbrdesfactures = c.Int(nullable: false),
                        TotalPaye = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalCredit = c.Decimal(nullable: false, precision: 18, scale: 3),
                        SommedesFacture = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Code);
            
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
                        Metrage = c.Int(nullable: false),
                        TVA = c.Int(nullable: false),
                        BonDeCommande_Code = c.String(maxLength: 128),
                        BondeLivraison_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BonDeSorties", t => t.BonDeCommande_Code)
                .ForeignKey("dbo.BondeLivraisons", t => t.BondeLivraison_Code)
                .Index(t => t.BonDeCommande_Code)
                .Index(t => t.BondeLivraison_Code);
            
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
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .Index(t => t.Client_Code);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BonDeSorties", t => t.BonDeCommande_Code)
                .Index(t => t.BonDeCommande_Code);
            
            CreateTable(
                "dbo.Caisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MontantTotal = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coffrecheques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumVente = c.String(),
                        NumAchat = c.String(),
                        NomSalarier = c.String(),
                        Frounisseur = c.String(),
                        Client = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NumCheque = c.String(),
                        Banque = c.String(),
                        DateEcheance = c.DateTime(),
                        Commentaire = c.String(),
                        ModePaiment = c.Int(nullable: false),
                        ChequeType = c.Int(nullable: false),
                        Nature = c.Int(nullable: false),
                        StatutVirement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Depenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        Numero = c.String(),
                        Nature = c.Int(nullable: false),
                        CodeFournisseur = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Commentaire = c.String(),
                        ModePaiement = c.String(),
                        Tiers = c.String(),
                        Banque = c.String(),
                        DateEcheance = c.DateTime(),
                        NumCheque = c.String(),
                        CodeTiers = c.String(),
                        NumVente = c.String(),
                        NumAchat = c.String(),
                        NomSalarier = c.String(),
                        Frounisseur = c.String(),
                        DateDepense = c.DateTime(nullable: false),
                        Salarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .Index(t => t.Salarie_Id);
            
            CreateTable(
                "dbo.Salariers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        numero = c.String(),
                        Tel = c.String(),
                        Matricule = c.String(),
                        Solde = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantReglé = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantJournalie = c.Decimal(nullable: false, precision: 18, scale: 3),
                        EtatSalarie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devis",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Reference = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateDevis = c.DateTime(nullable: false),
                        DateValiditeDevis = c.DateTime(nullable: false),
                        Emitteur = c.String(),
                        Timbre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Currency = c.String(),
                        TVA = c.Int(nullable: false),
                        Total_DevisHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_DevisTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        Attachment = c.Binary(),
                        ModePaiment = c.Int(nullable: false),
                        ModaliterPaiment = c.String(),
                        Client_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .Index(t => t.Client_Code);
            
            CreateTable(
                "dbo.ligneDevis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Qty = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                        TVA = c.Int(nullable: false),
                        Devis_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devis", t => t.Devis_Code)
                .Index(t => t.Devis_Code);
            
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Reference = c.String(),
                        NumeoDocument = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateFacture = c.DateTime(nullable: false),
                        TVA = c.Int(nullable: false),
                        Total_FactureHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Total_FactureTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Timbre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Client_Code = c.String(maxLength: 128),
                        Retenue_id = c.Int(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .ForeignKey("dbo.Retenues", t => t.Retenue_id)
                .Index(t => t.Client_Code)
                .Index(t => t.Retenue_id);
            
            CreateTable(
                "dbo.ligneFactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Qty = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TVA = c.Int(nullable: false),
                        Metrage = c.Int(nullable: false),
                        Facture_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factures", t => t.Facture_Code)
                .Index(t => t.Facture_Code);
            
            CreateTable(
                "dbo.Retenues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MatriculeFiscalePayeur = c.String(),
                        RaisonSocialePayeur = c.String(),
                        AdressePayeur = c.String(),
                        Num_Facture = c.String(),
                        Montant_Brut = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Taux = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRetenue = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Montant_Net = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalMontant_Brut = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalMontantRetenue = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalMontant_Net = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MatriculeFiscaleBeneficiaire = c.String(),
                        RaisonSocialePayeurBeneficiaire = c.String(),
                        AdressePayeurBeneficiaire = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HistoriquePaiementAchats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumAchat = c.String(),
                        codeFournisseur = c.String(),
                        IntituleFournisseur = c.String(),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModeReglement = c.Int(nullable: false),
                        NumCheque = c.String(),
                        DateEcheance = c.DateTime(),
                        Banque = c.String(),
                        Coffre = c.Boolean(nullable: false),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoriquePaiementSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        ModeReglement = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NumCheque = c.Int(nullable: false),
                        DateEcheance = c.DateTime(),
                        Bank = c.String(),
                        Coffre = c.Boolean(nullable: false),
                        Salarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .Index(t => t.Salarie_Id);
            
            CreateTable(
                "dbo.HistoriquePaiementVentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumVente = c.String(),
                        IdVente = c.Int(nullable: false),
                        IntituleClient = c.String(),
                        NumClient = c.String(),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModeReglement = c.Int(nullable: false),
                        NumCheque = c.String(),
                        DateEcheance = c.DateTime(),
                        Banque = c.String(),
                        Coffre = c.Boolean(nullable: false),
                        Commentaire = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Production_Id);
            
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
                "dbo.LigneVentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        NomArticle = c.String(),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TVA = c.Int(nullable: false),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Metrage = c.Int(nullable: false),
                        Vente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ventes", t => t.Vente_Id)
                .Index(t => t.Vente_Id);
            
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        IntituleClient = c.String(),
                        NumClient = c.String(),
                        NomClientPassager = c.String(),
                        PrenomClientPassager = c.String(),
                        Date = c.DateTime(nullable: false),
                        EtatVente = c.Int(nullable: false),
                        TotalHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteVendue = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModeReglement = c.Int(nullable: false),
                        MontantRemise = c.Decimal(nullable: false, precision: 18, scale: 3),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productions", t => t.Production_Id)
                .Index(t => t.Production_Id);
            
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
                "dbo.MouvementCaisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Date = c.DateTime(nullable: false),
                        Sens = c.Int(nullable: false),
                        Source = c.String(),
                        Commentaire = c.String(),
                        MontantSens = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Fournisseur = c.String(),
                        CodeTiers = c.String(),
                        Achat_id = c.Int(),
                        Client_Code = c.String(maxLength: 128),
                        Facture_Code = c.String(maxLength: 128),
                        NatureDepense_Id = c.Int(),
                        Salarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_id)
                .ForeignKey("dbo.Clients", t => t.Client_Code)
                .ForeignKey("dbo.Factures", t => t.Facture_Code)
                .ForeignKey("dbo.Depenses", t => t.NatureDepense_Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .Index(t => t.Achat_id)
                .Index(t => t.Client_Code)
                .Index(t => t.Facture_Code)
                .Index(t => t.NatureDepense_Id)
                .Index(t => t.Salarie_Id);
            
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
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Designation = c.String(nullable: false),
                        PrixdeVenteRevendeur = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixdeVenteGros1 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixdeVenteGros2 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixdeVentepublic = c.Decimal(nullable: false, precision: 18, scale: 3),
                        DateCreation = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPoids = c.Decimal(nullable: false, precision: 18, scale: 3),
                        GereStock = c.Boolean(nullable: false),
                        Metrage = c.Int(nullable: false),
                        IdArticlechute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PointageJournaliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Poste = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Salarier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salariers", t => t.Salarier_Id)
                .Index(t => t.Salarier_Id);
            
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
                "dbo.Societes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RaisonSociale = c.String(),
                        Capitale = c.String(),
                        Site = c.String(),
                        CodePostale = c.String(),
                        Adresse = c.String(),
                        Complement = c.String(),
                        MatriculFiscal = c.String(),
                        Activite = c.String(),
                        Telephone = c.String(),
                        Rib = c.String(),
                        Ville = c.String(),
                        Timber = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Mail = c.String(),
                        TVA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListeMatierePermierUtilisers", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.LigneProductions", "Production_Id", "dbo.Productions");
            DropForeignKey("dbo.PointageJournaliers", "Salarier_Id", "dbo.Salariers");
            DropForeignKey("dbo.MouvementCaisses", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.MouvementCaisses", "NatureDepense_Id", "dbo.Depenses");
            DropForeignKey("dbo.MouvementCaisses", "Facture_Code", "dbo.Factures");
            DropForeignKey("dbo.MouvementCaisses", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.MouvementCaisses", "Achat_id", "dbo.Achats");
            DropForeignKey("dbo.LigneVentes", "Vente_Id", "dbo.Ventes");
            DropForeignKey("dbo.HistoriquePaiementSalaries", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.Factures", "Retenue_id", "dbo.Retenues");
            DropForeignKey("dbo.ligneFactures", "Facture_Code", "dbo.Factures");
            DropForeignKey("dbo.Factures", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.ligneDevis", "Devis_Code", "dbo.Devis");
            DropForeignKey("dbo.Devis", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.Depenses", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.ligneBonLivraisons", "BondeLivraison_Code", "dbo.BondeLivraisons");
            DropForeignKey("dbo.ligneBonLivraisons", "BonDeCommande_Code", "dbo.BonDeSorties");
            DropForeignKey("dbo.ligneBonSorties", "BonDeCommande_Code", "dbo.BonDeSorties");
            DropForeignKey("dbo.BonDeSorties", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.BondeLivraisons", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.Alimentations", "Fournisseur_Code", "dbo.Fournisseurs");
            DropForeignKey("dbo.Alimentations", "Client_Code", "dbo.Clients");
            DropForeignKey("dbo.LigneAchats", "Achat_id", "dbo.Achats");
            DropIndex("dbo.PointageJournaliers", new[] { "Salarier_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Salarie_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "NatureDepense_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Facture_Code" });
            DropIndex("dbo.MouvementCaisses", new[] { "Client_Code" });
            DropIndex("dbo.MouvementCaisses", new[] { "Achat_id" });
            DropIndex("dbo.ListeMatierePermierUtilisers", new[] { "Production_Id" });
            DropIndex("dbo.LigneVentes", new[] { "Vente_Id" });
            DropIndex("dbo.LigneProductions", new[] { "Production_Id" });
            DropIndex("dbo.HistoriquePaiementSalaries", new[] { "Salarie_Id" });
            DropIndex("dbo.ligneFactures", new[] { "Facture_Code" });
            DropIndex("dbo.Factures", new[] { "Retenue_id" });
            DropIndex("dbo.Factures", new[] { "Client_Code" });
            DropIndex("dbo.ligneDevis", new[] { "Devis_Code" });
            DropIndex("dbo.Devis", new[] { "Client_Code" });
            DropIndex("dbo.Depenses", new[] { "Salarie_Id" });
            DropIndex("dbo.ligneBonSorties", new[] { "BonDeCommande_Code" });
            DropIndex("dbo.BonDeSorties", new[] { "Client_Code" });
            DropIndex("dbo.ligneBonLivraisons", new[] { "BondeLivraison_Code" });
            DropIndex("dbo.ligneBonLivraisons", new[] { "BonDeCommande_Code" });
            DropIndex("dbo.BondeLivraisons", new[] { "Client_Code" });
            DropIndex("dbo.Alimentations", new[] { "Fournisseur_Code" });
            DropIndex("dbo.Alimentations", new[] { "Client_Code" });
            DropIndex("dbo.LigneAchats", new[] { "Achat_id" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Societes");
            DropTable("dbo.Productions");
            DropTable("dbo.Prelevements");
            DropTable("dbo.PointageJournaliers");
            DropTable("dbo.Articles");
            DropTable("dbo.MouvementStockPacks");
            DropTable("dbo.MouvementStockMatierePremieres");
            DropTable("dbo.MouvementCaisses");
            DropTable("dbo.MatierePremieres");
            DropTable("dbo.ListeMatierePermierUtilisers");
            DropTable("dbo.Ventes");
            DropTable("dbo.LigneVentes");
            DropTable("dbo.LigneProductionUsine2");
            DropTable("dbo.LigneProductions");
            DropTable("dbo.HistoriquePaiementVentes");
            DropTable("dbo.HistoriquePaiementSalaries");
            DropTable("dbo.HistoriquePaiementAchats");
            DropTable("dbo.Retenues");
            DropTable("dbo.ligneFactures");
            DropTable("dbo.Factures");
            DropTable("dbo.ligneDevis");
            DropTable("dbo.Devis");
            DropTable("dbo.Salariers");
            DropTable("dbo.Depenses");
            DropTable("dbo.Coffrecheques");
            DropTable("dbo.Caisses");
            DropTable("dbo.ligneBonSorties");
            DropTable("dbo.BonDeSorties");
            DropTable("dbo.ligneBonLivraisons");
            DropTable("dbo.BondeLivraisons");
            DropTable("dbo.ArticleChutes");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Clients");
            DropTable("dbo.Alimentations");
            DropTable("dbo.LigneAchats");
            DropTable("dbo.Achats");
        }
    }
}
