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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model;
using System.Globalization;
using System.Threading;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout.Utils;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmCreeBonDeSortiesSaisieLibre : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();      
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;   
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmCreeBonDeSortiesSaisieLibre _FrmCreerBonDeCommande;
        public static FrmCreeBonDeSortiesSaisieLibre InstanceFrmCreerBonDeCommande
        {
            get
            {
                if (_FrmCreerBonDeCommande == null)
                    _FrmCreerBonDeCommande = new FrmCreeBonDeSortiesSaisieLibre();
                return _FrmCreerBonDeCommande;
            }
        }
        public FrmCreeBonDeSortiesSaisieLibre()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmCreerBonDeCommande_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCreerBonDeCommande = null;
        }

   

        private void FrmCreerBonDeCommande_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();
         
            dateEditDateBonDeCommande.DateTime = DateTime.Now;
            /***********************  Mode  Paiement Liste  ***********************/
          
            BonDeSortie D = new BonDeSortie();
            TxTReference.Text = D.Reference;           
            SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity}).ToList();
            TxtNomChauffeur.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtCIN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtDepart.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtDestination.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            layoutControlItemNom.Visibility = LayoutVisibility.Never;
            layoutControlItemPrenom.Visibility = LayoutVisibility.Never;

        }

        private void BtnCrrerBonDeCommande_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNomChauffeur.Text))
            {
                TxtNomChauffeur.ErrorText = "Nom Chauffeur  est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtCIN.Text))
            {
                TxtCIN.ErrorText = "CIN Chauffeur  est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtDepart.Text))
            {
                TxtDepart.ErrorText = "Depart   est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtDestination.Text))
            {
                TxtDestination.ErrorText = "Destination   est obligatoire";
                return;

            }

            
            List<ligneBonSortie> ListeGrid = new List<ligneBonSortie>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as ligneBonSortie;
                data.Metrage = data.Qty * 100;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show( "Ligne Bon De Sorie est invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
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


            BonDeSortie bonDeSortie = new BonDeSortie();
            bonDeSortie.TypeBonDeSortie = TypeBonDeSortie.BonDeSortieSaisieLibre;
            bonDeSortie.Client = client;
            bonDeSortie.NomClientPassager = TxtNomClient.Text;
            bonDeSortie.PrenomClientPassager = TxtPrenomClient.Text;
            bonDeSortie.RaisonSociale = client.RaisonSociale;

            bonDeSortie.NomChauffeur = TxtNomChauffeur.Text; 
            bonDeSortie.CinChauffeur = TxtCIN.Text;
            bonDeSortie.Depart = TxtDepart.Text;
            bonDeSortie.Destination = TxtDestination.Text;

            bonDeSortie.MatriculeCamion = TxtMatriculeCamion.Text;
            bonDeSortie.MatriculeClient = TxtMatriculeClient.Text;
            bonDeSortie.ligneBonDeSortie = ListeGrid;
            bonDeSortie.Reference = TxTReference.Text;
            bonDeSortie.Total_BonDeCommandeHT = ListeGrid.Sum(x=>x.TotalLigneHT);
            bonDeSortie.Total_BonDeCommandeTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
            db.BonDeSorties.Add(bonDeSortie);
            db.SaveChanges();
            XtraMessageBox.Show("Bon De Sortie e a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < gridView1.RowCount;)
                gridView1.DeleteRow(i);           
            BonDeSortie D = new BonDeSortie();
            TxTReference.Text = D.Reference;
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeBonDeSortiesSaisieLibre>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeBonDeSortiesSaisieLibre>().First().bonDeCommandeBindingSource.DataSource =db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").Where(x => x.TypeBonDeSortie == TypeBonDeSortie.BonDeSortieSaisieLibre).OrderByDescending(x => x.DateCreation).ToList();



        }

       

        

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
           
            gridView1.DeleteSelectedRows();
            
        }

       

       

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
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
            else
            {
                Client client = db.Clients.Find(ClientSelected);
                TxtMatriculeClient.Text = client.MatriculeFiscale;
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

        private void SearchLookUpPack_EditValueChanged(object sender, EventArgs e)
        {
            //SearchLookUpEdit editor = sender as SearchLookUpEdit;
            //GridView view2 = editor.Properties.View;
            //int rowHandle2 = view2.FocusedRowHandle;
            //string fieldName2 = "Designation"; // or other field name  
            //object PackSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
         //   if (PackSelected != null)
            {
                //pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(PackSelected.ToString()));              

                //repositoryItemComboBoxListePrice.Items.Clear();
                //repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros1);
                //repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros2);
                //repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVentepublic);
                //repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteRevendeur);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PrixHT", repositoryItemComboBoxListePrice.Items[0]);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Description", pack.Designation);
               
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }
    }
}