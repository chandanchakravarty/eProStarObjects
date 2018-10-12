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
    /// Summary description for TaxCreditNoteRpt.
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

        public TaxCreditNoteRpt(DataSet dsObj, string strClientCode, DataTable _taxType= null)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            textBox1.Value = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "CREDIT NOTE" : "TAX CREDIT NOTE";
            textBox21.Value = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "Total Brokerage" : "Total Payable Include GST";
            textBox8.Value = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "Closing Slip No" : "Addendum No";
            if (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST")
            {
                textBox2.Visible = false;
                txtGstNo.Visible = false;
                textBox14.Visible = false;
                textBox16.Visible = false;
                textBox24.Visible = false;
                txtTotalBrokerage.Visible = false;

                textBox13.Visible = false;
                textBox15.Visible = false;
                textBox17.Visible = false;
                txtGSTAmount.Visible = false;

                textBox18.Visible = false;
                txtSecGstNo.Visible = false;
            }
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
                    txtInvoiceNo.Value = ": "+dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                    txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    txtPremium.Value =String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["Premium"]));
                    txtDateOfIssue.Value = ": " + dsObj.Tables[0].Rows[0]["DateOfIssue"].ToString();


                    txtPolicyNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
                    txtBrokeragePer.Value = dsObj.Tables[0].Rows[0]["BrokerageRate"].ToString();
                    txtBrokerageRM.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["Brokerage"]));
                    txtTotalBrokerage.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["Brokerage"]));
                    txtGSTAmount.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["BrokerGSTAmount"]));
                    txtTotalPayable.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalPayable"]));                   
                    txtRemarks.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                    if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value)
                        textBox25.Value = "Brokerage Earned" + '(' + Convert.ToString(dsObj.Tables[0].Rows[0]["SumInsuredCurrency"]) + ')';
                    else
                        textBox25.Value = "Brokerage Earned";
                    if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                    {
                        txtPOI.Value = "";
                    }
                    else
                    {
                        txtPOI.Value = ": " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() + " To " + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    }

                                        
                }

                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtClientName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    txtClientAdd1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString() != "")
                        txtClientAdd1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString() != "")
                        txtClientAdd1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString() != "")
                        txtClientAdd1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    //txtClientAdd2.Value = dsObj.Tables[1].Rows[0]["dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString()ClientAddress2"].ToString();
                    //txtClientAdd3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    //txtClientAdd4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    txtClientAdd5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                    if (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST"
                        && _taxType.Rows[0]["PolicyId"] != null && Convert.ToInt16(_taxType.Rows[0]["PolicyId"].ToString()) == 0
                        && _taxType.Rows[0]["FeeType"] != null && _taxType.Rows[0]["FeeType"].ToString() == "I")
                    {
                        txtClientName1.Value = dsObj.Tables[2].Rows[0]["UnderwriterName"].ToString();
                        txtClientAddress1.Value = dsObj.Tables[2].Rows[0]["UnderwriterAddress1"].ToString();
                        if (dsObj.Tables[2].Rows[0]["UnderwriterAddress2"].ToString() != "")
                            txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress2"].ToString();
                        if (dsObj.Tables[2].Rows[0]["UnderwriterAddress3"].ToString() != "")
                            txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress3"].ToString();
                        if (dsObj.Tables[2].Rows[0]["UnderwriterAddress4"].ToString() != "")
                            txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress4"].ToString();
                       txtClientAddress5.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterPostalCode"]) + " " + Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterProvinceName"]) + " " + Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterTerritoryName"]);
                    }
                    else
                    {
                        if (dsObj.Tables[1].Columns.Contains("CoInsurance") && dsObj.Tables[1].Columns.Contains("BillingToleadInsurer"))
                        {
                            if (dsObj.Tables[1].Rows[0]["CoInsurance"].ToString() == "Y" && dsObj.Tables[1].Rows[0]["BillingToleadInsurer"].ToString() == "Y")
                            {
                                txtClientName1.Value = dsObj.Tables[1].Rows[0]["UnderwriterName"].ToString();
                                txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["UnderwriterAddress1"].ToString();
                                if (dsObj.Tables[1].Rows[0]["UnderwriterAddress2"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["UnderwriterAddress2"].ToString();
                                if (dsObj.Tables[1].Rows[0]["UnderwriterAddress3"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["UnderwriterAddress3"].ToString();
                                if (dsObj.Tables[1].Rows[0]["UnderwriterAddress4"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["UnderwriterAddress4"].ToString();
                                //txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["UnderwriterAddress2"].ToString();
                                //txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["UnderwriterAddress3"].ToString();
                                //txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["UnderwriterAddress4"].ToString();
                                txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["UnderwriterPostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["UnderwriterProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["UnderwriterTerritoryName"]);

                            }
                            else
                            {

                                txtClientName1.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                                txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                                if (dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                                if (dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                                if (dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString() != "")
                                    txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                                //txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                                //txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                                //txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                                txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                            }
                        }

                        else
                        {
                            txtClientName1.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                            txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["UnderwriterAddress1"].ToString();
                            if (dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString() != "")
                                txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                            if (dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString() != "")
                                txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                            if (dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString() != "")
                                txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                            //txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                            //txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                            //txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                            txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                        }
                    }
                    txtSecGstNo.Value = ": " + dsObj.Tables[1].Rows[0]["ClientGSTNo"].ToString();
                }
                //Values from Table 1
                if (dsObj.Tables[2].Rows.Count > 0)
                {
                    /*Below Code changes for redmine 27586*/
                    //txtCompanyName.Value = dsObj.Tables[2].Rows[0]["TopCompanyName"].ToString().ToUpper();
                    //txtCompAddress1.Value = dsObj.Tables[2].Rows[0]["CompanyAdd1"].ToString();
                    //txtCompAddress2.Value = dsObj.Tables[2].Rows[0]["CompanyAdd2"].ToString();
                    //txtCompAddress3.Value = dsObj.Tables[2].Rows[0]["CompanyAdd3"].ToString();
                    //txtCompAddress4.Value = dsObj.Tables[2].Rows[0]["CompanyAdd4"].ToString();
                    //txtGstNo.Value = ": " + dsObj.Tables[2].Rows[0]["GSTCode"].ToString();

                    txtCompanyName.Value = dsObj.Tables[2].Rows[0]["UnderwriterName"].ToString().ToUpper();
                    if (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST"
                        && _taxType.Rows[0]["PolicyId"] != null && Convert.ToInt16(_taxType.Rows[0]["PolicyId"].ToString()) == 0
                        && _taxType.Rows[0]["FeeType"] != null && _taxType.Rows[0]["FeeType"].ToString() == "I")
                    {
                        txtCompAddress1.Value = txtCompAddress1.Value + Environment.NewLine + dsObj.Tables[3].Rows[0]["CompanyAdd1"].ToString();
                        txtCompAddress1.Value = txtCompAddress1.Value + Environment.NewLine + dsObj.Tables[3].Rows[0]["CompanyAdd2"].ToString();
                        txtCompAddress1.Value = txtCompAddress1.Value + Environment.NewLine + dsObj.Tables[3].Rows[0]["CompanyAdd3"].ToString();
                        txtCompAddress5.Value = dsObj.Tables[3].Rows[0]["CompanyAdd4"].ToString();
                    }
                    txtCompAddress1.Value = dsObj.Tables[2].Rows[0]["UnderwriterAddress1"].ToString();
                    if (dsObj.Tables[2].Rows[0]["UnderwriterAddress2"].ToString() != "")
                        txtCompAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress2"].ToString();
                    if (dsObj.Tables[2].Rows[0]["UnderwriterAddress3"].ToString() != "")
                        txtCompAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress3"].ToString();
                    if (dsObj.Tables[2].Rows[0]["UnderwriterAddress4"].ToString() != "")
                        txtCompAddress1.Value += Environment.NewLine + dsObj.Tables[2].Rows[0]["UnderwriterAddress4"].ToString();
                    //txtCompAddress2.Value = dsObj.Tables[2].Rows[0]["UnderwriterAddress2"].ToString();
                    //txtCompAddress3.Value = dsObj.Tables[2].Rows[0]["UnderwriterAddress3"].ToString();
                    //txtCompAddress4.Value = dsObj.Tables[2].Rows[0]["UnderwriterAddress4"].ToString();
                    txtCompAddress5.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterPostalCode"]) + " " + Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterProvinceName"]) + " " + Convert.ToString(dsObj.Tables[2].Rows[0]["UnderwriterTerritoryName"]);

                    txtGstNo.Value = ": " + dsObj.Tables[2].Rows[0]["UnderwriterGSTNo"].ToString();
                   
                }
                if (dsObj.Tables[3].Rows.Count > 0)
                {
                    txtCompanyNameFooter.Value = dsObj.Tables[3].Rows[0]["TopCompanyName"].ToString().ToUpper();
                    //txtCompanyAddFooter.Value = dsObj.Tables[3].Rows[0]["TopCompanyAddress"].ToString();
                    txtCompanyAddFooter.Value = dsObj.Tables[3].Rows[0]["CompanyAdd1"].ToString() + " " + dsObj.Tables[3].Rows[0]["CompanyAdd2"].ToString() + " " + dsObj.Tables[3].Rows[0]["CompanyAdd3"].ToString() + Environment.NewLine + dsObj.Tables[3].Rows[0]["CompanyAdd4"].ToString();

                }
            }
        }      
    }
}