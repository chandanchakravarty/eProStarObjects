namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    //using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    /// <summary>
    /// Summary description for DebitNoteRptBillingInstallment.
    /// </summary>
    internal partial class DebitNoteKIBFeeBillingInstallment : Telerik.Reporting.Report
    {
        public int Rows = 0;
        public int Rows1 = 0;
        DataTable dtCopyViewunderwriter;
        public string insuredname = "";
        public string checkisleader = "";
        public int intnumber = 0;
        public DebitNoteKIBFeeBillingInstallment()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //txtpolicyvalue
        }
         public static string convertIntoNumeric(decimal number)
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

            return str;
        }


        public DebitNoteKIBFeeBillingInstallment(DataSet dsObj, string strClientCode, string strCheckedInstl, String clientFlag)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            textBox66.Visible = false;
            textBox67.Visible = false;
            if (dsObj.Tables[6].Rows.Count > 0)
            {
                if ((dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC") || Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalPremAmount"]) < 0)
                {

                    decimal totaldue = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                    if (totaldue >= 0)
                    {
                        txtvoice.Value = "TAX INVOICE";
                    }
                    else
                    {
                        txtvoice.Value = "Credit Note";
                    }
                  
                    txtdebitno.Value = "Credit Note No";
                    txtdebitnotedate.Value = "Credit Note Date";
                    //textBox5.Value = "";
                    //textBox2.Visible = false;
                    //textBox3.Value = "";
                    //textBox4.Value = "";                  
                    //textBox23.Value = "";
                    //tablepremium.Visible = false;
                    //panel1.Visible = false;
                    //txtgst.Visible = false;
                    //txtbrokage.Visible = false;
                    //textBox12.Visible = false;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox23.Visible = true;

                }
                else
                {
                    decimal totaldue1 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                    if (totaldue1 >= 0)
                    {
                        txtvoice.Value = "TAX INVOICE";
                    }
                    else
                    {
                        txtvoice.Value = "Credit Note";
                    }
                  
                
                    txtdebitno.Value = "Debit Note No";
                    txtdebitnotedate.Value = "Debit Note Date";
                    //txtWarrenty.Visible = true;
                    //txtwarrentinf01.Visible = true;
                    //txtwarrentydate.Visible = true;
                    //txtwarrentyinfo2.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    //txtBank.Visible = true;
                    //txtbankaddress.Visible = true;
                    //txtbankaccount.Visible = true;
                    //txtbranchno.Visible = true;
                    //txtswiftcode.Visible = true;
                    //txtbankname.Visible = true;
                    //txtAddress1.Visible = true;
                    //txtAddess2.Visible = true;
                    //txtAddress3.Visible = true;
                    //txtAccountNumber.Visible = true;
                    //txtBranchName.Visible = true;
                    //txtcode.Visible = true;
                    textBox23.Visible = true;


                    //txtoaccountno.Visible = true;
                    //txtoaddress.Visible = true;
                    //txtobank.Visible = true;
                    //txtobranchno.Visible = true;
                    //txtofficeAdddress3.Visible = true;
                    //txtofficeAddress1.Visible = true;
                    //txtofficeAddress2.Visible = true;
                    //textBox5.Visible = true;
                    //txtOfficeCode.Visible = true;

                    //txtofcBankName.Visible = true;
                    //txtOfficeAccNo.Visible = true;
                    //txtOfficeBranch.Visible = true;
                    //   textBox28.Value = "This is a computer generated printout and no signature is required.";
                    // textBox31.Visible = false;

                    //textBox30.Visible = false;
                    //  textBox28.Visible = false;

                }


                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();


                //txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString(); 
                //txtClientName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
                #region Add address detail
                DataView dvaddress = new DataView(dsObj.Tables[1]);

                DataTable dtAddressTable = dvaddress.ToTable();

                if (dtAddressTable != null)
                {

                    txtClientName.Value = dtAddressTable.Rows[0]["TopCompanyName"].ToString();
                    txtCompAddr.Value = dtAddressTable.Rows[0]["CompanyAdd2"].ToString();
                    txtCompanyAddress3.Value = dtAddressTable.Rows[0]["CompanyAdd3"].ToString();
                    txtfaxno.Value = dtAddressTable.Rows[0]["FaxNo"].ToString();
                    txtcomtele.Value = dtAddressTable.Rows[0]["TelNo"].ToString();
                    // txtClientAdd2.Value = dtAddressTable.Rows[0]["TopCompanyAddress"].ToString();
                    //txtClientAdd3.Value = dtAddressTable.Rows[0]["BillingAddress3"].ToString();
                }
                #endregion


                var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
                // txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();
                //txtComName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

                //txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();


                DataView dv = new DataView(dsObj.Tables[0]);
                dv.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable = dv.ToTable();
                if (dtViewTable != null)
                {
                    //  txtCompAddr.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                    txtClientAdd2.Value = dtViewTable.Rows[0]["BillingAddressFirst"].ToString();
                    txtClientAdd3.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                    txtcountry.Value = dtViewTable.Rows[0]["Countrypostal"].ToString();
                    // txtpostalcode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    txtdebitnotevalue.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                    txtdebitdatevalue.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                    txtclientcodevalue.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                    txtslipno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    // txtcovernoteno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    if (dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() != "")
                        txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    else
                        txtSer.Visible = false;
                    txtinsuredname.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                    txtDebitNoteInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();
                    txtPolicyNovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                    //insuredname = txtinsuredname.Value;
                    if (dtViewTable.Rows[0]["InterestField"].ToString() == "")
                    {
                        textintersetvalue.Visible = false;
                        textBox31.Visible = false;
                        textBox16.Visible = false;
                    }
                    else
                        textintersetvalue.Value = dtViewTable.Rows[0]["InterestField"].ToString();
                    //  txtclsinsurancevalue.Value = dtViewTable.Rows[0]["SubClassName"].ToString();

                    string str = dtViewTable.Rows[0]["SubClassName"].ToString().Trim();
                    string removecomma = "";
                    if (str.Contains(","))
                        removecomma = str.Remove(str.Length - 1);
                    else
                        removecomma = str;

                    if (!removecomma.Contains("Please"))
                        txtclsinsurancevalue.Value = removecomma;


                    txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                    txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();
                    if (dtViewTable.Rows[0]["POIToDate"].ToString() == "" || dtViewTable.Rows[0]["POIFromDate"].ToString() == "")
                        txtTextMiddle.Visible = false;
                    if (dtViewTable.Rows.Count > 0)
                    {
                        intnumber = dtViewTable.Rows.Count;
                        for (int i = 0; i < intnumber; i++)
                        {
                            string isleader = dtViewTable.Rows[i]["Isleader"].ToString();
                            if (intnumber == 1)
                                txtPolicyNovalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtPolicyNovalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }


                    // txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();
                    if (dsObj.Tables[2].Rows.Count > 0)
                    {
                        txtpolicydescvalue.Value = dsObj.Tables[2].Rows[0]["EndorsementRemark"].ToString();

                    }
                    else
                    {
                        txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                    }
                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;
                }
                if (dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString() == "0.00")
                {
                    txtsuminsured.Visible = false;
                    textBox18.Visible = false;
                    txtsuminsuredvalue.Visible = false;
                }
                else
                    txtsuminsuredvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString()));

                if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
                {

                    if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() != "")
                    {
                        txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString();
                        txtPOITo.Value = dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString();
                    }
                    else
                        txtTextMiddle.Visible = false;
                }

                if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
                {

                    //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                    //txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                    //txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                    //txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                    //txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                    //txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                    //txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                    //txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                    //txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                    //txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                    //txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
                    //txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                    //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                    //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                    //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
                }
                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                // txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["PremiumWithoutGST"].ToString()));

                DataView dv1 = new DataView(dsObj.Tables[3]);
                dv1.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable1 = dv1.ToTable();
                if (dtViewTable1 != null)
                {
                    //txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {



                        decimal totaldue = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue >= 0)
                        {
                            txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                        }
                        else
                        {
                            txtservicefeevalue.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["ServiceFee"].ToString()));


                        }
                    }
                    //if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    //{
                    //    txtdiscount.Visible = false;
                    //    txtdiscountvalue.Visible = false;
                    //    textBox13.Visible = false;
                    //}
                    //else
                    //{
                    //    txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //}
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {
                        decimal totaldue1 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue1 >= 0)
                        {
                            txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));//InsurerGSTAmount
                        }
                        else
                        {
                            txtGSTAmt.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));


                        }



                        //txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                    }

                    decimal totaldue2 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                    if (totaldue2 >= 0)
                    {
                        txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                    }
                    else
                    {
                        txttotaldueamount.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["DueFromClient"].ToString()));


                    }




                }

                //txtpremium.Visible = false;
                //txtpremiumvalue.Visible = false;
                //textBox9.Visible = false;
                //txtdiscount.Visible = false;
                //textBox13.Visible = false;
                //txtdiscountvalue.Visible = false;
                //tblfilecopydetail.Visible = false;
                //tblunderwriterlist.Visible = false;
                //tblAgent.Visible = false;

                txtFee.Visible = false;
                txtgstfee.Visible = false;
                txtpCharge.Visible = false;
                txtPolicyStatusValue.Visible = false;
                //   textBox28.Value = "This is a computer generated printout and no signature is required.";
                //textBox31.Visible = false;

                textBox1.Visible = false;
                textBox7.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                txtFee.Visible = false;
                txtgstfee.Visible = false;
                txtpCharge.Visible = false;
                txtPolicyStatusValue.Visible = false;
                textBox69.Visible = false;
                textBox70.Visible = false;
                textBox71.Visible = false;
                textBox72.Visible = false;
                textBox32.Visible = false;
                textBox30.Visible = false;
                textBox12.Visible = false;
                txtRiskGrouping.Visible = false;

                if (clientFlag == "FileCopy")
                {

                    textBox1.Visible = true;
                    textBox7.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    txtFee.Visible = true;
                    txtgstfee.Visible = true;
                    txtpCharge.Visible = true;
                    txtPolicyStatusValue.Visible = true;

                    textBox69.Visible = true;
                    textBox70.Visible = true;
                    textBox71.Visible = true;
                    textBox72.Visible = true;
                    textBox32.Visible = true;
                    textBox30.Visible = true;
                    textBox12.Visible = true;
                    txtRiskGrouping.Visible = true;

                    DataView dvFooter = new DataView(dsObj.Tables[3]);
                    dvFooter.RowFilter = "ClientCode = '" + strClientCode + "'";
                    DataTable dtViewTableFooter = dvFooter.ToTable();
                    if (dtViewTableFooter != null)
                    {

                        decimal totaldue5 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue5 >= 0)
                        {
                            txtFee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFee"].ToString()));
                            txtgstfee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            txtpCharge.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["PolicyCharge"].ToString()));
                        }
                        else
                        {


                            txtFee.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["ServiceFee"].ToString()));
                            txtgstfee.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            txtpCharge.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["PolicyCharge"].ToString()));


                        }





                        //txtFee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFee"].ToString()));
                        //txtgstfee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                        //txtpCharge.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["PolicyCharge"].ToString()));
                    }
                    txtPolicyStatusValue.Value = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    txtRiskGrouping.Value = dsObj.Tables[11].Rows[0]["DivisionalGroupingName"].ToString();


                    //  txtgrosspvalue.v  dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();



                }



            }
            else
            {


                decimal totaldue = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                if (totaldue >= 0)
                {
                    txtvoice.Value = "TAX INVOICE";
                }
                else
                {
                    txtvoice.Value = "Credit Note";
                }

               
                txtdebitno.Value = "Debit Note No";
                txtdebitnotedate.Value = "Debit Note Date";
                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();
                #region for address
                DataView dvaddress = new DataView(dsObj.Tables[1]);

                DataTable dtAddressTable = dvaddress.ToTable();
                #endregion
                if (dtAddressTable != null)
                {

                    txtClientName.Value = dtAddressTable.Rows[0]["TopCompanyName"].ToString();
                    txtCompAddr.Value = dtAddressTable.Rows[0]["CompanyAdd2"].ToString();
                    txtCompanyAddress3.Value = dtAddressTable.Rows[0]["CompanyAdd3"].ToString();
                    //  txtClientAdd2.Value = dtAddressTable.Rows[0]["TopCompanyAddress"].ToString();
                    // txtClientAdd3.Value = dtAddressTable.Rows[0]["BillingAddress3"].ToString();
                    txtfaxno.Value = dtAddressTable.Rows[0]["FaxNo"].ToString();
                    txtcomtele.Value = dtAddressTable.Rows[0]["TelNo"].ToString();
                }




                //textBox28.Visible = true;
                //textBox28.Value = "This is a computer generated printout and no signature is required.";


                DataView dv = new DataView(dsObj.Tables[0]);
                dv.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable = dv.ToTable();



                if (dtViewTable != null)
                {

                    txtdebitnotevalue.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                    txtdebitdatevalue.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                    txtclientcodevalue.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                    txtslipno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    //  txtcovernoteno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    if (dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() != "")
                        txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    else
                        txtSer.Visible = false;
                    txtinsuredname.Value = dtViewTable.Rows[0]["ClientName"].ToString();


                    //txtclsinsurancevalue.Value = dtViewTable.Rows[0]["SubClassName"].ToString();
                    //txtclsinsurancevalue.Value =Convert.ToString( dtViewTable.Rows[0]["SubClassName"]).Trim().Remove(Convert.ToString( dtViewTable.Rows[0]["SubClassName"]).Length-1);

                    string str = dtViewTable.Rows[0]["SubClassName"].ToString().Trim();
                    string removecomma = "";
                    if (str.Contains(","))
                        removecomma = str.Remove(str.Length - 1);
                    else
                        removecomma = str;
                    if (!removecomma.Contains("Please"))
                        txtclsinsurancevalue.Value = removecomma;


                    // txtpolicynovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                    //insuredname = txtinsuredname.Value;
                    //// string s = " ";
                    //textintersetvalue.Value = "All employees in " + insuredname + " company and subsidiary";
                    if (dtViewTable.Rows[0]["InterestField"].ToString() == "")
                    {
                        textintersetvalue.Visible = false;
                        textBox31.Visible = false;
                        textBox16.Visible = false;
                    }
                    else
                        textintersetvalue.Value = dtViewTable.Rows[0]["InterestField"].ToString();
                    txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                    txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();
                    if (dtViewTable.Rows[0]["POIToDate"].ToString() == "" || dtViewTable.Rows[0]["POIFromDate"].ToString() == "")
                        txtTextMiddle.Visible = false;
                    txtClientAdd2.Value = dtViewTable.Rows[0]["BillingAddressFirst"].ToString();
                    txtClientAdd3.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                    txtcountry.Value = dtViewTable.Rows[0]["Countrypostal"].ToString();
                    // txtpostalcode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    if (dtViewTable.Rows.Count > 0)
                    {
                        intnumber = dtViewTable.Rows.Count;
                        for (int i = 0; i < intnumber; i++)
                        {
                            string isleader = dtViewTable.Rows[i]["Isleader"].ToString();
                            if (intnumber == 1)
                                txtPolicyNovalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    //txtleader.Value = "(Leader)";
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtPolicyNovalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }

                    // txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();
                    txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();

                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;

                   // txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    txtDebitNoteInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();
                    txtPolicyNovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();

                }
                if (dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString() == "0.00")
                {
                    txtsuminsured.Visible = false;
                    textBox18.Visible = false;
                    txtsuminsuredvalue.Visible = false;
                }
                else
                    txtsuminsuredvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString()));

                if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
                {

                    if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() != "")
                    {
                        txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString();
                        txtPOITo.Value = dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString();
                    }
                    else
                        txtTextMiddle.Visible = false;
                }
                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();

                DataView dv1 = new DataView(dsObj.Tables[3]);
                dv1.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable1 = dv1.ToTable();
                if (dtViewTable1 != null)
                {
                    // txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {
                        decimal totaldue1 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue1 >= 0)
                        {
                            txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                        }
                        else
                        {
                            txtservicefeevalue.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["ServiceFee"].ToString()));


                        }



                      
                    }
                    //if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    //{
                    //    txtdiscount.Visible = false;
                    //    txtdiscountvalue.Visible = false;
                    //    textBox13.Visible = false;
                    //}
                    //else
                    //{
                    //    txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //}
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()) == 0.0) //InsurerGSTAmount
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {

                        decimal totaldue1 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue1 >= 0)
                        {
                            txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));//InsurerGSTAmount
                        }
                        else
                        {
                            txtGSTAmt.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));


                        }

                    }

                    decimal totaldue3 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                    if (totaldue3 >= 0)
                    {
                        txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                    }
                    else
                    {
                        txttotaldueamount.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["DueFromClient"].ToString()));


                    }


                }


                if (dsObj.Tables[6].Rows.Count == 0)
                {

                }
                textBox1.Visible = false;
                textBox7.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                txtFee.Visible = false;
                txtgstfee.Visible = false;
                txtpCharge.Visible = false;
                txtPolicyStatusValue.Visible = false;
                textBox69.Visible = false;
                textBox70.Visible = false;
                textBox71.Visible = false;
                textBox72.Visible = false;
                textBox32.Visible = false;
                textBox30.Visible = false;
                textBox12.Visible = false;
                txtRiskGrouping.Visible = false;
                if (clientFlag == "FileCopy")
                {


                    txtfilecopyvalue.Value = "(File Copy)";

                    textBox1.Visible = true;
                    textBox7.Visible = true;
                    textBox9.Visible = true;
                    textBox10.Visible = true;
                    txtFee.Visible = true;
                    txtgstfee.Visible = true;
                    txtpCharge.Visible = true;
                    txtPolicyStatusValue.Visible = true;

                    textBox69.Visible = true;
                    textBox70.Visible = true;
                    textBox71.Visible = true;
                    textBox72.Visible = true;
                    textBox32.Visible = true;
                    textBox30.Visible = true;
                    textBox12.Visible = true;
                    txtRiskGrouping.Visible = true;

                    DataView dvFooter = new DataView(dsObj.Tables[3]);
                    dvFooter.RowFilter = "ClientCode = '" + strClientCode + "'";
                    DataTable dtViewTableFooter = dvFooter.ToTable();
                    if (dtViewTableFooter != null)
                    {


                        decimal totaldue4 = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["DueFromClient"]);
                        if (totaldue4 >= 0)
                        {
                            txtFee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFee"].ToString()));
                            txtgstfee.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            txtpCharge.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTableFooter.Rows[0]["PolicyCharge"].ToString()));
                        }
                        else
                        {
                            

                            txtFee.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["ServiceFee"].ToString()));
                            txtgstfee.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            txtpCharge.Value = convertIntoNumeric(decimal.Parse(dtViewTableFooter.Rows[0]["PolicyCharge"].ToString()));


                        }


                       
                    }
                    txtPolicyStatusValue.Value = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    txtRiskGrouping.Value = dsObj.Tables[11].Rows[0]["DivisionalGroupingName"].ToString();

                }
            }
        }

    }
}