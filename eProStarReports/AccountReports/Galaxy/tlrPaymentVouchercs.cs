namespace eProStarReports.AccountReports.Galaxy
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for tlrPaymentVouchercs.
    /// </summary>
    internal partial class tlrPaymentVouchercs : Telerik.Reporting.Report
    {
        public tlrPaymentVouchercs()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrPaymentVouchercs(DataSet DsComp, DataSet DsClient, DataSet DsVoucher, DataSet DsBank, string batchType, string paymentType)
        {
            InitializeComponent();
            if (DsComp.Tables[0].Rows.Count > 0)
            {
                txtCompany41.Value = Convert.ToString(DsComp.Tables[0].Rows[0]["CompName"]);
                txtAddress42.Value = Convert.ToString(DsComp.Tables[0].Rows[0]["Add1"]);// +" " + Convert.ToString(DsComp.Tables[0].Rows[0]["Add2"]) + " " + Convert.ToString(DsComp.Tables[0].Rows[0]["Add3"]);
                textBox17.Value = DsComp.Tables[0].Rows[0]["Add2"].ToString();
                textBox31.Value = DsComp.Tables[0].Rows[0]["Add3"].ToString();
                textBox1.Value = DsComp.Tables[0].Rows[0]["Add4"].ToString();
                textBox2.Value = DsComp.Tables[0].Rows[0]["Add5"].ToString();
                textBox7.Value = DsComp.Tables[0].Rows[0]["Add7"].ToString();
            }

            if (batchType == "R")
            {
                textBox3.Value = "RECEIPT VOUCHER";
                //textBox49.Visible = true;
                textBox52.Visible = false;
                textBox53.Visible = false;
                textBox54.Visible = false;
                textBox14.Value = "Receipt No";
                textBox18.Value = "Receipt Date";
                textBox20.Value = "Bank Cheque No";
                if (DsClient.Tables[0].Rows.Count > 0)
                {
                    textBox24.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherNo"]);
                    textBox22.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherDate"]);                    
                }

                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    textBox21.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ChequeNo"]);
                }
                else
                {
                    textBox20.Visible = false;
                    textBox21.Visible = false;
                }
            }
            else if (batchType == "P")
            {
                textBox3.Value = "PAYMENT VOUCHER";
               // textBox49.Visible = false;
                textBox52.Visible = true;
                textBox53.Visible = true;
                textBox54.Visible = true;
                textBox14.Value = "Payment No";
                textBox18.Value = "Payment Date";
                textBox20.Value = "Bank Cheque No";
                if (DsClient.Tables[0].Rows.Count > 0)
                {
                    textBox24.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherNo"]);
                    textBox22.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherDate"]);
                 //   textBox21.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["AccountDate"]);
                }

                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    textBox21.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ChequeNo"]);
                }
                else
                {
                    textBox20.Visible = false;
                    textBox21.Visible = false;
                }
            }

            if (DsClient.Tables[0].Rows.Count > 0)
            {
                textBox13.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientName"]);
                textBox11.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientAdd1"]);
                textBox12.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientAdd2"]);
                textBox16.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientAdd3"]);
                if (!string.IsNullOrEmpty(Convert.ToString(DsClient.Tables[0].Rows[0]["ClientAdd4"])))
                {
                    textBox9.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientAdd4"]);
                    textBox9.Visible = true;
                }
                else
                {
                    textBox9.Visible = false;
                }
                textBox59.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["country"]);

                textBox26.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientCode"]);

                if (!string.IsNullOrEmpty(Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherDescription"])))
                    textBox27.Value = DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString();
                else
                    textBox27.Visible = false;
            }

            if (paymentType == "N")
            {
                table1.Visible = true;
                table3.Visible = false;

                if (DsVoucher.Tables[0].Rows.Count > 0)
                    table1.DataSource = DsVoucher.Tables[0];
                else
                    table1.Visible = false;
            }
            else
            {
                table1.Visible = false;
                table3.Visible = true;

                if (DsVoucher.Tables[0].Rows.Count > 0)
                    table3.DataSource = DsVoucher.Tables[0];
                else
                    table3.Visible = false;
            }

            if (DsBank.Tables[0].Rows.Count > 0)
                table4.DataSource = DsBank;
            else
                table4.Visible = false;
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
            return str;
        }
    }
}