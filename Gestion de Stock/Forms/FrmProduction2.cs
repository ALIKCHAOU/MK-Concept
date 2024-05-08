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
using System.Globalization;
using System.Threading;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmProduction2 : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmProduction2 _FrmProduction;
        public static FrmProduction2 InstanceFrmProduction
        {
            get
            {
                if (_FrmProduction == null)
                    _FrmProduction = new FrmProduction2();
                return _FrmProduction;
            }
        }

        public FrmProduction2()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmProduction2_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtQteProduite.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtQteUtiliser.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtQteUtiliser.Text = "0";
            TxtQteProduite.Text = "0";
            DateProduction.DateTime = DateTime.Now;
            DateTime DateMin = DateTime.Now;
            List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
            ListeGridMatierePermier = db.listeMatierePermierUtilisers.Where(x => x.Date.Year == DateMin.Year && x.Date.Month == DateMin.Month && x.Date.Day == DateMin.Day).ToList();
            List<LigneProductionUsine2> LigneProductionUsine2 = new List<LigneProductionUsine2>();
            LigneProductionUsine2 = db.LigneProductionUsine2.Where(x => x.DateCreation.Year == DateMin.Year && x.DateCreation.Month == DateMin.Month && x.DateCreation.Day == DateMin.Day).ToList();
          
            ligneProductionUsine2BindingSource.DataSource = LigneProductionUsine2;
         

           
            matierePremiereBindingSource.DataSource = db.MatierePremieres.Where(x=>x.Nom.Equals("Déchet") || x.Nom.Equals("BARGATAIRE NON BROUILLE")).Select(x => new { x.Code, x.Nom, x.Description, x.Quantity }).ToList();
            matierePremiereBindingSource1.DataSource = db.MatierePremieres.Where(x => !x.Nom.Equals("Déchet") || !x.Nom.Equals("BARGATAIRE NON BROUILLE")).Select(x => new { x.Code, x.Nom, x.Description, x.Quantity }).ToList();
        }

        private void FrmProduction2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmProduction = null;
        }

        private void repositoryItemButtonEditSupprimer_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

   
        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            MatierePremiere article = new MatierePremiere();
            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandlea = view.FocusedRowHandle;
            string fieldName = "Nom"; // or other field name  
            object articleSelected = view.GetRowCellValue(rowHandlea, fieldName);
            ///Condition existance Fournisseur
            if (articleSelected == null)
            {
                XtraMessageBox.Show("Choisir un MatierePremiere ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {

                article = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(articleSelected.ToString()));
            }
            #region  Controle Qunatite Utiliser
            if (String.IsNullOrEmpty(TxtQteUtiliser.Text))
            {
                TxtQteUtiliser.ErrorText = "Quantité   est obligatoire";
                XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            decimal Qunatite;
            string QunatiteStr = TxtQteUtiliser.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QunatiteStr, out Qunatite);
            if (Qunatite == 0)
            {
                TxtQteUtiliser.ErrorText = "Quantité   est Invalide";
                XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }

            #endregion

            #region  Controle Qunatite Utiliser TxtQte Bargataire BROUILLE
            if (String.IsNullOrEmpty(TxtQteProduite.Text))
            {
                TxtQteProduite.ErrorText = "Quantité  Produite est obligatoire";
                XtraMessageBox.Show("'Quantité Produite est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            decimal QunatiteProduite;
            string QunatiteProduiteStr = TxtQteProduite.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QunatiteProduiteStr, out QunatiteProduite);
            if (QunatiteProduite == 0)
            {
                TxtQteProduite.ErrorText = "Quantité  Produite  est Invalide";
                XtraMessageBox.Show("'Quantité Produite est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }

            #endregion
            // Article Fini
            MatierePremiere articleFini = new MatierePremiere();
            GridView view1 = searchLookUpEdit2.Properties.View;
            int rowHandlea1 = view1.FocusedRowHandle;
            string fieldName1 = "Nom"; // or other field name  
            object articleFiniSelected = view1.GetRowCellValue(rowHandlea1, fieldName1);
            ///Condition existance Fournisseur
            if (articleFiniSelected == null)
            {
                XtraMessageBox.Show("Choisir un article Fini ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit2.Focus();
                return;

            }
            else
            {

                articleFini = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(articleFiniSelected.ToString()));
            }
            List<LigneProductionUsine2> ListeGrid = new List<LigneProductionUsine2>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as LigneProductionUsine2;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }

            if (ListeGrid.Where(x => x.NomArticle.Equals(article.Nom)).Any())
            {
                XtraMessageBox.Show("'Article est Invalide", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LigneProductionUsine2 LigneProductionUsine2 = new LigneProductionUsine2();
          
            LigneProductionUsine2.DateCreation = DateProduction.DateTime;
            LigneProductionUsine2.Poste ="Jour";
            LigneProductionUsine2.NomArticle = article.Nom;
            LigneProductionUsine2.QteProduite =(int) QunatiteProduite;
            LigneProductionUsine2.QteUtiliser = (int)Qunatite;
            LigneProductionUsine2.NomArticleFini = articleFini.Nom;
            ListeGrid.Add(LigneProductionUsine2);
            ligneProductionUsine2BindingSource.DataSource = ListeGrid.ToList();
            TxtQteUtiliser.Text = string.Empty;
            TxtQteProduite.Text = string.Empty;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
          
           bool ExsisteLigneProductionUsine2DB = db.LigneProductionUsine2.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).Any();
           

            if (!ExsisteLigneProductionUsine2DB)
            {
                #region  new  Production Usine 2 
                List<LigneProductionUsine2> ListeGrid = new List<LigneProductionUsine2>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProductionUsine2;
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(data.NomArticle));
                    if (matierePremiere.Quantity < data.QteUtiliser)
                    {
                        XtraMessageBox.Show("Quantité de matière insuffisante : " + matierePremiere.Nom, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    data.DateCreation = DateProduction.DateTime;
                    data.code = "Pro-Usine2 le " + DateProduction.DateTime.ToString("dd_MM_yyyy");
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }
                if (ListeGrid.Count() == 0)
                {
                    XtraMessageBox.Show("Liste  Production est Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                db.LigneProductionUsine2.AddRange(ListeGrid);
                db.SaveChanges();

                XtraMessageBox.Show("Enregisterment Production Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Mouvement
                foreach (var L in ListeGrid)
                {
                    #region Ajouter MVT Stock MatierePremiere

                    MouvementStockMatierePremiere MvtStock = new MouvementStockMatierePremiere();
                    int lastMvtStock = db.MouvementsStockMatierePremiere.ToList().Count() + 1;

                    MvtStock.Numero = "Sor" + (lastMvtStock).ToString("D8");
                    MvtStock.Date = L.DateCreation;
                    MvtStock.Sens = SensStock.Sortie;
                    MvtStock.Code = L.code;
                    MvtStock.Intitulé = L.code;
                    MvtStock.QuantiteAchetee = 0;
                    MvtStock.QuantiteUtilisee = L.QteUtiliser;
                    // Matiere Premier 
                    MatierePremiere matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.NomArticle));
                    MvtStock.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock.QuantiteStockFinal = decimal.Subtract(MvtStock.QuantiteStockInitial, L.QteUtiliser);
                    MvtStock.PrixMouvement = matierePremieredb.PrixMoyen;
                    MvtStock.Article = L.NomArticle;
                    MvtStock.Commentaire = "Production Usine 2 N°" + " " + L.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock);
                    db.SaveChanges();
                    matierePremieredb.Quantity = decimal.Subtract(matierePremieredb.Quantity, L.QteUtiliser);
                    db.SaveChanges();
                    #endregion

                    // Ajouter Mouvement  Bargataire BROUILLE
                    #region Ajouter MVT Stock MatierePremiere Bargataire BROUILLE
                    matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.NomArticleFini));
                    MouvementStockMatierePremiere MvtStock1 = new MouvementStockMatierePremiere();
                    MvtStock1.Numero = "ENA" + (lastMvtStock + 1).ToString("D8");
                    MvtStock1.Date = L.DateCreation;
                    MvtStock1.Sens = SensStock.Entree;
                    MvtStock1.Code = L.code;
                    MvtStock1.Intitulé = "Production Usine 2";
                    MvtStock1.QuantiteUtilisee = 0;
                    MvtStock1.QuantiteAchetee = L.QteProduite;
                    // Matiere Premier 

                    MvtStock1.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock1.QuantiteStockFinal = decimal.Add(MvtStock1.QuantiteStockInitial, L.QteProduite);
                    MvtStock1.Article = L.NomArticleFini;
                    MvtStock1.Commentaire = "Production Usine 2 " + " " + L.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock1);
                    db.SaveChanges();

                    matierePremieredb.Quantity = decimal.Add(matierePremieredb.Quantity, L.QteProduite);
                    db.SaveChanges();
                    MvtStock.PMP = matierePremieredb.PrixMoyen;
                    db.SaveChanges();
                    #endregion
                }
                // Substract  Liste Matiere Permier 
                #endregion
            }
            else
            {
                // supprimer old Production 
                List<LigneProductionUsine2> ligneProductionUsine2 = new List<LigneProductionUsine2>();
                ligneProductionUsine2 = db.LigneProductionUsine2.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).ToList();
                foreach (var item in ligneProductionUsine2)
                {
                    // supprimer Mouvement de Stock Sor
                    MouvementStockMatierePremiere mouvementsStockSor = db.MouvementsStockMatierePremiere.Where(x => x.Date.Year == item.DateCreation.Year && x.Date.Month == item.DateCreation.Month && x.Date.Day == item.DateCreation.Day &&

                    x.Sens== SensStock.Sortie && x.Article.Equals(item.NomArticle)).FirstOrDefault();
                    if (mouvementsStockSor!=null) { 
                    db.MouvementsStockMatierePremiere.Remove(mouvementsStockSor);
                    db.SaveChanges();
                    }
                    else
                    {
                        mouvementsStockSor = db.MouvementsStockMatierePremiere.Where(x => x.Date.Year == item.DateCreation.Year && x.Date.Month == item.DateCreation.Month && x.Date.Day == item.DateCreation.Day && x.Sens == SensStock.Sortie).FirstOrDefault();
                        db.MouvementsStockMatierePremiere.Remove(mouvementsStockSor);
                        db.SaveChanges();
                    }
                    MouvementStockMatierePremiere mouvementsStockEntr = db.MouvementsStockMatierePremiere.Where(x => x.Date.Year == item.DateCreation.Year && x.Date.Month == item.DateCreation.Month && x.Date.Day == item.DateCreation.Day &&

                    x.Sens == SensStock.Entree && x.Article.Equals(item.NomArticleFini) && (int) x.QuantiteAchetee==item.QteProduite).FirstOrDefault();
                    if (mouvementsStockEntr!=null) { 
                    db.MouvementsStockMatierePremiere.Remove(mouvementsStockEntr);
                    db.SaveChanges();
                    }else
                    {
                        mouvementsStockSor = db.MouvementsStockMatierePremiere.Where(x => x.Date.Year == item.DateCreation.Year && x.Date.Month == item.DateCreation.Month && x.Date.Day == item.DateCreation.Day && x.Sens == SensStock.Entree).FirstOrDefault();
                        db.MouvementsStockMatierePremiere.Remove(mouvementsStockSor);
                        db.SaveChanges();
                    }


                    MatierePremiere matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(item.NomArticle));
                    matierePremieredb.Quantity = decimal.Add(matierePremieredb.Quantity, item.QteUtiliser);
                    db.SaveChanges();
                    matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(item.NomArticleFini));
                    matierePremieredb.Quantity = decimal.Subtract(matierePremieredb.Quantity, item.QteProduite);
                    db.SaveChanges();
                    db.LigneProductionUsine2.Remove(item);
                    db.SaveChanges();
                }

                // Ajouter new Production 
                db = new Model.ApplicationContext();
                #region  new  Production Usine 2 
                List<LigneProductionUsine2> ListeGrid = new List<LigneProductionUsine2>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProductionUsine2;
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(data.NomArticle));
                    if (matierePremiere.Quantity < data.QteUtiliser)
                    {
                        XtraMessageBox.Show("Quantité de matière insuffisante : " + matierePremiere.Nom, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    data.DateCreation = DateProduction.DateTime;
                    data.code = "Pro-Usine2 le " + DateProduction.DateTime.ToString("dd_MM_yyyy");
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }
                if (ListeGrid.Count() == 0)
                {
                    XtraMessageBox.Show(" Mise a jour  Production Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Application.OpenForms.OfType<FrmMatierePremiere>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmMatierePremiere>().First().matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();


                    if (Application.OpenForms.OfType<FrmSuivieProductionsUsine2>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmSuivieProductionsUsine2>().First().ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.OrderByDescending(x => x.DateCreation).ToList();

                    if (Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().First().mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.OrderByDescending(x => x.Date).ToList();
                    return;
                }



                db.LigneProductionUsine2.AddRange(ListeGrid);
                db.SaveChanges();

          

                foreach (var L in ListeGrid)
                {
                    #region Ajouter MVT Stock MatierePremiere

                    MouvementStockMatierePremiere MvtStock = new MouvementStockMatierePremiere();
                    int lastMvtStock = db.MouvementsStockMatierePremiere.ToList().Count() + 1;

                    MvtStock.Numero = "Sor" + (lastMvtStock).ToString("D8");
                    MvtStock.Date = L.DateCreation;
                    MvtStock.Sens = SensStock.Sortie;
                    MvtStock.Code = L.code;
                    MvtStock.Intitulé = L.code;
                    MvtStock.QuantiteAchetee = 0;
                    MvtStock.QuantiteUtilisee = L.QteUtiliser;
                    // Matiere Premier 
                    MatierePremiere matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.NomArticle));
                    MvtStock.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock.QuantiteStockFinal = decimal.Subtract(MvtStock.QuantiteStockInitial, L.QteUtiliser);
                    MvtStock.PrixMouvement = matierePremieredb.PrixMoyen;
                    MvtStock.Article = L.NomArticle;
                    MvtStock.Commentaire = "Production Usine 2 N°" + " " + L.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock);
                    db.SaveChanges();
                    matierePremieredb.Quantity = decimal.Subtract(matierePremieredb.Quantity, L.QteUtiliser);
                    db.SaveChanges();
                    #endregion

                    // Ajouter Mouvement  Bargataire BROUILLE
                    #region Ajouter MVT Stock MatierePremiere Bargataire BROUILLE
                    matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.NomArticleFini));
                    MouvementStockMatierePremiere MvtStock1 = new MouvementStockMatierePremiere();
                    MvtStock1.Numero = "ENA" + (lastMvtStock + 1).ToString("D8");
                    MvtStock1.Date = L.DateCreation;
                    MvtStock1.Sens = SensStock.Entree;
                    MvtStock1.Code = L.code;
                    MvtStock1.Intitulé = " Usine 2";
                    MvtStock1.QuantiteUtilisee = 0;
                    MvtStock1.QuantiteAchetee = L.QteProduite;
                    // Matiere Premier 

                    MvtStock1.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock1.QuantiteStockFinal = decimal.Add(MvtStock1.QuantiteStockInitial, L.QteProduite);
                    MvtStock1.Article = L.NomArticle;
                    MvtStock1.Commentaire = "Production Usine 2" + " " + L.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock1);
                    db.SaveChanges();

                    matierePremieredb.Quantity = decimal.Add(matierePremieredb.Quantity, L.QteProduite);
                    db.SaveChanges();
                    MvtStock.PMP = matierePremieredb.PrixMoyen;
                    db.SaveChanges();
                    #endregion
                }
                // Substract  Liste Matiere Permier 
                #endregion



                XtraMessageBox.Show("Mise à jour Production Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Application.OpenForms.OfType<FrmMatierePremiere>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmMatierePremiere>().First().matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();


            if (Application.OpenForms.OfType<FrmSuivieProductionsUsine2>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmSuivieProductionsUsine2>().First().ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().First().mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.OrderByDescending(x => x.Date).ToList();
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form 

            TxtQteProduite.Text = string.Empty;
            TxtQteUtiliser.Text = string.Empty;

            // Mouvement



        }

        private void DateProduction_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = DateProduction.DateTime;
            List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
            ListeGridMatierePermier = db.listeMatierePermierUtilisers.Where(x => x.Date.Year == DateMin.Year && x.Date.Month == DateMin.Month && x.Date.Day == DateMin.Day).ToList();
            List<LigneProductionUsine2> LigneProductionUsine2 = new List<LigneProductionUsine2>();
            LigneProductionUsine2 =db.LigneProductionUsine2.Where(x => x.DateCreation.Year == DateMin.Year && x.DateCreation.Month == DateMin.Month && x.DateCreation.Day == DateMin.Day).ToList();
           
            ligneProductionUsine2BindingSource.DataSource = LigneProductionUsine2;
            
        }

        private void FrmProduction2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TxtQunatite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
              
            }
        }

        private void FrmProduction2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
            }
        }
    }
}