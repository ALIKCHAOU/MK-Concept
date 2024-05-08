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
    public partial class FrmProductions : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmProductions _FrmProduction;
        public static FrmProductions InstanceFrmProduction
        {
            get
            {
                if (_FrmProduction == null)
                    _FrmProduction = new FrmProductions();
                return _FrmProduction;
            }
        }

        public FrmProductions()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }
       
        private void FrmProductions_Load(object sender, EventArgs e)
        {
            TxtNonConforme.Text = "0";
            TxtMettrage.Text = "100";
            DateProduction.DateTime = DateTime.Now;
            DateTime DateMin = DateTime.Now;
            List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
            ListeGridMatierePermier = db.listeMatierePermierUtilisers.Where(x => x.Date.Year == DateMin.Year && x.Date.Month == DateMin.Month && x.Date.Day == DateMin.Day).ToList();
            List<LigneProduction> LigneProduction = new List<LigneProduction>();
            LigneProduction=db.LigneProductions.Where(x => x.DateCreation.Year == DateMin.Year && x.DateCreation.Month == DateMin.Month && x.DateCreation.Day == DateMin.Day).ToList();
            listeMatierePermierUtiliserBindingSource.DataSource = ListeGridMatierePermier;
            ligneProductionBindingSource.DataSource = LigneProduction;
            bool Existe = db.Productions.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).Any();
            if (Existe)
            {
                TxtNonConforme.Text = db.Productions.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).FirstOrDefault().QuantiteNonconforme.ToString();
            }
            
            // Poste


            List<string> ListePoste = new List<string> { "Jour", "Nuit" };
            foreach (var Poste in ListePoste)
            {
                comboBoxPoste.Properties.Items.Add(Poste);
            }
            comboBoxPoste.SelectedIndex = 0;
            // Chaine
            List<string> ListeChaine = new List<string> { "Chaine1", "Chaine2" };
            foreach (var Chaine in ListeChaine)
            {
                comboBoxChaine.Properties.Items.Add(Chaine);
            }
            comboBoxChaine.SelectedIndex = 0;
            packBindingSource.DataSource = db.Packs.Select(x => new { x.Code, x.Designation }).ToList();
            matierePremiereBindingSource.DataSource = db.MatierePremieres.Select(x => new { x.Code, x.Nom, x.Description , x.Quantity }).ToList();
        }

        private void FrmProductions_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmProduction = null;
        }

        private void repositoryItemButtonEditSupprimer_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void repositoryItemButtonSupprimer_Click(object sender, EventArgs e)
        {
            gridView2.DeleteSelectedRows();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtMettrage.Text) || Convert.ToInt32(TxtMettrage.Text)==0)
            {
                TxtMettrage.ErrorText = "Mettrage est Invalide";
                XtraMessageBox.Show("'Mettrage est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            
               Article article = new Article();
            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandlea = view.FocusedRowHandle;
            string fieldName = "Designation"; // or other field name  
            object articleSelected = view.GetRowCellValue(rowHandlea, fieldName);
            ///Condition existance Fournisseur
            if (articleSelected == null)
            {
                XtraMessageBox.Show("Choisir un Article ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {

                article = db.Packs.FirstOrDefault(x => x.Designation.Equals(articleSelected.ToString()));
            }
            #region  Controle Qunatite
            if (String.IsNullOrEmpty(TxtPoids.Text))
            {
                TxtPoids.ErrorText = "Quantité   est obligatoire";
                XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            decimal Poids;
            string PoidsStr = TxtPoids.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PoidsStr, out Poids);
            if (Poids == 0)
            {
                TxtPoids.ErrorText = "Quantité   est Invalide";
                XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            
            #endregion 
            List<LigneProduction> ListeGrid = new List<LigneProduction>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as LigneProduction;               
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }

            LigneProduction ligneProduction = new LigneProduction();
            ligneProduction.Chaine = comboBoxChaine.Text;
            ligneProduction.DateCreation = DateProduction.DateTime;         
            ligneProduction.Poste = comboBoxPoste.Text;
            if (Convert.ToInt32(TxtMettrage.Text) < 100)
            {
                ligneProduction.NomArticle = article.Designation + " " + TxtMettrage.Text + "M";
            }
            else
            {
                ligneProduction.NomArticle = article.Designation;
            }
            ligneProduction.Quantite = 1;
            ligneProduction.Metrage = Convert.ToInt32(TxtMettrage.Text);
            ligneProduction.Poids = Poids;
            ListeGrid.Add(ligneProduction);
            ligneProductionBindingSource.DataSource = ListeGrid.ToList();
            TxtPoids.Text = string.Empty;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            decimal Qunatite;
            string QunatiteStr = TxtNonConforme.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QunatiteStr, out Qunatite);
         
            bool Existe = db.Productions.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).Any();
                 
            if (!Existe)
            {
                Production production = new Production();

                production.DateCreation = DateProduction.DateTime;               
                #region Matiere Permier
                List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
                int rowHandle1 = 0;
                while (gridView2.IsValidRowHandle(rowHandle1))
                {
                    var data = gridView2.GetRow(rowHandle1) as ListeMatierePermierUtiliser;
                    data.Date = DateProduction.DateTime;
                    ListeGridMatierePermier.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle1);
                    rowHandle1++;
                }
                if (ListeGridMatierePermier.Count() == 0)
                {
                    XtraMessageBox.Show("Liste Matiere Permier est Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var ligne in ListeGridMatierePermier)
                {
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(ligne.Nom));
                    if (matierePremiere.Quantity < ligne.Quantite)
                    {
                        XtraMessageBox.Show("Quantité de matière insuffisante : " + matierePremiere.Nom, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ligne.Code = matierePremiere.Code;
                    ligne.Date = DateProduction.DateTime;
                }
                #endregion
                #region Ligne Production
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }
                if (ListeGrid.Count() == 0)
                {
                    XtraMessageBox.Show("Liste Ligne Production est Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                production.LigneProductions = new List<LigneProduction>();
                production.LigneProductions.AddRange(ListeGrid);
                production.TotalPoids = ListeGrid.Sum(x => x.Poids);
                production.TotalArticle = ListeGrid.Count();


                production.ListeMatierePermierUtiliser = new List<ListeMatierePermierUtiliser>();
                production.ListeMatierePermierUtiliser.AddRange(ListeGridMatierePermier);
                production.QuantiteNonconforme = Qunatite;
                db.Productions.Add(production);
                db.SaveChanges();
                production.code = "P" + (production.Id).ToString("D8");
                db.SaveChanges();
                XtraMessageBox.Show("Enregisterment Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                TxtPoids.Text = string.Empty;
                // ajouter Qunatite Bargataire chute
                MatierePremiere Bargataire = db.MatierePremieres.Find(1);
                Bargataire.Quantity = decimal.Add(Bargataire.Quantity, Qunatite);
                db.SaveChanges();
                // waiting Form
                SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                }
                SplashScreenManager.CloseForm();
                //waiting Form 
                foreach (var L in ListeGridMatierePermier)
                {
                    #region Ajouter MVT Stock MatierePremiere

                    MouvementStockMatierePremiere MvtStock = new MouvementStockMatierePremiere();
                    int lastMvtStock = db.MouvementsStockMatierePremiere.ToList().Count() + 1;

                    MvtStock.Numero = "Sor" + (lastMvtStock).ToString("D8");
                    MvtStock.Date = production.DateCreation;
                    MvtStock.Sens = SensStock.Sortie;
                    MvtStock.Code = production.code;
                    MvtStock.Intitulé = production.code;
                    MvtStock.QuantiteAchetee = 0;
                    MvtStock.QuantiteUtilisee = L.Quantite;
                    // Matiere Premier 
                    MatierePremiere matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.Nom));
                    MvtStock.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock.QuantiteStockFinal = decimal.Subtract(MvtStock.QuantiteStockInitial, L.Quantite);
                    MvtStock.PrixMouvement = matierePremieredb.PrixMoyen;
                    MvtStock.Article = L.Nom;
                    MvtStock.Commentaire = "Production  N°" + " " + production.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock);
                    db.SaveChanges();
                    #endregion
                }
                // Substract  Liste Matiere Permier
                foreach (var ligne in ListeGridMatierePermier)
                {
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(ligne.Nom));
                    matierePremiere.Quantity = decimal.Subtract(matierePremiere.Quantity, ligne.Quantite);
                    db.SaveChanges();
                }
               
                // Ajouter Mouvement Article 
              
                List<LigneProduction> LigneProductions = production.LigneProductions.GroupBy(x => x.NomArticle).Select(gr =>
             
                 new LigneProduction  { NomArticle = gr.First().NomArticle, Quantite = gr.Count() ,Metrage= gr.First().Metrage,Poids=  gr.First().Poids }).ToList(); 
                foreach (var linge in LigneProductions)
                {
                    MouvementStockPack mouvementStockPack = new MouvementStockPack();
                    mouvementStockPack.Commentaire = "Pro N°" + " " + production.code;
                    mouvementStockPack.Intitulé = "Production";
                    mouvementStockPack.Numero = "Pro N° :" + production.code;
                    mouvementStockPack.QuantiteProduite = linge.Quantite;
                    mouvementStockPack.Sens = SensStock.Entree;
                    mouvementStockPack.Article = linge.NomArticle;
                    Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(linge.NomArticle));
                    if (Packdb!=null) {
                    mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                    mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial + linge.Quantite; 
                    Packdb.Quantity =  mouvementStockPack.QuantiteStockFinal;
                    mouvementStockPack.Date = production.DateCreation;
                    db.MouvementStockPacks.Add(mouvementStockPack);
                    db.SaveChanges();
                    mouvementStockPack.Code = "EN" + (mouvementStockPack.Id).ToString("D8");
                    db.SaveChanges();
                    }
                    else
                    {
                        Article Pack = new Article();
                        Pack.GereStock = true;
                        Pack.Designation = linge.NomArticle;
                        Pack.Quantity = 1;
                        Pack.Metrage = linge.Metrage;
                        Pack.TotalPoids= linge.Poids;
                        db.Packs.Add(Pack);
                        db.SaveChanges();
                        Pack.Code = "P" + (Pack.Id).ToString("D8");
                        db.SaveChanges();

                        ArticleChute articleChute = new ArticleChute();
                        articleChute.NomArticle = linge.NomArticle;
                        articleChute.Origine = "Production";
                        articleChute.Quantite = 1;                      
                        articleChute.Poids = linge.Poids;
                        articleChute.idArticle = Pack.Id;
                        articleChute.Metrage = linge.Metrage;
                        articleChute.Code = Pack.Code;
                        db.ArticleChutes.Add(articleChute);
                        db.SaveChanges();
                        Pack.IdArticlechute = articleChute.Id;
                        db.SaveChanges();
                    }
                }
                // Alimentation de stock MouvementStockMatierePremiere
               
                if (Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().First().mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.ToList();
                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.ToList(); ;
                }
                if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                    Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
                }
                if (Application.OpenForms.OfType<FrmArticleChutes>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmArticleChutes>().FirstOrDefault().articleChuteBindingSource.DataSource = db.ArticleChutes.ToList();


                
            }
            else
            {
               
                Production productionDb = db.Productions.Include("LigneProductions").Include("ListeMatierePermierUtiliser").Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).FirstOrDefault();

                #region Ligne Production
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }
                if (ListeGrid.Count() == 0)
                {
                    XtraMessageBox.Show("Liste Ligne Production est Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                List<LigneProduction>  LigneProductionsDb = new List<LigneProduction>();
                LigneProductionsDb = productionDb.LigneProductions.ToList();
                foreach (var ligne in LigneProductionsDb)
                {
                    LigneProduction L = db.LigneProductions.Find(ligne.Id);
                    db.LigneProductions.Remove(L);
                    db.SaveChanges();
                }

                productionDb.LigneProductions.AddRange(ListeGrid);
                #region ListeMatierePermierUtiliser
                List<ListeMatierePermierUtiliser> ListeMatierePermierUtiliserDB = new List<ListeMatierePermierUtiliser>();
                ListeMatierePermierUtiliserDB = productionDb.ListeMatierePermierUtiliser.ToList();
                foreach (var ligne in ListeMatierePermierUtiliserDB)
                {
                    ListeMatierePermierUtiliser L = db.listeMatierePermierUtilisers.Find(ligne.Id);
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(ligne.Nom));
                    matierePremiere.Quantity = decimal.Add(matierePremiere.Quantity, ligne.Quantite);
                    db.SaveChanges();
                    db.listeMatierePermierUtilisers.Remove(L);
                    db.SaveChanges();
                }
                #region Matiere Permier
                List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
                int rowHandle1 = 0;
                while (gridView2.IsValidRowHandle(rowHandle1))
                {
                    var data = gridView2.GetRow(rowHandle1) as ListeMatierePermierUtiliser;
                    data.Date = DateProduction.DateTime;
                    ListeGridMatierePermier.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle1);
                    rowHandle1++;
                }
                if (ListeGridMatierePermier.Count() == 0)
                {
                    XtraMessageBox.Show("Liste Matiere Permier est Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var ligne in ListeGridMatierePermier)
                {
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(ligne.Nom));
                    if (matierePremiere.Quantity < ligne.Quantite)
                    {
                        XtraMessageBox.Show("Quantité de matière insuffisante : " + matierePremiere.Nom, "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ligne.Code = matierePremiere.Code;
                    ligne.Date = DateProduction.DateTime;
                }
                #endregion
                productionDb.ListeMatierePermierUtiliser.AddRange(ListeGridMatierePermier);
                #endregion
                productionDb.TotalPoids = ListeGrid.Sum(x => x.Poids);
                productionDb.TotalArticle = ListeGrid.Count();
                db.SaveChanges();
                XtraMessageBox.Show("Mise a jour Production Terminer ", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Substract  Liste Matiere Permier
                List<MouvementStockMatierePremiere> ListmouvementStockMatierePremieredb = new List<MouvementStockMatierePremiere>();

                ListmouvementStockMatierePremieredb = db.MouvementsStockMatierePremiere.Where(x => x.Code.Equals(productionDb.code)).ToList();

                foreach (var Linge in ListmouvementStockMatierePremieredb)
                {
                    MouvementStockMatierePremiere mouvementdb = db.MouvementsStockMatierePremiere.Find(Linge.Id);
                    db.MouvementsStockMatierePremiere.Remove(mouvementdb);
                    db.SaveChanges();
                }


                foreach (var L in ListeGridMatierePermier)
                {
                    #region Ajouter MVT Stock

                    MouvementStockMatierePremiere MvtStock = new MouvementStockMatierePremiere();
                    int lastMvtStock = db.MouvementsStockMatierePremiere.ToList().Count() + 1;

                    MvtStock.Numero = "Sor" + (lastMvtStock).ToString("D8");
                    MvtStock.Date = productionDb.DateCreation;
                    MvtStock.Sens = SensStock.Sortie;
                    MvtStock.Code = productionDb.code;
                    MvtStock.Intitulé = productionDb.code;
                    MvtStock.QuantiteAchetee = 0;
                    MvtStock.QuantiteUtilisee = L.Quantite;
                    // Matiere Premier 
                    MatierePremiere matierePremieredb = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(L.Nom));
                    MvtStock.QuantiteStockInitial = matierePremieredb.Quantity;
                    MvtStock.QuantiteStockFinal = decimal.Subtract(MvtStock.QuantiteStockInitial, L.Quantite);
                    MvtStock.PrixMouvement = matierePremieredb.PrixMoyen;
                    MvtStock.Article = L.Nom;
                    MvtStock.Commentaire = "Production  N°" + " " + productionDb.code;
                    db.MouvementsStockMatierePremiere.Add(MvtStock);
                    db.SaveChanges();
                    #endregion
                }
                foreach (var ligne in ListeGridMatierePermier)
                {
                    MatierePremiere matierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Nom.Equals(ligne.Nom));
                    matierePremiere.Quantity = decimal.Subtract(matierePremiere.Quantity, ligne.Quantite);
                    db.SaveChanges();
                }

                // mettre a jour Stock
                
                DateTime DateMin = productionDb.DateCreation;
                DateTime DateMaxJour = productionDb.DateCreation.Date.AddDays(1).AddSeconds(-1);
                List<MouvementStockPack> mouvementStockPacksDB = new List<MouvementStockPack>();
                mouvementStockPacksDB = db.MouvementStockPacks.Where(x =>x.Sens==SensStock.Entree && x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();

                foreach (var linge in mouvementStockPacksDB)
                {
                    MouvementStockPack mouvementStockPack = db.MouvementStockPacks.Find(linge.Id);
                    db.MouvementStockPacks.Remove(mouvementStockPack);
                    db.SaveChanges();
                    Article Article = db.Packs.FirstOrDefault(x => x.Designation.Equals(linge.Article));
                    Article.Quantity = Article.Quantity - linge.QuantiteProduite;
                    db.SaveChanges();
                }
                // remove article and articleChutes
                List<ArticleChute> articleChutes=  db.ArticleChutes.Where(x=>x.Origine.Equals("Production")).ToList();
                foreach (var item in articleChutes)
                {
                    Article Pack = new Article();
                    Pack = db.Packs.Find(item.idArticle);
                    db.Packs.Remove(Pack);
                    db.SaveChanges();
                    ArticleChute ArticleChute = new ArticleChute();
                    ArticleChute = db.ArticleChutes.Find(item.Id);
                    db.ArticleChutes.Remove(ArticleChute);
                    db.SaveChanges();
                }
                // remove article and articleChutes


                // ajouter Mouvement stock Pack
                List<LigneProduction> LigneProductions = productionDb.LigneProductions.GroupBy(x => x.NomArticle).Select(gr =>

                  new LigneProduction { NomArticle = gr.First().NomArticle, Quantite = gr.Count(), Metrage = gr.First().Metrage, Poids = gr.First().Poids }).ToList();
                foreach (var linge in LigneProductions)
                {
                    MouvementStockPack mouvementStockPack = new MouvementStockPack();
                    mouvementStockPack.Commentaire = "Pro N° :" + " " + productionDb.code;
                    mouvementStockPack.Intitulé = "Production";
                    mouvementStockPack.Numero = "Pro N° : "+ productionDb.code; 
                    mouvementStockPack.QuantiteProduite = Convert.ToInt32(linge.Quantite);
                    mouvementStockPack.Sens = SensStock.Entree;
                    mouvementStockPack.Article = linge.NomArticle;
                    Article Packdb = db.Packs.FirstOrDefault(x => x.Designation.Equals(linge.NomArticle));
                    if (Packdb != null) { 
                    mouvementStockPack.QuantiteStockInitial = Packdb.Quantity;
                    mouvementStockPack.QuantiteStockFinal = mouvementStockPack.QuantiteStockInitial + linge.Quantite;
                    Packdb.Quantity = mouvementStockPack.QuantiteStockFinal;
                    mouvementStockPack.Date = productionDb.DateCreation;
                    db.MouvementStockPacks.Add(mouvementStockPack);
                    db.SaveChanges();
                    mouvementStockPack.Code = "EN" + (mouvementStockPack.Id).ToString("D8");
                    db.SaveChanges();
                    }
                    else
                    {
                        Article Pack = new Article();
                        Pack.GereStock = true;
                        Pack.Designation = linge.NomArticle;
                        Pack.Quantity = 1;
                        Pack.TotalPoids = linge.Poids;
                        Pack.Metrage = linge.Metrage;
                        db.Packs.Add(Pack);
                        db.SaveChanges();
                        Pack.Code = "P" + (Pack.Id).ToString("D8");
                        db.SaveChanges();

                        ArticleChute articleChute = new ArticleChute();
                        articleChute.NomArticle = linge.NomArticle;
                        articleChute.Origine = "Production";
                        articleChute.Quantite = 1;
                        articleChute.Poids = linge.Poids;
                        articleChute.idArticle = Pack.Id;
                        articleChute.Metrage = linge.Metrage;
                        articleChute.Code = Pack.Code;
                        db.ArticleChutes.Add(articleChute);
                        db.SaveChanges();
                        Pack.IdArticlechute = articleChute.Id;
                        db.SaveChanges();
                    }
                }
                if (Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMouvementStockMatierePremiere>().First().mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.ToList();
                if (Application.OpenForms.OfType<FrmMvtStockPack>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMvtStockPack>().First().mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.OrderByDescending(x => x.Date).ToList(); ;
                }
                // mettre a jour Stock
            }
            if (Application.OpenForms.OfType<FrmMatierePremiere>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmMatierePremiere>().First().matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();
            if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
            }

            if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                 Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.OrderByDescending(x => x.DateCreation).ToList();



        }

        private void DateProduction_EditValueChanged(object sender, EventArgs e)
        {
             
            DateTime DateMin = DateProduction.DateTime;
            List<ListeMatierePermierUtiliser> ListeGridMatierePermier = new List<ListeMatierePermierUtiliser>();
            ListeGridMatierePermier = db.listeMatierePermierUtilisers.Where(x => x.Date.Year == DateMin.Year && x.Date.Month == DateMin.Month && x.Date.Day == DateMin.Day).ToList();
            List<LigneProduction> LigneProduction = new List<LigneProduction>();
            LigneProduction = db.LigneProductions.Where(x => x.DateCreation.Year == DateMin.Year && x.DateCreation.Month == DateMin.Month && x.DateCreation.Day == DateMin.Day).ToList();
            listeMatierePermierUtiliserBindingSource.DataSource = ListeGridMatierePermier;
            ligneProductionBindingSource.DataSource = LigneProduction;
            bool Existe = db.Productions.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).Any();
            if (Existe)
            {
                TxtNonConforme.Text = db.Productions.Where(x => x.DateCreation.Year == DateProduction.DateTime.Year && x.DateCreation.Month == DateProduction.DateTime.Month && x.DateCreation.Day == DateProduction.DateTime.Day).FirstOrDefault().QuantiteNonconforme.ToString();
            }
        }

        private void FrmProductions_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void TxtQunatite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Article article = new Article();
                GridView view = searchLookUpEdit1.Properties.View;
                int rowHandlea = view.FocusedRowHandle;
                string fieldName = "Designation"; // or other field name  
                object articleSelected = view.GetRowCellValue(rowHandlea, fieldName);
                ///Condition existance Fournisseur
                if (articleSelected == null)
                {
                    XtraMessageBox.Show("Choisir un Article ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpEdit1.Focus();
                    return;

                }
                else
                {

                    article = db.Packs.FirstOrDefault(x => x.Designation.Equals(articleSelected.ToString()));
                }
                #region  Controle Qunatite
                if (String.IsNullOrEmpty(TxtPoids.Text))
                {
                    TxtPoids.ErrorText = "Quantité   est obligatoire";
                    XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;

                }
                decimal Qunatite;
                string QunatiteStr = TxtPoids.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QunatiteStr, out Qunatite);
                if (Qunatite == 0)
                {
                    TxtPoids.ErrorText = "Quantité   est Invalide";
                    XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;

                }

                #endregion
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }

                LigneProduction ligneProduction = new LigneProduction();
                ligneProduction.Chaine = comboBoxChaine.Text;
                ligneProduction.DateCreation = DateProduction.DateTime;
                ligneProduction.Poste = comboBoxPoste.Text;
                ligneProduction.NomArticle = article.Designation;
                ligneProduction.Quantite = 1;
                ligneProduction.Poids = Qunatite;
                ListeGrid.Add(ligneProduction);
                ligneProductionBindingSource.DataSource = ListeGrid.ToList();
                TxtPoids.Text = string.Empty;
            }
        }

        private void FrmProductions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Article article = new Article();
                GridView view = searchLookUpEdit1.Properties.View;
                int rowHandlea = view.FocusedRowHandle;
                string fieldName = "Designation"; // or other field name  
                object articleSelected = view.GetRowCellValue(rowHandlea, fieldName);
                ///Condition existance Fournisseur
                if (articleSelected == null)
                {
                    XtraMessageBox.Show("Choisir un Article ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpEdit1.Focus();
                    return;

                }
                else
                {

                    article = db.Packs.FirstOrDefault(x => x.Designation.Equals(articleSelected.ToString()));
                }
                #region  Controle Qunatite
                if (String.IsNullOrEmpty(TxtPoids.Text))
                {
                    TxtPoids.ErrorText = "Quantité   est obligatoire";
                    XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;

                }
                decimal Qunatite;
                string QunatiteStr = TxtPoids.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QunatiteStr, out Qunatite);
                if (Qunatite == 0)
                {
                    TxtPoids.ErrorText = "Quantité   est Invalide";
                    XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;

                }

                #endregion
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;
                while (gridView1.IsValidRowHandle(rowHandle))
                {
                    var data = gridView1.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandle);
                    rowHandle++;
                }

                LigneProduction ligneProduction = new LigneProduction();
                ligneProduction.Chaine = comboBoxChaine.Text;
                ligneProduction.DateCreation = DateProduction.DateTime;
                ligneProduction.Poste = comboBoxPoste.Text;
                ligneProduction.NomArticle = article.Designation;
                ligneProduction.Quantite = 1;
                ligneProduction.Poids = Qunatite;
                ListeGrid.Add(ligneProduction);
                ligneProductionBindingSource.DataSource = ListeGrid.ToList();
                TxtPoids.Text = string.Empty;
            }
        }
    }
}