namespace eProStarReports.Broking.Acclaim
{
    using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PrintRenewalSummary.
    /// </summary>
    public partial class PrintRenewalSummary : Telerik.Reporting.Report
    {
        public PrintRenewalSummary()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PrintRenewalSummary(DataRow dr,DataTable dt,string pg)
        {
            InitializeComponent();
            //dt.Columns.Add("CoverNote");
            //dt.Columns.Add("SubClass");
            //dt.Columns.Add("ClientName");
            //dt.Columns.Add("Address");
            //dt.Columns.Add("Nationality");
            //dt.Columns.Add("Postalcode");
            //dt.Columns.Add("PolicyNo");
            //dt.Columns.Add("Underwriter");
            //dt.Columns.Add("StartDate");
            //dt.Columns.Add("ExpiryDate");
            //dt.Columns.Add("Suminsured");
            //dt.Columns.Add("Premimum");
            //dt.Columns.Add("Company");
            //dt.Columns.Add("GST");
            //dt.Columns.Add("TotalAmtPayable");
            //textBox3.Value = dr["CoverNote"].ToString();
            textBox32.Value = dr["Premimum"].ToString();
            textBox34.Value = dr["GST"].ToString();
            textBox36.Value = (Convert.ToDecimal((string.IsNullOrEmpty(textBox32.Value) ? "0" : textBox32.Value)) + Convert.ToDecimal((string.IsNullOrEmpty(textBox34.Value) ? "0" : textBox34.Value))).ToString();
            textBox32.Value = String.Format("{0:#,###0.00}", Convert.ToDecimal(textBox32.Value));
            textBox34.Value = String.Format("{0:#,###0.00}", Convert.ToDecimal(textBox34.Value));
            textBox36.Value = String.Format("{0:#,###0.00}",Convert.ToDecimal(textBox36.Value));
            textBox42.Value = dr["CoverNote"].ToString();
            table1.DataSource = dt;
            textBox38.Value = pg;

           
        }
    }
}