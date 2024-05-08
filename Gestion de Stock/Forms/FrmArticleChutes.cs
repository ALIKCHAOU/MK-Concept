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
using Gestion_de_Stock.Model;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmArticleChutes : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmArticleChutes _FrmArticleChutes;
        public static FrmArticleChutes InstanceFrmArticleChutes
        {
            get
            {
                if (_FrmArticleChutes == null)
                    _FrmArticleChutes = new FrmArticleChutes();
                return _FrmArticleChutes;
            }
        }
        public FrmArticleChutes()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmArticleChutes_Load(object sender, EventArgs e)
        {
            articleChuteBindingSource.DataSource = db.ArticleChutes.ToList();
        }

        private void FrmArticleChutes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmArticleChutes = null;
        }

        private void BtnBerurier_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous Berurier cet Article ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {


             


                db = new Model.ApplicationContext();
                ArticleChute A = gridView1.GetFocusedRow() as ArticleChute; 
                ArticleChute GetArticleChuteDB = db.ArticleChutes.Where(x => x.Id ==A.Id).FirstOrDefault();
                FormshowNotParent(Gestion_de_Stock.FrmBerurierArticleChute.InstanceFrmBerurierArticleChute);
                if (Application.OpenForms.OfType<FrmBerurierArticleChute>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmBerurierArticleChute>().FirstOrDefault().TxtNomArticle.Text = GetArticleChuteDB.NomArticle.ToString();
                    Application.OpenForms.OfType<FrmBerurierArticleChute>().FirstOrDefault().TxtCode.Text = GetArticleChuteDB.Id.ToString();

                }




            }
            else
            {

                XtraMessageBox.Show("Berurier cet Article été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}