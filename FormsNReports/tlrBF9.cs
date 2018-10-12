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
    /// Summary description for tlrBF9.
    /// </summary>
    public partial class tlrBF9 : Telerik.Reporting.Report
    {
        public tlrBF9()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrBF9(DataSet dataSet, string fromMonth, string fromYear, string toMonth, string toYear)
        {
            double TrainingEx, TotalGross, PerOfTrain, MinimunTrain,Diffrance;
            TrainingEx = TotalGross = PerOfTrain = Diffrance=MinimunTrain = 0.0;

            InitializeComponent();
            txtFinancialEnded.Value = string.Format("From 1/{0}/{1} to {2}/{3}/{4}", fromMonth, fromYear, DateTime.DaysInMonth(int.Parse(toYear), int.Parse(toMonth)), toMonth, toYear);           
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
                    TrainingEx = double.Parse(dataSet.Tables[1].Rows[0]["Result"].ToString());
                    TotalGross = double.Parse(dataSet.Tables[2].Rows[0]["Result"].ToString());
                    if (TotalGross == 0)
                    {
                        PerOfTrain = 0.00;
                    }
                    else
                    {
                        PerOfTrain = TrainingEx / TotalGross;
                    }
                    result = PerOfTrain.ToString("#0.00");
                }
                if (count == 4)
                {
                    MinimunTrain = TotalGross*2/100;
                    result = MinimunTrain.ToString("#0.00");
                }
                if (count == 5)
                {
                    Diffrance = TrainingEx-MinimunTrain;
                    result = Diffrance.ToString("#0.00");
                }               
                txtR.Value = result;
            }
        }
    }
}