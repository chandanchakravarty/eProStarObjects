namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    //using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using BusinessObjectLayer.BrokingModule.Reports;
    using BusinessAccessLayer.BrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for InPatientSubReport.
    /// </summary>
   internal partial class InPatientSubReport : Telerik.Reporting.Report
    {
        #region Declaration of Objects
        BusinessAccessLayer.BrokingModule.Reports.clsEBLetterManager objEBInPatient = new clsEBLetterManager();
        DataSet ds = new DataSet();
        #endregion
        public InPatientSubReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public InPatientSubReport(string strUWcode)
        {
            //
            // Required for telerik Reporting designer support
            //
            
            InitializeComponent();
            //string UWCode = ReportParams.Params[0].ToString().Trim();
            //tblClaims.DataSource = objClaims;
            //DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(strUWcode);
            //tblClaims.DataSource = dataTable1.Tables[0].AsDataView();
            //txtCertificateNo.Value = "1";//dataTable1.Tables[0].Columns["CertificateNo"].ToString();
           // txtClaimNo.Value = dataTable1.Tables[0].Columns["ClaimNo"].ToString();
           
            
            
            
        }

        private void InPatientSubReport_ItemDataBinding(object sender, EventArgs e)
        {
            //var report1 = (sender as Telerik.Reporting.Processing.Report);
            //var parameter1Value = report1.Parameters["UWCode"].Value;//strUWcode;
            //var dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(parameter1Value.ToString());
            //report1.DataSource = dataTable1;
        }

        private void InPatientSubReport_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report1 = (sender as Telerik.Reporting.Processing.Report);
            DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(report1.Parameters["UWCode"].Value.ToString());
            tblClaims.DataSource = dataTable1;
        }
    }
}