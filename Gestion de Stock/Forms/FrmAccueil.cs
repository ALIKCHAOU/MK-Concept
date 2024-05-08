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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraReports.Parameters;
using System.ComponentModel.Composition.Hosting;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAccueil : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAccueil _FrmAccueil;
        public static FrmAccueil InstanceFrmAccueil
        {
            get
            {
                if (_FrmAccueil == null)
                    _FrmAccueil = new FrmAccueil();
                return _FrmAccueil;
            }
        }
        public FrmAccueil()
        {
            InitializeComponent();
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
        public void Formshow(Form frm)
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
            frm.MdiParent =Application.OpenForms.OfType<MainRibbonForm>().First();
            frm.Show();
            frm.Activate();
        }

        private void FrmAccueil_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAccueil = null;
        }

     

        private void tileIFactures_ItemClick(object sender, TileItemEventArgs e)
        {
          
        }

        private void tileISociete_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSociete.InstanceFrmSociete);
        }

       

        private void tileIClients_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmClient.InstanceFrmClient); 
        }

        private void tileICaisse_ItemClick(object sender, TileItemEventArgs e)
        {
            //FrmCaisse
        }

        private void tileIFrounisseurs_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmFournisseur.InstanceFrmFournisseur);
        }

        private void tileImportClient_ItemClick(object sender, TileItemEventArgs e)
        {
        
        }

        private void tileProduits_ItemClick(object sender, TileItemEventArgs e)
        {
            //Formshow(Gestion_de_Stock.Forms.FrmProduits.InstanceFrmProduit);
         // Formshow(Gestion_de_Stock.Forms.FrmAjouterArticle.InstanceFrmAjouterArticle);
        }

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            // verification de licence
           //  LicenseInvalideLayout(tileIClients);
            //   AuthorisationdeLayout(tileIClients);

        }
        void LicenseInvalideLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }
        void AuthorisationdeLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }

        private void tileIAchat_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAchats.InstanceFrmAchats);
        }

       

        private void tileIJournalAchat_ItemClick(object sender, TileItemEventArgs e)
        {

            Formshow(Gestion_de_Stock.Forms.FrmListeAchats.InstanceFrmListeAchats);
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmCreerDevis.InstanceFrmCreerDevis); 
        }


        private void tileItemListeDevis_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeDevis.InstanceFrmListeDevis);
        }

        private void tileIVente_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeFactures.InstanceFrmListeFactures);
        }

    

     

        private void BtnListeVentes_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Forms.FrmListeVente.InstanceFrmListeVente);
        }

       
    }
}