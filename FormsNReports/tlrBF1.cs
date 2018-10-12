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
    /// Summary description for tlrBF1.
    /// </summary>
    public partial class tlrBF1 : Telerik.Reporting.Report
    {
        public tlrBF1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public tlrBF1(DataSet dataSet, string fromMonth, string fromYear, string toMonth, string toYear)
        {
            double profit, profitBeforTax, profitAfterTax, ProfitNet;
            profit = profitBeforTax = profitAfterTax = ProfitNet = 0.0;

            InitializeComponent();
            txtFinancialEnded.Value = string.Format("For financial year ended {0}/{1}/{2}", System.DateTime.DaysInMonth(int.Parse(toYear), int.Parse(toMonth)), toMonth, toYear);
            //txthead.Value = string.Format("{5} 1/{0}/{1} To {2}/{3}/{4}", fromMonth, fromYear, System.DateTime.DaysInMonth(int.Parse(toYear), int.Parse(toMonth)), toMonth, toYear, txthead.Value);
            DateTime pdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["printTime"].ToString());
            txtCompanyCode.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pCode"].ToString());
            txtCompanyName.Value = string.Format(":   {0}",dataSet.Tables[0].Rows[0]["pName"].ToString());
            txtPrintDate.Value = string.Format("Date Printed {0}/{1}/{2}  {3}:{4}:{5}", pdate.Day, pdate.ToString("MMM"), pdate.Year, pdate.Hour, pdate.Minute, pdate.Second);
            for (int count = 1; count < dataSet.Tables.Count; count++)
            {
                Telerik.Reporting.TextBox txtN = detail.Items.Find(string.Format("txt{0}n", count), true)[0] as Telerik.Reporting.TextBox;
                Telerik.Reporting.TextBox txtR = detail.Items.Find(string.Format("txt{0}r", count), true)[0] as Telerik.Reporting.TextBox;
                txtN.Value = dataSet.Tables[count].Rows[0]["ColumnName"].ToString();
                string result = dataSet.Tables[count].Rows[0]["Result"].ToString();
                if (count == 3)
                {
                    profit = double.Parse(dataSet.Tables[1].Rows[0]["Result"].ToString()) - double.Parse(dataSet.Tables[2].Rows[0]["Result"].ToString());
                    result = profit.ToString("#0.00");
                }
                if (count == 5)
                {
                    profitBeforTax = profit - double.Parse(dataSet.Tables[4].Rows[0]["Result"].ToString());
                    result = profitBeforTax.ToString("#0.00");
                }
                if (count == 8)
                {
                    profitAfterTax = profitBeforTax - double.Parse(dataSet.Tables[6].Rows[0]["Result"].ToString()) - double.Parse(dataSet.Tables[7].Rows[0]["Result"].ToString());
                    result = profitAfterTax.ToString("#0.00");
                }
                if (count == 10)
                {
                    ProfitNet = profitAfterTax + double.Parse(dataSet.Tables[9].Rows[0]["Result"].ToString());
                    result = ProfitNet.ToString("#0.00");
                }
                txtR.Value = result;
            }
        }
    }
}