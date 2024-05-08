using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeVente _FrmListeVente;
        public static FrmListeVente InstanceFrmListeVente
        {
            get
            {
                if (_FrmListeVente == null)
                {
                    _FrmListeVente = new FrmListeVente();
                }

                return _FrmListeVente;
            }
        }
        public FrmListeVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeVente_Load(object sender, EventArgs e)
        {

            venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();
        }

        private void FrmListeVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeVente = null;
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            GridView view = sender as GridView;

            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath = executingFolder + "\\Image\\Reglee_16x16.png";
            Image imageReglee = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\NonReglee_16x16.png";
            Image imageNonReglee = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\PR_16x16.png";
            Image imagePR = Image.FromFile(dbPath3);


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (e.Column.FieldName == "EtatVente")
                {
                    if (Convert.ToInt32(e.CellValue) == 1)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageNonReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 2)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imagePR, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }
                    else if (Convert.ToInt32(e.CellValue) == 3)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }


                }
            }
        }

        private void repositoryItemDeatis_Click(object sender, EventArgs e)
        {
            Vente vente = gridView1.GetFocusedRow() as Vente;
            db = new Model.ApplicationContext();
            Vente VentetDb = db.Vente.Include("LigneVentes").FirstOrDefault(x => x.Id == vente.Id);

            List<LigneVente> ListeLV = new List<LigneVente>();

            ListeLV = VentetDb.LigneVentes;

            //  FrmDetailVente.ligneVenteBindingSource.DataSource = ListeLV;

            FormshowNotParent(Forms.FrmDetailVente.InstanceFrmDetailVente);
            if (Application.OpenForms.OfType<FrmDetailVente>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailVente>().First().ligneVenteBindingSource.DataSource = ListeLV;
            }
        }

        private void repositoryBtnAjouterReglement_Click(object sender, EventArgs e)
        {
            Vente v = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Vente VenteDb = db.Vente.Find(v.Id);

            if (VenteDb.EtatVente != EtatVente.Reglee)
            {
                FormshowNotParent(Forms.FrmAjouterReglementVente.InstanceFrmAjouterReglementVente);

                if (Application.OpenForms.OfType<FrmAjouterReglementVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtNumVente.Text = v.Id.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtClient.Text = v.IntituleClient;
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtTotalCommande.Text = v.TotalTTC.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtAvance.Text = v.MontantRegle.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtResteAPayer.Text = v.ResteApayer.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtMTRegle.Text = v.ResteApayer.ToString();

                }

            }
            else
            {
                XtraMessageBox.Show("Vente est Réglée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            //if (DateMaxJour.CompareTo(DateMin)<0)
            //{
            //    XtraMessageBox.Show("Date Fin est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
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
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void repositorHistoriquePaiementVente_Click(object sender, EventArgs e)
        {

            Vente vente = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            List<HistoriquePaiementVente> result = db.HistoriquePaiementVente.Where(x => x.NumVente.Equals(vente.Numero)).ToList();

            FormshowNotParent(Forms.FrmHistoriquePaiementVente.InstanceFrmHistoriquePaiementVente);

            if (Application.OpenForms.OfType<FrmHistoriquePaiementVente>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmHistoriquePaiementVente>().First().historiquePaiementVenteBindingSource.DataSource = result;
            }
        }





        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Ventes.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void ReSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Vente C = gridView1.GetFocusedRow() as Vente;
                if (C == null)
                {
                    XtraMessageBox.Show("La Suppression a été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var VenteDb = db.Vente.Include("LigneVentes").FirstOrDefault(x => x.Id == C.Id);
                if (VenteDb.EtatVente == EtatVente.NonReglee)
                {
                    List<LigneVente> ligneVentes = new List<LigneVente>();
                    ligneVentes = VenteDb.LigneVentes.ToList();
               
                    db.Vente.Remove(VenteDb);
                    db.SaveChanges();
                    XtraMessageBox.Show(" la Vente a été  Supprimer", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 

                

                }
                else
                {

                    XtraMessageBox.Show("La Suppression a été annulée ,la Vente est Regleè", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();

                XtraMessageBox.Show("la vente a été supprimée avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                XtraMessageBox.Show("La Suppression a été annulée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }

        private void ButtonRemise_Click(object sender, EventArgs e)
        {
            Vente v = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Vente VenteDb = db.Vente.Find(v.Id);
       
            if (VenteDb.EtatVente == EtatVente.PartiellementReglee)
            {
                FormshowNotParent(Forms.FrmRemiseVente.InstanceFrmRemiseVente);

                if (Application.OpenForms.OfType<FrmRemiseVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmRemiseVente>().First().TxtCodeVente.Text = VenteDb.Id.ToString();
                    Application.OpenForms.OfType<FrmRemiseVente>().First().TxtRemise.Text = VenteDb.ResteApayer.ToString();
                    Application.OpenForms.OfType<FrmRemiseVente>().First().TxtMtVente.Text = VenteDb.MontantReglement.ToString();
                    Application.OpenForms.OfType<FrmRemiseVente>().First().TxtMtReg.Text = VenteDb.MontantRegle.ToString();
                }
            }
            else
            {
                XtraMessageBox.Show("Impossible de faire une remise!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

        }

      
    }
}