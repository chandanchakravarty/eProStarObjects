namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for DebitNoteRptBilling_Acclaim.
    /// </summary>
    public partial class DebitNoteRptBilling_Acclaim : Telerik.Reporting.Report
    {
        public DebitNoteRptBilling_Acclaim()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

          public DebitNoteRptBilling_Acclaim(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag)
        {
            //
            // Required for telerik Reporting designer support
            //
           
            InitializeComponent();
            if (dsObj.Tables[6].Rows.Count > 0)
            {
                if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count > 0)
                {
                  
                    txtvoice.Value = "CREDIT NOTE";
                    txtdebitno.Value = "Credit Note No";
                    txtdebitnotedate.Value = "Credit Note Date";
                  //  txtfilecopyvalue.Value = "FILE COPY";
                    txtofcBankName.Value = "";
                    txtOfficeAccNo.Value = "";
                    txtOfficeBranch.Value = "";
                    txtoaccountno.Value = "";
                    txtoaddress.Value = "";
                    txtobank.Value = "";
                    txtobranchno.Value = "";
                    txtofficeAdddress3.Value = "";
                    txtofficeAddress1.Value = "";
                    txtofficeAddress2.Value = "";
                    textBox5.Value = "";
                    txtOfficeCode.Value = "";

                    txtofcBankName.Value = "";
                    txtOfficeAccNo.Value = "";
                    txtOfficeBranch.Value = "";



                    txtwarrentinf01.Value = "";
                   // txtwarrentydate.Value = "";
                    txtwarrentyinfo2.Value = "";
                    textBox2.Visible = false;
                    textBox3.Value = "";
                    textBox4.Value = "";
                    txtBank.Value = "";
                    txtbankaddress.Value = "";
                    txtbankaccount.Value = "";
                    txtbranchno.Value = "";
                    txtswiftcode.Value = "";
                    txtbankname.Value = "";
                    txtAddress1.Value = "";
                    txtAddess2.Value = "";
                    txtAddress3.Value = "";
                    txtAccountNumber.Value = "";
                    txtBranchName.Value = "";
                    txtcode.Value = "";
                    textBox23.Value = "";


                    txtoaccountno.Value = "";
                    txtoaddress.Value = "";
                    txtobank.Value = "";
                    txtobranchno.Value = "";
                    txtofficeAdddress3.Value = "";
                    txtofficeAddress1.Value = "";
                    txtofficeAddress2.Value = "";
                    textBox5.Value = "";
                    txtOfficeCode.Value = "";

                    txtofcBankName.Value = "";
                    txtOfficeAccNo.Value = "";
                    txtOfficeBranch.Value = "";

                    txtWarrenty.Value = "";
               




                }
                else
                {
                 
                    txtvoice.Value = "TAX INVOICE";
                    txtdebitno.Value = "Tax Invoice No";
                    txtdebitnotedate.Value = "Tax Invoice Date";
                    txtWarrenty.Visible = true;
                    txtwarrentinf01.Visible = true;
                    txtwarrentydate.Visible = true;
                    txtwarrentyinfo2.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    txtBank.Visible = true;
                    txtbankaddress.Visible = true;
                    txtbankaccount.Visible = true;
                    txtbranchno.Visible = true;
                    txtswiftcode.Visible = true;
                    txtbankname.Visible = true;
                    txtAddress1.Visible = true;
                    txtAddess2.Visible = true;
                    txtAddress3.Visible = true;
                    txtAccountNumber.Visible = true;
                    txtBranchName.Visible = true;
                    txtcode.Visible = true;
                    textBox23.Visible = true;


                    txtoaccountno.Visible = true;
                    txtoaddress.Visible = true;
                    txtobank.Visible = true;
                    txtobranchno.Visible = true;
                    txtofficeAdddress3.Visible = true;
                    txtofficeAddress1.Visible = true;
                    txtofficeAddress2.Visible = true;
                    textBox5.Visible = true;
                    txtOfficeCode.Visible = true;

                    txtofcBankName.Visible = true;
                    txtOfficeAccNo.Visible = true;
                    txtOfficeBranch.Visible = true;
                }


                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();
            

                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();

                var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
                txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();
                //txtComName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtTextTel.Value = "";
                txtPhone.Value = "";
                txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
                txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
                txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
                txtpolicydescvalue.Value = "";
                txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();

                if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
                {

                    txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                    txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                    txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                    txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                    txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                    txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                    txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                    txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                    txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                    txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                    txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
                    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                    txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                    txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                    txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
                }
                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
                txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
                txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
                txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
               
               
                //tblfilecopydetail.Visible = false;
                tblunderwriterlist.Visible = false;
                tblAgent.Visible = false;
                txtstampdutyvalue.Visible = false;

                //   txtservicefeevalue.Visible =false; 
                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
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
                textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;




            }
            else
            {
                txtvoice.Value = "TAX INVOICE";
                txtdebitno.Value = "Tax Invoice No";
                txtdebitnotedate.Value = "Tax Invoice Date";
                // }
                txtfilecopyvalue.Value = "";
                txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();
                //txtregvalue.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                // txtcovalue.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();

                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
                txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();
                //txtComName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtTextTel.Value = "";
                txtPhone.Value = "";
                txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
                txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
                txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
                txtpolicydescvalue.Value = "";
                txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
             //   txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
                txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
                txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
                txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
                
              
                txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
                if (dsObj.Tables[6].Rows.Count == 0)
                {
                    txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                    txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                    txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                    txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                    txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                    txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                    txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                    txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                    txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                    txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
                    txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                }
                //tblfilecopydetail.Visible = false;
                tblunderwriterlist.Visible = false;
                tblAgent.Visible = false;
                txtstampdutyvalue.Visible = false;

                //   txtservicefeevalue.Visible =false; 
                txtgrosspvalue.Visible = false;
                //txtbrokageper.Visible =false; 
                txtbrokaragevalue.Visible = false;
                txtGstvalue.Visible = false;
                txtgstbrokerageper.Visible = false;
                txtbrogevalue.Visible = false;
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
                textBox7.Visible = false;
                txtbro.Visible = false;
                txtothervalue.Visible = false;
                txtpolicystatus.Visible = false;



            }




        }

          public DebitNoteRptBilling_Acclaim(DataSet dsObj, string strUWCode, string strCheckedInstl)
          {
              InitializeComponent();
              if (dsObj.Tables[6].Rows.Count > 0)
              {
                  if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count > 0)
                  {
                   
                      txtvoice.Value = "CREDIT NOTE";
                      txtdebitno.Value = "Credit Note No";
                      txtdebitnotedate.Value = "Credit Note Date";
                      txtfilecopyvalue.Value = "FILE COPY";
                      txtofcBankName.Value = "";
                      txtOfficeAccNo.Value = "";
                      txtOfficeBranch.Value = "";
                      txtoaccountno.Value = "";
                      txtoaddress.Value = "";
                      txtobank.Value = "";
                      txtobranchno.Value = "";
                      txtofficeAdddress3.Value = "";
                      txtofficeAddress1.Value = "";
                      txtofficeAddress2.Value = "";
                      textBox5.Value = "";
                      txtOfficeCode.Value = "";
                      textBox2.Visible = false;
                      txtofcBankName.Value = "";
                      txtOfficeAccNo.Value = "";
                      txtOfficeBranch.Value = "";



                      txtwarrentinf01.Value = "";
                     // txtwarrentydate.Value = "";
                      txtwarrentydate.Visible = false;
                      txtwarrentyinfo2.Value = "";
                     // textBox2.Value = "";
                      textBox3.Value = "";
                      textBox4.Value = "";
                      txtBank.Value = "";
                      txtbankaddress.Value = "";
                      txtbankaccount.Value = "";
                      txtbranchno.Value = "";
                      txtswiftcode.Value = "";
                      txtbankname.Value = "";
                      txtAddress1.Value = "";
                      txtAddess2.Value = "";
                      txtAddress3.Value = "";
                      txtAccountNumber.Value = "";
                      txtBranchName.Value = "";
                      txtcode.Value = "";
                      textBox23.Value = "";


                      txtoaccountno.Value = "";
                      txtoaddress.Value = "";
                      txtobank.Value = "";
                      txtobranchno.Value = "";
                      txtofficeAdddress3.Value = "";
                      txtofficeAddress1.Value = "";
                      txtofficeAddress2.Value = "";
                      textBox5.Value = "";
                      txtOfficeCode.Value = "";

                      txtofcBankName.Value = "";
                      txtOfficeAccNo.Value = "";
                      txtOfficeBranch.Value = "";
                      txtWarrenty.Visible = false;
                   
                  }
                  else
                  {
                      txtvoice.Value = "TAX INVOICE";
                      txtdebitno.Value = "Tax Invoice No";
                      txtdebitnotedate.Value = "Tax Invoice Date";
                      txtfilecopyvalue.Value = "FILE COPY";
                      txtWarrenty.Visible = true;
                      txtwarrentinf01.Visible = true;
                      txtwarrentydate.Visible = true;
                      txtwarrentyinfo2.Visible = true;
                      textBox2.Visible = true;
                      textBox3.Visible = true;
                      textBox4.Visible = true;
                      txtBank.Visible = true;
                      txtbankaddress.Visible = true;
                      txtbankaccount.Visible = true;
                      txtbranchno.Visible = true;
                      txtswiftcode.Visible = true;
                      txtbankname.Visible = true;
                      txtAddress1.Visible = true;
                      txtAddess2.Visible = true;
                      txtAddress3.Visible = true;
                      txtAccountNumber.Visible = true;
                      txtBranchName.Visible = true;
                      txtcode.Visible = true;
                      textBox23.Visible = true;


                      txtoaccountno.Visible = true;
                      txtoaddress.Visible = true;
                      txtobank.Visible = true;
                      txtobranchno.Visible = true;
                      txtofficeAdddress3.Visible = true;
                      txtofficeAddress1.Visible = true;
                      txtofficeAddress2.Visible = true;
                      textBox5.Visible = true;
                      txtOfficeCode.Visible = true;

                      txtofcBankName.Visible = true;
                      txtOfficeAccNo.Visible = true;
                      txtOfficeBranch.Visible = true;

                  }

                  txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                  txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();

                  txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();
                  
                  txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                  txtTextTel.Value = "";
                  txtPhone.Value = "";
                  txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                  txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                  txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                  txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                  txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

                  txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
                  txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                  txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                  txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
                  txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                  txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                  txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
                  txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
                  txtpolicydescvalue.Value = "";
                  txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                  txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                  txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                  txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
                  txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
                  txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
                  txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
                

                  if (dsObj.Tables[6].Rows[0]["EndorsementType"].ToString() == "Canc" && dsObj.Tables[6].Rows[0]["Pol_status"].ToString() == "CNCANC" && dsObj.Tables[8].Rows.Count == 0)
                  
                  {
                      txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                      txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                      txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                      txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
                      txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                      txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                      txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                      txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                      txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                      txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                      txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                      txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                      txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                      txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();

                  }

                  //  tblfilecopydetail.Visible = false;
                  tblunderwriterlist.Visible = true;
                  tblAgent.Visible = true;



              }
              else
              {
                  txtvoice.Value = "TAX INVOICE";
                  txtdebitno.Value = "Tax Invoice No";
                  txtdebitnotedate.Value = "Tax Invoice Date";
                  //}
                  txtfilecopyvalue.Value = "FILE COPY";
                  txtgstno.Value = dsObj.Tables[1].Rows[0]["GSTCODE"].ToString();
                  txtcotegno.Value = dsObj.Tables[1].Rows[0]["BusinessRegNo"].ToString();
                 
                  txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                  var val = "ALL CHEQUES SHOULD BE CROSSED AND MADE PAYABLE TO";
                  txtComName.Value = val + " " + dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString().ToUpper();

                  txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                  txtTextTel.Value = "";
                  txtPhone.Value = "";
                  txtdebitnotevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                  txtdebitdatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                  txtclientcodevalue.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                  txtslipno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                  txtcovernoteno.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

                  txtservicervalue.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
                  txtinsuredname.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                  txtclsinsurancevalue.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                  txtpolicynovalue.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
                  txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                  txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                  txtsuminsuredvalue.Value = dsObj.Tables[2].Rows[0]["TotalsumInsured"].ToString();
                  txtinsurervalue.Value = dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();
                  txtpolicydescvalue.Value = "";
                  txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                 // txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                  txtcurrencyvalue.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                  txtpremiumvalue.Value = dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString();
                  txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
                  txtdiscountvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();
                  txttotaldueamount.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
                  txtbankname.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
                  txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
                  txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
                  txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();

                  if (dsObj.Tables[6].Rows.Count == 0)
                  {
                      txtAccountNumber.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
                      txtBranchName.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
                      txtcode.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();
                      txtofcBankName.Value = dsObj.Tables[1].Rows[0]["obankname"].ToString();
                      txtofficeAddress1.Value = dsObj.Tables[1].Rows[0]["oaddress1"].ToString();
                      txtofficeAddress2.Value = dsObj.Tables[1].Rows[0]["oaddress2"].ToString();
                      txtofficeAdddress3.Value = dsObj.Tables[1].Rows[0]["oaddress3"].ToString();
                      txtOfficeAccNo.Value = dsObj.Tables[1].Rows[0]["oacno"].ToString();
                      txtOfficeBranch.Value = dsObj.Tables[1].Rows[0]["obranchname"].ToString();
                      txtOfficeCode.Value = dsObj.Tables[1].Rows[0]["oswiftcode"].ToString();
                  }
                  //  tblfilecopydetail.Visible = false;
                  tblunderwriterlist.Visible = true;
                  tblAgent.Visible = true;

              }
              if (dsObj.Tables.Count > 3)
              {
                  txtstampdutyvalue.Value = dsObj.Tables[3].Rows[0]["StampDuty"].ToString();
                  txtserfeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();
                  txtgrosspvalue.Value = dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();
                  txtbrokageper.Value = dsObj.Tables[3].Rows[0]["uwbrokerage"].ToString();
                  txtbrokaragevalue.Value = dsObj.Tables[3].Rows[0]["uwbrokerageamount"].ToString();
                  txtGstvalue.Value = dsObj.Tables[3].Rows[0]["InsurerGSTAmount"].ToString();
                 txtgstbrokerageper.Value = dsObj.Tables[3].Rows[0]["BrokerGST"].ToString();
                 txtbrogevalue.Value = dsObj.Tables[3].Rows[0]["BrokerGSTAmount"].ToString();
               //  txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["specialDiscountAmount"].ToString();
                 txtdiscvalue.Value = dsObj.Tables[3].Rows[0]["ClientDiscount"].ToString();

                 txtothervalue.Value = dsObj.Tables[3].Rows[0]["policycharge"].ToString();
                 txtcustvalue.Value = dsObj.Tables[3].Rows[0]["DueFromClient"].ToString();
                 txtsergstvalue.Value = dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString();
                 string businessType = dsObj.Tables[2].Rows[0]["BusinessType"].ToString();
                  if(businessType =="N")
                  {
                      businessType = "New Business";
                  }
                  if (businessType == "P")
                  {
                      businessType = "Penetrate";
                  }
                  if (businessType == "R")
                  {
                      businessType = "Renewal";
                  }


                  txtpolicyvalue.Value = businessType;
                  //  txtgrosspvalue.v  dsObj.Tables[3].Rows[0]["TotalPremium"].ToString();

              }
              if (dsObj.Tables.Count > 8)
              {
                  DataView dv = new DataView(dsObj.Tables[8]);

                  DataTable dtIntroducer = dv.ToTable();
                  int icount = 0;
                  tblAgent.DataSource = dtIntroducer;
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
             
                  if (dsObj.Tables.Count > 4 && dsObj.Tables[8].Rows.Count==0)
                  {
                      DataView dv = new DataView(dsObj.Tables[4]);

                      DataTable dtIntroducer = dv.ToTable();
                      int icount = 0;
                      tblAgent.DataSource = dtIntroducer;
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
                  DataView dv = new DataView(dsObj.Tables[5]);

                  DataTable dtCopyViewIntroducer = dv.ToTable();
                  tblunderwriterlist.DataSource = dtCopyViewIntroducer;
                  int Rows = dtCopyViewIntroducer.Rows.Count;


                  DataColumn dc = new DataColumn("UnderCount", typeof(String));
                  DataColumn dc1 = new DataColumn("UnderPremium", typeof(String));

                  dtCopyViewIntroducer.Columns.Add(dc);
                  dtCopyViewIntroducer.Columns.Add(dc1);

                  for (int i = 0; i < Rows; i++)
                  {

                      DataRow dr = dtCopyViewIntroducer.Rows[i];
                      string agent = "INSURER";
                      string Comm = "GROSS PREMIUM";
                      int sum = i + 1;
                      dr["UnderCount"] = agent + sum;
                      dr["UnderPremium"] = Comm + sum;


                  }

              }
           
          }
    }
}