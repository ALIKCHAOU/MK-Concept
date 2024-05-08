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
    public partial class FrmModifierOuvrier : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierOuvrier _FrmModifierOuvrier;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public static FrmModifierOuvrier InstanceFrmModifierOuvrier
        {
            get
            {
                if (_FrmModifierOuvrier == null)
                    _FrmModifierOuvrier = new FrmModifierOuvrier();
                return _FrmModifierOuvrier;
            }
        }

        public FrmModifierOuvrier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmModifierOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierOuvrier = null;

        }

        private void Enregister(object sender, EventArgs e)
        {
            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            int id = Convert.ToInt32(TxtNumero.Text);
            Salarier SalarieDb = db.Salariers.Find(id);
            if (SalarieDb != null)
            {
                if (Montant <= 0)
                {
                    XtraMessageBox.Show("Montant est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMontant.ErrorText = "Montant est Invalid";
                    return;
                }
                SalarieDb.Id = Convert.ToInt32(TxtNumero.Text);
                SalarieDb.Intitule = TxtIntitule.Text;
                SalarieDb.Tel = TxtTel.Text;
                SalarieDb.Matricule = TxtMatricule.Text;
                SalarieDb.MontantJournalie = Montant;
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
                if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault().salarierBindingSource.DataSource = db.Salariers.ToList();

                if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault().salarierBindingSource.DataSource = db.Salariers.ToList();

                XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Echec d'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmModifierOuvrier_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierOuvrier_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtIntitule;
        }
    }
}