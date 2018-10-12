namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using DataAccessLayer;

    /// <summary>
    /// Summary description for StandardRatedListingToInsurer.
    /// </summary>
    internal partial class StandardRatedListingToInsurer : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;

        public StandardRatedListingToInsurer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public StandardRatedListingToInsurer(string insurerCode, string fromDate, string toDate, string type, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            InitializeComponent();

            decimal totalCommission = 0;
            decimal totalCommissionGST = 0;

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = GetGenericSearchDataForStandardRatedListingToInsurer(insurerCode, fromDate, toDate, type);

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer(DParam1, DParam2, DParam3, DParam4, DParam5);

            textBox1.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
            txtTranPeriod.Value = fromDate + " To " + toDate;
            table1.DataSource = dsReportDetails.Tables[0];

            totalCommission = CalculateTotalCommisssionAndCommissionGST(dsReportDetails.Tables[0], out totalCommissionGST);
            textBox15.Value = String.Format("{0:#,###0.00}", totalCommission);
            textBox16.Value = String.Format("{0:#,###0.00}", totalCommissionGST);
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetGenericSearchDataForStandardRatedListingToInsurer(string insurerCode, string fromDate, string toDate, string type)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_StandardRated  '" + insurerCode + "','" + fromDate + "','" + toDate + "','" + type + "' ");
        }

        private DataSet Get_OtherGenericSearchDataForStandardRatedListingToInsurer(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        }

        private decimal CalculateTotalCommisssionAndCommissionGST(DataTable dtDetails, out decimal totalCommissionGST)
        {
            decimal totalCommission = 0;
            totalCommissionGST = 0;

            if (dtDetails.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetails.Rows)
                {
                    totalCommission = totalCommission + Convert.ToDecimal(Convert.ToString(row["CommissionAmtLI"]).Replace(",", ""));
                    totalCommissionGST = totalCommissionGST + Convert.ToDecimal(Convert.ToString(row["gstCommAmtLI"]).Replace(",", ""));
                }
            }
            return totalCommission;
        }
    }
}