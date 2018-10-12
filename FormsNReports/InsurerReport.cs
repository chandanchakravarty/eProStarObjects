namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for InsurerReport.
    /// </summary>
    public partial class InsurerReport : Telerik.Reporting.Report
    {
        private System.Data.DataSet dsGetData;
        private string Insurercode;
        private string residence;
        private string from;
        private string to;

        public InsurerReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public InsurerReport(DataSet dsGetData,DataSet DsComp, string Insurercode, string residence, string from, string to, string InsurerName)
        {
            InitializeComponent();
            //DataSet DsFinal = new DataSet("Main");
            DataTable dt = new DataTable("Insurer");
            dt = dsGetData.Tables[0].Clone();
            var query = (
            from row in dsGetData.Tables[0].AsEnumerable()
            select row.Field<string>("InsurerName")).Distinct();
            DataRow drow;
            double total = 0.0;
            double total1 = 0.0;
            double total2 = 0.0;
            double total3 = 0.0;
            double total4 = 0.0;
            foreach (string item in query)
            {
              
                DataRow[] ldrs = null;
                ldrs = dsGetData.Tables[0].Select("InsurerName='" + item + "'");
                int _c = 1;

                double total_ = 0.0;
                double total1_1 = 0.0;
                double total2_2 = 0.0;
                double total3_3 = 0.0;
                double total4_4 = 0.0;
                foreach (DataRow dr in ldrs)
                {
                    if (_c == 1)
                    {
                        DataRow newRow1 = dt.NewRow();
                        newRow1["debitnotedate"] ="INSURER:";
                        newRow1["drcrtoname"] = item;
                        dt.Rows.Add(newRow1);
                    }
                 dt.ImportRow(dr);
                 total_ += Convert.ToDouble(dr["grosspremiumli"]);
                 total1_1 += Convert.ToDouble(dr["discountLC"]);
                 total2_2 += Convert.ToDouble(dr["gstcommamtli"]);
                 total3_3 += Convert.ToDouble(dr["commissionamtli"]);
                 total4_4 += Convert.ToDouble(dr["netpremiumli"]);

                 if (_c == ldrs.Length)
                 {

                     //object  sumObject = 0.0;
                     //try
                     //{
                     //   // sumObject = dt.Compute("Sum(grosspremiumli)", "");
                     //    sumObject = dt.Compute("Sum(grosspremiumli)", "");
                     //}
                     //catch
                     //{
                     //    sumObject = 0.0;
                     //}
                     //total = +Convert.ToDouble(sumObject);
                     //object sumObject1 = 0.0;
                     //try
                     //{
                     //    sumObject1 = dt.Compute("Sum(discountLC)", "");
                     //}
                     //catch
                     //{
                     //    sumObject1 = 0.0;
                     //}
                     //total1 = +Convert.ToDouble(sumObject1);
                     //object sumObject2 = 0.0;
                     //try
                     //{
                     //    sumObject2 = dt.Compute("Sum(gstcommamtli)", "");
                     //}
                     //catch
                     //{
                     //    sumObject2 = 0.0;
                     //}
                     //total2 = +Convert.ToDouble(sumObject2);
                     //object sumObject3 = 0.0;
                     //try
                     //{
                     //    sumObject3 = dt.Compute("Sum(commissionamtli)", "");
                     //}
                     //catch
                     //{
                     //    sumObject3 = 0.0;
                     //}
                     //total3 = +Convert.ToDouble(sumObject3);
                     //object sumObject4 = 0.0;
                     //try
                     //{
                     //    sumObject4 = dt.Compute("Sum(netpremiumli)", "");
                     //}
                     //catch
                     //{
                     //    sumObject4 = 0.0;
                     //}
                     total += Convert.ToDouble(total_);
                     total1 += Convert.ToDouble(total1_1);
                     total2 += Convert.ToDouble(total2_2);
                     total3 += Convert.ToDouble(total3_3);
                     total4 += Convert.ToDouble(total4_4);
                     DataRow newCustomersRow1 = dt.NewRow();
                     newCustomersRow1["drcrtoname"] = "Sub Total :";
                     newCustomersRow1["grosspremiumli"] = total_;
                     newCustomersRow1["discountLC"] = total1_1;
                     newCustomersRow1["gstcommamtli"] = total2_2;
                     newCustomersRow1["commissionamtli"] = total3_3;
                     newCustomersRow1["netpremiumli"] = total4_4;
                     dt.Rows.Add(newCustomersRow1);

                 }
                    _c++;
                }
            }
            textBox36.Value = total.ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture);
            textBox37.Value = total1.ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture);
            textBox38.Value = total2.ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture); ;
            textBox39.Value = total3.ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture); ;
            textBox40.Value = total3.ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture); ;

            #region start
            //DataTable dtDistinctNames = new DataTable();
            //dtDistinctNames.Columns.Add("InsurerName", typeof(string));
            //int _counter = 1;
            //foreach (string item in query)
            //{
            //    DataRow newRow = dtDistinctNames.NewRow();
            //    newRow["InsurerName"] = item;
            //    dtDistinctNames.Rows.Add(newRow);
            //    DataSet Dss = FilterDataset(dsGetData, "InsurerName='" + item + "'", _counter);
            //    DsFinal.Tables.Add(Dss.Tables[0].Copy());
            //    _counter++;
            //}
            #endregion End

            textBox10.Value = "Date";
            textBox11.Value = "Client Name";
            textBox12.Value = "Policy No";
            textBox15.Value = "Ref No.";
            textBox16.Value = "Class";
            textBox17.Value = "GrossPrem";
            textBox18.Value = "Disct";
            textBox19.Value = "GST";
            textBox20.Value = "OwnComm";
            textBox21.Value = "NettPrem";
            textBox13.Value = "IntroName";
            textBox22.Value = "IntroComm";
            textBox1.Value = DsComp.Tables[0].Rows[0]["CompName"].ToString();
            textBox41.Value = "RUN DATE :" + DateTime.Now.ToString("dd/MM/yyyy");
            textBox5.Value = from + "To" + to;
            textBox7.Value = residence;
            textBox9.Value = InsurerName;
            table1.DataSource = dt;
            //table3.DataSource = dsGetData;
           
        }

        public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            DataTable dtUniqRecords = new DataTable();
            dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
            return dtUniqRecords;
        }

        public static DataSet FilterDataset(DataSet dsInput, string strFilter, int _counter)
        {
           
            DataSet dsResult = new DataSet();
            DataRow[] ldrs = null;
            dsResult = dsInput.Clone();
            ldrs = dsInput.Tables[0].Select(strFilter);
           // dsResult.Tables.Add();
         
            foreach (DataRow dr in ldrs)
            {
                dsResult.Tables[0].ImportRow(dr);
            }
            object sumObject;
            try
            {
                sumObject = dsResult.Tables[0].Compute("Sum(grosspremiumli)", "");
            }
            catch
            {
                sumObject = 0.0;
            }
            DataRow newCustomersRow = dsResult.Tables[0].NewRow();
            newCustomersRow["grosspremiumli"] = sumObject;
            dsResult.Tables[0].Rows.Add(newCustomersRow);
            
            return dsResult;
        }

        private void textBox24_ItemDataBinding(object sender, EventArgs e)
        {

        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {

        }
    }
}