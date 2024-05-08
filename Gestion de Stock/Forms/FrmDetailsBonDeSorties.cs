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
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmDetailsBonDeSorties : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmDetailsBonDeSorties _FrmDetaisBonDeCommande;
        public static FrmDetailsBonDeSorties InstanceFrmDetaisBonDeCommande
        {
            get
            {
                if (_FrmDetaisBonDeCommande == null)
                    _FrmDetaisBonDeCommande = new FrmDetailsBonDeSorties();
                return _FrmDetaisBonDeCommande;
            }
        }

        public FrmDetailsBonDeSorties()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetaisBonDeCommande_Load(object sender, EventArgs e)
        {
            SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity, x.PrixdeVenteRevendeur, x.PrixdeVentepublic, x.PrixdeVenteGros1, x.PrixdeVenteGros2 }).ToList();
        }

        private void FrmDetaisBonDeCommande_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetaisBonDeCommande = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            // BonDeCommande DB
       
            string Code = TxtCodeBonDeCommande.Text;
             BonDeSortie  GetBonDeCommandeDB = db.BonDeSorties.Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(Code));
            List<ligneBonSortie> ListeGrid = new List<ligneBonSortie>();

            int rowHandleListeGrid = 0;
            while (gridView1.IsValidRowHandle(rowHandleListeGrid))
            {
                var data = gridView1.GetRow(rowHandleListeGrid) as ligneBonSortie;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandleListeGrid);
                rowHandleListeGrid++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("ligne Bon De Commande est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                List<ligneBonSortie> ligneBonDeCommandes = new List<ligneBonSortie>();
                foreach (var L in ListeGrid)
                {
                    ligneBonSortie Ld = new ligneBonSortie();
                   
                    Ld.Description = L.Description;
                    Ld.PrixHT = L.PrixHT;
                    Ld.Metrage = L.Qty * 100;
                    Ld.Remise = L.Remise;
                    Ld.Qty = L.Qty;
                    Ld.TVA = GetBonDeCommandeDB.TVA;
                    ligneBonDeCommandes.Add(Ld);
                }
                var ListeLigne = GetBonDeCommandeDB.ligneBonDeSortie.ToList();
                foreach (var lignedevis in ListeLigne)
                {
                    ligneBonSortie Ld = db.ligneBonSorties.Find(lignedevis.Id);
                    db.ligneBonSorties.Remove(Ld);
                    db.SaveChanges();
                }

                GetBonDeCommandeDB.ligneBonDeSortie = ligneBonDeCommandes;

                db.SaveChanges();
                GetBonDeCommandeDB.Total_BonDeCommandeHT = ListeGrid.Sum(x => x.TotalLigneHT);
                GetBonDeCommandeDB.Total_BonDeCommandeTTC = ListeGrid.Sum(x => x.TotalLigneTTC);

                db.SaveChanges();
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
                if (Application.OpenForms.OfType<FrmListeBonDeSorties>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeBonDeSorties>().First().bonDeCommandeBindingSource.DataSource = db.BonDeSorties.Include("Client").Include("ligneBonDeSortie").OrderByDescending(x => x.DateCreation).ToList();
                XtraMessageBox.Show(" le Bon De Commande e a été  Modifier", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
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


                //  }

            }
        }
    }
}