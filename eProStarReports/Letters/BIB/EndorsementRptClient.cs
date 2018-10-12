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
    /// Summary description for EndorsementRptClient.
    /// </summary>
    public partial class EndorsementRptClient : Telerik.Reporting.Report
    {
        public EndorsementRptClient()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public EndorsementRptClient(DataSet dsObj, string CaseRefNo, string PolicyId, string PolVersionId)
        {

            InitializeComponent();

            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }

            textBox16.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString().ToUpper();
            textBox17.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
            textBox18.Value = dsObj.Tables[0].Rows[0]["CorrAddress1"].ToString();
            textBox70.Value = dsObj.Tables[0].Rows[0]["CorreAddress2"].ToString();
            textBox71.Value = dsObj.Tables[0].Rows[0]["CorreAddress3"].ToString();
            textBox72.Value = dsObj.Tables[0].Rows[0]["CorrAddress4"].ToString();
            textBox19.Value = dsObj.Tables[0].Rows[0]["Attn"].ToString();
            textBox21.Value = dsObj.Tables[0].Rows[0]["Attn"].ToString();
            textBox55.Value = dsObj.Tables[0].Rows[0]["Insured"].ToString();
            textBox56.Value = dsObj.Tables[0].Rows[0]["InsurerName"].ToString();
            textBox57.Value = dsObj.Tables[0].Rows[0]["ClosingSlipNo"].ToString();
            textBox59.Value = dsObj.Tables[0].Rows[0]["PolicyNumber"].ToString();
            textBox60.Value = dsObj.Tables[0].Rows[0]["PrevPolicyNUmber"].ToString();
            textBox61.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            textBox62.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
            textBox74.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            textBox64.Value = dsObj.Tables[0].Rows[0]["EndorsementEffdate"].ToString();

            textBox48.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
            textBox68.Value = dsObj.Tables[0].Rows[0]["TotalPremium"].ToString();
        }
    }
}