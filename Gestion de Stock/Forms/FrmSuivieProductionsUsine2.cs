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
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSuivieProductionsUsine2 : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmSuivieProductionsUsine2 _FrmSuivieProductionsUsine2;
        public static FrmSuivieProductionsUsine2 InstanceFrmSuivieProductionsUsine2
        {
            get
            {
                if (_FrmSuivieProductionsUsine2 == null)
                    _FrmSuivieProductionsUsine2 = new FrmSuivieProductionsUsine2();
                return _FrmSuivieProductionsUsine2;
            }
        }
        public FrmSuivieProductionsUsine2()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmSuivieProductionsUsine2_Load(object sender, EventArgs e)
        {
            ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.OrderByDescending(x => x.DateCreation).ToList();
        }

        private void FrmSuivieProductionsUsine2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmSuivieProductionsUsine2 = null;
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
                ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).OrderByDescending(x => x.DateCreation).ToList();
            }
            else
            {
                ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
            }
        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).OrderByDescending(x => x.DateCreation).ToList();
            }
            else
            {
                ligneProductionUsine2BindingSource.DataSource = db.LigneProductionUsine2.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Production Usine2.xlsx";
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
    }
}