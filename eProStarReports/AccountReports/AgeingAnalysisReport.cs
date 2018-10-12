namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataAccessLayer;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class AgeingAnalysisReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        #region Convert method
        public static string convertIntoNumeric(decimal number)
        {
            string str;
            if (Convert.ToDecimal(number) < 0)
            {
                str = Convert.ToDecimal(-1 * number).ToString("#,##0.00");
                str = "(" + str + ")";
            }
            else
            {
                str = Convert.ToDecimal(number).ToString("#,##0.00");
            }

            return str;

        }
        #endregion

        public AgeingAnalysisReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public static string NewLine()
        {
            return Environment.NewLine;
        }

        public AgeingAnalysisReport(string Accounttype, string AccountCode, string month, string date, string CurrencyCode, string clientsource, string Option, string Type)
        {
            InitializeComponent();

            decimal totalCommission = 0;
            decimal totalCommissionGST = 0;

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = Get_OutStandingAgeingReport(Accounttype, AccountCode, Convert.ToInt32(month), Convert.ToInt32(date), CurrencyCode, clientsource, Option, Type);

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer("", "", "", "", "");

            textBox107.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
            pictureBox1.Value = ReportsUtility.ClientLogo;

            if (dsReportDetails.Tables.Count > 0 && dsReportDetails.Tables[0].Rows.Count > 0)
            {
                table1.Visible = true;
                table1.DataSource = dsReportDetails;
            }
            else
            {
                table1.Visible = false;
            }
            
        }


        #region Added method by neetu sinha

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        ////
        private DataSet Get_OtherGenericSearchDataForStandardRatedListingToInsurer(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        }

        ///  AC_SQLREPORT_OutstandingAgeingAnalysis

        private DataSet Get_OutStandingAgeingReport(string AccountType, string AccountCode, int Month, int Year, string CurrencyCode, string ClientSource, string Option, string Unit)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_AgeingAnalysisReport  '" + AccountType + "','" + AccountCode + "','" + Month + "','" + Year + "', '" + CurrencyCode + "','" + ClientSource + "','" + Option + "','" + Unit + "'");
        }

        #endregion
    }
}