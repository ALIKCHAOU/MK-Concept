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
    public partial class FrmListedesPrixFournisseurs : DevExpress.XtraEditors.XtraForm
    {

        private static FrmListedesPrixFournisseurs _FrmListedesPrixFournisseurs;
        public static FrmListedesPrixFournisseurs InstanceFrmListedesPrixFournisseurs
        {
            get
            {
                if (_FrmListedesPrixFournisseurs == null)
                    _FrmListedesPrixFournisseurs = new FrmListedesPrixFournisseurs();
                return _FrmListedesPrixFournisseurs;
            }
        }
        public FrmListedesPrixFournisseurs()
        {
            InitializeComponent();
        }

        private void FrmListedesPrixFournisseurs_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListedesPrixFournisseurs = null;
        }
    }
}