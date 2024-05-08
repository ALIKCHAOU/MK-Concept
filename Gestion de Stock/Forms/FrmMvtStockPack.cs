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
    public partial class FrmMvtStockPack : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmMvtStockPack _FrmMvtStockPack;
        public static FrmMvtStockPack InstanceFrmMvtStockPack
        {
            get
            {
                if (_FrmMvtStockPack == null)
                    _FrmMvtStockPack = new FrmMvtStockPack();
                return _FrmMvtStockPack;
            }
        }

        public FrmMvtStockPack()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmMvtStockPack_Load(object sender, EventArgs e)
        {
            mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.OrderByDescending(x => x.Date).ToList(); 
        }

        private void FrmMvtStockPack_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMvtStockPack = null;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Mvt Stock Article.xlsx";
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

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                mouvementStockPackBindingSource.DataSource = db.MouvementStockPacks.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }
    }
}