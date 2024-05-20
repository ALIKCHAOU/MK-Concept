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
using System.Globalization;
using System.Threading;

namespace Gestion_de_Stock
{
    public partial class FrmListedesPrixFournisseurs : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
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
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }

        private void FrmListedesPrixFournisseurs_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmListedesPrixFournisseurs = null;
        }
    }
}