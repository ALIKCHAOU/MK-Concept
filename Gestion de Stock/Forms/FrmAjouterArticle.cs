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
using DevExpress.XtraSplashScreen;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterArticle : DevExpress.XtraEditors.XtraForm
    {
        private decimal MontantPrixvente=0m, MontantPrixventeGros1=0m, MontantPrixventeGros2=0m, MontantPrixventePublic=0m;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmAjouterArticle _frmPack;
        public static FrmAjouterArticle InstanceFrmPack
        {
            get
            {
                if (_frmPack == null)
                    _frmPack = new FrmAjouterArticle();
                return _frmPack;
            }
        }
      
        public FrmAjouterArticle()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }


                                    
        private void FrmPack_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmPack = null;
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


        private void ListeMatiere_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtDesignation.Text))
            {
                TxtDesignation.ErrorText = "Designation  est obligatoire";
                XtraMessageBox.Show("Designation est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            if (String.IsNullOrEmpty(TxTPrixdeVenteRevendeur.Text))
            {
                TxTPrixdeVenteRevendeur.ErrorText = "Prix Vente Revendeur est obligatoire";
                XtraMessageBox.Show("Prix Vente Revendeur est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            if (String.IsNullOrEmpty(TxTPrixdeVenteGros1.Text))
            {
                TxTPrixdeVenteGros1.ErrorText = "Prix Vente Gros 1  est obligatoire";
                XtraMessageBox.Show("Prix Vente Gros 1 est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            if (String.IsNullOrEmpty(TxTPrixdeVenteGros2.Text))
            {
                TxTPrixdeVenteGros2.ErrorText = "Prix Vente Gros 2  est obligatoire";
                XtraMessageBox.Show("Prix Vente Gros 2 est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            if (String.IsNullOrEmpty(TxTPrixdeVenteGros2.Text))
            {
                TxTPrixdeVenteGros2.ErrorText = "Prix Vente Gros 2  est obligatoire";
                XtraMessageBox.Show("Prix Vente Gros 2 est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            if (String.IsNullOrEmpty(TxTPrixdeVentePublic.Text))
            {
                TxTPrixdeVentePublic.ErrorText = "Prix Vente Public  est obligatoire";
                XtraMessageBox.Show("Prix Vente Public est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }



            //  conversion  Prix vente  Revendeur
            string MontantPrixUStr = TxTPrixdeVenteRevendeur.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantPrixUStr, out MontantPrixvente);
            if (MontantPrixvente <= 0)
            {
                TxTPrixdeVenteRevendeur.ErrorText = "Prix de Vente Revendeur  est obligatoire";
                XtraMessageBox.Show("Prix de Vente Revendeur est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            //  conversion  Prix vente  Gros 1
            string MontantPrixventeGros1UStr = TxTPrixdeVenteGros1.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantPrixventeGros1UStr, out MontantPrixventeGros1);
            if (MontantPrixventeGros1 <= 0)
            {
                TxTPrixdeVenteGros1.ErrorText = "Prix de  Vente Gros1  est obligatoire";
                XtraMessageBox.Show("Prix de Vente Gros 1 est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            //  conversion  Prix vente  Gros 2
            string MontantPrixventeGros2UStr = TxTPrixdeVenteGros2.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantPrixventeGros2UStr, out MontantPrixventeGros2);
            if (MontantPrixventeGros2 <= 0)
            {
                TxTPrixdeVenteGros2.ErrorText = "Prix de  Vente Gros2  est obligatoire";
                XtraMessageBox.Show("Prix de Vente Gros2  est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            //  conversion  Prix vente  Public
            string MontantPrixventePublicUStr = TxTPrixdeVentePublic.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantPrixventePublicUStr, out MontantPrixventePublic);
            if (MontantPrixventePublic <= 0)
            {
                TxTPrixdeVentePublic.ErrorText = "Prix de  Vente Public  est obligatoire";
                XtraMessageBox.Show("Prix de Vente Public  est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

            }
            Article Pack = new Article();
            if(CheckGere.Checked)
            {
                Pack.GereStock = true;
            }
          
            Pack.Designation = TxtDesignation.Text;
            Pack.PrixdeVenteRevendeur = MontantPrixvente;
            Pack.PrixdeVenteGros1 = MontantPrixventeGros1;
            Pack.PrixdeVenteGros2 = MontantPrixventeGros2;
            Pack.PrixdeVentepublic = MontantPrixventePublic;
            Pack.Metrage =  string.IsNullOrEmpty(TxtMetrage.Text)?0 : Convert.ToInt32(TxtMetrage.Text);
            db.Packs.Add(Pack);
            db.SaveChanges();
            Pack.Code = "P" + (Pack.Id).ToString("D8");
            db.SaveChanges();
            XtraMessageBox.Show("Article a été Ajouté", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtDesignation.Text = string.Empty;            
            TxTPrixdeVenteRevendeur.Text = string.Empty;
            TxTPrixdeVenteGros1.Text = string.Empty;
            TxTPrixdeVenteGros2.Text = string.Empty;
            TxTPrixdeVentePublic.Text = string.Empty;
            CheckGere.Checked = false;
            TxtCode.Text = "P" + (Pack.Id + 1).ToString("D8");
            articleBindingSource.DataSource = db.Packs.Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation ,x.Quantity}).ToList();


            if (Application.OpenForms.OfType<FrmCreerDevis>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCreerDevis>().First().SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity}).ToList();

   

            if (Application.OpenForms.OfType<FrmCreerFacture>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCreerFacture>().First().SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity }).ToList();

        }

        private void repositoryItemButtonSupprimer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            if (XtraMessageBox.Show("Voulez-vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string CodeArticle = gridView1.GetFocusedRowCellValue("Code").ToString();               
                var articleDeleted = db.Packs.FirstOrDefault(x => x.Code == CodeArticle);
                if (articleDeleted != null)
                {
                    db.Packs.Remove(articleDeleted);
                    db.SaveChanges();
                    XtraMessageBox.Show("L'article a été supprimé.", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    articleBindingSource.DataSource = db.Packs.Where(x => x.IdArticlechute == 0).Select(x => new { x.Code, x.PrixdeVenteGros1, x.PrixdeVenteGros2, x.PrixdeVentepublic, x.PrixdeVenteRevendeur, x.Designation, x.Quantity }).ToList();
                    articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage, x.TotalPoids }).ToList();
                    // Refresh the grid to reflect the updated data
                    // waiting Form
                    SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(10);
                    }
                    SplashScreenManager.CloseForm();
                    //waiting Form 

                }
                else
                {
                    XtraMessageBox.Show("L'article n'a pas été trouvé.", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("La suppression a été annulée.", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void repositoryItemButtonModifier_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            string CodeArticle = gridView1.GetFocusedRowCellValue("Code").ToString();
            Article article = db.Packs.FirstOrDefault(x => x.Code == CodeArticle);
            if (article != null)
            {
                

                FormshowNotParent(Forms.FrmModifierArticle.InstanceFrmModifierArticle);
                if (Application.OpenForms.OfType<FrmModifierArticle>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtCodeArticle.Text = article.Code;
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtDésignation.Text = article.Designation;
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtPrixventeGros1.Text = article.PrixdeVenteGros1.ToString();
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtPrixVenteGros2.Text = article.PrixdeVenteGros2.ToString();
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtPrixVentePublic.Text = article.PrixdeVentepublic.ToString();
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtPrixRevendeur.Text = article.PrixdeVenteRevendeur.ToString();
                    Application.OpenForms.OfType<FrmModifierArticle>().First().TxtQte.Text = article.Quantity.ToString();
                }
            }

            else
            {
                XtraMessageBox.Show("Veuillez sélectionner une article", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void FrmAjouterPack_Load(object sender, EventArgs e)
        {
            TxtDesignation.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;           
            TxTPrixdeVenteRevendeur.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxTPrixdeVenteGros1.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxTPrixdeVenteGros2.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxTPrixdeVentePublic.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            List<Article> lastPacks = db.Packs.OrderByDescending(x => x.DateCreation).ToList();
            if (lastPacks.Count == 0)
            {
                
                TxtCode.Text = "P00000001";
            }
            else
            {
                TxtCode.Text = "P" + (lastPacks.FirstOrDefault().Id+1).ToString("D8");
            }
          articleBindingSource.DataSource = db.Packs.Where(x=>x.IdArticlechute==0).Select(x => new { x.Code, x.PrixdeVenteGros1,x.PrixdeVenteGros2, x.PrixdeVentepublic,x.PrixdeVenteRevendeur,x.Designation ,x.Quantity}).ToList();
          articleBindingSource1.DataSource = db.Packs.Where(x => x.IdArticlechute != 0).Select(x => new { x.Code, x.Designation, x.Quantity, x.Metrage,x.TotalPoids }).ToList();
        }

        private void FrmAjouterPack_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtDesignation;
        }

        private void FrmAjouterPack_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmPack = null;
        }
    }
}