namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for rptClaimReportCover.
    /// </summary>
    public partial class rptClaimReportCover : Telerik.Reporting.Report
    {
        public rptClaimReportCover()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public rptClaimReportCover(List<string> lsCover)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            txtClientName.Value = lsCover[0].ToString();
            textBox2.Value = lsCover[1].ToString();
            textBox3.Value = "Prepared by:\nNova Insurance Consultants Limited\n" + DateTime.Now.ToString("dd MMM yyyy");
            txtCountry.Value = lsCover[2].ToString();
            txtAddress.Value = lsCover[3].ToString();
            txtTel.Value = lsCover[4].ToString();
            txtFax.Value = lsCover[5].ToString();
            txtMail.Value = lsCover[6].ToString();
            txtWebsite.Value = lsCover[7].ToString();
        }
    }
}