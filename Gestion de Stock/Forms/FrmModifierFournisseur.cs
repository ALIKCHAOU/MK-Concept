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
    public partial class FrmModifierFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierFournisseur _FrmModifierFournisseur;
        public static FrmModifierFournisseur InstanceFrmModifierFournisseur
        {
            get
            {
                if (_FrmModifierFournisseur == null)
                    _FrmModifierFournisseur = new FrmModifierFournisseur();
                return _FrmModifierFournisseur;
            }
        }
        public FrmModifierFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierFournisseur_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierFournisseur_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmModifierFournisseur = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            Fournisseur FournisseursBb = db.Fournisseurs.Find(TxtCode.Text);
         
            if (FournisseursBb != null)
            {
                FournisseursBb.RaisonSociale = TxtRaisonSocial.Text;
                FournisseursBb.Activite = TxtActivite.Text;
                FournisseursBb.MatriculeFiscale = TxtMatriculeFiscale.Text;
                FournisseursBb.Adresse = TxtAdress.Text;
                FournisseursBb.Ville = TxtVille.Text;
                FournisseursBb.NomResponsable = TxtNom.Text;
                FournisseursBb.PrenomResponsable = TxtPrenom.Text;
                FournisseursBb.TelResponsable = TxtTelephone.Text;
                FournisseursBb.EmailResponsable = TxtEmail.Text;
                FournisseursBb.Adresse = TxtAdress.Text;
                FournisseursBb.Fax = TxtFax.Text;
                FournisseursBb.Banque = TxtBanque.Text;
                FournisseursBb.RIB = TxtRiB.Text;
                if (!string.IsNullOrEmpty(TXTTVA.Text))
                { FournisseursBb.TVA = int.Parse(TXTTVA.Text); }
                else
                { FournisseursBb.TVA = 0; }                
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
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).ToList();
                XtraMessageBox.Show("Enregisterment Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
            else
            {
                XtraMessageBox.Show("Echec de l'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}