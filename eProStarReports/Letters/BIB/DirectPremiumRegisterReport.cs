namespace eProStarReports.Letters.BIB
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for DirectPremiumRegisterReport.
    /// </summary>
    public partial class DirectPremiumRegisterReport : Telerik.Reporting.Report
    {
        public DirectPremiumRegisterReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public DirectPremiumRegisterReport(DataSet dsObj)
        {
            InitializeComponent();
            table1.DataSource = dsObj.Tables[0];
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
            //String.Format("{0:n}", Convert.ToDouble(number));
            return str;

        }

    }
}