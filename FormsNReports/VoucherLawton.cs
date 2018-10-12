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
    /// Summary description for ReceiptVoucherLCH.
    /// </summary>
    public partial class VoucherLawton : Telerik.Reporting.Report
    {
        public VoucherLawton(DataSet DS, string ReportType)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            txtCompanyName.Value = DS.Tables[1].Rows[0]["CompanyName"].ToString();
            txtAddress.Value = DS.Tables[1].Rows[0]["CompanyAddress"].ToString();
            txtDescription.Value = DS.Tables[1].Rows[0]["Description"].ToString();
            txtVoucherNo.Value = DS.Tables[1].Rows[0]["VouRefNo"].ToString();
            txtVoucherDate.Value = DS.Tables[1].Rows[0]["VoucherDate"].ToString();
            if (ReportType.Trim().ToUpper() == "P")
            {
                txtReportType.Value = "Payment Journal";
            }
            else if (ReportType.Trim().ToUpper() == "J")
            {
                txtReportType.Value = "General Journal";
            }
            int rowCount = DS.Tables[0].Rows.Count;
            for (int i = 1; i <= 24 - (rowCount % 20); i++)
            {
                DS.Tables[0].Rows.Add(DS.Tables[0].NewRow());
            }
            table1.DataSource = DS.Tables[0];
            double total = 0.0;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    total += double.Parse(DS.Tables[0].Rows[i]["TranAmountCr"].ToString());
                }
                catch (Exception ex)
                {
                }
            }
            ReportUtility reportUtility = new ReportUtility();
            txtAmountinWord.Value = reportUtility.DecimalToWords(total);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        //START - Method for Generate Batch Printing(Vouchers) Report :---------------------
        public VoucherLawton(DataRow header, DataTable dt, string ReportType)
        {
            InitializeComponent();

            txtCompanyName.Value = Convert.ToString(header["CompanyName"]);
            txtAddress.Value = Convert.ToString(header["CompanyAddress"]);
            txtDescription.Value = Convert.ToString(header["Description"]);
            txtVoucherNo.Value = Convert.ToString(header["VouRefNo"]);
            txtVoucherDate.Value = Convert.ToString(header["VoucherDate"]);

            if (ReportType.Trim().ToUpper() == "P")
            {
                txtReportType.Value = "Payment Journal";
            }
            else if (ReportType.Trim().ToUpper() == "J")
            {
                txtReportType.Value = "General Journal";
            }

            int rowCount = dt.Rows.Count;

            for (int i = 1; i <= 24 - (rowCount % 20); i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

            table1.DataSource = dt;

            double total = 0.0;

            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    total += double.Parse(dt.Rows[i]["TranAmountCr"].ToString());
                }
                catch (Exception ex)
                {
                }
            }

            ReportUtility reportUtility = new ReportUtility();
            txtAmountinWord.Value = reportUtility.DecimalToWords(total);
        }
    }
}