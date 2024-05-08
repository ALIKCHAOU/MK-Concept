using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Gestion_de_Stock.Model;
using System.IO;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraReports.UI;
using Convertisseur;
using Convertisseur.Entite;
using Gestion_de_Stock.Repport;
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeBonDeSortiesSaisieLibre : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmListeBonDeSortiesSaisieLibre _FrmListeBonDeCommande;
        public static FrmListeBonDeSortiesSaisieLibre InstanceFrmListeBonDeCommande
        {
            get
            {
                if (_FrmListeBonDeCommande == null)
                    _FrmListeBonDeCommande = new FrmListeBonDeSortiesSaisieLibre();
                return _FrmListeBonDeCommande;
            }
        }

        public FrmListeBonDeSortiesSaisieLibre()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeBonDeCommande_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeBonDeCommande = null;
        }

        private void FrmListeBonDeCommande_Load(object sender, EventArgs e)
        {
            bonDeCommandeBindingSource.DataSource = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").Where(x=>x.TypeBonDeSortie==TypeBonDeSortie.BonDeSortieSaisieLibre).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void ViewDocument_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BonDeSortie GetBonDeCommandeDB = db.BonDeSorties.Find(CodeBonDeCommande);

            //PDFViewer PDFViewer1;
            //byte[] baPDF; // load the decrypted PDF to this byte array

            //PDFViewer1.LoadDocument(baPDF);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();



            frmViewPdf.pdfViewer1.DetachStreamAfterLoadComplete = true;

        }
        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            frm.Activate();
        }

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            bonDeCommandeBindingSource.DataSource = db.BonDeSorties.Where(x => x.DateBonDeCommande.CompareTo(DateMin) >= 0 && x.DateBonDeCommande.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            bonDeCommandeBindingSource.DataSource = db.BonDeSorties.Where(x => x.DateBonDeCommande.CompareTo(DateMin) >= 0 && x.DateBonDeCommande.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void ImprimerItem_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BonDeSortie GetBonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
            Societe societe = db.Societes.FirstOrDefault();
            BonDeSortieClient RFIpression = new BonDeSortieClient();

            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["MatriculeFiscale"].Value = societe.MatriculFiscal;
            RFIpression.Parameters["Telephone"].Value = societe.Telephone;
            RFIpression.Parameters["NomSociete"].Value = societe.Name;
            RFIpression.Parameters["Email"].Value = societe.Mail;
            RFIpression.Parameters["RIB"].Value = societe.Rib;

            RFIpression.Parameters["Date"].Value = GetBonDeCommandeDB.DateCreation.ToString("dd/MM/yyyy");
            RFIpression.Parameters["CodeBonDeCommande"].Value = GetBonDeCommandeDB.Reference;
            RFIpression.Parameters["NomChauffeur"].Value = GetBonDeCommandeDB.NomChauffeur;
            RFIpression.Parameters["CinChauffeur"].Value = GetBonDeCommandeDB.CinChauffeur;
            RFIpression.Parameters["Depart"].Value = GetBonDeCommandeDB.Depart;
            RFIpression.Parameters["Destination"].Value = GetBonDeCommandeDB.Destination;
            RFIpression.Parameters["MatriculeCamion"].Value = GetBonDeCommandeDB.MatriculeCamion;
            if (GetBonDeCommandeDB.MatriculeClient.ToUpper().Contains("PASSAGER"))
                RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.NomClientPassager +" "+ GetBonDeCommandeDB.PrenomClientPassager;
            else              
                RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.MatriculeClient;

            RFIpression.Parameters["RaisonSocialeClient"].Value = GetBonDeCommandeDB.Client.RaisonSociale;
            RFIpression.DataSource = GetBonDeCommandeDB.ligneBonDeSortie.ToList();
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();

        }

        private void repositoryItemButtonDetaisBonDeCommande_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BonDeSortie GetBonDeCommandeDB = db.BonDeSorties.Find(CodeBonDeCommande);
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsBonDeSorties.InstanceFrmDetaisBonDeCommande);
            if (Application.OpenForms.OfType<FrmDetailsBonDeSorties>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsBonDeSorties>().FirstOrDefault().ligneBonDeCommandeBindingSource.DataSource = GetBonDeCommandeDB.ligneBonDeSortie.ToList();
                GetBonDeCommandeDB = db.BonDeSorties.Include("Client").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
                Application.OpenForms.OfType<FrmDetailsBonDeSorties>().FirstOrDefault().TxtClient.Text = GetBonDeCommandeDB.Client.RaisonSociale;
                Application.OpenForms.OfType<FrmDetailsBonDeSorties>().FirstOrDefault().TxtCodeBonDeCommande.Text = GetBonDeCommandeDB.Code;
            }

        }

        private void BtnCreerFacture_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            int FocusedRowHandle = gridView1.FocusedRowHandle;
            int count = gridView1.SelectedRowsCount;
            // si la ligne n'est pas seléctionner
            if (count == 0)
            {
                XtraMessageBox.Show("Merci de sélectionner une ligne", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                var D = gridView1.GetFocusedRow() as BonDeSortie;
                BonDeSortie BonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(D.Code));





                Vente Vente = new Vente();
                Vente.IntituleClient = BonDeCommandeDB.Client.RaisonSociale;
                Vente.NumClient = BonDeCommandeDB.Client.Code;
                Vente.NomClientPassager = BonDeCommandeDB.NomClientPassager;
                Vente.PrenomClientPassager = BonDeCommandeDB.PrenomClientPassager;
                Vente.TotalHT = BonDeCommandeDB.Total_BonDeCommandeHT;
                Vente.TotalTTC = BonDeCommandeDB.Total_BonDeCommandeTTC;
                Vente.LigneVentes = new List<LigneVente>();
                foreach (var LD in BonDeCommandeDB.ligneBonDeSortie)
                {
                    LigneVente LF = new LigneVente();
                    LF.NomArticle = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                    LF.Metrage = LD.Metrage;
                    LF.Quantity = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Vente.LigneVentes.Add(LF);


                }
                foreach (var L in Vente.LigneVentes)
                {

                    Article Pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.NomArticle));
                    int PackQuantity = Pack.Quantity; // Stock Disponible 

                    int QtyRequired = L.Quantity;
                    if (QtyRequired <= 0)
                    {

                        XtraMessageBox.Show("Quantité Article Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (QtyRequired > PackQuantity && Pack.GereStock)
                    {
                        decimal MissedQty = decimal.Subtract(QtyRequired, PackQuantity);
                        XtraMessageBox.Show("Article  : " + Pack.Designation + " Quantité Manquante :" + MissedQty, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                Vente.MontantRegle = 0m;
                Vente.EtatVente = EtatVente.NonReglee;
                Vente.MontantReglement = Vente.TotalTTC;
                db.Vente.Add(Vente);
                db.SaveChanges();
                Vente.Numero = "V" + (Vente.Id).ToString("D8");
                db.SaveChanges();
             
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.ToList();

                // Mouvement Sortie Vente
                foreach (var L in Vente.LigneVentes)
                {
                    MouvementStockPack mouvementStockPack = new MouvementStockPack();
                    int lastMvtStockPacks = db.MouvementStockPacks.ToList().Count() + 1;

                    mouvementStockPack.Commentaire = "Facture et Vente N°" + " " + Vente.Numero;
                    mouvementStockPack.Intitulé = "Vente";
                    mouvementStockPack.Numero = Vente.Numero;
                    mouvementStockPack.QuantiteProduite = 0;
                    mouvementStockPack.QuantiteVendue = L.Quantity;
                    mouvementStockPack.Sens = SensStock.Sortie;
                    mouvementStockPack.Article = L.NomArticle;
                    Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.NomArticle));
                    mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                    mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial - mouvementStockPack.QuantiteVendue;
                    if(Packdb.GereStock)
                    {
                        Packdb.Quantity = mouvementStockPack.QuantiteStockFinal;
                    }
                    mouvementStockPack.Date = Vente.Date;
                    db.MouvementStockPacks.Add(mouvementStockPack);
                    db.SaveChanges();
                    mouvementStockPack.Code = "SP" + (mouvementStockPack.Id).ToString("D8");
                    db.SaveChanges();
                    if (Packdb.IdArticlechute != 0)
                    { // Supression article chute
                        db.ArticleChutes.Remove(db.ArticleChutes.Find(Packdb.IdArticlechute));
                        db.SaveChanges();
                        // Supression article chute
                        db.Packs.Remove(Packdb);
                        db.SaveChanges();
                    }
                }
                //waiting Form  mise a jour des interfaces 
                //waiting Form  mise a jour des interfaces 

                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.OrderByDescending(x => x.Date).ToList();





                Facture Facture = new Facture();
                Facture.NumeoDocument = BonDeCommandeDB.Code;
                Facture.Client = BonDeCommandeDB.Client;
                Facture.TVA = BonDeCommandeDB.TVA;
                Facture.Total_FactureHT = BonDeCommandeDB.Total_BonDeCommandeHT;
                Facture.Total_FactureTTC = decimal.Add(Facture.Total_FactureHTFODEC, Facture.TOTALTVA);
                Facture.ligneFactures = new List<ligneFacture>();
                foreach (var LD in BonDeCommandeDB.ligneBonDeSortie)
                {
                    ligneFacture LF = new ligneFacture();
                    LF.Description = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                    LF.Qty = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Facture.ligneFactures.Add(LF);


                }
                foreach (var L in Facture.ligneFactures)
                {

                    Article Pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.Description));
                    int PackQuantity = Pack.Quantity;// Stock Disponible 
                    int QtyRequired = L.Qty;
                  

                }

               
                Facture.Client = BonDeCommandeDB.Client;
             


                db.Factures.Add(Facture);
                db.SaveChanges();
                XtraMessageBox.Show("creation Facture terminer avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();

              
                //waiting Form  mise a jour des interfaces 

                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.OrderByDescending(x => x.Date).ToList();

                if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
                }
            }




        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //sélection d'une seule ligne à l'aide de cases à cocher

            GridView view = sender as GridView;
            view.BeginSelection();
            if (e.Action == CollectionChangeAction.Add && view.GetSelectedRows().Length > 1)
                view.ClearSelection();
            if (e.Action == CollectionChangeAction.Refresh)
                view.SelectRow(view.FocusedRowHandle);
            //an additional check
            if (e.Action == CollectionChangeAction.Remove & view.GetSelectedRows().Length == 1)
                view.UnselectRow(view.FocusedRowHandle);
            //      
            view.EndSelection();
        }

        private void BtnVente_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            int FocusedRowHandle = gridView1.FocusedRowHandle;
            int count = gridView1.SelectedRowsCount;
            // si la ligne n'est pas seléctionner
            if (count == 0)
            {
                XtraMessageBox.Show("Merci de sélectionner une ligne", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                var D = gridView1.GetFocusedRow() as BonDeSortie;
                BonDeSortie BonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(D.Code));
                Vente Vente = new Vente();
                Vente.IntituleClient = BonDeCommandeDB.Client.RaisonSociale;
                Vente.NumClient = BonDeCommandeDB.Client.Code;
                Vente.NomClientPassager= BonDeCommandeDB.NomClientPassager;
                Vente.PrenomClientPassager = BonDeCommandeDB.PrenomClientPassager;
                Vente.TotalHT = BonDeCommandeDB.Total_BonDeCommandeHT;
                Vente.TotalTTC = BonDeCommandeDB.Total_BonDeCommandeTTC;
                Vente.LigneVentes = new List<LigneVente>();
                foreach (var LD in BonDeCommandeDB.ligneBonDeSortie)
                {
                    LigneVente LF = new LigneVente();
                    LF.NomArticle = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                    LF.Metrage = LD.Metrage;
                    LF.Quantity = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Vente.LigneVentes.Add(LF);


                }
                foreach (var L in Vente.LigneVentes)
                {

                    Article Pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.NomArticle));
                    int PackQuantity = Pack.Quantity; // Stock Disponible 

                    int QtyRequired = L.Quantity;
                    if (QtyRequired <= 0)
                    {

                        XtraMessageBox.Show("Quantité Article Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (QtyRequired > PackQuantity && Pack.GereStock)
                    {
                        decimal MissedQty = decimal.Subtract(QtyRequired, PackQuantity);
                        XtraMessageBox.Show("Article  : " + Pack.Designation + " Quantité Manquante :" + MissedQty, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                Vente.MontantRegle = 0m;
                Vente.EtatVente = EtatVente.NonReglee;
                Vente.MontantReglement = Vente.TotalTTC;
                db.Vente.Add(Vente);
                db.SaveChanges();
                Vente.Numero = "V" + (Vente.Id).ToString("D8");
                db.SaveChanges();
                XtraMessageBox.Show("creation Vente terminée avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.ToList();

                // Mouvement Sortie Vente
                foreach (var L in Vente.LigneVentes)
                {
                    MouvementStockPack mouvementStockPack = new MouvementStockPack();
                    int lastMvtStockPacks = db.MouvementStockPacks.ToList().Count() + 1;

                    mouvementStockPack.Commentaire = "Vente N°" + " " + Vente.Numero;
                    mouvementStockPack.Intitulé = "Vente";
                    mouvementStockPack.Numero = Vente.Numero;
                    mouvementStockPack.QuantiteProduite = 0;
                    mouvementStockPack.QuantiteVendue = L.Quantity;
                    mouvementStockPack.Sens = SensStock.Sortie;
                    mouvementStockPack.Article = L.NomArticle;
                    Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.NomArticle));
                    mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                    mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial - mouvementStockPack.QuantiteVendue;

                    if(Packdb.GereStock)
                    {
                        Packdb.Quantity = mouvementStockPack.QuantiteStockFinal;
                    }

                    
                    mouvementStockPack.Date = Vente.Date;
                    db.MouvementStockPacks.Add(mouvementStockPack);
                    db.SaveChanges();
                    mouvementStockPack.Code = "SP" + (mouvementStockPack.Id).ToString("D8");
                    db.SaveChanges();
                    if (Packdb.IdArticlechute != 0)
                    { // Supression article chute
                        db.ArticleChutes.Remove(db.ArticleChutes.Find(Packdb.IdArticlechute));
                        db.SaveChanges();
                      // Supression article chute
                        db.Packs.Remove(Packdb);
                        db.SaveChanges();
                    }
                }
                //waiting Form  mise a jour des interfaces 
                //waiting Form  mise a jour des interfaces 

                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.OrderByDescending(x => x.Date).ToList();


                if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
                }

            }
        }

        private void BtnCréerBondeLivraison_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            int FocusedRowHandle = gridView1.FocusedRowHandle;
            int count = gridView1.SelectedRowsCount;
            // si la ligne n'est pas seléctionner
            if (count == 0)
            {
                XtraMessageBox.Show("Merci de sélectionner une ligne", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                var D = gridView1.GetFocusedRow() as BonDeSortie;
                BonDeSortie BonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(D.Code));

                FormshowNotParent(Forms.FrmBSVersBL.InstanceFrmBSVersBL);
                if (Application.OpenForms.OfType<FrmBSVersBL>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmBSVersBL>().First().TxtCodeBondeSortie.Text = BonDeCommandeDB.Code;
                    Application.OpenForms.OfType<FrmBSVersBL>().First().TxtCodeClient.Text = BonDeCommandeDB.Client.Code;
                    Application.OpenForms.OfType<FrmBSVersBL>().First().TxtRsClient.Text = BonDeCommandeDB.Client.RaisonSociale;
                   
                }

               
               
            }
        }

        private void BtnImprimerSansPrix_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BonDeSortie GetBonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
            Societe societe = db.Societes.FirstOrDefault();
            BonDeSortieClientSansPrix RFIpression = new BonDeSortieClientSansPrix();

            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["MatriculeFiscale"].Value = societe.MatriculFiscal;
            RFIpression.Parameters["Telephone"].Value = societe.Telephone;
            RFIpression.Parameters["NomSociete"].Value = societe.Name;
            RFIpression.Parameters["Email"].Value = societe.Mail;
            RFIpression.Parameters["RIB"].Value = societe.Rib;

            RFIpression.Parameters["Date"].Value = GetBonDeCommandeDB.DateCreation.ToString("dd/MM/yyyy");
            RFIpression.Parameters["CodeBonDeCommande"].Value = GetBonDeCommandeDB.Reference;
            RFIpression.Parameters["NomChauffeur"].Value = GetBonDeCommandeDB.NomChauffeur;
            RFIpression.Parameters["CinChauffeur"].Value = GetBonDeCommandeDB.CinChauffeur;
            RFIpression.Parameters["Depart"].Value = GetBonDeCommandeDB.Depart;
            RFIpression.Parameters["Destination"].Value = GetBonDeCommandeDB.Destination;
            RFIpression.Parameters["MatriculeCamion"].Value = GetBonDeCommandeDB.MatriculeCamion;
            if (GetBonDeCommandeDB.MatriculeClient.ToUpper().Contains("PASSAGER"))
                RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.NomClientPassager + " " + GetBonDeCommandeDB.PrenomClientPassager;
            else
                RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.MatriculeClient;

            RFIpression.Parameters["RaisonSocialeClient"].Value = GetBonDeCommandeDB.Client.RaisonSociale;
            RFIpression.DataSource = GetBonDeCommandeDB.ligneBonDeSortie.ToList();
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();
        }
    }
}