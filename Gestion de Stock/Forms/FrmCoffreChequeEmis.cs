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
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmCoffreChequeEmis : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmCoffreChequeEmis _FrmCoffreChequeEmis;

        public static FrmCoffreChequeEmis InstanceFrmCoffreChequeEmis
        {
            get
            {
                if (_FrmCoffreChequeEmis == null)
                    _FrmCoffreChequeEmis = new FrmCoffreChequeEmis();
                return _FrmCoffreChequeEmis;
            }
        }

        public FrmCoffreChequeEmis()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmCoffreChequeSalarie_Load(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Emis).ToList();
        }

        private void FrmCoffreChequeSalarie_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCoffreChequeEmis = null;
        }

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Emis && x.DateEcheance.Value.CompareTo(DateMin) >= 0 && x.DateEcheance.Value.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateEcheance.Value).ToList();
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);
            coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == Model.Enumuration.ChequeType.Emis && x.DateEcheance.Value.CompareTo(DateMin) >= 0 && x.DateEcheance.Value.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.DateEcheance.Value).ToList();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Cheques Emis.xlsx";

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

        private void repositoryAjouterRetrait_Click(object sender, EventArgs e)
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
                if (XtraMessageBox.Show("voulez vous Retrait ce somme vers la Caisse ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {

                    coffrecheque.StatutVirement = Model.Enumuration.StatutVirement.VirementEffectué;
                    db.SaveChanges();
                    // Deponse de Caisse
                    decimal Montant = coffrecheque.Montant;
                    Caisse CaisseDb = db.Caisse.Find(1);
                    if (Montant > 0)
                    {
                        if (CaisseDb.MontantTotal >= Montant)
                        {
                            Depense D = new Depense();
                            D.Nature = NatureMouvement.Autre;
                            D.Montant = Montant;
                            D.ModePaiement = "Retrait " + coffrecheque.NumVente + " " + coffrecheque.ModePaiment.ToString() + " Client " + coffrecheque.Client + " " + coffrecheque.NumCheque; ;
                            D.Commentaire = "Retrait " + coffrecheque.NumVente + " " + coffrecheque.ModePaiment.ToString() + " Client " + coffrecheque.Client + " " + coffrecheque.NumCheque; ;
                            db.Depenses.Add(D);
                            db.SaveChanges();
                            D.Numero = "D" + (D.Id).ToString("D8");
                            db.SaveChanges();

                            MouvementCaisse mvtCaisse = new MouvementCaisse();

                            int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                            mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                            mvtCaisse.Date = D.DateCreation;

                            mvtCaisse.MontantSens = Montant * -1;
                            mvtCaisse.Sens = Sens.Depense;
                          
                            mvtCaisse.Source = " Retrait " + coffrecheque.NumVente + " " + coffrecheque.ModePaiment.ToString() + " Client " + coffrecheque.Client + " " + coffrecheque.NumCheque; ;
                          


                            mvtCaisse.NatureDepense = D;
                            mvtCaisse.Commentaire = "Retrait" + coffrecheque.NumVente + " " + coffrecheque.ModePaiment.ToString() + " Client " + coffrecheque.Client + " " + coffrecheque.NumCheque; ;

                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, Montant);
                            db.SaveChanges();

                            mvtCaisse.Montant = CaisseDb.MontantTotal;
                            db.MouvementsCaisse.Add(mvtCaisse);
                            db.SaveChanges();


                            //waiting Form 
                            if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                                Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.OrderByDescending(x => x.DateCreation).ToList();

                            if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                                Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = db.CoffreCheques.Where(x => x.ChequeType == ChequeType.Emis).OrderByDescending(x => x.DateCreation).ToList();

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
                        }
                        else
                        {
                            XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                            return;

                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Montant est Invalid Caisse", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        return;

                    }

                    // waiting Form
                    SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(10);
                    }
                    SplashScreenManager.CloseForm();



                    // Deponse de caisse


                }
                else
                {

                    XtraMessageBox.Show("Le Retrait été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
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