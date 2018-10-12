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
    /// Summary description for ClientListingReport.
    /// </summary>
    public partial class ClientListingReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        DataSet dsReportSummaryDetails = null;

        public ClientListingReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ClientListingReport(DataSet DsComp, DataSet param, DataSet DsReport)
        {
            InitializeComponent();

           

        }

        public ClientListingReport(string Insurercode, string cmbpaid, string fromdate, string todate, string ClientType, string ClientSource, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            InitializeComponent();

            decimal totalCommission = 0;
            decimal totalCommissionGST = 0;

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = Get_ClientListingReport(Insurercode, cmbpaid, fromdate, todate, ClientType, ClientSource);

            dsParamD = new DataSet();
          //  dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer(DParam1, DParam2, DParam3, DParam4, DParam5);

            textBox76.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
            textBox2.Value = DParam1;
            textBox4.Value = DParam2;
            textBox9.Value = DParam3;
          //  pictureBox1.Value = ReportsUtility.ClientLogo;
            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer(DParam1, DParam2, DParam3, DParam4, DParam5);


            if (dsReportDetails.Tables.Count > 0 && dsReportDetails.Tables[0].Rows.Count > 0)
            {
                table3.Visible = true;
                table3.DataSource = dsReportDetails;
            }
            else
            {
                table3.Visible = false;
            }



         
            //if (dsReportDetails.Tables[0].Rows.Count == 0)
            //{
            //    textBox239.Value = "";
            //    textBox240.Value = "";
            //    textBox241.Value = "";
            //    textBox242.Value = "";
            //    textBox243.Value = "";
            //}




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
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters'" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        }

        ///  AC_SQLREPORT_OutstandingAgeingAnalysis

        private DataSet Get_ClientListingReport(string Insurercode, string cmbpaid, string fromdate, string todate, string ClientType, string ClientSource)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ClientReceiptListing'" + Insurercode + "','" + cmbpaid + "','" + fromdate + "','" + todate + "', '" + ClientType + "', '" + ClientSource + "'");
        }

        #endregion

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
    }
}