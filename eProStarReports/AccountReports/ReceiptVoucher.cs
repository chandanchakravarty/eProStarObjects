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
    /// Summary description for RecieptVoucher.
    /// </summary>
   internal partial class ReceiptVoucher : Telerik.Reporting.Report
    {
        public ReceiptVoucher()
        {
            InitializeComponent();
        }


        public ReceiptVoucher(DataSet DsComp, DataSet DsClient, DataSet DsVoucher, DataSet DsBank)
        {
           
            InitializeComponent();
             string _customizedClient = String.Empty;
            BusinessAccessLayer.Common.clsCommon _cmn = new BusinessAccessLayer.Common.clsCommon();
            _customizedClient = _cmn.GetCustomizedClient();

            string _client = String.Empty;
            _client = _cmn.GetClient();

            if (_customizedClient.ToUpper() == "HOWDEN" || _customizedClient.ToUpper() == "HOWDENSG")
	        {
                textBox61.Value = "Medium Reference Number";
                textBox62.Value = "Medium Reference Date";
	        }
            
           // textBox1.Value = DS.Tables[0].Rows[0]["ClientName"].ToString();
            textBox1.Value = DsClient.Tables[0].Rows[0]["AccountDate"].ToString();
            textBox3.Value = DsClient.Tables[0].Rows[0]["ClientName"].ToString();
            textBox10.Value = DsClient.Tables[0].Rows[0]["VoucherNo"].ToString();
            textBox11.Value = DsClient.Tables[0].Rows[0]["ClientAdd1"].ToString();
            textBox12.Value = DsClient.Tables[0].Rows[0]["ClientAdd2"].ToString();
            textBox30.Value = DsClient.Tables[0].Rows[0]["ClientAdd3"].ToString();
            //textBox15.Visible = false
            if (DsClient.Tables[0].Rows[0]["ClientAdd4"].ToString()=="")
            {
                textBox16.Value = DsClient.Tables[0].Rows[0]["Country"].ToString();
                textBox25.Visible = false;
            }
            else
            {
                textBox16.Value = DsClient.Tables[0].Rows[0]["ClientAdd4"].ToString();
                textBox25.Value = DsClient.Tables[0].Rows[0]["Country"].ToString();

            }
            
            textBox18.Value = DsClient.Tables[0].Rows[0]["ClientCode"].ToString();
            textBox14.Value = DsClient.Tables[0].Rows[0]["VoucherDate"].ToString();

            txtCompany41.Value = DsComp.Tables[0].Rows[0]["CompName"].ToString();

            txtAddress42.Value = DsComp.Tables[0].Rows[0]["Add1"].ToString() + " " + DsComp.Tables[0].Rows[0]["Add2"].ToString() + " " + DsComp.Tables[0].Rows[0]["Add3"].ToString();
            //txtAddress43.Value = DS.Tables[0].Rows[0]["Add2"].ToString();
            //textBox1.Value = DS.Tables[0].Rows[0]["Add3"].ToString();
            textBox6.Value = DsComp.Tables[0].Rows[0]["Add4"].ToString();
            textBox5.Value = DsComp.Tables[0].Rows[0]["Add5"].ToString();
            textBox7.Value = DsComp.Tables[0].Rows[0]["Add7"].ToString();
            
            //textBox58.Value = DsComp.Tables[0].Rows[0]["Currency"].ToString();
            //textBox59.Value = DsComp.Tables[0].Rows[0]["TranAmount"].ToString();

            if (DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString() != "")
            {
                textBox19.Value = DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString();
            }
            else
            {
                textBox19.Visible = false;
            }
            
            //if (DS.Tables[0].Columns.Contains("ChequeNo"))
            //{
            //    textBox33.Value = DS.Tables[0].Rows[0]["ChequeNo"].ToString();
            //    textBox31.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
            //    textBox32.Value = DS.Tables[0].Rows[0]["CurrencyCode"].ToString();
            //    textBox34.Value = DS.Tables[0].Rows[0]["ExchangeRate"].ToString();
            //    textBox35.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
            //    textBox40.Value = DS.Tables[0].Rows[0]["ChequeDate"].ToString();

            //    //object SumAmount;
            //    //SumAmount = DS.Tables[0].Compute("Sum(Amount)", "");
            //    //textBox38.Value = SumAmount.ToString();
            //    textBox38.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
            //}
            //else
            //{
            //  //  textBox24.Visible = false;
            //    textBox33.Visible = false;
            //    textBox31.Visible = false;
            //    textBox32.Visible = false;
            //    textBox34.Visible = false;
            //    textBox35.Visible = false;
            //    textBox38.Visible = false;
            //    textBox25.Visible = false;
            //   // textBox27.Visible = false;
            //    textBox28.Visible = false;
            //    textBox29.Visible = false;
            //    textBox30.Visible = false;
            //    textBox38.Visible = false;
            //    textBox36.Visible = false;
            //    textBox37.Visible = false;
            //    textBox39.Visible = false;
            //    textBox4.Visible = false;
            //    textBox40.Visible = false;
            //}           

            if (_client.ToUpper() == "STARACCLAIM")
            {
                table3.Visible = false;
                table2.Visible = true;
                if (DsVoucher.Tables[0].Rows.Count > 0)
                {
                    table2.DataSource = DsVoucher.Tables[0];

                }
                else
                {
                    table2.Visible = false;

                }
            }
            else
            {
                table2.Visible = false;
                table3.Visible = true;
                if (DsVoucher.Tables[0].Rows.Count > 0)
                {
                    table3.DataSource = DsVoucher.Tables[0];

                }
                else
                {
                    table3.Visible = false;
                }
            }

            if (_client.ToUpper() == "STARACCLAIM")
            {
                table4.Visible = true;
                table1.Visible = false;
                
                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    table4.DataSource = DsBank.Tables[0]; ;

                }
                else
                {
                    table4.Visible = false;

                }
            }
            else
            {
                table1.Visible = true;
                table4.Visible = false;
                if (DsBank.Tables[0].Rows.Count > 0)
                {
                    table1.DataSource = DsBank.Tables[0]; ;

                }
                else
                {
                    table1.Visible = false;

                }
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