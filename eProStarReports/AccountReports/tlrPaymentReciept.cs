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
    /// Summary description for tlrPaymentReciept.
    /// </summary>
   internal partial class tlrPaymentReciept : Telerik.Reporting.Report
    {
        public tlrPaymentReciept()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrPaymentReciept(DataSet DS)
        {
            InitializeComponent();
            textBox2.Value = DS.Tables[0].Rows[0]["ClientName"].ToString();
            textBox10.Value = DS.Tables[0].Rows[0]["VoucherNo"].ToString();
            textBox11.Value = DS.Tables[0].Rows[0]["ClientAdd1"].ToString();
            textBox12.Value = DS.Tables[0].Rows[0]["ClientAdd2"].ToString();

            textBox15.Value = DS.Tables[0].Rows[0]["ClientAdd3"].ToString();
            textBox16.Value = DS.Tables[0].Rows[0]["ClientAdd4"].ToString();
            textBox18.Value = DS.Tables[0].Rows[0]["ClientCode"].ToString();
            textBox14.Value = DS.Tables[0].Rows[0]["VoucherDate"].ToString();
            table1.DataSource = DS.Tables[0];
           // table2.DataSource = DS1.Tables[0];
        }
    }
}