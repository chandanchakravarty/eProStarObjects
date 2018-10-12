namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    //using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using BusinessObjectLayer.BrokingModule.Reports;
    //using BusinessAccessLayer.BrokingModule.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for rptClaimReport.
    /// </summary>
   internal partial class rptClaimReport : Telerik.Reporting.Report
    {
        public rptClaimReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public rptClaimReport(List<clsClaimReport> ClaimReport, List<string> strFooter)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            table1.DataSource = ClaimReport;

            txtCountry.Value = strFooter[2].ToString();
            txtAddress.Value = strFooter[3].ToString();
            txtTel.Value = strFooter[4].ToString();
            txtFax.Value = strFooter[5].ToString();
            txtMail.Value = strFooter[6].ToString();
            txtWebsite.Value = strFooter[7].ToString();
        }
    }
}