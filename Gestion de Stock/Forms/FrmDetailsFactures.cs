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
    public partial class FrmDetailsFactures : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmDetailsFactures _FrmDetaisFactures;
        public static FrmDetailsFactures InstanceDetaisFactures
        {
            get
            {
                if (_FrmDetaisFactures == null)
                    _FrmDetaisFactures = new FrmDetailsFactures();
                return _FrmDetaisFactures;
            }
        }

        public FrmDetailsFactures()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetaisFactures_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetaisFactures = null;
        }

        private void FrmDetaisFactures_Load(object sender, EventArgs e)
        {

        }
    }
}