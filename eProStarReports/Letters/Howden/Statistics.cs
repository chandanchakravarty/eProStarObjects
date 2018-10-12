namespace eProStarReports.Letters.Howden
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using DataAccessLayer;

    /// <summary>
    /// Summary description for Statistics.
    /// </summary>
    public partial class Statistics : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        public Statistics()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public Statistics(string financialYear)
        {
            InitializeComponent();

            DataSet _dsReportDetails = new DataSet();
            dataAccess = new DatabaseInteraction(_connectionstring);
            
            string _sqlQuery = "AC_GetStatisticsReport";
            _dsReportDetails = dataAccess.RunSQLWithDataSet(_sqlQuery);
            if (_dsReportDetails.Tables.Count > 1)
            {
                if (_dsReportDetails.Tables[0].Rows.Count > 0) // condition is using for bind company name.
                {
                    txtCtyCompName.Value = _dsReportDetails.Tables[0].Rows[0]["CompanyName"].ToString() + " FY" + financialYear;
                    txtClsCompName.Value = _dsReportDetails.Tables[0].Rows[0]["CompanyName"].ToString() + " FY" + financialYear;
                }

                if (_dsReportDetails.Tables[1].Rows.Count > 0) // condition is using for country table.
                {
                    dtCountry.Visible = true;
                    dtCountry.DataSource = _dsReportDetails.Tables[1];
                }

                if (_dsReportDetails.Tables[2].Rows.Count > 0) // condition is using for sub class table.
                {
                     dtSubClass.Visible = true;
                     dtSubClass.DataSource = _dsReportDetails.Tables[2];
                }
            }
            
        }
        public static string ConvertIntoNumeric(decimal number)
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