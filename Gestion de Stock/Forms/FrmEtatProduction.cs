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
using Gestion_de_Stock.Repport;
using Gestion_de_Stock.Model;
using DevExpress.XtraReports.UI;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatProduction : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatProduction _FrmEtatProduction;

        public static FrmEtatProduction InstanceFrmEtatProduction
        {
            get
            {
                if (_FrmEtatProduction == null)
                    _FrmEtatProduction = new FrmEtatProduction();
                return _FrmEtatProduction;
            }
        }

        public FrmEtatProduction()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEtatProduction_Load(object sender, EventArgs e)
        {
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void FrmEtatProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatProduction = null;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
          
            EtatProduction EtatProduction = new EtatProduction();

            DateTime dateDébut = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            List<LigneProduction> ListeProduction = new List<LigneProduction>();

            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                ListeProduction = db.LigneProductions.Where(x => x.DateCreation >= dateDébut).OrderBy(x => x.DateCreation).ToList();

            }

            else
            {
                ListeProduction = db.LigneProductions.Where(x => x.DateCreation >= dateDébut && x.DateCreation <= datefin).OrderBy(x => x.DateCreation).ToList();

            }

            EtatProduction.Parameters["Du"].Value = dateDébut;

            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                EtatProduction.Parameters["Au"].Value = DateTime.Now;
            }

            else
            {
                EtatProduction.Parameters["Au"].Value = datefin;

            }
            EtatProduction.DataSource = ListeProduction;
            ReportPrintTool tool = new ReportPrintTool(EtatProduction);
            tool.ShowPreviewDialog();


        }
    }
}