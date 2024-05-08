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
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatClient : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatClient _FrmEtatClient;

        public static FrmEtatClient InstanceFrmEtatClient
        {
            get
            {
                if (_FrmEtatClient == null)
                    _FrmEtatClient = new FrmEtatClient();
                return _FrmEtatClient;
            }
        }

        public FrmEtatClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }



        private void EtatClient_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Select(x => new { x.Code, x.RaisonSociale }).ToList();
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void FrmEtatClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatClient = null;
        }



        private void BtnImprimerEtat_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            RapportEtatClient RapportEtatClient = new RapportEtatClient();


            EtatTousLesClients EtatTousLesClients = new EtatTousLesClients();


            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            Client clt = new Client();

            List<Vente> ListeVente = new List<Vente>();

            List<Vente> Tous = new List<Vente>();
            List<Vente> Regle = new List<Vente>();
            List<Vente> NonRegle = new List<Vente>();

            GridView view = searchLookUpClient.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object ClientSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (ClientSelected == null && !checkTousClients.Checked)
            {
                XtraMessageBox.Show("Choisir un Client ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpClient.Focus();
                return;

            }
            else if (ClientSelected != null && !checkTousClients.Checked)
            {

               

                List<Vente> VentesAnterieurs = db.Vente.Where(x => x.Date < DateMin && x.NumClient.Equals(ClientSelected.ToString()) ).ToList();

                Decimal SoldeAnterieur = VentesAnterieurs.Sum(x => x.ResteApayer);

                RapportEtatClient.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatClient.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatClient.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    RapportEtatClient.Parameters["Au"].Value = datefin;
                }


                RapportEtatClient.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    Tous = db.Vente.Where(x => x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                    Regle = db.Vente.Where(x => x.EtatVente == Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                }

                else
                {
                    Tous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                    Regle = db.Vente.Where(x => x.EtatVente == Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                }


                if (radioBtnTous.Checked)
                {
                    ListeVente = Tous;

                    RapportEtatClient.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    RapportEtatClient.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    RapportEtatClient.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

                    RapportEtatClient.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);

                    RapportEtatClient.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

                    RapportEtatClient.DataSource = ListeVente;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatClient);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    ListeVente = Regle;

                    RapportEtatClient.DataSource = ListeVente;


                    RapportEtatClient.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    RapportEtatClient.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    RapportEtatClient.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

                    RapportEtatClient.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);

                    RapportEtatClient.Parameters["SoldeTotale"].Value = SoldeAnterieur + NonRegle.Sum(x => x.ResteApayer);

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatClient);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    ListeVente = NonRegle;

                    RapportEtatClient.DataSource = ListeVente;

                    RapportEtatClient.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    RapportEtatClient.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    RapportEtatClient.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

                    RapportEtatClient.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);

                    RapportEtatClient.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatClient);
                    tool.ShowPreviewDialog();
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }


            }
            else if (ClientSelected == null && checkTousClients.Checked)
            {
                List<Vente> VentesAnterieurs = db.Vente.Where(x => x.Date.CompareTo(DateMin) < 0).ToList();

                Decimal SoldeAnterieur = VentesAnterieurs.Sum(x => x.ResteApayer);

                EtatTousLesClients.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                EtatTousLesClients.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    EtatTousLesClients.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    EtatTousLesClients.Parameters["Au"].Value = datefin;
                }


                EtatTousLesClients.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    Tous = db.Vente.Where(x => x.Date >= DateMin).OrderBy(x => x.Date).ToList();

                    Regle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();

                }

                else
                {
                    Tous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                    Regle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                }


                if (radioBtnTous.Checked)
                {
                    ListeVente = Tous;

                    EtatTousLesClients.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    EtatTousLesClients.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    EtatTousLesClients.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);


                    EtatTousLesClients.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);
                    EtatTousLesClients.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

                    EtatTousLesClients.DataSource = ListeVente;

                    ReportPrintTool tool = new ReportPrintTool(EtatTousLesClients);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    ListeVente = Regle;

                    EtatTousLesClients.DataSource = ListeVente;


                    EtatTousLesClients.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    EtatTousLesClients.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    EtatTousLesClients.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);
                    EtatTousLesClients.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);
                    EtatTousLesClients.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

                    ReportPrintTool tool = new ReportPrintTool(EtatTousLesClients);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    ListeVente = NonRegle;

                    EtatTousLesClients.DataSource = ListeVente;



                    EtatTousLesClients.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

                    EtatTousLesClients.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

                    EtatTousLesClients.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

                    EtatTousLesClients.Parameters["TotalRemise"].Value = ListeVente.Sum(x => x.MontantRemise);

                    EtatTousLesClients.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

                    ReportPrintTool tool = new ReportPrintTool(EtatTousLesClients);
                    tool.ShowPreviewDialog();
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }

            }





        }

        private void checkTousClients_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTousClients.Checked)
            {
                searchLookUpClient.ReadOnly = true;

            }

            else
            {
                searchLookUpClient.ReadOnly = false;
            }
        }

        private void searchLookUpClient_EditValueChanged(object sender, EventArgs e)
        {
            checkTousClients.ReadOnly = true;
        }
    }
}