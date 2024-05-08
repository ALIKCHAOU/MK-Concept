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
    public partial class FrmListeBonLivraison : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmListeBonLivraison _FrmListeBonDeCommande;
        public static FrmListeBonLivraison InstanceFrmListeBonDeCommande
        {
            get
            {
                if (_FrmListeBonDeCommande == null)
                    _FrmListeBonDeCommande = new FrmListeBonLivraison();
                return _FrmListeBonDeCommande;
            }
        }

        public FrmListeBonLivraison()
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
            bondeLivraisonBindingSource.DataSource = db.BondeLivraisons.Include("Client").Include("ligneBonDeCommande").Where(x => x.TypeBonDeLivraison == TypeBonDeLivraison.NonSaisieLibre).OrderByDescending(x => x.DateCreation).ToList();
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
            bondeLivraisonBindingSource.DataSource = db.BondeLivraisons.Where(x => x.DateBonDeCommande.CompareTo(DateMin) >= 0 && x.DateBonDeCommande.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            bondeLivraisonBindingSource.DataSource = db.BondeLivraisons.Where(x => x.DateBonDeCommande.CompareTo(DateMin) >= 0 && x.DateBonDeCommande.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void ImprimerItem_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BondeLivraison GetBonDeCommandeDB = db.BondeLivraisons.Include("ligneBonDeCommande").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
            Societe societe = db.Societes.FirstOrDefault();
            RapportBondeLivraison RFIpression = new RapportBondeLivraison();

            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["matFiscal"].Value = societe.MatriculFiscal;
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
            RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.MatriculeClient;
            RFIpression.Parameters["RaisonSocialeClient"].Value = GetBonDeCommandeDB.RaisonSocialeClient;



            RFIpression.DataSource = GetBonDeCommandeDB.ligneBonDeCommande.ToList();
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();

        }

        private void repositoryItemButtonDetaisBonDeCommande_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BondeLivraison GetBonDeCommandeDB = db.BondeLivraisons.Find(CodeBonDeCommande);
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsBondeLivraison.InstanceFrmDetaisBonDeCommande);
            if (Application.OpenForms.OfType<FrmDetailsBondeLivraison>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsBondeLivraison>().FirstOrDefault().ligneBonLivraisonBindingSource.DataSource = GetBonDeCommandeDB.ligneBonDeCommande.ToList();
                GetBonDeCommandeDB = db.BondeLivraisons.Include("Client").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
                Application.OpenForms.OfType<FrmDetailsBondeLivraison>().FirstOrDefault().TxtClient.Text = GetBonDeCommandeDB.Client.RaisonSociale;
                Application.OpenForms.OfType<FrmDetailsBondeLivraison>().FirstOrDefault().TxtCodeBonDeCommande.Text = GetBonDeCommandeDB.Code;
            }

        }

        private void BtnImprimerSansPrix_Click(object sender, EventArgs e)
        {
            string CodeBonDeCommande = gridView1.GetFocusedRowCellValue("Code").ToString();
            BondeLivraison GetBonDeCommandeDB = db.BondeLivraisons.Include("ligneBonDeCommande").FirstOrDefault(x => x.Code.Equals(CodeBonDeCommande));
            Societe societe = db.Societes.FirstOrDefault();
            RapportBondeLivraisonSansPrix RFIpression = new RapportBondeLivraisonSansPrix();

            RFIpression.Parameters["Adresse"].Value = societe.Adresse;
            RFIpression.Parameters["CodePostale"].Value = societe.CodePostale;
            RFIpression.Parameters["Complement"].Value = societe.Complement;
            RFIpression.Parameters["Ville"].Value = societe.Ville;
            RFIpression.Parameters["matFiscal"].Value = societe.MatriculFiscal;
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
            RFIpression.Parameters["MatriculeClient"].Value = GetBonDeCommandeDB.MatriculeClient;
            RFIpression.Parameters["RaisonSocialeClient"].Value = GetBonDeCommandeDB.RaisonSocialeClient;



            RFIpression.DataSource = GetBonDeCommandeDB.ligneBonDeCommande.ToList();
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
            tool.ShowPreviewDialog();
        }
    }
}