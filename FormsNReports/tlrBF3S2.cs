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
    /// Summary description for tlrBF3S2.
    /// </summary>
    public partial class tlrBF3S2 : Telerik.Reporting.Report
    {
        public tlrBF3S2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
          public tlrBF3S2(DataSet dataSet, string fromMonth, string fromYear)
        {
           
            InitializeComponent();           
            txtCompanyCode.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pCode"].ToString());
            txtCompanyName.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pName"].ToString());
            DateTime fdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["FinancialEnd"].ToString());
            DateTime pdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["printTime"].ToString());
            string CurrencyDesc = dataSet.Tables[0].Rows[0]["CurrencyDesc"].ToString();
            txtFinEndDate.Value = string.Format("As at {0}/{1}/{2}", System.DateTime.DaysInMonth(int.Parse(fromYear), int.Parse(fromMonth)), fromMonth, fromYear);
            //txtFinEndDate.Value = string.Format("As at {0}/{1}/{2}", System.DateTime.DaysInMonth(fdate.Year, fdate.Month), fdate.Month, fdate.Year);
            txtPrintDate.Value = string.Format("Date Printed {0}/{1}/{2}  {3}:{4}:{5}", pdate.Day, pdate.ToString("MMM"), pdate.Year, pdate.Hour, pdate.Minute, pdate.Second);
            if (!string.IsNullOrEmpty(CurrencyDesc))
            {
                txtCurr.Value = string.Format("Currency: {0}", CurrencyDesc);
            }         
           
        }
    }
}