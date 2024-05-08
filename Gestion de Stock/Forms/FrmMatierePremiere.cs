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
using System.Data.Entity.Validation;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMatierePremiere : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        decimal PrixAchat;
        decimal Quantity;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private static FrmMatierePremiere _FrmMatierePremiere;
        public static FrmMatierePremiere InstanceFrmMatierePremiere
        {
            get
            {
                if (_FrmMatierePremiere == null)
                    _FrmMatierePremiere = new FrmMatierePremiere();
                return _FrmMatierePremiere;
            }
        }

        public FrmMatierePremiere()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmMatierePremiere_Load(object sender, EventArgs e)
        {
            
            matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();

        }

        private void FrmMatierePremiere_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMatierePremiere = null;
        }

        private void AjouterMatierePremiere_Click(object sender, EventArgs e)
        {
            //  conversion  Quantite
            decimal Quantite;
            string QuantiteStr = TxtQuantite.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QuantiteStr, out Quantite);



            try
            {
                string NameMatierePremiere = TxtNomMatierePremiere.Text.Trim();
                if (string.IsNullOrEmpty(NameMatierePremiere))
                {
                    TxtNomMatierePremiere.ErrorText = "Nom Matiere Premiere  est obligatoire";
                    return;

                }
              
                MatierePremiere matierePremiereDB = db.MatierePremieres.FirstOrDefault(x => x.Nom.ToUpper().Equals(NameMatierePremiere.ToUpper()));
                if (matierePremiereDB!=null)
                {
                    TxtNomMatierePremiere.ErrorText = "Nom Matiere Premiere  existe déjà ";
                    return;

                }
             
                var mp = new MatierePremiere();
                mp.Nom = NameMatierePremiere;
                mp.Unite = MpUniteComboBox.Text;
                mp.Description = TxtDescription.Text.Trim();
                mp.Quantity = Quantite;
                db.MatierePremieres.Add(mp);
                db.SaveChanges();             
                mp.Code = "M" + (mp.Id).ToString("D8");               
                db.SaveChanges();
                XtraMessageBox.Show("Enregisterment Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();
                TxtNomMatierePremiere.Text = string.Empty;
                TxtDescription.Text = string.Empty;              

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().First().matierePremiereBindingSource.DataSource = db.MatierePremieres.Select(x => new { x.Code, x.Nom, x.Description, x.Unite }).ToList();

                if (Application.OpenForms.OfType<FrmProductions>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmProductions>().First().matierePremiereBindingSource.DataSource = db.MatierePremieres.Select(x => new { x.Code, x.Nom, x.Description, x.Quantity }).ToList();
                
            }
            catch (DbEntityValidationException ex)
            {
                var errors = "";
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        if (!errors.Contains(ve.ErrorMessage))
                        {
                            errors += ve.ErrorMessage + "\n";
                        }
                    }
                }
                MessageBox.Show(errors);
            }
        }

      
        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Matieres Premieres.xlsx";          
            gridControl1.ExportToXlsx(path);
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

        private void FrmMatierePremiere_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtNomMatierePremiere;
        }

        private void repositoryItemButtonSupprimer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeM = gridView1.GetFocusedRowCellValue("Code").ToString();
            MatierePremiere MatierePremiere = db.MatierePremieres.FirstOrDefault(x => x.Code.Equals(CodeM));
         
           
            if(!CodeM.Equals("M00000001"))
            {
                try { 
                db.MatierePremieres.Remove(MatierePremiere);
                db.SaveChanges();
                XtraMessageBox.Show("Suppression Terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                matierePremiereBindingSource.DataSource = db.MatierePremieres.ToList();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erreur de Suppression", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                XtraMessageBox.Show("Erreur de Suppression", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}