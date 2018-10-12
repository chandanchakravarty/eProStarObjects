namespace eProStarReports.Broking.BIB
{
   
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PrintRenewalNotice.
    /// </summary>
    public partial class PrintRenewalNotice : Telerik.Reporting.Report
    {
        public PrintRenewalNotice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public PrintRenewalNotice(DataRow dr)
        {
            //dt.Columns.Add("ClientName");
            //dt.Columns.Add("Address1");
            //dt.Columns.Add("Address2");
            //dt.Columns.Add("Address3");
            //dt.Columns.Add("Address4");
            //dt.Columns.Add("Nationality");
            //dt.Columns.Add("City");
            //dt.Columns.Add("Postalcode");
            //dt.Columns.Add("CoverNote");
            //dt.Columns.Add("PolicyNo");
            //dt.Columns.Add("SubClass");
            //dt.Columns.Add("Underwriter");
            //dt.Columns.Add("ExpiryDate");
            //dt.Columns.Add("Interest");
            //dt.Columns.Add("Suminsured");
            //dt.Columns.Add("RenewalPremimum");
            //dt.Columns.Add("Company");
            //dt.Columns.Add("servicer");
            InitializeComponent();
            textBox2.Value = dr["ClientName"].ToString();
            textBox3.Value = dr["Address1"].ToString();
            textBox4.Value = dr["Address2"].ToString();
            textBox5.Value = dr["Address3"].ToString();
            textBox9.Value = dr["Address4"].ToString();
            textBox43.Value = dr["Nationality"].ToString() + " " + dr["Postalcode"].ToString();
            textBox7.Value = dr["CoverNote"].ToString();
            textBox11.Value = dr["PolicyNo"].ToString();
            textBox16.Value = dr["SubClass"].ToString();
            textBox19.Value = dr["CoverNote"].ToString();
            textBox22.Value = dr["Underwriter"].ToString();
            textBox25.Value = dr["ExpiryDate"].ToString();
            textBox25.Value = dr["ExpiryDate"].ToString();
            textBox28.Value = dr["Interest"].ToString();
            textBox31.Value = dr["Suminsured"].ToString();
            textBox34.Value = dr["RenewalPremimum"].ToString();
            textBox40.Value = dr["servicer"].ToString();
            textBox35.Value=textBox35.Value.Replace("{comp}", dr["Company"].ToString());
            textBox44.Value= dr["Company"].ToString();
            textBox31.Value = String.Format("{0:#,###0.00}", Convert.ToDecimal((string.IsNullOrEmpty(textBox31.Value.Trim())) ? "0" : textBox31.Value));
            textBox34.Value = String.Format("{0:#,###0.00}", Convert.ToDecimal((string.IsNullOrEmpty(textBox34.Value.Trim())) ? "0" : textBox34.Value));
           

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

    }
}