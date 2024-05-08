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
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmBSVersBL : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmBSVersBL _FrmBSVersBL;
        public static FrmBSVersBL InstanceFrmBSVersBL
        {
            get
            {
                if (_FrmBSVersBL == null)
                    _FrmBSVersBL = new FrmBSVersBL();
                return _FrmBSVersBL;
            }
        }
        public FrmBSVersBL()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmBSVersBL_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();
            layoutChoixClient.Visibility = LayoutVisibility.Never;
        }

        private void FrmBSVersBL_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmBSVersBL = null;
        }

        private void CheckchangerClient_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckchangerClient.Checked)
            {
                layoutChoixClient.Visibility =  LayoutVisibility.Always;
            }
            else
            {
                layoutChoixClient.Visibility = LayoutVisibility.Never;
            }
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            BonDeSortie BonDeCommandeDB = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(TxtCodeBondeSortie.Text));
            BondeLivraison BondeLivraison = new BondeLivraison();

            BondeLivraison.NomChauffeur = BonDeCommandeDB.NomChauffeur;
            BondeLivraison.CinChauffeur = BonDeCommandeDB.CinChauffeur;
            BondeLivraison.Depart = BonDeCommandeDB.Depart;
            BondeLivraison.Destination = BonDeCommandeDB.Destination;
            BondeLivraison.MatriculeCamion = BonDeCommandeDB.MatriculeCamion;
            BondeLivraison.ligneBonDeCommande = new  List<ligneBonLivraison>();
            List<ligneBonSortie> ligneBonSorties= BonDeCommandeDB.ligneBonDeSortie.ToList();
            foreach (var item in ligneBonSorties)
            {
                ligneBonLivraison ligneBonLivraison = new ligneBonLivraison();
                ligneBonLivraison.Description = item.Description;
                ligneBonLivraison.Metrage = item.Metrage;
                ligneBonLivraison.PrixHT = item.PrixHT;
                ligneBonLivraison.Qty = item.Qty;
                ligneBonLivraison.Remise = item.Remise;
                BondeLivraison.ligneBonDeCommande.Add(ligneBonLivraison);


            }

           
            if (CheckchangerClient.Checked)
            {
                GridView view2 = searchLookUpEdit1.Properties.View;
                int rowHandle2 = view2.FocusedRowHandle;
                string fieldName2 = "Code"; // or other field name  
                object ClientSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
                ///Condition existance Fournisseur
                if (ClientSelected == null)
                {
                    XtraMessageBox.Show("'Client est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpEdit1.Focus();
                    return;

                }
                Client client = db.Clients.Find(ClientSelected);

                BondeLivraison.MatriculeClient = client.MatriculeFiscale;
                BondeLivraison.RaisonSocialeClient = client.RaisonSociale;
                BondeLivraison.Client = client;
            }
            else
            {
                Client client = db.Clients.Find(TxtCodeClient.Text);

                BondeLivraison.MatriculeClient = client.MatriculeFiscale;
                BondeLivraison.RaisonSocialeClient = TxtRsClient.Text;
                BondeLivraison.Client = client;
            }       
         
            db.BondeLivraisons.Add(BondeLivraison);
            db.SaveChanges();
            XtraMessageBox.Show("Bon De  Livraisons e a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form 
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeBonLivraison>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeBonLivraison>().First().bondeLivraisonBindingSource.DataSource = db.BondeLivraisons.Include("Client").Include("ligneBonDeCommande").OrderByDescending(x => x.DateCreation).ToList();
           
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GridView view2 = searchLookUpEdit1.Properties.View;
            int rowHandle2 = view2.FocusedRowHandle;
            string fieldName2 = "Code"; // or other field name  
            object ClientSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
            ///Condition existance Fournisseur
            if (ClientSelected != null)
            {
                Client client = db.Clients.Find(TxtCodeClient.Text);

            if (client.RaisonSociale.ToUpper().Contains("PASSAGER"))
            {
                TxtPrenomClient.Text = string.Empty;
                TxtNomClient.Text = string.Empty;
                layoutControlItemNom.Visibility = LayoutVisibility.Always;
                layoutControlItemPrenom.Visibility = LayoutVisibility.Always;
            }
            else
            {
                TxtPrenomClient.Text = string.Empty;
                TxtNomClient.Text = string.Empty;
                layoutControlItemNom.Visibility = LayoutVisibility.Never;
                layoutControlItemPrenom.Visibility = LayoutVisibility.Never;
            }

            }
        }
    }
}