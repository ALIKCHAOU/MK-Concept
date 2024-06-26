﻿using System;
using System.ComponentModel;

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;



namespace Gestion_de_Stock.Model.EditRapport
{

    public class NewCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
    {
        private readonly XRDesignMdiController _xrDesigner;
        private XtraReport _report;

        public NewCommandHandler(XRDesignMdiController xrDesigner, CompositionContainer container)
        {
            if (xrDesigner == null)
                throw new ArgumentNullException("xrDesigner");

            if (container == null)
                throw new ArgumentNullException("container");

            _xrDesigner = xrDesigner;
            container.ComposeParts(this);
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.NewReport || command == ReportCommand.NewReportWizard);
            return !useNextHandler;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {

            _report = new XtraReport
            {
            };

            _report.DesignerLoaded += DesignerLoaded;
            _xrDesigner.OpenReport(_report);
        }

        private void DesignerLoaded(object sender, DesignerLoadedEventArgs e)
        {
            var report = sender as XtraReport;
            if (report == null) return;
            if (report.Container == null) return;

            foreach (var comp in report.Container.Components.OfType<SqlDataAdapter>())
            {
                report.Container.Remove(comp);
            }

            var reportview = _report as XtraReport;

            var pd = TypeDescriptor.GetProperties(report.DataSource)["Name"];
            pd.SetValue(report.DataSource, ((DataSet)report.DataSource).DataSetName);

            foreach (var comp in report.Container.Components.OfType<SqlDataAdapter>())
            {
                pd = TypeDescriptor.GetProperties(comp)["Name"];

                pd.SetValue(comp, "DataAdapter");
            }
        }
    }

}