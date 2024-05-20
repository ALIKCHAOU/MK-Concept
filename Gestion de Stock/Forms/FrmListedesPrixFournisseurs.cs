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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;

namespace Gestion_de_Stock
{
    public partial class FrmListedesPrixFournisseurs : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmListedesPrixFournisseurs _FrmListedesPrixFournisseurs;
        public static FrmListedesPrixFournisseurs InstanceFrmListedesPrixFournisseurs
        {
            get
            {
                if (_FrmListedesPrixFournisseurs == null)
                    _FrmListedesPrixFournisseurs = new FrmListedesPrixFournisseurs();
                return _FrmListedesPrixFournisseurs;
            }
        }
        public FrmListedesPrixFournisseurs()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }

        private void FrmListedesPrixFournisseurs_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListedesPrixFournisseurs = null;
        }

        private void FrmListedesPrixFournisseurs_Load(object sender, EventArgs e)
        {
            fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.NomResponsable, x.PrenomResponsable }).ToList();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Fournisseur F = new Fournisseur();



            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object FournisseurSelected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Fournisseur
            if (FournisseurSelected == null)
            {
                XtraMessageBox.Show("Choisir un Fournisseur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {
              
                F = db.Fournisseurs.Include("ListeArticles").FirstOrDefault(x=>x.Code.Equals(FournisseurSelected.ToString()));
                if(F.ListeArticles!= null)
                articleBindingSource.DataSource = F.ListeArticles.ToList();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Fournisseur F = new Fournisseur();
            List<Article> ListeGrid = new List<Article>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as Article;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("liste Articles  est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            GridView view = searchLookUpEdit1.Properties.View;

            int rowHandle1 = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object FournisseurSelected = view.GetRowCellValue(rowHandle1, fieldName);
            ///Condition existance Fournisseur
            if (FournisseurSelected == null)
            {
                XtraMessageBox.Show("Choisir un Fournisseur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {

                F = db.Fournisseurs.Include("ListeArticles").FirstOrDefault(x => x.Code.Equals(FournisseurSelected.ToString()));
                if (F.ListeArticles != null)
                    F.ListeArticles = new List<Article>();
                F.ListeArticles = ListeGrid;
                db.SaveChanges();
                XtraMessageBox.Show("Enregistrement  terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
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