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
    /// Summary description for DiretCommissionOutgoCreditNote.
    /// </summary>
    public partial class DiretCommissionOutgoCreditNote : Telerik.Reporting.Report
    {
        public DiretCommissionOutgoCreditNote()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DiretCommissionOutgoCreditNote(DataSet dsObj, string strAgentCode, string strOriDup)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            // added for #23256 --begin
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            if (dsObj.Tables.Count > 0)
            {
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtOriginal.Value = dsObj.Tables[0].Rows[0]["OriginalDuplicate"].ToString();
                    txtIntroducerName.Value = dsObj.Tables[0].Rows[0]["IntroducerName"].ToString();
                    txtIntroducerAddress1.Value = dsObj.Tables[0].Rows[0]["IntroducerAddress1"].ToString();
                    txtIntroducerAddress2.Value = dsObj.Tables[0].Rows[0]["IntroducerAddress2"].ToString();
                    txtIntroducerAddress3.Value = dsObj.Tables[0].Rows[0]["IntroducerAddress3"].ToString();
                    txtIntroducerAddress4.Value = dsObj.Tables[0].Rows[0]["IntroducerAddress4"].ToString();
                    txtIntroducerAddress5.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[0]["TerritoryName"]);

                    txtInvoiceNo.Value = ": "+dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                    txtInvoiceDate.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
                    txtDatePrinted.Value = ": " + dsObj.Tables[0].Rows[0]["PrintDate"].ToString();
                    txtIntroducerMainCont.Value = ": " + dsObj.Tables[0].Rows[0]["ContactPerson"].ToString();
                    txtIntroducerCode.Value = ": " + dsObj.Tables[0].Rows[0]["IntroducerCode"].ToString();
                    txtAccNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    txtSubClass.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                    txtPOIFrom.Value = ": " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                    txtPOITo.Value = ": " + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    txtEffectiveFrom.Value = ": " + dsObj.Tables[0].Rows[0]["EffectiveDateFrom"].ToString();
                    txtCrossReference.Value = ": " + dsObj.Tables[0].Rows[0]["PreviousPlacementNo"].ToString();
                    txtRemarks.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                    txtServiceExecutive.Value = dsObj.Tables[0].Rows[0]["ServiceExecutive"].ToString();

                    txtCommission.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalDue"]));  //Commission
                    txtTotalDue.Value =String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalDue"])); 
                }
               
                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtCompanyNameFooter.Value =Convert.ToString(dsObj.Tables[1].Rows[0]["TopCompanyName"]).ToUpper();
                    txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                    txtCompAddress.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                }
            }
         }
    }
}