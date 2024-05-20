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
using System.IO;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private string filePathBattante = string.Empty;
        private string filePathRegistredecommerce = string.Empty;
        private string filePathAttestationExoneration = string.Empty;
        

        private static FrmAjouterFournisseur _FrmAjouterFournisseur;
        public static FrmAjouterFournisseur InstanceFrmAjouterFournisseur
        {
            get
            {
                if (_FrmAjouterFournisseur == null)
                    _FrmAjouterFournisseur = new FrmAjouterFournisseur();
                return _FrmAjouterFournisseur;
            }
        }
        public FrmAjouterFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterFournisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterFournisseur = null;
        }

        private void FrmAjouterFournisseur_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtCode.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            // 	Coordonné STE 
            TxtRaisonSocial.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtActivite.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtMatriculeFiscale.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtAdress.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtVille.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            // 	Coordonné Responsable  

            TxtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;          
            TxtPrenom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;           
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtEmail.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
         

            //	Document pour attachement 


            //comboBoxEditDevis.SelectedItem = 0;
            //comboBoxEditDevis.SelectedText = comboBoxEditDevis.Properties.Items[0].ToString();

            int lastFournisseurs = db.Fournisseurs.Count() + 1;
            if (lastFournisseurs == 0)
            {
                TxtCode.Text = "FR00000001";
            }
            else
            {
                TxtCode.Text = "FR" + (lastFournisseurs).ToString("D8");
            }
            //TxtRaisonSocial.Text.Focus();


        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtRaisonSocial.Text))
            {
                TxtRaisonSocial.ErrorText = "Raison Social  est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtActivite.Text))
            {
                TxtActivite.ErrorText = "Activite   est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtMatriculeFiscale.Text))
            {
                TxtMatriculeFiscale.ErrorText = "Matricule Fiscale  est obligatoire";
                return;

            }

            //if (string.IsNullOrEmpty(TxtAdress.Text))
            //{
            //    TxtAdress.ErrorText = "Adress  est obligatoire";
            //    return;

            //}
            //if (string.IsNullOrEmpty(TxtVille.Text))
            //{
            //    TxtVille.ErrorText = "Ville  est obligatoire";
            //    return;

            //}

            //if (string.IsNullOrEmpty(TxtNom.Text))
            //{
            //    TxtNom.ErrorText = "Nom  est obligatoire";
            //    return;


            //}
            //if (string.IsNullOrEmpty(TxtPrenom.Text))
            //{
            //    TxtPrenom.ErrorText = "Prenom  est obligatoire";
            //    return;

            //}
            //if (string.IsNullOrEmpty(TxtTelephone.Text))
            //{
            //    TxtTelephone.ErrorText = "Telephone  est obligatoire";
            //    return;

            //}
            //if (string.IsNullOrEmpty(TXTTVA.Text))
            //{
            //    TXTTVA.ErrorText = "TVA  est obligatoire";
            //    return;
            //}



            Fournisseur fournisser = new Fournisseur();


            fournisser.RaisonSociale = TxtRaisonSocial.Text;
            fournisser.Activite = TxtActivite.Text;
            fournisser.MatriculeFiscale = TxtMatriculeFiscale.Text;
            fournisser.Adresse = TxtAdress.Text;
            fournisser.Ville = TxtVille.Text;

            fournisser.NomResponsable = TxtNom.Text;
            fournisser.PrenomResponsable = TxtPrenom.Text;
            fournisser.TelResponsable = TxtTelephone.Text;
            fournisser.EmailResponsable = TxtEmail.Text;
        
        

            fournisser.Status = Status.Active;
           
            db.Fournisseurs.Add(fournisser);
            db.SaveChanges();
            XtraMessageBox.Show("Fournisseur Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtRaisonSocial.Text = string.Empty;
            TxtActivite.Text = string.Empty;
            TxtMatriculeFiscale.Text = string.Empty;
            TxtAdress.Text = string.Empty;
            TxtVille.Text = string.Empty;

            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
            TxtTelephone.Text = string.Empty;
            TxtEmail.Text = string.Empty; 
           

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
            if(Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault()!=null)
            Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).ToList();
            //waiting Form
            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.NomResponsable, x.PrenomResponsable }).ToList();

        }

        private void FrmAjouterFournisseur_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtRaisonSocial;
        }

        private void buttonEditBattante_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Pdf Files|*.pdf",
                Title = "Open Pdf File",
                InitialDirectory = @"C:\"
            })


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {



                    filePathBattante = openFileDialog.FileName;




                }
        }

        private void buttonEditRegistredecommerce_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Pdf Files|*.pdf",
                Title = "Open Pdf File",
                InitialDirectory = @"C:\"
            })


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                 

                    filePathRegistredecommerce = openFileDialog.FileName;




                }
        }

        private void buttonEditAttestationExoneration_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Pdf Files|*.pdf",
                Title = "Open Pdf File",
                InitialDirectory = @"C:\"
            })


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                 

                    filePathAttestationExoneration = openFileDialog.FileName;




                }
            
        }
    }
}