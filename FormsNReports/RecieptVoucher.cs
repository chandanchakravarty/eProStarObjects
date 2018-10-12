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
    /// Summary description for RecieptVoucher.
    /// </summary>
    public partial class RecieptVoucher : Telerik.Reporting.Report
    {
        public RecieptVoucher()
        {
            InitializeComponent();
        }


        public RecieptVoucher(DataSet DS)
        {
           
            InitializeComponent();
           // textBox1.Value = DS.Tables[0].Rows[0]["ClientName"].ToString();
            textBox2.Value = DS.Tables[0].Rows[0]["ClientName"].ToString();
            textBox10.Value = DS.Tables[0].Rows[0]["VoucherNo"].ToString();
            textBox11.Value = DS.Tables[0].Rows[0]["ClientAdd1"].ToString();
            textBox12.Value = DS.Tables[0].Rows[0]["ClientAdd2"].ToString();
            textBox15.Value = DS.Tables[0].Rows[0]["ClientAdd3"].ToString();
            textBox16.Value = DS.Tables[0].Rows[0]["ClientAdd4"].ToString();
            textBox18.Value = DS.Tables[0].Rows[0]["ClientCode"].ToString();
            textBox14.Value = DS.Tables[0].Rows[0]["VoucherDate"].ToString();
            object sumObject;
            sumObject = DS.Tables[0].Compute("Sum(TranAmount)", "");
            textBox23.Value = sumObject.ToString();
            if (DS.Tables[0].Columns.Contains("ChequeNo"))
            {
                textBox33.Value = DS.Tables[0].Rows[0]["ChequeNo"].ToString();
                textBox31.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
                textBox32.Value = DS.Tables[0].Rows[0]["CurrencyCode"].ToString();
                textBox34.Value = DS.Tables[0].Rows[0]["ExchangeRate"].ToString();
                textBox35.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
                //object SumAmount;
                //SumAmount = DS.Tables[0].Compute("Sum(Amount)", "");
                //textBox38.Value = SumAmount.ToString();
                textBox38.Value = DS.Tables[0].Rows[0]["Amount"].ToString();
            }
            else
            {
                textBox24.Visible = false;
                textBox33.Visible = false;
                textBox31.Visible = false;
                textBox32.Visible = false;
                textBox34.Visible = false;
                textBox35.Visible = false;
                textBox38.Visible = false;
                textBox25.Visible = false;
                textBox27.Visible = false;
                textBox28.Visible = false;
                textBox29.Visible = false;
                textBox30.Visible = false;
                textBox38.Visible = false;
                textBox36.Visible = false;
                textBox37.Visible = false;
            }
            table1.DataSource = DS.Tables[0];
           
           
        }
    }
}