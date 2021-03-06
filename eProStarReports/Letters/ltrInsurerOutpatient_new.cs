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
   internal partial class ltrInsurerOutpatient_new : Telerik.Reporting.Report
    {
        List<clsEBLetter> objLetter = null;
        public string strUW = "";
        public string strDateFormat = "";
        BusinessAccessLayer.BrokingModule.Reports.clsEBLetterManager objEBInPatient = new clsEBLetterManager();
        DataSet ds = new DataSet();
        public ltrInsurerOutpatient_new()
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
        public ltrInsurerOutpatient_new(List<clsEBLetter> objLettera, DataSet dsFooterCountry, List<EBInsurerInpatientClaims> objClaims, DataSet dsLetterInfo,string DateFormat)
        {

            objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //

            strDateFormat = DateFormat;
            InitializeComponent();
            table1.DataSource = objLetter;
            //Parameter objPara = new Parameter("UWCode", dsLetterInfo.Tables[0].Rows[0]["UwriterCode"].ToString());
            //ReportParameter objRpt = new ReportParameter("UWCode", ReportParameterType.String, dsLetterInfo.Tables[0].Rows[0]["UwriterCode"].ToString());
            //subReport1.Parameters.Add(objPara);
           
           // InPatientSubReport obj = new InPatientSubReport(dsLetterInfo.Tables[0].Rows[0]["UwriterCode"].ToString());
            // ReportParameter objPara = new ReportParameter("UWCode",ReportParameterType.String,"=Fields.UWCode");
          // obj.ReportParameters.Add(objPara);
            if (dsFooterCountry.Tables[0].Rows.Count > 0)
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
            //strUW = "";

            //DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(strUW);
            tb.DataSource = objLetter[num++].lstInpatientClaims;
            //tb.DataSource = dataTable1;
            //report1.DataSource = 
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {

        }
    }
}