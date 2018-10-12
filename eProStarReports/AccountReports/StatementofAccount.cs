namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// Summary description for StatementofAccount.
    /// </summary>
   internal partial class StatementofAccount : Telerik.Reporting.Report
    {
        public StatementofAccount()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public StatementofAccount(DataSet ds)
        {
            InitializeComponent();
            
            //var result = from tab in (ds.Tables[1]).AsEnumerable()
            //             group tab by tab["CurrencyCode"]
            //                 into groupDt
            //                 select new
            //                 {
            //                     CurrencyCode = groupDt.Key,                                
            //                     CurrentMonth = groupDt.Sum((r) => decimal.Parse(r["CurrentMonth"].ToString())),
            //                     Days30to60 = groupDt.Sum((r) => decimal.Parse(r["Days30to60"].ToString())),
            //                     Days60to90 = groupDt.Sum((r) => decimal.Parse(r["Days60to90"].ToString())),
            //                     Days90to180 = groupDt.Sum((r) => decimal.Parse(r["Days90to180"].ToString())),                                 

            //                 };

            //textBox7.Value = "L.C.H.(S) PTE LTD";
            textBox7.Value = ds.Tables[0].Rows[0]["Company"].ToString();
            textBox9.Value = ds.Tables[0].Rows[0]["CompanyAdd1"].ToString();
            textBox52.Value = ds.Tables[0].Rows[0]["Team"].ToString();

            textBox31.Value = ds.Tables[0].Rows[0]["CompanyAdd2"].ToString();

            textBox64.Value = (ds.Tables[0].Rows[0]["CompanyAdd3"].ToString() == "" ? (ds.Tables[0].Rows[0]["CompanyAdd4"].ToString() == "" ? ds.Tables[0].Rows[0]["Email"].ToString() : ds.Tables[0].Rows[0]["CompanyAdd4"].ToString()) : ds.Tables[0].Rows[0]["CompanyAdd3"].ToString());

            textBox66.Value = (ds.Tables[0].Rows[0]["CompanyAdd4"].ToString() == "" ? (ds.Tables[0].Rows[0]["CompanyAdd3"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["Email"].ToString()) : (ds.Tables[0].Rows[0]["CompanyAdd3"].ToString() == "" ? ds.Tables[0].Rows[0]["Email"].ToString() : ds.Tables[0].Rows[0]["CompanyAdd4"].ToString()));

            if ((textBox64.Value == ds.Tables[0].Rows[0]["Email"].ToString()) || (textBox66.Value == ds.Tables[0].Rows[0]["Email"].ToString()))
            {
                textBox67.Value = "";
            }
            else { textBox67.Value = ds.Tables[0].Rows[0]["Email"].ToString(); } 


            //textBox9.Value = "Accounting Month/Year : " + ((ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["SmonthYr"].ToString() + " To " + ds.Tables[0].Rows[0]["EmonthYr"].ToString() : "");
            table1.DataSource = ds.Tables[0];       
            //table3.DataSource = result;
        }

        public static string convertIntoNumeric(decimal number)
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

            return str;

        }
    }
}