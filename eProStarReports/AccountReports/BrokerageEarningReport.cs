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
    /// Summary description for BrokerageEarningReport.
    /// </summary>
    public partial class BrokerageEarningReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;

        public BrokerageEarningReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BrokerageEarningReport(string fromDate, string toDate, string currency, string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            InitializeComponent();

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsReportDetails = new DataSet();
            dsReportDetails = GetGenericSearchDataForBrokerageEarningReport(fromDate, toDate, currency);

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForBrokerageEarningReport(DParam1, DParam2, DParam3, DParam4, DParam5);

            textBox1.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
            textBox6.Value = currency;
            
            table1.DataSource = dsReportDetails.Tables[0];
            CalculateTotalBrokerageEarning(dsReportDetails.Tables[0]);
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetGenericSearchDataForBrokerageEarningReport(string fromDate, string toDate, string currency)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_RepBrokerage  '" + fromDate + "','" + toDate + "','" + currency + "' ");
        }

        private DataSet Get_OtherGenericSearchDataForBrokerageEarningReport(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
        }

        private void CalculateTotalBrokerageEarning(DataTable dtDetails)
        {
            decimal
            amtPaid = 0,
            grossPrem = 0,
            disct = 0,
            otherCharges = 0,
            fullCommWOGST = 0,
            ownComm = 0,
            otherComm = 0;

            if (dtDetails.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetails.Rows)
                {
                    amtPaid = amtPaid + Convert.ToDecimal(Convert.ToString(row["amount"]).Replace(",", ""));
                    grossPrem = grossPrem + Convert.ToDecimal(Convert.ToString(row["grosspremiumlc"]).Replace(",", ""));
                    disct = disct + Convert.ToDecimal(Convert.ToString(row["discountlc"]).Replace(",", ""));
                    otherCharges = otherCharges + Convert.ToDecimal(Convert.ToString(row["StampDutyL"]).Replace(",", "")) + Convert.ToDecimal(Convert.ToString(row["ServiceFeeO"]).Replace(",", ""));
                    fullCommWOGST = fullCommWOGST + Convert.ToDecimal(Convert.ToString(row["finalpremiumli"]).Replace(",", ""));
                    ownComm = ownComm + Convert.ToDecimal(Convert.ToString(row["firmcommission"]).Replace(",", ""));
                    otherComm = otherComm + Convert.ToDecimal(Convert.ToString(row["agentcomml"]).Replace(",", ""));
                }
                textBox37.Value = String.Format("{0:#,###0.00}", amtPaid);
                textBox36.Value = String.Format("{0:#,###0.00}", grossPrem);
                textBox35.Value = String.Format("{0:#,###0.00}", disct);
                textBox42.Value = String.Format("{0:#,###0.00}", otherCharges);
                textBox43.Value = String.Format("{0:#,###0.00}", fullCommWOGST);
                textBox44.Value = String.Format("{0:#,###0.00}", ownComm);
                textBox41.Value = String.Format("{0:#,###0.00}", otherComm);
            }
        }
    }
}