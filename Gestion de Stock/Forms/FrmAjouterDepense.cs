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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterDepense : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private static FrmAjouterDepense _FrmDepense;


        public static FrmAjouterDepense InstanceFrmDepense
        {
            get
            {
                if (_FrmDepense == null)
                    _FrmDepense = new FrmAjouterDepense();
                return _FrmDepense;
            }
        }


        public FrmAjouterDepense()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmDepense_Load(object sender, EventArgs e)
        {
            /***********************  Nature Mouvement Liste  ***********************/

            dateDepense.EditValue = DateTime.Now;
            List<string> ListeNatureMVT = Enum.GetNames(typeof(NatureMouvement)).ToList();
            if (ListeNatureMVT != null)
            {
                foreach (var Nature in ListeNatureMVT)
                {
                    if (!Nature.Equals("Achat") && !Nature.Equals("ClôtureCaisse"))
                    {
                        comboBoxNature.Properties.Items.Add(Nature);
                    }

                }

                comboBoxNature.SelectedIndex = 0;
                if (ListeNatureMVT.Count > 0)
                    comboBoxNature.SelectedItem = ListeNatureMVT[0];

            }

            /**********************  Ouvrier Liste************************/
            salarierBindingSource.DataSource = db.Salariers.Select(x => new { x.Id, x.Intitule }).ToList();

            ///***********************  Mode  Paiement Liste  ***********************/
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).Where(x => !x.Equals("Remise")).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModePaie.Properties.Items.Add(M);
                }

                comboBoxModePaie.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                    comboBoxModePaie.SelectedItem = ModePaiement[0];

            }


            /***********************  Bnaque Liste  ***********************/
            List<string> ListeBanques = Enum.GetNames(typeof(SourceAlimentation)).ToList();

            if (ListeBanques != null)
            {
                foreach (var Source in ListeBanques)
                {
                    if (Source != "Service" && Source != "Vente")
                    {
                        comboBoxBank.Properties.Items.Add(Source);
                    }

                }

                comboBoxBank.SelectedIndex = 0;
                if (ListeBanques.Count > 0)
                    comboBoxBank.SelectedItem = ListeBanques[0];

            }

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null)
            {
                TxtSoldeCaisse.Text = CaisseDb.MontantTotal.ToString();

            }



        }

        private void FrmDepense_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDepense = null;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Depense D = new Depense();

            Salarier S = new Salarier();

            MouvementCaisse mvtCaisse = new MouvementCaisse();

            Coffrecheque Cheque = new Coffrecheque();

            Caisse CaisseDb = db.Caisse.Find(1);

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.ErrorText = "Montant est obligatoire";
                return;

            }






            #region Ajouter depense espéce

            D.DateDepense = dateDepense.DateTime;
            if (comboBoxModePaie.SelectedItem.ToString().Equals("Espèce"))
            {

                if (Montant > 0)
                {
                    if (CaisseDb.MontantTotal >= Montant)
                    {
                        if (comboBoxNature.SelectedItem.ToString().Equals("Salarié"))
                        {

                            if (string.IsNullOrEmpty(searchLookUpOuvrier.Text))
                            {
                                XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                                return;

                            }
                            GridView view = searchLookUpOuvrier.Properties.View;
                            int rowHandle = view.FocusedRowHandle;
                            string fieldName = "Id"; // or other field name  
                            object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);
                            if (SalarierSelected == null)
                            {
                                XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                searchLookUpOuvrier.Focus();
                                return;

                            }
                            else if (SalarierSelected != null)
                            {
                                int IdSalarier = Convert.ToInt32(SalarierSelected);
                                S = db.Salariers.Find(IdSalarier);

                            }
                            D.Nature = NatureMouvement.Salarié;

                            D.Salarie = S;
                            D.Tiers = S.Intitule;
                            D.CodeTiers = S.numero;
                            D.NomSalarier = S.Intitule;
                            D.Montant = Montant;
                            D.ModePaiement = "Espèce";
                            D.Commentaire = TxtCommentaire.Text;
                            db.Depenses.Add(D);
                            db.SaveChanges();
                            D.Numero = "D" + (D.Id).ToString("D8");
                            db.SaveChanges();
                            List<Depense> ListeDeponses = new List<Depense>();
                            ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                            List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                            ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                            S.MontantReglé = ListeDeponses.Sum(x => x.Montant);
                            db.SaveChanges();
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(TxtCommentaire.Text))
                            {
                                TxtCommentaire.ErrorText = "Commentaire est obligatoire";
                                return;

                            }
                            if (comboBoxNature.SelectedItem.ToString().Equals("Autre"))
                            {
                                D.Nature = NatureMouvement.Autre;
                            }
                            if (comboBoxNature.SelectedItem.ToString().Equals("STEG"))
                            {
                                D.Nature = NatureMouvement.STEG;
                            }
                       
                            D.Montant = Montant;
                            D.ModePaiement = "Espèce";
                            D.Commentaire = TxtCommentaire.Text;
                            db.Depenses.Add(D);
                            db.SaveChanges();
                            D.Numero = "D" + (D.Id).ToString("D8");
                            db.SaveChanges();

                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        TxtMontant.Text = string.Empty;
                        return;

                    }
                }
                else
                {
                    XtraMessageBox.Show("Montant est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    TxtMontant.Text = string.Empty;
                    return;

                }

            }


            #endregion


            #region Ajouter cheque dans coffre emis

            if (comboBoxNature.SelectedItem.ToString().Equals("Salarié") && comboBoxModePaie.SelectedIndex != 0)
            {

                if (string.IsNullOrEmpty(searchLookUpOuvrier.Text))
                {
                    XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }
                if (dateEchance.DateTime.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    XtraMessageBox.Show("Date Echance est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GridView view = searchLookUpOuvrier.Properties.View;
                int rowHandle = view.FocusedRowHandle;
                string fieldName = "Id"; // or other field name  
                object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);
                if (SalarierSelected == null)
                {
                    XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpOuvrier.Focus();
                    return;

                }
                else if (SalarierSelected != null)
                {
                    int IdSalarier = Convert.ToInt32(SalarierSelected);
                    S = db.Salariers.Find(IdSalarier);

                }
                // Controle Numèro de Cheque ou traite
                var ChequeDB = db.CoffreCheques.Where(x => x.NumCheque.Equals(TxtNumCheque.Text.Trim())).SingleOrDefault();
                if (ChequeDB != null)
                {
                    XtraMessageBox.Show("Numéro de chèque existe déjà dans la base de données", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Cheque.Nature = NatureMouvement.Salarié;
                if (comboBoxModePaie.SelectedItem.Equals("Chèque"))
                {
                    Cheque.ModePaiment = ModePaiment.cheque;

                }
                else if (comboBoxModePaie.SelectedItem.Equals("Traite"))
                {
                    Cheque.ModePaiment = ModePaiment.Traite;
                }

                Cheque.DateCreation = D.DateDepense;
                Cheque.NomSalarier = S.Intitule;

                Cheque.Montant = Montant;
                Cheque.NumCheque = TxtNumCheque.Text.Trim();

                if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                {
                    Cheque.Banque = SourceAlimentation.Zitouna.ToString();

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                {
                    Cheque.Banque = SourceAlimentation.BH.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                {
                    Cheque.Banque = SourceAlimentation.BNA.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("ATB"))
                {
                    Cheque.Banque = SourceAlimentation.ATB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                {
                    Cheque.Banque = SourceAlimentation.UIB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                {
                    Cheque.Banque = SourceAlimentation.Elbaraka.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                {
                    Cheque.Banque = SourceAlimentation.BIAT.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                {
                    Cheque.Banque = SourceAlimentation.Attijari.ToString();

                }
                else
                {
                    Cheque.Banque = comboBoxBank.SelectedItem.ToString();
                }

                Cheque.DateEcheance = dateEchance.DateTime;
                Cheque.Commentaire = TxtCommentaire.Text;
                db.CoffreCheques.Add(Cheque);
                db.SaveChanges();
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                S.MontantReglé = ListeDeponses.Sum(x => x.Montant);
                db.SaveChanges();
            }
            else if (comboBoxModePaie.SelectedIndex != 0)
            {
                if (dateEchance.DateTime.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    XtraMessageBox.Show("Date Echance est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBoxModePaie.SelectedItem.Equals("Chèque"))
                {
                    Cheque.ModePaiment = ModePaiment.cheque;

                }
                else if (comboBoxModePaie.SelectedItem.Equals("Traite"))
                {
                    Cheque.ModePaiment = ModePaiment.Traite;
                }
                // Controle Numèro de Cheque ou traite
                var ChequeDB = db.CoffreCheques.Where(x => x.NumCheque.Equals(TxtNumCheque.Text.Trim())).SingleOrDefault();
                if (ChequeDB != null)
                {
                    XtraMessageBox.Show("Numéro de chèque existe déjà dans la base de données", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Cheque.DateCreation = D.DateDepense;
                Cheque.Montant = Montant;
                Cheque.NumCheque = TxtNumCheque.Text;

                if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                {
                    Cheque.Banque = SourceAlimentation.Zitouna.ToString();

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                {
                    Cheque.Banque = SourceAlimentation.BH.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("ATB"))
                {
                    Cheque.Banque = SourceAlimentation.ATB.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                {
                    Cheque.Banque = SourceAlimentation.BNA.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                {
                    Cheque.Banque = SourceAlimentation.UIB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                {
                    Cheque.Banque = SourceAlimentation.Elbaraka.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                {
                    Cheque.Banque = SourceAlimentation.BIAT.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                {
                    Cheque.Banque = SourceAlimentation.Attijari.ToString(); ;

                }
                else
                {
                    Cheque.Banque = comboBoxBank.SelectedItem.ToString();
                }
                // Nature
                if (comboBoxNature.SelectedItem.ToString().Equals("Autre"))
                {
                    Cheque.Nature = NatureMouvement.Autre;
                }
                if (comboBoxNature.SelectedItem.ToString().Equals("STEG"))
                {
                    Cheque.Nature = NatureMouvement.STEG;
                }            
                Cheque.DateEcheance = dateEchance.DateTime;
                Cheque.Commentaire = TxtCommentaire.Text;
                db.CoffreCheques.Add(Cheque);
                db.SaveChanges();
            }


            #endregion


            #region Ajouter Mouvement caisse


            if (comboBoxModePaie.SelectedIndex == 0)
            {

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Date = D.DateDepense;

                mvtCaisse.MontantSens = Montant * -1;
                mvtCaisse.Sens = Sens.Depense;
                if (comboBoxNature.SelectedItem.ToString().Equals("Salarié"))
                {
                    mvtCaisse.Source = "Salarié : " + D.Salarie.Intitule;
                    mvtCaisse.Salarie = D.Salarie;
                    mvtCaisse.CodeTiers = D.Salarie.numero;
                }
                else
                {
                    mvtCaisse.Source = comboBoxNature.SelectedItem.ToString();
                }


                mvtCaisse.NatureDepense = D;
                mvtCaisse.Commentaire = D.Commentaire;

                CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, Montant);
                db.SaveChanges();

                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

            }




            #endregion
            XtraMessageBox.Show("Dépense Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<string> ListeNatureMVT = Enum.GetNames(typeof(NatureMouvement)).ToList();
            comboBoxNature.SelectedItem = ListeNatureMVT[0];
            List<string> ListeModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            comboBoxModePaie.SelectedItem = ListeModePaiement[0];
            searchLookUpOuvrier.EditValue = searchLookUpOuvrier.Properties.NullText;
            TxtMontant.Text = string.Empty;
            TxtCommentaire.Text = string.Empty;
            List<string> ListeBanques = Enum.GetNames(typeof(SourceAlimentation)).ToList();
            comboBoxBank.SelectedIndex = 0;
            if (ListeBanques.Count > 0)
                comboBoxBank.SelectedItem = ListeBanques[0];

            TxtNumCheque.Text = string.Empty;
            dateEchance.EditValue = null;
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
            if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == ChequeType.Emis).OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmListeDepenseSalarier>().FirstOrDefault() != null)
            {
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                Application.OpenForms.OfType<FrmListeDepenseSalarier>().First().depenseBindingSource.DataSource = ListeDeponses;

            }



            if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                if (db.MouvementsCaisse.Count() > 0)
                {

                    List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                    MouvementCaisse mvt = ListeMvtCaisse.Last();

                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = mvt.Montant.ToString();

                }
            }

            if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = db.Salariers.ToList();

        }
        private List<Depense> ConvertToListeDeponses(List<Coffrecheque> ListeCoffrecheque)
        {
            List<Depense> ListeDepense = new List<Depense>();
            foreach (var item in ListeCoffrecheque)
            {
                Depense depense = new Depense();
                depense.DateCreation = item.DateCreation;
                depense.Nature = item.Nature;
                depense.Montant = item.Montant;
                depense.ModePaiement = item.ModePaiment.ToString();
                depense.Banque = item.Banque;
                depense.NumCheque = item.NumCheque;
                depense.DateEcheance = item.DateEcheance;
                depense.NumVente = item.NumVente;
                depense.NumAchat = item.NumAchat;
                depense.NomSalarier = item.NomSalarier;
                depense.Frounisseur = item.Frounisseur;
                ListeDepense.Add(depense);

            }
            return ListeDepense;
        }
        private void TxtMontant_EditValueChanged(object sender, EventArgs e)
        {

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null && comboBoxModePaie.SelectedIndex == 0 && Montant < CaisseDb.MontantTotal)
            {
                TxtSoldeCaisse.Text = (CaisseDb.MontantTotal - Montant).ToString();

            }

            else
            {

                TxtSoldeCaisse.Text = CaisseDb.MontantTotal.ToString();
            }

        }

        private void comboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxNature.SelectedIndex == 0)
            { // Nature ouvrier

                layoutControlOuvrier.Visibility = LayoutVisibility.Always;




            }
            else
            {// Nature Autre
                layoutControlOuvrier.Visibility = LayoutVisibility.Never;


            }


            TxtCommentaire.Text = comboBoxNature.SelectedItem.ToString();


        }

        private void comboBoxModePaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModePaie.SelectedIndex != 0)
            {// cheque
                numCheque.Visibility = LayoutVisibility.Always;
                bank.Visibility = LayoutVisibility.Always;
                DateEcheance.Visibility = LayoutVisibility.Always;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Never;

            }

            else
            { // espece
                numCheque.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                DateEcheance.Visibility = LayoutVisibility.Never;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Always;
            }
        }
    }
}