using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using Gestion_de_Stock.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmClient _FrmClient;
        public static FrmClient InstanceFrmClient
        {
            get
            {
                if (_FrmClient == null)
                {
                    _FrmClient = new FrmClient();
                }

                return _FrmClient;
            }
        }
        public FrmClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {

            if (db.Clients.Count() > 0)
            {
                //   clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).OrderBy(x => x.DateCreation).Select(x => new { x.Code, x.RaisonSociale, x.Nom, x.Prenom, x.Telephone, x.Ville, x.Adresse,x.Email }).ToList();
                // gridView1.FocusedRowHandle = 0;
                clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();
            }
        }

        private void FrmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmClient = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            Client C = gridView1.GetFocusedRow() as Client;


            db = new Model.ApplicationContext();

            if (C != null)
            {

                Client ClientDb = db.Clients.Find(C.Code);
                FormshowNotParent(Forms.FrmModifierClient.InstanceFrmModifierClient);
                if (Application.OpenForms.OfType<FrmModifierClient>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtCode.Text = ClientDb.Code;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtRaisonSocial.Text = ClientDb.RaisonSociale;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtMatriculeFiscale.Text = ClientDb.MatriculeFiscale;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TXTActivite.Text = ClientDb.Activie;

                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtAdress.Text = ClientDb.Adresse;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtVille.Text = ClientDb.Ville;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtNom.Text = ClientDb.Nom;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtPrenom.Text = ClientDb.Prenom;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtTelephone.Text = ClientDb.Telephone;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtEmail.Text = ClientDb.Email;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtFax.Text = ClientDb.FAX;


                }

            }
            else
            {
                XtraMessageBox.Show("Acune ligne sélectionnée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Client C = gridView1.GetFocusedRow() as Client;
                if (C == null)
                {
                    XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var ClientBb = db.Clients.Find(C.Code);
                ClientBb.Status = Status.Bloquer;
                db.SaveChanges();
                /***************************** reload DataGridView ***********************************/
                // clientBindingSource.DataSource = db.Clients.Where(x=>x.Status== Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Nom, x.Prenom, x.Telephone, x.Ville, x.Adresse, x.Email }).ToList();
                clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();
                /***************************** reload DataGridView  ***********************************/
                XtraMessageBox.Show("l'utilisateur a été supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
            else
            {

                XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterClient.InstanceFrmAjouterClient);
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





        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<Client> AllClient = new List<Client>();
            AllClient = db.Clients.ToList();
            foreach (var C in AllClient)
            {

                C.Status = Status.Bloquer;
            }
            db.Clients.RemoveRange(AllClient);
            db.SaveChanges();
            // clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Nom, x.Prenom, x.Telephone, x.Ville, x.Adresse, x.Email }).ToList();
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();

            XtraMessageBox.Show("Supprimé Tout les Clients avec  Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnExporterXLS_Click(object sender, EventArgs e)
        {
            string path = "Liste Clients.xlsx";

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

        private void BtnExporterPDF_Click(object sender, EventArgs e)
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
    }
}