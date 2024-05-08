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
    public partial class FrmDetailsProduction : DevExpress.XtraEditors.XtraForm
    {
        public FrmDetailsProduction()
        {
            InitializeComponent();
        }
        private Model.ApplicationContext db;

        private static FrmDetailsProduction _FrmDetailsProduction;

        public static FrmDetailsProduction InstanceFrmDetailsProduction
        {
            get
            {
                if (_FrmDetailsProduction == null)
                    _FrmDetailsProduction = new FrmDetailsProduction();
                return _FrmDetailsProduction;
            }
        }
        private void FrmDetailsProduction_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailsProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailsProduction = null;
        }
    }
}