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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmDetailsAchats : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmDetailsAchats _FrmdetaisAchats;
        public static FrmDetailsAchats InstanceFrmdetaisAchats
        {
            get
            {
                if (_FrmdetaisAchats == null)
                    _FrmdetaisAchats = new FrmDetailsAchats();
                return _FrmdetaisAchats;
            }
        }

        public FrmDetailsAchats()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmdetaisAchats_Load(object sender, EventArgs e)
        {

        }

        private void FrmdetaisAchats_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmdetaisAchats = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            string CodeAchat = TxtNumAchats.Text;
            Achat GetAchatDB = db.Achats.Include("Lines").Where(x => x.Code.Equals(CodeAchat)).FirstOrDefault();
            if (GetAchatDB.EtatAchat == Model.Enumuration.EtatAchat.NonReglee)
            {
                List<LigneAchats> ListeGrid = new List<LigneAchats>();

                int rowHandleListeGrid = 0;
                while (gridView1.IsValidRowHandle(rowHandleListeGrid))
                {
                    var data = gridView1.GetRow(rowHandleListeGrid) as LigneAchats;
                    ListeGrid.Add(data);
                    bool isSelected = gridView1.IsRowSelected(rowHandleListeGrid);
                    rowHandleListeGrid++;
                }
                List<LigneAchats> LigneAchatDb = GetAchatDB.Lines.ToList();

               

                foreach (var linge in LigneAchatDb)
                {
                    LigneAchats ligneAchatsdb = db.LigneAchats.Find(linge.Id);
                    db.LigneAchats.Remove(ligneAchatsdb);
                    db.SaveChanges();
                }
                foreach (var linge in ListeGrid)
                {
                    LigneAchats L = new LigneAchats();
                    L.NomArticle = linge.NomArticle;
                        L.Quantity = linge.Quantity;
                    L.unite = linge.unite;
                    L.TVA = linge.TVA;
                    L.PrixUnitaire = linge.PrixUnitaire;  
                    GetAchatDB.Lines.Add(L);
                }
              
                GetAchatDB.Total_AchatHT = ListeGrid.Sum(x => x.TotalLigneHT);
                GetAchatDB.Total_AchatTTC = ListeGrid.Sum(x => x.TotalLigneTTC);
                GetAchatDB.MontantReglement = ListeGrid.Sum(x => x.TotalLigneTTC);
                GetAchatDB.MontantRegle = 0m;
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
                XtraMessageBox.Show("Achat a été  mise a Jour", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.OrderByDescending(x => x.DateCreation).ToList();
            }
            else
            {
                XtraMessageBox.Show("Impossible de mettre à jour cette Achat", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}