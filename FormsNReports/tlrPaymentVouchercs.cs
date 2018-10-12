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
    /// Summary description for tlrPaymentVouchercs.
    /// </summary>
    public partial class tlrPaymentVouchercs : Telerik.Reporting.Report
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

        public tlrPaymentVouchercs(DataSet DsComp, DataSet DsClient, DataSet DsVoucher, DataSet DsBank)
        {
            InitializeComponent();
           // table1.DataSource = DsComp.Tables[0];
           // table2.DataSource = DsClient.Tables[0];
            textBox1.Value = DsComp.Tables[0].Rows[0]["CompName"].ToString();
            textBox12.Value = DsComp.Tables[0].Rows[0]["Add1"].ToString();
            textBox2.Value = DsComp.Tables[0].Rows[0]["Add2"].ToString();
            textBox21.Value = DsComp.Tables[0].Rows[0]["Add3"].ToString();
            textBox26.Value = DsComp.Tables[0].Rows[0]["Add4"].ToString();
            textBox57.Value = DsComp.Tables[0].Rows[0]["Add7"].ToString();
            textBox31.Value = DsComp.Tables[0].Rows[0]["Add6"].ToString();
            textBox20.Value = DsComp.Tables[0].Rows[0]["Add5"].ToString();
            textBox34.Value = "Total Payment(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            textBox48.Value = " Total Paid Amount(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            textBox85.Value = "Amount(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            textBox46.Value = " Amount(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            if (textBox1.Value == "")
            {
                this.textBox1.Height = Unit.Cm(0.0);
            }
            if (textBox12.Value == "")
            {
                this.textBox12.Height = Unit.Cm(0.0);
            }
            if (textBox2.Value == "")
            {
                this.textBox2.Height = Unit.Cm(0.0);
            }
            if (textBox21.Value == "")
            {
                this.textBox21.Height = Unit.Cm(0.0);
            }
            if (textBox26.Value == "")
            {
                this.textBox26.Height = Unit.Cm(0.0);
            }
            if ((textBox57.Value == "") || (textBox57.Value.Trim() == "Co.& Reg No."))
            {
                textBox57.Value = "";
                this.textBox57.Height = Unit.Cm(0.0);
            }
            if ((textBox31.Value == "") || (textBox31.Value.Trim() == "Email:"))
            {
                textBox31.Value = "";
                this.textBox31.Height = Unit.Cm(0.0);
            }
            if ((textBox20.Value == "" ) ||(textBox20.Value.Trim() =="GST Reg No."))
            {
                textBox20.Value = "";
                this.textBox20.Height = Unit.Cm(0.0);
            }
            


            textBox9.Value = DsClient.Tables[0].Rows[0]["ClientName"].ToString();
            textBox62.Value = DsClient.Tables[0].Rows[0]["ClientAdd1"].ToString();
            textBox74.Value = DsClient.Tables[0].Rows[0]["ClientAdd2"].ToString();
            textBox56.Value = DsClient.Tables[0].Rows[0]["ClientAdd3"].ToString();
            textBox3.Value = DsClient.Tables[0].Rows[0]["ClientAdd4"].ToString();
            textBox16.Value = "Account No : "  + DsClient.Tables[0].Rows[0]["ClientCode"].ToString();

            textBox7.Value ="Payment No :" + DsClient.Tables[0].Rows[0]["VoucherNo"].ToString();
            textBox11.Value ="Payment Date :" + DsClient.Tables[0].Rows[0]["VoucherDate"].ToString();
            textBox13.Value = "Bank Cheque No :" +DsClient.Tables[0].Rows[0]["ChequeNo"].ToString();

            textBox60.Value = DsClient.Tables[0].Rows[0]["VoucherDescription"].ToString();

            table3.DataSource = DsVoucher.Tables[0];
            object sumObject;
            if (DsVoucher.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sumObject = DsVoucher.Tables[0].Compute("Sum(TranAmount)", "");
                }
                catch
                {
                    sumObject = 0.0;
                }
                textBox34.Value = "Total Payment(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
                textBox35.Value = Convert.ToDecimal(sumObject).ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture);
            }
           
            if (DsBank.Tables[0].Rows.Count > 0)
            {
                table4.DataSource = DsBank;
                object sumObject1;
                textBox48.Value = " Total Paid Amount(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
                sumObject1 = DsBank.Tables[0].Compute("Sum(LocalAmount)", "");
                textBox49.Value = Convert.ToDecimal(sumObject1).ToString("0,#.00", System.Globalization.CultureInfo.InvariantCulture);
               
            }
            else
            {
                table4.Visible = false;
               
                textBox49.Visible = false;
            }
            
        }

        private void pageHeaderSection1_ItemDataBound(object sender, EventArgs e)
        {
         
        }

        private void pageHeaderSection1_ItemDataBinding(object sender, EventArgs e)
        {
           
        }
        

        
    }
}