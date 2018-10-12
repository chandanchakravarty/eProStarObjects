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
    /// Summary description for RptIHSafetySummaryCanVAT.
    /// </summary>
   internal partial class RptIHSafetySummaryCanVAT : Telerik.Reporting.Report
    {
        public RptIHSafetySummaryCanVAT (DataSet dsObj)
        {
            InitializeComponent();
            table1.DataSource = dsObj;
        }
    }
}