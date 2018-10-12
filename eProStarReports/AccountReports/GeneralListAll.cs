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
    /// Summary description for GeneralListAll.
    /// </summary>
    public partial class GeneralListAll : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
        DataSet dsCompDetails = null;
        DataSet dsParamD = null;
        DataSet dsReportDetails = null;
        public GeneralListAll()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public GeneralListAll(string CompanyId, string Month, string Year, string TranFrom, string TranTo, string Param1, string Param2, string Param3, string Param4, string Param5, string IsPosted, string ParamMFrom, string ParamMTo, string RecordType)
        {
            InitializeComponent();

            dsCompDetails = new DataSet();
            dsCompDetails = GetCompanyDetails();

            dsParamD = new DataSet();
            dsParamD = Get_OtherGenericSearchDataForGeneralListAll(Month, Year, TranFrom, TranTo, IsPosted, ParamMFrom, ParamMTo, RecordType);

            dsReportDetails = new DataSet();
            dsReportDetails = Get_OtherGenericSearchDataForGeneralListAllGrandTotal(Month, Year, TranFrom, TranTo, IsPosted, ParamMFrom, ParamMTo, RecordType);

            txtCompanyName.Value = dsCompDetails.Tables[0].Rows[0]["CompName"].ToString();
           // textBox3.Value = IsPosted;
            //txtTranPeriod.Value = fromDate + " To " + toDate;
            //table1.DataSource = dsReportDetails.Tables[0];
            if (dsParamD.Tables[0].Rows.Count > 0)
            {
                if (RecordType == "A")
                {
                    table3.Visible = false;
                    table1.DataSource = dsParamD.Tables[0];
                }
                else
                {
                    table3.DataSource = dsParamD.Tables[0];
                    table1.Visible = false;
                }
            }
            else
            {
                table3.Visible = false;
                table1.Visible = false;

            }

            if (dsReportDetails.Tables[0].Rows.Count > 0)
            {
                table2.DataSource = dsReportDetails.Tables[0];
            }
            else
            {
                table2.Visible = false;
                textBox26.Visible = false;
            }
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
        }

        private DataSet Get_OtherGenericSearchDataForGeneralListAll(string Month, string Year, string TranFrom, string TranTo, string IsPosted, string ParamMFrom, string ParamMTo, string RecordType)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_JournalListing  '" + Month + "','" + Year + "','" + TranFrom + "','" + TranTo + "','" + IsPosted + "','" + ParamMFrom + "','" + ParamMTo + "','" + RecordType + "'");
        }
        private DataSet Get_OtherGenericSearchDataForGeneralListAllGrandTotal(string Month, string Year, string TranFrom, string TranTo, string IsPosted, string ParamMFrom, string ParamMTo, string RecordType)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_JournalListingSummary  '" + Month + "','" + Year + "','" + TranFrom + "','" + TranTo + "','" + IsPosted + "','" + ParamMFrom + "','" + ParamMTo + "','" + RecordType + "'");
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