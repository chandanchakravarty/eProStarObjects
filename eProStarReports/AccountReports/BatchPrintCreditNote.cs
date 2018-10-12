namespace eProStarReports.AccountReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataAccessLayer;
    using BusinessObjectLayer.BrokingModule.BrokingSystem;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

    /// <summary>
    /// Summary description for BatchPrintCreditNote.
    /// </summary>
    public partial class BatchPrintCreditNote : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];

        DataSet DsCompDtl = null;
        DataSet DsParamD = null;
        DataSet DsreportDetails = null;

        public BatchPrintCreditNote()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BatchPrintCreditNote(string Param1, string Param2)
        {
            InitializeComponent();
            DsCompDtl = GetCompanyDetails();
            string _client = String.Empty;
            BusinessAccessLayer.Common.clsCommon _cmn = new BusinessAccessLayer.Common.clsCommon();
            _client = _cmn.GetClient();

            if (DsCompDtl.Tables[0].Rows.Count > 0)
            {
                textBox4.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
                textBox9.Value = DsCompDtl.Tables[0].Rows[0]["Add1"].ToString() + " " + DsCompDtl.Tables[0].Rows[0]["Add2"].ToString() + " " + DsCompDtl.Tables[0].Rows[0]["Add3"].ToString();
                textBox12.Value = DsCompDtl.Tables[0].Rows[0]["Add4"].ToString();
                textBox15.Value = DsCompDtl.Tables[0].Rows[0]["Add5"].ToString();
                textBox18.Value = DsCompDtl.Tables[0].Rows[0]["Add7"].ToString();
                textBox19.Value = "Please make cheque payable to " + DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
            }

            DsreportDetails = GetBatchPrintForDebitNote(Param1, Param2);

            if (_client.ToUpper() == "STARACCLAIM")
            {
                textBox5.Value = "CREDIT NOTE";
            }

            if (DsreportDetails.Tables[0].Rows.Count > 0)
            {
                textBox29.Value = DsreportDetails.Tables[0].Rows[0]["CusM_Name"].ToString();
                if (string.IsNullOrEmpty(textBox29.Value))
                {
                    textBox29.Visible = false;
                }


                textBox26.Value = DsreportDetails.Tables[0].Rows[0]["CusM_Address1"].ToString();

                if (string.IsNullOrEmpty(textBox26.Value))
                {
                    textBox26.Visible = false;
                }

                textBox24.Value = DsreportDetails.Tables[0].Rows[0]["CusM_Address2"].ToString();

                if (string.IsNullOrEmpty(textBox24.Value))
                {
                    textBox24.Visible = false;
                }
                textBox21.Value = DsreportDetails.Tables[0].Rows[0]["CusM_Address3"].ToString();

                if (string.IsNullOrEmpty(textBox21.Value))
                {
                    textBox21.Visible = false;
                }

                textBox25.Value = DsreportDetails.Tables[0].Rows[0]["CusM_Address4"].ToString();

                if (string.IsNullOrEmpty(textBox25.Value))
                {
                    textBox25.Visible = false;
                }

                textBox27.Value = DsreportDetails.Tables[0].Rows[0]["DrCrNo"].ToString();
                textBox22.Value = DsreportDetails.Tables[0].Rows[0]["DrCrDate"].ToString();
                textBox6.Value = DsreportDetails.Tables[0].Rows[0]["CusM_ID"].ToString();

                if (_client.ToUpper() == "STARACCLAIM")
                {
                    table2.Visible = true;
                    table3.Visible = false;
                    textBox34.Value = DsreportDetails.Tables[0].Rows[0]["DrCrDescription"].ToString();
                    textBox35.Value = ConvertIntoNumeric(Convert.ToDecimal(DsreportDetails.Tables[0].Rows[0]["Amount"].ToString()));
                    textBox31.Value = ConvertIntoNumeric(Convert.ToDecimal(DsreportDetails.Tables[0].Rows[0]["LocalAmount"].ToString()));
                    textBox47.Value = ConvertIntoNumeric(Convert.ToDecimal(DsreportDetails.Tables[0].Rows[0]["GST"].ToString())); ;
                }
                else
                {
                    table3.Visible = true;
                    table2.Visible = false;
                    textBox40.Value = DsreportDetails.Tables[0].Rows[0]["DrCrDescription"].ToString();
                    textBox37.Value = ConvertIntoNumeric(Convert.ToDecimal(DsreportDetails.Tables[0].Rows[0]["LocalAmount"].ToString()));
                    textBox30.Value = ConvertIntoNumeric(Convert.ToDecimal(DsreportDetails.Tables[0].Rows[0]["LocalAmount"].ToString())); ;
                }

            }
        }

        private DataSet GetBatchPrintForDebitNote(string Param1, string Param2)
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetVoucherMain  '" + Param1 + "','" + Param2 + "'");
        }

        private DataSet GetCompanyDetails()
        {
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
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