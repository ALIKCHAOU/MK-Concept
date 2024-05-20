using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraWaitForm;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Forms;
using System.ComponentModel.Composition.Hosting;

namespace Gestion_de_Stock
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Model.ApplicationContext db;
        public MainRibbonForm()
        {
            InitializeComponent();
        }

        private void barSociete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSociete.InstanceFrmSociete);
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
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
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

      
      

        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     

       

       

       
        private void barAjouterfournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmAjouterFournisseur.InstanceFrmAjouterFournisseur);
        }

        private void barlisteClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bardashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAccueil.InstanceFrmAccueil);
        }

        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAccueil.InstanceFrmAccueil);
        }

        private void barFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmFournisseur.InstanceFrmFournisseur);
        }

        private void barAchat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAchats.InstanceFrmAchats);
        }


        private void barBtnListeAchats_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeAchats.InstanceFrmListeAchats);
        }

      


        private void barButtonItemDevis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmCreerDevis.InstanceFrmCreerDevis);
        }

        private void barButtonItemListeDevis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeDevis.InstanceFrmListeDevis);
        }

       

        private void barButtonItemAjouterClient_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItemListeClients_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmClient.InstanceFrmClient);
        }

       

        private void barButtonItemmatricule_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmMatriculeFiscale.InstanceFrmMatriculeFiscale);
        }


      

        private void barButtonMatierePremier_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

       

        private void barBtnListeFactures_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeFactures.InstanceFrmListeFactures);
        }

        private void barBtnFacture_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmCreerFacture.InstanceFrmCreerFacture); 
        }

        private void barBtnAjouterClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmAjouterClient.InstanceFrmAjouterClient);
        }

        private void barBtnCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmMouvementCaisse.InstanceFrmMouvementCaisse);
        }

        private void barBtnClotureCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous Clôturer la Caisse ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                db = new Model.ApplicationContext();

                Caisse CaisseDb = db.Caisse.Find(1);

                decimal MontantCaisse = CaisseDb.MontantTotal;

                if (MontantCaisse == 0)
                {
                    XtraMessageBox.Show("Caisse Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    FormshowNotParent(Gestion_de_Stock.Forms.FrmClotureCaisse.InstanceFrmClotureCaisse);
                }


            }
        }

        private void barButtonItemAjouterAlimentation_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterAlimentation.InstanceFrmAlimentation);
        }

        private void barButtonItemAjouertDepense_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterDepense.InstanceFrmDepense);
        }

        private void barButtonListeAlimentation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeAlimentation.InstanceFrmListeAlimentation);
        }

        private void barButtonListeDeponse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeDepenses.InstanceFrmListeDepenses);
        }

        private void barBtnChequeReçu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.Coffre.InstanceFrmCoffre);
        }

        private void barBtnChequeEmis_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            Formshow(Gestion_de_Stock.Forms.FrmCoffreChequeEmis.InstanceFrmCoffreChequeEmis);
        }

        private void barButtonItemListeSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSalarier.InstanceFrmOuvrier);
        }

        private void barButtonListePointages_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListePointages.InstanceFrmListePointages);
        }

        private void barBtnEtatCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatCaisse.InstanceFrmEtatCaisse);
        }

        private void barBtnEtatdeProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barListedesventes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmListeVente.InstanceFrmListeVente);
        }

        private void barBtnSuivie_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barBtnEtatsClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatClient.InstanceFrmEtatClient);
        }

        private void barBntFounisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatFournisseur.InstanceFrmEtatFournisseur);
        }

        private void btnEtatDepenseParNature_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatDepenseParNature.InstanceFrmEtatDepenseParNature);
        }

        private void barEtatFinancierGlobal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatFinancierGlobal.InstanceFrmEtatFinancierGlobal);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmListeDepenseSalarier.InstanceFrmListeDepenseSalarier); 
        }

        private void barBtnAjouterPointage_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterPointage.InstanceFrmAjouterPointage);
        }

        private void barBtnCrrerBondeLivraisons_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

      
        private void barEtatVente_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatVente.InstanceFrmEtatVente);
        }

        private void btnEtatAchat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatAchat.InstanceFrmEtatAchat);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xx = new EditeurRapport(new CompositionContainer());
            xx.Show();
        }

      

     

      

        private void barArticlesChutes_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barEtatdeStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmEtatStock.InstanceFrmEtatStock);
        }

        private void ListedesPrixdesFournissuers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.FrmListedesPrixFournisseurs.InstanceFrmListedesPrixFournisseurs);
        }

        private void barlistedesprixso_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.FrmListedesPrixSociete.InstanceFrmListedesPrixSociete);
        }
    }

}