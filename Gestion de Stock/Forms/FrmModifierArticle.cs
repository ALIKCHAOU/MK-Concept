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
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierArticle : DevExpress.XtraEditors.XtraForm
    {
        public Model.ApplicationContext db { get; set; }
        private static FrmModifierArticle _FrmModifierArticle;

        public static FrmModifierArticle InstanceFrmModifierArticle
        {
            get
            {
                if (_FrmModifierArticle == null)
                    _FrmModifierArticle = new FrmModifierArticle();
                return _FrmModifierArticle;
            }
        }

        public FrmModifierArticle()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }


        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            var codeArticle = TxtCodeArticle.Text;
            Article article = db.Packs.Where(x => x.Code == codeArticle).FirstOrDefault();

            article.Designation = TxtDésignation.Text;
            article.PrixdeVenteGros1 = Convert.ToDecimal(TxtPrixventeGros1.Text);
            article.PrixdeVenteGros2 = Convert.ToDecimal(TxtPrixVenteGros2.Text);
            article.PrixdeVentepublic = Convert.ToDecimal(TxtPrixVentePublic.Text);
            article.PrixdeVenteRevendeur = Convert.ToDecimal(TxtPrixRevendeur.Text);
            article.Quantity = Convert.ToInt32(TxtQte.Text);
            if (checkGererStock.Checked)
            {
                article.GereStock = true;
            }
            article.Metrage = string.IsNullOrEmpty(TxtMetrage.Text) ? 0 : Convert.ToInt32(TxtMetrage.Text);
            db.SaveChanges();
            XtraMessageBox.Show("L'article a été modifié.", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);


            TxtCodeArticle.Text = string.Empty;
            TxtDésignation.Text = string.Empty;
            TxtPrixventeGros1.Text = string.Empty;
            TxtPrixVenteGros2.Text = string.Empty;
            TxtPrixVentePublic.Text = string.Empty;
            TxtPrixRevendeur.Text = string.Empty;
            TxtQte.Text = string.Empty;
            TxtMetrage.Text= string.Empty;
            checkGererStock.Checked = false;
            this.Hide();
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form 
            if (Application.OpenForms.OfType<FrmAjouterArticle>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
            Application.OpenForms.OfType<FrmAjouterArticle>().First().gridControl1.RefreshDataSource();

            Application.OpenForms.OfType<FrmAjouterArticle>().First().articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();

        }

            private void FrmModifierArticle_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierArticle = null;
        }

       

        private void FrmModifierArticle_Shown_1(object sender, EventArgs e)
        {
            this.ActiveControl = TxtDésignation;
        }
    }
}