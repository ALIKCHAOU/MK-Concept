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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Globalization;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatDepenseParNature : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatDepenseParNature _FrmEtatDepenseParNature;

        public static FrmEtatDepenseParNature InstanceFrmEtatDepenseParNature
        {
            get
            {
                if (_FrmEtatDepenseParNature == null)
                    _FrmEtatDepenseParNature = new FrmEtatDepenseParNature();
                return _FrmEtatDepenseParNature;
            }
        }
        public FrmEtatDepenseParNature()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }



        private void FrmEtatDepenseParNature_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatDepenseParNature = null;
        }


        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    

        private void searchLookUpFournisseur_EditValueChanged(object sender, EventArgs e)
        {
            checkTout.ReadOnly = true;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();

            DateTime DateMin = dateDebut.DateTime;
         
            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            EtatDepenseParNature RapportEtatDepenseParNature = new EtatDepenseParNature();
            RapportEtatDepenseParNature.Parameters["Du"].Value = DateMin;
            RapportEtatDepenseParNature.Parameters["DateImpression"].Value = DateTime.Now;
            List<Depense> ListeDeponses = new List<Depense>();

            if (checkTout.Checked)
            {
                ListeDeponses = db.Depenses.ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
            }
            else
            {
                if (searchLookUpFournisseur.Text == "Salarié")
                {
                    
                       ListeDeponses = db.Depenses.Where(x=>x.Nature==NatureMouvement.Salarié).ToList();
                       List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x=>x.Nature== NatureMouvement.Salarié).ToList();
                      ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
                if (searchLookUpFournisseur.Text == "LeasingCamion1")
                {
                    ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.LeasingCamion1).ToList();
                    List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.LeasingCamion1).ToList();
                    ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
                if (searchLookUpFournisseur.Text == "LeasingCamion2")
                {
                    ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.LeasingCamion2).ToList();
                    List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.LeasingCamion2).ToList();
                    ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
                if (searchLookUpFournisseur.Text == "STEG")
                {
                    ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.STEG).ToList();
                    List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.STEG).ToList();
                    ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
                if (searchLookUpFournisseur.Text == "Piece")
                {
                    ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Piece).ToList();
                    List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Piece).ToList();
                    ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
                if (searchLookUpFournisseur.Text == "Autre")
                {
                    ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Autre).ToList();
                    List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Autre).ToList();
                    ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                }
            }

            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                ListeDeponses = ListeDeponses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                RapportEtatDepenseParNature.Parameters["Au"].Value = DateTime.Now;

            }
            else
            {
                ListeDeponses = ListeDeponses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                RapportEtatDepenseParNature.Parameters["Au"].Value = datefin;
            }
          
            RapportEtatDepenseParNature.DataSource = ListeDeponses;

            ReportPrintTool tool = new ReportPrintTool(RapportEtatDepenseParNature);
            tool.ShowPreviewDialog();

        }

        private void FrmEtatDepenseParNature_Load(object sender, EventArgs e)
        {
            checkTout.Checked = true;
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

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
                depense.NumVente    = item.NumVente;
                depense.NumAchat    = item.NumAchat;
                depense.NomSalarier = item.NomSalarier;
                depense.Frounisseur = item.Frounisseur;
                ListeDepense.Add(depense);

            }
            return ListeDepense;
        }

        private void FrmEtatDepenseParNature_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _FrmEtatDepenseParNature = null;
        }
    }
}