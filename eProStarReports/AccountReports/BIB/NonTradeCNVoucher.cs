namespace eProStarReports.AccountReports.BIB
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using DataAccessLayer;

    /// <summary>
    /// Summary description for NonTradeDNVoucher.
    /// </summary>
    internal partial class NonTradeCNVoucher : Telerik.Reporting.Report
    {
        private string _connectionString = String.Empty;
        public NonTradeCNVoucher()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public NonTradeCNVoucher(string type,string refNo, string _taxType = "")//Redmine 32342
        {
            InitializeComponent();
            _connectionString = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
            DatabaseInteraction _dataAccess = new DatabaseInteraction(_connectionString);
            DataSet _ds = new DataSet();
            //DataTable _dt = null;
            _ds =_dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
            if (_ds!=null && _ds.Tables[0].Rows.Count>0)
            {
                clientLogo.Value = ReportsUtility.ClientLogo;
                pictureBox1.Value = ReportsUtility.OrinialStamp;
                txtClientCompanyName.Value = _ds.Tables[0].Rows[0]["CompName"].ToString().ToUpper();
                //clientLogo.Style.BackgroundImage = "../BIB/Logo/BIB.png";
                txtAccountFor.Value = "MISC CREDIT NOTE";
                txtPrintedDate.Value = DateTime.Now.ToString("dd MMM yyyy");
                lblmpNoticeP3.Value = "3.  All cheques should be crossed and made payable to " + _ds.Tables[0].Rows[0]["CompName"].ToString().ToUpper() + ".";    
            }
            

            _ds = _dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetVoucherMain  '" + type + "','" + refNo + "'");
            if (_ds!=null && _ds.Tables[0].Rows.Count>0)
            {
                txtInvoiceNo.Value = _ds.Tables[0].Rows[0]["DrCrNo"].ToString();
                txtInvoiceDate.Value = _ds.Tables[0].Rows[0]["DrCrDate"].ToString();
                txtAccountCode1.Value = _ds.Tables[0].Rows[0]["CusM_ID"].ToString();
                txtClientName.Value = _ds.Tables[0].Rows[0]["CusM_Name"].ToString();
                txtAddr1.Value = _ds.Tables[0].Rows[0]["CusM_Address1"].ToString();
                txtAddr2.Value = _ds.Tables[0].Rows[0]["CusM_Address2"].ToString();
                txtAddr3.Value = _ds.Tables[0].Rows[0]["CusM_Address3"].ToString();
                txtAddr4.Value = _ds.Tables[0].Rows[0]["CusM_Address4"].ToString();
                
                tblVoucher.DataSource = _ds.Tables[0];
                if (_taxType.ToUpper() == "SST")
                {
                    txtGST.Value = String.Empty;
                    txtGSTAmount.Value = String.Empty;
                }
                else
                {
                    txtGST.Value = _ds.Tables[1].Rows[0]["DebitGSTRate"].ToString();
                    txtGSTAmount.Value = _ds.Tables[1].Rows[0]["DebitGSTBalance"].ToString();
                }
                txtTotalAmountDue.Value = Convert.ToDecimal(_ds.Tables[1].Rows[0]["TotalAmount"].ToString()).ToString("n2");
            }
        }
    }
}