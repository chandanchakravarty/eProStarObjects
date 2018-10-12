namespace FormsNReports
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
    using BusinessAccessLayer.Common;
    using FormsNReports;
    
    /// <summary>
    /// Summary description for StatementofAccount.
    /// </summary>
    public partial class StatementofAccount : Telerik.Reporting.Report 
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
            textBox9.Value = ds.Tables[0].Rows[0]["CompanyAdd"].ToString();
            textBox52.Value = ds.Tables[0].Rows[0]["Team"].ToString();
            picHeader.Value = MiscUtil.setClientLogo();
            //textBox9.Value = "Accounting Month/Year : " + ((ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["SmonthYr"].ToString() + " To " + ds.Tables[0].Rows[0]["EmonthYr"].ToString() : "");
            table1.DataSource = ds.Tables[0];       
            //table3.DataSource = result;
        }
    }
}