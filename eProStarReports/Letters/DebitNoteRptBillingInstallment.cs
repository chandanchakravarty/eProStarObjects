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
    internal partial class DebitNoteRptBillingInstallment : Telerik.Reporting.Report
    {
        public int Rows = 0;
        public int Rows1 = 0;
        DataTable dtCopyViewunderwriter;
        public string insuredname = "";
        public string checkisleader = "";
        public int intnumber = 0;
        public DebitNoteRptBillingInstallment()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //txtpolicyvalue
        }

        public DebitNoteRptBillingInstallment(DataSet dsObj, string strClientCode, string strCheckedInstl, String clientFlag)
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
                    txtvoice.Value = "CREDIT NOTE";
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
                    txtvoice.Value = "DEBIT NOTE";
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
                   // txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    txtinsuredname.Value = dtViewTable.Rows[0]["ClientName"].ToString();
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
                    // txtpolicynovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();

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
                                txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }


                    // txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();
                    if (dsObj.Tables[2].Rows.Count > 0)
                    {
                        if (dsObj.Tables[2].Rows[0]["EndorsementRemark"].ToString() != "")
                            txtpolicydescvalue.Value = dsObj.Tables[2].Rows[0]["EndorsementRemark"].ToString();
                        else
                        {
                            txtpolicydesc.Visible = false;
                            textBox21.Visible = false;
                        }
                    }
                    else
                    {
                        if (dsObj.Tables[2].Rows[0]["Remarks"].ToString() != "")
                            txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                        else
                        {
                            txtpolicydesc.Visible = false;
                            textBox21.Visible = false;
                            txtpolicydescvalue.Visible = false;
                        }
                    }
                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;
                    if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
                    {

                        if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() != "")
                        {
                            txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString();
                            txtPOITo.Value = dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString();
                            if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() == "" || dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString() == "")
                                txtTextMiddle.Visible = false;
                        }
                    }
                }
                if (dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString() == "0.00")
                {
                    txtsuminsured.Visible = false;
                    textBox18.Visible = false;
                    txtsuminsuredvalue.Visible = false;
                }
                else
                    txtsuminsuredvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString()));

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
                    txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {
                        txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    {
                        txtdiscount.Visible = false;
                        txtdiscountvalue.Visible = false;
                        textBox13.Visible = false;
                    }
                    else
                    {
                        txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {
                        txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                    }

                    txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

                }

                //tblfilecopydetail.Visible = false;
                //tblunderwriterlist.Visible = false;
                //tblAgent.Visible = false;
                txtstampdutyvalue.Visible = false;

                //   txtservicefeevalue.Visible =false; 
                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
                textBox62.Visible = false;
                //textBox32.Visible = false;
                txtdiscvalue.Visible = false;
                txtotherharge.Visible = false;
                txtcustvalue.Visible = false;
                txtpolicyvalue.Visible = false;
                txtstampvalue.Visible = false;
                txtgrossp.Visible = false;
                txtgst.Visible = false;
                txtservicegst.Visible = false;
                txtdisc.Visible = false;
                txtcust.Visible = false;
                txtSerFee.Visible = false;
                txtbrokage.Visible = false;
                //textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;
                txtInstalment.Visible = false;
                txtInstalmentValue.Visible = false;
                txtduedate.Visible = false;
                txtduedatevalue.Visible = false;
                //   textBox28.Value = "This is a computer generated printout and no signature is required.";
                //textBox31.Visible = false;

                if (clientFlag == "FileCopy")
                {
                    //textBox30.Visible = false;
                    //textBox28.Visible = false;
                    txtgst.Visible = false;
                    //textBox31.Visible = true;

                    txtfilecopyvalue.Value = "(File Copy)";
                    //tblunderwriterlist.Visible = true;
                    //tblAgent.Visible = true;
                    txtstampdutyvalue.Visible = false;

                    //   txtservicefeevalue.Visible =false; 
                    txtgrosspvalue.Visible = true;
                    //txtbrokageper.Visible =false; 
                    txtbrokaragevalue.Visible = true;
                    txtGstvalue.Visible = true;
                    txtgstbrokerageper.Visible = true;
                    txtbrogevalue.Visible = true;
                    textBox62.Visible = true;
                    //textBox32.Visible = true;
                    txtdiscvalue.Visible = true;
                    txtotherharge.Visible = true;
                    txtcustvalue.Visible = true;
                    txtpolicyvalue.Visible = true;
                    txtstampvalue.Visible = true;
                    txtgrossp.Visible = true;
                    txtgst.Visible = true;
                    txtservicegst.Visible = true;
                    txtdisc.Visible = true;
                    txtcust.Visible = true;
                    txtSerFee.Visible = true;
                    txtbrokage.Visible = true;
                    //textBox7.Visible = true;
                    txtbro.Visible = true;
                    txtothervalue.Visible = true;
                    txtpolicystatus.Visible = true;




                    //  txtgrosspvalue.v  dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();


                    if (dsObj.Tables.Count > 8)
                    {
                        DataView dv2 = new DataView(dsObj.Tables[8]);

                        DataTable dtIntroducer = dv2.ToTable();
                        int icount = 0;
                        //tblAgent.DataSource = dtIntroducer;
                        int Rows = dtIntroducer.Rows.Count;

                        DataColumn dc = new DataColumn("AgentCount", typeof(String));
                        DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

                        dtIntroducer.Columns.Add(dc);
                        dtIntroducer.Columns.Add(dc1);
                        for (int i = 0; i < Rows; i++)
                        {
                            StringBuilder sb = new StringBuilder();
                            if (dsObj.Tables[6].Rows.Count > 0)
                            {
                                //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC")
                                //{
                                string agentcode = dsObj.Tables[4].Rows[i]["agentcode"].ToString();
                                DataRow drintro = dtIntroducer.Rows[i];
                                drintro["agentcode"] = agentcode;
                                //}


                                DataRow dr = dtIntroducer.Rows[i];
                                string agent = "AGENT";
                                string Comm = "AGENTCOMM";
                                int sum = i + 1;
                                dr["AgentCount"] = agent + sum;
                                dr["AgentCommision"] = Comm + sum;
                            }


                        }



                    }

                    if (dsObj.Tables.Count > 4 && dsObj.Tables[8].Rows.Count == 0)
                    {
                        DataView dv3 = new DataView(dsObj.Tables[4]);

                        DataTable dtIntroducer = dv3.ToTable();
                        int icount = 0;
                        //tblAgent.DataSource = dtIntroducer;
                        int Rows = dtIntroducer.Rows.Count;


                        DataColumn dc = new DataColumn("AgentCount", typeof(String));
                        DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

                        dtIntroducer.Columns.Add(dc);
                        dtIntroducer.Columns.Add(dc1);

                        for (int i = 0; i < Rows; i++)
                        {
                            StringBuilder sb = new StringBuilder();

                            if (dsObj.Tables[7].Rows.Count > 0 && dsObj.Tables[6].Rows.Count == 0)
                            {
                                string agentcode = dsObj.Tables[4].Rows[i]["agentname"].ToString();
                                DataRow drintroname = dtIntroducer.Rows[i];
                                drintroname["agentcode"] = agentcode;
                            }


                            DataRow dr = dtIntroducer.Rows[i];
                            string agent = "AGENT";
                            string Comm = "AGENTCOMM";
                            int sum = i + 1;
                            dr["AgentCount"] = agent + sum;
                            dr["AgentCommision"] = Comm + sum;


                        }
                    }

                    if (dsObj.Tables.Count > 5)
                    {
                        DataView dv4 = new DataView(dsObj.Tables[5]);

                        DataTable dtCopyViewIntroducer = dv4.ToTable();

                        int Rows = dtCopyViewIntroducer.Rows.Count;


                        for (int i = 0; i < Rows; i++)
                        {

                            DataRow dr = dtCopyViewIntroducer.Rows[i];

                            int sum = i + 1;
                            textBox7.Value = dtCopyViewIntroducer.Rows[0]["Underwritername"].ToString();

                            textBox7.Value = "GROSS PREMIUM" + i.ToString();

                            if (dtViewTable1 != null)
                            {
                                txtstampdutyvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()));

                                txtserfeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                                txtgrosspvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["TotalPremium"].ToString()));
                                txtbrokageper.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["uwbrokerage"].ToString()));
                                txtbrokaragevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["uwbrokerageamount"].ToString()));
                                txtGstvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                                txtgstbrokerageper.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["BrokerGST"].ToString()));
                                txtbrogevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["BrokerGSTAmount"].ToString()));
                                textBox62.Value = dtViewTable1.Rows[0]["BrokerGST"].ToString() + " %";
                                txtdiscvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));

                                txtothervalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["policycharge"].ToString()));
                                txtcustvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                                txtsergstvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            }

                            string businessType2 = string.Empty;

                            if (dsObj.Tables[9].Rows.Count > 0)
                                businessType2 = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                            if (businessType2 == "N")
                            {
                                businessType2 = "New Business";
                            }
                            if (businessType2 == "P")
                            {
                                businessType2 = "Expanded";
                            }
                            if (businessType2 == "R")
                            {
                                businessType2 = "Renewal";
                            }
                            txtpolicyvalue.Value = businessType2;
                        }

                    }
                }



            }
            else
            {
                txtvoice.Value = "DEBIT NOTE";
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

                txtgst.Visible = false;
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
                   // txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
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
                    if (dtViewTable.Rows[0]["POIFromDate"].ToString() == "" || dtViewTable.Rows[0]["POIToDate"].ToString() == "")
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
                                txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    //txtleader.Value = "(Leader)";
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }

                    // txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();
                    if (dtViewTable.Rows[0]["Remarks"].ToString() != "")
                        txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                    else
                    {
                        txtpolicydesc.Visible = false;
                        textBox21.Visible = false;
                        txtpolicydescvalue.Visible = false;
                    }
                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;
                   // txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
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
                        if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() == "" || dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString() == "")
                            txtTextMiddle.Visible = false;
                    }
                }

                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();

                DataView dv1 = new DataView(dsObj.Tables[3]);
                dv1.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable1 = dv1.ToTable();
                if (dtViewTable1 != null)
                {
                    txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {
                        txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    {
                        txtdiscount.Visible = false;
                        txtdiscountvalue.Visible = false;
                        textBox13.Visible = false;
                    }
                    else
                    {
                        txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {
                        txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                    }

                    txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

                }


                if (dsObj.Tables[6].Rows.Count == 0)
                {

                }

                txtstampdutyvalue.Visible = false;

                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
                textBox62.Visible = false;
                txtdiscvalue.Visible = false;
                txtotherharge.Visible = false;
                txtcustvalue.Visible = false;
                txtpolicyvalue.Visible = false;
                txtstampvalue.Visible = false;
                txtgrossp.Visible = false;
                txtgst.Visible = false;
                txtservicegst.Visible = false;
                txtdisc.Visible = false;
                txtcust.Visible = false;
                txtSerFee.Visible = false;
                txtbrokage.Visible = false;
                //textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;
                table1.Visible = false;
                tablepremium.Visible = false;
                txtInstalmentValue.Visible = false;
                txtInstalment.Visible = false;


                if (clientFlag == "FileCopy")
                {
                    #region dynamically bind table

                    txtfilecopyvalue.Value = "(File Copy)";

                    txtstampdutyvalue.Visible = true;

                    txtgrosspvalue.Visible = true;

                    txtbrokaragevalue.Visible = true;
                    txtGstvalue.Visible = true;
                    txtgstbrokerageper.Visible = true;
                    txtbrogevalue.Visible = true;
                    textBox62.Visible = true;
                    //textBox32.Visible = true;
                    txtdiscvalue.Visible = true;
                    txtotherharge.Visible = true;
                    txtcustvalue.Visible = true;
                    txtpolicyvalue.Visible = true;
                    txtstampvalue.Visible = true;
                    txtgrossp.Visible = true;
                    txtgst.Visible = true;
                    txtservicegst.Visible = true;
                    txtdisc.Visible = true;
                    txtcust.Visible = true;
                    txtSerFee.Visible = true;
                    txtbrokage.Visible = true;

                    txtbro.Visible = true;
                    txtothervalue.Visible = true;
                    txtpolicystatus.Visible = true;

                    if (dsObj.Tables.Count > 5)
                    {

                        DataView dv4 = new DataView(dsObj.Tables[12]);
                        dv4.RowFilter = "sno<3";
                        dtCopyViewunderwriter = new DataTable();
                        dtCopyViewunderwriter = dv4.ToTable();
                        tablepremium.DataSource = dtCopyViewunderwriter;
                        Rows = dtCopyViewunderwriter.Rows.Count;
                        DataColumn header = new DataColumn("header", typeof(String));
                        DataColumn footer = new DataColumn("footer", typeof(String));
                        DataColumn stumpvaluename = new DataColumn("stumpvaluename", typeof(String));
                        DataColumn grosspremium = new DataColumn("grosspremium", typeof(String));
                        DataColumn grosspremiumValue = new DataColumn("grosspremiumValue", typeof(String));
                        DataColumn stumpvaluevalue = new DataColumn("stumpvaluevalue", typeof(String));

                        DataColumn gst = new DataColumn("gst", typeof(String));
                        DataColumn gstvalue = new DataColumn("gstvalue", typeof(String));
                        DataColumn Servicefee = new DataColumn("Servicefee", typeof(String));
                        DataColumn Servicefeevalue = new DataColumn("Servicefeevalue", typeof(String));

                        DataColumn discount = new DataColumn("discount", typeof(String));
                        DataColumn discountvalue = new DataColumn("discountvalue", typeof(String));
                        DataColumn customerpremium = new DataColumn("customerpremium", typeof(String));
                        DataColumn customerpremiumvalue = new DataColumn("customerpremiumvalue", typeof(String));
                        DataColumn servicefeeu = new DataColumn("servicefeeu", typeof(String));
                        DataColumn serviceufeevalue = new DataColumn("serviceufeevalue", typeof(String));
                        DataColumn brokeragename = new DataColumn("brokeragename", typeof(String));
                        DataColumn brokeragevalue = new DataColumn("brokeragevalue", typeof(String));
                        DataColumn gstu = new DataColumn("gstu", typeof(String));
                        DataColumn gstuvalue = new DataColumn("gstuvalue", typeof(String));
                        DataColumn onbrokerage = new DataColumn("onbrokerage", typeof(String));
                        DataColumn onbrokeragevalue = new DataColumn("onbrokeragevalue", typeof(String));
                        DataColumn onInsrurGST = new DataColumn("onInsrurGST", typeof(String));
                        DataColumn othercharges = new DataColumn("othercharges", typeof(String));
                        DataColumn otherchargesvalue = new DataColumn("otherchargesvalue", typeof(String));
                        DataColumn policystatus = new DataColumn("policystatus", typeof(String));
                        DataColumn policystatusvalue = new DataColumn("policystatusvalue", typeof(String));
                        DataColumn grosspremiumu = new DataColumn("grosspremiumu", typeof(String));
                        DataColumn grosspremiumuvalue = new DataColumn("grosspremiumuvalue", typeof(String));

                        DataColumn underwriternamevalue = new DataColumn("underwriternamevalue", typeof(String));

                        DataColumn underwritercodevalue = new DataColumn("underwritercodevalue", typeof(String));
                        DataColumn uwbrokerage = new DataColumn("uwbrokerage", typeof(String));
                        DataColumn insurergstvalue = new DataColumn("insurergstvalue", typeof(String));


                        dtCopyViewunderwriter.Columns.Add(insurergstvalue);

                        dtCopyViewunderwriter.Columns.Add(uwbrokerage);

                        dtCopyViewunderwriter.Columns.Add(underwriternamevalue);

                        dtCopyViewunderwriter.Columns.Add(underwritercodevalue);

                        dtCopyViewunderwriter.Columns.Add(header);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluename);
                        dtCopyViewunderwriter.Columns.Add(grosspremium);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumValue);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluevalue);
                        dtCopyViewunderwriter.Columns.Add(Servicefee);
                        dtCopyViewunderwriter.Columns.Add(Servicefeevalue);

                        dtCopyViewunderwriter.Columns.Add(gst);
                        dtCopyViewunderwriter.Columns.Add(gstvalue);

                        dtCopyViewunderwriter.Columns.Add(discount);
                        dtCopyViewunderwriter.Columns.Add(discountvalue);
                        dtCopyViewunderwriter.Columns.Add(customerpremium);
                        dtCopyViewunderwriter.Columns.Add(customerpremiumvalue);
                        dtCopyViewunderwriter.Columns.Add(servicefeeu);
                        dtCopyViewunderwriter.Columns.Add(serviceufeevalue);
                        dtCopyViewunderwriter.Columns.Add(brokeragename);
                        dtCopyViewunderwriter.Columns.Add(brokeragevalue);
                        dtCopyViewunderwriter.Columns.Add(onInsrurGST);
                        dtCopyViewunderwriter.Columns.Add(gstu);
                        dtCopyViewunderwriter.Columns.Add(gstuvalue);
                        dtCopyViewunderwriter.Columns.Add(onbrokerage);
                        dtCopyViewunderwriter.Columns.Add(onbrokeragevalue);
                        dtCopyViewunderwriter.Columns.Add(othercharges);
                        dtCopyViewunderwriter.Columns.Add(otherchargesvalue);
                        dtCopyViewunderwriter.Columns.Add(policystatus);
                        dtCopyViewunderwriter.Columns.Add(policystatusvalue);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumu);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumuvalue);
                        dtCopyViewunderwriter.Columns.Add(footer);
                        for (int i = 0; i < Rows; i++)
                        {

                            if (i < 2)
                            {
                                panel3.Visible = true;
                                tablepremium.Visible = true;
                                DataRow dr = dtCopyViewunderwriter.Rows[i];

                                dr["servicefeeu"] = "Service Fee";
                                dr["brokeragename"] = "Brokerage";
                                dr["gstu"] = "GST";
                                dr["onbrokerage"] = "On Brokerage";
                                dr["othercharges"] = "Other Charges";
                                dr["policystatus"] = "Policy Status";
                                //int sum = i + 1;
                                //dr["grosspremiumu"] = "Gross Premium" + sum.ToString();

                                //dr["grosspremiumuvalue"] =string.Format("{0:0,0.00}", Convert.ToDouble( dtCopyViewunderwriter.Rows[i]["Premium"].ToString()));
                                int sum = i + 1;
                                dr["grosspremiumu"] = "Gross Premium" + sum.ToString();

                                dr["grosspremiumuvalue"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["Premium"].ToString()));

                                string uwbrokerageamount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["Brokerage"].ToString()));
                                dr["brokeragevalue"] = uwbrokerageamount;
                                string BrokerGSTAmount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerGSTAmount"].ToString()));
                                dr["gstuvalue"] = BrokerGSTAmount;
                                string gvalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerGST"].ToString()));
                                dr["gstvalue"] = gvalue;
                                string InsurerGST = dtCopyViewunderwriter.Rows[i]["BrokerGST"].ToString();
                                dr["onInsrurGST"] = InsurerGST + " %";
                                string uwbrok = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerageRate"].ToString()));
                                dr["uwbrokerage"] = uwbrok;





                                if (dtCopyViewunderwriter != null)
                                {
                                    string isleader = dtCopyViewunderwriter.Rows[i]["Isleader"].ToString();
                                    if (isleader == "Y")
                                    {
                                        string per = "%";
                                        string s = " - ";
                                        string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["UWShare"].ToString()));
                                        checkisleader = "(Leader)";
                                        string underwritername = dtCopyViewunderwriter.Rows[i]["UnderWriterName"].ToString() + checkisleader + s + undersharepercentage + per;
                                        dr["underwriternamevalue"] = underwritername;
                                    }
                                    else
                                    {
                                        string per = "%";
                                        string s = " - ";
                                        string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["UWShare"].ToString()));
                                        string underwritername = dtCopyViewunderwriter.Rows[i]["UnderWriterName"].ToString() + s + undersharepercentage + per; ;
                                        dr["underwriternamevalue"] = underwritername;
                                    }



                                    // dr["sharepercentagevalue"] = undersharepercentage;
                                    string uwritercode = dtCopyViewunderwriter.Rows[i]["Underwritercode"].ToString();
                                    dr["underwritercodevalue"] = uwritercode;
                                }

                                if (dtViewTable1 != null)
                                {
                                    if (i == 0)
                                    {
                                        dr["header"] = "Brokerage";
                                        dr["footer"] = "This is a computer generated printout and no signature is required.";
                                        dr["stumpvaluename"] = "Stump Duty";
                                        dr["grosspremium"] = "Gross Premium";
                                        dr["gst"] = "GST";
                                        dr["Servicefee"] = "Service Fee GST";

                                        dr["discount"] = "Discount";
                                        dr["customerpremium"] = "Customer Premium";

                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()) == 0.0)
                                        {
                                            txtstampvalue.Visible = false;
                                            txtstampdutyvalue.Visible = false;

                                        }
                                        else
                                        {
                                            string stumpduty = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()));
                                            dr["stumpvaluevalue"] = stumpduty;
                                        }




                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()) == 0.0)
                                        {
                                            txtservicegst.Visible = false;
                                            txtsergstvalue.Visible = false;

                                        }
                                        else
                                        {

                                            string servicefeegst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                                            dr["Servicefeevalue"] = servicefeegst;
                                        }


                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                                        {
                                            txtdisc.Visible = false;
                                            txtdiscvalue.Visible = false;

                                        }
                                        else
                                        {

                                            string disc = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                                            dr["discountvalue"] = disc;
                                        }



                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                                        {
                                            txtgst.Visible = false;
                                            txtGstvalue.Visible = false;


                                        }
                                        else
                                        {

                                            string isurergst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["InsurerGSTAmount"].ToString()));
                                            dr["insurergstvalue"] = isurergst;
                                        }








                                        string grosspre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                                        dr["grosspremiumValue"] = grosspre;



                                        string customerpre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                                        dr["customerpremiumvalue"] = customerpre;

                                        //textBox31.Visible = false;
                                        textBox10.Visible = true;
                                        string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["ServiceFee"].ToString()));

                                        dr["serviceufeevalue"] = servicefeevalue;

                                        dr["gstuvalue"] = BrokerGSTAmount;
                                        string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["policycharge"].ToString()));
                                        dr["otherchargesvalue"] = policycharge;

                                    }
                                    else
                                    {
                                        //textBox10.Visible = false;

                                        //textBox31.Visible = true;
                                        if (dtViewTable.Rows.Count > 1)
                                        {
                                            string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["ServiceFee"].ToString()));

                                            dr["serviceufeevalue"] = servicefeevalue;

                                            dr["gstuvalue"] = BrokerGSTAmount;
                                            string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["policycharge"].ToString()));
                                            dr["otherchargesvalue"] = policycharge;

                                        }
                                    }



                                }
                                if (dsObj.Tables[2].Rows.Count > 0)
                                {
                                    string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                                    string businessType4 = string.Empty;
                                    //int tblCount = dsObj.Tables.Count;
                                    if (dsObj.Tables[9].Rows.Count > 0)
                                        businessType4 = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                                    if (businessType4 == "N")
                                    {
                                        businessType4 = "New Business";
                                    }
                                    if (businessType4 == "P")
                                    {
                                        businessType4 = "Expanded";
                                    }
                                    if (businessType4 == "R")
                                    {
                                        businessType4 = "Renewal";
                                    }



                                    string businessType4value = businessType4;
                                    dr["policystatusvalue"] = businessType4value;


                                }
                            }
                        }

                        #region declare data

                        DataView dv5 = new DataView(dsObj.Tables[12]);
                        dv5.RowFilter = "sno>2";
                        dtCopyViewunderwriter = new DataTable();
                        dtCopyViewunderwriter = dv5.ToTable();
                        table1.DataSource = dtCopyViewunderwriter;
                        Rows1 = dtCopyViewunderwriter.Rows.Count;

                        DataColumn header1 = new DataColumn("header1", typeof(String));
                        DataColumn footer1 = new DataColumn("footer1", typeof(String));
                        DataColumn stumpvaluename1 = new DataColumn("stumpvaluename1", typeof(String));
                        DataColumn grosspremium1 = new DataColumn("grosspremium1", typeof(String));
                        DataColumn grosspremiumValue1 = new DataColumn("grosspremiumValue1", typeof(String));
                        DataColumn stumpvaluevalue1 = new DataColumn("stumpvaluevalue1", typeof(String));

                        DataColumn gst1 = new DataColumn("gst1", typeof(String));
                        DataColumn gstvalue1 = new DataColumn("gstvalue1", typeof(String));
                        DataColumn Servicefee1 = new DataColumn("Servicefee1", typeof(String));
                        DataColumn Servicefeevalue1 = new DataColumn("Servicefeevalue1", typeof(String));

                        DataColumn discount1 = new DataColumn("discount1", typeof(String));
                        DataColumn discountvalue1 = new DataColumn("discountvalue1", typeof(String));
                        DataColumn customerpremium1 = new DataColumn("customerpremium1", typeof(String));
                        DataColumn customerpremiumvalue1 = new DataColumn("customerpremiumvalue1", typeof(String));
                        DataColumn servicefeeu1 = new DataColumn("servicefeeu1", typeof(String));
                        DataColumn serviceufeevalue1 = new DataColumn("serviceufeevalue1", typeof(String));
                        DataColumn brokeragename1 = new DataColumn("brokeragename1", typeof(String));
                        DataColumn brokeragevalue1 = new DataColumn("brokeragevalue1", typeof(String));
                        DataColumn gstu1 = new DataColumn("gstu1", typeof(String));
                        DataColumn gstuvalue1 = new DataColumn("gstuvalue1", typeof(String));
                        DataColumn onbrokerage1 = new DataColumn("onbrokerage1", typeof(String));
                        DataColumn onbrokeragevalue1 = new DataColumn("onbrokeragevalue1", typeof(String));
                        DataColumn onInsrurGST1 = new DataColumn("onInsrurGST1", typeof(String));
                        DataColumn othercharges1 = new DataColumn("othercharges1", typeof(String));
                        DataColumn otherchargesvalue1 = new DataColumn("otherchargesvalue1", typeof(String));
                        DataColumn policystatus1 = new DataColumn("policystatus1", typeof(String));
                        DataColumn policystatusvalue1 = new DataColumn("policystatusvalue1", typeof(String));
                        DataColumn grosspremiumu1 = new DataColumn("grosspremiumu1", typeof(String));
                        DataColumn grosspremiumuvalue1 = new DataColumn("grosspremiumuvalue1", typeof(String));

                        DataColumn underwriternamevalue1 = new DataColumn("underwriternamevalue1", typeof(String));
                        // DataColumn sharepercentagevalue1 = new DataColumn("sharepercentagevalue1", typeof(String));
                        DataColumn underwritercodevalue1 = new DataColumn("underwritercodevalue1", typeof(String));
                        DataColumn uwbrokerage1 = new DataColumn("uwbrokerage1", typeof(String));
                        DataColumn insurergstvalue1 = new DataColumn("insurergstvalue1", typeof(String));


                        dtCopyViewunderwriter.Columns.Add(insurergstvalue1);

                        dtCopyViewunderwriter.Columns.Add(uwbrokerage1);

                        dtCopyViewunderwriter.Columns.Add(underwriternamevalue1);
                        //  dtCopyViewunderwriter.Columns.Add(sharepercentagevalue1);
                        dtCopyViewunderwriter.Columns.Add(underwritercodevalue1);

                        dtCopyViewunderwriter.Columns.Add(header1);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluename1);
                        dtCopyViewunderwriter.Columns.Add(grosspremium1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumValue1);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluevalue1);
                        dtCopyViewunderwriter.Columns.Add(Servicefee1);
                        dtCopyViewunderwriter.Columns.Add(Servicefeevalue1);

                        dtCopyViewunderwriter.Columns.Add(gst1);
                        dtCopyViewunderwriter.Columns.Add(gstvalue1);

                        dtCopyViewunderwriter.Columns.Add(discount1);
                        dtCopyViewunderwriter.Columns.Add(discountvalue1);
                        dtCopyViewunderwriter.Columns.Add(customerpremium1);
                        dtCopyViewunderwriter.Columns.Add(customerpremiumvalue1);
                        dtCopyViewunderwriter.Columns.Add(servicefeeu1);
                        dtCopyViewunderwriter.Columns.Add(serviceufeevalue1);
                        dtCopyViewunderwriter.Columns.Add(brokeragename1);
                        dtCopyViewunderwriter.Columns.Add(brokeragevalue1);
                        dtCopyViewunderwriter.Columns.Add(gstu1);
                        dtCopyViewunderwriter.Columns.Add(gstuvalue1);
                        dtCopyViewunderwriter.Columns.Add(onbrokerage1);
                        dtCopyViewunderwriter.Columns.Add(onbrokeragevalue1);
                        dtCopyViewunderwriter.Columns.Add(onInsrurGST1);
                        dtCopyViewunderwriter.Columns.Add(othercharges1);
                        dtCopyViewunderwriter.Columns.Add(otherchargesvalue1);
                        dtCopyViewunderwriter.Columns.Add(policystatus1);
                        dtCopyViewunderwriter.Columns.Add(policystatusvalue1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumu1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumuvalue1);
                        dtCopyViewunderwriter.Columns.Add(footer1);
                        #endregion


                        for (int j = 0; j < Rows1; j++)
                        {
                            panel4.Visible = true;
                            table1.Visible = true;




                            DataRow drr = dtCopyViewunderwriter.Rows[j];


                            drr["servicefeeu1"] = "Service Fee";
                            drr["brokeragename1"] = "Brokerage";
                            drr["gstu1"] = "GST";
                            drr["onbrokerage1"] = "On Brokerage";
                            drr["othercharges1"] = "Other Charges";
                            drr["policystatus1"] = "Policy Status";
                            int sum = j + 1;
                            drr["grosspremiumu1"] = "Gross Premium" + sum.ToString();

                            drr["grosspremiumuvalue1"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["Premium"].ToString()));

                            string uwbrokerageamount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["Brokerage"].ToString()));
                            drr["brokeragevalue1"] = uwbrokerageamount;
                            string BrokerGSTAmount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerGSTAmount"].ToString()));
                            drr["gstuvalue1"] = BrokerGSTAmount;
                            string gvalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerGST"].ToString()));
                            drr["gstvalue1"] = gvalue;
                            string InsurerGST1 = dtCopyViewunderwriter.Rows[j]["BrokerGST"].ToString();
                            drr["onInsrurGST1"] = InsurerGST1 + " %";
                            string uwbrok = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerageRate"].ToString()));
                            drr["uwbrokerage1"] = uwbrok;

                            if (dtCopyViewunderwriter != null)
                            {
                                string isleader = dtCopyViewunderwriter.Rows[j]["Isleader"].ToString();
                                if (isleader == "Y")
                                {

                                    string per = "%";
                                    string s = " - ";
                                    string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["UWShare"].ToString()));
                                    checkisleader = "(Leader)";
                                    string underwritername = dtCopyViewunderwriter.Rows[j]["UnderWriterName"].ToString() + checkisleader + s + undersharepercentage + per;
                                    drr["underwriternamevalue1"] = underwritername;




                                }
                                else
                                {
                                    string per = "%";
                                    string s = " - ";
                                    string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["UWShare"].ToString()));

                                    string underwritername = dtCopyViewunderwriter.Rows[j]["UnderWriterName"].ToString() + s + undersharepercentage + per;
                                    drr["underwriternamevalue1"] = underwritername;
                                }


                                //  drr["sharepercentagevalue1"] = undersharepercentage;
                                string uwritercode = dtCopyViewunderwriter.Rows[j]["Underwritercode"].ToString();
                                drr["underwritercodevalue1"] = uwritercode;
                            }

                            if (dtViewTable1 != null)
                            {

                                drr["header1"] = "Brokerage";
                                drr["footer1"] = "This is a computer generated printout and no signature is required.";
                                if (j == 0)
                                {
                                    textBox65.Visible = true;
                                    drr["stumpvaluename1"] = "Stump Duty";
                                    drr["grosspremium1"] = "Gross Premium";
                                    drr["gst1"] = "GST";
                                    drr["Servicefee1"] = "Service Fee GST";

                                    drr["discount1"] = "Discount";
                                    drr["customerpremium1"] = "Customer Premium";

                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()) == 0.0)
                                    {
                                        textBox36.Visible = false;
                                        textBox57.Visible = false;


                                    }
                                    else
                                    {
                                        string stumpduty = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["StampDuty"].ToString()));
                                        drr["stumpvaluevalue1"] = stumpduty;
                                    }




                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()) == 0.0)
                                    {
                                        textBox45.Visible = false;
                                        textBox46.Visible = false;


                                    }
                                    else
                                    {

                                        string servicefeegst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ServiceFeeGSTAmount"].ToString()));
                                        drr["Servicefeevalue1"] = servicefeegst;
                                    }


                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                                    {
                                        textBox48.Visible = false;
                                        textBox49.Visible = false;


                                    }
                                    else
                                    {

                                        string disc = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ClientDiscountAmount"].ToString()));
                                        drr["discountvalue1"] = disc;
                                    }



                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                                    {
                                        textBox41.Visible = false;
                                        textBox42.Visible = false;


                                    }
                                    else
                                    {
                                        string isurergst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["InsurerGSTAmount"].ToString()));
                                        drr["insurergstvalue1"] = isurergst;
                                    }






                                    string grosspre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["PremiumWithoutGST"].ToString()));
                                    drr["grosspremiumValue1"] = grosspre;



                                    string customerpre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["DueFromClient"].ToString()));
                                    drr["customerpremiumvalue1"] = customerpre;

                                    string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ServiceFee"].ToString()));

                                    drr["serviceufeevalue1"] = servicefeevalue;
                                    string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["policycharge"].ToString()));
                                    drr["otherchargesvalue1"] = policycharge;

                                }
                                else
                                {


                                    string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ServiceFee"].ToString()));

                                    drr["serviceufeevalue1"] = servicefeevalue;

                                    string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["policycharge"].ToString()));
                                    drr["otherchargesvalue1"] = policycharge;

                                }


                            }
                            if (dsObj.Tables[2].Rows.Count > 0)
                            {
                                string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                                string businessType4 = string.Empty;
                                //int tblCount = dsObj.Tables.Count;
                                if (dsObj.Tables[9].Rows.Count > 0)
                                    businessType4 = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                                if (businessType4 == "N")
                                {
                                    businessType4 = "New Business";
                                }
                                if (businessType4 == "P")
                                {
                                    businessType4 = "Expanded";
                                }
                                if (businessType4 == "R")
                                {
                                    businessType4 = "Renewal";
                                }



                                string businessType4value = businessType4;
                                drr["policystatusvalue1"] = businessType4value;


                            }

                        }
                    }

                    #endregion
                }



            }
        }









        #region Installment Section
        public DebitNoteRptBillingInstallment(DataSet dsObj, string strClientCode, string strCheckedInstl, String clientFlag, string installment)
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

                    txtvoice.Value = "CREDIT NOTE";
                    txtdebitno.Value = "Credit Note No";
                    txtdebitnotedate.Value = "Credit Note Date";

                    //textBox5.Value = "";

                    //textBox2.Visible = false;
                    //textBox3.Value = "";
                    //textBox4.Value = "";                    
                    //textBox23.Value = "";

                    //textBox5.Value = "";                   

                    //tablepremium.Visible = false;
                    //table1.Visible = false;
                    //panel3.Visible = false;
                    //panel4.Visible = false;

                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;

                    textBox23.Visible = true;


                    textBox5.Visible = true;

                    txtgst.Visible = false;
                }
                else
                {

                    txtvoice.Value = "DEBIT NOTE";
                    txtdebitno.Value = "Debit Note No";
                    txtdebitnotedate.Value = "Debit Note Date";

                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;

                    textBox23.Visible = true;


                    textBox5.Visible = true;

                    txtgst.Visible = false;
                    //textBox30.Visible = false;

                }


                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();


                DataView dvaddress = new DataView(dsObj.Tables[1]);

                DataTable dtAddressTable = dvaddress.ToTable();

                if (dtAddressTable != null)
                {

                    txtClientName.Value = dtAddressTable.Rows[0]["TopCompanyName"].ToString();
                    txtCompAddr.Value = dtAddressTable.Rows[0]["CompanyAdd2"].ToString();
                    txtCompanyAddress3.Value = dtAddressTable.Rows[0]["CompanyAdd3"].ToString();

                }




                var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";

                DataView dv = new DataView(dsObj.Tables[0]);

                dv.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";

                DataView dvInst = new DataView(dsObj.Tables[0]);
                dvInst.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTableInst = dvInst.ToTable();

                DataTable dtViewTable = dv.ToTable();
                if (dtViewTable != null)
                {
                    //txtCompAddr.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                    txtClientAdd2.Value = dtViewTable.Rows[0]["BillingAddressFirst"].ToString();
                    txtClientAdd3.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                    txtcountry.Value = dtViewTable.Rows[0]["Countrypostal"].ToString();
                    // txtpostalcode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    txtdebitnotevalue.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                    txtdebitdatevalue.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                    txtclientcodevalue.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                    txtslipno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    //txtcovernoteno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                   // txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    if (dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() != "")
                        txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    else
                        txtSer.Visible = false;

                    txtinsuredname.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                    // txtclsinsurancevalue.Value = dtViewTable.Rows[0]["SubClassName"].ToString();
                    txtInstalmentValue.Value = "0" + dtViewTable.Rows[0]["instno"].ToString().Trim() + " of " + "0" + dtViewTableInst.Rows.Count;
                    string str = dtViewTable.Rows[0]["SubClassName"].ToString().Trim();
                    string removecomma = "";
                    if (str.Contains(","))
                        removecomma = str.Remove(str.Length - 1);
                    else
                        removecomma = str;

                    if (!removecomma.Contains("Please"))
                        txtclsinsurancevalue.Value = removecomma;
                    //txtpolicynovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
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
                    // txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();

                    if (dtViewTable.Rows.Count > 0)
                    {
                        intnumber = dtViewTable.Rows.Count;
                        for (int i = 0; i < intnumber; i++)
                        {
                            string isleader = dtViewTable.Rows[i]["Isleader"].ToString();
                            if (intnumber == 1)
                                txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    //  txtleader.Value = "(Leader)";
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }





                    if (dsObj.Tables[2].Rows.Count > 0)
                    {
                        if (dtViewTable.Rows[0]["EndorsementRemark"].ToString() != "")
                            txtpolicydescvalue.Value = dsObj.Tables[2].Rows[0]["EndorsementRemark"].ToString();
                        else
                        {
                            txtpolicydesc.Visible = false;
                            textBox21.Visible = false;
                        }
                    }
                    else
                    {
                        if (dtViewTable.Rows[0]["Remarks"].ToString() != "")
                            txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                        else
                        {
                            txtpolicydesc.Visible = false;
                            textBox21.Visible = false;
                            txtpolicydescvalue.Visible = false;
                        }
                    }
                    if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
                    {

                        if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() != "")
                        {
                            txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString();
                            txtPOITo.Value = dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString();
                            if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() == "" || dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString() == "")
                                txtTextMiddle.Visible = false;
                        }
                    }
                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;
                   // txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                }
                if (dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString() == "0.00")
                {
                    txtsuminsured.Visible = false;
                    textBox18.Visible = false;
                    txtsuminsuredvalue.Visible = false;
                }
                else
                    txtsuminsuredvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString()));

                if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
                {
                }
                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                // txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[2].Rows[0]["PremiumWithoutGST"].ToString()));

                DataView dv1 = new DataView(dsObj.Tables[3]);
                dv1.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";
                DataTable dtViewTable1 = dv1.ToTable();
                if (dtViewTable1 != null)
                {
                    txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {
                        txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    {
                        txtdiscount.Visible = false;
                        txtdiscountvalue.Visible = false;
                        textBox13.Visible = false;
                    }
                    else
                    {
                        txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {
                        txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                    }

                    txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

                }
                txtstampdutyvalue.Visible = false;

                //   txtservicefeevalue.Visible =false; 
                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
                textBox62.Visible = false;
                //textBox32.Visible = false;
                txtdiscvalue.Visible = false;
                txtotherharge.Visible = false;
                txtcustvalue.Visible = false;
                txtpolicyvalue.Visible = false;
                txtstampvalue.Visible = false;
                txtgrossp.Visible = false;
                txtgst.Visible = false;
                txtservicegst.Visible = false;
                txtdisc.Visible = false;
                txtcust.Visible = false;
                txtSerFee.Visible = false;
                txtbrokage.Visible = false;
                //  textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;
                txtInstalment.Visible = true;
                txtInstalmentValue.Visible = true;
                txtduedate.Visible = false;
                txtduedatevalue.Visible = false;
                if (clientFlag == "FileCopy")
                {

                    txtfilecopyvalue.Value = "(File Copy)";

                    txtstampdutyvalue.Visible = false;

                    //   txtservicefeevalue.Visible =false; 
                    txtgrosspvalue.Visible = true;
                    //txtbrokageper.Visible =false; 
                    txtbrokaragevalue.Visible = true;
                    txtGstvalue.Visible = true;
                    txtgstbrokerageper.Visible = true;
                    txtbrogevalue.Visible = true;
                    textBox62.Visible = true;
                    //textBox32.Visible = true;
                    txtdiscvalue.Visible = true;
                    txtotherharge.Visible = true;
                    txtcustvalue.Visible = true;
                    txtpolicyvalue.Visible = true;
                    txtstampvalue.Visible = true;
                    txtgrossp.Visible = true;
                    txtgst.Visible = true;
                    txtservicegst.Visible = true;
                    txtdisc.Visible = true;
                    txtcust.Visible = true;
                    txtSerFee.Visible = true;
                    txtbrokage.Visible = true;
                    //textBox7.Visible = true;
                    txtbro.Visible = true;
                    txtothervalue.Visible = true;
                    txtpolicystatus.Visible = true;

                    if (dsObj.Tables.Count > 8)
                    {
                        DataView dv2 = new DataView(dsObj.Tables[8]);

                        DataTable dtIntroducer = dv2.ToTable();
                        int icount = 0;
                        //tblAgent.DataSource = dtIntroducer;
                        int Rows = dtIntroducer.Rows.Count;

                        DataColumn dc = new DataColumn("AgentCount", typeof(String));
                        DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

                        dtIntroducer.Columns.Add(dc);
                        dtIntroducer.Columns.Add(dc1);
                        for (int i = 0; i < Rows; i++)
                        {
                            StringBuilder sb = new StringBuilder();
                            if (dsObj.Tables[6].Rows.Count > 0)
                            {
                                //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC")
                                //{
                                string agentcode = dsObj.Tables[4].Rows[i]["agentcode"].ToString();
                                DataRow drintro = dtIntroducer.Rows[i];
                                drintro["agentcode"] = agentcode;
                                //}


                                DataRow dr = dtIntroducer.Rows[i];
                                string agent = "AGENT";
                                string Comm = "AGENTCOMM";
                                int sum = i + 1;
                                dr["AgentCount"] = agent + sum;
                                dr["AgentCommision"] = Comm + sum;
                            }


                        }



                    }

                    if (dsObj.Tables.Count > 4 && dsObj.Tables[8].Rows.Count == 0)
                    {
                        DataView dv3 = new DataView(dsObj.Tables[4]);

                        DataTable dtIntroducer = dv3.ToTable();
                        int icount = 0;
                        //tblAgent.DataSource = dtIntroducer;
                        int Rows = dtIntroducer.Rows.Count;


                        DataColumn dc = new DataColumn("AgentCount", typeof(String));
                        DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

                        dtIntroducer.Columns.Add(dc);
                        dtIntroducer.Columns.Add(dc1);

                        for (int i = 0; i < Rows; i++)
                        {
                            StringBuilder sb = new StringBuilder();

                            if (dsObj.Tables[7].Rows.Count > 0 && dsObj.Tables[6].Rows.Count == 0)
                            {
                                string agentcode = dsObj.Tables[4].Rows[i]["agentname"].ToString();
                                DataRow drintroname = dtIntroducer.Rows[i];
                                drintroname["agentcode"] = agentcode;
                            }


                            DataRow dr = dtIntroducer.Rows[i];
                            string agent = "AGENT";
                            string Comm = "AGENTCOMM";
                            int sum = i + 1;
                            dr["AgentCount"] = agent + sum;
                            dr["AgentCommision"] = Comm + sum;


                        }
                    }

                    if (dsObj.Tables.Count > 5)
                    {
                        DataView dv4 = new DataView(dsObj.Tables[5]);

                        DataTable dtCopyViewIntroducer = dv4.ToTable();
                        //tblunderwriterlist.DataSource = dtCopyViewIntroducer;
                        int Rows = dtCopyViewIntroducer.Rows.Count;

                        for (int i = 0; i < Rows; i++)
                        {

                            textBox7.Value = dtCopyViewIntroducer.Rows[0]["Underwritername"].ToString();
                            //  textBox32.Value = dtCopyViewIntroducer.Rows[0]["grosspremiumpercentage"].ToString();
                            //   textBox33.Value = dtCopyViewIntroducer.Rows[0]["underwritername"].ToString();
                            textBox7.Value = "GROSS PREMIUM" + i.ToString();
                            //   textBox34.Value = dtCopyViewIntroducer.Rows[0]["PremiumBalance"].ToString();

                            if (dtViewTable1 != null)
                            {
                                txtstampdutyvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()));
                                txtserfeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                                txtgrosspvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["TotalPremium"].ToString()));
                                txtbrokageper.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["uwbrokerage"].ToString()));
                                txtbrokaragevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["uwbrokerageamount"].ToString()));
                                txtGstvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                                txtgstbrokerageper.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["BrokerGST"].ToString()));
                                txtbrogevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["BrokerGSTAmount"].ToString()));
                                //  txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["specialDiscountAmount"].ToString();
                                txtdiscvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                                textBox62.Value = dtViewTable1.Rows[0]["BrokerGST"].ToString() + " %";
                                txtothervalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["policycharge"].ToString()));
                                txtcustvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                                txtsergstvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                            }
                            //string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                            string businessType = string.Empty;
                            //int tblCount = dsObj.Tables.Count;
                            if (dsObj.Tables[9].Rows.Count > 0)
                                businessType = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                            if (businessType == "N")
                            {
                                businessType = "New Business";
                            }
                            if (businessType == "P")
                            {
                                businessType = "Expanded";
                            }
                            if (businessType == "R")
                            {
                                businessType = "Renewal";
                            }


                            txtpolicyvalue.Value = businessType;

                        }

                    }
                }



            }
            else
            {
                txtvoice.Value = "DEBIT NOTE";
                txtdebitno.Value = "Debit Note No";
                txtdebitnotedate.Value = "Debit Note Date";
                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();

                //  txtClientName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
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


                DataView dv = new DataView(dsObj.Tables[0]);
                dv.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";
                DataTable dtViewTable = dv.ToTable();

                DataView dvInst1 = new DataView(dsObj.Tables[0]);
                dvInst1.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTableInst1 = dvInst1.ToTable();


                if (dtViewTable != null)
                {
                    //txtCompAddr.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();

                    txtClientAdd2.Value = dtViewTable.Rows[0]["BillingAddressFirst"].ToString();
                    txtClientAdd3.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                    txtcountry.Value = dtViewTable.Rows[0]["Countrypostal"].ToString();
                    // txtpostalcode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    txtdebitnotevalue.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                    txtdebitdatevalue.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                    txtclientcodevalue.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                    txtslipno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                    //  txtcovernoteno.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                   // txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    if (dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() != "")
                        txtservicervalue.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();
                    else
                        txtSer.Visible = false;
                    txtinsuredname.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                    //  txtclsinsurancevalue.Value = dtViewTable.Rows[0]["SubClassName"].ToString();
                    txtInstalmentValue.Value = "0" + dtViewTable.Rows[0]["instno"].ToString().Trim() + " of " + "0" + dtViewTableInst1.Rows.Count;
                    string str = dtViewTable.Rows[0]["SubClassName"].ToString().Trim();
                    string removecomma = "";
                    if (str.Contains(","))
                        removecomma = str.Remove(str.Length - 1);
                    else
                        removecomma = str;

                    if (!removecomma.Contains("Please"))
                        txtclsinsurancevalue.Value = removecomma;

                    //txtpolicynovalue.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
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
                    //   txtinsurervalue.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();


                    if (dtViewTable.Rows.Count > 0)
                    {
                        intnumber = dtViewTable.Rows.Count;
                        for (int i = 0; i < intnumber; i++)
                        {
                            string isleader = dtViewTable.Rows[i]["Isleader"].ToString();
                            if (intnumber == 1)
                                txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString();
                            else
                            {
                                if (isleader == "Y")
                                {
                                    //txtleader.Value = "(Leader)";
                                    string lea = "(Leader)";
                                    string space = " ";
                                    txtinsurervalue.Value = dtViewTable.Rows[i]["UnderWriterName"].ToString() + space + lea;

                                }
                            }
                        }

                    }

                    if (dtViewTable.Rows[0]["Remarks"].ToString() != "")
                        txtpolicydescvalue.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                    else
                    {
                        txtpolicydesc.Visible = false;
                        textBox21.Visible = false;
                        txtpolicydescvalue.Visible = false;
                    }
                    if (dtViewTable.Rows[0]["DueDate"].ToString() != "")
                    {
                        txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
                    }
                    else
                        txtduedate.Visible = false;
                    //txtduedatevalue.Value = dtViewTable.Rows[0]["DueDate"].ToString();
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
                        if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() == "" || dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString() == "")
                            txtTextMiddle.Visible = false;
                    }
                }

                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();

                DataView dv1 = new DataView(dsObj.Tables[3]);

                dv1.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";
                // dv1.RowFilter = "ClientCode = '" + strClientCode + "' ";

                DataTable dtViewTable1 = dv1.ToTable();
                if (dtViewTable1 != null)
                {
                    txtpremiumvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()) == 0.0)
                    {
                        txtservicefeevalue.Visible = false;
                        txtserviceFee.Visible = false;
                        textBox11.Visible = false;
                    }
                    else
                    {
                        txtservicefeevalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFee"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                    {
                        txtdiscount.Visible = false;
                        txtdiscountvalue.Visible = false;
                        textBox13.Visible = false;
                    }
                    else
                    {
                        txtdiscountvalue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    }
                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                    {
                        txtGSTText.Visible = false;
                        textBox24.Visible = false;
                        txtGSTAmt.Visible = false;
                    }
                    else
                    {
                        txtGSTAmt.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()));
                    }

                    txttotaldueamount.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

                }



                if (dsObj.Tables[6].Rows.Count == 0)
                {

                }

                txtstampdutyvalue.Visible = false;

                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
                textBox62.Visible = false;
                //textBox32.Visible = false;
                txtdiscvalue.Visible = false;
                txtotherharge.Visible = false;
                txtcustvalue.Visible = false;
                txtpolicyvalue.Visible = false;
                txtstampvalue.Visible = false;
                txtgrossp.Visible = false;
                txtgst.Visible = false;
                txtservicegst.Visible = false;
                txtdisc.Visible = false;
                txtcust.Visible = false;
                txtSerFee.Visible = false;
                txtbrokage.Visible = false;
                //textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;
                table1.Visible = false;
                tablepremium.Visible = false;

                if (clientFlag == "FileCopy")
                {

                    #region dynamically bind table for installmentwise

                    txtfilecopyvalue.Value = "(File Copy)";

                    txtstampdutyvalue.Visible = true;

                    txtgrosspvalue.Visible = true;

                    txtbrokaragevalue.Visible = true;
                    txtGstvalue.Visible = true;
                    txtgstbrokerageper.Visible = true;
                    txtbrogevalue.Visible = true;
                    textBox62.Visible = true;
                    //textBox32.Visible = true;
                    txtdiscvalue.Visible = true;
                    txtotherharge.Visible = true;
                    txtcustvalue.Visible = true;
                    txtpolicyvalue.Visible = true;
                    txtstampvalue.Visible = true;
                    txtgrossp.Visible = true;
                    txtgst.Visible = true;
                    txtservicegst.Visible = true;
                    txtdisc.Visible = true;
                    txtcust.Visible = true;
                    txtSerFee.Visible = true;
                    txtbrokage.Visible = true;

                    txtbro.Visible = true;
                    txtothervalue.Visible = true;
                    txtpolicystatus.Visible = true;

                    if (dsObj.Tables.Count > 5)
                    {

                        DataView dv4 = new DataView(dsObj.Tables[12]);
                        dv4.RowFilter = "sno<3 and instno='" + strCheckedInstl + "'";
                        //dv4.RowFilter = " instno='" + strCheckedInstl + "'";
                        dtCopyViewunderwriter = new DataTable();
                        dtCopyViewunderwriter = dv4.ToTable();
                        tablepremium.DataSource = dtCopyViewunderwriter;
                        Rows = dtCopyViewunderwriter.Rows.Count;
                        DataColumn header = new DataColumn("header", typeof(String));
                        DataColumn footer = new DataColumn("footer", typeof(String));
                        DataColumn stumpvaluename = new DataColumn("stumpvaluename", typeof(String));
                        DataColumn grosspremium = new DataColumn("grosspremium", typeof(String));
                        DataColumn grosspremiumValue = new DataColumn("grosspremiumValue", typeof(String));
                        DataColumn stumpvaluevalue = new DataColumn("stumpvaluevalue", typeof(String));

                        DataColumn gst = new DataColumn("gst", typeof(String));
                        DataColumn gstvalue = new DataColumn("gstvalue", typeof(String));
                        DataColumn Servicefee = new DataColumn("Servicefee", typeof(String));
                        DataColumn Servicefeevalue = new DataColumn("Servicefeevalue", typeof(String));

                        DataColumn discount = new DataColumn("discount", typeof(String));
                        DataColumn discountvalue = new DataColumn("discountvalue", typeof(String));
                        DataColumn customerpremium = new DataColumn("customerpremium", typeof(String));
                        DataColumn customerpremiumvalue = new DataColumn("customerpremiumvalue", typeof(String));
                        DataColumn servicefeeu = new DataColumn("servicefeeu", typeof(String));
                        DataColumn serviceufeevalue = new DataColumn("serviceufeevalue", typeof(String));
                        DataColumn brokeragename = new DataColumn("brokeragename", typeof(String));
                        DataColumn brokeragevalue = new DataColumn("brokeragevalue", typeof(String));
                        DataColumn gstu = new DataColumn("gstu", typeof(String));
                        DataColumn gstuvalue = new DataColumn("gstuvalue", typeof(String));
                        DataColumn onbrokerage = new DataColumn("onbrokerage", typeof(String));                        
                        DataColumn onbrokeragevalue = new DataColumn("onbrokeragevalue", typeof(String));
                        DataColumn onInsrurGST = new DataColumn("onInsrurGST", typeof(String));
                        DataColumn othercharges = new DataColumn("othercharges", typeof(String));
                        DataColumn otherchargesvalue = new DataColumn("otherchargesvalue", typeof(String));
                        DataColumn policystatus = new DataColumn("policystatus", typeof(String));
                        DataColumn policystatusvalue = new DataColumn("policystatusvalue", typeof(String));
                        DataColumn grosspremiumu = new DataColumn("grosspremiumu", typeof(String));
                        DataColumn grosspremiumuvalue = new DataColumn("grosspremiumuvalue", typeof(String));

                        DataColumn underwriternamevalue = new DataColumn("underwriternamevalue", typeof(String));

                        DataColumn underwritercodevalue = new DataColumn("underwritercodevalue", typeof(String));
                        DataColumn uwbrokerage = new DataColumn("uwbrokerage", typeof(String));
                        DataColumn insurergstvalue = new DataColumn("insurergstvalue", typeof(String));


                        dtCopyViewunderwriter.Columns.Add(insurergstvalue);

                        dtCopyViewunderwriter.Columns.Add(uwbrokerage);

                        dtCopyViewunderwriter.Columns.Add(underwriternamevalue);

                        dtCopyViewunderwriter.Columns.Add(underwritercodevalue);

                        dtCopyViewunderwriter.Columns.Add(header);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluename);
                        dtCopyViewunderwriter.Columns.Add(grosspremium);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumValue);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluevalue);
                        dtCopyViewunderwriter.Columns.Add(Servicefee);
                        dtCopyViewunderwriter.Columns.Add(Servicefeevalue);

                        dtCopyViewunderwriter.Columns.Add(gst);
                        dtCopyViewunderwriter.Columns.Add(gstvalue);

                        dtCopyViewunderwriter.Columns.Add(discount);
                        dtCopyViewunderwriter.Columns.Add(discountvalue);
                        dtCopyViewunderwriter.Columns.Add(customerpremium);
                        dtCopyViewunderwriter.Columns.Add(customerpremiumvalue);
                        dtCopyViewunderwriter.Columns.Add(servicefeeu);
                        dtCopyViewunderwriter.Columns.Add(serviceufeevalue);
                        dtCopyViewunderwriter.Columns.Add(brokeragename);
                        dtCopyViewunderwriter.Columns.Add(brokeragevalue);
                        dtCopyViewunderwriter.Columns.Add(gstu);
                        dtCopyViewunderwriter.Columns.Add(gstuvalue);
                        dtCopyViewunderwriter.Columns.Add(onbrokerage);
                        dtCopyViewunderwriter.Columns.Add(onInsrurGST);
                        dtCopyViewunderwriter.Columns.Add(onbrokeragevalue);
                        dtCopyViewunderwriter.Columns.Add(othercharges);
                        dtCopyViewunderwriter.Columns.Add(otherchargesvalue);
                        dtCopyViewunderwriter.Columns.Add(policystatus);
                        dtCopyViewunderwriter.Columns.Add(policystatusvalue);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumu);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumuvalue);
                        dtCopyViewunderwriter.Columns.Add(footer);
                        for (int i = 0; i < Rows; i++)
                        {

                            if (i < 2)
                            {
                                panel3.Visible = true;
                                tablepremium.Visible = true;
                                DataRow dr = dtCopyViewunderwriter.Rows[i];

                                dr["servicefeeu"] = "Service Fee";
                                dr["brokeragename"] = "Brokerage";
                                dr["gstu"] = "GST";
                                dr["onbrokerage"] = "On Brokerage";
                                dr["othercharges"] = "Other Charges";
                                dr["policystatus"] = "Policy Status";
                                //int sum = i + 1;
                                //dr["grosspremiumu"] = "Gross Premium" + sum.ToString();

                                //dr["grosspremiumuvalue"] = dtCopyViewunderwriter.Rows[i]["Premium"].ToString();

                                int sum = i + 1;
                                dr["grosspremiumu"] = "Gross Premium" + sum.ToString();

                                dr["grosspremiumuvalue"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["Premium"].ToString()));

                                string uwbrokerageamount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["Brokerage"].ToString()));
                                dr["brokeragevalue"] = uwbrokerageamount;
                                string BrokerGSTAmount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerGSTAmount"].ToString()));
                                dr["gstuvalue"] = BrokerGSTAmount;
                                string gvalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerGST"].ToString()));
                                dr["gstvalue"] = gvalue;
                                string InsureGst = dtCopyViewunderwriter.Rows[i]["BrokerGST"].ToString();
                                dr["onInsrurGST"] = InsureGst + " %";
                                string uwbrok = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["BrokerageRate"].ToString()));
                                dr["uwbrokerage"] = uwbrok;


                                if (dtCopyViewunderwriter != null)
                                {
                                    string isleader = dtCopyViewunderwriter.Rows[i]["Isleader"].ToString();
                                    if (isleader == "Y")
                                    {

                                        string per = "%";
                                        string s = " - ";
                                        string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["UWShare"].ToString()));
                                        checkisleader = "(Leader)";
                                        string underwritername = dtCopyViewunderwriter.Rows[i]["UnderWriterName"].ToString() + checkisleader + s + undersharepercentage + per;
                                        dr["underwriternamevalue"] = underwritername;
                                    }
                                    else
                                    {

                                        string per = "%";
                                        string s = " - ";
                                        string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[i]["UWShare"].ToString()));

                                        string underwritername = dtCopyViewunderwriter.Rows[i]["UnderWriterName"].ToString() + s + undersharepercentage + per;
                                        dr["underwriternamevalue"] = underwritername;
                                    }



                                    // dr["sharepercentagevalue"] = undersharepercentage;
                                    string uwritercode = dtCopyViewunderwriter.Rows[i]["Underwritercode"].ToString();
                                    dr["underwritercodevalue"] = uwritercode;
                                }

                                if (dtViewTable1 != null)
                                {
                                    if (i == 0)
                                    {
                                        dr["header"] = "Brokerage";
                                        dr["footer"] = "This is a computer generated printout and no signature is required.";
                                        dr["stumpvaluename"] = "Stump Duty";
                                        dr["grosspremium"] = "Gross Premium";
                                        dr["gst"] = "GST";
                                        dr["Servicefee"] = "Service Fee GST";

                                        dr["discount"] = "Discount";
                                        dr["customerpremium"] = "Customer Premium";
                                        string grosspre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));
                                        dr["grosspremiumValue"] = grosspre;


                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()) == 0.0)
                                        {
                                            txtstampvalue.Visible = false;
                                            txtstampdutyvalue.Visible = false;

                                        }
                                        else
                                        {
                                            string stumpduty = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()));
                                            dr["stumpvaluevalue"] = stumpduty;
                                        }




                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()) == 0.0)
                                        {
                                            txtservicegst.Visible = false;
                                            txtsergstvalue.Visible = false;

                                        }
                                        else
                                        {

                                            string servicefeegst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                                            dr["Servicefeevalue"] = servicefeegst;
                                        }


                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                                        {
                                            txtdisc.Visible = false;
                                            txtdiscvalue.Visible = false;

                                        }
                                        else
                                        {

                                            string disc = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                                            dr["discountvalue"] = disc;
                                        }



                                        if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                                        {
                                            txtgst.Visible = false;
                                            txtGstvalue.Visible = false;


                                        }
                                        else
                                        {

                                            string isurergst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["InsurerGSTAmount"].ToString()));
                                            dr["insurergstvalue"] = isurergst;
                                        }




                                        string customerpre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                                        dr["customerpremiumvalue"] = customerpre;





                                        //textBox31.Visible = false;
                                        textBox10.Visible = true;
                                    }
                                    else
                                    {

                                        if (dtViewTable.Rows.Count > 1)
                                        {
                                            //textBox31.Visible = true;
                                            string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["ServiceFee"].ToString()));

                                            dr["serviceufeevalue"] = servicefeevalue;

                                            string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[i]["policycharge"].ToString()));
                                            dr["otherchargesvalue"] = policycharge;

                                        }
                                    }



                                }
                                if (dsObj.Tables[2].Rows.Count > 0)
                                {
                                    string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                                    string businessType4 = string.Empty;
                                    //int tblCount = dsObj.Tables.Count;
                                    if (dsObj.Tables[9].Rows.Count > 0)
                                        businessType4 = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                                    if (businessType4 == "N")
                                    {
                                        businessType4 = "New Business";
                                    }
                                    if (businessType4 == "P")
                                    {
                                        businessType4 = "Expanded";
                                    }
                                    if (businessType4 == "R")
                                    {
                                        businessType4 = "Renewal";
                                    }



                                    string businessType4value = businessType4;
                                    dr["policystatusvalue"] = businessType4value;


                                }
                            }
                        }

                        #region declare data

                        DataView dv5 = new DataView(dsObj.Tables[12]);
                        dv5.RowFilter = "sno>2 and instno='" + strCheckedInstl + "'";
                        //dv5.RowFilter = "instno='" + strCheckedInstl + "'";
                        dtCopyViewunderwriter = new DataTable();
                        dtCopyViewunderwriter = dv5.ToTable();
                        table1.DataSource = dtCopyViewunderwriter;
                        Rows1 = dtCopyViewunderwriter.Rows.Count;

                        DataColumn header1 = new DataColumn("header1", typeof(String));
                        DataColumn footer1 = new DataColumn("footer1", typeof(String));
                        DataColumn stumpvaluename1 = new DataColumn("stumpvaluename1", typeof(String));
                        DataColumn grosspremium1 = new DataColumn("grosspremium1", typeof(String));
                        DataColumn grosspremiumValue1 = new DataColumn("grosspremiumValue1", typeof(String));
                        DataColumn stumpvaluevalue1 = new DataColumn("stumpvaluevalue1", typeof(String));

                        DataColumn gst1 = new DataColumn("gst1", typeof(String));
                        DataColumn gstvalue1 = new DataColumn("gstvalue1", typeof(String));
                        DataColumn Servicefee1 = new DataColumn("Servicefee1", typeof(String));
                        DataColumn Servicefeevalue1 = new DataColumn("Servicefeevalue1", typeof(String));

                        DataColumn discount1 = new DataColumn("discount1", typeof(String));
                        DataColumn discountvalue1 = new DataColumn("discountvalue1", typeof(String));
                        DataColumn customerpremium1 = new DataColumn("customerpremium1", typeof(String));
                        DataColumn customerpremiumvalue1 = new DataColumn("customerpremiumvalue1", typeof(String));
                        DataColumn servicefeeu1 = new DataColumn("servicefeeu1", typeof(String));
                        DataColumn serviceufeevalue1 = new DataColumn("serviceufeevalue1", typeof(String));
                        DataColumn brokeragename1 = new DataColumn("brokeragename1", typeof(String));
                        DataColumn brokeragevalue1 = new DataColumn("brokeragevalue1", typeof(String));
                        DataColumn gstu1 = new DataColumn("gstu1", typeof(String));
                        DataColumn gstuvalue1 = new DataColumn("gstuvalue1", typeof(String));
                        DataColumn onbrokerage1 = new DataColumn("onbrokerage1", typeof(String));                       
                        DataColumn onbrokeragevalue1 = new DataColumn("onbrokeragevalue1", typeof(String));
                        DataColumn onInsrurGST1 = new DataColumn("onInsrurGST1", typeof(String));
                        DataColumn othercharges1 = new DataColumn("othercharges1", typeof(String));
                        DataColumn otherchargesvalue1 = new DataColumn("otherchargesvalue1", typeof(String));
                        DataColumn policystatus1 = new DataColumn("policystatus1", typeof(String));
                        DataColumn policystatusvalue1 = new DataColumn("policystatusvalue1", typeof(String));
                        DataColumn grosspremiumu1 = new DataColumn("grosspremiumu1", typeof(String));
                        DataColumn grosspremiumuvalue1 = new DataColumn("grosspremiumuvalue1", typeof(String));

                        DataColumn underwriternamevalue1 = new DataColumn("underwriternamevalue1", typeof(String));
                        //   DataColumn sharepercentagevalue1 = new DataColumn("sharepercentagevalue1", typeof(String));
                        DataColumn underwritercodevalue1 = new DataColumn("underwritercodevalue1", typeof(String));
                        DataColumn uwbrokerage1 = new DataColumn("uwbrokerage1", typeof(String));
                        DataColumn insurergstvalue1 = new DataColumn("insurergstvalue1", typeof(String));


                        dtCopyViewunderwriter.Columns.Add(insurergstvalue1);

                        dtCopyViewunderwriter.Columns.Add(uwbrokerage1);

                        dtCopyViewunderwriter.Columns.Add(underwriternamevalue1);
                        //   dtCopyViewunderwriter.Columns.Add(sharepercentagevalue1);
                        dtCopyViewunderwriter.Columns.Add(underwritercodevalue1);

                        dtCopyViewunderwriter.Columns.Add(header1);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluename1);
                        dtCopyViewunderwriter.Columns.Add(grosspremium1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumValue1);
                        dtCopyViewunderwriter.Columns.Add(stumpvaluevalue1);
                        dtCopyViewunderwriter.Columns.Add(Servicefee1);
                        dtCopyViewunderwriter.Columns.Add(Servicefeevalue1);

                        dtCopyViewunderwriter.Columns.Add(gst1);
                        dtCopyViewunderwriter.Columns.Add(gstvalue1);

                        dtCopyViewunderwriter.Columns.Add(discount1);
                        dtCopyViewunderwriter.Columns.Add(discountvalue1);
                        dtCopyViewunderwriter.Columns.Add(customerpremium1);
                        dtCopyViewunderwriter.Columns.Add(customerpremiumvalue1);
                        dtCopyViewunderwriter.Columns.Add(servicefeeu1);
                        dtCopyViewunderwriter.Columns.Add(serviceufeevalue1);
                        dtCopyViewunderwriter.Columns.Add(brokeragename1);
                        dtCopyViewunderwriter.Columns.Add(brokeragevalue1);
                        dtCopyViewunderwriter.Columns.Add(gstu1);
                        dtCopyViewunderwriter.Columns.Add(gstuvalue1);
                        dtCopyViewunderwriter.Columns.Add(onbrokerage1);
                        dtCopyViewunderwriter.Columns.Add(onInsrurGST1);
                        dtCopyViewunderwriter.Columns.Add(onbrokeragevalue1);
                        dtCopyViewunderwriter.Columns.Add(othercharges1);
                        dtCopyViewunderwriter.Columns.Add(otherchargesvalue1);
                        dtCopyViewunderwriter.Columns.Add(policystatus1);
                        dtCopyViewunderwriter.Columns.Add(policystatusvalue1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumu1);
                        dtCopyViewunderwriter.Columns.Add(grosspremiumuvalue1);
                        dtCopyViewunderwriter.Columns.Add(footer1);
                        #endregion


                        for (int j = 0; j < Rows1; j++)
                        {
                            panel4.Visible = true;
                            table1.Visible = true;



                            DataRow drr = dtCopyViewunderwriter.Rows[j];


                            drr["servicefeeu1"] = "Service Fee";
                            drr["brokeragename1"] = "Brokerage";
                            drr["gstu1"] = "GST";
                            drr["onbrokerage1"] = "On Brokerage";
                            drr["othercharges1"] = "Other Charges";
                            drr["policystatus1"] = "Policy Status";
                            int sum = j + 1;
                            drr["grosspremiumu1"] = "Gross Premium" + sum.ToString();

                            drr["grosspremiumuvalue1"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["Premium"].ToString()));

                            string uwbrokerageamount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["Brokerage"].ToString()));
                            drr["brokeragevalue1"] = uwbrokerageamount;
                            string BrokerGSTAmount = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerGSTAmount"].ToString()));
                            drr["gstuvalue1"] = BrokerGSTAmount;
                            string gvalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerGST"].ToString()));
                            drr["gstvalue1"] = gvalue;
                            string InsrurGST1 = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerGST"].ToString()));
                            drr["onInsrurGST1"] = InsrurGST1 + " %";                            
                            string uwbrok = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["BrokerageRate"].ToString()));
                            drr["uwbrokerage1"] = uwbrok;

                            if (dtCopyViewunderwriter != null)
                            {
                                string isleader = dtCopyViewunderwriter.Rows[j]["Isleader"].ToString();
                                if (isleader == "Y")
                                {

                                    string per = "%";
                                    string s = " - ";
                                    string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["UWShare"].ToString()));
                                    checkisleader = "(Leader)";
                                    string underwritername = dtCopyViewunderwriter.Rows[j]["UnderWriterName"].ToString() + checkisleader + s + undersharepercentage + per;
                                    drr["underwriternamevalue1"] = underwritername;




                                }
                                else
                                {
                                    string per = "%";
                                    string s = " - ";
                                    string undersharepercentage = string.Format("{0:0,0.00}", Convert.ToDouble(dtCopyViewunderwriter.Rows[j]["UWShare"].ToString()));

                                    string underwritername = dtCopyViewunderwriter.Rows[j]["UnderWriterName"].ToString() + s + undersharepercentage + per;
                                    drr["underwriternamevalue1"] = underwritername;
                                }





                                // drr["sharepercentagevalue1"] = undersharepercentage;
                                string uwritercode = dtCopyViewunderwriter.Rows[j]["Underwritercode"].ToString();
                                drr["underwritercodevalue1"] = uwritercode;
                            }

                            if (dtViewTable1 != null)
                            {

                                drr["header1"] = "Brokerage";
                                drr["footer1"] = "This is a computer generated printout and no signature is required.";

                                if (j == 0)
                                {
                                    drr["stumpvaluename1"] = "Stump Duty";
                                    drr["grosspremium1"] = "Gross Premium";
                                    drr["gst1"] = "GST";
                                    drr["Servicefee1"] = "Service Fee GST";

                                    drr["discount1"] = "Discount";
                                    drr["customerpremium1"] = "Customer Premium";

                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["StampDuty"].ToString()) == 0.0)
                                    {
                                        textBox36.Visible = false;
                                        textBox57.Visible = false;


                                    }
                                    else
                                    {
                                        string stumpduty = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["StampDuty"].ToString()));
                                        drr["stumpvaluevalue1"] = stumpduty;
                                    }




                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ServiceFeeGSTAmount"].ToString()) == 0.0)
                                    {
                                        textBox45.Visible = false;
                                        textBox46.Visible = false;


                                    }
                                    else
                                    {

                                        string servicefeegst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ServiceFeeGSTAmount"].ToString()));
                                        drr["Servicefeevalue1"] = servicefeegst;
                                    }


                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()) == 0.0)
                                    {
                                        textBox48.Visible = false;
                                        textBox49.Visible = false;


                                    }
                                    else
                                    {

                                        string disc = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ClientDiscountAmount"].ToString()));
                                        drr["discountvalue1"] = disc;
                                    }



                                    if (Convert.ToDouble(dtViewTable1.Rows[0]["InsurerGSTAmount"].ToString()) == 0.0)
                                    {
                                        textBox41.Visible = false;
                                        textBox42.Visible = false;


                                    }
                                    else
                                    {
                                        string isurergst = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["InsurerGSTAmount"].ToString()));
                                        drr["insurergstvalue1"] = isurergst;
                                    }










                                    string grosspre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["PremiumWithoutGST"].ToString()));
                                    drr["grosspremiumValue1"] = grosspre;



                                    string customerpre = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["DueFromClient"].ToString()));
                                    drr["customerpremiumvalue1"] = customerpre;

                                    textBox65.Visible = true;

                                }

                                else
                                {




                                    string servicefeevalue = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["ServiceFee"].ToString()));

                                    drr["serviceufeevalue1"] = servicefeevalue;

                                    string policycharge = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[j]["policycharge"].ToString()));
                                    drr["otherchargesvalue1"] = policycharge;
                                }


                            }
                            if (dsObj.Tables[2].Rows.Count > 0)
                            {
                                string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                                string businessType4 = string.Empty;
                                //int tblCount = dsObj.Tables.Count;
                                if (dsObj.Tables[9].Rows.Count > 0)
                                    businessType4 = dsObj.Tables[9].Rows[0]["BusinessType"].ToString();
                                if (businessType4 == "N")
                                {
                                    businessType4 = "New Business";
                                }
                                if (businessType4 == "P")
                                {
                                    businessType4 = "Penetrate";
                                }
                                if (businessType4 == "R")
                                {
                                    businessType4 = "Renewal";
                                }



                                string businessType4value = businessType4;
                                drr["policystatusvalue1"] = businessType4value;


                            }

                        }
                    }

                    #endregion
                }



            }

        }
        #endregion

    }
}