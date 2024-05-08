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
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeDepenseSalarier : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmListeDepenseSalarier _FrmListeDepenseSalarier;
        public static FrmListeDepenseSalarier InstanceFrmListeDepenseSalarier
        {
            get
            {
                if (_FrmListeDepenseSalarier == null)
                    _FrmListeDepenseSalarier = new FrmListeDepenseSalarier();
                return _FrmListeDepenseSalarier;
            }
        }
        public FrmListeDepenseSalarier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeDepenseSalarier_Load(object sender, EventArgs e)
        {
            List<Depense> ListeDeponses = new List<Depense>();
            ListeDeponses= db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
            List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
            ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
            depenseBindingSource.DataSource = ListeDeponses;


        }

        private void FrmListeDepenseSalarier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDepenseSalarier = null;
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }


        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

           
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.DateCreation.CompareTo(DateMin) >= 0).OrderByDescending(x => x.DateCreation).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));

                depenseBindingSource.DataSource = ListeDeponses;

            }
            else
            {
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                depenseBindingSource.DataSource = ListeDeponses;
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
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.DateCreation.CompareTo(DateMin) >= 0).OrderByDescending(x => x.DateCreation).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));

                depenseBindingSource.DataSource = ListeDeponses;

            }
            else
            {
                List<Depense> ListeDeponses = new List<Depense>();
                ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié && x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
                List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
                ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
                depenseBindingSource.DataSource = ListeDeponses;
            }

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

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Depenses Salariers.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

            //gridControl1.ExportToXlsx(path, advOptions);
            //// Open the created XLSX file with the default application.
            //Process.Start(path);


            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void repositoryItemButtonimpression_Click(object sender, EventArgs e)
        {
            string CodeDepense = gridView1.GetFocusedRowCellValue("DateCreation").ToString();
           // DateTime CodeDate = Convert.ToDateTime(CodeDepense);
           // Depense GetDepenseDB = db.Depenses.FirstOrDefault(x => x.Id== Code);

            List<Depense> ListeDeponses = new List<Depense>();
            ListeDeponses = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
            List<Coffrecheque> ListCoffrecheques = db.CoffreCheques.Where(x => x.Nature == NatureMouvement.Salarié).OrderByDescending(x => x.DateCreation).ToList();
            ListeDeponses.AddRange(ConvertToListeDeponses(ListCoffrecheques));
            Depense GetDepenseDB = ListeDeponses.Where(x => x.DateCreation.ToString().Equals(CodeDepense)).FirstOrDefault();
            RapportDepenseSalarier RFIpression = new RapportDepenseSalarier();
            RFIpression.Parameters["DateImpression"].Value = DateTime.Now;
            List<Depense> ListeDepenses = new List<Depense>();
            ListeDepenses.Add(GetDepenseDB);
            RFIpression.DataSource = ListeDepenses;
            ReportPrintTool tool = new ReportPrintTool(RFIpression);
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
    }
}