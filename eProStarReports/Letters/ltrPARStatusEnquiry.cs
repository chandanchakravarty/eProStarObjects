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
    /// Summary description for ltrPARStatusEnquiry.
    /// </summary>
   internal partial class ltrPARStatusEnquiry : Telerik.Reporting.Report
    {
           List<clsECLetter> objLetter = null;
        int num = 0;
        public ltrPARStatusEnquiry()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrPARStatusEnquiry(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //


            InitializeComponent();
            table1.DataSource = objLetter;

            //txtpagecount.Value = txtpagecountHeader.Value;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                if (!string.IsNullOrEmpty(dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString()))
                {
                    txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                }
                else
                {
                    txtCountry.Value = " ";
                }
                if (!string.IsNullOrEmpty(dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString()))
                {
                    txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                }
                else
                {
                    txtAddress.Value = " ";
                }
                if (!string.IsNullOrEmpty(dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString()))
                {
                    txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
                }
                else
                {
                    txtAddress.Value = " ";
                }
            }
            txtFrom.Value = " ";
            txtpagecount.Value = " ";
            txtRefNo.Value = " ";
            txtSubject.Value = " ";
            textBox1.Value = " ";
           

        }

    }
}