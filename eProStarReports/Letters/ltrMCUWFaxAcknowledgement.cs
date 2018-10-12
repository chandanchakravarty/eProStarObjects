namespace eProStarReports.Letters
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
    using Telerik.Reporting.Processing;
    /// <summary>
    /// Summary description for ltrMCUWFaxAcknowledgement.
    /// </summary>
   internal partial class ltrMCUWFaxAcknowledgement : Telerik.Reporting.Report
    {
        List<clsECLetter> objLetter = null;
        int num = 0;
        public ltrMCUWFaxAcknowledgement()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///  This constructor has been overloaded for the Telerik Report Control to be mapped with the Report Template and the Data from the Database
        /// </summary>
        /// <param name="objLettera"></param>
        /// <param name="dsFooterCountry"></param>
        public ltrMCUWFaxAcknowledgement(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;

            // this object required for the Telerik Report desiginging support
            InitializeComponent();
            table1.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["compContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            txtFrom.Value = "";
            txtpagecount.Value = "";
            txtRefNo.Value = "";
            txtSubject.Value = "";
            textBox1.Value = "";


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table3_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            tb.DataSource = objLetter[num++].lstLetterBodyContents;
        }
    }
}