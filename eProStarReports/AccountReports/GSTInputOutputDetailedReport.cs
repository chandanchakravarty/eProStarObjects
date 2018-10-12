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

    /// <summary>
    /// Summary description for GSTInputOutputDetailedReport.
    /// </summary>
    public partial class GSTInputOutputDetailedReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];

        DataSet DsCompDtl = null;
        DataSet DsGSTDeatail = null;
        DataSet DsreportDetails = null;
        Double GSTTotalAmt = 0.0;
        Double GSTTotalBaseAmt = 0.0, TotalOutBasedAmt = 0.0, TotalInBaseAmt = 0.0;
        public GSTInputOutputDetailedReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public GSTInputOutputDetailedReport(string Param1, string Param2, string Param3, string DParam1, string par1, string Param5, string Param6, string Param7)
        {
            InitializeComponent();
            DsCompDtl = GetCompanyDetails();

            textBox1.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
            textBox2.Value = DParam1;

            DsGSTDeatail = GetGSTBasicDetails(Param1, Param2, Param3, Param5, Param6, Param7);

            if (DsGSTDeatail.Tables.Count > 0 && DsGSTDeatail.Tables[0].Rows.Count > 0)
            {
                table1.Visible = true;
                table1.DataSource = DsGSTDeatail.Tables[0];

                decimal grandTaxAmtIn = 0;
                decimal grandTaxAmtOut = 0; 
                decimal grandBaseAmtIn = 0;
                decimal grandBaseAmtOut = 0;

                grandTaxAmtIn = GetGrandTotal(DsGSTDeatail, out grandTaxAmtOut, out grandBaseAmtIn, out grandBaseAmtOut);
                textBox49.Value = convertIntoNumeric(grandBaseAmtIn - grandTaxAmtIn);
                textBox54.Value = convertIntoNumeric(grandBaseAmtOut - grandTaxAmtOut);
            }
            else
            {
                table1.Visible = false;
            }
        }
        private decimal GetGrandTotal(DataSet ds, out decimal grandTaxAmtOut, out decimal grandBaseAmtIn, out decimal grandBaseAmtOut)
        {
            decimal grandTaxAmtIn = 0;
            grandTaxAmtOut = 0;
            grandBaseAmtIn = 0;
            grandBaseAmtOut = 0;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToString(dr["GSTType"]) == "IN")
                    {
                        grandTaxAmtIn = grandTaxAmtIn + Convert.ToDecimal(dr["GSTAmount"]);
                        grandTaxAmtOut = grandTaxAmtOut + Convert.ToDecimal(dr["GSTBaseAmount"]);
                    }
                    if (Convert.ToString(dr["GSTType"]) == "OUT")
                    {
                        grandBaseAmtIn = grandBaseAmtIn + Convert.ToDecimal(dr["GSTAmount"]);
                        grandBaseAmtOut = grandBaseAmtOut + Convert.ToDecimal(dr["GSTBaseAmount"]);
                    }
                }
            }
            return grandTaxAmtIn;
        }
        private DataSet GetGSTReportSummary(string Param1, string Param2, string Dparam1, string Param5, string Param6, string Param7)
        {

            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetDataForGSTInOutReportSummary  '" + Param1 + "','" + Param2 + "', '" + Dparam1 + "','" + Param5 + "','" + Param6 + "','" + Param7 + "'");
        }

        private DataSet GetGSTBasicDetails(string Param1, string Param2, string Dparam1, string Param5, string Param6, string Param7)
        {

            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetDataForGSTInOutReport  '" + Param1 + "','" + Param2 + "', '" + Dparam1 + "','" + Param5 + "','" + Param6 + "','" + Param7 + "'");
        }

        private DataSet GetCompanyDetails()
        {

            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");


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