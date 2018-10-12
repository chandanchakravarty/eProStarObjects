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
    /// Summary description for ReceiptListing.
    /// </summary>
    public partial class ReceiptListing : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        DataSet dsReportSummaryDetails = null;

        public ReceiptListing()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReceiptListing(string companyId, string month, string year, string tranFrom, string tranTo, string IsPosted, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5, string Param5, string Param6, string Param7)
        {
            InitializeComponent();

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = GetGenericSearchDataForReceiptListing(month, year, tranFrom, tranTo, IsPosted, Param5, Param6, Param7);


            //dsParamD = new DataSet();
            //dsParamD = Get_OtherGenericSearchDataForReceiptListing(DParam1, DParam2, DParam3, DParam4, DParam5);
            if (dsReportDetails.Tables[0].Rows.Count > 0)
            {
                if (Param7 == "A")
                {
                    table1.Visible = false;
                    table3.DataSource = dsReportDetails.Tables[0];
                }
                else
                {
                    //dsReportDetails.Tables[0].Columns.Remove("AccountDate");
                    //table1.Body.Columns.RemoveAt(4);
                    //// table1.ConditionalFormatting.RemoveAt(4);
                    table1.DataSource = dsReportDetails.Tables[0];
                    table3.Visible = false;

                }
            }
            else
            {
                table1.Visible = false;
                table3.Visible = false;
            }
            dsReportSummaryDetails = new DataSet();
            dsReportSummaryDetails = GetGenericSearchDataForReceiptSummaryListing(month, year, tranFrom, tranTo, IsPosted, Param5, Param6, Param7);
            if (dsReportSummaryDetails.Tables[0].Rows.Count > 0)
                table2.DataSource = dsReportSummaryDetails.Tables[0];
            else
            {
                table2.Visible = false;
                textBox33.Visible = false;
            }
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetGenericSearchDataForReceiptListing(string month, string year, string tranFrom, string tranTo, string IsPosted, string Param5, string Param6, string Param7)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReceiptListing  '" + month + "','" + year + "','" + tranFrom + "','" + tranTo + "','" + IsPosted + "','" + Param5 + "','" + Param6 + "','" + Param7 + "' ");
        }

        private DataSet Get_OtherGenericSearchDataForReceiptListing(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        }

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

        private DataSet GetGenericSearchDataForReceiptSummaryListing(string month, string year, string tranFrom, string tranTo, string IsPosted, string Param5, string Param6, string Param7)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReceiptListingSummary  '" + month + "','" + year + "','" + tranFrom + "','" + tranTo + "','" + IsPosted + "','" + Param5 + "','" + Param6 + "','" + Param7 + "' ");
        }
    }
}