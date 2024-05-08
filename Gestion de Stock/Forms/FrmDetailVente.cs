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
    public partial class FrmDetailVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmDetailVente _FrmDetailVente;
        public static FrmDetailVente InstanceFrmDetailVente
        {
            get
            {
                if (_FrmDetailVente == null)
                    _FrmDetailVente = new FrmDetailVente();
                return _FrmDetailVente;
            }
        }
        public FrmDetailVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetailVente_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailVente = null;
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
        }
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            
            LigneVente v = gridView1.GetFocusedRow() as LigneVente;

            db = new Model.ApplicationContext();

            LigneVente VenteDb = db.LigneVentes.Find(v.Id);

            FormshowNotParent(Forms.FrmDemandeRetour.InstanceFrmDemandeRetour);

            if (Application.OpenForms.OfType<FrmDemandeRetour>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDemandeRetour>().First().TxtCodeLigne.Text = v.Id.ToString();
                Application.OpenForms.OfType<FrmDemandeRetour>().First().TxtNomArticle.Text = v.NomArticle;
                Application.OpenForms.OfType<FrmDemandeRetour>().First().TxtQuantiteVendu.Text = v.Quantity.ToString();
            }



        }

    }
}