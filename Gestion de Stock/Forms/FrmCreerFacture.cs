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
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmCreerFacture : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        private string filePath = string.Empty;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmCreerFacture _FrmCreerFacture;
        public static FrmCreerFacture InstanceFrmCreerFacture
        {
            get
            {
                if (_FrmCreerFacture == null)
                    _FrmCreerFacture = new FrmCreerFacture();
                return _FrmCreerFacture;
            }
        }
        public FrmCreerFacture()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmCreerFacture_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCreerFacture = null;
        }



        private void FrmCreerFacture_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();

          
            /***********************  Mode  Paiement Liste  ***********************/

            Facture D = new Facture();
            TxTReference.Text = D.Reference;
           
            TxtTimber.Text = db.Societes.FirstOrDefault().Timber.ToString();
            SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity, x.PrixdeVenteRevendeur, x.PrixdeVentepublic, x.PrixdeVenteGros1, x.PrixdeVenteGros2 }).ToList();


        }

        private void BtnCrrerFacture_Click(object sender, EventArgs e)
        {
            List<ligneFacture> ListeGrid = new List<ligneFacture>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as ligneFacture;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("'ligne Facture est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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





            Vente Vente = new Vente();
            Vente.IntituleClient = client.RaisonSociale;
            Vente.NumClient = client.Code;
            Vente.TotalHT = ListeGrid.Sum(x=>x.TotalLigneHT);
            Vente.TotalTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
            Vente.LigneVentes = new List<LigneVente>();
            foreach (var LD in ListeGrid)
            {
                LigneVente LF = new LigneVente();
                LF.NomArticle = LD.Description;
                LF.PrixHT = LD.PrixHT;
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
            }
            //waiting Form  mise a jour des interfaces 
            //waiting Form  mise a jour des interfaces 






            Facture Facture = new Facture();
            Facture.NumeoDocument = "";
            Facture.Client = client;
            Facture.TVA = 19;
            Facture.Total_FactureHT = Vente.TotalTTC;
            Facture.Total_FactureTTC = decimal.Add(Facture.Total_FactureHTFODEC, Facture.TOTALTVA);
            Facture.ligneFactures = new List<ligneFacture>();
            Facture.ligneFactures = ListeGrid;          
            Facture.Client = client;
            db.Factures.Add(Facture);
            db.SaveChanges();
            XtraMessageBox.Show("creation Facture terminer avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();


            //waiting Form  mise a jour des interfaces 

           
            XtraMessageBox.Show("Facture e a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < gridView1.RowCount;)
                gridView1.DeleteRow(i);
           
            Facture D = new Facture();
            TxTReference.Text = D.Reference;
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();



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
            

            }
        }

        private void SearchLookUpPack_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            GridView view2 = editor.Properties.View;
            int rowHandle2 = view2.FocusedRowHandle;
            string fieldName2 = "Designation"; // or other field name  
            object PackSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
            if (PackSelected != null)
            {
                pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(PackSelected.ToString()));
                //if (gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
                //{

                repositoryItemComboBoxListePrice.Items.Clear();
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros1);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros2);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVentepublic);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteRevendeur);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PrixHT", repositoryItemComboBoxListePrice.Items[0]);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Description", pack.Designation);
                // repositoryItemComboBoxListePrice.selec

                //  }
                // gridView1.OptionsBehavior.Editable = true;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                // get price of current Pack 

                string DesignationPack = gridView1.GetFocusedRowCellValue("Description").ToString();
                pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(DesignationPack));
                repositoryItemComboBoxListePrice.Items.Clear();
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros1);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros2);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVentepublic);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteRevendeur);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PrixHT", repositoryItemComboBoxListePrice.Items[0]);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", 1);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Description", pack.Designation); 
            }
        }
    }
}