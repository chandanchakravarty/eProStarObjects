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
    /// Summary description for RecieptVoucher.
    /// </summary>
    internal partial class PaymentVoucher : Telerik.Reporting.Report
    {
        public PaymentVoucher()
        {
            InitializeComponent();
        }


        public PaymentVoucher(DataSet DsComp, DataSet DsClient, DataSet DsVoucher, DataSet DsBank, string batchType, string paymentType)
        {

            InitializeComponent();
            this.pictureBox1.Value = ReportsUtility.ClientLogo;

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
                textBox30.Visible = false;
                textBox34.Visible = false;
                textBox36.Visible = false;

                textBox25.Value = "Receipt No";
                textBox18.Value = "Receipt Date";
                textBox14.Value = "Bank Cheque No";
                if (DsClient.Tables[0].Rows.Count > 0)
                {
                    textBox10.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherNo"]);
                    textBox8.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherDate"]);
                }

                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    textBox6.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ChequeNo"]);
                }
                else
                {
                    textBox14.Visible = false;
                    textBox6.Visible = false;
                }
            }
            else if (batchType == "P")
            {
                textBox3.Value = "PAYMENT VOUCHER";
                // textBox49.Visible = false;
                textBox36.Visible = true;
                textBox34.Visible = true;
                textBox30.Visible = true;
                textBox25.Value = "Payment No";
                textBox18.Value = "Payment Date";
                textBox14.Value = "Bank Cheque No";
                if (DsClient.Tables[0].Rows.Count > 0)
                {
                    textBox10.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherNo"]);
                    textBox8.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["VoucherDate"]);
                    //   textBox6.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["AccountDate"]);
                }

                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    textBox6.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ChequeNo"]);
                }
                else
                {
                    textBox14.Visible = false;
                    textBox6.Visible = false;
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

                textBox5.Value = Convert.ToString(DsClient.Tables[0].Rows[0]["ClientCode"]);

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
            //String.Format("{0:n}", Convert.ToDouble(number));
            return str;

        }
    }
}