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
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterReglementAchat : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAjouterReglementAchat _FrmAjouterReglementAchat;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;

        public static FrmAjouterReglementAchat InstanceFrmAjouterReglementAchat
        {
            get
            {
                if (_FrmAjouterReglementAchat == null)
                    _FrmAjouterReglementAchat = new FrmAjouterReglementAchat();
                return _FrmAjouterReglementAchat;
            }
        }


        public FrmAjouterReglementAchat()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }



        private void FrmAjouterReglementAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterReglementAchat = null;

        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            decimal MontantEncaisse;
            string MontantEncaisseStr = TxtMontantEncaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantEncaisseStr, out MontantEncaisse);
            Caisse CaisseDb = db.Caisse.Find(1);
            decimal MontantCaisse = CaisseDb.MontantTotal;

            #region   controle sur solde caisse
            if (comboBoxModePaiement.SelectedItem.ToString().Equals("Espèce") && (MontantEncaisse > MontantCaisse))
            {
               XtraMessageBox.Show("Solde Caisse est Insuffisant", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
               TxtMontantEncaisse.Text = string.Empty;
               return;
                
            }
            #endregion
        

            string CodeAchat = TxtCodeAchat.Text;


            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);


            var Achat = db.Achats.FirstOrDefault(x => x.Code.Equals(CodeAchat));

            if ((MontantEncaisse > Solde || MontantEncaisse <= 0))
            {
                XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }
            Achat.MontantRegle = decimal.Add(Achat.MontantRegle, MontantEncaisse);
            decimal MontantTotal = Achat.MontantReglement;
            db.SaveChanges();

            if (Achat.MontantRegle == MontantTotal && Achat.ResteApayer == 0)
            {
                Achat.EtatAchat = EtatAchat.Reglee;
            }

            else if (MontantEncaisse == 0 && MontantTotal == Achat.ResteApayer)
            {
                Achat.EtatAchat = EtatAchat.NonReglee;
            }


            else if (Achat.ResteApayer < MontantTotal && MontantTotal != 0 && Achat.ResteApayer != 0)
            {
                Achat.EtatAchat = EtatAchat.PartiellementReglee;
            }

            else if (MontantEncaisse == 0 && MontantTotal == 0)
            {
                Achat.EtatAchat = EtatAchat.NonReglee;
            }

            db.SaveChanges();



            #region Ajouter historique paiement achat
            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
            HP.codeFournisseur = Achat.CodeFournisseur;
            HP.IntituleFournisseur = Achat.RaisonSociale;
            HP.NumAchat = Achat.Code;
            HP.MontantReglement = Achat.MontantReglement;
            HP.MontantRegle = MontantEncaisse;
            HP.ResteApayer = Achat.ResteApayer;
            if (comboBoxModePaiement.SelectedItem.ToString().Equals("Espèce"))
            {
                HP.ModeReglement = ModeReglement.Espèce;
                HP.Coffre = false;
                HP.Commentaire = "Règlement Caisse";
            }
            else if (comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
            {
                HP.ModeReglement = ModeReglement.Chèque;
                HP.NumCheque = TxtNumCheque.Text;
                HP.Coffre = true;
                HP.DateEcheance = dateEcheance.DateTime;
                HP.Banque = TxtBank.Text;
                HP.Commentaire = "Règlement Chèque";
            }
            else if (comboBoxModePaiement.SelectedItem.ToString().Equals("Traite"))
            {
                HP.ModeReglement = ModeReglement.Traite;
                HP.NumCheque = TxtNumCheque.Text;
                HP.Coffre = true;
                HP.DateEcheance = dateEcheance.DateTime;
                HP.Banque = TxtBank.Text;
                HP.Commentaire = "Règlement Traite";
            }
           
            db.HistoriquePaiementAchats.Add(HP);
            db.SaveChanges();

            #endregion
            TxtMontantEncaisse.Text = string.Empty;
            this.Hide();
            if (comboBoxModePaiement.SelectedItem.ToString().Equals("Espèce"))
            {
                #region ajouter deponse        

                Depense D = new Depense();
                D.DateCreation = Achat.DateCreation;
                D.Nature = NatureMouvement.Achat;
                D.CodeFournisseur = Achat.CodeFournisseur;
                D.CodeTiers = Achat.CodeFournisseur;
                D.Tiers = Achat.RaisonSociale; 
                D.ModePaiement = "Espèce";
                D.Montant = MontantEncaisse;
                D.Commentaire = "Achat Fournisseur_Code :" +Achat.Code;
                db.Depenses.Add(D);
                db.SaveChanges();
                D.Numero = "D" + (D.Id).ToString("D8");
                db.SaveChanges();

                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MontantEncaisse * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Fournisseur = Achat.RaisonSociale;
                mvtCaisse.CodeTiers = Achat.CodeFournisseur;
                mvtCaisse.Date = Achat.DateCreation;
                mvtCaisse.Source = "Fournisseur: " + Achat.RaisonSociale; 
                mvtCaisse.Commentaire = "Achat Fournisseur :" + Achat.Code+" "+ Achat.RaisonSociale;
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantEncaisse);

                }

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                mvtCaisse.Achat = Achat;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();
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
                if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.ToList();
                #endregion
            }
            else
            {

                Coffrecheque coffrecheque = new Coffrecheque();
                if(comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
                {
                    coffrecheque.ModePaiment = ModePaiment.cheque;
                    coffrecheque.Commentaire = "Règlement Chèque";
                }
                if (comboBoxModePaiement.SelectedItem.ToString().Equals("Traite"))
                {
                    coffrecheque.ModePaiment = ModePaiment.Traite;
                    coffrecheque.Commentaire = "Règlement Traite";
                }
                coffrecheque.NumCheque = TxtNumCheque.Text;               
                coffrecheque.DateEcheance = dateEcheance.DateTime;
                coffrecheque.Banque = TxtBank.Text;
               
                coffrecheque.NumAchat = Achat.Code;
                coffrecheque.Frounisseur = Achat.RaisonSociale;               
                coffrecheque.Montant = MontantEncaisse;
                coffrecheque.ChequeType = ChequeType.Emis;
                db.CoffreCheques.Add(coffrecheque);
                db.SaveChanges();
                if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x=> x.ChequeType == ChequeType.Emis).ToList();


            }

            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();
            }



            XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


            


        }

        private void FrmAjouterReglementAchat_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtMontantEncaisse;
        }

        private void FrmAjouterReglementAchat_Load(object sender, EventArgs e)
        {
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModePaiement.Properties.Items.Add(M);
                }

                comboBoxModePaiement.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                    comboBoxModePaiement.SelectedItem = ModePaiement[0];

            }
        }

        private void comboBoxModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModePaiement.SelectedIndex == 1 || comboBoxModePaiement.SelectedIndex == 2)
            {
                layoutControlItem11.Visibility = LayoutVisibility.Always;
                layoutControlItem12.Visibility = LayoutVisibility.Always;
                layoutControlItem13.Visibility = LayoutVisibility.Always;
            }

            else if (comboBoxModePaiement.SelectedIndex == 0)
            {
                layoutControlItem11.Visibility = LayoutVisibility.Never;
                layoutControlItem12.Visibility = LayoutVisibility.Never;
                layoutControlItem13.Visibility = LayoutVisibility.Never;

            }
        }
    }


}