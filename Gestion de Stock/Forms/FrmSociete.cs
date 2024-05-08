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
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSociete : DevExpress.XtraEditors.XtraForm
    {
        decimal Timber;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmSociete _FrmSociete;
        public static FrmSociete InstanceFrmSociete
        {
            get
            {
                if (_FrmSociete == null)
                    _FrmSociete = new FrmSociete();
                return _FrmSociete;
            }
        }
        public FrmSociete()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmSociete_Load(object sender, EventArgs e)
        {
            if (db.Societes.Count() > 0)
            {

                Societe ste = db.Societes.FirstOrDefault();
                TxtActivite.Text = ste.Activite;
                TxtAdresse.Text = ste.Adresse;
                TxtCapitale.Text = ste.Capitale;
                TxtCodePostale.Text = ste.CodePostale;
                TxtComplement.Text = ste.Complement;
                TxtEmail.Text = ste.Mail;
                TxtMatriculFiscal.Text = ste.MatriculFiscal;
                TxtName.Text = ste.Name;
                TxtRaisonSociale.Text = ste.RaisonSociale;
                TxtSite.Text = ste.Site;
                TxtRib.Text = ste.Rib;
                txtTelephone.Text = ste.Telephone;
                TxtTVA.Text = ste.TVA.ToString();
                TxtVille.Text = ste.Ville;
                TxtTimber.Text = ste.Timber.ToString();




            }
        }

        private void FrmSociete_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmSociete = null;
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            int idSte = db.Societes.FirstOrDefault().Id;
            Societe ste = db.Societes.Find(idSte);
            ste.Activite = TxtActivite.Text;
            ste.Adresse = TxtAdresse.Text;
            ste.Capitale = TxtCapitale.Text;
            ste.CodePostale = TxtCodePostale.Text;
            ste.Complement = TxtComplement.Text;
            ste.Mail = TxtEmail.Text;
            ste.MatriculFiscal = TxtMatriculFiscal.Text;
            ste.Name = TxtName.Text;
            ste.RaisonSociale = TxtRaisonSociale.Text;
            ste.Site = TxtSite.Text;
            ste.Telephone = txtTelephone.Text;
            ste.Ville = TxtVille.Text;
            ste.Rib = TxtRib.Text;
            ste.TVA =!string.IsNullOrEmpty(TxtTVA.Text) ? Convert.ToInt32(TxtTVA.Text) : 0; 
            string MontantPrixUStr = TxtTimber.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantPrixUStr, out Timber);
            ste.Timber = Timber;
            db.Societes.AddOrUpdate(ste);
            db.SaveChanges();
            XtraMessageBox.Show("Enregistrement  terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}