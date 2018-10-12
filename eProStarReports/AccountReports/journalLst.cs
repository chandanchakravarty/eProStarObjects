namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for journalLst.
    /// </summary>
    internal partial class journalLst : Telerik.Reporting.Report
    {
        public journalLst()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public journalLst(DataSet ds)
        {
            DataSet dsDetails = new DataSet();
            dsDetails = ds;

            InitializeComponent();
            textBox7.Value = "L.C.H.(S) PTE LTD";
            textBox9.Value = "Accounting Month/Year : " + ((ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["SmonthYr"].ToString() + " To " + ds.Tables[0].Rows[0]["EmonthYr"].ToString() : "");
            
            table1.DataSource = ds.Tables[0];
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
    }
}