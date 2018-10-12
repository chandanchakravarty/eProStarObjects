namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for DetailsCreditorReconReport.
    /// </summary>
    public partial class DetailsCreditorReconReport : Telerik.Reporting.Report
    {
        public DetailsCreditorReconReport()
        {
            InitializeComponent();
        }

        public DetailsCreditorReconReport(DataSet Dsrecon)
        {
            InitializeComponent();
            table1.DataSource = Dsrecon.Tables[0];
            

        }
    }
}