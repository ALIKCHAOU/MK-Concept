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

namespace Gestion_de_Stock
{
    public partial class FrmListedesPrixSociete : DevExpress.XtraEditors.XtraForm
    {

        private static FrmListedesPrixSociete _FrmListedesPrixSociete;
        public static FrmListedesPrixSociete InstanceFrmListedesPrixSociete
        {
            get
            {
                if (_FrmListedesPrixSociete == null)
                    _FrmListedesPrixSociete = new FrmListedesPrixSociete();
                return _FrmListedesPrixSociete;
            }
        }
        public FrmListedesPrixSociete()
        {
            InitializeComponent();
        }

        private void FrmListedesPrixSociete_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListedesPrixSociete = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmListedesPrixSociete_Load(object sender, EventArgs e)
        {

        }
    }
}