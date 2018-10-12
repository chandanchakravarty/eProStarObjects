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
    /// Summary description for TrialBalance.
    /// </summary>
    internal partial class TrialBalance : Telerik.Reporting.Report
    {
        public TrialBalance()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public TrialBalance(DataSet TrialBalance, string Mon, int yy, string mstrCompanylogo, int type, string DateType)
        {
            InitializeComponent();

            decimal CurrMonthDB = 0;
            decimal CurrMonthCR = 0;
            decimal YearToDateDB = 0;
            decimal YearToDateCR = 0;

            table4.DataSource = TrialBalance.Tables[1];
            textBox92.Value = "YES";
            textBox89.Value = Mon + ' ' + yy;
            if (type == 1)
            {
                table1.Visible = false;
                if (TrialBalance.Tables.Count > 0 && TrialBalance.Tables[0].Rows.Count > 0)
                    table2.DataSource = TrialBalance.Tables[0];

                if (TrialBalance.Tables.Count > 1 && TrialBalance.Tables[2].Rows.Count > 0)
                {
                    textBox9.Value = "Debit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox12.Value = "Credit" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox26.Value = "Debit" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox27.Value = "Credit" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                }
            }
            else
            {
                table2.Visible = false;
                if (TrialBalance.Tables.Count > 0 && TrialBalance.Tables[0].Rows.Count > 0)
                    table1.DataSource = TrialBalance.Tables[0];

                if (TrialBalance.Tables.Count > 1 && TrialBalance.Tables[2].Rows.Count > 0)
                {
                    textBox39.Value = "Debit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox40.Value = "Credit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox42.Value = "Debit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox43.Value = "Credit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox49.Value = "Debit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                    textBox46.Value = "Credit(" + Convert.ToString(TrialBalance.Tables[2].Rows[0]["CurrencyCode"]) + ")";
                }
            }

            //if (type == 2)
            //{

            //    if (TrialBalance.Tables[0].Rows.Count > 0)
            //    {
            //        table2.Visible = false;
            //        textBox39.Visible = false;
            //        textBox40.Visible = false;
            //        textBox41.Visible = false;
            //        // image1 = Image.FromFile(mstrCompanylogo);
            //        // this.pictureBox1.Value = image1;
            //        textBox89.Value = Mon + ' ' + yy;
            //        //object ObjCRAmount;
            //        //object ObjDBAmount;
            //        //object ObjCRAmountYear;
            //        //object ObjDBAmountYear;
            //        //ObjDBAmount = TrialBalance.Tables[0].Compute("Sum(CurrMonthDB)", "");
            //        //ObjCRAmount = TrialBalance.Tables[0].Compute("Sum(CurrMonthCR)", "");
            //        //ObjDBAmountYear = TrialBalance.Tables[0].Compute("Sum(YearToDateDB)", "");
            //        //ObjCRAmountYear = TrialBalance.Tables[0].Compute("Sum(YearToDateCR)", "");
            //        //textBox57.Value = ObjDBAmount.ToString();
            //        //textBox58.Value = ObjCRAmount.ToString();
            //        //textBox59.Value = ObjDBAmountYear.ToString();
            //        //textBox60.Value = ObjCRAmountYear.ToString();
            //        CurrMonthDB = CalculateTotalTrailBalance(TrialBalance.Tables[0], out CurrMonthCR, out YearToDateDB, out YearToDateCR);
            //        textBox57.Value = String.Format("{0:#,###0.00}", CurrMonthDB);
            //        textBox58.Value = String.Format("{0:#,###0.00}", CurrMonthCR);
            //        textBox59.Value = String.Format("{0:#,###0.00}", YearToDateDB);
            //        textBox60.Value = String.Format("{0:#,###0.00}", YearToDateCR);
            //        table4.DataSource = TrialBalance.Tables[1];
            //        table3.DataSource = TrialBalance.Tables[0];
            //    }
            //}
            //else
            //{
            //    textBox92.Value = "NO";
            //    if (TrialBalance.Tables[0].Rows.Count > 0)
            //    {

            //        table3.Visible = false;
            //        textBox55.Visible = false;
            //        textBox57.Visible = false;
            //        textBox58.Visible = false;
            //        textBox59.Visible = false;
            //        textBox60.Visible = false;
            //        textBox89.Value = Mon + ' ' + yy;
            //        //object ObjCRAmount;
            //        //object ObjDBAmount;
            //        //ObjDBAmount = TrialBalance.Tables[0].Compute("Sum(CurrMonthDB)", "");
            //        //ObjCRAmount = TrialBalance.Tables[0].Compute("Sum(CurrMonthCR)", "");
            //        //textBox39.Value = ObjDBAmount.ToString();
            //        //textBox40.Value = ObjCRAmount.ToString();
            //        CurrMonthDB = CalculateTotalTrailBalance(TrialBalance.Tables[0], out CurrMonthCR, out YearToDateDB, out YearToDateCR);
            //        textBox39.Value = String.Format("{0:#,###0.00}", CurrMonthDB);
            //        textBox40.Value = String.Format("{0:#,###0.00}", CurrMonthCR);
            //        table4.DataSource = TrialBalance.Tables[1];
            //        table2.DataSource = TrialBalance.Tables[0];
            //    }
            //}
        }

        private decimal CalculateTotalTrailBalance(DataTable dtTrialBalance, out decimal CurrMonthCR, out decimal YearToDateDB, out decimal YearToDateCR)
        {
            decimal CurrMonthDB = 0;
            CurrMonthCR = 0;
            YearToDateDB = 0;
            YearToDateCR = 0;

            if (dtTrialBalance.Rows.Count > 0)
            {
                foreach (DataRow row in dtTrialBalance.Rows)
                {
                    CurrMonthDB = CurrMonthDB + Convert.ToDecimal(Convert.ToString(row["CurrMonthDB"]).Replace(",", ""));
                    CurrMonthCR = Convert.ToDecimal(CurrMonthCR) + Convert.ToDecimal(Convert.ToString(row["CurrMonthCR"]).Replace(",", ""));
                    YearToDateDB = Convert.ToDecimal(YearToDateDB) + Convert.ToDecimal(Convert.ToString(row["YearToDateDB"]).Replace(",", ""));
                    YearToDateCR = Convert.ToDecimal(YearToDateCR) + Convert.ToDecimal(Convert.ToString(row["YearToDateCR"]).Replace(",", ""));
                }
            }

            return CurrMonthDB;
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