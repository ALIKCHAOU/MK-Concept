
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
    public partial class FrmEtatVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatVente _FrmEtatVente;

        public static FrmEtatVente InstanceFrmEtatVente
        {
            get
            {
                if (_FrmEtatVente == null)
                {
                    _FrmEtatVente = new FrmEtatVente();
                }

                return _FrmEtatVente;
            }
        }

        public FrmEtatVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }







        //private void BtnImprimerEtat_Click(object sender, EventArgs e)
        //{
        //    db = new Model.ApplicationContext();

        //    RapportEtatVente RapportEtatVente = new RapportEtatVente();



        //    DateTime DateMin = dateDebut.DateTime;

        //    DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

        //    Client clt = new Client();

        //    List<Vente> ListeVente = new List<Vente>();

        //    List<Vente> Tous = new List<Vente>();
        //    List<Vente> Regle = new List<Vente>();
        //    List<Vente> NonRegle = new List<Vente>();

        //    GridView view = searchLookUpClient.Properties.View;
        //    int rowHandle = view.FocusedRowHandle;
        //    string fieldName = "Code"; // or other field name  
        //    object ClientSelected = view.GetRowCellValue(rowHandle, fieldName);

        //    if (ClientSelected == null && !checkTousClients.Checked)
        //    {
        //        XtraMessageBox.Show("Choisir un Client ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        //        searchLookUpClient.Focus();
        //        return;

        //    }
        //    else if (ClientSelected != null && !checkTousClients.Checked)
        //    {



        //        List<Vente> VentesAnterieurs = db.Vente.Where(x => x.Date < DateMin && x.NumClient.Equals(ClientSelected.ToString()) ).ToList();

        //        Decimal SoldeAnterieur = VentesAnterieurs.Sum(x => x.ResteApayer);

        //        RapportEtatVente.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

        //        RapportEtatVente.Parameters["Du"].Value = DateMin;

        //        if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
        //        {
        //            RapportEtatVente.Parameters["Au"].Value = DateTime.Now;
        //        }

        //        else
        //        {
        //            RapportEtatVente.Parameters["Au"].Value = datefin;
        //        }


        //        RapportEtatVente.Parameters["DateImpression"].Value = DateTime.Now;

        //        if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
        //        {
        //            Tous = db.Vente.Where(x => x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //            Regle = db.Vente.Where(x => x.EtatVente == Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //            NonRegle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //        }

        //        else
        //        {
        //            Tous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //            Regle = db.Vente.Where(x => x.EtatVente == Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //            NonRegle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

        //        }


        //        if (radioBtnTous.Checked)
        //        {
        //            ListeVente = Tous;

        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);



        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

        //            RapportEtatVente.DataSource = ListeVente;

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();

        //        }

        //        else if (radioBtnRegle.Checked)
        //        {
        //            ListeVente = Regle;

        //            RapportEtatVente.DataSource = ListeVente;


        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);



        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + NonRegle.Sum(x => x.ResteApayer);

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();
        //        }

        //        else if (radioBtnNonRegle.Checked)
        //        {
        //            ListeVente = NonRegle;

        //            RapportEtatVente.DataSource = ListeVente;

        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);



        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();
        //        }

        //        else
        //        {
        //            XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

        //            return;

        //        }


        //    }
        //    else if (ClientSelected == null && checkTousClients.Checked)
        //    {
        //        List<Vente> VentesAnterieurs = db.Vente.Where(x => x.Date.CompareTo(DateMin) < 0).ToList();

        //        Decimal SoldeAnterieur = VentesAnterieurs.Sum(x => x.ResteApayer);

        //        RapportEtatVente.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

        //        RapportEtatVente.Parameters["Du"].Value = DateMin;

        //        if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
        //        {
        //            RapportEtatVente.Parameters["Au"].Value = DateTime.Now;
        //        }

        //        else
        //        {
        //            RapportEtatVente.Parameters["Au"].Value = datefin;
        //        }


        //        RapportEtatVente.Parameters["DateImpression"].Value = DateTime.Now;

        //        if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
        //        {
        //            Tous = db.Vente.Where(x => x.Date >= DateMin).OrderBy(x => x.Date).ToList();

        //            Regle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();

        //            NonRegle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();

        //        }

        //        else
        //        {
        //            Tous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

        //            Regle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

        //            NonRegle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

        //        }


        //        if (radioBtnTous.Checked)
        //        {
        //            ListeVente = Tous;

        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);



        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

        //            RapportEtatVente.DataSource = ListeVente;

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();

        //        }

        //        else if (radioBtnRegle.Checked)
        //        {
        //            ListeVente = Regle;

        //            RapportEtatVente.DataSource = ListeVente;


        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();
        //        }

        //        else if (radioBtnNonRegle.Checked)
        //        {
        //            ListeVente = NonRegle;

        //            RapportEtatVente.DataSource = ListeVente;



        //            RapportEtatVente.Parameters["TotalCmd"].Value = ListeVente.Sum(x => x.MontantReglement);

        //            RapportEtatVente.Parameters["TotalAvance"].Value = ListeVente.Sum(x => x.MontantRegle);

        //            RapportEtatVente.Parameters["TotalSolde"].Value = ListeVente.Sum(x => x.ResteApayer);

        //            RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + ListeVente.Sum(x => x.ResteApayer);

        //            ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
        //            tool.ShowPreviewDialog();
        //        }

        //        else
        //        {
        //            XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

        //            return;

        //        }

        //    }





        //}

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




        private void BtnImprimerEtat_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            RapportVenteHistorique RapportEtatVente = new RapportVenteHistorique();

            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            Client clt = new Client();

            List<Vente> ListeVentetous = new List<Vente>();
            List<Vente> ListeVenteRégle = new List<Vente>();
            List<Vente> ListeVenteNonRégle = new List<Vente>();
            List<venteHistoriqueP> Tous = new List<venteHistoriqueP>();
            List<venteHistoriqueP> Regle = new List<venteHistoriqueP>();
            List<venteHistoriqueP> NonRegle = new List<venteHistoriqueP>();
            List<HistoriquePaiementVente> HistoriqueRemise = new List<HistoriquePaiementVente>();
            List<HistoriquePaiementVente> HistoriqueRemiseTout = new List<HistoriquePaiementVente>();
            

            GridView view = searchLookUpClient.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object ClientSelected = view.GetRowCellValue(rowHandle, fieldName);

            List<Vente> VentesListe = new List<Vente>();
            List<HistoriquePaiementVente> histListe = new List<HistoriquePaiementVente>();
            if (ClientSelected != null)
            {
                VentesListe = db.Vente.Where(x => x.Date < DateMin && x.NumClient.Equals(ClientSelected.ToString())).ToList();
                histListe = db.HistoriquePaiementVente.Where(x => x.NumClient.Equals(ClientSelected.ToString())).ToList();
            }

            List<venteHistoriqueP> listeventeHistorique = new List<venteHistoriqueP>();

            List<venteHistoriqueP> listeventeHistoriqueVenteNonRégle = new List<venteHistoriqueP>();
            List<venteHistoriqueP> listeventeHistoriqueVenteRégle = new List<venteHistoriqueP>();
            List<venteHistoriqueP> ListeVenteHistoriquetous = new List<venteHistoriqueP>();


            if (ClientSelected == null && !checkTousClients.Checked)
            {
                XtraMessageBox.Show("Choisir un Client ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpClient.Focus();
                return;

            }



            else if (ClientSelected != null && !checkTousClients.Checked)
            {

                ListeVentetous = db.Vente.Where(x => x.Date < DateMin && x.NumClient.Equals(ClientSelected.ToString())).ToList();

                Decimal SoldeAnterieur = VentesListe.Sum(x => x.ResteApayer);

                RapportEtatVente.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatVente.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatVente.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    RapportEtatVente.Parameters["Au"].Value = datefin;
                }


                RapportEtatVente.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {

                    ListeVentetous = db.Vente.Where(x => x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();


                    foreach (var vente in ListeVentetous)
                    {
                        var venteHistorique = new venteHistoriqueP();

                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }


                        ListeVenteHistoriquetous.Add(venteHistorique);

                    }

                    foreach (var item in ListeVenteHistoriquetous)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemiseTout.Add(ligne);
                            }
                        }

                    }

                    ListeVenteRégle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();


                    foreach (var vente in ListeVenteRégle)
                    {
                        var venteHistorique = new venteHistoriqueP();
                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteRégle.Add(venteHistorique);
                    }

                    foreach (var item in listeventeHistoriqueVenteRégle)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }

                    ListeVenteNonRégle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

         
                    foreach (var vente in ListeVenteNonRégle)
                    {
                        var venteHistorique = new venteHistoriqueP();
                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteNonRégle.Add(venteHistorique);
                    }

                  
                }

                else
                {
                    ListeVentetous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                   
                    foreach (var vente in ListeVentetous)
                    {
                        var venteHistorique = new venteHistoriqueP();

                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        ListeVenteHistoriquetous.Add(venteHistorique);
                    }

                    foreach (var item in ListeVenteHistoriquetous)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }
                    ListeVenteRégle = db.Vente.Where(x => x.EtatVente == Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

               
                    foreach (var vente in ListeVenteRégle)
                    {
                        var venteHistorique2 = new venteHistoriqueP();
                        venteHistorique2.ID = vente.Id;
                        venteHistorique2.vente = vente;
                        venteHistorique2.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique2.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteRégle.Add(venteHistorique2);
                    }

                    foreach (var item in listeventeHistoriqueVenteRégle)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) &&  ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }

                    ListeVenteNonRégle = db.Vente.Where(x => x.EtatVente != Model.Enumuration.EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin && x.NumClient.Equals(ClientSelected.ToString())).OrderBy(x => x.Date).ToList();

                  
                    foreach (var vente in ListeVenteNonRégle)
                    {
                        var venteHistorique3 = new venteHistoriqueP();
                        venteHistorique3.ID = vente.Id;
                        venteHistorique3.vente = vente;
                        venteHistorique3.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique3.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteNonRégle.Add(venteHistorique3);

                    }

                    foreach (var item in listeventeHistoriqueVenteNonRégle)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }

                }


                if (radioBtnTous.Checked)
                {
                    listeventeHistorique = ListeVenteHistoriquetous;

                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);

                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeventeHistorique.Sum(x => x.vente.ResteApayer);

                    var listeHistVenteSansRemise = new List<HistoriquePaiementVente>();
                    foreach(var item in listeventeHistorique)
                    {
                        foreach(var ligne in item.HistoriquePaiementVentes)
                        {
                            if(ligne.ModeReglement!=ModeReglement.Remise)
                            {
                                listeHistVenteSansRemise.Add(ligne);
                            }
                        }

                    }
                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeHistVenteSansRemise.Sum(x => x.MontantRegle).ToString();


                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();

                    RapportEtatVente.Parameters["TotalRemise"].Value = HistoriqueRemiseTout.Sum(x => x.MontantRegle).ToString();


                    RapportEtatVente.DataSource = listeventeHistorique;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    listeventeHistorique = listeventeHistoriqueVenteRégle;

                    RapportEtatVente.DataSource = listeventeHistorique;


                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);



                    var listeHistVenteSansRemise = new List<HistoriquePaiementVente>();
                    foreach (var item in listeventeHistorique)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (ligne.ModeReglement != ModeReglement.Remise)
                            {
                                listeHistVenteSansRemise.Add(ligne);
                            }
                        }

                    }
                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeHistVenteSansRemise.Sum(x => x.MontantRegle).ToString();

                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();
                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + NonRegle.Sum(x => x.vente.ResteApayer);
                    RapportEtatVente.Parameters["TotalRemise"].Value = HistoriqueRemise.Sum(x => x.MontantRegle).ToString();
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    listeventeHistorique = listeventeHistoriqueVenteNonRégle;

                    RapportEtatVente.DataSource = listeventeHistorique;

                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);


                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle).ToString();
                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();
                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeventeHistorique.Sum(x => x.vente.ResteApayer);
                    RapportEtatVente.Parameters["TotalRemise"].Value = "0";
                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
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
                RapportEtatVente.nomClient.Visible = false;
                histListe = db.HistoriquePaiementVente.ToList();
                List<Vente> VentesAnterieurs = db.Vente.Where(x => x.Date.CompareTo(DateMin) < 0).ToList();

                Decimal SoldeAnterieur = VentesAnterieurs.Sum(x => x.ResteApayer);

                RapportEtatVente.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatVente.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatVente.Parameters["Au"].Value = DateTime.Now;
                }

                else
                {
                    RapportEtatVente.Parameters["Au"].Value = datefin;
                }


                RapportEtatVente.Parameters["DateImpression"].Value = DateTime.Now;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {

                    ListeVentetous = db.Vente.Where(x => x.Date >= DateMin).OrderBy(x => x.Date).ToList();
                    foreach (var vente in ListeVentetous)
                    {
                        var venteHistorique = new venteHistoriqueP();
                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        ListeVenteHistoriquetous.Add(venteHistorique);
                    }

                    foreach (var item in ListeVenteHistoriquetous)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemiseTout.Add(ligne);
                            }
                        }

                    }


                    ListeVenteRégle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();
                    foreach (var vente in ListeVenteRégle)
                    {
                        var venteHistorique = new venteHistoriqueP();
                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteRégle.Add(venteHistorique);
                    }


                    foreach (var item in listeventeHistoriqueVenteRégle)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }



                    ListeVenteNonRégle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin).OrderBy(x => x.Date).ToList();
                    foreach (var vente in ListeVenteNonRégle)
                    {
                        var venteHistorique = new venteHistoriqueP();
                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteNonRégle.Add(venteHistorique);
                    }
                }

                else
                {

                    ListeVentetous = db.Vente.Where(x => x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                    foreach (var vente in ListeVentetous)
                    {
                        var venteHistorique = new venteHistoriqueP();

                        venteHistorique.ID = vente.Id;
                        venteHistorique.vente = vente;
                        venteHistorique.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        ListeVenteHistoriquetous.Add(venteHistorique);
                    }

                    foreach (var item in ListeVenteHistoriquetous)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemiseTout.Add(ligne);
                            }
                        }

                    }

                    ListeVenteRégle = db.Vente.Where(x => x.EtatVente == EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                 
                    foreach (var vente in ListeVenteRégle)
                    {
                        var venteHistorique2 = new venteHistoriqueP();
                        venteHistorique2.ID = vente.Id;
                        venteHistorique2.vente = vente;
                        venteHistorique2.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique2.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteRégle.Add(venteHistorique2);
                    }


                    foreach (var item in listeventeHistoriqueVenteRégle)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (!string.IsNullOrEmpty(ligne.Commentaire) && ligne.Commentaire.Equals("Remise"))
                            {
                                HistoriqueRemise.Add(ligne);
                            }
                        }

                    }
                    ListeVenteNonRégle = db.Vente.Where(x => x.EtatVente != EtatVente.Reglee && x.Date >= DateMin && x.Date <= datefin).OrderBy(x => x.Date).ToList();

                    foreach (var vente in ListeVenteNonRégle)
                    {
                        var venteHistorique3 = new venteHistoriqueP();
                        venteHistorique3.ID = vente.Id;
                        venteHistorique3.vente = vente;
                        venteHistorique3.HistoriquePaiementVentes = new List<HistoriquePaiementVente>();

                        foreach (var hist in histListe)
                        {
                            if (hist.IdVente == vente.Id)
                            {
                                venteHistorique3.HistoriquePaiementVentes.Add(hist);
                            }
                        }

                        listeventeHistoriqueVenteNonRégle.Add(venteHistorique3);
                    }

                }


                if (radioBtnTous.Checked)
                {
                    listeventeHistorique = ListeVenteHistoriquetous;

                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);

                    var listeHistVenteSansRemise = new List<HistoriquePaiementVente>();
                    foreach (var item in listeventeHistorique)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (ligne.ModeReglement != ModeReglement.Remise)
                            {
                                listeHistVenteSansRemise.Add(ligne);
                            }
                        }

                    }

                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeHistVenteSansRemise.Sum(x => x.MontantRegle).ToString();

                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();
                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeventeHistorique.Sum(x => x.vente.ResteApayer);
                    RapportEtatVente.Parameters["TotalRemise"].Value = HistoriqueRemiseTout.Sum(x => x.MontantRegle).ToString();
                    RapportEtatVente.DataSource = listeventeHistorique;

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
                    tool.ShowPreviewDialog();

                }

                else if (radioBtnRegle.Checked)
                {
                    listeventeHistorique = listeventeHistoriqueVenteRégle;

                    RapportEtatVente.DataSource = listeventeHistorique;


                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);

                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeventeHistorique.Sum(x => x.vente.ResteApayer);
                    var listeHistVenteSansRemise = new List<HistoriquePaiementVente>();
                    foreach (var item in listeventeHistorique)
                    {
                        foreach (var ligne in item.HistoriquePaiementVentes)
                        {
                            if (ligne.ModeReglement != ModeReglement.Remise)
                            {
                                listeHistVenteSansRemise.Add(ligne);
                            }
                        }

                    }

                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeHistVenteSansRemise.Sum(x => x.MontantRegle).ToString();

                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();

                    RapportEtatVente.Parameters["TotalRemise"].Value = HistoriqueRemise.Sum(x => x.MontantRegle).ToString();

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
                    tool.ShowPreviewDialog();
                }

                else if (radioBtnNonRegle.Checked)
                {
                    listeventeHistorique = listeventeHistoriqueVenteNonRégle;

                    RapportEtatVente.DataSource = listeventeHistorique;



                    RapportEtatVente.Parameters["TotalCmd"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement);

                    RapportEtatVente.Parameters["TotalAvance"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle);

                    RapportEtatVente.Parameters["TotalSolde"].Value = listeventeHistorique.Sum(x => x.vente.ResteApayer);

                    RapportEtatVente.Parameters["SoldeTotale"].Value = SoldeAnterieur + listeventeHistorique.Sum(x => x.vente.ResteApayer);
                    RapportEtatVente.Parameters["TotalMtReg"].Value = listeventeHistorique.Sum(x => x.vente.MontantRegle).ToString();
                    RapportEtatVente.Parameters["TotalVentes"].Value = listeventeHistorique.Sum(x => x.vente.MontantReglement).ToString();
                    RapportEtatVente.Parameters["TotalRemise"].Value = "0";

                    ReportPrintTool tool = new ReportPrintTool(RapportEtatVente);
                    tool.ShowPreviewDialog();
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }

            }





        }

        private void FrmEtatVente_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _FrmEtatVente = null;
        }

        private void FrmEtatVente_Load_1(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Select(x => new { x.Code, x.RaisonSociale }).ToList();
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        }
    }
}