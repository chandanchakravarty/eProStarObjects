namespace eProStarReports.IHReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    //using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
    using BusinessObjectLayer.BrokingModule.Reports;

    /// <summary>
    /// Summary description for HBCDailyReport.
    /// </summary>
   internal partial class HBCDailyReport : Telerik.Reporting.Report
    {
        public HBCDailyReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public HBCDailyReport(DataSet objList)
        {
            InitializeComponent();
            table1.DataSource = objList;
        }
    }
}