﻿using System;
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
    public partial class FrmDetailsDevis : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmDetailsDevis _FrmDetaisDevis;
        public static FrmDetailsDevis InstanceFrmDetaisDevis
        {
            get
            {
                if (_FrmDetaisDevis == null)
                    _FrmDetaisDevis = new FrmDetailsDevis();
                return _FrmDetaisDevis;
            }
        }

        public FrmDetailsDevis()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetaisDevis_Load(object sender, EventArgs e)
        {
            SearchLookUpPack.DataSource = db.Packs.Select(x => new { x.Code, x.Designation, x.Quantity, x.PrixdeVenteRevendeur, x.PrixdeVentepublic, x.PrixdeVenteGros1, x.PrixdeVenteGros2 }).ToList();
        }

        private void FrmDetaisDevis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetaisDevis = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            // Devis DB
            //  Devis GetDevisDB = gridView1.GetFocusedRow() as Devis;
            string Code = TxtCodeDevis.Text;
            Devis GetDevisDB = db.Devis.Include("Client").Include("ligneDevis").FirstOrDefault(x => x.Code.Equals(Code));
            List<ligneDevis> ListeGrid = new List<ligneDevis>();

            int rowHandleListeGrid = 0;
            while (gridView1.IsValidRowHandle(rowHandleListeGrid))
            {
                var data = gridView1.GetRow(rowHandleListeGrid) as ligneDevis;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandleListeGrid);
                rowHandleListeGrid++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("ligne Devis est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                List<ligneDevis> ligneDevis = new List<ligneDevis>();
                foreach (var L in ListeGrid)
                {
                    ligneDevis Ld = new ligneDevis();
                    Ld.Description = L.Description;
                    Ld.Description = L.Description;
                    Ld.PrixHT = L.PrixHT;
                    Ld.Remise = L.Remise;
                    Ld.Qty = L.Qty;                   
                    Ld.TVA = GetDevisDB.TVA;
                    ligneDevis.Add(Ld);
                }
                var ListeLigne = GetDevisDB.ligneDevis.ToList();
                foreach (var lignedevis in ListeLigne)
                {
                    ligneDevis Ld = db.ligneDevis.Find(lignedevis.Id);
                    db.ligneDevis.Remove(Ld);
                    db.SaveChanges();
                }

                GetDevisDB.ligneDevis = ligneDevis;

                db.SaveChanges();
                GetDevisDB.Total_DevisHT = ListeGrid.Sum(x => x.TotalLigneHT);
                GetDevisDB.Total_DevisTTC = ListeGrid.Sum(x => x.TotalLigneTTC);

                db.SaveChanges();
                this.Hide();
                // waiting Form
                SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                }
                SplashScreenManager.CloseForm();
                //waiting Form 
                if (Application.OpenForms.OfType<FrmListeDevis>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeDevis>().First().devisBindingSource.DataSource = db.Devis.Include("Client").Include("ligneDevis").OrderByDescending(x => x.DateCreation).ToList();
                XtraMessageBox.Show("Devis e a été  Modifier", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                // get price of current Pack 

                string DesignationPack = gridView1.GetFocusedRowCellValue("Description").ToString();
                pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(DesignationPack));
                repositoryItemComboBoxListePrice.Items.Clear();
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros1);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros2);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVentepublic);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteRevendeur);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PrixHT", repositoryItemComboBoxListePrice.Items[0]);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", 1);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Description", pack.Designation); 
            }
        }

        private void SearchLookUpPack_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            GridView view2 = editor.Properties.View;
            int rowHandle2 = view2.FocusedRowHandle;
            string fieldName2 = "Designation"; // or other field name  
            object PackSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
            if (PackSelected != null)
            {
                pack = db.Packs.FirstOrDefault(x => x.Designation.Equals(PackSelected.ToString()));
                //if (gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
                //{

                repositoryItemComboBoxListePrice.Items.Clear();
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros1);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteGros2);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVentepublic);
                repositoryItemComboBoxListePrice.Items.Add(pack.PrixdeVenteRevendeur);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PrixHT", repositoryItemComboBoxListePrice.Items[0]);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Description", pack.Designation);


                //  }

            }
        }
    }
}