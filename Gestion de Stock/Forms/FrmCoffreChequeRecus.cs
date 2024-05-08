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
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class Coffre : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static Coffre _FrmCoffre;

        public static Coffre InstanceFrmCoffre
        {
            get
            {
                if (_FrmCoffre == null)
                    _FrmCoffre = new Coffre();
                return _FrmCoffre;
            }
        }
        public Coffre()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void Coffre_Load(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Recu).ToList();
        }

        private void Coffre_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCoffre = null;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Cheques Recus.xlsx";

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

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Recu && x.DateEcheance.Value.CompareTo(DateMin) >= 0 && x.DateEcheance.Value.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateEcheance.Value).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Recu && x.DateEcheance.Value.CompareTo(DateMin) >= 0 && x.DateEcheance.Value.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateEcheance.Value).ToList();
        }

        private void repositoryBtnViremmentCaisse_Click(object sender, EventArgs e)
        {
            Coffrecheque Cheque = gridView1.GetFocusedRow() as Coffrecheque;
            db = new Model.ApplicationContext();
            Coffrecheque coffrecheque = db.CoffreCheques.Find(Cheque.Id);
            if (coffrecheque.StatutVirement == StatutVirement.VirementEffectué)
            {
                XtraMessageBox.Show("Votre demande est non autorisée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (coffrecheque != null)
            {
                if (XtraMessageBox.Show("voulez vous Transférer ce somme vers la Caisse ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {

                    coffrecheque.StatutVirement = Model.Enumuration.StatutVirement.VirementEffectué;
                    db.SaveChanges();
                    // Alimentation de Caisse


                    decimal Montant = coffrecheque.Montant;
                    Alimentation A = new Alimentation();
                    MouvementCaisse mvtCaisse = new MouvementCaisse();

                    A.Montant = Montant;
                    A.Source = SourceAlimentation.Vente;
                    mvtCaisse.Source = SourceAlimentation.Vente.ToString();


                    A.Commentaire = "Viremment  "+coffrecheque.NumVente+" "+ coffrecheque .ModePaiment.ToString()+ " Client " + coffrecheque.Client+" "+ coffrecheque.NumCheque;

                    mvtCaisse.MontantSens = Montant;

                    mvtCaisse.Date = A.DateCreation;

                    mvtCaisse.Sens = Sens.Alimentation;
                    mvtCaisse.Commentaire = "Viremment  " + coffrecheque.NumVente + " " + coffrecheque.ModePaiment.ToString() + " Client " + coffrecheque.Client + " " + coffrecheque.NumCheque;

                    Caisse CaisseDb = db.Caisse.Find(1);

                    if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, Montant);

                    }

                    mvtCaisse.Montant = CaisseDb.MontantTotal;

                    db.Alimentations.Add(A);
                    db.SaveChanges();

                    A.Numero = "E" + (A.Id).ToString("D8");
                    db.SaveChanges();

                    mvtCaisse.Numero = "E" + (A.Id).ToString("D8");
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();

                    XtraMessageBox.Show("Alimentation Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  

                    // waiting Form
                    SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(10);
                    }
                    SplashScreenManager.CloseForm();
                    //waiting Form 
                    if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();

                    if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();


                        if (db.MouvementsCaisse.Count() > 0)
                        {

                            List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                            MouvementCaisse mvt = ListeMvtCaisse.Last();

                            Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = mvt.Montant.ToString();

                        }
                    }


                    // Alimentation de caisse


                }
                else
                {

                    XtraMessageBox.Show("Le Transférer été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
                if (e.Column.FieldName == "StatutVirement")
                {
                    if (Convert.ToInt32(e.CellValue) == 0)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageNonReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 1)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }


                }
            }
        }
    }
}