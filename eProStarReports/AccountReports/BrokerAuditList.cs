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
    /// Summary description for BrokerAuditList.
    /// </summary>
    public partial class BrokerAuditList : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;

        public BrokerAuditList()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BrokerAuditList(string fromDate, string toDate, string currency, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            InitializeComponent();

            txtReportFromTo.Value = "For the Period from " + fromDate + "  to " + toDate + " ";
            
            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            txtComapnyName.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["CompName"]);
            txtCurrency.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["BaseCurr"]);

            dsReportDetails = GetGenericSearchDataForBrokerAuditList(fromDate, toDate, currency);
            if (dsReportDetails.Tables.Count > 0 && dsReportDetails.Tables[0].Rows.Count > 0)
            {
                table1.Visible = true;
                table1.DataSource = dsReportDetails;
            }
            else
            {
                table1.Visible = false;
            }

            //dsParamD = new DataSet();
            //dsParamD = Get_OtherGenericSearchDataForBrokerAuditList(DParam1, DParam2, DParam3, DParam4, DParam5);
            //CalculateTotalBrokerAuditList(dsReportDetails.Tables[0]);
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetGenericSearchDataForBrokerAuditList(string fromDate, string toDate, string currency)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_RepBrokerage  '" + fromDate + "','" + toDate + "', '" + currency + "' ");
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

        //private DataSet Get_OtherGenericSearchDataForBrokerAuditList(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        //{
        //    dataAccess = new DatabaseInteraction(connectionstring);
        //    return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        //}

        //private void CalculateTotalBrokerAuditList(DataTable dtDetails)
        //{
        //    if (dtDetails.Rows.Count > 0)
        //    {
        //        decimal
        //        grosspremiumlc = 0,
        //        agentcomml = 0,
        //        discountlc = 0,
        //        StampDutyWGst = 0,
        //        StampDutyWOGst = 0,
        //        ServiceFeeOWTGST = 0,
        //        gstamtlc = 0,
        //        netpremiumlc = 0,
        //        finalpremiumli = 0,
        //        CommGst = 0,
        //        firmcommission = 0;

        //        foreach (DataRow row in dtDetails.Rows)
        //        {
        //            grosspremiumlc = grosspremiumlc + Convert.ToDecimal(Convert.ToString(row["grosspremiumlc"]).Replace(",", ""));
        //            agentcomml = agentcomml + Convert.ToDecimal(Convert.ToString(row["agentcomml"]).Replace(",", ""));
        //            discountlc = discountlc + Convert.ToDecimal(Convert.ToString(row["discountlc"]).Replace(",", ""));
        //            StampDutyWGst = StampDutyWGst + Convert.ToDecimal(Convert.ToString(row["StampDutyWGst"]).Replace(",", ""));
        //            StampDutyWOGst = StampDutyWOGst + Convert.ToDecimal(Convert.ToString(row["StampDutyWOGst"]).Replace(",", ""));
        //            ServiceFeeOWTGST = ServiceFeeOWTGST + Convert.ToDecimal(Convert.ToString(row["ServiceFeeOWTGST"]).Replace(",", ""));
        //            gstamtlc = gstamtlc + Convert.ToDecimal(Convert.ToString(row["gstamtlc"]).Replace(",", ""));
        //            netpremiumlc = netpremiumlc + Convert.ToDecimal(Convert.ToString(row["netpremiumlc"]).Replace(",", ""));
        //            finalpremiumli = finalpremiumli + Convert.ToDecimal(Convert.ToString(row["finalpremiumli"]).Replace(",", ""));
        //            CommGst = CommGst + Convert.ToDecimal(Convert.ToString(row["CommGst"]).Replace(",", ""));
        //            firmcommission = firmcommission + Convert.ToDecimal(Convert.ToString(row["firmcommission"]).Replace(",", ""));
        //        }

        //        textBox39.Value = String.Format("{0:#,###0.00}", grosspremiumlc);
        //        textBox40.Value = String.Format("{0:#,###0.00}", agentcomml);
        //        textBox41.Value = String.Format("{0:#,###0.00}", discountlc);
        //        textBox42.Value = String.Format("{0:#,###0.00}", StampDutyWGst);
        //        textBox43.Value = String.Format("{0:#,###0.00}", StampDutyWOGst);
        //        textBox44.Value = String.Format("{0:#,###0.00}", ServiceFeeOWTGST);
        //        textBox45.Value = String.Format("{0:#,###0.00}", StampDutyWOGst);
        //        textBox46.Value = String.Format("{0:#,###0.00}", gstamtlc);
        //        textBox47.Value = String.Format("{0:#,###0.00}", netpremiumlc);
        //        textBox48.Value = String.Format("{0:#,###0.00}", finalpremiumli);
        //        textBox49.Value = String.Format("{0:#,###0.00}", CommGst);
        //        textBox50.Value = String.Format("{0:#,###0.00}", firmcommission);
        //    }
        //}
    }
}