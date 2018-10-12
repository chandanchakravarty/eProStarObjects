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
    /// Summary description for RptMonthlyAvivaReport.
    /// </summary>
   internal partial class RptMonthlyAvivaReport : Telerik.Reporting.Report
    {
        public RptMonthlyAvivaReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptMonthlyAvivaReport(DataSet objList)
        {
           InitializeComponent();

           table1.DataSource = objList;
           if (objList.Tables[0].Rows.Count > 0)
           {
               textBox48.Value = objList.Tables[0].Rows[0]["RptType"].ToString();
           }
        }
    }
}