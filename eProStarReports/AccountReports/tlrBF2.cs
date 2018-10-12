namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    //using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for tlrBF2.
    /// </summary>
   internal partial class tlrBF2 : Telerik.Reporting.Report
    {
        public tlrBF2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public tlrBF2(DataSet dataSet, string fromMonth, string fromYear, string toMonth, string toYear)
        {
            InitializeComponent();
            txtFinancialEnded.Value = string.Format("For financial year ended {0}/{1}/{2}", System.DateTime.DaysInMonth(int.Parse(toYear), int.Parse(toMonth)), toMonth, toYear);
            DateTime pdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["printTime"].ToString());
            txtCompanyCode.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pCode"].ToString());
            txtCompanyName.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pName"].ToString());
            txtPrintDate.Value = string.Format("Date Printed {0}/{1}/{2}  {3}:{4}:{5}", pdate.Day, pdate.ToString("MMM"), pdate.Year, pdate.Hour, pdate.Minute, pdate.Second);
            txtn1.Value = string.Format("{0}  01/01/{1}", txtn1.Value,(int.Parse(toYear) - 1));
            txtn10.Value = string.Format("{0}  31/12/{1}", txtn10.Value,(int.Parse(toYear) - 1));
            txtn19.Value = string.Format("{0}  31/12/{1}",txtn19.Value, toYear);
            
        }
    }
}