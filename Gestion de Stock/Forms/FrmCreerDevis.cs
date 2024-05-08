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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model;
using System.Globalization;
using System.Threading;
using System.IO;
using DevExpress.XtraGrid;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmCreerDevis : DevExpress.XtraEditors.XtraForm
    {
        private Article pack = new Article();
        private string filePath = string.Empty;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmCreerDevis _FrmCreerDevis;
        public static FrmCreerDevis InstanceFrmCreerDevis
        {
            get
            {
                if (_FrmCreerDevis == null)
                    _FrmCreerDevis = new FrmCreerDevis();
                return _FrmCreerDevis;
            }
        }
        public FrmCreerDevis()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmCreerDevis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCreerDevis = null;
        }



        private void FrmCreerDevis_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Adresse, x.Ville }).ToList();

            dateEditDateDevis.DateTime = DateTime.Now;
            /***********************  Mode  Paiement Liste  ***********************/

            Devis D = new Devis();
            TxTReference.Text = D.Reference;
            TXTTVA.Text = "19";
            dateEditValidite.DateTime = DateTime.Now.AddDays(7);



        }

        private void BtnCrrerDevis_Click(object sender, EventArgs e)
        {
            List<ligneDevis> ListeGrid = new List<ligneDevis>();
            int rowHandle = 0;
            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as ligneDevis;
                ListeGrid.Add(data);
                bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("'ligne Devis est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            GridView view2 = searchLookUpEdit1.Properties.View;
            int rowHandle2 = view2.FocusedRowHandle;
            string fieldName2 = "Code"; // or other field name  
            object ClientSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
            ///Condition existance Fournisseur
            if (ClientSelected == null)
            {
                XtraMessageBox.Show("'Client est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            Client client = db.Clients.Find(ClientSelected);
            Devis devis = new Devis();
            devis.Client = client;
            devis.TVA = int.Parse(TXTTVA.Text);
            foreach (var L in ListeGrid)
            {
                L.TVA = devis.TVA;
            }
            devis.ligneDevis = ListeGrid;
            devis.Reference = TxTReference.Text;

            if (!String.IsNullOrEmpty(filePath))
            {
                byte[] imag = File.ReadAllBytes(filePath);
                devis.Attachment = imag;
                devis.FileName = filePath;
            }
            devis.Total_DevisHT = ListeGrid.Sum(x => x.TotalLigneHT);
            devis.Total_DevisTTC = decimal.Add(devis.Total_DevisHT, devis.TOTALTVA);// ListeGrid.Sum(x => x.TotalLigneTTC);
            db.Devis.Add(devis);
            db.SaveChanges();
            XtraMessageBox.Show("Devis e a été  Ajouter", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < gridView1.RowCount;)
                gridView1.DeleteRow(i);
         
            Devis D = new Devis();
            TxTReference.Text = D.Reference;
            //waiting Form 
            if (Application.OpenForms.OfType<FrmListeDevis>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDevis>().First().devisBindingSource.DataSource = db.Devis.Include("Client").Include("ligneDevis").OrderByDescending(x => x.DateCreation).ToList();



        }

    

       

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

            gridView1.DeleteSelectedRows();

        }





        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //  GridView view3 = SearchLookUpPack.Properties.View;

            GridView view2 = searchLookUpEdit1.Properties.View;
            int rowHandle2 = view2.FocusedRowHandle;
            string fieldName2 = "Code"; // or other field name  
            object ClientSelected = view2.GetRowCellValue(rowHandle2, fieldName2);
            ///Condition existance Fournisseur
            if (ClientSelected == null)
            {
                XtraMessageBox.Show("'Client est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEdit1.Focus();
                return;

            }
            else
            {
                Client client = db.Clients.Find(ClientSelected);
               

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
                 pack = db.Articles.FirstOrDefault(x => x.Designation.Equals(PackSelected.ToString()));
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