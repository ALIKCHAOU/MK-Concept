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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmRemiseAchat : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmRemiseAchat _FrmRemiseAchat;
        public static FrmRemiseAchat InstanceFrmRemiseAchat
        {
            get
            {
                if (_FrmRemiseAchat == null)
                    _FrmRemiseAchat = new FrmRemiseAchat();
                return _FrmRemiseAchat;
            }
        }

        public FrmRemiseAchat()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmRemiseAchat_Load(object sender, EventArgs e)
        {

        }

        private void FrmRemiseAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmRemiseAchat = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCodeVente.Text);

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Find(id);

            decimal MontantVente;
            string MontantVenteStr = TxtMtVente.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantVenteStr, out MontantVente);

            decimal MontantRegle;
            string MontantRegleStr = TxtMtReg.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRegleStr, out MontantRegle);

            decimal MontantRemise;
            string MontantRemiseStr = TxtRemise.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRemiseStr, out MontantRemise);

            if (decimal.Add(MontantRemise, MontantRegle) == MontantVente)
            {
                AchatDb.EtatAchat = Model.Enumuration.EtatAchat.Reglee;
                AchatDb.MontantRegle = AchatDb.MontantRegle;
                AchatDb.MontantRemise = MontantRemise;
                db.SaveChanges();


                #region  Historique paiement vente
                HistoriquePaiementVente hpv = new HistoriquePaiementVente();
                hpv.IdVente = AchatDb.id;
                hpv.IntituleClient = AchatDb.RaisonSociale;
                hpv.NumClient = AchatDb.CodeFournisseur;
                hpv.MontantRegle = MontantRemise;
                hpv.MontantReglement = AchatDb.MontantReglement;
                hpv.ResteApayer = 0;
                hpv.NumVente = AchatDb.Code;
                hpv.Commentaire = "Remise";
                hpv.ModeReglement = Model.Enumuration.ModeReglement.Remise;
                db.HistoriquePaiementVente.Add(hpv);
                db.SaveChanges();
                #endregion

            }
            else
            {
                this.Hide();
                TxtRemise.Text = string.Empty;
                return;
            }

            this.Hide();
            TxtRemise.Text = string.Empty;

            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();

            XtraMessageBox.Show("Remise appliquée avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}