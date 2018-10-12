namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for RptEBBenefitLimitSummary.
    /// </summary>
    public partial class RptEBBenefitLimitSummary : Telerik.Reporting.Report
    {
        public RptEBBenefitLimitSummary()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptEBBenefitLimitSummary(DataSet dsEBBenefitSummary, DataSet dsPolicyInfo, DataSet dsCoverNote)
        {
            
            InitializeComponent();
            
            txtSubClass.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["SubClassName"].ToString();
            txtClientname.Value  = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["ClientName"].ToString();
            if (dsCoverNote != null)
            {
                if (dsCoverNote.Tables.Count > 0 && dsCoverNote.Tables[0].Rows.Count > 0)
                {
                    txtCoverNote.Value = dsCoverNote.Tables["CoverNoteList"].Rows[0]["CoverNoteNo"].ToString();
                    txtQuotationno.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["SourcePolicyNo"].ToString();
                }
                else
                {
                    txtQuotationno.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["PolicyNo"].ToString();
                }
            }
            else
            {
                txtQuotationno.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["PolicyNo"].ToString();
            }
            txtPoiFromdate.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["POIFromDate1"].ToString();
            txtPOItodate.Value = dsPolicyInfo.Tables["Pol_PolicyMaster"].Rows[0]["POIToDate1"].ToString();

            CtabBenefitLimit.DataSource = dsEBBenefitSummary;

            
        }
    }
}