namespace NWILetterReport.IHReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptMonthlyProfitability.
    /// </summary>
    public partial class RptMonthlyProfitability : Telerik.Reporting.Report
    {
        public RptMonthlyProfitability()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptMonthlyProfitability(DataSet ds)
        {
           InitializeComponent();
           table1.DataSource = ds;
        }
    }
}