﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Gestion_de_Stock.Repport
{
    public partial class RapportDepenseSalarier : DevExpress.XtraReports.UI.XtraReport
    {
        public RapportDepenseSalarier()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath0 = executingFolder + "\\Image\\Logo.png";
            xrPictureBox1.ImageUrl = dbPath0;
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath0 = executingFolder + "\\Image\\Logo.png";
            xrPictureBox1.ImageUrl = dbPath0;
        }
    }
}
