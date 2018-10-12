namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using System.Data;
    using BusinessObjectLayer.BrokingModule.Reports;
    using BusinessAccessLayer.BrokingModule.Reports;
    /// <summary>
    /// Summary description for ltrECChineseEnglishFormEnquiry.
    /// </summary>
    public partial class ltrECChineseEnglishFormsEnquiry : Telerik.Reporting.Report
    {
        List<clsECLetter> objLetter = new List<clsECLetter>();
        int num = 0;
        public ltrECChineseEnglishFormsEnquiry()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            this.subReport1.ReportSource = new ltrECChineseFormEnquiry();
            this.subReport2.ReportSource = new ltrECEnglishFormEnquiry();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrECChineseEnglishFormsEnquiry(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;
            Telerik.Reporting.Report ReportToDisplay = null;
            //
            // Required for telerik Reporting designer support
            //

            ltrECEnglishFormEnquiry recnewEnglish = new ltrECEnglishFormEnquiry(objLettera, dsFooterCountry);
            ltrECChineseFormEnquiry rechineseReport = new ltrECChineseFormEnquiry(objLettera, dsFooterCountry);
            InitializeComponent();
            this.subReport2.ReportSource = recnewEnglish;
            this.subReport1.ReportSource = rechineseReport;
            //table1.DataSource = objLetter;
            //ReportToDisplay = new ltrECEnglishFormEnquiry(objLettera, dsFooterCountry);
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
        }

        public void table3_NeedDataSource(object sender,EventArgs e)
        {
            //Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            //tb.DataSource = objLetter[num++];
        }
    }
}