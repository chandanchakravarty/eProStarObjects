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
    /// Summary description for Report1.
    /// </summary>
    public partial class DebitNoteRptGeneral : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneral()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRptGeneral(DataSet dsObj, string strClientCode,string strOriDup, DataTable _taxType =null)
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
            if (_taxType!= null && _taxType.Rows.Count>0 && _taxType.Rows[0]["TaxType"].ToString() == "SST")
            {
               textBox30.Value = textBox30.Value.Replace("Addendum", "Closing Slip");
               textBox38.Value = textBox38.Value.Replace("Addendum", "Closing Slip");
            }
            if (dsObj.Tables.Count > 0)
            {
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    if (dsObj.Tables[0].Rows[0]["DebitNoteNo"] != DBNull.Value) txtInvoiceNo.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value) txtInvoiceDate.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value) txtClientCode.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value) txtSubClass.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value) txtPolicyNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value) txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["PreviouPolicyNo"] != DBNull.Value) txtPrevPolicyNo.Value = ": " + dsObj.Tables[0].Rows[0]["PreviouPolicyNo"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["DebitNoteType"] != DBNull.Value) txtTransType.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNoteType"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value) txtSumInsuredCurrency.Value = ": " + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["SumInsuredAmount"] != DBNull.Value) txtSumInsured.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["SumInsuredAmount"]));       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["UnderWriterName"] != DBNull.Value) txtInsurerName.Value = ": " + dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["EffectiveDateFrom"] != DBNull.Value) txtEffFromDate.Value = ": " + dsObj.Tables[0].Rows[0]["EffectiveDateFrom"].ToString();       // added for #23642
                    //txtPremium.Value = string.Format("{0:#,###0}", 123456789.00); // 123,456,789 String.Format("{0:n}",dsObj.Tables[0].Rows[0]["Premium"].ToString());
                    if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value)
                        textBox18.Value = "Amount" + "(" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ")";
                    else
                        textBox18.Value = "Amount";
                    DataTable dtPrem= new DataTable();
                    dtPrem.Columns.Add("Key",typeof(String));
                    dtPrem.Columns.Add("Value",typeof(String));
                    DataRow drp=null;
                    
                     if (dsObj.Tables[0].Columns.Contains("GrossPremium") && dsObj.Tables[0].Rows[0]["GrossPremium"] != DBNull.Value)
                                        {
                                         drp= dtPrem.NewRow();
                                         drp["Key"]="GROSS PREMIUM";
                                         drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["GrossPremium"]));      
                                         dtPrem.Rows.Add(drp);
                                        }
                       if (dsObj.Tables[0].Columns.Contains("NCDAmount") && dsObj.Tables[0].Rows[0]["NCDAmount"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["NCDAmount"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="NCD";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["NCDAmount"]));      
                                         dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("PolicyCharge") && dsObj.Tables[0].Rows[0]["PolicyCharge"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["PolicyCharge"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="POLICY CHARGE";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["PolicyCharge"]));      
                                         dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("LodingByInsurerAmount") && dsObj.Tables[0].Rows[0]["LodingByInsurerAmount"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["LodingByInsurerAmount"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="LOADING BY INSURER";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["LodingByInsurerAmount"]));      
                                         dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("DiscountByInsurerAmount") && dsObj.Tables[0].Rows[0]["DiscountByInsurerAmount"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["DiscountByInsurerAmount"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="DISCOUNT BY INSURER";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["DiscountByInsurerAmount"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                     if (dsObj.Tables[0].Columns.Contains("InsurerGSTAmount") && dsObj.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"] = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "INSURER SERVICE TAX" : "INSURER GST";//_taxType.ToUpper() == "SST"? "INSURER SERVICE TAX" :  "INSURER GST";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("ClientDiscount") && dsObj.Tables[0].Rows[0]["ClientDiscount"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["ClientDiscount"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="CLIENT DISCOUNT";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ClientDiscount"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("ServiceFee") && dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFee"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="SERVICE FEE";
                                          // +dsObj.Tables[0].Rows[0]["ServiceFeeType"];
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFee"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                     if (dsObj.Tables[0].Columns.Contains("ServiceFeeGSTAmount") && dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"] = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "SERVICE TAX ON SERVICE FEE" : "GST ON SERVICE";//_taxType.ToUpper() == "SST"?  "SERVICE TAX ON SERVICE FEE":"GST ON SERVICE";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("OtherCharges") && dsObj.Tables[0].Rows[0]["OtherCharges"] != DBNull.Value &&  Convert.ToDouble(dsObj.Tables[0].Rows[0]["OtherCharges"])>0)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="OTHER CHARGES";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["OtherCharges"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                    if (dsObj.Tables[0].Columns.Contains("ClientStampDuty") && dsObj.Tables[0].Rows[0]["ClientStampDuty"] != DBNull.Value)
                                        {
                                          drp= dtPrem.NewRow();
                                          drp["Key"]="STAMP DUTY";
                                          drp["Value"]= String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ClientStampDuty"]));      
                                          dtPrem.Rows.Add(drp);
                                        }
                    tblPremium.DataSource=dtPrem;


                    //if (dsObj.Tables[0].Columns.Contains("Premium"))
                    //{
                    //    if (dsObj.Tables[0].Rows[0]["Premium"] != DBNull.Value) txtPremium.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["Premium"]));       // added for #23642
                    //}          
                    if (dsObj.Tables[0].Columns.Contains("ServiceFee"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value) txtServiceTax.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFee"]));       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("ServiceFee"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value) txtServiceTax.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFee"]));       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("StampDuty"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["StampDuty"] != DBNull.Value) txtStampDuty.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["StampDuty"]));       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("Discount"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["Discount"] != DBNull.Value) txtDiscount.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["Discount"]));
                        //lblDiscount.Value = "CLIENT DISCOUNT";                       
                    }
                    if (dsObj.Tables[0].Columns.Contains("TotalDue"))
                    {
                        if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value) txtAmountDue.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalDue"]));       // added for #23642
                    }
                    txtRemarks.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                    //txtPremium.Value = (txtPremium.Value).ToString("");
                    if (dsObj.Tables[0].Columns.Contains("ServiceTax"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["ServiceTax"] != DBNull.Value) txtServiceFeeGST.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceTax"]));       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("OtherCharges"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["OtherCharges"] != DBNull.Value) txtOtherCharge.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["OtherCharges"]));       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("ServiceFeeType"))
                    {
                       // if (dsObj.Tables[0].Rows[0]["ServiceFeeType"] != DBNull.Value) lblServiceFeeType.Value = (dsObj.Tables[0].Rows[0]["ServiceFeeType"].ToString().ToUpper());       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("ServiceFeeType"))
                    {
                        //if (dsObj.Tables[0].Rows[0]["ServiceFeeType"] != DBNull.Value) lblServiceFeeGSTType.Value = (dsObj.Tables[0].Rows[0]["ServiceFeeType"].ToString().ToUpper()) + " " + "GST";       // added for #23642
                    }
                    if (dsObj.Tables[0].Columns.Contains("OtherChargesFeeType"))
                    {
                        //if (dsObj.Tables[0].Rows[0]["OtherChargesFeeType"] != DBNull.Value) lblOtherChargeFeeType.Value = dsObj.Tables[0].Rows[0]["OtherChargesFeeType"].ToString().ToUpper();       // added for #23642
                    }

                    //if (txtServiceTax.Value == "0.00" && txtOtherCharge.Value == "0.00")
                    //{
                    //   // txtServiceTax.Visible = txtServiceFeeGST.Visible = txtOtherCharge.Visible = lblServiceFeeType.Visible = lblServiceFeeGSTType.Visible = lblOtherChargeFeeType.Visible = false;
                    //}


                    //if (lblServiceFeeType.Value == "")
                    //{
                    //    lblServiceFeeType.Value = "SERVICE FEE";
                    //    if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value) txtServiceTax.Value = String.Format("{0:n}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["ServiceFee"]));  //#19719
                    //}
                    //if (lblOtherChargeFeeType.Value == "")
                    //{
                    //    txtOtherCharge.Visible = lblOtherChargeFeeType.Visible = false;
                    //}
                    txtPOIFrom.Value = String.Empty;
                    if (dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() == "") // added from Redmine #37141
                    {
                        txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                    }
                    if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                    {
                        txtPOITo.Visible = false;
                    }
                    else
                    {
                        txtPOIFrom.Value = ": " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                        txtPOITo.Value = ": " + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    }

                    txtClientMainContactPerson.Value = ": " + dsObj.Tables[0].Rows[0]["ContactPerson"].ToString();
                    txtDatePrinted.Value = ": " + dsObj.Tables[0].Rows[0]["PrintDate"].ToString();
                    
                    txtServiceExecutive.Value = ": " + dsObj.Tables[0].Rows[0]["ServiceExecute"].ToString();
                    txtOriDup.Value = dsObj.Tables[0].Rows[0]["OriginalDuplicate"].ToString();
                    txtEndorsementNo.Value = ": " + dsObj.Tables[0].Rows[0]["EndorsementNo"].ToString();


                    if (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1")
                        txtImpNotice7.Value = "It is fundamental and absolute special condition of this contract of insurance that the premium due must be paid and received by the" +
                                   " insurer within sixty (60) days from the inception date of this policy/endorsement/renewal certificate." +
                                   " To avoid breaching the Premium Warranty we strongly recommend that the premium as indicated in this invoice be first paid. Any" +
                                   " subsequent changes can be (are to be made) reconciled by way of adjusment invoices.";
                    else if (dsObj.Tables[0].Rows[0]["CashBeforeCover"].ToString() == "1")
                        txtImpNotice7.Value = "CASH-BEFORE-COVER";
                    else
                    {
                        txt7.Value = "";
                        txtImpNotice7.Value = "";
                    }
                }

                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtClientName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString() != "")
                        txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString() != "")
                        txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    if (dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString() != "")
                        txtClientAddress1.Value += Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    //txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    //txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                   // txtClient.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                }

                //Values from Table 2
                if (dsObj.Tables[2].Rows.Count > 0)
                {
                    txtImpNotice6.Value="6. All Cheques should be crossed and made payable to \"" +dsObj.Tables[2].Rows[0]["TopCompanyName"].ToString().ToUpper()+"\"";
                    txtCompanyName.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                    //txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
                    txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["CompanyAdd1"].ToString() + " " + dsObj.Tables[2].Rows[0]["CompanyAdd2"].ToString() + " " + dsObj.Tables[2].Rows[0]["CompanyAdd3"].ToString() + Environment.NewLine + dsObj.Tables[2].Rows[0]["CompanyAdd4"].ToString();
                }               
               
            }

        }
    }
}