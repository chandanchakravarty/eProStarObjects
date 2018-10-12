namespace eProStarReports.AccountReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataAccessLayer;
    using BusinessObjectLayer.BrokingModule.BrokingSystem;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
    /// <summary>
    /// Summary description for BatchPrintPettyCash.
    /// </summary>
    public partial class BatchPrintPettyCash : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];

        DataSet DsCompDtl = null;
        DataSet DsParamD = null;
        DataSet DsreportDetails = null;
        DataSet DsCurDispCode = null;
        double Debitamt = 0.0;

        public BatchPrintPettyCash()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BatchPrintPettyCash(string Param1, string Param2)
        {
            InitializeComponent();
            DsCompDtl = GetCompanyDetails();
            if (DsCompDtl.Tables[0].Rows.Count > 0)
            {
                textBox4.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
                textBox9.Value = DsCompDtl.Tables[0].Rows[0]["Add1"].ToString() + " " + DsCompDtl.Tables[0].Rows[0]["Add2"].ToString() + " " + DsCompDtl.Tables[0].Rows[0]["Add3"].ToString();
                textBox12.Value = DsCompDtl.Tables[0].Rows[0]["Add4"].ToString();
                textBox15.Value = DsCompDtl.Tables[0].Rows[0]["Add5"].ToString();
                textBox18.Value = DsCompDtl.Tables[0].Rows[0]["Add7"].ToString();
            }
            DsreportDetails = GetBatchPrintForPettyCash(Param1, Param2);
            if (DsreportDetails.Tables[0].Rows.Count > 0)
            {
                textBox26.Value = DsreportDetails.Tables[0].Rows[0]["ClientName"].ToString();
                textBox27.Value = DsreportDetails.Tables[0].Rows[0]["VoucherNo"].ToString();
                textBox22.Value = DsreportDetails.Tables[0].Rows[0]["VoucherDate"].ToString();
                textBox40.Value = DsreportDetails.Tables[0].Rows[0]["VoucherDescription"].ToString();
            }
            DsParamD = GetBatchGLDetails(Param1, Param2);
            if (DsParamD.Tables[0].Rows.Count > 0)
            {
                textBox33.Value = DsParamD.Tables[0].Rows[0]["GLCode"].ToString();
                textBox35.Value = DsParamD.Tables[0].Rows[0]["GLDesc"].ToString();
                textBox37.Value = DsParamD.Tables[0].Rows[0]["DebitAmount"].ToString();
                for (int i = 0; i < DsParamD.Tables[0].Rows.Count; i++)
                    Debitamt = Debitamt + Convert.ToDouble(DsParamD.Tables[0].Rows[0]["DebitAmount"]);
                textBox39.Value = Convert.ToString(Debitamt);
            }

            DsCurDispCode = GetBatchPrintForPettyCashDispCode();
            if (DsCurDispCode.Tables[0].Rows.Count > 0)
            {
                textBox6.Value = "Total " + DsCurDispCode.Tables[0].Rows[0]["CurDispCode"].ToString();
            }
        }

        private DataSet GetBatchPrintForPettyCash(string Param1, string Param2)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetVoucherMain  '" + Param1 + "','" + Param2 + "'");
        }

        private DataSet GetBatchGLDetails(string Param1, string Param2)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetVoucherGL  '" + Param1 + "','" + Param2 + "'");
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetBatchPrintForPettyCashDispCode()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("select dbo.fnGetDispCode()as CurDispCode");
        }
    }
}