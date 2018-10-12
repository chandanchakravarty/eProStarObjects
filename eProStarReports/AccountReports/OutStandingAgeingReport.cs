namespace eProStarReports.AccountReports
{
    using DataAccessLayer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for OutStandingAgeingReport.
    /// </summary>
    public partial class OutStandingAgeingReport : Telerik.Reporting.Report
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
        public OutStandingAgeingReport()
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

        public OutStandingAgeingReport(string Accounttype, string AccountCode, string month, string date, string CurrencyCode, string Accountservicer, string clientsource, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            InitializeComponent();

            decimal totalCommission = 0;
            decimal totalCommissionGST = 0;

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = Get_OutStandingAgeingReport(Accounttype, AccountCode, Convert.ToInt32(month), Convert.ToInt32(date), CurrencyCode, Accountservicer, clientsource);

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer(DParam1, DParam2, DParam3, DParam4, DParam5);

            textBox1.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
            txtfromdate1.Value = DParam1;
            pictureBox1.Value = ReportsUtility.ClientLogo;
            txtAll.Value = DParam2;
            txtfromdate2.Value = DParam1;
            txtfromdate2.Visible = false;
            table1.DataSource = dsReportDetails.Tables[0];
            if (dsReportDetails.Tables[0].Rows.Count == 0)
            {
                textBox239.Value = "";
                textBox240.Value = "";
                textBox241.Value = "";
                textBox242.Value = "";
                textBox243.Value = "";
            }




            //txtdebitnoteno.Value = dsParamD.Tables[0].Rows[0]["DebitNoteNo"].ToString();
           // txtTranPeriod.Value = fromDate + " To " + toDate;
            //table1.DataSource = dsReportDetails.Tables[0];

            //totalCommission = CalculateTotalCommisssionAndCommissionGST(dsReportDetails.Tables[0], out totalCommissionGST);
            //textBox15.Value = String.Format("{0:#,###0.00}", totalCommission);
            //textBox16.Value = String.Format("{0:#,###0.00}", totalCommissionGST);
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

        private DataSet Get_OutStandingAgeingReport(string AccountType, string AccountCode, int Month, int Year, string CurrencyCode, string AccountServicer, string ClientSource)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_OutstandingAgeingAnalysis  '" + AccountType + "','" + AccountCode + "','" + Month + "','" + Year + "', '" + CurrencyCode + "', '" + AccountServicer + "','" + ClientSource + "'");
        }

        #endregion
    }
}