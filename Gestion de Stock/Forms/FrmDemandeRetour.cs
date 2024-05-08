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
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmDemandeRetour : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmDemandeRetour _FrmDemandeRetour;
        public static FrmDemandeRetour InstanceFrmDemandeRetour
        {
            get
            {
                if (_FrmDemandeRetour == null)
                    _FrmDemandeRetour = new FrmDemandeRetour();
                return _FrmDemandeRetour;
            }
        }

        public FrmDemandeRetour()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDemandeRetour_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDemandeRetour = null;
        }

        private void FrmDemandeRetour_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtQte.Text))
            {
                XtraMessageBox.Show("merci d'ajouter Qunatitè de retour", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            db = new Model.ApplicationContext();
            int CodeLigne= Convert.ToInt32(TxtCodeLigne.Text.Trim());
            int QteRetourne = Convert.ToInt32(TxtQte.Text);
            bool AvecRetourStock = checkRetourStock.Checked;
            bool AjouterChute = checkBoxAjouterChute.Checked;
            LigneVente VenteLigneDb = db.LigneVentes.Include("Vente").FirstOrDefault(x=>x.Id==CodeLigne);
            int CodeVente = VenteLigneDb.Vente.Id;
            Vente vente = db.Vente.Find(CodeVente);
            int QteVendu = VenteLigneDb.Quantity;
            // Qte Retourne 
            if (QteRetourne > QteVendu)
            {
                TxtQte.ErrorText = "Qte Retourne est obligatoire";
                return;

            }
            if (AvecRetourStock && AjouterChute)
            {
                XtraMessageBox.Show("merci de sélectionner un seul type de retour", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!AvecRetourStock && !AjouterChute)
            {
                XtraMessageBox.Show("merci d'ajouter le type de retour", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (AjouterChute && string.IsNullOrEmpty(TxtMettrage.Text))
            {
                XtraMessageBox.Show("Merci d'ajouter le métrage ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (AjouterChute)
            {
                Article Pack = new Article();                
                Pack.GereStock = true;
                Pack.Designation = VenteLigneDb.NomArticle+" "+TxtMettrage.Text+"M";
                Pack.Quantity = 1;
                db.Packs.Add(Pack);
                db.SaveChanges();
                Pack.Code = "P" + (Pack.Id).ToString("D8");
                db.SaveChanges();

                ArticleChute articleChute = new ArticleChute();
                articleChute.NomArticle = VenteLigneDb.NomArticle+" "+TxtMettrage.Text+"M";
                articleChute.Origine = "Retour";
                articleChute.Quantite = QteRetourne;
                articleChute.Poids= 50;
                articleChute.idArticle = Pack.Id;
                articleChute.Metrage = Convert.ToInt32(TxtMettrage.Text);
                db.ArticleChutes.Add(articleChute);
                db.SaveChanges();
                Pack.IdArticlechute = articleChute.Id;
                db.SaveChanges();
                
                if (Application.OpenForms.OfType<FrmArticleChutes>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmArticleChutes>().First().articleChuteBindingSource.DataSource = db.ArticleChutes.OrderByDescending(x => x.DateCreation).ToList();
            }else if (AvecRetourStock)
            {
               
                //  mouvementStockPack
                MouvementStockPack mouvementStockPack = new MouvementStockPack();
                mouvementStockPack.Commentaire = "Retour N°" + " " + vente.Numero;
                mouvementStockPack.Intitulé = "Retour";
                mouvementStockPack.Numero = "Retour N° :" + vente.Numero;
                mouvementStockPack.QuantiteProduite = QteRetourne;
                mouvementStockPack.Sens = SensStock.Entree;
                mouvementStockPack.Article = VenteLigneDb.NomArticle;
                Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(VenteLigneDb.NomArticle));
                mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial + QteRetourne;
                Packdb.Quantity = mouvementStockPack.QuantiteStockFinal;
                mouvementStockPack.Date =DateTime.Now;
                db.MouvementStockPacks.Add(mouvementStockPack);
                db.SaveChanges();
                mouvementStockPack.Code = "EN" + (mouvementStockPack.Id).ToString("D8");
                db.SaveChanges();
                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.ToList(); ;
                }
            }
            
            if (QteVendu - QteRetourne > 0)
            {
                // mise a jour de la vente 
                VenteLigneDb.Quantity = QteVendu - QteRetourne;
                db.SaveChanges();


            }
            else if (QteRetourne - QteVendu == 0)
            {
                db.LigneVentes.Remove(VenteLigneDb);
                db.SaveChanges();
            }


            this.Hide();
            Vente VenteDB = db.Vente.FirstOrDefault(x => x.Id == CodeVente);
             //vente.TotalHT = VenteDB.LigneVentes.Sum(x => x.TotalLigneHT);
            //vente.TotalTTC = VenteDB.LigneVentes.Sum(x => x.TotalLigneTTC);
            List<LigneVente> allLigneVenteDb = db.LigneVentes.Include("Vente").Where(lv => lv.Vente.Id == CodeVente).ToList();
            vente.TotalHT = allLigneVenteDb.Sum(x => x.TotalLigneHT);
             vente.TotalTTC = allLigneVenteDb.Sum(x => x.TotalLigneTTC);
         
            db.SaveChanges();
            if (Application.OpenForms.OfType<FrmDetailVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmDetailVente>().First().Close();

            if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();
            if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
            }
              
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form 
            XtraMessageBox.Show("Enregisterment de mise a jour terminée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            // supression ligne si Qte Vendu = Qte Retournè 
            // Retour Au Stock is AvecRetourStock = True
            // modification des Montants mise a jour vente 

        }

        private void FrmDemandeRetour_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtQte;
        }
        private void checkRetourStock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRetourStock.Checked)
            {
                
                checkBoxAjouterChute.Checked = false;
            }
        }


        private void checkBoxAjouterChute_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkBoxAjouterChute.Checked)
            {

                checkRetourStock.Checked = false;
            }

        }
    }
}