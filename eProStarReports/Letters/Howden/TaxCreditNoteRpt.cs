namespace eProStarReports.Letters.Howden
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class TaxCreditNoteRpt : Telerik.Reporting.Report
    {
        public TaxCreditNoteRpt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public TaxCreditNoteRpt(DataSet dsObj, string strClientCode)
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

            //txtTextDN.Value = "DEBIT NOTE :";

            if (dsObj.Tables.Count > 0)
            {
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    if (dsObj.Tables[0].Rows[0]["DebitNoteNo"] != DBNull.Value)
                        txtCoveNoteNo.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value)
                        txtCoverNoteDate.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value)
                        txtClientCode.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                        txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["Servicer"] != DBNull.Value)
                        txtServicer.Value = ": " + dsObj.Tables[0].Rows[0]["Servicer"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["BillingDueDate"] != DBNull.Value)
                        txtDueDate.Value = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();       // added for #23642


                    //PolicyDetails
                    if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value)
                        txtClassofInsurance.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value)
                        txtEndtNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                    {
                        txtPOIFrom.Visible = false;
                        txtPOITo.Visible = false;
                    }
                    else
                    {
                        txtPOIFrom.Value = ": " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                        txtPOITo.Value = "" + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    }
                    if (dsObj.Tables[0].Rows[0]["UnderWriterName"] != DBNull.Value)
                        txtInsurerName.Value = ": " + dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["EndtInsurerNo"] != DBNull.Value)
                        txtInsurerEndtNo.Value = ": " + dsObj.Tables[0].Rows[0]["EndtInsurerNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["EndtEffectivetDate"] != DBNull.Value)
                        txtEndtEffDate.Value = ": " + dsObj.Tables[0].Rows[0]["EndtEffectivetDate"].ToString();       // added for #23642


                    if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value)
                        txtCurrency.Value = ": <" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value)
                        txtAmount.Value = ": " + dsObj.Tables[0].Rows[0]["TotalDue"].ToString();       // added for #23642

                    if (dsObj.Tables[0].Rows[0]["CoverageToInclude"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "EB" || dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "V"))
                        pnlGeneral.Visible = false;
                    if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "LIF"))
                        pnlLife.Visible = true;
                    if (dsObj.Tables[0].Rows[0]["PremWarranty"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                        pnlNonLife.Visible = true;

                    if (pnlLife.Visible == false && pnlNonLife.Visible == true)
                    {
                        pnlNonLife.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Cm),
                                                new Telerik.Reporting.Drawing.Unit(16.6, Telerik.Reporting.Drawing.UnitType.Cm));

                    }
                }
                table1.Visible = false;
                if (dsObj != null && dsObj.Tables[4].Rows.Count > 3)
                {
                    table1.DataSource = dsObj.Tables[4];
                    table1.Visible = true;
                    txtInsuredName.Value = "PLEASE SEE ATTACHED";
                }
                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtClientName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                    txtInsuredName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                }

                //Values from Table 2
                if (dsObj.Tables[3].Rows.Count > 0)
                {
                    //txtImpNotice6.Value="6. All Cheques should be crossed and made payable to \"" +dsObj.Tables[2].Rows[0]["TopCompanyName"].ToString()+"\"";
                    txtCompanyName.Value = Convert.ToString(dsObj.Tables[3].Rows[0]["TopCompanyName"]).ToUpper();
                    txtCompanyAddress.Value = dsObj.Tables[3].Rows[0]["TopCompanyAddress"].ToString();
                }




            }

        }
    }
}