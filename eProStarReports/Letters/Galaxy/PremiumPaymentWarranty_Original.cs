namespace eProStarReports.Letters.Galaxy
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for PremiumPaymentWarranty_Original.
    /// </summary>
    public partial class PremiumPaymentWarranty_Original : Telerik.Reporting.Report
    {
        public PremiumPaymentWarranty_Original()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PremiumPaymentWarranty_Original(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, string Username, string Blank1,string printlogo, string strDebitNoteNo, string Blank)
        {
            InitializeComponent();
            textBox2.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();
            textBox7.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString().ToUpper();
            textBox10.Value = dsObj.Tables[1].Rows[0]["CompanyAdd2"].ToString().ToUpper();
            textBox14.Value = dsObj.Tables[1].Rows[0]["TelNo"].ToString().ToUpper();
            textBox17.Value = dsObj.Tables[1].Rows[0]["FaxNo"].ToString().ToUpper();
            textBox4.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString().ToUpper();
            textBox8.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString().ToUpper();

            textBox5.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString().ToUpper();
            textBox9.Value = dsObj.Tables[0].Rows[0]["BillingAddress1"].ToString().ToUpper();
            textBox11.Value = dsObj.Tables[0].Rows[0]["BillingAddress2"].ToString().ToUpper();
            textBox95.Value = dsObj.Tables[0].Rows[0]["BillingAddressLast"].ToString().ToUpper();

            textBox26.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString().ToUpper();
            textBox29.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString().ToUpper();
            textBox32.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString().ToUpper();


            textBox39.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString().ToUpper();
            textBox43.Value = dsObj.Tables[0].Rows[0]["policyno"].ToString().ToUpper();
            textBox46.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString().ToUpper();
            textBox53.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString().ToUpper();
            textBox57.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString().ToUpper();

            textBox49.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString().ToUpper();

            textBox70.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"]));
            textBox74.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"]));
            textBox78.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"]));

           
            Decimal dbtemp1 = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"]);
            textBox75.Value = ConvertIntoNumeric(dbtemp1 + dbtemp1 + dbtemp1);

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