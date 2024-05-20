namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listearticles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Prix", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Articles", "Societe_Id", c => c.Int());
            AlterColumn("dbo.Articles", "Code", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "Code");
            CreateIndex("dbo.Articles", "Societe_Id");
            AddForeignKey("dbo.Articles", "Code", "dbo.Fournisseurs", "Code");
            AddForeignKey("dbo.Articles", "Societe_Id", "dbo.Societes", "Id");
            DropColumn("dbo.Fournisseurs", "FileName_Battante");
            DropColumn("dbo.Fournisseurs", "FileSize_Battante");
            DropColumn("dbo.Fournisseurs", "Attachment_Battante");
            DropColumn("dbo.Fournisseurs", "FileName_RC");
            DropColumn("dbo.Fournisseurs", "FileSize_RC");
            DropColumn("dbo.Fournisseurs", "Attachment_RC");
            DropColumn("dbo.Fournisseurs", "FileName_Attestation_exonération");
            DropColumn("dbo.Fournisseurs", "FileSize__Attestation_exonération");
            DropColumn("dbo.Fournisseurs", "Attachment__Attestation_exonération");
            DropColumn("dbo.Articles", "PrixdeVenteRevendeur");
            DropColumn("dbo.Articles", "PrixdeVenteGros1");
            DropColumn("dbo.Articles", "PrixdeVenteGros2");
            DropColumn("dbo.Articles", "PrixdeVentepublic");
            DropColumn("dbo.Articles", "TotalPoids");
            DropColumn("dbo.Articles", "GereStock");
            DropColumn("dbo.Articles", "Metrage");
            DropColumn("dbo.Articles", "IdArticlechute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "IdArticlechute", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "Metrage", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "GereStock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "TotalPoids", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Articles", "PrixdeVentepublic", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Articles", "PrixdeVenteGros2", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Articles", "PrixdeVenteGros1", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Articles", "PrixdeVenteRevendeur", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Fournisseurs", "Attachment__Attestation_exonération", c => c.Binary());
            AddColumn("dbo.Fournisseurs", "FileSize__Attestation_exonération", c => c.Int(nullable: false));
            AddColumn("dbo.Fournisseurs", "FileName_Attestation_exonération", c => c.String());
            AddColumn("dbo.Fournisseurs", "Attachment_RC", c => c.Binary());
            AddColumn("dbo.Fournisseurs", "FileSize_RC", c => c.Int(nullable: false));
            AddColumn("dbo.Fournisseurs", "FileName_RC", c => c.String());
            AddColumn("dbo.Fournisseurs", "Attachment_Battante", c => c.Binary());
            AddColumn("dbo.Fournisseurs", "FileSize_Battante", c => c.Int(nullable: false));
            AddColumn("dbo.Fournisseurs", "FileName_Battante", c => c.String());
            DropForeignKey("dbo.Articles", "Societe_Id", "dbo.Societes");
            DropForeignKey("dbo.Articles", "Code", "dbo.Fournisseurs");
            DropIndex("dbo.Articles", new[] { "Societe_Id" });
            DropIndex("dbo.Articles", new[] { "Code" });
            AlterColumn("dbo.Articles", "Code", c => c.String());
            DropColumn("dbo.Articles", "Societe_Id");
            DropColumn("dbo.Articles", "Prix");
        }
    }
}
