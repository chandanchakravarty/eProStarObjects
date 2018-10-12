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
    /// Summary description for GLChartOfAccounts.
    /// </summary>
    public partial class GLChartOfAccounts : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        DataSet dsReportSummaryDetails = null;

        public GLChartOfAccounts()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public GLChartOfAccounts(DataSet DsComp, DataSet param, DataSet DsReport)
        {
            InitializeComponent();

           

        }

        public GLChartOfAccounts(string Param1, string Param2, string Param3, string Param4, string Param5, string Param6, string Param7, string Param8, string Param9, string Param10, string Param11, string Param12, string Param13)
        {
            InitializeComponent();

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            //pictureBox1.Value = ReportsUtility.ClientLogo;
            textBox76.Value = Convert.ToString(dsCompDetails.Tables[0].Rows[0]["CompName"]);
            //textBox2.Value = DParam1;
            //textBox3.Value = DParam2;
            //textBox4.Value = DParam3;

            dsReportDetails = new DataSet();
            dsReportDetails = Get_GLChartOfAccount(Param1, Param2, Param3, Param4, Param5,Param6,Param7,Param8,Param9,Param10,Param11,Param12,Param13);

            if(dsReportDetails.Tables.Count>0 && dsReportDetails.Tables[0].Rows.Count>0)
            {
                table1.Visible = true;
                table1.DataSource = dsReportDetails;
            }
            else
            {
                table1.Visible = false;
            }
        }

        private DataSet Get_GLChartOfAccount(string Param1, string Param2, string Param3, string Param4, string Param5, string Param6, string Param7, string Param8, string Param9, string Param10, string Param11, string Param12, string Param13)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_GetGLChartOfAccounts  '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param4 + "','" + Param5 + "' ,'" + Param6 + "','" + Param7 + "','" + Param8 + "','" + Param9 + "','" + Param10 + "','" + Param11 + "','" + Param12 + "','" + Param13 + "' ");
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