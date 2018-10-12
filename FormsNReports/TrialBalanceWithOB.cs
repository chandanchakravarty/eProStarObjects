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
    /// Summary description for TrialBalanceWithOB.
    /// </summary>
    public partial class TrialBalanceWithOB : Telerik.Reporting.Report
    {
        public TrialBalanceWithOB(DataSet DS)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            txtCompanyName.Value = DS.Tables[1].Rows[0]["CompanyName"].ToString();
            txtReportName.Value += DS.Tables[1].Rows[0]["ToDate"].ToString();
            txtPrintDate.Value = DS.Tables[1].Rows[0]["PrintDate"].ToString();            

            txtGLCodeFrom.Value = DS.Tables[1].Rows[0]["GLCodeFrom"].ToString();
            txtGLCodeTo.Value = DS.Tables[1].Rows[0]["GLCodeTo"].ToString();

            txtDateFrom.Value = DS.Tables[1].Rows[0]["FromDate"].ToString();
            txtDateTo.Value = DS.Tables[1].Rows[0]["ToDate"].ToString();
            txtZeroAmt.Value += DS.Tables[1].Rows[0]["IsZeroAmtIncluded"].ToString()+"]";

            table1.DataSource = DS.Tables[0];
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}