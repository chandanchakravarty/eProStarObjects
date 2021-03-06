namespace eProStarReports.Letters.Acclaim
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Premium30DaysGracePeriod.
    /// </summary>
    public partial class Premium30DaysGracePeriod : Telerik.Reporting.Report
    {
        public Premium30DaysGracePeriod()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public Premium30DaysGracePeriod(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, String Username)
        {

            InitializeComponent();
            //if (dsObj.Tables[6].Rows.Count > 0)
            //{
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "ClientCode = '" + strClientCode + "'";
            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable != null)
            {
                txtCompName.Value = dtViewTable.Rows[0]["ClientName"].ToString().ToUpper();
                txtAddress.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                txtBillingAdd2.Value = dtViewTable.Rows[0]["BillingAddress2"].ToString();
                txtBillingAdd34.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                
                if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()) && String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingPostalCode"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = "";
                }
                else if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                }
                else if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingPostalCode"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString();
                }
                else
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString() + ", " + dtViewTable.Rows[0]["BillingPostalCode"].ToString() ;
                }

                txtDocNo1.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                txtDate1.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                txtClientCode1.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                txtCoverNoteNo1.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                txtDueDate1.Value = dtViewTable.Rows[0]["DueDate"].ToString();

                //if (String.IsNullOrEmpty(dtViewTable.Rows[0]["Primary_AccountHandler"].ToString()))
                //{
                //    txtServicer1.Value = Username;
                //}
                //else
                //{
                //    txtServicer1.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() + "/" + Username;
                //}

                if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"])))
                {
                    txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"]);

                    if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"])))
                        txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"]) + "/" + Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"]);
                }
                else
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"])))
                        txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"]);
                }


                if (dtViewTable.Rows[0]["ClientContactName"].ToString() == "")
                {
                    txtAttnNo.Visible = false;
                    txtContactPersonName.Visible = false;
                }
                else
                {
                    txtAttnNo.Visible = true;
                    txtContactPersonName.Visible = true;
                    txtContactPersonName.Value = "Ms/Mr " + dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;

                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
            {
                txtEndtNo1.Visible = true;
                txtEndtNo.Visible = true;
                txtEndtNo1.Value = dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString();
            }
            else
            {
                txtEndtNo1.Visible = false;
                txtEndtNo.Visible = false;
            }

            if (dsObj.Tables[2].Rows[0]["EndorsementEffdate"].ToString() != "")
            {
                txtEndtDate1.Visible = true;
                txtEndtDate.Visible = true;
                txtEndtDate1.Value = dsObj.Tables[2].Rows[0]["EndorsementEffdate"].ToString();
            }
            else
            {
                txtEndtDate1.Visible = false;
                txtEndtDate.Visible = false;
            }
            txtBank1.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "'";
            DataTable dtViewTable1 = dv1.ToTable();


            if (dtViewTable1 != null)
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    txtBankCode.Visible = false;
                    txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    txtBankCode1.Visible = false;
                    txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "CREDIT NOTE";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    txtBankCode.Visible = true;
                    txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    txtBankCode1.Visible = true;
                    txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }
                txtPremium1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));
                //txtPremiumCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    txtCharges1.Visible = true;
                    //txtChargesCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    //txtChargesCr.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {
                    txtDiscount1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                    txtDiscount.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                //txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();

                txtTotalDue1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                //txtTotalDueCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }
                //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
                //{
                //    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                //    txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                //    txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                //    txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
                //    txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                //    txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                //    txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                //    txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                //    txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                //    txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                //    txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                //    txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                //    txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                //    txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();

                //}

                ////  tblfilecopydetail.Visible = false;


            //}
            //else
            //{
            //    txtvoice.Value = "TAX INVOICE";
            //    txtdebitno.Value = "Tax Invoice No";
            //    txtdebitnotedate.Value = "Tax Invoice Date";
            //    //}
            //    txtfilecopyvalue.Value = "FILE COPY";
            //    txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
            //    txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();

            //    txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
            //    var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
            //    txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

            //    txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
            //    txtTextTel.Value = "";
            //    txtPhone.Value = "";
            //    txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
            //    txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            //    txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
            //    txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

            //    txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
            //    txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            //    txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            //    txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            //    txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
            //    txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            //    txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
            //    txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
            //    txtpolicydescvalue.Value = "";
            //    txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    // txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
            //    txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
            //    txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
            //    txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
            //    txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
            //    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            //    txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //    txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //    txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();

            //    if (dsObj.Tables[6].Rows.Count == 0)
            //    {
            //        txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            //        txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            //        txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
            //        txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
            //        txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
            //        txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
            //        txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
            //        txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
            //        txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
            //        txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
            //    }
            //    //  tblfilecopydetail.Visible = false;
            //    tblunderwriterlist.Visible = true;
            //    tblAgent.Visible = true;

            //}
            //if (dsObj.Tables.Count > 3)
            //{
            //    txtstampdutyvalue.Value = dsObj.Tables[3].Rows[0]["StampDuty"].ToString();
            //    txtserfeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
            //    txtgrosspvalue.Value = dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();
            //    txtbrokageper.Value = dsObj.Tables[3].Rows[0]["uwbrokerage"].ToString();
            //    txtbrokaragevalue.Value = dsObj.Tables[3].Rows[0]["uwbrokerageamount"].ToString();
            //    txtGstvalue.Value = dsObj.Tables[3].Rows[0]["InsurerGSTAmount"].ToString();
            //    txtgstbrokerageper.Value = dsObj.Tables[3].Rows[0]["BrokerGST"].ToString();
            //    txtbrogevalue.Value = dsObj.Tables[3].Rows[0]["BrokerGSTAmount"].ToString();
            //    //  txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["specialDiscountAmount"].ToString();
            //    txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();

            //    txtothervalue.Value = dsObj.Tables[3].Rows[0]["policycharge"].ToString();
            //    txtcustvalue.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
            //    txtsergstvalue.Value = dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString();
            //    string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
            //    if (businessType == "N")
            //    {
            //        businessType = "New Business";
            //    }
            //    if (businessType == "P")
            //    {
            //        businessType = "Penetrate";
            //    }
            //    if (businessType == "R")
            //    {
            //        businessType = "Renewal";
            //    }


            //    txtpolicyvalue.Value = businessType;
            //    //  txtgrosspvalue.v  dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();

            //}
            //if (dsObj.Tables.Count > 8)
            //{
            //    DataView dv = new DataView(dsObj.Tables[8]);

            //    DataTable dtIntroducer = dv.ToTable();
            //    int icount = 0;
            //    tblAgent.DataSource = dtIntroducer;
            //    int Rows = dtIntroducer.Rows.Count;

            //    DataColumn dc = new DataColumn("AgentCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

            //    dtIntroducer.Columns.Add(dc);
            //    dtIntroducer.Columns.Add(dc1);
            //    for (int i = 0; i < Rows; i++)
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        if (dsObj.Tables[6].Rows.Count > 0)
            //        {
            //            //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC")
            //            //{
            //            string agentcode = dsObj.Tables[4].Rows[i]["agentcode"].ToString();
            //            DataRow drintro = dtIntroducer.Rows[i];
            //            drintro["agentcode"] = agentcode;
            //            //}


            //            DataRow dr = dtIntroducer.Rows[i];
            //            string agent = "AGENT";
            //            string Comm = "AGENTCOMM";
            //            int sum = i + 1;
            //            dr["AgentCount"] = agent + sum;
            //            dr["AgentCommision"] = Comm + sum;
            //        }


            //    }



            //}

            //if (dsObj.Tables.Count > 4 && dsObj.Tables[8].Rows.Count == 0)
            //{
            //    DataView dv = new DataView(dsObj.Tables[4]);

            //    DataTable dtIntroducer = dv.ToTable();
            //    int icount = 0;
            //    tblAgent.DataSource = dtIntroducer;
            //    int Rows = dtIntroducer.Rows.Count;


            //    DataColumn dc = new DataColumn("AgentCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

            //    dtIntroducer.Columns.Add(dc);
            //    dtIntroducer.Columns.Add(dc1);

            //    for (int i = 0; i < Rows; i++)
            //    {
            //        StringBuilder sb = new StringBuilder();

            //        if (dsObj.Tables[7].Rows.Count > 0 && dsObj.Tables[6].Rows.Count == 0)
            //        {
            //            string agentcode = dsObj.Tables[4].Rows[i]["agentname"].ToString();
            //            DataRow drintroname = dtIntroducer.Rows[i];
            //            drintroname["agentcode"] = agentcode;
            //        }


            //        DataRow dr = dtIntroducer.Rows[i];
            //        string agent = "AGENT";
            //        string Comm = "AGENTCOMM";
            //        int sum = i + 1;
            //        dr["AgentCount"] = agent + sum;
            //        dr["AgentCommision"] = Comm + sum;


            //    }
            //}

            //if (dsObj.Tables.Count > 5)
            //{
            //    DataView dv = new DataView(dsObj.Tables[5]);

            //    DataTable dtCopyViewIntroducer = dv.ToTable();
            //    tblunderwriterlist.DataSource = dtCopyViewIntroducer;
            //    int Rows = dtCopyViewIntroducer.Rows.Count;


            //    DataColumn dc = new DataColumn("UnderCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("UnderPremium", typeof(String));

            //    dtCopyViewIntroducer.Columns.Add(dc);
            //    dtCopyViewIntroducer.Columns.Add(dc1);

            //    for (int i = 0; i < Rows; i++)
            //    {

            //        DataRow dr = dtCopyViewIntroducer.Rows[i];
            //        string agent = "INSURER";
            //        string Comm = "GROSS PREMIUM";
            //        int sum = i + 1;
            //        dr["UnderCount"] = agent + sum;
            //        dr["UnderPremium"] = Comm + sum;


            //    }

            //}
        }

        public Premium30DaysGracePeriod(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, String Username,string installment)
        {

            InitializeComponent();
            //if (dsObj.Tables[6].Rows.Count > 0)
            //{
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";

            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable != null)
            {
                txtCompName.Value = dtViewTable.Rows[0]["ClientName"].ToString().ToUpper();
                txtAddress.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                txtBillingAdd2.Value = dtViewTable.Rows[0]["BillingAddress2"].ToString();
                txtBillingAdd34.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();
                if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()) && String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingPostalCode"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = "";
                }
                else if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                }
                else if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingPostalCode"].ToString()))
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString();
                }
                else
                {
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString() + "(" + dtViewTable.Rows[0]["BillingPostalCode"].ToString() + ")";
                }

                txtDocNo1.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                txtDate1.Value = dtViewTable.Rows[0]["DebitNoteDate"].ToString();
                txtClientCode1.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                txtCoverNoteNo1.Value = dtViewTable.Rows[0]["CoverNoteNo"].ToString();
                txtDueDate1.Value = dtViewTable.Rows[0]["DueDate"].ToString();

                //if (String.IsNullOrEmpty(dtViewTable.Rows[0]["Primary_AccountHandler"].ToString()))
                //{
                //    txtServicer1.Value = Username;
                //}
                //else
                //{
                //    txtServicer1.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString() + "/" + Username;
                //}

                if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"])))
                {
                    txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"]);

                    if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"])))
                        txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Primary_AccountHandler"]) + "/" + Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"]);
                }
                else
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"])))
                        txtServicer1.Value = Convert.ToString(dtViewTable.Rows[0]["Secondary_AccountHandler"]);
                }


                if (dtViewTable.Rows[0]["ClientContactName"].ToString() == "")
                {
                    txtAttnNo.Visible = false;
                    txtContactPersonName.Visible = false;
                }
                else
                {
                    txtAttnNo.Visible = true;
                    txtContactPersonName.Visible = true;
                    txtContactPersonName.Value = "Ms/Mr " + dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;

                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
            {
                txtEndtNo1.Visible = true;
                txtEndtNo.Visible = true;
                txtEndtNo1.Value = dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString();
            }
            else
            {
                txtEndtNo1.Visible = false;
                txtEndtNo.Visible = false;
            }

            if (dsObj.Tables[2].Rows[0]["EndorsementEffdate"].ToString() != "")
            {
                txtEndtDate1.Visible = true;
                txtEndtDate.Visible = true;
                txtEndtDate1.Value = dsObj.Tables[2].Rows[0]["EndorsementEffdate"].ToString();
            }
            else
            {
                txtEndtDate1.Visible = false;
                txtEndtDate.Visible = false;
            }
            txtBank1.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";

            DataTable dtViewTable1 = dv1.ToTable();


            if (dtViewTable1 != null)
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    txtBankCode.Visible = false;
                    txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    txtBankCode1.Visible = false;
                    txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "CREDIT NOTE";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    txtBankCode.Visible = true;
                    txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    txtBankCode1.Visible = true;
                    txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }
                txtPremium1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));
                //txtPremiumCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    txtCharges1.Visible = true;
                    //txtChargesCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    //txtChargesCr.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {
                    txtDiscount1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                    txtDiscount.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                //txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();

                txtTotalDue1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                //txtTotalDueCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }
            //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
            //{
            //    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            //    txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //    txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //    txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            //    txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            //    txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            //    txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
            //    txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
            //    txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
            //    txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
            //    txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
            //    txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
            //    txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
            //    txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();

            //}

            ////  tblfilecopydetail.Visible = false;


            //}
            //else
            //{
            //    txtvoice.Value = "TAX INVOICE";
            //    txtdebitno.Value = "Tax Invoice No";
            //    txtdebitnotedate.Value = "Tax Invoice Date";
            //    //}
            //    txtfilecopyvalue.Value = "FILE COPY";
            //    txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
            //    txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();

            //    txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
            //    var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
            //    txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

            //    txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
            //    txtTextTel.Value = "";
            //    txtPhone.Value = "";
            //    txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
            //    txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            //    txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
            //    txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

            //    txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
            //    txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            //    txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            //    txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            //    txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
            //    txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            //    txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
            //    txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
            //    txtpolicydescvalue.Value = "";
            //    txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    // txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //    txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
            //    txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
            //    txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
            //    txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
            //    txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
            //    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            //    txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //    txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //    txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();

            //    if (dsObj.Tables[6].Rows.Count == 0)
            //    {
            //        txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            //        txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            //        txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
            //        txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
            //        txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
            //        txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
            //        txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
            //        txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
            //        txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
            //        txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
            //    }
            //    //  tblfilecopydetail.Visible = false;
            //    tblunderwriterlist.Visible = true;
            //    tblAgent.Visible = true;

            //}
            //if (dsObj.Tables.Count > 3)
            //{
            //    txtstampdutyvalue.Value = dsObj.Tables[3].Rows[0]["StampDuty"].ToString();
            //    txtserfeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
            //    txtgrosspvalue.Value = dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();
            //    txtbrokageper.Value = dsObj.Tables[3].Rows[0]["uwbrokerage"].ToString();
            //    txtbrokaragevalue.Value = dsObj.Tables[3].Rows[0]["uwbrokerageamount"].ToString();
            //    txtGstvalue.Value = dsObj.Tables[3].Rows[0]["InsurerGSTAmount"].ToString();
            //    txtgstbrokerageper.Value = dsObj.Tables[3].Rows[0]["BrokerGST"].ToString();
            //    txtbrogevalue.Value = dsObj.Tables[3].Rows[0]["BrokerGSTAmount"].ToString();
            //    //  txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["specialDiscountAmount"].ToString();
            //    txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();

            //    txtothervalue.Value = dsObj.Tables[3].Rows[0]["policycharge"].ToString();
            //    txtcustvalue.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
            //    txtsergstvalue.Value = dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString();
            //    string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
            //    if (businessType == "N")
            //    {
            //        businessType = "New Business";
            //    }
            //    if (businessType == "P")
            //    {
            //        businessType = "Penetrate";
            //    }
            //    if (businessType == "R")
            //    {
            //        businessType = "Renewal";
            //    }


            //    txtpolicyvalue.Value = businessType;
            //    //  txtgrosspvalue.v  dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();

            //}
            //if (dsObj.Tables.Count > 8)
            //{
            //    DataView dv = new DataView(dsObj.Tables[8]);

            //    DataTable dtIntroducer = dv.ToTable();
            //    int icount = 0;
            //    tblAgent.DataSource = dtIntroducer;
            //    int Rows = dtIntroducer.Rows.Count;

            //    DataColumn dc = new DataColumn("AgentCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

            //    dtIntroducer.Columns.Add(dc);
            //    dtIntroducer.Columns.Add(dc1);
            //    for (int i = 0; i < Rows; i++)
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        if (dsObj.Tables[6].Rows.Count > 0)
            //        {
            //            //if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC")
            //            //{
            //            string agentcode = dsObj.Tables[4].Rows[i]["agentcode"].ToString();
            //            DataRow drintro = dtIntroducer.Rows[i];
            //            drintro["agentcode"] = agentcode;
            //            //}


            //            DataRow dr = dtIntroducer.Rows[i];
            //            string agent = "AGENT";
            //            string Comm = "AGENTCOMM";
            //            int sum = i + 1;
            //            dr["AgentCount"] = agent + sum;
            //            dr["AgentCommision"] = Comm + sum;
            //        }


            //    }



            //}

            //if (dsObj.Tables.Count > 4 && dsObj.Tables[8].Rows.Count == 0)
            //{
            //    DataView dv = new DataView(dsObj.Tables[4]);

            //    DataTable dtIntroducer = dv.ToTable();
            //    int icount = 0;
            //    tblAgent.DataSource = dtIntroducer;
            //    int Rows = dtIntroducer.Rows.Count;


            //    DataColumn dc = new DataColumn("AgentCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("AgentCommision", typeof(String));

            //    dtIntroducer.Columns.Add(dc);
            //    dtIntroducer.Columns.Add(dc1);

            //    for (int i = 0; i < Rows; i++)
            //    {
            //        StringBuilder sb = new StringBuilder();

            //        if (dsObj.Tables[7].Rows.Count > 0 && dsObj.Tables[6].Rows.Count == 0)
            //        {
            //            string agentcode = dsObj.Tables[4].Rows[i]["agentname"].ToString();
            //            DataRow drintroname = dtIntroducer.Rows[i];
            //            drintroname["agentcode"] = agentcode;
            //        }


            //        DataRow dr = dtIntroducer.Rows[i];
            //        string agent = "AGENT";
            //        string Comm = "AGENTCOMM";
            //        int sum = i + 1;
            //        dr["AgentCount"] = agent + sum;
            //        dr["AgentCommision"] = Comm + sum;


            //    }
            //}

            //if (dsObj.Tables.Count > 5)
            //{
            //    DataView dv = new DataView(dsObj.Tables[5]);

            //    DataTable dtCopyViewIntroducer = dv.ToTable();
            //    tblunderwriterlist.DataSource = dtCopyViewIntroducer;
            //    int Rows = dtCopyViewIntroducer.Rows.Count;


            //    DataColumn dc = new DataColumn("UnderCount", typeof(String));
            //    DataColumn dc1 = new DataColumn("UnderPremium", typeof(String));

            //    dtCopyViewIntroducer.Columns.Add(dc);
            //    dtCopyViewIntroducer.Columns.Add(dc1);

            //    for (int i = 0; i < Rows; i++)
            //    {

            //        DataRow dr = dtCopyViewIntroducer.Rows[i];
            //        string agent = "INSURER";
            //        string Comm = "GROSS PREMIUM";
            //        int sum = i + 1;
            //        dr["UnderCount"] = agent + sum;
            //        dr["UnderPremium"] = Comm + sum;


            //    }

            //}
        }
        #region Added By neetu Sinha
        #endregion
    }
}