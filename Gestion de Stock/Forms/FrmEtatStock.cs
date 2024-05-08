using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Repport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatStock : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmEtatStock _FrmEtatStock;
        public static FrmEtatStock InstanceFrmEtatStock
        {
            get
            {
                if (_FrmEtatStock == null)
                {
                    _FrmEtatStock = new FrmEtatStock();
                }

                return _FrmEtatStock;
            }
        }
        public FrmEtatStock()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEtatStock_Load(object sender, EventArgs e)
        {

            articleBindingSource.DataSource = db.Articles.OrderByDescending(x => x.DateCreation).ToList();
        }

        private void FrmEtatStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatStock = null;
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            RapportEtatStock RapportEtatStock = new RapportEtatStock();

            //DateTime DateMin = DateDebut.DateTime;

            // DateTime Datefin = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            // RapportEtatStock.Parameters["Du"].Value = DateMin;

            //if (Datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            //{
            //    RapportEtatStock.Parameters["Au"].Value = DateTime.Now;
            //}

            //else
            //{
            //    RapportEtatStock.Parameters["Au"].Value = Datefin;
            //}


            RapportEtatStock.Parameters["DateImpression"].Value = DateTime.Now;
            List<Article> EtatStock = new List<Article>();
            //if (Datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            //{

            EtatStock = db.Articles.OrderBy(x => x.Code).ToList();


            //}
            //else
            //{
            //    EtatStock = db.Packs.Where(x => x.DateCreation >= DateMin && x.DateCreation <= Datefin).OrderBy(x => x.Code).ToList();
            //}
            RapportEtatStock.DataSource = EtatStock;

            ReportPrintTool tool = new ReportPrintTool(RapportEtatStock);
            tool.ShowPreviewDialog();
        }


    }
}