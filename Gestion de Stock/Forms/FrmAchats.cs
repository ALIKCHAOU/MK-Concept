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
using System.Globalization;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraSplashScreen;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAchats : DevExpress.XtraEditors.XtraForm
    {
        private string filePath = string.Empty;
        private Decimal MontantPrixU = 0;
        private Decimal MontantPrixTotal = 0;
        private int QuantiteTotal = 0;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmAchats _FrmAchats;
        public static FrmAchats InstanceFrmAchats
        {
            get
            {
                if (_FrmAchats == null)
                    _FrmAchats = new FrmAchats();
                return _FrmAchats;
            }
        }
        public FrmAchats()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAchats_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAchats = null;
        }

        private void FrmAchats_Load(object sender, EventArgs e)
        { /********************** Fournisseurs Liste************************/
            fournisseurBindingSource.DataSource = db.Fournisseurs.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.NomResponsable, x.PrenomResponsable }).ToList();
         
         
            dateEditDateFacture.DateTime = DateTime.Now;

            /***********************  Mode  Paiement Liste  ***********************/
        
     

            string Code = "";
            int lastAchat = db.Achats.Count() + 1;
            if (lastAchat == 0)
            {
                Code = "FA00000001";
            }
            else
            {
                Code = "FA" + (lastAchat).ToString("D8");
            }

            TxtFactureNumero.Text = Code;

        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            Fournisseur F = new Fournisseur();

       
           
            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Code"; // or other field name  
            object FournisseurSelected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Fournisseur
            if (FournisseurSelected == null)
            {
                XtraMessageBox.Show("Choisir un Fournisseur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {

                F = db.Fournisseurs.Find(FournisseurSelected.ToString());
            }
        

            List<LigneAchats> ListeGrid = new List<LigneAchats>();

            int rowHandleListeGrid = 0;
            while (gridView1.IsValidRowHandle(rowHandleListeGrid))
            {
                var data = gridView1.GetRow(rowHandleListeGrid) as LigneAchats;
            
                if (data.Quantity <1)
                {
                    XtraMessageBox.Show(" ligne Achats est Invalide :"+ data.NomArticle, "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
                if (data.PrixUnitaire ==0)
                {
                    XtraMessageBox.Show(" ligne Achats est Invalide :" + data.NomArticle, "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
              
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandleListeGrid);
                rowHandleListeGrid++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show(" lignes Achats est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
           // Creation Achats
                Achat A = new Achat();
       

            A.NFactureFounisseur = TxtFactureFounisseur.Text;
            A.Lines = ListeGrid;
            A.CodeFournisseur = F.Code;
            A.RaisonSociale = F.RaisonSociale;
            A.Total_AchatHT = ListeGrid.Sum(x => x.TotalLigneHT);
            A.Total_AchatTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
            A.MontantRegle = 0m;
            A.EtatAchat = EtatAchat.NonReglee;
            A.MontantReglement= ListeGrid.Sum(x => x.TotalLigneTTC);          
            db.Achats.Add(A);
            db.SaveChanges();
            A.Code = "FA" + (A.id).ToString("D8");
            db.SaveChanges();
            BtnImport.Text = string.Empty;
            XtraMessageBox.Show("Achat  a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();
          
         
            for (int i = 0; i < gridView1.RowCount;)
                gridView1.DeleteRow(i);
           
        }




        private void BtnImport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Pdf Files|*.pdf",
                Title = "Open Pdf File",
                InitialDirectory = @"C:\"
            })


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    BtnImport.Text = openFileDialog.FileName;

                    filePath = openFileDialog.FileName;




                }
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

        private void ViewDocuement_Click(object sender, EventArgs e)
        {
            string CodeAchat = gridView1.GetFocusedRowCellValue("Code").ToString();
            Achat GetAchatDB = db.Achats.Find(CodeAchat);

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

      

        private void repositoryItemButtonSupprimer_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void FrmAchats_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtFactureFounisseur;
        }
    }
}