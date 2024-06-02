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
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraGrid;

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
            CustomDrawCell(gridControl1, gridView1);
        }
        public static void CustomDrawCell(GridControl gridControl, GridView gridView)
        {
            // Handle this event to paint cells manually
            GridView view = gridView;
            gridView.CustomDrawCell += (s, e) => {
                if (e.Column.VisibleIndex != 4 ) return;
                if (e.Column.VisibleIndex == 4 && e.CellValue != null)
                {
                    DateTime DateExpiration = Convert.ToDateTime(e.CellValue);
                    DateTime Date = DateTime.Now;
                    if ((DateExpiration - Date).TotalDays < 7 && e.CellValue != null)
                    {
                        e.Cache.FillRectangle(Color.Salmon, e.Bounds);
                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds);
                        e.Handled = true;
                    }
                }
       

            };
        }
        private void FrmListeDevis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDevis = null;
        }

        private void FrmListeDevis_Load(object sender, EventArgs e)
        {
            devisBindingSource.DataSource = db.Devis.Include("Client").Include("ligneDevis").OrderByDescending(x => x.DateCreation).ToList();
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
            devisBindingSource.DataSource = db.Devis.Where(x => x.Datelivraison.CompareTo(DateMin) >= 0 && x.Datelivraison.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Datelivraison).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            devisBindingSource.DataSource = db.Devis.Where(x => x.Datelivraison.CompareTo(DateMin) >= 0 && x.Datelivraison.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Datelivraison).ToList();
        }

        private void ImprimerItem_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeDevis = gridView1.GetFocusedRowCellValue("Code").ToString();
            Devis GetDevisDB = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(CodeDevis));
            Societe societe = db.Societes.FirstOrDefault();
            DevisClient RFIpression = new DevisClient();
            RFIpression.Parameters["Date"].Value = GetDevisDB.DateCreation.ToString("dd/MM/yyyy");
            RFIpression.Parameters["DateValiditeDevis"].Value = GetDevisDB.Datelivraison.ToString("dd/MM/yyyy");

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
            Devis GetDevisDB = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(CodeDevis));
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsDevis.InstanceFrmDetaisDevis);
            if (Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().ligneDevisBindingSource.DataSource = GetDevisDB.ligneDevis.ToList();
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().TxtClient.Text = GetDevisDB.Client.RaisonSociale;
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().TxtCodeDevis.Text = GetDevisDB.Code;
                Application.OpenForms.OfType<FrmDetailsDevis>().FirstOrDefault().TxtTvaclient.Text = GetDevisDB.TVA.ToString();

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
            if (string.IsNullOrEmpty(GetDevisDB.Client.Email))
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

     

        private void BtnConvertToVente_Click(object sender, EventArgs e)
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
                Devis devis = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(D.Code));
                Vente Vente = new Vente();
                Vente.IntituleClient = devis.Client.RaisonSociale;
                Vente.NumClient = devis.Client.Code;

                Vente.TotalHT = devis.Total_DevisHT;
                Vente.TotalTTC = devis.Total_DevisTTC;
                Vente.LigneVentes = new List<LigneVente>();
                foreach (var LD in devis.ligneDevis)
                {
                    LigneVente LF = new LigneVente();
                    LF.NomArticle = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                
                    LF.Quantity = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Vente.LigneVentes.Add(LF);

                }
                Vente.MontantRegle = 0m;
                Vente.EtatVente = EtatVente.NonReglee;
                Vente.MontantReglement = Vente.TotalTTC;
                db.Vente.Add(Vente);
                db.SaveChanges();
                Vente.Numero = "V" + (Vente.Id).ToString("D8");
                db.SaveChanges();
                XtraMessageBox.Show("Création Vente terminée avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.ToList();

                // suppression de devis apres la creation du facture
                var DevisDb = db.Devis.Include("ligneDevis").FirstOrDefault(x => x.Code == devis.Code);
                List<ligneDevis> ligneDeviss = new List<ligneDevis>();
                ligneDeviss = DevisDb.ligneDevis.ToList();
                foreach (var Ld in ligneDeviss)
                {
                    ligneDevis lignesDevis = db.ligneDevis.Find(Ld.Id);
                    db.ligneDevis.Remove(lignesDevis);
                    db.SaveChanges();
                }
                db.Devis.Remove(DevisDb);
                db.SaveChanges();
                devisBindingSource.DataSource = db.Devis.OrderByDescending(x => x.DateCreation).ToList();


            }
        }

        private void BtnConvertToFacture_Click(object sender, EventArgs e)
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
                Devis devis = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(D.Code));





                Vente Vente = new Vente();
                Vente.IntituleClient = devis.Client.RaisonSociale;
                Vente.NumClient = devis.Client.Code;

                Vente.TotalHT = devis.Total_DevisHT;
                Vente.TotalTTC = devis.Total_DevisTTC;
                Vente.LigneVentes = new List<LigneVente>();
                foreach (var LD in devis.ligneDevis)
                {
                    LigneVente LF = new LigneVente();
                    LF.NomArticle = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                   
                    LF.Quantity = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = LD.TVA;
                    Vente.LigneVentes.Add(LF);


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


                Facture Facture = new Facture();
                Facture.NumeoDocument = devis.Code;
                Facture.Client = devis.Client;
                Societe societe = db.Societes.FirstOrDefault();

                Facture.TVA = societe != null ? societe.TVA : 19;
                Facture.Total_FactureHT = devis.Total_DevisHT;
                Facture.Total_FactureTTC = decimal.Add(Facture.Total_FactureHT, Facture.TOTALTVA);
                Facture.ligneFactures = new List<ligneFacture>();
                foreach (var LD in devis.ligneDevis)
                {
                    ligneFacture LF = new ligneFacture();
                    LF.Description = LD.Description;
                    LF.PrixHT = LD.PrixHT;
                    LF.Qty = LD.Qty;
                    LF.Remise = LD.Remise;
                    LF.TVA = societe != null ? societe.TVA : 19;
                    Facture.ligneFactures.Add(LF);

                }
                Facture.Client = devis.Client;
                Facture.IdVentes = Vente.Id;
                db.Factures.Add(Facture);
                db.SaveChanges();
       

                // suppression de devis apres la creation du facture
                var DevisDb = db.Devis.Include("ligneDevis").FirstOrDefault(x => x.Code == devis.Code);
                List<ligneDevis> ligneDeviss = new List<ligneDevis>();
                ligneDeviss = DevisDb.ligneDevis.ToList();
                foreach (var Ld in ligneDeviss)
                {
                    ligneDevis lignesDevis = db.ligneDevis.Find(Ld.Id);
                    db.ligneDevis.Remove(lignesDevis);
                    db.SaveChanges();
                }
                db.Devis.Remove(DevisDb);
                db.SaveChanges();
                devisBindingSource.DataSource = db.Devis.OrderByDescending(x => x.DateCreation).ToList();

                XtraMessageBox.Show("Création Facture terminer avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();
            }




        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste des devis.xlsx";

            //Customize export options
            (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            advOptions.SheetName = "Exported from Data Grid";

            gridControl1.ExportToXlsx(path, advOptions);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPdF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void repositoryItemSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Devis C = gridView1.GetFocusedRow() as Devis;
                if (C == null)
                {
                    XtraMessageBox.Show("La Suppression a été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var DevisDb = db.Devis.Include("ligneDevis").FirstOrDefault(x => x.Code == C.Code);
                List<ligneDevis> ligneDeviss = new List<ligneDevis>();
                ligneDeviss = DevisDb.ligneDevis.ToList();
                foreach (var Ld in ligneDeviss)
                {
                    ligneDevis lignesDevis = db.ligneDevis.Find(Ld.Id);
                    db.ligneDevis.Remove(lignesDevis);
                    db.SaveChanges();
                }
                db.Devis.Remove(DevisDb);
                db.SaveChanges();
                devisBindingSource.DataSource = db.Devis.OrderByDescending(x => x.DateCreation).ToList();

                XtraMessageBox.Show("le Devis a été supprimée avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                XtraMessageBox.Show("La Suppression a été annulée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }
    }

}