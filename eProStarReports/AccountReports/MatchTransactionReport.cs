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
    /// Summary description for MatchTransactionReport.
    /// </summary>
   internal partial class MatchTransactionReport : Telerik.Reporting.Report
    {
        public MatchTransactionReport() 
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public MatchTransactionReport(DataSet Ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            DataTable dtUniqRecords = new DataTable();
            DataTable DtFinal = new DataTable();
            DtFinal = Ds.Tables[0].Clone();
            dtUniqRecords = Ds.Tables[0].DefaultView.ToTable(true, "Insurer");

            string _customizedClient = String.Empty;
            BusinessAccessLayer.Common.clsCommon _cmn = new BusinessAccessLayer.Common.clsCommon();
            _customizedClient = _cmn.GetCustomizedClient();
            if (_customizedClient.ToUpper() == "HOWDEN" || _customizedClient.ToUpper() == "HOWDENSG")
	        {
                textBox2.Value = "Medium Reference No.";
                textBox3.Value = "Medium Reference Date";
                textBox37.Value = "Medium Reference Number";
	        }
            for (int i = 0; i < dtUniqRecords.Rows.Count; i++)
            {
                string filterExp = "Insurer = '" + dtUniqRecords.Rows[i]["Insurer"].ToString() + "'";
                var dv = Ds.Tables[0].DefaultView;
                dv.RowFilter = filterExp;
                var newDS = new DataSet();
                var newDT = dv.ToTable();
                DataRow newCustomersRow = newDT.NewRow();
                newCustomersRow["Insurer"] = "Total :";
                newCustomersRow["Amount_DueInsurer"] = newDT.Compute("Sum(Amount_DueInsurer)", "");
                newCustomersRow["Brokerage"] = newDT.Compute("Sum(Brokerage)", "");
                newCustomersRow["GrandTotal"] = newDT.Compute("Sum(GrandTotal)", "");
                newDT.Rows.Add(newCustomersRow);
                newDS.Tables.Add(newDT);

                for (int k = 1; k <= newDS.Tables[0].Rows.Count; k++)
                {
                    DtFinal.ImportRow(newDS.Tables[0].Rows[k-1]);
                }

            }
            object sumInsurerAmt = 0.0;
            object sumBrokerage = 0.0;
            object sumGrandTotal = 0.0;
            //sumInsurerAmt = DtFinal.Compute("Sum(Amount_DueInsurer)", "");
            //sumBrokerage = DtFinal.Compute("Sum(Brokerage)", "");
            //sumGrandTotal = DtFinal.Compute("Sum(GrandTotal)", "");
            if (DtFinal.Rows.Count > 0)
            {
                sumInsurerAmt = DtFinal.Rows[DtFinal.Rows.Count - 1]["Amount_DueInsurer"].ToString();
                sumBrokerage = DtFinal.Rows[DtFinal.Rows.Count - 1]["Brokerage"].ToString();
                sumGrandTotal = DtFinal.Rows[DtFinal.Rows.Count - 1]["GrandTotal"].ToString();
                textBox42.Value = sumInsurerAmt.ToString();
                textBox43.Value = sumBrokerage.ToString();
                textBox44.Value = sumGrandTotal.ToString();
            }
            else
            {
                textBox42.Value = sumInsurerAmt.ToString();
                textBox43.Value = sumBrokerage.ToString();
                textBox44.Value = sumGrandTotal.ToString();
            }
            table1.DataSource = DtFinal;

        }
    }
}