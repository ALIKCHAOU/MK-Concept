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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Forms;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Gestion_de_Stock
{
    public partial class FrmBerurierArticleChute : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmBerurierArticleChute _FrmBerurierArticleChute;
        public static FrmBerurierArticleChute InstanceFrmBerurierArticleChute
        {
            get
            {
                if (_FrmBerurierArticleChute == null)
                {
                    _FrmBerurierArticleChute = new FrmBerurierArticleChute();
                }

                return _FrmBerurierArticleChute;
            }
        }

        public FrmBerurierArticleChute()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmBerurierArticleChute_Load(object sender, EventArgs e)
        {
            matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
         

            db = new Model.ApplicationContext();

            if (string.IsNullOrEmpty(TxtQuantitie.Text))
            {
                XtraMessageBox.Show("merci d'ajouter Qunatitè de retour", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            int QuantitieProduite = Convert.ToInt32(TxtQuantitie.Text);
            // Article Fini
            MatierePremiere articleFini = new MatierePremiere();
            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandlea = view.FocusedRowHandle;
            string fieldName = "Nom"; // or other field name  
            object articleFiniSelected = view.GetRowCellValue(rowHandlea, fieldName);
            ///Condition existance Fournisseur
            if (articleFiniSelected == null)
            {
                XtraMessageBox.Show("Choisir un article Fini ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {

                articleFini = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(articleFiniSelected.ToString()));
            }

            // Ajouter Mouvement  Bargataire BROUILLE
            int lastMvtStock = db.MouvementsStockMatierePremiere.ToList().Count() + 1;
            #region Ajouter MVT Stock MatierePremiere Bargataire BROUILLE

            MouvementStockMatierePremiere MvtStock1 = new MouvementStockMatierePremiere();
            MvtStock1.Numero = "ENA" + (lastMvtStock + 1).ToString("D8");
            MvtStock1.Date = DateTime.Now;
            MvtStock1.Sens = SensStock.Entree;
            MvtStock1.Code = "BROUILLE";
            MvtStock1.Intitulé = "BROUILLE Bargataire ";
            MvtStock1.QuantiteUtilisee = 0;
            MvtStock1.QuantiteAchetee = QuantitieProduite;
            // Matiere Premier 

            MvtStock1.QuantiteStockInitial = articleFini.Quantity;
            MvtStock1.QuantiteStockFinal = decimal.Add(MvtStock1.QuantiteStockInitial, QuantitieProduite);
            MvtStock1.Article = articleFini.Nom;
            MvtStock1.Commentaire = "BROUILLE Bargataire ";
            db.MouvementsStockMatierePremiere.Add(MvtStock1);
            db.SaveChanges();

            articleFini.Quantity = decimal.Add(articleFini.Quantity, QuantitieProduite);
            db.SaveChanges();
            #endregion

            #region Remove Article 
            int CodeArticlechute = Convert.ToInt32(TxtCode.Text);
            ArticleChute articleChute = db.ArticleChutes.Find(CodeArticlechute);
           
            db.Packs.Remove(db.Packs.Find(articleChute.idArticle));
            db.SaveChanges();

            if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity, x.GereStock }).ToList();
            #endregion
            #region  remouve Article chute
                     
            db.ArticleChutes.Remove(articleChute);
            db.SaveChanges();

            #endregion
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form 
            XtraMessageBox.Show("Enregisterment de mise a jour terminée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Application.OpenForms.OfType<FrmArticleChutes>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmArticleChutes>().FirstOrDefault().articleChuteBindingSource.DataSource = db.ArticleChutes.ToList();
               

            }
        }

        private void FrmBerurierArticleChute_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmBerurierArticleChute = null;
        }
    }
}
