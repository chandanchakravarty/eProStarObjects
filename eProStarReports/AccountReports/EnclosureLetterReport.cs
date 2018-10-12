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
    /// Summary description for EnclosureLetterReport.
    /// </summary>
    public partial class EnclosureLetterReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];


        DataSet DsEnclosureDeatail = null;
       // DataSet DsreportDetails = null;
       
        public EnclosureLetterReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public EnclosureLetterReport(DataSet ds)
        {
            InitializeComponent();
            //DsEnclosureDeatail = GetGetEnclosureLetterDetails(Param1, Param2, Param3, Param4);
            textBox6.Value  =DateTime.Now.ToString("dd/MM/yyyy");
            table2.DataSource = ds.Tables[0];
         
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
        //private DataSet GetGetEnclosureLetterDetails(string Param1, string Param2, string Param3, string Param4)
        //{
           
        //    dataAccess = new DatabaseInteraction(connectionstring);
        //    return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetEnclosureLetter '" + Param1 + "','" + Param2 + "', '" + Param3 + "', '" + Param4 + "'");
        //}
      
    }
}