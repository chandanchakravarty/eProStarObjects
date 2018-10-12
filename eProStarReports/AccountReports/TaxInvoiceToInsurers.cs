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
    /// Summary description for TaxInvoiceToUnderwriter.
    /// </summary>
    public partial class TaxInvoiceToInsurers : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        DataSet dsReportSummaryDetails = null;
        DataSet dsGetInsurer = null;

        public TaxInvoiceToInsurers()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public TaxInvoiceToInsurers(DataSet DsComp, DataSet param, DataSet DsReport)
        {
            InitializeComponent();
          
        }

        public TaxInvoiceToInsurers(string Param1, string Param2, string Param3, string Param4, string DParam1, string Param5, string Param6, string Param7,string DParam2, string DParam3,string DParam4,string DParam5)
        {
            InitializeComponent();

          
            dsReportDetails = new DataSet();
            dsReportDetails = Get_InsurerTaxInVoice(Param1, Param2, Param3, Param4, Param5,Param6,Param7);

          
            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();
            textBox7.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["CompName"]);
            textBox8.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["Add1"]) + " " + Convert.ToString(dsCompDetails.Tables[0].Rows[0]["Add2"]);
            textBox9.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["Add3"]);
            textBox10.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["Add4"]);
            textBox11.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["Add7"]);
            textBox12.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["GSTCode"]);
            //textBox13.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["TaxRefNo"]);

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForStandardRatedListingToInsurer(DParam1, DParam2, DParam3, "", "");
            pictureBox1.Value = ReportsUtility.ClientLogo;
            textBox76.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["CompName"]);
            textBox2.Value = DParam1;
            //textBox3.Value = DParam2;
            //textBox4.Value = DParam3;

            //dsGetInsurer = new DataSet();
            //dsGetInsurer = GetInsurer();

            //textBox3.Value = Convert.ToString(dsGetInsurer.Tables[0].Rows[0]["in_name"]);
            //textBox4.Value = Convert.ToString(dsGetInsurer.Tables[0].Rows[0]["InsAddress1"]);
            //textBox5.Value = Convert.ToString(dsGetInsurer.Tables[0].Rows[0]["InsAddress2"]);
            //textBox6.Value = Convert.ToString(dsGetInsurer.Tables[0].Rows[0]["In_Country"]) + " " + Convert.ToString(dsGetInsurer.Tables[0].Rows[0]["In_PinCode"]);

            if (dsReportDetails.Tables.Count > 0 && dsReportDetails.Tables[0].Rows.Count > 0)
            {
                table1.Visible = true;
                table1.DataSource = dsReportDetails;                
            }
            else
            {
                table1.Visible = false;
                textBox3.Value = "";
                textBox4.Value = "";
                textBox5.Value = "";
                textBox6.Value = "";
                textBox7.Value = "";
                textBox8.Value = "";
                textBox9.Value = "";
                textBox10.Value = "";
                textBox11.Value = "";
                textBox12.Value = "";
            }

        }

        private DataSet Get_InsurerTaxInVoice(string Param1, string Param2, string Param3, string Param4, string Param5,string Param6,string Param7)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetInsurerTaxInvoice  '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param4 + "','" + Param5 + "','" + Param6 + "', '" + Param7 + "'");
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet GetInsurer()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetInsurer");
        }

        private DataSet Get_OtherGenericSearchDataForStandardRatedListingToInsurer(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
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
    }
}