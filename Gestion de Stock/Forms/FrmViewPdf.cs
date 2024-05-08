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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmViewPdf : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmViewPdf _FrmFrmViewPdf;
        public static FrmViewPdf InstanceFrmViewPdf
        {
            get
            {
                if (_FrmFrmViewPdf == null)
                    _FrmFrmViewPdf = new FrmViewPdf();
                return _FrmFrmViewPdf;
            }
        }

        public FrmViewPdf()
        {
            InitializeComponent();
        }
     
        private void FrmViewPdf_Load(object sender, EventArgs e)
        {

        }

        private void FrmViewPdf_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmFrmViewPdf = null;
        }
    }
}