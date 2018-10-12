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
    /// Summary description for TransactionLog.
    /// </summary>
    public partial class TransactionLog : Telerik.Reporting.Report
    {
        public TransactionLog()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        // Parameterized Constructor By gopal

        public TransactionLog(DataSet DsParamD, DataSet DsCompDtl,DataSet DsreportDetails)
        {
            InitializeComponent();

            textBox1.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
            table1.DataSource = DsParamD.Tables[0];
            table2.DataSource = DsreportDetails.Tables[0];
        }
    }
}