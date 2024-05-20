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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using System.IO;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmFournisseur _FrmFournisseur;
        public static FrmFournisseur InstanceFrmFournisseur
        {
            get
            {
                if (_FrmFournisseur == null)
                    _FrmFournisseur = new FrmFournisseur();
                return _FrmFournisseur;
            }
        }
        public FrmFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmFournisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmFournisseur = null;
        }

        private void FrmFournisseur_Load(object sender, EventArgs e)
        {
            if (db.Fournisseurs.Count() > 0)
              fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).ToList();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterFournisseur.InstanceFrmAjouterFournisseur);
        }
        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void BtnSupprimerTout_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Fournisseur F = gridView1.GetFocusedRow() as Fournisseur;
                if(F==null)
                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var FournisseurBb = db.Fournisseurs.Find(F.Code);
                FournisseurBb.Status = Status.Bloquer;
                db.SaveChanges();
                /***************************** reload DataGridView ***********************************/
                fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x=>x.Status==Status.Active).ToList();
                /***************************** reload DataGridView  ***********************************/
                XtraMessageBox.Show("le fournisseur a été supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                


            }
            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
  

    

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            Fournisseur F = gridView1.GetFocusedRow() as Fournisseur;
            db = new Model.ApplicationContext();

            if(F!=null)
            { 

            Fournisseur FounisseurDb = db.Fournisseurs.Find(F.Code);
            FormshowNotParent(Forms.FrmModifierFournisseur.InstanceFrmModifierFournisseur);
            if (Application.OpenForms.OfType<FrmModifierFournisseur>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtCode.Text = FounisseurDb.Code;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtRaisonSocial.Text = FounisseurDb.RaisonSociale;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtActivite.Text = FounisseurDb.Activite;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtMatriculeFiscale.Text = FounisseurDb.MatriculeFiscale;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtAdress.Text = FounisseurDb.Adresse;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtVille.Text = FounisseurDb.Ville;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtNom.Text = FounisseurDb.NomResponsable;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtPrenom.Text = FounisseurDb.PrenomResponsable;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtTelephone.Text = FounisseurDb.TelResponsable;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtEmail.Text = FounisseurDb.EmailResponsable;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtFax.Text = FounisseurDb.Fax;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtBanque.Text = FounisseurDb.Banque;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtRiB.Text = FounisseurDb.RIB;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TXTTVA.Text = FounisseurDb.TVA.ToString();
            }

            }
            else
            {
                XtraMessageBox.Show("Acune ligne sélectionnée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void BtnExportXLS_Click(object sender, EventArgs e)
        {
            string path = "Liste Founisseurs.xlsx";

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

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            // Check whether or not the Grid Control can be printed.
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

       

        private void repositoryItemButtonEditViewBattante_Click(object sender, EventArgs e)
        {
            Fournisseur F = gridView1.GetFocusedRow() as Fournisseur;
            Fournisseur FounisseurDb = db.Fournisseurs.Find(F.Code);

            //PDFViewer PDFViewer1;
            //byte[] baPDF; // load the decrypted PDF to this byte array

            //PDFViewer1.LoadDocument(baPDF);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();

            
        }

        private void repositoryItemButtonEditviewAttestationexoneration_Click(object sender, EventArgs e)
        {
            Fournisseur F = gridView1.GetFocusedRow() as Fournisseur;
            Fournisseur FounisseurDb = db.Fournisseurs.Find(F.Code);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();

          
        }

        private void repositoryItemButtonEditViewRegistredecommerce_Click(object sender, EventArgs e)
        {
            Fournisseur F = gridView1.GetFocusedRow() as Fournisseur;
            Fournisseur FounisseurDb = db.Fournisseurs.Find(F.Code);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();

           

        }
    }
}