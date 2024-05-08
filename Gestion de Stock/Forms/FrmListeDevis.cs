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
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Net.Mime;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeDevis : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmListeDevis _FrmListeDevis;
        public static FrmListeDevis InstanceFrmListeDevis
        {
            get
            {
                if (_FrmListeDevis == null)
                    _FrmListeDevis = new FrmListeDevis();
                return _FrmListeDevis;
            }
        }

        public FrmListeDevis()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeDevis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDevis = null;
        }

        private void FrmListeDevis_Load(object sender, EventArgs e)
        {
            devisBindingSource.DataSource = db.Devis.Include("Client").Include("ligneDevis").OrderByDescending(x => x.DateCreation).ToList();
        }

        private void ViewDocument_Click(object sender, EventArgs e)
        {
            string CodeDevis = gridView1.GetFocusedRowCellValue("Code").ToString();
            Devis GetDevisDB = db.Devis.Find(CodeDevis);

            //PDFViewer PDFViewer1;
            //byte[] baPDF; // load the decrypted PDF to this byte array

            //PDFViewer1.LoadDocument(baPDF);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();

            byte[] byteArray = GetDevisDB.Attachment;

            frmViewPdf.pdfViewer1.DetachStreamAfterLoadComplete = true;
            if (byteArray != null)
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                    frmViewPdf.pdfViewer1.LoadDocument(ms);
            }
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
            devisBindingSource.DataSource = db.Devis.Where(x => x.DateDevis.CompareTo(DateMin) >= 0 && x.DateDevis.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            devisBindingSource.DataSource = db.Devis.Where(x => x.DateDevis.CompareTo(DateMin) >= 0 && x.DateDevis.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void ImprimerItem_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeDevis = gridView1.GetFocusedRowCellValue("Code").ToString();
            Devis GetDevisDB = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(CodeDevis));
            Societe societe = db.Societes.FirstOrDefault();
            DevisClient RFIpression = new DevisClient();
            RFIpression.Parameters["Date"].Value = GetDevisDB.DateCreation.ToString("dd/MM/yyyy");
            RFIpression.Parameters["DateValiditeDevis"].Value = GetDevisDB.DateValiditeDevis.ToString("dd/MM/yyyy");

            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["matFiscal"].Value = societe.MatriculFiscal;
            RFIpression.Parameters["Telephone"].Value = societe.Telephone;
            RFIpression.Parameters["NomSociete"].Value = societe.Name;
            RFIpression.Parameters["Email"].Value = societe.Mail;
            RFIpression.Parameters["RIB"].Value = societe.Rib;

            RFIpression.Parameters["CodeDevis"].Value = GetDevisDB.Reference;
            RFIpression.Parameters["ClientFullName"].Value = GetDevisDB.Client.FullName;
            RFIpression.Parameters["RSClient"].Value = GetDevisDB.Client.RaisonSociale;
            RFIpression.Parameters["AdresseClient"].Value = GetDevisDB.Client.Adresse;
            RFIpression.Parameters["TelephneClient"].Value = GetDevisDB.Client.Telephone;


            string Currency = "TND";
            RFIpression.Parameters["TotalDevis"].Value = GetDevisDB.Total_DevisHT + " " + Currency;
            RFIpression.Parameters["FODEC"].Value = GetDevisDB.FODEC + " " + Currency;
            RFIpression.Parameters["Total_DevisHTFODEC"].Value = GetDevisDB.Total_DevisHTFODEC + " " + Currency;
            decimal Timber = db.Societes.FirstOrDefault().Timber;
            RFIpression.Parameters["Timbre"].Value = Timber.ToString() + " " + Currency;

            RFIpression.Parameters["TotalDevisTTC"].Value = decimal.Add(GetDevisDB.Total_DevisTTC, Timber) + " " + Currency;
            var convertisseur = ConvertisseurNombreEnLettre.Parametrage
             .AppliquerUneUnite(Unite.Creer("dinar", "dinars", " millime", "millimes"))
             .ModifierLaVirgule("et")
             .ValiderLeParametrage();
            RFIpression.Parameters["TotalEnChiffre"].Value = convertisseur.Convertir(decimal.Add(GetDevisDB.Total_DevisTTC, Timber));
            RFIpression.Parameters["TOTALTVA"].Value = GetDevisDB.TOTALTVA + " " + Currency;
            RFIpression.Parameters["MatriculeFiscale"].Value = GetDevisDB.Client.MatriculeFiscale;
            RFIpression.Parameters["TVA"].Value = societe.TVA + " " + "%";
            RFIpression.DataSource = GetDevisDB.ligneDevis.ToList();      
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();

            // Etat de Activiè Caisse
        }

        private void repositoryItemButtonDetaisDevis_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeDevis = gridView1.GetFocusedRowCellValue("Code").ToString();
            Devis GetDevisDB = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x=> x.Code.Equals(CodeDevis));
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsDevis.InstanceFrmDetaisDevis);
            if (Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().ligneDevisBindingSource.DataSource = GetDevisDB.ligneDevis.ToList();                
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().TxtClient.Text = GetDevisDB.Client.RaisonSociale;
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().TxtCodeDevis.Text = GetDevisDB.Code;
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

                var D = gridView1.GetFocusedRow() as Devis;
                Devis DevisDB = db.Devis.Include("ligneDevis").Include("Client").FirstOrDefault(x => x.Code.Equals(D.Code));
                Facture Facture = new Facture();
                Facture.NumeoDocument = DevisDB.Code;
                Facture.Client = DevisDB.Client;
                Facture.TVA = DevisDB.TVA;
                Facture.Total_FactureHT = DevisDB.Total_DevisHT;                    
                Facture.Total_FactureTTC = decimal.Add(Facture.Total_FactureHTFODEC, Facture.TOTALTVA);
                Facture.ligneFactures = new List<ligneFacture>();
                foreach (var LD in DevisDB.ligneDevis)
                {
                    ligneFacture LF = new ligneFacture();
                    LF.Description = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                    LF.Qty = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Facture.ligneFactures.Add(LF);


                }
                // verification  de Qty en stock 
                foreach (var L in Facture.ligneFactures)
                {

                    Article Pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.Description));
                    int PackQuantity = Pack.Quantity; // Stock Disponible 

                    int QtyRequired = L.Qty;
                    if (QtyRequired <= 0)
                    {

                        XtraMessageBox.Show("Quantité Pack Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (QtyRequired > PackQuantity)
                    {
                        decimal MissedQty = decimal.Subtract(QtyRequired, PackQuantity);
                        XtraMessageBox.Show("Pack  : " + Pack.Designation + " Quantité Manquante :" + MissedQty, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
               
                Facture.Client = DevisDB.Client;
               
                db.Factures.Add(Facture);
                db.SaveChanges();
                XtraMessageBox.Show("Creation de Facture a ètè termineè avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                //waiting Form  mise a jour des interfaces 
             
                if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();
                // Mouvement Sortie Vente
                foreach (var L in Facture.ligneFactures)
                {
                    MouvementStockPack mouvementStockPack = new MouvementStockPack();
                    int lastMvtStockPacks = db.MouvementStockPacks.ToList().Count() + 1;

                    mouvementStockPack.Commentaire = "Facture N°" + " " + Facture.Code;
                    mouvementStockPack.Intitulé = "Vente";
                    mouvementStockPack.Numero = Facture.Code;
                    mouvementStockPack.QuantiteProduite = 0;
                    mouvementStockPack.QuantiteVendue = L.Qty;
                    mouvementStockPack.Sens = SensStock.Sortie;
                    mouvementStockPack.Article = L.Description;
                    Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(L.Description));
                    mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                    mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial - mouvementStockPack.QuantiteVendue;
                    Packdb.Quantity = mouvementStockPack.QuantiteStockFinal;
                    mouvementStockPack.Date = Facture.DateCreation;
                    db.MouvementStockPacks.Add(mouvementStockPack);
                    db.SaveChanges();
                    mouvementStockPack.Code = "SP" + (mouvementStockPack.Id).ToString("D8");
                    db.SaveChanges();
                }
                //waiting Form  mise a jour des interfaces 
       

              
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

        private void BtnCreerBonDeCommande_Click(object sender, EventArgs e)
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

                var D = gridView1.GetFocusedRow() as Devis;
                Devis DevisDB = db.Devis.Include("ligneDevis").Include("Client").FirstOrDefault(x => x.Code.Equals(D.Code));
                BonDeSortie BonDeCommande = new BonDeSortie();
              
                BonDeCommande.TVA = DevisDB.TVA;
                BonDeCommande.Total_BonDeCommandeHT = DevisDB.Total_DevisHT;
                BonDeCommande.Total_BonDeCommandeTTC = DevisDB.Total_DevisTTC;
                BonDeCommande.ligneBonDeSortie = new List<ligneBonSortie>();
                foreach (var LD in DevisDB.ligneDevis)
                {
                    ligneBonSortie LBC = new ligneBonSortie();
                    LBC.Description = LD.Description;
                    LBC.PrixHT = LD.PrixHT;
                    LBC.Qty = LD.Qty;
                    LBC.Remise = LD.Remise;
                    LBC.TVA = LD.TVA;
                    BonDeCommande.ligneBonDeSortie.Add(LBC);


                }
                // BonDeCommande.ligneFactures     =DevisDB.ligneDevis

               
                BonDeCommande.Currency = DevisDB.Currency;
                BonDeCommande.Client = DevisDB.Client;
               


                db.BonDeSorties.Add(BonDeCommande);
                db.SaveChanges();
                XtraMessageBox.Show("Creation Bon De Commande terminer avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeBonDeSorties>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeBonDeSorties>().First().bonDeCommandeBindingSource.DataSource = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").OrderByDescending(x => x.DateCreation).ToList();

            }
        }
        public void SendRapport()
        {
            db = new Model.ApplicationContext();
            string FromMail = ConfigurationManager.AppSettings["gmailAccountAddress"];
            string password = ConfigurationManager.AppSettings["gmailAccountPassword"];

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(FromMail, password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

        
            string CodeDevis = gridView1.GetFocusedRowCellValue("Code").ToString();
            Devis GetDevisDB = db.Devis.Include("Client").FirstOrDefault(x => x.Code.Equals(CodeDevis));
            if(string.IsNullOrEmpty(GetDevisDB.Client.Email))
            {
                XtraMessageBox.Show("Email Client est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              
            }

            DevisClient RFIpression = new DevisClient();
            RFIpression.Parameters["Date"].Value = DateTime.Now;
            RFIpression.Parameters["CodeFacture"].Value = GetDevisDB.Reference;
            RFIpression.Parameters["ClientFullName"].Value = GetDevisDB.Client.FullName;
            RFIpression.Parameters["RSClient"].Value = GetDevisDB.Client.RaisonSociale;
            RFIpression.Parameters["AdresseClient"].Value = GetDevisDB.Client.Adresse;
            RFIpression.Parameters["TelephneClient"].Value = GetDevisDB.Client.Telephone;
            string Currency = GetDevisDB.Currency;
            RFIpression.Parameters["TotalFacture"].Value = GetDevisDB.Total_DevisHT + " " + Currency;
            RFIpression.Parameters["TotalFactureTTC"].Value = GetDevisDB.Total_DevisTTC + " " + Currency;
            var convertisseur = ConvertisseurNombreEnLettre.Parametrage
             .AppliquerUneUnite(Unite.Creer("dinar", "dinars", " millime", "millimes"))
             .ModifierLaVirgule("et")
             .ValiderLeParametrage();
            RFIpression.Parameters["TOTALTVA"].Value = GetDevisDB.TOTALTVA + " " + Currency;
            RFIpression.Parameters["TotalEnChiffre"].Value = convertisseur.Convertir(GetDevisDB.Total_DevisTTC);
            RFIpression.Parameters["MatriculeFiscale"].Value = GetDevisDB.Client.MatriculeFiscale;
            RFIpression.Parameters["TVA"].Value = GetDevisDB.TVA + " " + "%";
            RFIpression.DataSource = GetDevisDB.ligneDevis.ToList();
            MailMessage mail = new MailMessage
            {
                Subject = "Vous trouverez ci-joint votre devis N° :" + GetDevisDB.Code,
                Body = "Bonjour,Vous trouverez ci-joint votre devis  N° :" + GetDevisDB.Code,
                IsBodyHtml = true,
                Priority = MailPriority.High,

            };
            mail.From = new MailAddress(FromMail, "Devis ");
            var ListeMail = new List<string>(ConfigurationManager.AppSettings["ListeMail"].Split(new char[] { ';' }));
            foreach (var p in ListeMail)
            {
                mail.To.Add(new MailAddress(p));
            }
            mail.To.Add(new MailAddress(GetDevisDB.Client.Email));
            MemoryStream reportingStream = new MemoryStream();
            RFIpression.ExportToPdf(reportingStream);
            reportingStream.Seek(0, System.IO.SeekOrigin.Begin);
            mail.Attachments.Add(new Attachment(reportingStream, "Devis.pdf", MediaTypeNames.Application.Pdf));
            smtpClient.Send(mail);
            reportingStream.Close();
            reportingStream.Flush();
            XtraMessageBox.Show("Email envoyé avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void repositorySendEmail_Click(object sender, EventArgs e)
        {
            SendRapport();
           
        }

        private void BtnCreerBonDeLivraison_Click(object sender, EventArgs e)
        {

        }
    }
}