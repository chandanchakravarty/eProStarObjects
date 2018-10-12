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
    /// Summary description for tlrBF3S1.
    /// </summary>
    public partial class tlrBF3 : Telerik.Reporting.Report
    {
        public tlrBF3()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrBF3(DataSet dataSet, string fromMonth, string fromYear, string toMonth, string toYear)
        {
            double Equity, Liability, Property, TradeBalance,Loans,Investments,Cash,Assets;
            Equity = Liability = Property = TradeBalance=Loans=Investments=Cash=Assets = 0.0;

            InitializeComponent();
            //txtFinancialEnded.Value = string.Format("(For financial year ended 31/12/{0})", toYear);
            //txtFinEndDate.Value = string.Format("{5} 1/{0}/{1} To {2}/{3}/{4}", fromMonth, fromYear, System.DateTime.DaysInMonth(int.Parse(toYear), int.Parse(toMonth)), toMonth, toYear, txthead.Value);

            txtCompanyCode.Value = string.Format(":   {0}", dataSet.Tables[0].Rows[0]["pCode"].ToString());
            txtCompanyName.Value = string.Format(":   {0}",dataSet.Tables[0].Rows[0]["pName"].ToString());
            //DateTime fdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["FinancialEnd"].ToString());
           // DateTime fdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["FinancialEnd"].ToString());           
            DateTime pdate = DateTime.Parse(dataSet.Tables[0].Rows[0]["printTime"].ToString());
            txtFinEndDate.Value = string.Format("As at {0}/{1}/{2}", System.DateTime.DaysInMonth(int.Parse(fromYear), int.Parse(fromMonth)), fromMonth, fromYear);


            //txtFinEndDate.Value = string.Format("As at {0}/{1}/{2}", System.DateTime.DaysInMonth(fdate.Year, fdate.Month), fdate.Month, fdate.Year);
            txtPrintDate.Value = string.Format("Date Printed {0}/{1}/{2}  {3}:{4}:{5}", pdate.Day, pdate.ToString("MMM"), pdate.Year, pdate.Hour, pdate.Minute, pdate.Second);
            for (int count = 1; count < dataSet.Tables.Count; count++)
            {
                Telerik.Reporting.TextBox txtN = detail.Items.Find(string.Format("txt{0}n", count), true)[0] as Telerik.Reporting.TextBox;
                Telerik.Reporting.TextBox txtR = detail.Items.Find(string.Format("txt{0}r", count), true)[0] as Telerik.Reporting.TextBox;
                txtN.Value = dataSet.Tables[count].Rows[0]["ColumnName"].ToString();
                string result = dataSet.Tables[count].Rows[0]["Result"].ToString();

                if (count == 1)
                {
                    Equity = double.Parse(dataSet.Tables[2].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[3].Rows[0]["Result"].ToString())
                        + double.Parse(dataSet.Tables[4].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[5].Rows[0]["Result"].ToString());
                    result = Equity.ToString("#0.00");
                }
                if (count == 6)
                {
                    Liability = double.Parse(dataSet.Tables[7].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[8].Rows[0]["Result"].ToString())
                        + double.Parse(dataSet.Tables[9].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[10].Rows[0]["Result"].ToString())
                    +double.Parse(dataSet.Tables[11].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[12].Rows[0]["Result"].ToString());
                    result = Liability.ToString("#0.00");
                }
                if (count == 13)
                {
                    Property = double.Parse(dataSet.Tables[14].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[15].Rows[0]["Result"].ToString());
                    result = Property.ToString("#0.00");
                }
                if (count == 16)
                {
                    Loans = double.Parse(dataSet.Tables[16].Rows[0]["Result"].ToString());
                    result = Loans.ToString("#0.00");
                }
                if (count == 17)
                {
                    Investments = double.Parse(dataSet.Tables[17].Rows[0]["Result"].ToString());
                    result = Investments.ToString("#0.00");
                }
                if (count == 18)
                {
                    Cash = double.Parse(dataSet.Tables[18].Rows[0]["Result"].ToString());
                    result = Cash.ToString("#0.00");
                }
                if (count == 19)
                {          
                    TradeBalance = double.Parse(dataSet.Tables[21].Rows[0]["Result"].ToString()) + double.Parse(dataSet.Tables[22].Rows[0]["Result"].ToString());
                    Assets = TradeBalance+double.Parse(dataSet.Tables[23].Rows[0]["Result"].ToString());
                    result = Assets.ToString("#0.00");
                }
                if (count == 20)
                { 
                    result = TradeBalance.ToString("#0.00");
                }
                txtR.Value = result;
            }

            txtTotalLiabil.Value = (Equity + Liability).ToString("#0.00");
            txtTotalAssets.Value = (Property+Loans+Investments+Cash+Assets).ToString("#0.00");

        }
    }
}