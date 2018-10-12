namespace eProStarReports.Letters
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

    /// <summary>
    /// Summary description for ltrInsurerInpatient.
    /// </summary>
   internal partial class ltrInsurerInpatient : Telerik.Reporting.Report
    {
        List<clsEBLetter> objLetter = null;
        public string strUW = "";
        BusinessAccessLayer.BrokingModule.Reports.clsEBLetterManager objEBInPatient = new clsEBLetterManager();
        DataSet ds = new DataSet();
        public string strDateFormat = ""; 
        public ltrInsurerInpatient()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //subReport1.ReportSource = new InPatientSubReport();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        int num = 0;
        public ltrInsurerInpatient(List<clsEBLetter> objLettera, DataSet dsFooterCountry, List<EBInsurerInpatientClaims> objClaims, DataSet dsLetterInfo, string DateFormat)
        {

            objLetter = objLettera;
            strDateFormat = DateFormat;
            InitializeComponent();
            table1.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }

        }
        //int i = 0;
        private void table2_NeedDataSource(object sender, EventArgs e)
        {
            //strUW = objLetter[num++].UWCode;
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
                  
            tb.DataSource = objLetter[num++].lstInpatientClaims;
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {

        }
    }
}