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
    public partial class FrmModifierClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierClient _FrmModifierClient;
        public static FrmModifierClient InstanceFrmModifierClient
        {
            get
            {
                if (_FrmModifierClient == null)
                    _FrmModifierClient = new FrmModifierClient();
                return _FrmModifierClient;
            }
        }
        public FrmModifierClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierClient_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierClient = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            Client ClientBb = db.Clients.Find(TxtCode.Text);
           if(ClientBb!= null) {      
            
                
                ClientBb.Nom = TxtNom.Text;
                ClientBb.Prenom = TxtPrenom.Text;
                ClientBb.Telephone = TxtTelephone.Text;
                ClientBb.Email = TxtEmail.Text;
                ClientBb.Adresse = TxtAdress.Text;
                ClientBb.RaisonSociale = TxtRaisonSocial.Text;
                ClientBb.Activie = TXTActivite.Text;
                ClientBb.Ville = TxtVille.Text;
                ClientBb.FAX = TxtFax.Text;
                ClientBb.MatriculeFiscale = TxtMatriculeFiscale.Text;            
                db.SaveChanges();         
                
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
            if (Application.OpenForms.OfType<FrmClient>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmClient>().FirstOrDefault().clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();
            XtraMessageBox.Show("Enregisterment Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Echec de l'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}