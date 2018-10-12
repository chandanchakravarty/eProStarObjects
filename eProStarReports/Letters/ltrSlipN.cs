namespace eProStarReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using BusinessObjectLayer.BrokingModule.Reports;
    using System.Data;
    using BusinessAccessLayer.BrokingModule.Reports;
    using System.Web;

    /// <summary>
    /// Summary description for ltrSlipN.
    /// </summary>
   internal partial class ltrSlipN : Telerik.Reporting.Report
    {
        List<clsPrintSlipData> objLetter = null;
        int num = 0;
        public ltrSlipN(List<clsPrintSlipData> objLettera, DataSet dsFooterCountry)
        {
            //
            // Required for telerik Reporting designer support
            //
            objLetter = objLettera;
            InitializeComponent();
            this.DataSource = objLettera;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        private void subReport1_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport tb = (Telerik.Reporting.Processing.SubReport)sender;
            tb.InnerReport.DataSource = objLetter[num++].lstSlipFields;
        }
    }
}