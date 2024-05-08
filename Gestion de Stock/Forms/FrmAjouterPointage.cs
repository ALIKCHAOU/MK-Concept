using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterPointage : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterPointage _FrmAjouterPointage;

        public static FrmAjouterPointage InstanceFrmAjouterPointage
        {
            get
            {
                if (_FrmAjouterPointage == null)
                {
                    _FrmAjouterPointage = new FrmAjouterPointage();
                }

                return _FrmAjouterPointage;
            }
        }



        public FrmAjouterPointage()
        {
            db = new Model.ApplicationContext();
            InitializeComponent();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAjouterPointage_Load(object sender, EventArgs e)
        {

            salarierBindingSource.DataSource = db.Salariers.Select(x => new { x.Id, x.Intitule, x.Tel }).ToList();

            dateEditDatePointage.DateTime = DateTime.Now;
            List<string> ListePoste = new List<string> { "Jour", "Nuit" };
            foreach (var Poste in ListePoste)
            {
                comboBoxPoste.Properties.Items.Add(Poste);
            }
            comboBoxPoste.SelectedIndex = 0;
            comboBoxPoste.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtMontant.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;


        }



        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateEditDatePointage.Text))
            {
                dateEditDatePointage.ErrorText = "Date est obligatoire";
                return;
            }
            if (string.IsNullOrEmpty(comboBoxPoste.SelectedItem.ToString()))
            {
                comboBoxPoste.ErrorText = "Poste est obligatoire";
                return;
            }
            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.ErrorText = "Montant est obligatoire";
                return;
            }
            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);
            if (Montant <= 0)
            {
                TxtMontant.ErrorText = "Montant est Invalide";
                XtraMessageBox.Show("Montant est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;

            }

            Salarier S = new Salarier();

            GridView view = searchLookUpEditSalarier.Properties.View;
            //row manipulé
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id";
            object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (SalarierSelected == null)
            {
                XtraMessageBox.Show("Choisir un Salarié ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEditSalarier.Focus();
                return;

            }
            else
            {

                int IdSalarier = Convert.ToInt32(SalarierSelected);
                S = db.Salariers.Find(IdSalarier);
            }
            var currentday = dateEditDatePointage.DateTime;
            var pointageDbJour = db.PointagesJournalier.FirstOrDefault(x => x.Poste.Equals("Jour") && x.Salarier.Id == S.Id && x.Date.Day == currentday.Day && x.Date.Month == currentday.Month && x.Date.Year == currentday.Year);
            var pointageDbNuit = db.PointagesJournalier.FirstOrDefault(x => x.Poste.Equals("Nuit") && x.Salarier.Id == S.Id && x.Date.Day == currentday.Day && x.Date.Month == currentday.Month && x.Date.Year == currentday.Year);
            if (pointageDbNuit != null && comboBoxPoste.SelectedItem.ToString().Equals("Nuit"))
            {
                XtraMessageBox.Show("Pointage Nuit déja effectué", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pointageDbJour != null && comboBoxPoste.SelectedItem.ToString().Equals("Jour"))
            {
                XtraMessageBox.Show("Pointage Jour déja effectué", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pointageDbJour == null && comboBoxPoste.SelectedItem.Equals("Jour"))
            {
                PointageJournalier P = new PointageJournalier();
                P.Date = dateEditDatePointage.DateTime;
                P.Salarier = S;
                P.Poste = "Jour";
                P.Montant = Montant;
                db.PointagesJournalier.Add(P);
                S.Solde = decimal.Add(S.Solde, Montant);
                db.SaveChanges();

                // Mise Ajour Rgelement Salarier
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                S.MontantReglé = ListeDeponses.Sum(x => x.Montant);

                decimal MontantTotal = S.Solde;
                decimal MontantRegle = S.MontantReglé;
                decimal ResteAPayer = S.MontantRestReglé;

                if (MontantRegle == MontantTotal && MontantTotal != 0)
                {
                    S.EtatSalarie = EtatSalarie.Reglee;
                }

                else if (MontantRegle == 0 && MontantTotal == ResteAPayer)
                {
                    S.EtatSalarie = EtatSalarie.NonReglee;
                }


                else if (S.MontantRestReglé < MontantTotal && MontantTotal != 0 && ResteAPayer != 0)
                {
                    S.EtatSalarie = EtatSalarie.PartiellementReglee;
                }

                else if (MontantRegle == 0 && MontantTotal == 0)
                {
                    S.EtatSalarie = EtatSalarie.NonReglee;
                }


                db.SaveChanges();

                if (Application.OpenForms.OfType<FrmListePointages>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListePointages>().First().pointageJournalierBindingSource.DataSource = db.PointagesJournalier.ToList();
                }

                if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = db.Salariers.ToList();
                }

                XtraMessageBox.Show("Pointage Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            if (pointageDbNuit == null && comboBoxPoste.SelectedItem.Equals("Nuit"))
            {
                PointageJournalier P = new PointageJournalier();
                P.Date = dateEditDatePointage.DateTime;
                P.Salarier = S;
                P.Poste = "Nuit";
                P.Montant = Montant;
                db.PointagesJournalier.Add(P);
                S.Solde = decimal.Add(S.Solde, Montant);
                db.SaveChanges();
                // Mise Ajour Rgelement Salarier
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié && x.NomSalarier.Equals(S.Intitule)).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                S.MontantReglé = ListeDeponses.Sum(x => x.Montant);

                decimal MontantTotal = S.Solde;
                decimal MontantRegle = S.MontantReglé;
                decimal ResteAPayer = S.MontantRestReglé;

                if (MontantRegle == MontantTotal && MontantTotal != 0)
                {
                    S.EtatSalarie = EtatSalarie.Reglee;
                }

                else if (MontantRegle == 0 && MontantTotal == ResteAPayer)
                {
                    S.EtatSalarie = EtatSalarie.NonReglee;
                }


                else if (S.MontantRestReglé < MontantTotal && MontantTotal != 0 && ResteAPayer != 0)
                {
                    S.EtatSalarie = EtatSalarie.PartiellementReglee;
                }

                else if (MontantRegle == 0 && MontantTotal == 0)
                {
                    S.EtatSalarie = EtatSalarie.NonReglee;
                }


                db.SaveChanges();

                if (Application.OpenForms.OfType<FrmListePointages>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListePointages>().First().pointageJournalierBindingSource.DataSource = db.PointagesJournalier.OrderByDescending(x => x.Date).ToList();
                }

                if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = db.Salariers.ToList();
                }

                XtraMessageBox.Show("Pointage Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            searchLookUpEditSalarier.EditValue = searchLookUpEditSalarier.Properties.NullText;
            TxtMontant.Text = string.Empty;
            dateEditDatePointage.DateTime = DateTime.Now;

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

        private void FrmAjouterPointage_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterPointage = null;
        }

        private void searchLookUpEditSalarier_EditValueChanged(object sender, EventArgs e)
        {
            Salarier salarier = new Salarier();

            GridView view = searchLookUpEditSalarier.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);

            int salarierId = Convert.ToInt32(SalarierSelected);
            salarier = db.Salariers.Find(salarierId);

            TxtMontant.Text = salarier.MontantJournalie.ToString();



        }
    }
}