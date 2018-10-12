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
    /// Summary description for ltrECUWAcknowledgement.
    /// </summary>
    public partial class ltrECUWAcknowledgement : Telerik.Reporting.Report
    {
        List<clsECLetter> objLetter = null;
        int num = 0;
        public ltrECUWAcknowledgement()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrECUWAcknowledgement(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //


            InitializeComponent();
            table1.DataSource = objLetter;

            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            
        }

        private void table2_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            //strUW = "";

            //DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(strUW);
            tb.DataSource = objLetter[num++].lstLetterBodyContents;
        }

        
    }
}