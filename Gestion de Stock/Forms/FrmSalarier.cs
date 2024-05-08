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
using DevExpress.XtraGrid.Views.Grid;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSalarier : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmSalarier _FrmOuvrier;
        internal object salarieBindingSource;

        public static FrmSalarier InstanceFrmOuvrier
        {
            get
            {
                if (_FrmOuvrier == null)
                    _FrmOuvrier = new FrmSalarier();
                return _FrmOuvrier;
            }
        }

        public FrmSalarier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }



        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
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

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer ce salarié ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Salarier S = gridView1.GetFocusedRow() as Salarier;
                if (S == null)
                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Salarier SalarierDb = db.Salariers.Find(S.Id);

                Depense DepSal = db.Depenses.Where(x => x.Salarie.Id == SalarierDb.Id).FirstOrDefault();

                if (DepSal != null)

                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.Salariers.Remove(SalarierDb);
                    db.SaveChanges();


                    /***************************** reload DataGridView ***********************************/
                    salarierBindingSource.DataSource = db.Salariers.ToList();



                    if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault().salarierBindingSource.DataSource = db.Salariers.ToList();



                    /***************************** reload DataGridView  ***********************************/
                    XtraMessageBox.Show("Salarié Supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
            }
            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmOuvrier = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterOuvrier.InstanceFrmAjouterOuvrier);
        }

        private void FrmOuvrier_Load(object sender, EventArgs e)
        {
            List<Salarier> SalarieList = db.Salariers.ToList();
            salarierBindingSource.DataSource = SalarieList;

        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            Salarier S = gridView1.GetFocusedRow() as Salarier;

            db = new Model.ApplicationContext();

            if (S != null)
            {
                Salarier SalarieDb = db.Salariers.Find(S.Id);
                FormshowNotParent(Forms.FrmModifierOuvrier.InstanceFrmModifierOuvrier);
                if (Application.OpenForms.OfType<FrmModifierOuvrier>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtNumero.Text = SalarieDb.Id.ToString();
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtIntitule.Text = SalarieDb.Intitule.ToString();
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtTel.Text = SalarieDb.Tel.ToString();
                    if(SalarieDb.Matricule!=null)
                    {
                        Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtMatricule.Text = SalarieDb.Matricule.ToString();

                    }
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtMontant.Text = SalarieDb.MontantJournalie.ToString();




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
                if (e.Column.FieldName == "EtatSalarie")
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
    }
}