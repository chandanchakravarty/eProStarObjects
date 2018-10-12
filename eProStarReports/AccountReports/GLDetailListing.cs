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
    /// Summary description for GLDetailListing.
    /// </summary>
    public partial class GLDetailListing : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        //DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        public GLDetailListing()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public GLDetailListing(string CompanyId, string MonthStart, string MonthEnd, string YearStart, string YearEnd, string GLFrom, string GLTo, string Param1, string Param2, string Param3, string Param4, string Param5, string sReportName)
        {
            InitializeComponent();

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForGLDetailedListing(CompanyId, MonthStart, MonthEnd, YearStart, YearEnd, GLFrom, GLTo);
            //this.pictureBox1.Value = ReportsUtility.ClientLogo;
            textBox1.Value = sReportName.ToString();
            param2.Value = Param2.ToString();
            param1.Value = Param1.ToString();
            //txtTranPeriod.Value = fromDate + " To " + toDate;
            //table1.DataSource = dsReportDetails.Tables[0];
            table1.DataSource = dsParamD.Tables[0];
        }
       

        private DataSet Get_OtherGenericSearchDataForGLDetailedListing(string CompanyId, string MonthStart, string MonthEnd, string YearStart, string YearEnd, string GLFrom, string GLTo)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetDetailedGLListing  '" + CompanyId + "','" + MonthStart + "','" + MonthEnd + "','" + YearStart + "','" + YearEnd + "','" + GLFrom +"','" + GLTo + "'");
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