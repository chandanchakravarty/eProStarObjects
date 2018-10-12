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
    using Telerik.Reporting.Processing;

    /// <summary>
    /// Summary description for ltrMCClientFaxAcknowledgement.
    /// </summary>
    public partial class ltrMCClientFaxAcknowledgement : Telerik.Reporting.Report
    {


        List<clsECLetter> objLetter = null;
        int num = 0;
        public ltrMCClientFaxAcknowledgement()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }

        public ltrMCClientFaxAcknowledgement(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //


            InitializeComponent();
            table1.DataSource = objLetter;

            //txtpagecount.Value = txtpagecountHeader.Value;
            if (dsFooterCountry.Tables[0].Rows.Count > 0)
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            txtFrom.Value = " ";
            txtpagecount.Value = " ";
            txtRefNo.Value = " ";
            txtSubject.Value = " ";
            textBox1.Value = " ";

        }



        private void table3_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            tb.DataSource = objLetter[num++].lstLetterBodyContents;
        }


    }
}