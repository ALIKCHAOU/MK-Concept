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
    public partial class FrmCreeBonDeLivraisonSaisieLibre : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmCreeBonDeLivraisonSaisieLibre _FrmCreerBonDeCommande;
        public static FrmCreeBonDeLivraisonSaisieLibre InstanceFrmCreerBonDeLivraisonSaisieLibre
        {
            get
            {
                if (_FrmCreerBonDeCommande == null)
                    _FrmCreerBonDeCommande = new FrmCreeBonDeLivraisonSaisieLibre();
                return _FrmCreerBonDeCommande;
            }
        }
        public FrmCreeBonDeLivraisonSaisieLibre()
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
          
            TxtNomChauffeur.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtCIN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtDepart.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtDestination.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

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


            List<ligneBonLivraison> ListeGrid = new List<ligneBonLivraison>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as ligneBonLivraison;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("Ligne Bon De Sorie est invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
          
            BondeLivraison BondeLivraison = new BondeLivraison();
            BondeLivraison.TypeBonDeLivraison = TypeBonDeLivraison.BonDeSortieSaisieLibre;
            BondeLivraison.NomChauffeur = TxtNomChauffeur.Text;
            BondeLivraison.CinChauffeur = TxtCIN.Text;
            BondeLivraison.Depart = TxtDepart.Text;
            BondeLivraison.Destination = TxtDestination.Text;
            BondeLivraison.ligneBonDeCommande = ListeGrid;
            BondeLivraison.Reference = TxTReference.Text;
            BondeLivraison.MatriculeCamion = TxtMatriculeCamion.Text;
            BondeLivraison.MatriculeClient = TxtMatriculeClient.Text;
            BondeLivraison.RaisonSocialeClient = TxtRaisonSocialeClient.Text;
            BondeLivraison.Total_BonDeCommandeHT = ListeGrid.Sum(x => x.TotalLigneHT);
            BondeLivraison.Total_BonDeCommandeTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
            db.BondeLivraisons.Add(BondeLivraison);
            db.SaveChanges();
            XtraMessageBox.Show("Bon De Livraison Saisie Libre e a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < gridView1.RowCount;)
                gridView1.DeleteRow(i);
            BonDeSortie D = new BonDeSortie();
            TxTReference.Text = D.Reference;
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeBonLivraisonSaisieLibre>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeBonLivraisonSaisieLibre>().First().bondeLivraisonBindingSource.DataSource = db.BondeLivraisons.Include("Client").Include("ligneBonDeCommande").Where(x=>x.TypeBonDeLivraison==TypeBonDeLivraison.BonDeSortieSaisieLibre).OrderByDescending(x => x.DateCreation).ToList();



        }





        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

            gridView1.DeleteSelectedRows();

        }





       

       
    }
}