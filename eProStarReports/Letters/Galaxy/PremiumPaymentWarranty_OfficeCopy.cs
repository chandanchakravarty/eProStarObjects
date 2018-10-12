namespace eProStarReports.Letters.Galaxy
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    // using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using Telerik.Reporting.Processing;

    /// <summary>
    /// Summary description for PremiumPaymentWarranty_OfficeCopy.
    /// </summary>
    public partial class PremiumPaymentWarranty_OfficeCopy : Telerik.Reporting.Report
    {
        public PremiumPaymentWarranty_OfficeCopy()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PremiumPaymentWarranty_OfficeCopy(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, string Username, string printlogo, string strDebitNoteNo, string Blank)
        {
            InitializeComponent();
            this.pictureBox1.Value = ReportsUtility.ClientLogo;
            if (printlogo == "Y")
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            DataView dv = new DataView(dsObj.Tables[0]);
            //dv.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo='" + strDebitNoteNo + "'";// Commented for Redmine #33455(Crash)
            // dv.RowFilter = "DebitNoteNo='" + strDebitNoteNo + "'";
            string multibilling = dsObj.Tables[0].Rows[0]["MultipleBilling"].ToString();// Added for Redmine #33455(Crash)
            string coInsurance = dsObj.Tables[0].Rows[0]["CoInsurance"].ToString();// Added for Redmine #33491(Crash)

            string packagePolicy = dsObj.Tables[16].Rows[0]["PackagePolicy"].ToString();

            if (multibilling == "Y" || coInsurance == "Y" || packagePolicy == "Y")
            {
                dv.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo1='" + strDebitNoteNo + "'";
            }
            else
                dv.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo='" + strDebitNoteNo + "'";
            DataTable dtViewTable = dv.ToTable();
            string MultipleBilling = "";
            int ManualOverwritePremium = 0;
            string CoInsurance = "";
            string strRiskId = "0";
            if (dtViewTable != null && dtViewTable.Rows.Count > 0)
            {
                strRiskId = dtViewTable.Rows[0]["RiskId"].ToString();
                txtAddress.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                txtBillingAdd2.Value = dtViewTable.Rows[0]["BillingAddress2"].ToString();
                txtBillingAdd34.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();

                txtCompName.Value = dtViewTable.Rows[0]["ClientName"].ToString().ToUpper();
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
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString() + ", " + dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                }

                txtDocNo1.Value = dtViewTable.Rows[0]["DebitNoteNo1"].ToString();
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
                    txtContactPersonName.Value = dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIPeriod.Value = dtViewTable.Rows[0]["POIPeriod"].ToString();
                //txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;
                //panel6.Visible = false;
                //textBox4.Visible = false;
                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                MultipleBilling = dtViewTable.Rows[0]["MultipleBilling"].ToString();
                ManualOverwritePremium = Convert.ToInt16(dtViewTable.Rows[0]["ManualOverwritePremium"].ToString());
                CoInsurance = dtViewTable.Rows[0]["CoInsurance"].ToString();
                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            DataView dvEnd = new DataView(dsObj.Tables[2]);
            dvEnd.RowFilter = "DebitNoteNo='" + strDebitNoteNo + "'";
            DataTable dtEnd = dvEnd.ToTable();
            if (dtEnd != null && dtEnd.Rows.Count > 0)
            {
                if (dtEnd.Rows[0]["EndorsementNo"].ToString() != "NA")
                {
                    txtEndtNo1.Visible = true;
                    txtEndtNo.Visible = true;
                    txtEndtNo1.Value = dtEnd.Rows[0]["EndorsementNo"].ToString();
                    //  if (dtEnd.Rows[0]["EndorsementFromDate"].ToString() != "")
                    //   txtPOIPeriod.Value = dtEnd.Rows[0]["EndorsementFromDate"].ToString() + " TO " + dtEnd.Rows[0]["EndorsementToDate"].ToString();
                }
                else
                {
                    txtEndtNo1.Visible = false;
                    txtEndtNo.Visible = false;
                }

                if (dtEnd.Rows[0]["EndorsementEffdate"].ToString() != "")
                {
                    txtEndtDate1.Visible = true;
                    txtEndtDate.Visible = true;
                    txtEndtDate1.Value = dtEnd.Rows[0]["EndorsementEffdate"].ToString();
                }
                else
                {
                    txtEndtDate1.Visible = false;
                    txtEndtDate.Visible = false;
                }
            }

            txtBank1.Value = dsObj.Tables[1].Rows[0]["bankname"].ToString();
            //txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            //txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo='" + strDebitNoteNo + "'";// Commented for Redmine #33455(Crash)
            //dv1.RowFilter = "DebitNoteNo='" + strDebitNoteNo + "'";
            //if (multibilling == "Y")// Added for Redmine #33455(Crash)
            //if (multibilling == "Y" || coInsurance == "Y")
            //{
            //    dv.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo1='" + strDebitNoteNo + "'";
            //}
            //else
            //    dv.RowFilter = "ClientCode = '" + strClientCode + "' and DebitNoteNo='" + strDebitNoteNo + "'";
            DataTable dtViewTable1 = dv1.ToTable();
            if ((dtViewTable1 != null && dtViewTable1.Rows.Count > 0) && (dtViewTable != null && dtViewTable.Rows.Count > 0))
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    //txtBankCode.Visible = false;
                    //txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    //txtBankCode1.Visible = false;
                    //txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "Credit Note";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    //txtBankCode.Visible = true;
                    //txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    //txtBankCode1.Visible = true;
                    //txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }

                txtPremium1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    txtCharges1.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;
                    //txtChargesCr.Visible = false;
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {

                    txtDiscount1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    txtDiscount.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                txtTotalDue1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["DueFromClient"].ToString()));// string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }

            DataView dvUW = new DataView(dsObj.Tables[12]);
            dvUW.RowFilter = "RiskId='" + strRiskId + "'";
            DataTable dtUWriter = dvUW.ToTable();

            DataView dvAgent = new DataView(dsObj.Tables[13]);
            dvAgent.RowFilter = "RiskId='" + strRiskId + "'";
            DataTable dtAgent = dvAgent.ToTable();


            int minRows = 7;
            int maxRows = 0;
            int intRows = 2 + dtUWriter.Rows.Count + dtAgent.Rows.Count;
            int introducerRows = dtAgent.Rows.Count;
            int insurerRows = dtUWriter.Rows.Count;
            int introducerRowIndex = 0;
            int insurerRowIndex = 0;
            if (intRows <= minRows)
                maxRows = minRows;
            else
                maxRows = intRows;

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Col1"));
            objDataTable.Columns.Add(new DataColumn("Col2"));
            objDataTable.Columns.Add(new DataColumn("Col3"));
            objDataTable.Columns.Add(new DataColumn("Col4"));
            objDataTable.Columns.Add(new DataColumn("Col5"));
            objDataTable.Columns.Add(new DataColumn("Col6"));


            //DataTable objDataTable = new DataTable();
            //DataColumn dtblankcol1 = new DataColumn("Col1", typeof(String));
            //DataColumn dtblankcol2 = new DataColumn("Col2", typeof(String));
            //DataColumn dtblankcol3 = new DataColumn("Col3", typeof(String));
            //DataColumn dtblankcol4 = new DataColumn("Col4", typeof(String));
            //DataColumn dtblankcol5 = new DataColumn("Col5", typeof(String));
            //DataColumn dtblankcol6 = new DataColumn("Col6", typeof(String));
            //objDataTable.Columns.Add(dtblankcol1);
            //objDataTable.Columns.Add(dtblankcol2);
            //objDataTable.Columns.Add(dtblankcol3);
            //objDataTable.Columns.Add(dtblankcol4);
            //objDataTable.Columns.Add(dtblankcol5);
            //  objDataTable.Columns.Add(dtblankcol6);
            decimal clientbro = 0;
            decimal IntroShare = 0;
            decimal ClientPremShare = 0;
            decimal InsurerBrokerage = 0;
            for (int i = 1; i <= maxRows; i++)
            {
                DataRow objDataRow = objDataTable.NewRow();
                DataTable table;
                table = dtUWriter;

                if (i == 1)
                {
                    objDataRow["Col1"] = "Policy Status";
                    objDataRow["Col2"] = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    objDataRow["Col3"] = "Gross Brokerage";
                    objDataRow["Col4"] = "";
                    //if (dtViewTable1.Rows.Count>1)
                    //{
                    //    //redmine 21214, coinsurance brokerage to be shown for underwriters

                    if (table.Rows.Count > 0)
                    {
                        if (decimal.Parse(table.Compute("Avg(BrokerageRate)", "").ToString()) == decimal.Parse(table.Rows[0]["BrokerageRate"].ToString()))
                        {
                            objDataRow["Col5"] = table.Compute("Avg(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        }
                        else
                        {
                            objDataRow["Col5"] = "";
                        }
                    }
                    else
                    {
                        objDataRow["Col5"] = "";
                    }
                    //objDataRow["Col5"] = ""; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                    //objDataRow["Col6"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientWiseBrok"].ToString()));
                    if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                    {
                        objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Compute("Sum(uwbrokerageamount)", "").ToString()));//.ToString("#,##0.00");
                        clientbro = decimal.Parse(dtViewTable1.Compute("Sum(uwbrokerageamount)", "").ToString());
                    }
                    else if (ManualOverwritePremium == 0 && MultipleBilling == "Y" && CoInsurance == "Y")
                    {
                        ClientPremShare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                        if (table.Rows.Count > 0)
                        {
                            InsurerBrokerage = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());//.ToString("#,##0.00");
                        }
                        decimal clientBrokerageAmt = (ClientPremShare * InsurerBrokerage) / 100;
                        objDataRow["Col6"] = convertIntoNumeric(clientBrokerageAmt);
                        clientbro = clientBrokerageAmt;
                    }
                    else if (ManualOverwritePremium == 1 && MultipleBilling == "Y" && CoInsurance == "Y")
                    {
                        ClientPremShare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                        if (table.Rows.Count > 0)
                        {
                            InsurerBrokerage = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());//.ToString("#,##0.00");
                        }
                        decimal clientBrokerageAmt = (ClientPremShare * InsurerBrokerage) / 100;
                        objDataRow["Col6"] = convertIntoNumeric(clientBrokerageAmt);
                        clientbro = clientBrokerageAmt;
                    }
                    else if (MultipleBilling == "N" && CoInsurance == "Y")
                    {
                        objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Compute("Sum(uwbrokerageamount)", "").ToString()));//.ToString("#,##0.00");
                        clientbro = decimal.Parse(dtViewTable1.Compute("Sum(uwbrokerageamount)", "").ToString());
                    }
                    else
                    {
                        //if (objDataRow["Col6"] != System.DBNull.Value)
                        //{
                        //}
                        //if (!DBNull.Value.Equals(objDataRow["Col6"])) 
                        //{
                        objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString()));//.ToString("#,##0.00");
                        clientbro = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString());
                        //}
                        //else
                        //    objDataRow["Col6"] =string.Empty;
                    }

                    //}
                    //else
                    //{
                    //    objDataRow["Col5"] = table.Compute("Sum(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                    //    objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()));//.ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                    //    clientbro = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());
                    //}

                }
                if (i == 2)
                {
                    objDataRow["Col1"] = "Renewal Type";
                    objDataRow["Col2"] = dsObj.Tables[15].Rows[0]["RenewalType"].ToString();
                    objDataRow["Col3"] = "GST on Brokerage";
                    objDataRow["Col4"] = "";
                    objDataRow["Col5"] = "";
                    //object sumObject;
                    //sumObject = table.Compute("Sum(Amount)", "");
                    //decimal BrokerageSum = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString());
                    //decimal BrokerageClientwise = (clientshare * BrokerageSum) / 100;
                    //objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);
                    //objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(table.Compute("Sum(BrokerGSTAmount)", "").ToString()));

                    decimal clientshare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                    if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                    {
                        decimal BrokerageSum = decimal.Parse(dtViewTable1.Compute("Sum(OldMappingBrokerGSTAmount)", "").ToString());
                        decimal BrokerageClientwise = BrokerageSum;
                        objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);

                    }
                    else if (ManualOverwritePremium == 1 && MultipleBilling == "Y" && CoInsurance == "Y")
                    {
                        ClientPremShare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                        decimal BrokerageSum = decimal.Parse(dtViewTable1.Compute("Sum(OldMappingBrokerGSTAmount)", "").ToString());
                        decimal BrokerageClientwise = (ClientPremShare * BrokerageSum) / 100;
                        objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);
                    }
                    else
                    {
                        decimal BrokerageSum = decimal.Parse(dtViewTable1.Rows[0]["BrokerGSTAmount"].ToString());
                        decimal BrokerageClientwise = BrokerageSum;
                        objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);

                    }

                    //.ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");                   
                }

                if (i >= 3)
                {
                    if (i == 3)
                    {
                        objDataRow["Col1"] = "Divisional Grouping";
                        objDataRow["Col2"] = dsObj.Tables[11].Rows[0]["DivisionalGroupingName"].ToString();
                    }
                    else if (i == 4)
                    {
                        objDataRow["Col1"] = "Gross Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));//.ToString("#,##0.00");
                    }
                    else if (i == 5)
                    {
                        objDataRow["Col1"] = "GST on Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["InsurerGSTAmount"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["GSTONPremium"].ToString()));//.ToString("#,##0.00");

                    }
                    else if (i == 6)
                    {
                        objDataRow["Col1"] = "Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeWithoutGST"].ToString()));//.ToString("#,##0.00");      

                    }
                    else if (i == 7)
                    {
                        objDataRow["Col1"] = "GST on Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = convertIntoNumeric((decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeGST"].ToString())));//.ToString("#,##0.00");

                    }
                    else
                    {
                        objDataRow["Col1"] = "";
                        objDataRow["Col2"] = "";
                    }
                    if (introducerRows > 0)
                    {
                        //Bind from Introducer Table

                        objDataRow["Col3"] = "Introducer " + (introducerRowIndex + 1).ToString();
                        objDataRow["Col4"] = dtAgent.Rows[introducerRowIndex]["AGENTNAME"].ToString();
                        objDataRow["Col5"] = dtAgent.Rows[introducerRowIndex]["AgentShare"].ToString() + " %";
                        IntroShare = decimal.Parse(dtAgent.Rows[introducerRowIndex]["AgentShare"].ToString());
                        // objDataRow["Col6"] = decimal.Parse(dsObj.Tables[13].Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                        if (ManualOverwritePremium == 1)
                        {
                            // decimal IntroShareamount = (IntroShare * clientbro) / 100;
                            objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtAgent.Rows[introducerRowIndex]["PREMIUM"].ToString()));//.ToString("#,##0.00");
                        }
                        else
                        {
                            decimal IntroShareamount = (IntroShare * clientbro) / 100;
                            objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtAgent.Rows[introducerRowIndex]["PREMIUM"].ToString()));//convertIntoNumeric(IntroShareamount);//.ToString("#,##0.00");
                        }
                        introducerRows--;
                        introducerRowIndex++;


                    }
                    else if (insurerRows > 0)
                    {
                        //Bind from Insurer Table
                        objDataRow["Col3"] = "Insurer " + (insurerRowIndex + 1).ToString();
                        objDataRow["Col4"] = dtUWriter.Rows[insurerRowIndex]["UWShortName"].ToString();
                        objDataRow["Col5"] = dtUWriter.Rows[insurerRowIndex]["UWShare"].ToString() + " %";
                        if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                        {
                            //decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));
                            objDataRow["Col6"] = convertIntoNumeric(decimal.Parse((decimal.Parse(dtUWriter.Rows[insurerRowIndex]["Premium"].ToString())).ToString()));
                        }
                        else
                        {
                            {
                                //if (objDataRow["Col6"] != System.DBNull.Value)
                                //{
                                //}
                                //if (!DBNull.Value.Equals(objDataRow["Col6"]))
                                //{

                                // Change Code By  Rajeev
                                decimal dtUWriterUWShare = 0;
                                if (!string.IsNullOrEmpty(dtUWriter.Rows[insurerRowIndex]["UWShare"].ToString()))
                                    dtUWriterUWShare = decimal.Parse(Convert.ToString(dtUWriter.Rows[insurerRowIndex]["UWShare"].ToString()));
                                //decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));
                                decimal Amount = (decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()) * dtUWriterUWShare);
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse((Amount / 100).ToString()));//.ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                                //}
                                //else
                                //    objDataRow["Col6"] = string.Empty;
                            }
                        }
                        insurerRows--;
                        insurerRowIndex++;
                    }
                    else
                    {
                        objDataRow["Col3"] = "";
                        objDataRow["Col4"] = "";
                        objDataRow["Col5"] = "";
                        objDataRow["Col6"] = "";
                    }
                }
                objDataTable.Rows.Add(objDataRow);
            }
            table4.DataSource = objDataTable;
        }


        #region Added by neetu Sinha
        public PremiumPaymentWarranty_OfficeCopy(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, string Username, string installment, string printlogo)
        {
            InitializeComponent();
            this.pictureBox1.Value = ReportsUtility.ClientLogo;
            if (printlogo == "Y")
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            DataView dv = new DataView(dsObj.Tables[0]);
            if (strCheckedInstl == "")
                strCheckedInstl = "0";
            dv.RowFilter = "ClientCode = '" + strClientCode + "' and instno ='" + strCheckedInstl + "'";
            DataTable dtViewTable = dv.ToTable();

            string MultipleBilling = "";
            int ManualOverwritePremium = 0;
            string CoInsurance = "";
            if (dtViewTable != null && dtViewTable.Rows.Count > 0)
            {
                txtAddress.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                txtBillingAdd2.Value = dtViewTable.Rows[0]["BillingAddress2"].ToString();
                txtBillingAdd34.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();

                txtCompName.Value = dtViewTable.Rows[0]["ClientName"].ToString().ToUpper();
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
                    //txtContactPersonName.Value = "Ms/Mr " + dtViewTable.Rows[0]["ClientContactName"].ToString();
                    txtContactPersonName.Value = dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIPeriod.Value = dtViewTable.Rows[0]["POIPeriod"].ToString();
                //txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;
                //panel6.Visible = false;
                //textBox4.Visible = false;
                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                MultipleBilling = dtViewTable.Rows[0]["MultipleBilling"].ToString();
                ManualOverwritePremium = Convert.ToInt16(dtViewTable.Rows[0]["ManualOverwritePremium"].ToString());
                CoInsurance = dtViewTable.Rows[0]["CoInsurance"].ToString();
                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
            {
                txtEndtNo1.Visible = true;
                txtEndtNo.Visible = true;
                txtEndtNo1.Value = dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString();
                // if (dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() != "")
                //  txtPOIPeriod.Value = dsObj.Tables[2].Rows[0]["EndorsementFromDate"].ToString() + " TO " + dsObj.Tables[2].Rows[0]["EndorsementToDate"].ToString(); 
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
            //txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            //txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "' and instno ='" + strCheckedInstl + "'";
            DataTable dtViewTable1 = dv1.ToTable();
            if (dtViewTable1 != null && dtViewTable1.Rows.Count > 0)
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    //txtBankCode.Visible = false;
                    //txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    //txtBankCode1.Visible = false;
                    //txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "Credit Note";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    //txtBankCode.Visible = true;
                    //txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    //txtBankCode1.Visible = true;
                    //txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }

                txtPremium1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));

                    txtCharges1.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {
                    txtDiscount1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    txtDiscount.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                txtTotalDue1.Value = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["DueFromClient"].ToString()));// string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }
            int minRows = 7;
            int maxRows = 0;

            // int introducerRows = dsObj.Tables[13].Rows.Count;


            //int insurerRows = dsObj.Tables[12].Rows.Count;
            DataView dv3 = new DataView(dsObj.Tables[12]);
            dv3.RowFilter = " instno ='" + strCheckedInstl + "'";
            DataTable dtinsurer = dv3.ToTable();
            int insurerRows = dtinsurer.Rows.Count;

            DataView dvI = new DataView(dsObj.Tables[13]);
            dvI.RowFilter = " instno ='" + strCheckedInstl + "'";
            DataTable dtintroducer = dvI.ToTable();
            int introducerRows = dtintroducer.Rows.Count;

            //int intRows = 2 + dsObj.Tables[12].Rows.Count + dsObj.Tables[13].Rows.Count;
            int intRows = 2 + insurerRows + introducerRows;

            int introducerRowIndex = 0;
            int insurerRowIndex = 0;
            if (intRows <= minRows)
                maxRows = minRows;
            else
                maxRows = intRows;

            DataTable objDataTable = new DataTable();
            objDataTable.Columns.Add(new DataColumn("Col1"));
            objDataTable.Columns.Add(new DataColumn("Col2"));
            objDataTable.Columns.Add(new DataColumn("Col3"));
            objDataTable.Columns.Add(new DataColumn("Col4"));
            objDataTable.Columns.Add(new DataColumn("Col5"));
            objDataTable.Columns.Add(new DataColumn("Col6"));


            decimal clientbro = 0;
            decimal IntroShare = 0;
            for (int i = 1; i <= maxRows; i++)
            {
                DataRow objDataRow = objDataTable.NewRow();
                DataTable table;

                // table = dsObj.Tables[12];
                DataView dv4 = new DataView(dsObj.Tables[12]);
                dv4.RowFilter = " instno ='" + strCheckedInstl + "'";
                table = dv4.ToTable();
                if (i == 1)
                {
                    objDataRow["Col1"] = "Policy Status";
                    objDataRow["Col2"] = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    objDataRow["Col3"] = "Gross Brokerage";
                    objDataRow["Col4"] = "";
                    //if (dtViewTable1.Rows.Count > 1)
                    //{
                    if (table.Rows.Count > 0)
                    {
                        if (decimal.Parse(table.Compute("Avg(BrokerageRate)", "").ToString()) == decimal.Parse(table.Rows[0]["BrokerageRate"].ToString()))
                        {
                            objDataRow["Col5"] = table.Compute("Avg(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        }
                        else
                        {
                            objDataRow["Col5"] = "";
                        }
                    }
                    else
                    {
                        objDataRow["Col5"] = "";
                    }
                    //objDataRow["Col5"] = ""; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                    //objDataRow["Col6"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientWiseBrok"].ToString()));
                    //objDataRow["Col6"] = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString()).ToString("#,##0.00");

                    if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                    {
                        if (table.Rows.Count > 0)
                        {
                            objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()));//.ToString("#,##0.00");
                            clientbro = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());
                        }
                    }
                    else if (ManualOverwritePremium == 0 && MultipleBilling == "Y" && CoInsurance == "Y")
                    {
                        decimal ClientPremShare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());

                        decimal InsurerBrokerage = 0;
                        if (table.Rows.Count > 0)
                        {
                            InsurerBrokerage = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());//.ToString("#,##0.00");
                        }
                        decimal clientBrokerageAmt = (ClientPremShare * InsurerBrokerage) / 100;

                        objDataRow["Col6"] = convertIntoNumeric(clientBrokerageAmt);//.ToString("#,##0.00");
                        clientbro = clientBrokerageAmt;
                    }
                    else if (ManualOverwritePremium == 1 && MultipleBilling == "Y" && CoInsurance == "Y")
                    {
                        decimal ClientPremShare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                        decimal ClientWise = decimal.Parse(dtViewTable1.Rows[0]["ClientWiseBrok"].ToString()); //Added for Redmine #33375


                        decimal InsurerBrokerage = 0;
                        if (table.Rows.Count > 0)
                        {
                            InsurerBrokerage = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());//.ToString("#,##0.00");
                        }
                        decimal clientBrokerageAmt = (ClientPremShare * InsurerBrokerage) / 100;

                        //objDataRow["Col6"] = convertIntoNumeric(clientBrokerageAmt);//.ToString("#,##0.00");
                        //clientbro = clientBrokerageAmt;//Commented for Redmine #33375

                        objDataRow["Col6"] = convertIntoNumeric(ClientWise);//Added for Redmine #33375
                        clientbro = ClientWise;

                    }
                    else
                    {
                        if (dtViewTable1 != null && dtViewTable1.Rows.Count > 0)
                        {
                            objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString()));
                            clientbro = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString());
                        }
                    }
                    //}
                    //else
                    //{
                    //    objDataRow["Col5"] = table.Compute("Sum(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                    //    objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString())); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                    //    clientbro = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString());

                    //}
                    //objDataRow["Col5"] = table.Compute("Avg(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                    //objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                }
                if (i == 2)
                {
                    objDataRow["Col1"] = "Renewal Type";
                    objDataRow["Col2"] = dsObj.Tables[15].Rows[0]["RenewalType"].ToString();
                    objDataRow["Col3"] = "GST on Brokerage";
                    objDataRow["Col4"] = "";
                    objDataRow["Col5"] = "";
                    //object sumObject;
                    //sumObject = table.Compute("Sum(Amount)", "");
                    //if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                    //{
                    //    decimal clientshare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());

                    //    decimal BrokerageSum = decimal.Parse(dtViewTable1.Rows[0]["OldMappingBrokerGSTAmount"].ToString());
                    //    decimal BrokerageClientwise = BrokerageSum;
                    //    objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);

                    //}
                    //else
                    //{
                    if (dtViewTable1 != null && dtViewTable1.Rows.Count > 0)
                    {
                        decimal clientshare = decimal.Parse(dtViewTable1.Rows[0]["ClientShare"].ToString());
                        // decimal BrokerageSum = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString());
                        decimal BrokerageSum = decimal.Parse(dtViewTable1.Rows[0]["BrokerGSTAmount"].ToString());
                        decimal BrokerageClientwise = BrokerageSum;
                        objDataRow["Col6"] = convertIntoNumeric(BrokerageClientwise);//.ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                    }
                    //}
                    //objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(BrokerGSTAmount)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");                   
                }

                if (i >= 3)
                {
                    if (i == 3)
                    {
                        objDataRow["Col1"] = "Divisional Grouping";
                        objDataRow["Col2"] = dsObj.Tables[11].Rows[0]["DivisionalGroupingName"].ToString();
                    }
                    else if (i == 4)
                    {
                        objDataRow["Col1"] = "Gross Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                        //objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()));//.ToString("#,##0.00");
                        objDataRow["Col2"] = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString())) : "0";
                    }
                    else if (i == 5)
                    {
                        objDataRow["Col1"] = "GST on Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["InsurerGSTAmount"].ToString()).ToString("#,##0.00");
                        // objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["GSTONPremium"].ToString()));//.ToString("#,##0.00");
                        objDataRow["Col2"] = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["GSTONPremium"].ToString())) : "0";

                    }
                    else if (i == 6)
                    {
                        objDataRow["Col1"] = "Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        //objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeWithoutGST"].ToString()));//.ToString("#,##0.00");
                        objDataRow["Col2"] = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeWithoutGST"].ToString())) : "0";

                    }
                    else if (i == 7)
                    {
                        objDataRow["Col1"] = "GST on Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        //objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeGST"].ToString()));//.ToString("#,##0.00");
                        objDataRow["Col2"] = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? convertIntoNumeric(decimal.Parse(dtViewTable1.Rows[0]["TotalpolicychargeGST"].ToString())) : "0";

                    }
                    else
                    {
                        objDataRow["Col1"] = "";
                        objDataRow["Col2"] = "";
                    }
                    if (introducerRows > 0)
                    {
                        //Bind from Introducer Table
                        if (dtintroducer.Rows.Count > 1)
                        {
                            objDataRow["Col3"] = "Introducer " + (introducerRowIndex + 1).ToString();
                            objDataRow["Col4"] = dtintroducer.Rows[introducerRowIndex]["AGENTNAME"].ToString();
                            objDataRow["Col5"] = dtintroducer.Rows[introducerRowIndex]["AgentShare"].ToString() + " %";
                            IntroShare = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["AgentShare"].ToString());
                            // objDataRow["Col6"] = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                            decimal IntroShareamount = (IntroShare * clientbro) / 100;
                            if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()));
                            }
                            else
                            {
                                objDataRow["Col6"] = convertIntoNumeric(IntroShareamount);//.ToString("#,##0.00");
                            }
                            introducerRows--;
                            introducerRowIndex++;
                        }

                        else
                        {
                            objDataRow["Col3"] = "Introducer " + "1".ToString();
                            objDataRow["Col4"] = dtintroducer.Rows[introducerRowIndex]["AGENTNAME"].ToString();
                            objDataRow["Col5"] = dtintroducer.Rows[introducerRowIndex]["AgentShare"].ToString() + " %";
                            IntroShare = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["AgentShare"].ToString());
                            //decimal IntroShareamount = (IntroShare * clientbro) / 100;//Commented for Redmine #33375
                            decimal IntroShareamount = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString());
                            if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()));
                            }
                            else
                            {
                                objDataRow["Col6"] = convertIntoNumeric(IntroShareamount);//.ToString("#,##0.00");
                            }
                            // objDataRow["Col6"] = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                            introducerRows--;

                        }
                    }
                    else if (insurerRows > 0)
                    {
                        if (dtinsurer.Rows.Count > 1)
                        {
                            //Bind from Insurer Table
                            objDataRow["Col3"] = "Insurer " + (insurerRowIndex + 1).ToString();
                            // objDataRow["Col4"] = dsObj.Tables[12].Rows[insurerRowIndex]["UnderWriterName"].ToString();
                            objDataRow["Col4"] = dtinsurer.Rows[insurerRowIndex]["UWShortName"].ToString();
                            objDataRow["Col5"] = dtinsurer.Rows[insurerRowIndex]["UWShare"].ToString() + " %";
                            //objDataRow["Col6"] = decimal.Parse(dtinsurer.Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            //insurerRows--;
                            // decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()) * decimal.Parse(dtinsurer.Rows[insurerRowIndex]["UWShare"].ToString()));
                            //Change Code By rajeev
                            decimal Amount = 0;
                            if (dsObj.Tables.Count > 11 && dsObj.Tables[12].Rows.Count > 0)
                            {
                                decimal PremiumWithoutGST = 0;
                                decimal UWShare = 0;
                                if (!string.IsNullOrEmpty(Convert.ToString(dtViewTable1.Rows[0]["PremiumWithoutGST"])))
                                    PremiumWithoutGST = decimal.Parse(Convert.ToString(dtViewTable1.Rows[0]["PremiumWithoutGST"]));

                                //if (!string.IsNullOrEmpty(Convert.ToString(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"])))
                                //    UWShare = decimal.Parse(Convert.ToString(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"]));


                                if (!string.IsNullOrEmpty(Convert.ToString(dtinsurer.Rows[insurerRowIndex]["UWShare"].ToString())))
                                    UWShare = decimal.Parse(Convert.ToString(dtinsurer.Rows[insurerRowIndex]["UWShare"].ToString()));

                                Amount = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? (PremiumWithoutGST * UWShare) : decimal.Parse("0");
                            }
                            if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtinsurer.Rows[insurerRowIndex]["Premium"].ToString()));//.ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            }
                            else
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse((Amount / 100).ToString()));//.ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            }
                            insurerRows--;
                            insurerRowIndex++;
                        }
                        else
                        {
                            objDataRow["Col3"] = "Insurer " + "1".ToString();
                            // objDataRow["Col4"] = dsObj.Tables[12].Rows[insurerRowIndex]["UnderWriterName"].ToString();
                            objDataRow["Col4"] = dtinsurer.Rows[0]["UWShortName"].ToString();
                            objDataRow["Col5"] = dtinsurer.Rows[0]["UWShare"].ToString() + " %";
                            //objDataRow["Col6"] = decimal.Parse(dtinsurer.Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                            //insurerRows--;
                            //decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));

                            //Change By Rajeev
                            decimal Amount = 0;
                            if (dsObj.Tables.Count > 11 && dsObj.Tables[12].Rows.Count > 0)
                            {
                                decimal PremiumWithoutGST = 0;
                                decimal UWShare = 0;
                                if (!string.IsNullOrEmpty(Convert.ToString(dtViewTable1.Rows[0]["PremiumWithoutGST"])))
                                    PremiumWithoutGST = decimal.Parse(Convert.ToString(dtViewTable1.Rows[0]["PremiumWithoutGST"]));

                                //if (!string.IsNullOrEmpty(Convert.ToString(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"])))
                                //   UWShare = decimal.Parse(Convert.ToString(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"]));

                                if (!string.IsNullOrEmpty(Convert.ToString(dtinsurer.Rows[0]["UWShare"].ToString())))
                                    UWShare = decimal.Parse(Convert.ToString(dtinsurer.Rows[0]["UWShare"].ToString()));


                                Amount = (dtViewTable1 != null && dtViewTable.Rows.Count > 0) ? (PremiumWithoutGST * UWShare) : decimal.Parse("0");
                            }

                            if (MultipleBilling == "N" && ManualOverwritePremium == 1)
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dtinsurer.Rows[insurerRowIndex]["Premium"].ToString()));//.ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            }
                            else
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse((Amount / 100).ToString()));//.ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            }
                            insurerRows--;
                        }

                    }
                    else
                    {
                        objDataRow["Col3"] = "";
                        objDataRow["Col4"] = "";
                        objDataRow["Col5"] = "";
                        objDataRow["Col6"] = "";
                    }
                }
                objDataTable.Rows.Add(objDataRow);
            }
            table4.DataSource = objDataTable;
        }
        #endregion

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
    }
}