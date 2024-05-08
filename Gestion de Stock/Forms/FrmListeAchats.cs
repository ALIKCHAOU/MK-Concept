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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model;
using System.IO;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeAchats : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeAchats _FrmListeAchats;
        public static FrmListeAchats InstanceFrmListeAchats
        {
            get
            {
                if (_FrmListeAchats == null)
                    _FrmListeAchats = new FrmListeAchats();
                return _FrmListeAchats;
            }
        }
        public FrmListeAchats()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            achatBindingSource.DataSource = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
            
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            achatBindingSource.DataSource = db.Achats.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void FrmListeAchats_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeAchats = null;
        }

        private void FrmListeAchats_Load(object sender, EventArgs e)
        {
            achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Achats.xlsx";

            //Customize export options
            (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            advOptions.SheetName = "Exported from Data Grid";

            gridControl1.ExportToXlsx(path, advOptions);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPdF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
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
            frm.Activate();
        }
        private void ViewDocument_Click(object sender, EventArgs e)
        {

            string CodeAchat = gridView1.GetFocusedRowCellValue("Code").ToString();
            Achat GetAchatDB = db.Achats.FirstOrDefault(x=>x.Code.Equals(CodeAchat));

            //PDFViewer PDFViewer1;
            //byte[] baPDF; // load the decrypted PDF to this byte array

            //PDFViewer1.LoadDocument(baPDF);
            FrmViewPdf frmViewPdf = new FrmViewPdf();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmViewPdf.InstanceFrmViewPdf);
            if (Application.OpenForms.OfType<FrmViewPdf>().FirstOrDefault() != null)
                frmViewPdf = Application.OpenForms.OfType<FrmViewPdf>().First();

            byte[] byteArray = GetAchatDB.Attachment;

            frmViewPdf.pdfViewer1.DetachStreamAfterLoadComplete = true;
            if (byteArray != null)
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                    frmViewPdf.pdfViewer1.LoadDocument(ms);
            }
        }



        private void repositoryItemButtonEditViewDetais_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeAchat = gridView1.GetFocusedRowCellValue("Code").ToString();
            Achat GetAchatDB = db.Achats.Include("Lines").Where(x => x.Code.Equals(CodeAchat)).FirstOrDefault();
            FormshowNotParent(Gestion_de_Stock.Forms.FrmDetailsAchats.InstanceFrmdetaisAchats);
            if (Application.OpenForms.OfType<FrmDetailsAchats>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailsAchats>().FirstOrDefault().TxtNumAchats.Text = CodeAchat.ToString();
                Application.OpenForms.OfType<FrmDetailsAchats>().FirstOrDefault().ligneAchatsBindingSource.DataSource = GetAchatDB.Lines.ToList();

            }
        }



        private void repositoryItemButtonAjouterReglement_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.FirstOrDefault(x => x.Code.Equals(A.Code));



            if (AchatDb.EtatAchat != EtatAchat.Reglee)
            {


                FormshowNotParent(Forms.FrmAjouterReglementAchat.InstanceFrmAjouterReglementAchat);

                if (Application.OpenForms.OfType<FrmAjouterReglementAchat>().FirstOrDefault() != null)
                {

                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().layoutControlMtAPayer.Text = "Montant à Payer";
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtCodeAchat.Text = A.Code.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtFournisseur.Text = A.RaisonSociale;
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantOperation.Text = A.MontantReglement.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtAvance.Text = A.MontantRegle.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtSolde.Text = A.ResteApayer.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantEncaisse.Text = A.ResteApayer.ToString();
                }

            }
            else
            {
                XtraMessageBox.Show("Votre demande est non Autorisée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();

            }

        }



        private void repositoryItemHistoriquePaiement_Click(object sender, EventArgs e)
        {
            Achat achat = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            List<HistoriquePaiementAchats> result = db.HistoriquePaiementAchats.Where(x => x.NumAchat.Equals(achat.Code)).ToList();

            FormshowNotParent(Forms.FrmHistoriquePaiementAchat.InstanceFrmHistoriquePaiementAchat);

            if (Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().First().historiquePaiementAchatsBindingSource.DataSource = result;
            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            #region image etat Achat
            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath = executingFolder + "\\Image\\Reglee_16x16.png";
            Image imageReglee = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\NonReglee_16x16.png";
            Image imageNonReglee = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\PR_16x16.png";
            Image imagePR = Image.FromFile(dbPath3);
            #endregion



            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (e.Column.FieldName == "EtatAchat")
                {

                    if (Convert.ToInt32(e.CellValue) == 3)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 1)
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

                }



            }
        }

        private void repositoryItemSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cette Achat ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                Achat A = gridView1.GetFocusedRow() as Achat;
                bool Historique = db.HistoriquePaiementAchats.Where(x => x.NumAchat.Equals(A.Code)).Any();
                if (!Historique)
                {
                    Achat achat = db.Achats.Include("Lines").Where(x => x.id == A.id).FirstOrDefault();
                    List<LigneAchats> LigneAchatDb = achat.Lines.ToList();
                    foreach (var linge in LigneAchatDb)
                    {
                        LigneAchats ligneAchatsdb = db.LigneAchats.Find(linge.Id);
                        db.LigneAchats.Remove(ligneAchatsdb);
                        db.SaveChanges();
                    }
                    db.Achats.Remove(achat);
                    db.SaveChanges();
                    SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(10);
                    }
                    SplashScreenManager.CloseForm();
                    if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();
                }
                else
                {
                    XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                XtraMessageBox.Show("La Suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}