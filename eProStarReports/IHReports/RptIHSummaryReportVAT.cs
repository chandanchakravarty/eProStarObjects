namespace eProStarReports.IHReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
using System.Data;

    /// <summary>
    /// Summary description for RptIHSummaryReportVAT.
    /// </summary>
   internal partial class RptIHSummaryReportVAT : Telerik.Reporting.Report
    {
        public RptIHSummaryReportVAT(DataSet dsObj)
        {
            InitializeComponent();
            table1.DataSource = dsObj;
          
        }
    }
}