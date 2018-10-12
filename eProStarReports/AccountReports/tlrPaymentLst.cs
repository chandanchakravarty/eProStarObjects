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
    //using AcclaimAcc;
    
    
    /// <summary>
    /// Summary description for tlrPaymentLst.
    /// </summary>
   internal partial class tlrPaymentLst : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsReportDetails = null;
        DataSet dsReportSummaryDetails = null;

        public tlrPaymentLst()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
         
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrPaymentLst(string serachString, string Year, string TranFrom, string TranTo, string isposted, string AccMonthFrom, string AccMonthTo, string RecordType, string Param1, string Param2, string Param3, string Param4)
        {
            InitializeComponent();

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();
            
            dsReportDetails = new DataSet();
            dsReportDetails = Get_PaymentList(serachString, Year, TranFrom, TranTo, isposted, AccMonthFrom, AccMonthTo, RecordType);

            if (dsReportDetails.Tables.Count > 0 && dsReportDetails.Tables[0].Rows.Count > 0)
            {
                if (RecordType == "T")
                {
                    table1.DataSource = dsReportDetails;
                    table2.Visible = false;
                }
                else
                {
                    table1.Visible = false;
                    table2.DataSource = dsReportDetails;
                }
            }
            else
            {
                table1.Visible = false;
                table2.Visible = false;
            }

            dsReportSummaryDetails = new DataSet();
            dsReportSummaryDetails = Get_PaymentListSummary(serachString, Year, TranFrom, TranTo, isposted);
            if (dsReportSummaryDetails.Tables.Count > 0 && dsReportSummaryDetails.Tables[0].Rows.Count > 0)
            {
                table5.Visible = true;
                table5.DataSource = dsReportSummaryDetails;
            }
            else
            {
                table5.Visible = false;
            }
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet Get_PaymentList(string serachString, string Year, string TranFrom, string TranTo, string isposted, string AccMonthFrom, string AccMonthTo, string RecordType)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_PaymentListing  '" + serachString + "','" + Year + "','" + TranFrom + "','" + TranTo + "','" + isposted + "','" + AccMonthFrom + "','" + AccMonthTo + "','" + RecordType + "' ");
        }

        private DataSet Get_PaymentListSummary(string serachString, string Year, string TranFrom, string TranTo, string isposted)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_PaymentListingSummary  '" + serachString + "','" + Year + "','" + TranFrom + "','" + TranTo + "','" + isposted + "' ");
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
    }
}