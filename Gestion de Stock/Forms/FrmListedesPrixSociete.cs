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

namespace Gestion_de_Stock
{
    public partial class FrmListedesPrixSociete : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmListedesPrixSociete _FrmListedesPrixSociete;
        public static FrmListedesPrixSociete InstanceFrmListedesPrixSociete
        {
            get
            {
                if (_FrmListedesPrixSociete == null)
                    _FrmListedesPrixSociete = new FrmListedesPrixSociete();
                return _FrmListedesPrixSociete;
            }
        }
        public FrmListedesPrixSociete()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmListedesPrixSociete_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListedesPrixSociete = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmListedesPrixSociete_Load(object sender, EventArgs e)
        {
            Societe societe = db.Societes.Include("ListeArticles").FirstOrDefault();
            articleBindingSource.DataSource = societe.ListeArticles;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
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
            Societe societe = db.Societes.Include("ListeArticles").FirstOrDefault();
            if (societe.ListeArticles == null)
                societe.ListeArticles = new List<Article>();

            societe.ListeArticles = ListeGrid;
            db.SaveChanges();
            XtraMessageBox.Show("Enregistrement  terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}