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
    public partial class FrmDetailsBondeLivraison : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmDetailsBondeLivraison _FrmDetaisBonDeCommande;
        public static FrmDetailsBondeLivraison InstanceFrmDetaisBonDeCommande
        {
            get
            {
                if (_FrmDetaisBonDeCommande == null)
                    _FrmDetaisBonDeCommande = new FrmDetailsBondeLivraison();
                return _FrmDetaisBonDeCommande;
            }
        }

        public FrmDetailsBondeLivraison()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetaisBonDeCommande_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmDetaisBonDeCommande_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetaisBonDeCommande = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            // BonDeCommande DB
            
            string Code = TxtCodeBonDeCommande.Text;
            BonDeSortie GetBonDeCommandeDB = db.BonDeSorties.Include("ligneBonDeSortie").FirstOrDefault(x => x.Code.Equals(Code));
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
                    Ld.Description = L.Description;
                    Ld.PrixHT = L.PrixHT;
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

     

       
    }
}