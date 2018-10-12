namespace eProStarReports.IHReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptIndividualSummary.
    /// </summary>
   internal partial class RptIndividualSummary : Telerik.Reporting.Report
    {
        public RptIndividualSummary()
        {
            InitializeComponent();

        }
        public RptIndividualSummary(DataSet ds)
        {
            InitializeComponent();
            table1.DataSource = ds;
        }
    }
}