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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListePointages : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListePointages _FrmListePointages;
        public static FrmListePointages InstanceFrmListePointages
        {
            get
            {
                if (_FrmListePointages == null)
                    _FrmListePointages = new FrmListePointages();
                return _FrmListePointages;
            }
        }
        public FrmListePointages()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListePointages_Load(object sender, EventArgs e)
        {
            pointageJournalierBindingSource.DataSource = db.PointagesJournalier.OrderByDescending(x => x.Date).ToList();
        }

        private void FrmListePointages_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListePointages = null;
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
         
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                pointageJournalierBindingSource.DataSource = db.PointagesJournalier.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                pointageJournalierBindingSource.DataSource = db.PointagesJournalier.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                pointageJournalierBindingSource.DataSource = db.PointagesJournalier.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                pointageJournalierBindingSource.DataSource = db.PointagesJournalier.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void repositoryItemButtonModifié_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous Modifié cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

              
            }
            else
            {

                XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void repositoryItemSupprimer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                PointageJournalier P = gridView1.GetFocusedRow() as PointageJournalier;
                db = new Model.ApplicationContext();
                if (P != null)
                {
                    PointageJournalier PointageJournalierDb = db.PointagesJournalier.Find(P.Id);
                    Salarier salarier = PointageJournalierDb.Salarier;
                    decimal MontantReglé = salarier.MontantReglé;
                    decimal MontantRestReglé = salarier.MontantRestReglé;
                    decimal DifferenceMontant =decimal.Subtract( MontantReglé,MontantRestReglé); 
                    if(MontantRestReglé >= PointageJournalierDb.Montant)
                    {
                        db.PointagesJournalier.Remove(PointageJournalierDb);
                        db.SaveChanges();
                        salarier.Solde= decimal.Subtract(salarier.Solde, PointageJournalierDb.Montant);
                        db.SaveChanges();
                        pointageJournalierBindingSource.DataSource = db.PointagesJournalier.OrderByDescending(x => x.Date).ToList();
                        if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
                            Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = db.Salariers.ToList();
                        XtraMessageBox.Show("La suppression été  effectuèe ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Cette demande n'êtes pas autorisé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                   
                }

                



                //PointageJournalier P = new PointageJournalier();
                //P.Date = dateEditDatePointage.DateTime;
                //P.Salarier = S;
                //P.Poste = "Jour";
                //P.Montant = Montant;
                //db.PointagesJournalier.Add(P);
                //S.Solde = decimal.Add(S.Solde, Montant);
                //db.SaveChanges();
            }
            else
            {

                XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}