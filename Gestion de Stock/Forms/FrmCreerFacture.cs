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
            string lastCodestr = "";
            if (db.Factures.Count() > 1)
            {
                lastCodestr = db.Factures.OrderByDescending(x => x.DateCreation).FirstOrDefault().Code.Replace("F", "");
             
                TxTReference.Text = "Facture/MK CONCEPT/" + (Convert.ToInt32(lastCodestr) + 1).ToString("D8");
            }
            else
            {
                TxTReference.Text = "Facture/MK CONCEPT/00000001";
            }

            TxtTimber.Text = db.Societes.FirstOrDefault().Timber.ToString();
           


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

       
            Facture Facture = new Facture();
            string  lastCodestr = "";
            if (db.Factures.Count() > 1)
            {
                lastCodestr = db.Factures.OrderByDescending(x => x.DateCreation).FirstOrDefault().Code.Replace("F", "");
                Facture.Code = "F" + (Convert.ToInt32(lastCodestr) + 1).ToString("D8");
                Facture.Reference = "Facture/MK CONCEPT/" + (Convert.ToInt32(lastCodestr) + 1).ToString("D8");
            }
            else
            {
                Facture.Code = "F00000001";
                Facture.Reference = "Facture/MK CONCEPT/00000001";
            }

            Facture.NumeoDocument = "";
            Facture.Client = client;
            Societe societe= db.Societes.FirstOrDefault();            
            Facture.TVA = societe != null ? societe.TVA : 19;
            Facture.Total_FactureHT = Vente.TotalTTC;
            Facture.Total_FactureTTC = decimal.Add(Facture.Total_FactureHT, Facture.TOTALTVA);
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

             lastCodestr = "";
            if (db.Factures.Count() > 1)
            {
                lastCodestr = db.Factures.OrderByDescending(x => x.DateCreation).FirstOrDefault().Code.Replace("F", "");

                TxTReference.Text = "Facture/MK CONCEPT/" + (Convert.ToInt32(lastCodestr) + 1).ToString("D8");
            }
            else
            {
             
                TxTReference.Text = "Facture/MK CONCEPT/00000001";
            }
           
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

       

      
    }
}