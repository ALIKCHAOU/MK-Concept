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
    public partial class FrmAjouterClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterClient _FrmAjouterClient;
        public static FrmAjouterClient InstanceFrmAjouterClient
        {
            get
            {
                if (_FrmAjouterClient == null)
                    _FrmAjouterClient = new FrmAjouterClient();
                return _FrmAjouterClient;
            }
        }
        public FrmAjouterClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterClient = null;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            // Raison social
            if (string.IsNullOrEmpty(TxtRaisonSocial.Text))
            {
                TxtRaisonSocial.ErrorText = "Raison Social  est obligatoire";
                return;

            }

            // Matricule fiscale
            if (string.IsNullOrEmpty(TxtMatriculeFiscale.Text))
            {
                TxtMatriculeFiscale.ErrorText = "Matricule Fiscale  est obligatoire";
                return;

            }
            //Address
            if (string.IsNullOrEmpty(TxtAdress.Text))
            {
                TxtAdress.ErrorText = "Adress  est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtTelephone.Text))
            {
                TxtTelephone.ErrorText = "Telèphone  est obligatoire";
                return;

            }

          

            


            Client c = new Client();
          
         
            c.Telephone = TxtTelephone.Text;
            c.Adresse = TxtAdress.Text;
            c.Email = TxtEmail.Text;
            c.MatriculeFiscale = TxtMatriculeFiscale.Text;
            c.Nom = TxtNom.Text;
            c.Prenom = TxtPrenom.Text;
            c.Status = Status.Active;
            c.Ville = TxtVille.Text;
            c.Activie = TXTActivite.Text;
            c.RaisonSociale = TxtRaisonSocial.Text;           
            db.Clients.Add(c);
            db.SaveChanges();
            XtraMessageBox.Show("Enregisterment Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
            TxtTelephone.Text = string.Empty;
            TxtAdress.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtVille.Text = string.Empty;
            TxtRaisonSocial.Text = string.Empty;
            TxtMatriculeFiscale.Text=string.Empty;
            TXTActivite.Text = string.Empty;

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
            if (Application.OpenForms.OfType<FrmClient>().FirstOrDefault()!=null)
            Application.OpenForms.OfType<FrmClient>().First().clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();
            //waiting Form 
            if (Application.OpenForms.OfType<FrmCreerDevis>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCreerDevis>().First().clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();



            if (Application.OpenForms.OfType<FrmCreerFacture>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCreerFacture>().First().clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();
            

        }

        private void FrmAjouterClient_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtAdress.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtEmail.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtFax.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPrenom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtVille.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtRaisonSocial.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
          
            
            // CONTERUR


            int lastClient = db.Clients.Count() + 1;
            if (lastClient == 0)
            {
                TxtCode.Text = "CL00000001";
            }
            else
            {
                TxtCode.Text = "CL" + (lastClient).ToString("D8");
            }

        }

        private void FrmAjouterClient_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtRaisonSocial;
        }
    }
}