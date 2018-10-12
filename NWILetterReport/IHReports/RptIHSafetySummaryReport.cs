namespace NWILetterReport.IHReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
    using BusinessObjectLayer.BrokingModule.Reports;

    /// <summary>
    /// Summary description for RptIHSafetySummaryReport.
    /// </summary>
    public partial class RptIHSafetySummaryReport : Telerik.Reporting.Report
    {

        public RptIHSafetySummaryReport(DataSet dsObj)
        {
            InitializeComponent();
            table1.DataSource = dsObj;
        }
    }
}