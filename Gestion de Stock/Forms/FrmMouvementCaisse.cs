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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraLayout.Utils;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMouvementCaisse : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmMouvementCaisse _FrmMouvementCaisse;

        public static FrmMouvementCaisse InstanceFrmMouvementCaisse
        {
            get
            {
                if (_FrmMouvementCaisse == null)
                    _FrmMouvementCaisse = new FrmMouvementCaisse();
                return _FrmMouvementCaisse;
            }
        }

        public FrmMouvementCaisse()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmMouvementCaisse_Load(object sender, EventArgs e)
        {
            if (db.MouvementsCaisse.Count() > 0)
            {

                List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                mouvementCaisseBindingSource.DataSource = ListeMvtCaisse;

                MouvementCaisse mvt = ListeMvtCaisse.Last();

                TxtSoldeCaisse.Text = mvt.Montant.ToString();

            }


        }

        private void FrmMouvementCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMouvementCaisse = null;
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            //if (DateMaxJour.CompareTo(DateMin)<0)
            //{
            //    XtraMessageBox.Show("Date Fin est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
            }

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
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Caisse.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {

            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
            frm.Activate();
        }

        private void repositoryDetailMvmCaisse_Click(object sender, EventArgs e)
        {
            MouvementCaisse MvmCaisse = gridView1.GetFocusedRow() as MouvementCaisse;

            db = new Model.ApplicationContext();

            var mvmCaisseDb = db.MouvementsCaisse.Find(MvmCaisse.Id);

          

        }

        private void repositoryImprimerTicket_Click(object sender, EventArgs e)
        {
            MouvementCaisse MvmCaisse = gridView1.GetFocusedRow() as MouvementCaisse;

            db = new Model.ApplicationContext();

            var mvmCaisseDb = db.MouvementsCaisse.Find(MvmCaisse.Id);

            //Societe societe = db.Societe.FirstOrDefault();

            //string RsSte = societe.RaisonSocial;


            //if (mvmCaisseDb.Achat != null)
            //{

            //    int codeAchat = mvmCaisseDb.Achat.Id;

            //    Achat AchatDb = db.Achats.FirstOrDefault(x => x.Id == codeAchat);

            //    if (mvmCaisseDb.Commentaire.Equals("Avance Agriculteur"))
            //    {
            //        xrAvance xrAvance = new xrAvance();

            //        if (AchatDb.TypeAchat == TypeAchat.Avance)
            //        {
            //            List<Achat> ListeAchats = new List<Achat>();
            //            ListeAchats.Add(AchatDb);
            //            xrAvance.Parameters["RsSte"].Value = RsSte;
            //            xrAvance.DataSource = ListeAchats;
            //            ReportPrintTool tool = new ReportPrintTool(xrAvance);
            //            tool.ShowPreviewDialog();

            //        }
            //    }


            //    //if (AchatDb.TypeAchat == TypeAchat.Service)
            //    //{
            //    //    List<Achat> ListeAchats = new List<Achat>();

            //    //    ListeAchats.Add(AchatDb);
            //    //    TicketService ticketService = new TicketService();
            //    //    ticketService.Parameters["RsSte"].Value = RsSte;
            //    //    ticketService.DataSource = ListeAchats;
            //    //    ReportPrintTool tool1 = new ReportPrintTool(ticketService);
            //    //    tool1.ShowPreview();
            //    //}

            //    if (mvmCaisseDb.Commentaire.Contains("_"))
            //    {
            //        TickeAvanceAvecAchat xrAchatTicket = new TickeAvanceAvecAchat();

            //        List<Achat> ListeAchats = new List<Achat>();

            //        ListeAchats.Add(AchatDb);

            //        xrAchatTicket.Parameters["RsSte"].Value = RsSte;

            //        xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;

            //        if (AchatDb.TypeAchat == TypeAchat.Base)
            //        {
            //            xrAchatTicket.Parameters["QteAchetee"].Value = AchatDb.NbSacs;

            //            if (AchatDb.TypeOlive == ArticleAchat.Nchira)
            //            {
            //                xrAchatTicket.Parameters["Type"].Value = "Nchira";
            //            }
            //            else if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
            //            {
            //                xrAchatTicket.Parameters["Type"].Value = "OliveVif";
            //            }

            //        }


            //        else if (AchatDb.TypeAchat == TypeAchat.Huile)
            //        {
            //            xrAchatTicket.Parameters["QteAchetee"].Value = AchatDb.QteHuileAchetee;

            //            if (AchatDb.Qualite == ArticleVente.Extra)
            //            {
            //                xrAchatTicket.Parameters["Type"].Value = "Extra";
            //            }
            //            else if (AchatDb.Qualite == ArticleVente.Lampante)
            //            {
            //                xrAchatTicket.Parameters["Type"].Value = "Lampante";
            //            }


            //        }
            //        xrAchatTicket.DataSource = ListeAchats;
            //        ReportPrintTool tool = new ReportPrintTool(xrAchatTicket);
            //        tool.ShowPreviewDialog();


            //    }

            //    if (!mvmCaisseDb.Commentaire.Contains("_") && (AchatDb.TypeAchat == TypeAchat.Huile || AchatDb.TypeAchat == TypeAchat.Base))
            //    {
            //        TicketMvtCaisse Ticket = new TicketMvtCaisse();

            //        Ticket.Parameters["RsSte"].Value = RsSte;

            //        Ticket.Parameters["NumAchat"].Value = AchatDb.Numero;

            //        Ticket.Parameters["Agriculteur"].Value = AchatDb.Founisseur.FullName;

            //        Ticket.Parameters["Montant"].Value = decimal.Multiply(mvmCaisseDb.MontantSens, -1);

            //        List<Achat> AchatListe = new List<Achat>();

            //        AchatListe.Add(AchatDb);

            //        Ticket.DataSource = AchatListe;

            //        ReportPrintTool tool = new ReportPrintTool(Ticket);

            //        tool.ShowPreviewDialog();
            //    }
            //}

        }
    }
}