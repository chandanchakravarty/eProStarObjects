namespace eProStarReports.Letters
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Premium_Instalment_Payment_Warranty.
    /// </summary>
    public partial class PremiumInstalmentPaymentWarranty : Telerik.Reporting.Report
    {
        public PremiumInstalmentPaymentWarranty()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PremiumInstalmentPaymentWarranty(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, String Username)
        {

            InitializeComponent();
            //if (dsObj.Tables[6].Rows.Count > 0)
            //{
            txtCompName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

            txtAddress.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();

            txtDocNo1.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
            txtDate1.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            txtClientCode1.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            txtCoverNoteNo1.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
            txtDueDate1.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            txtServicer1.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString() + "/" + Username;

            if (dsObj.Tables[0].Rows[0]["ClientContactName"].ToString() == "")
            {
                txtAttnNo.Visible = false;
                txtContactPersonName.Visible = false;
            }
            else
            {
                txtAttnNo.Visible = true;
                txtContactPersonName.Visible = true;
                txtContactPersonName.Value = dsObj.Tables[0].Rows[0]["ClientContactName"].ToString();
            }

            txtInsuredName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();

            txtClass1.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString().Replace(",", "");
            txtPolicyNo1.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
            txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();

            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "")
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

            txtDescription1.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();


            txtBank1.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();


            txtCurrecny1.Value = dsObj.Tables[0].Rows[0]["Currency"].ToString();
            txtPremium1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[3].Rows[0]["PRTotalPremium"].ToString()));

            if (Convert.ToDouble(dsObj.Tables[3].Rows[0]["Totalpolicycharge"]) > 0)
            {
                txtCharges1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[3].Rows[0]["Totalpolicycharge"].ToString()));
                txtCharges1.Visible = true;

            }
            else
            {
                txtCharges1.Visible = false;
            }



            if (dsObj.Tables[3].Rows[0]["ClientDiscountAmount"].ToString() != "")
            {
                txtDiscount1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[3].Rows[0]["ClientDiscountAmount"].ToString()));
                txtDiscount1.Visible = true;

            }
            else
            {
                txtDiscount1.Visible = false;
            }

            //txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
            //txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();

            txtTotalDue1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[3].Rows[0]["DueFromClient"].ToString()));

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
    }
}