namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for JournalVoucher.
    /// </summary>
   internal partial class JournalVoucher : Telerik.Reporting.Report
    {
        public JournalVoucher()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public JournalVoucher(DataSet DsDetail,DataSet DsClient,DataSet DsCompany,DataSet DsGlDetails)
        {
            InitializeComponent();
            if (DsCompany.Tables[0].Rows.Count > 0)
            {
                table1.DataSource = DsCompany.Tables[0];
            }
            if (DsClient.Tables[0].Rows.Count > 0)
            {
                table2.DataSource = DsClient.Tables[0];
            }

            if (DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString() != "")
            {
                textBox47.Value = DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString();
            }
            if (!string.IsNullOrEmpty(DsClient.Tables[0].Rows[0]["UserLoginID"].ToString()))
            {
                textBox74.Value = DsClient.Tables[0].Rows[0]["UserLoginID"].ToString();
            }
            else
            {
                textBox47.Visible = false;
            }

            if (DsDetail.Tables[0].Rows.Count > 0)
            {
                //object ObjAmount;
                //ObjAmount = DsDetail.Tables[0].Compute("Sum(TranAmount)", "");
                //textBox62.Value = ObjAmount.ToString();
                table3.DataSource = DsDetail.Tables[0];

            }

            else
            {
                
                //textBox26.Visible = false;
                //textBox27.Visible = false;
                //textBox48.Visible = false;
                //textBox49.Visible = false;
                //textBox50.Visible = false;
                ////textBox51.Visible = false;
                //textBox52.Visible = false;
               // textBox60.Visible = false;
                //textBox61.Visible = false;
               // textBox62.Visible = false;
                //textBox63.Visible = false;
                table3.Visible = false;
            }

            if (DsGlDetails.Tables[0].Rows.Count > 0)
            {
                //object ObjCreditAmount;
                //object ObjDebitAmount;
                //ObjCreditAmount = DsGlDetails.Tables[0].Compute("Sum(Creditamount)", "");
                //ObjDebitAmount = DsGlDetails.Tables[0].Compute("Sum(Debitamount)", "");
                //textBox69.Value = ObjDebitAmount.ToString();
                //textBox70.Value = ObjCreditAmount.ToString();
                table4.DataSource = DsGlDetails.Tables[0];
            }
            else
            {
                //textBox63.Visible = false;
                //textBox64.Visible = false;
                //textBox65.Visible = false;
                //textBox66.Visible = false;
                //textBox67.Visible = false;
                //textBox68.Visible = false;
                //textBox69.Visible = false;
                //textBox70.Visible = false;
               
                table4.Visible = false;
            }
         
        }

        public static string ConvertIntoNumeric(decimal number)
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
            //String.Format("{0:n}", Convert.ToDouble(number));
            return str;

        }
    }
}