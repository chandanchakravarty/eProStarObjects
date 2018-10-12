namespace eProStarReports.Letters.BIB
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for EndorsementRptInsurer.
    /// </summary>
    public partial class EndorsementRptInsurer : Telerik.Reporting.Report
    {
        public EndorsementRptInsurer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public EndorsementRptInsurer(DataSet dsObj, string CaseRefNo, string PolicyId, string PolVersionId)
        {
            
            InitializeComponent();
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }

            textBox4.Value = dsObj.Tables[0].Rows[0]["InsurerName"].ToString().ToUpper();
            textBox8.Value = dsObj.Tables[0].Rows[0]["ATTN"].ToString().ToUpper();
            textBox10.Value = dsObj.Tables[0].Rows[0]["ClosingSlipNo"].ToString().ToUpper();
            textBox13.Value = dsObj.Tables[0].Rows[0]["ATTN"].ToString().ToUpper();
            textBox20.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString().ToUpper();
            textBox21.Value = dsObj.Tables[0].Rows[0]["PolicyNumber"].ToString().ToUpper();
            textBox22.Value = dsObj.Tables[0].Rows[0]["PrevPolicyNUmber"].ToString().ToUpper();
            
            textBox26.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["GrossPremium"]));
            textBox39.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["DiscountByInsurerAmount"]));
            textBox40.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["ClientDiscount"]));
            textBox41.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"]));
            textBox42.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["OtherCharges"]));
            textBox43.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["StampDuty"]));
            //textBox44.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Brokerage"]));
            textBox45.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerageRate"]))+ "%";
            textBox46.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Brokerage"]));
            textBox47.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGSTAmount1"]));
            textBox48.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["NetPayableToInsurer"]));

            
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