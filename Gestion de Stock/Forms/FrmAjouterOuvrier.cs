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
using System.Globalization;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterOuvrier : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterOuvrier _FrmAjouterOuvrier;

        public static FrmAjouterOuvrier InstanceFrmAjouterOuvrier
        {
            get
            {
                if (_FrmAjouterOuvrier == null)
                    _FrmAjouterOuvrier = new FrmAjouterOuvrier();
                return _FrmAjouterOuvrier;
            }
        }


        public FrmAjouterOuvrier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAjouterOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterOuvrier = null;

        }

        private void FrmAjouterOuvrier_Load(object sender, EventArgs e)
        {
            TxtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtMatricule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            



        }

        private void btnAjouterOuvrier_Click(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider


            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;
            }

            if (string.IsNullOrEmpty(TxtTelephone.Text))
            {
                TxtTelephone.ErrorText = "Téléphone est obligatoire";
                return;
            }

            if (string.IsNullOrEmpty(TxtMatricule.Text))
            {
                TxtMatricule.ErrorText = "Matricule est obligatoire";
                return;
            }

            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.ErrorText = "Montant est Obligatoire";
                return;
            }

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);


            if (Montant <= 0)
            {
                XtraMessageBox.Show("Montant est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMontant.ErrorText = "Montant est Invalid";
                return;
            }

            Salarier S = new Salarier();
            S.Intitule = TxtIntitule.Text;
            S.Tel = TxtTelephone.Text;
            S.Matricule = TxtMatricule.Text;
            S.MontantJournalie = Montant;
            db.Salariers.Add(S);
            db.SaveChanges();

            S.numero = "S" + (S.Id).ToString("D8");
            db.SaveChanges();
            XtraMessageBox.Show("Salarié Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtIntitule.Text = string.Empty;
            TxtTelephone.Text = string.Empty;
            TxtMatricule.Text = string.Empty;
            TxtMontant.Text = string.Empty;

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
            if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = db.Salariers.ToList();

            if (Application.OpenForms.OfType<FrmAjouterPointage>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterPointage>().First().salarierBindingSource.DataSource = db.Salariers.ToList();

            if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterDepense>().First().salarierBindingSource.DataSource = db.Salariers.ToList();

        }
    }
}