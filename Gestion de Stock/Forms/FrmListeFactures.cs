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
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Convertisseur;
using Convertisseur.Entite;
using System.IO;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeFactures : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeFactures _FrmListeFactures;
        public static FrmListeFactures InstanceFrmListeFactures
        {
            get
            {
                if (_FrmListeFactures == null)
                    _FrmListeFactures = new FrmListeFactures();
                return _FrmListeFactures;
            }
        }

        public FrmListeFactures()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeFactures_Load(object sender, EventArgs e)
        {
            factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();
        }

        private void FrmListeFactures_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListeFactures = null;
        }

        private void repositoryItemButtoncolCertificateRS_Click(object sender, EventArgs e)
        {
            string CodeFacture = gridView1.GetFocusedRowCellValue("Code").ToString();
            Facture GetFactureDB = db.Factures.Include("Client").Where(x => x.Code.Equals(CodeFacture)).FirstOrDefault();

            if (GetFactureDB.Total_FactureTTC > 1000)
            {
                RapportCertificateRS RFIpression = new RapportCertificateRS();
                Societe Societe = db.Societes.FirstOrDefault();
                List<Retenue> Listretenue = new List<Retenue>();
                Retenue retenue = new Retenue();
                // Organisme Payeur
                retenue.MatriculeFiscalePayeur = Societe.MatriculFiscal;
                retenue.RaisonSocialePayeur = Societe.RaisonSociale;
                retenue.AdressePayeur = Societe.Adresse;
                // Retenue
                retenue.Num_Facture = GetFactureDB.Code;
                retenue.Montant_Brut = GetFactureDB.Total_FactureTTC;
                retenue.TotalMontant_Brut = GetFactureDB.Total_FactureTTC;
                retenue.Taux = 1M;
                retenue.MontantRetenue = Math.Round(Decimal.Divide(GetFactureDB.Total_FactureTTC, 100), 3);
                retenue.Montant_Net = GetFactureDB.Total_FactureHT;
                retenue.TotalMontant_Net = GetFactureDB.Total_FactureHT;

                // Bénéficiaire
                retenue.MatriculeFiscaleBeneficiaire = GetFactureDB.Client.MatriculeFiscale;
                retenue.RaisonSocialePayeurBeneficiaire = GetFactureDB.Client.RaisonSociale;
                retenue.AdressePayeurBeneficiaire = GetFactureDB.Client.Adresse;

                Listretenue.Add(retenue);
                RFIpression.DataSource = Listretenue;
                ReportPrintTool tool = new ReportPrintTool(RFIpression);
                tool.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("La Sommme de cette Facture est inferieur a 1000 ", "Error");
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Factures.xlsx";

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

        private void repositoryLignefacture_Click(object sender, EventArgs e)
        {
            string CodeFacture = gridView1.GetFocusedRowCellValue("Code").ToString();
            Facture GetFactureDB = db.Factures.Find(CodeFacture);
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsFactures.InstanceDetaisFactures);
            if (Application.OpenForms.OfType<FrmDetailsFactures>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsFactures>().FirstOrDefault().ligneFactureBindingSource.DataSource = GetFactureDB.ligneFactures.ToList();


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

        private void repositoryItemButtonEditImprimer_Click(object sender, EventArgs e)
        {
            string CodeFacture = gridView1.GetFocusedRowCellValue("Code").ToString();
            Facture GetFactureDB = db.Factures.Include("Client").Include("ligneFactures").FirstOrDefault(x => x.Code.Equals(CodeFacture));
            Societe societe = db.Societes.FirstOrDefault();
            FactureClient RFIpression = new FactureClient();
            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["MatFiscale"].Value = societe.MatriculFiscal;
            RFIpression.Parameters["Telephone"].Value = societe.Telephone;
            RFIpression.Parameters["NomSociete"].Value = societe.Name;
            RFIpression.Parameters["Email"].Value = societe.Mail;
            RFIpression.Parameters["RIB"].Value = societe.Rib;

            RFIpression.Parameters["Date"].Value = GetFactureDB.DateCreation.ToString("dd/MM/yyyy");
            RFIpression.Parameters["CodeFacture"].Value = GetFactureDB.Reference;
            RFIpression.Parameters["ClientFullName"].Value = GetFactureDB.Client.FullName;
            RFIpression.Parameters["RSClient"].Value = GetFactureDB.Client.RaisonSociale;
            RFIpression.Parameters["AdresseClient"].Value = GetFactureDB.Client.Adresse;
            RFIpression.Parameters["TelephneClient"].Value = GetFactureDB.Client.Telephone;
        
            string Currency = "TND";
            RFIpression.Parameters["TotalFacture"].Value = GetFactureDB.Total_FactureHT + " " + Currency;
            RFIpression.Parameters["FODEC"].Value = GetFactureDB.FODEC + " " + Currency;
            RFIpression.Parameters["Total_FactureHTFODEC"].Value = GetFactureDB.Total_FactureHTFODEC + " " + Currency;
            decimal Timber = db.Societes.FirstOrDefault().Timber;
            RFIpression.Parameters["Timbre"].Value = Timber.ToString() + " " + Currency;
            
            RFIpression.Parameters["TotalFactureTTC"].Value =decimal.Add(GetFactureDB.Total_FactureTTC,Timber) + " " + Currency;
            var convertisseur = ConvertisseurNombreEnLettre.Parametrage
             .AppliquerUneUnite(Unite.Creer("dinar", "dinars", " millime", "millimes"))
             .ModifierLaVirgule("et")
             .ValiderLeParametrage();
            RFIpression.Parameters["TotalEnChiffre"].Value = convertisseur.Convertir(decimal.Add(GetFactureDB.Total_FactureTTC, Timber));
            RFIpression.Parameters["TOTALTVA"].Value = GetFactureDB.TOTALTVA + " " + Currency;
            RFIpression.Parameters["MatriculeFiscale"].Value = GetFactureDB.Client.MatriculeFiscale;
            RFIpression.Parameters["TVA"].Value = societe.TVA + " " + "%";
            RFIpression.DataSource = GetFactureDB.ligneFactures.ToList();
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();

        }

        

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            factureBindingSource.DataSource = db.Factures.Where(x => x.DateFacture.CompareTo(DateMin) >= 0 && x.DateFacture.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            factureBindingSource.DataSource = db.Factures.Where(x => x.DateFacture.CompareTo(DateMin) >= 0 && x.DateFacture.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }
    }
}