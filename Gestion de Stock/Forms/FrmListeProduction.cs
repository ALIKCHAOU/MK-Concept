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
using DevExpress.XtraSplashScreen;
using Gestion_de_Stock.Forms;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Gestion_de_Stock
{
    public partial class FrmListeProduction : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeProduction _FrmListeProduction;
        public static FrmListeProduction InstanceFrmListeProduction
        {
            get
            {
                if (_FrmListeProduction == null)
                    _FrmListeProduction = new FrmListeProduction();
                return _FrmListeProduction;
            }
        }

        public FrmListeProduction()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeProduction_Load(object sender, EventArgs e)
        {
            productionBindingSource.DataSource = db.Productions.ToList();
        }

        private void FrmListeProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeProduction = null;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeProduction = gridView1.GetFocusedRowCellValue("code").ToString();
            Production GetProductionsDB = db.Productions.Include("LigneProductions").FirstOrDefault(x => x.code.Equals(CodeProduction));
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsProduction.InstanceFrmDetailsProduction);
            if (Application.OpenForms.OfType<FrmDetailsProduction>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsProduction>().FirstOrDefault().ligneProductionBindingSource.DataSource = GetProductionsDB.LigneProductions.Where(x=>x.Poste.Equals("Jour")).ToList();
                Application.OpenForms.OfType<FrmDetailsProduction>().FirstOrDefault().ligneProductionBindingSource1.DataSource = GetProductionsDB.LigneProductions.Where(x => x.Poste.Equals("Nuit")).ToList();

            }
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

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste des Productions .xlsx";

            //Customize export options
            (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            advOptions.SheetName = "Exported from Data Grid";

            gridControl1.ExportToXlsx(path, advOptions);
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

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            productionBindingSource.DataSource = db.Productions.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            productionBindingSource.DataSource = db.Productions.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }
    }
}