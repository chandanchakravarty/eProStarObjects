namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for PremiumReport.
    /// </summary>
    internal partial class PremiumReportBIB : Telerik.Reporting.Report
    {
        public PremiumReportBIB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            // lstrtype, DebitNoteNo, FromDate, ToDate, ClientCode, ClientSource, status
        }

        public PremiumReportBIB(DataSet dsObj, string lstrtype, string DebitNoteNo, string PolicyFrom, string PolicyTo, string ClientCode, string ClientSource, string status, string CustomizedClient, string TransType)
        {
            InitializeComponent();

            table1.DataSource = dsObj.Tables[0];
            textBox120.Value = PolicyFrom + " to " + PolicyTo;
            textBox118.Value = (string.IsNullOrEmpty(ClientCode)) ? "ALL" : ClientCode;
            textBox122.Value = (string.IsNullOrEmpty(DebitNoteNo)) ? "ALL" : DebitNoteNo;
            textBox124.Value = "ALL";
            textBox126.Value = "Y";
            this.pictureBox1.Value = ReportsUtility.ClientLogoBW;
            this.pictureBox1.Visible = false;
            if (dsObj != null && dsObj.Tables.Count > 1 && dsObj.Tables[1].Rows.Count>0)
            {
              txtClientCompanyName.Value=  dsObj.Tables[1].Rows[0]["CompName"].ToString();
            }
            if (lstrtype == "C")
            {
                textBox119.Value = "Client";
            }
            if (lstrtype == "A")
            {
                textBox119.Value = "Introducer";
            }
            if (lstrtype == "I")
            {
                textBox119.Value = "Insurer";
            }
            if (CustomizedClient == "Howden")
            {
                textBox38.Value = "FC";
                textBox86.Value = "LC";
                if (TransType == "T")
                {
                    this.textBox136.Style.Visible = false;
                    this.textBox117.Style.Visible = false;
                    this.textBox133.Style.Visible = false;
                    this.textBox134.Style.Visible = false;
                    this.textBox135.Style.Visible = false;
                }
            }
            if (CustomizedClient == "HowdenSG")
            {
                if (TransType == "T")
                {
                    this.textBox136.Style.Visible = false;
                    this.textBox117.Style.Visible = false;
                    this.textBox133.Style.Visible = false;
                    this.textBox134.Style.Visible = false;
                    this.textBox135.Style.Visible = false;
                }
            }
        }

        public static string ConvertIntoNumeric(object number)
        {
            string str;
            if (Convert.ToDecimal(number) < 0)
            {
                str = Convert.ToDecimal(-1 * Convert.ToDecimal(number)).ToString("#,##0.00");
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