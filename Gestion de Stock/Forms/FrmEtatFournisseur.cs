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
    public partial class FrmEtatFournisseur : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatFournisseur _FrmEtatFournisseur;

        public static FrmEtatFournisseur InstanceFrmEtatFournisseur
        {
            get
            {
                if (_FrmEtatFournisseur == null)
                    _FrmEtatFournisseur = new FrmEtatFournisseur();
                return _FrmEtatFournisseur;
            }
        }
        public FrmEtatFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }



        private void FrmEtatFournisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatFournisseur = null;
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

        private void checkFournisseurs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFournisseurs.Checked)
            {
                searchLookUpFournisseur.ReadOnly = true;

            }

            else
            {
                searchLookUpFournisseur.ReadOnly = false;
            }
        }

        private void searchLookUpFournisseur_EditValueChanged(object sender, EventArgs e)
        {
            checkFournisseurs.ReadOnly = true;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();

            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            Fournisseur Fournisseur = new Fournisseur();

            List<Achat> ListeAchats = new List<Achat>();
            List<Achat> TousListeAchats = db.Achats.ToList();
            List<Achat> Tous = new List<Achat>();
            List<Achat> Regle = new List<Achat>();
            List<Achat> NonRegle = new List<Achat>();

            if (checkFournisseurs.Checked)
            {

                RapportEtatFournisseur RapportEtatFournisseurs = new RapportEtatFournisseur();

                List<Fournisseur> ListeFournisseurs = db.Fournisseurs.ToList();
                RapportEtatFournisseurs.Parameters["DateImpression"].Value = DateTime.Now;
                RapportEtatFournisseurs.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatFournisseurs.Parameters["Au"].Value = DateTime.Now;
                }
                else
                {
                    RapportEtatFournisseurs.Parameters["Au"].Value = datefin;
                }


                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    Tous = db.Achats.Where(x => x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                    Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                    NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                }

                else
                {
                    Tous = db.Achats.Where(x => x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                    Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                    NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                }


                if (radioBtnTous.Checked)
                {
                    ListeAchats = Tous;                   
                    RapportEtatFournisseurs.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                    RapportEtatFournisseurs.DataSource = ListeAchats;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseurs);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    ListeAchats = Regle;
                    RapportEtatFournisseurs.DataSource = ListeAchats;                   
                    RapportEtatFournisseurs.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseurs);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    ListeAchats = NonRegle;
                    RapportEtatFournisseurs.DataSource = ListeAchats;                  
                    RapportEtatFournisseurs.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseurs);
                    tool.ShowPreviewDialog();
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }
            }


            else
            {
                GridView view = searchLookUpFournisseur.Properties.View;
                int rowHandle = view.FocusedRowHandle;
                string fieldName = "Code"; // or other field name  
                object Fournisseurselected = view.GetRowCellValue(rowHandle, fieldName);

                if (Fournisseurselected == null && !checkFournisseurs.Checked)
                {
                    XtraMessageBox.Show("Choisir un Fournisseur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpFournisseur.Focus();
                    return;

                }

                if (Fournisseurselected != null && !checkFournisseurs.Checked)
                {

                    Fournisseur fournisseur = db.Fournisseurs.Find(Fournisseurselected.ToString());
                
                    TousListeAchats = TousListeAchats.Where(x => x.CodeFournisseur == Fournisseurselected.ToString()).ToList();
                    RapportEtatFournisseur RapportEtatFournisseur = new RapportEtatFournisseur();
                    RapportEtatFournisseur.Parameters["Fournisseur"].Value = fournisseur.RaisonSociale;
                    RapportEtatFournisseur.Parameters["Du"].Value = DateMin;

                    if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                    {
                        RapportEtatFournisseur.Parameters["Au"].Value = DateTime.Now;
                    }
                    else
                    {
                        RapportEtatFournisseur.Parameters["Au"].Value = datefin;
                    }
                  
                    RapportEtatFournisseur.Parameters["DateImpression"].Value = DateTime.Now;


                    if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                    {
                        Tous = db.Achats.Where(x => x.CodeFournisseur== Fournisseurselected.ToString() && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                        Regle = db.Achats.Where(x => x.CodeFournisseur == Fournisseurselected.ToString() && x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                        NonRegle = db.Achats.Where(x => x.CodeFournisseur == Fournisseurselected.ToString() && x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();

                    }

                    else
                    {
                        Tous = db.Achats.Where(x => x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                        Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                        NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

                    }


                    if (radioBtnTous.Checked)
                    {
                        
                        ListeAchats = Tous;
                        
                        RapportEtatFournisseur.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                        RapportEtatFournisseur.DataSource = ListeAchats;
                        ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseur);
                        tool.ShowPreviewDialog();

                    }

                    else if (radioBtnRegle.Checked)
                    {
                        ListeAchats = Regle;
                        RapportEtatFournisseur.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                        RapportEtatFournisseur.DataSource = ListeAchats;



                        ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseur);
                        tool.ShowPreviewDialog();
                    }

                    else if (radioBtnNonRegle.Checked)
                    {
                        ListeAchats = NonRegle;
                        RapportEtatFournisseur.Parameters["TotalSolde"].Value = TousListeAchats.Sum(x => x.ResteApayer);
                        RapportEtatFournisseur.DataSource = ListeAchats;



                        ReportPrintTool tool = new ReportPrintTool(RapportEtatFournisseur);
                        tool.ShowPreviewDialog();
                    }

                    else
                    {
                        XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        return;

                    }

                }
            }





        }

        private void FrmEtatFournisseur_Load(object sender, EventArgs e)
        {
            if (db.Fournisseurs.Count() > 0)
            {


                fournisseurBindingSource.DataSource = db.Fournisseurs.Select(x => new { x.Code, x.RaisonSociale, x.TelResponsable }).ToList();
                radioBtnTous.Checked = true;
            }
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        }

        private void FrmEtatFournisseur_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _FrmEtatFournisseur = null;
        }
    }
}