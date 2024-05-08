using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Repport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatAchat : DevExpress.XtraEditors.XtraForm
    {

        private Model.ApplicationContext db;

        private static FrmEtatAchat _FrmEtatAchat;

        public static FrmEtatAchat InstanceFrmEtatAchat
        {
            get
            {
                if (_FrmEtatAchat == null)
                {
                    _FrmEtatAchat = new FrmEtatAchat();
                }

                return _FrmEtatAchat;
            }
        }


        public FrmEtatAchat()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEtatAchat_Load(object sender, EventArgs e)
        {
            fournisseurBindingSource.DataSource = db.Fournisseurs.Select(x => new { x.Code, x.RaisonSociale }).ToList();
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void FrmEtatAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatAchat = null;
        }

        private void searchLookUpClient_EditValueChanged(object sender, EventArgs e)
        {
            checkTousFournisseurs.ReadOnly = true;
        }

        private void checkTousFournisseurs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTousFournisseurs.Checked)
            {
                searchLookUpFournisseur.ReadOnly = true;

            }

            else
            {
                searchLookUpFournisseur.ReadOnly = false;
            }
        }

        private void BtnImprimerEtat_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();

            RapportAchatHistorique RapportEtatAchat = new RapportAchatHistorique();

            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            Fournisseur fourn = new Fournisseur();


            List<Achat> ListeAchattous = new List<Achat>();
            List<Achat> ListeAchatRégle = new List<Achat>();
            List<Achat> ListeAchatNonRégle = new List<Achat>();

            List<RapportHistoriqueAchat> Tous = new List<RapportHistoriqueAchat>();
            List<RapportHistoriqueAchat> Regle = new List<RapportHistoriqueAchat>();
            List<RapportHistoriqueAchat> NonRegle = new List<RapportHistoriqueAchat>();

            GridView view = searchLookUpFournisseur.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object ClientSelected = view.GetRowCellValue(rowHandle, fieldName);


            List<RapportHistoriqueAchat> listeAchatHistorique = new List<RapportHistoriqueAchat>();
            List<HistoriquePaiementAchats> histListe = new List<HistoriquePaiementAchats>();
            if (ClientSelected != null && !checkTousFournisseurs.Checked)
            {
                histListe = db.HistoriquePaiementAchats.Where(x => x.codeFournisseur.Equals(ClientSelected.ToString())).ToList();
            }

            List<RapportHistoriqueAchat> listeAchatHistoriqueAchatNonRégle = new List<RapportHistoriqueAchat>();
            List<RapportHistoriqueAchat> listeAchatHistoriqueAchatRégle = new List<RapportHistoriqueAchat>();
            List<RapportHistoriqueAchat> ListeAchatHistoriquetous = new List<RapportHistoriqueAchat>();

            if (ClientSelected == null && !checkTousFournisseurs.Checked)
            {
                XtraMessageBox.Show("Choisir un fournisseur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpFournisseur.Focus();
                return;

            }



            else if (ClientSelected != null && !checkTousFournisseurs.Checked)
            {
                List<Achat> AchatsAnterieurs = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) < 0).ToList();

                Decimal SoldeAnterieur = AchatsAnterieurs.Sum(x => x.ResteApayer);

                RapportEtatAchat.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatAchat.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatAchat.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    RapportEtatAchat.Parameters["Au"].Value = datefin;
                }


                RapportEtatAchat.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {

                    ListeAchattous = db.Achats.Where(x => x.DateCreation >= DateMin && x.CodeFournisseur.Equals(ClientSelected.ToString())).ToList();


                    foreach (var Achat in ListeAchattous)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();

                        AchatHistorique.ID = Achat.id;

                        AchatHistorique.Achat = Achat;

                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        ListeAchatHistoriquetous.Add(AchatHistorique);
                    }


                    ListeAchatRégle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin && x.CodeFournisseur.Equals(ClientSelected.ToString())).OrderBy(x => x.DateCreation).ToList();

                    foreach (var Achat in ListeAchatRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatRégle.Add(AchatHistorique);
                    }

                    ListeAchatNonRégle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin && x.CodeFournisseur.Equals(ClientSelected.ToString())).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatNonRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatNonRégle.Add(AchatHistorique);
                    }
                }

                else
                {
                    ListeAchattous = db.Achats.Where(x => x.DateCreation >= DateMin && x.DateCreation <= datefin && x.CodeFournisseur.Equals(ClientSelected.ToString())).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchattous)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        ListeAchatHistoriquetous.Add(AchatHistorique);
                    }

                    ListeAchatRégle = db.Achats.Where(x => x.EtatAchat == Model.Enumuration.EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin && x.CodeFournisseur.Equals(ClientSelected.ToString())).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatRégle.Add(AchatHistorique);
                    }
                    ListeAchatNonRégle = db.Achats.Where(x => x.EtatAchat != Model.Enumuration.EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin && x.CodeFournisseur.Equals(ClientSelected.ToString())).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatNonRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatNonRégle.Add(AchatHistorique);
                    }
                }


                if (radioBtnTous.Checked)
                {
                    listeAchatHistorique = ListeAchatHistoriquetous;

                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);
                    RapportEtatAchat.DataSource = listeAchatHistorique;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    listeAchatHistorique = listeAchatHistoriqueAchatRégle;

                    RapportEtatAchat.DataSource = listeAchatHistorique;

                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + NonRegle.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    listeAchatHistorique = listeAchatHistoriqueAchatNonRégle;

                    RapportEtatAchat.DataSource = listeAchatHistorique;

                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
                    tool.ShowPreviewDialog();
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }


            }
            else if (ClientSelected == null && checkTousFournisseurs.Checked)
            {
                RapportEtatAchat.nomFournisseur.Visible=false;

                     histListe = db.HistoriquePaiementAchats.ToList();
                List<Achat> AchatsAnterieurs = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) < 0).ToList();

                Decimal SoldeAnterieur = AchatsAnterieurs.Sum(x => x.ResteApayer);

                RapportEtatAchat.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatAchat.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatAchat.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    RapportEtatAchat.Parameters["Au"].Value = datefin;
                }


                RapportEtatAchat.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {

                    ListeAchattous = db.Achats.Where(x => x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchattous)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        ListeAchatHistoriquetous.Add(AchatHistorique);
                    }




                    ListeAchatRégle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatRégle.Add(AchatHistorique);
                    }





                    ListeAchatNonRégle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatNonRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatNonRégle.Add(AchatHistorique);
                    }
                }

                else
                {

                    ListeAchattous = db.Achats.Where(x => x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchattous)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        ListeAchatHistoriquetous.Add(AchatHistorique);
                    }



                    ListeAchatRégle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatRégle.Add(AchatHistorique);
                    }


                    ListeAchatNonRégle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.DateCreation >= DateMin && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();
                    foreach (var Achat in ListeAchatNonRégle)
                    {
                        var AchatHistorique = new RapportHistoriqueAchat();
                        AchatHistorique.ID = Achat.id;
                        AchatHistorique.Achat = Achat;
                        AchatHistorique.HistoriquePaiementAchat = new List<HistoriquePaiementAchats>();

                        foreach (var hist in histListe)
                        {
                            if (hist.NumAchat == Achat.Code)
                            {
                                AchatHistorique.HistoriquePaiementAchat.Add(hist);
                            }
                        }

                        listeAchatHistoriqueAchatNonRégle.Add(AchatHistorique);
                    }
                }


                if (radioBtnTous.Checked)
                {
                    listeAchatHistorique = ListeAchatHistoriquetous;

                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);
                    RapportEtatAchat.DataSource = listeAchatHistorique;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    listeAchatHistorique = listeAchatHistoriqueAchatRégle;

                    RapportEtatAchat.DataSource = listeAchatHistorique;


                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    listeAchatHistorique = listeAchatHistoriqueAchatNonRégle;

                    RapportEtatAchat.DataSource = listeAchatHistorique;

                    RapportEtatAchat.Parameters["TotalCmd"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);

                    RapportEtatAchat.Parameters["TotalAvance"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);

                    RapportEtatAchat.Parameters["TotalSolde"].Value = listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeAchatHistorique.Sum(x => x.Achat.ResteApayer);

                    RapportEtatAchat.Parameters["TotalMtReg"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantRegle);
                    RapportEtatAchat.Parameters["TotalAchats"].Value = listeAchatHistorique.Sum(x => x.Achat.MontantReglement);
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatAchat);
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
}