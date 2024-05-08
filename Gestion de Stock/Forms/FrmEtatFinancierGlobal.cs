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
    public partial class FrmEtatFinancierGlobal : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatFinancierGlobal _FrmEtatFinancierGlobal;

        public static FrmEtatFinancierGlobal InstanceFrmEtatFinancierGlobal
        {
            get
            {
                if (_FrmEtatFinancierGlobal == null)
                    _FrmEtatFinancierGlobal = new FrmEtatFinancierGlobal();
                return _FrmEtatFinancierGlobal;
            }
        }
        public FrmEtatFinancierGlobal()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }



        private void FrmEtatFinancierGlobal_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatFinancierGlobal = null;
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





        private void BtnImprimer_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();

            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            EtatFinancierGlobal RapportEtatFinancierGlobal = new EtatFinancierGlobal();
            RapportEtatFinancierGlobal.Parameters["Du"].Value = DateMin;
            RapportEtatFinancierGlobal.Parameters["DateImpression"].Value = DateTime.Now;

            List<Depense> ListeDeponsesSalarie = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié).ToList();
            List<Coffrecheque> ListCoffrechequesSalarie = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).ToList();
            ListeDeponsesSalarie.AddRange(ConvertToListeDeponses(ListCoffrechequesSalarie));

            List<Depense> ListeDeponsesLeasingCamion1 = db.Depenses.Where(x => x.Nature == NatureMouvement.LeasingCamion1).ToList();
            List<Coffrecheque> ListCoffrechequesLeasingCamion1 = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.LeasingCamion1).ToList();
            ListeDeponsesLeasingCamion1.AddRange(ConvertToListeDeponses(ListCoffrechequesLeasingCamion1));


            List<Depense> ListeDeponsesLeasingCamion2 = db.Depenses.Where(x => x.Nature == NatureMouvement.LeasingCamion2).ToList();
            List<Coffrecheque> ListCoffrechequeLeasingCamion2s = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.LeasingCamion2).ToList();
            ListeDeponsesLeasingCamion2.AddRange(ConvertToListeDeponses(ListCoffrechequeLeasingCamion2s));


            List<Depense> ListeDeponsesSTEG = db.Depenses.Where(x => x.Nature == NatureMouvement.STEG).ToList();
            List<Coffrecheque> ListCoffrechequesSTEG = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.STEG).ToList();
            ListeDeponsesSTEG.AddRange(ConvertToListeDeponses(ListCoffrechequesSTEG));

            List<Depense> ListeDeponsesPiece = db.Depenses.Where(x => x.Nature == NatureMouvement.Piece).ToList();
            List<Coffrecheque> ListCoffrechequePieces = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Piece).ToList();
            ListeDeponsesPiece.AddRange(ConvertToListeDeponses(ListCoffrechequePieces));


            List<Depense> ListeDeponsesAutre = db.Depenses.Where(x => x.Nature == NatureMouvement.Autre).ToList();
            List<Coffrecheque> ListCoffrechequeAutres = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Autre).ToList();
            ListeDeponsesAutre.AddRange(ConvertToListeDeponses(ListCoffrechequeAutres));

            List<Achat> ListeAchats = db.Achats.ToList();
            List<Vente> ListeVentes = db.Vente.ToList();

            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                ListeDeponsesSalarie = ListeDeponsesSalarie.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                    ListeDeponsesLeasingCamion1 = ListeDeponsesLeasingCamion1.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeDeponsesLeasingCamion2 = ListeDeponsesLeasingCamion2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeDeponsesSTEG = ListeDeponsesSTEG.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeDeponsesPiece = ListeDeponsesPiece.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeDeponsesAutre = ListeDeponsesAutre.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeAchats = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
                ListeVentes = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
                RapportEtatFinancierGlobal.Parameters["Au"].Value = DateTime.Now;

            }
            else
            {
                ListeDeponsesSalarie = ListeDeponsesSalarie.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeDeponsesLeasingCamion1 = ListeDeponsesLeasingCamion1.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeDeponsesLeasingCamion2 = ListeDeponsesLeasingCamion2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeDeponsesSTEG = ListeDeponsesSTEG.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeDeponsesPiece = ListeDeponsesPiece.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeDeponsesAutre = ListeDeponsesAutre.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeAchats = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(datefin) <= 0).ToList();
                ListeVentes = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(datefin) <= 0).ToList();
                RapportEtatFinancierGlobal.Parameters["Au"].Value = datefin;
            }
            RapportEtatFinancierGlobal.Parameters["Salarie"].Value = ListeDeponsesSalarie.Sum(x=>x.Montant);
            RapportEtatFinancierGlobal.Parameters["LeasingCamion1"].Value = ListeDeponsesLeasingCamion1.Sum(x => x.Montant);
            RapportEtatFinancierGlobal.Parameters["LeasingCamion2"].Value = ListeDeponsesLeasingCamion2.Sum(x => x.Montant);
            RapportEtatFinancierGlobal.Parameters["STEG"].Value = ListeDeponsesSTEG.Sum(x => x.Montant);
            RapportEtatFinancierGlobal.Parameters["Piece"].Value = ListeDeponsesPiece.Sum(x => x.Montant);
            RapportEtatFinancierGlobal.Parameters["Autre"].Value = ListeDeponsesAutre.Sum(x => x.Montant);
            // Achats
            RapportEtatFinancierGlobal.Parameters["TotaldesAchatsRegle"].Value = ListeAchats.Sum(x => x.MontantRegle);
            RapportEtatFinancierGlobal.Parameters["RestaReglèeAchats"].Value = ListeAchats.Sum(x => x.ResteApayer);
            RapportEtatFinancierGlobal.Parameters["TotaldesAchats"].Value = ListeAchats.Sum(x => x.MontantReglement);
            // Ventes
            RapportEtatFinancierGlobal.Parameters["TotaldesVentesRegle"].Value = ListeVentes.Sum(x => x.MontantRegle);
            RapportEtatFinancierGlobal.Parameters["RestaReglèeVentes"].Value = ListeVentes.Sum(x => x.ResteApayer);
            RapportEtatFinancierGlobal.Parameters["TotaldesVentes"].Value = ListeVentes.Sum(x => x.MontantReglement);
            /******************************** Solde Client ************************************/

        

            decimal SoldeClients = 0;

            if (ListeVentes != null)
            {
                SoldeClients = decimal.Divide(ListeVentes.Sum(x => x.ResteApayer), 1000) * -1;
            }

            RapportEtatFinancierGlobal.Parameters["SoldeClients"].Value = Math.Truncate(SoldeClients * 1000m) / 1000m;

            /******************************* Solde Caisse ***********************************/

            Caisse Caisse = db.Caisse.FirstOrDefault();

            RapportEtatFinancierGlobal.Parameters["SoldeCaisse"].Value = Math.Truncate(decimal.Divide(Caisse.MontantTotal, 1000) * 1000m) / 1000m; ;


            /******************************* Solde Fournisseurs ***********************************/

            
            decimal SoldeFournisseurs = 0;

            if (ListeVentes != null)
            {
                SoldeFournisseurs = decimal.Divide(ListeAchats.Sum(x => x.ResteApayer), 1000) ;

            }

            RapportEtatFinancierGlobal.Parameters["SoldeFournisseurs"].Value = Math.Truncate(SoldeFournisseurs * 1000m) / 1000m;

            ReportPrintTool tool = new ReportPrintTool(RapportEtatFinancierGlobal);
            tool.ShowPreviewDialog();






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
        private void FrmEtatFinancierGlobal_Load(object sender, EventArgs e)
        {

            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        }

        private void FrmEtatFinancierGlobal_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _FrmEtatFinancierGlobal = null;
        }

    }
}