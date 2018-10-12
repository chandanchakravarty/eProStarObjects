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
    /// Summary description for StatementofAccount_Insurer.
    /// </summary>
    public partial class StatementofAccount_Insurer : Telerik.Reporting.Report
    {
        public StatementofAccount_Insurer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public StatementofAccount_Insurer(DataSet ds)
        {
            InitializeComponent();
            textBox7.Value = "L.C.H.(S) PTE LTD";
            textBox9.Value = ds.Tables[0].Rows[0]["CompanyAdd"].ToString();
            //textBox9.Value = "Accounting Month/Year : " + ((ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["SmonthYr"].ToString() + " To " + ds.Tables[0].Rows[0]["EmonthYr"].ToString() : "");
            table1.DataSource = ds.Tables[0];
            //table3.DataSource = result;
        }
    }

    
}