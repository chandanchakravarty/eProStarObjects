namespace eProStarReports.IHReports
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
    /// Summary description for RptIndividualSummaryReport.
    /// </summary>
   internal partial class RptIndividualSummaryReport : Telerik.Reporting.Report
    {
        public RptIndividualSummaryReport()
        {

            InitializeComponent();

        }
        //public RptIndividualSummaryReport()
        //{

        //    InitializeComponent();

        //}
        public RptIndividualSummaryReport(DataSet objList)
        {
            InitializeComponent();
            table1.DataSource = objList;
        }
    }
}