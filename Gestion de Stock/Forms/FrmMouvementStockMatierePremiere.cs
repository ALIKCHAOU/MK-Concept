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
    public partial class FrmMouvementStockMatierePremiere : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmMouvementStockMatierePremiere _FrmMouvementStock;
        public static FrmMouvementStockMatierePremiere InstanceFrmMouvementStock
        {
            get
            {
                if (_FrmMouvementStock == null)
                    _FrmMouvementStock = new FrmMouvementStockMatierePremiere();
                return _FrmMouvementStock;
            }
        }

        public FrmMouvementStockMatierePremiere()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmMouvementStock_Load(object sender, EventArgs e)
        {
            mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.OrderByDescending(x => x.Date).ToList();
        }

        private void FrmMouvementStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMouvementStock = null;
        }

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
           
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {

                mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {

                mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
           
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {

                mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {

                mouvementStockBindingSource.DataSource = db.MouvementsStockMatierePremiere.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "MouvementStock.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPdF_Click(object sender, EventArgs e)
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