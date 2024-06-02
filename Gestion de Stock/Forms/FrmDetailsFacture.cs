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
    public partial class FrmDetailsFacture : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmDetailsFacture _FrmDetailsFacture;
        public static FrmDetailsFacture InstanceFrmDetailsFacture
        {
            get
            {
                if (_FrmDetailsFacture == null)
                    _FrmDetailsFacture = new FrmDetailsFacture();
                return _FrmDetailsFacture;
            }
        }

        public FrmDetailsFacture()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetailsFacture_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();
        }

        private void FrmDetailsFacture_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailsFacture = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            // Facture DB
            //  Facture GetFactureDB = gridView1.GetFocusedRow() as Facture;
            string Code = TxtCodeFacture.Text;
            Facture GetFactureDB = db.Factures.Include("Client").Include("ligneFactures").FirstOrDefault(x => x.Code.Equals(Code));
            List<ligneFacture> ListeGrid = new List<ligneFacture>();

            int rowHandleListeGrid = 0;
            while (gridView1.IsValidRowHandle(rowHandleListeGrid))
            {
                var data = gridView1.GetRow(rowHandleListeGrid) as ligneFacture;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandleListeGrid);
                rowHandleListeGrid++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("ligne Facture est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                List<ligneFacture> ligneFacture = new List<ligneFacture>();
                foreach (var L in ListeGrid)
                {
                    ligneFacture Ld = new ligneFacture();
                    Ld.Description = L.Description;
                    Ld.PrixHT = L.PrixHT;
                    Ld.Remise = L.Remise;
                    Ld.Qty = L.Qty;
                    Ld.TVA = L.TVA;
                    ligneFacture.Add(Ld);
                }
                var ListeLigne = GetFactureDB.ligneFactures.ToList();
                foreach (var ligne in ListeLigne)
                {
                    ligneFacture Ld = db.ligneFactures.Find(ligne.Id);
                    db.ligneFactures.Remove(Ld);
                    db.SaveChanges();
                }

                GetFactureDB.ligneFactures = ligneFacture;
                GetFactureDB.TVA = !string.IsNullOrEmpty(TxtTvaclient.Text) ? Convert.ToInt16(TxtTvaclient.Text) : GetFactureDB.TVA;
                db.SaveChanges();
                GetFactureDB.Total_FactureHT = ListeGrid.Sum(x => x.TotalLigneHT);
                GetFactureDB.Total_FactureTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
                GridView view2 = searchLookUpEdit1.Properties.View;
                int rowHandle2 = view2.FocusedRowHandle;
                string fieldName2 = "Code"; // or other field name  
                object ClientSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
                ///Condition existance Fournisseur
                Client client = new Client();
                if (ClientSelected != null)
                {

                    client = db.Clients.Find(ClientSelected);

                    GetFactureDB.Client = client;
                }


                db.SaveChanges();
                // UPDATE VENTE
                if (GetFactureDB.IdVentes != 0)
                {
                    Vente VenteDB = db.Vente.Include("LigneVentes").FirstOrDefault(x => x.Id == GetFactureDB.IdVentes);
                    List<LigneVente> LigneVente = new List<LigneVente>();
                    foreach (var L in ListeGrid)
                    {
                        LigneVente Ld = new LigneVente();
                        Ld.NomArticle = L.Description;
                        Ld.PrixHT = L.PrixHT;
                        Ld.Remise = L.Remise;
                        Ld.Quantity = L.Qty;
                        Ld.TVA = L.TVA;
                        LigneVente.Add(Ld);
                    }

                    var LigneVentes = VenteDB.LigneVentes.ToList();
                    foreach (var ligne in LigneVentes)
                    {
                        LigneVente Ld = db.LigneVentes.Find(ligne.Id);
                        db.LigneVentes.Remove(Ld);
                        db.SaveChanges();
                    }

                    VenteDB.LigneVentes = LigneVente;
                    VenteDB.IntituleClient = GetFactureDB.Client.RaisonSociale;
                    VenteDB.NumClient = GetFactureDB.Client.Code;
                    VenteDB.TotalHT = ListeGrid.Sum(x => x.TotalLigneHT);
                    VenteDB.TotalTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
                    // UPDATE VENTE 
                    List<HistoriquePaiementVente> HistoriquePaiementVentes = db.HistoriquePaiementVente.Where(x => x.IdVente == GetFactureDB.IdVentes).ToList();
                    foreach (var ligne in HistoriquePaiementVentes)
                    {
                        HistoriquePaiementVente Ld = db.HistoriquePaiementVente.Find(ligne.Id);
                        db.HistoriquePaiementVente.Remove(Ld);
                        db.SaveChanges();
                    }
                    VenteDB.EtatVente = Model.Enumuration.EtatVente.NonReglee;
                    VenteDB.MontantReglement = VenteDB.TotalTTC;
                    VenteDB.MontantRegle = 0;
                    db.SaveChanges();
                }
                this.Hide();
                // waiting Form
                //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                //for (int i = 0; i < 100; i++)
                //{
                //    Thread.Sleep(10);
                //}
                //SplashScreenManager.CloseForm();
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeFactures>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeFactures>().First().factureBindingSource.DataSource = db.Factures.Include("Client").Include("ligneFactures").OrderByDescending(x => x.DateCreation).ToList();
                if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();

                XtraMessageBox.Show("Facture e a été  Modifier", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }



        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();

        }




    }
}