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
    public partial class DebitNoteRptGeneralReport_FileCopy : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneralReport_FileCopy()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRptGeneralReport_FileCopy(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type)
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
            if (dsObj.Tables.Contains("reprint"))
            {
                textBox69.Value = "DUPLICATE";
            }
            // added for #23256 --end

            //txtTextDN.Value = "DEBIT NOTE :";

            if (dsObj.Tables.Count > 0)
            {
                string IsPrintLegNote = string.Empty;
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    if (dsObj.Tables[0].Rows[0]["InvoiceNo"] != DBNull.Value)
                        txtDebitNoteNo.Value = ": " + dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["EffectiveDate"] != DBNull.Value)
                        txtDebitNoteDate.Value = ": " + dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();       
                    if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value)
                        txtClientCode.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();       
                    if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                        txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ExecutiveInCharge"] != DBNull.Value)
                        txtServicer.Value = ": " + dsObj.Tables[0].Rows[0]["ExecutiveInCharge"].ToString();       
                    if (dsObj.Tables[0].Rows[0]["BillingDueDate"] != DBNull.Value)
                        txtDueDate.Value = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();      
                    //if (dsObj.Tables[0].Rows[0]["BankId"] != DBNull.Value)
                    //    textBox65.Value = "" + dsObj.Tables[0].Rows[0]["BankId"].ToString();
                    if (dsObj.Tables[0].Rows[0]["BankName"] != DBNull.Value)
                        txtBankName.Value = "" + dsObj.Tables[0].Rows[0]["BankName"].ToString();
                    if (dsObj.Tables[0].Rows[0]["SwiftCode"] != DBNull.Value)
                        textBox39.Value = "" + dsObj.Tables[0].Rows[0]["SwiftCode"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ACNo"] != DBNull.Value)
                        textBox37.Value = "" + dsObj.Tables[0].Rows[0]["ACNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["Remarks"] != DBNull.Value)
                        txtParticular.Value = ": " + dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                    txtClientAddress1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorrAddress1"]);
                    txtClientAddress2.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorreAddress2"].ToString());
                    txtClientAddress3.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorreAddress3"].ToString());
                    txtClientAddress4.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorrAddress4"].ToString());
                    if (dsObj.Tables[0].Rows[0]["GrossPremCurrency"] != DBNull.Value)
                        txtCurrency.Value =txtCurr2.Value= txtCurr1.Value = ":" + dsObj.Tables[0].Rows[0]["GrossPremCurrency"].ToString() + "";
                    IsPrintLegNote = Convert.ToString(dsObj.Tables[0].Rows[0]["IsPrintLegNote"]);
                    //PolicyDetails
                    //if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value)
                    //    txtClassofInsurance.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value)
                    //    txtPolicyNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                    //{
                    //    txtPOIFrom.Visible = false;
                    //    txtPOITo.Visible = false;
                    //}
                    //else
                    //{
                    //    txtPOIFrom.Value = ": " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                    //    txtPOITo.Value = "" + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    //}
                    //if (dsObj.Tables[0].Rows[0]["UnderWriterName"] != DBNull.Value)
                    //    txtInsurerName.Value = ": " + dsObj.Tables[0].Rows[0]["UnderWriterName"].ToString();       // added for #23642


                    //if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value)
                    //    txtCurrency.Value = txtCurr1.Value = txtCurr2.Value = ": <" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";       // added for #23642
                    
                    //if (dsObj.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value)
                    //    txtGSTAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value)
                    //{
                    //    txtTotalDue.Value =ConvertIntoNumeric( Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));
                    //}
                    //if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value)
                    //{
                    //   // txtAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["CLTotalDue"].ToString()));      // added for #23642
                    //    txtAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()) - Convert.ToDecimal(txtGSTAmt.Value))); // #23516
                    //    txtCustPremium.Value = txtTotalDue.Value;
                    //}

                    //if (dsObj.Tables[0].Rows[0]["CoverageToInclude"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "EB" || dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "V"))
                    //    pnlGeneral.Visible = false;
                    //if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "LIF"))
                    //    pnlLife.Visible = true;
                    //if (dsObj.Tables[0].Rows[0]["PremWarranty"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "0"))
                    //    pnlNonLife.Visible = true;

                    //if (pnlLife.Visible == false && pnlNonLife.Visible == true)
                    //{
                    //    pnlNonLife.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Cm),
                    //                            new Telerik.Reporting.Drawing.Unit(14.3, Telerik.Reporting.Drawing.UnitType.Cm));

                    //}
                    if (IsPrintLegNote == "True")
                    {
                        if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "NLF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                            pnlGeneral.Visible = true;
                        //#32117 
                        //if (dsObj.Tables[0].Rows[0]["CoverageToInclude"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "EB" || dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "V"))
                        //    pnlGeneral.Visible = false;

                        if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "LIF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                            pnlLife.Visible = true;

                        if (dsObj.Tables[0].Rows[0]["PremWarranty"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "0"))
                            pnlNonLife.Visible = true;

                        if (pnlGeneral.Visible == false)
                        {
                            var p1 = pnlLife.Location;
                            pnlLife.Location = pnlGeneral.Location;
                            pnlNonLife.Location = p1;
                        }
                        if (pnlGeneral.Visible == false && pnlLife.Visible == false)
                        {
                            pnlNonLife.Location = pnlGeneral.Location;
                        }
                        if (pnlGeneral.Visible == false && pnlLife.Visible == true)
                        {
                            pnlNonLife.Location = pnlNonLife.Location;
                        }
                    }


                    //if (dsObj.Tables[0].Rows[0]["StampDuty"] != DBNull.Value)
                    //    txtStampDuty.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["StampDuty"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value)
                    //    txtServiceFee.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["ServiceFee"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["Premium"] != DBNull.Value)
                    //    txtGrossPrem.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Premium"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value)
                    //    txtInsurerGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()));

                    //if (dsObj.Tables[0].Rows[0]["BrokerageRate"] != DBNull.Value)
                    //    txtBrokPer.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerageRate"].ToString())) + "%";
                    //if (dsObj.Tables[0].Rows[0]["Brokerage"] != DBNull.Value)
                    //    txtBrokAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Brokerage"].ToString()));

                    //if (dsObj.Tables[0].Rows[0]["BrokerGST"] != DBNull.Value)
                    //    txtBrokerGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGST"].ToString())) + "%";
                    //if (dsObj.Tables[0].Rows[0]["BrokerGSTAmount"] != DBNull.Value)
                    //    txtBrokerGSTGSTAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGSTAmount"].ToString()));

                    //if (dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value)
                    //    txtServiceFeeGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["OtherCharges"] != DBNull.Value)
                    //    txtOtherCharge.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["OtherCharges"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["Discount"] != DBNull.Value)
                    //    txtDiscount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Discount"].ToString()));
                    //if (dsObj.Tables[0].Rows[0]["PolicyCharge"] != DBNull.Value)
                    //    txtPolicyCharge.Value = "";// dsObj.Tables[0].Rows[0]["PolicyCharge"].ToString(); 
                    //if (dsObj.Tables[0].Rows[0]["ClientName"] != DBNull.Value)
                    //    txtInsuredName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
                  


                }

                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtCompanyName.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["CompanyName"]).ToUpper();
                    txtCompanyName1.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["CompanyName"]);
                    txtCompanyAddress.Value = dsObj.Tables[1].Rows[0]["CompanyAdd1"].ToString() + " " + dsObj.Tables[1].Rows[0]["CompanyAdd2"].ToString() + " " + dsObj.Tables[1].Rows[0]["CompanyAdd3"].ToString() + Environment.NewLine + dsObj.Tables[1].Rows[0]["CompanyAdd4"].ToString();
                    //txtClientName.Value =  dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    //txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    //txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    //txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    //txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    //txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                }

                //Values from Table 2
                if (dsObj.Tables[2].Rows.Count > 0)
                {
                    txtClientName.Value = dsObj.Tables[2].Rows[0]["ClientName"].ToString();
                    //txtCompanyName.Value = txtCompanyName1.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                    //txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
                    if (dsObj.Tables[2].Rows[0]["SubClassName"] != DBNull.Value)
                        txtClassofInsurance.Value = ": " + dsObj.Tables[2].Rows[0]["SubClassName"].ToString();       // added for #23642
                    if (dsObj.Tables[2].Rows[0]["PolicyNo"] != DBNull.Value)
                        txtPolicyNo.Value = ": " + dsObj.Tables[2].Rows[0]["PolicyNo"].ToString();       // added for #23642
                    if (dsObj.Tables[2].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[2].Rows[0]["POIToDate"].ToString() == "")
                    {
                        txtPOIFrom.Visible = false;
                        txtPOITo.Visible = false;
                    }
                    else
                    {
                        txtPOIFrom.Value = ": " + dsObj.Tables[2].Rows[0]["POIFromDate"].ToString();
                        txtPOITo.Value = "" + dsObj.Tables[2].Rows[0]["POIToDate"].ToString();
                    }
                    if (dsObj.Tables[2].Rows[0]["Insured"] != DBNull.Value)
                        txtInsuredName.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
                    if (dsObj.Tables[2].Rows[0]["Insurer Name"] != DBNull.Value)
                        txtInsurerName.Value = ": " + dsObj.Tables[2].Rows[0]["Insurer Name"].ToString();  
                }
                if (dsObj.Tables[3].Rows.Count > 0)
                {
                    if (dsObj.Tables[3].Rows[0]["ServiceFee"] != DBNull.Value || dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value)
                    {
                        txtTotalDue.Value = Convert.ToString((dsObj.Tables[3].Rows[0]["ServiceFee"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"]));
                        txtTotalDue.Value = ConvertIntoNumeric((dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString()) + Convert.ToDecimal(txtTotalDue.Value)));
                    }
                    if (dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value)
                        txtGSTAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString()));
                    if (dsObj.Tables[3].Rows[0]["ServiceFee"] != DBNull.Value)
                    {
                        txtAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"].ToString()));
                    }
                }

                //if (dsObj.Tables[0].Rows.Count > 0 && Convert.ToString(dsObj.Tables[0].Rows[0]["CoInsurance"]) == "Y" && Convert.ToString(dsObj.Tables[0].Rows[0]["Installment"]) == "Y")
                //{
                //    DataTable dtinstallment = new DataTable();
                //    dtinstallment.Columns.Add("DueDate");
                //    dtinstallment.Columns.Add("GrossPr");
                //    // int maxRow = dsObj.Tables[3].Rows.Count - 1;
                //    for (int i = 0; i <= 2; i++)
                //    {
                //        DataRow objDataRow = dtinstallment.NewRow();
                //        objDataRow["DueDate"] = "dd/mm/yyyy";
                //        objDataRow["GrossPr"] = "99999.99";
                //        dtinstallment.Rows.Add(objDataRow);
                //    }
                //    tblInstalment.DataSource = dtinstallment;
                //    tblInstalment.Visible = true;
                //    lblInstalment.Visible = true;
                //    txtTotal.Value = "99999.99";
                //    DataTable objDataTabledtInsurer = new DataTable();
                //    objDataTabledtInsurer.Columns.Add("UnderwriterName");
                //    objDataTabledtInsurer.Columns.Add("UWShare");
                //    // int maxRow = dsObj.Tables[3].Rows.Count - 1;
                //    for (int i = 0; i <= 8; i++)
                //    {
                //        DataRow objDataRow = objDataTabledtInsurer.NewRow();
                //        objDataRow["UnderwriterName"] = "XXXXX";
                //        if (i == 0)
                //        {
                //            objDataRow["UWShare"] = "99.99%" + " <share percentage>";
                //        }
                //        else
                //        {
                //            objDataRow["UWShare"] = "99.99%";
                //        }
                //        objDataTabledtInsurer.Rows.Add(objDataRow);
                //    }
                //    tblInsurerList.DataSource = objDataTabledtInsurer;
                //    tblInsurerList.Visible = true;

                //    //if (dsObj.Tables[4].Rows.Count > 0)
                //    //{
                //    DataTable dtAgent = new DataTable();
                //    // dtAgent = dsObj.Tables[4];
                //    DataTable objDataTableAgent = new DataTable();
                //    objDataTableAgent.Columns.Add("Col1");
                //    objDataTableAgent.Columns.Add("Col2");
                //    objDataTableAgent.Columns.Add("Col3");
                //    objDataTableAgent.Columns.Add("Col4");
                //    // int maxRow = dsObj.Tables[3].Rows.Count - 1;
                //    for (int i = 0; i <= 1; i++)
                //    {
                //        DataRow objDataRow = objDataTableAgent.NewRow();
                //        objDataRow["Col1"] = "Agent " + (i + 1).ToString();
                //        objDataRow["Col2"] = "XXXXX";
                //        // objDataRow["Col2"] = dtAgent.Rows[i]["AgentCode"].ToString();
                //        objDataRow["Col3"] = "Agent Comm " + (i + 1).ToString();
                //        //objDataRow["Col4"] = dtAgent.Rows[i]["AgentShare"].ToString() + "%";
                //        objDataTableAgent.Rows.Add(objDataRow);
                //    }
                //    tblAgent.DataSource = objDataTableAgent;
                //    //  }


                //    //if (dsObj.Tables[2].Rows.Count > 0)
                //    //{
                //    DataTable dtDW = new DataTable();
                //    //dtDW = dsObj.Tables[2];
                //    //tblInsurerList.DataSource = dsObj.Tables[2];
                //    DataTable objDataUW = new DataTable();
                //    objDataUW.Columns.Add("Col1");
                //    objDataUW.Columns.Add("Col2");
                //    objDataUW.Columns.Add("Col3");
                //    objDataUW.Columns.Add("Col4");
                //    objDataUW.Columns.Add("Col5");
                //    // int maxRow = dsObj.Tables[2].Rows.Count - 1;
                //    for (int i = 0; i <= 1; i++)
                //    {
                //        DataRow objDataRow = objDataUW.NewRow();
                //        objDataRow["Col1"] = "Insurer " + (i + 1).ToString();
                //        objDataRow["Col2"] = "XXXX";
                //        //objDataRow["Col2"] = dtDW.Rows[i]["UnderWriterCode"].ToString();
                //        objDataRow["Col3"] = "Premium " + (i + 1).ToString();
                //        objDataRow["Col4"] = "9.99%";
                //        objDataRow["Col5"] = "9999.99";
                //        //objDataRow["Col4"] = dtDW.Rows[i]["UWShare"].ToString() + "%";
                //        //objDataRow["Col5"] = ConvertIntoNumeric(Convert.ToDecimal(dtDW.Rows[i]["TotalDue"].ToString()));
                //        objDataUW.Rows.Add(objDataRow);
                //    }
                //    tblUW.DataSource = objDataUW;
                //    lblInsurer.Visible = true;

                //    //}
                //    //if (dsObj.Tables[2].Rows.Count > 2)
                //    //{
                //    //    tblInsurerList.Visible = true;

                //    //tblInsurerList.DataSource = dsObj.Tables[2];
                //    //    txtInsurerName.Value = ": PLEASE SEE ATTACHED";
                //    //}
                //    //if (dsObj.Tables[5].Rows.Count > 0)
                //    //{
                //    //    dsObj.Tables[5].Columns["TotalDue"].DataType = typeof(Decimal);
                //    //    foreach (DataRow dr in dsObj.Tables[5].Rows)
                //    //    {
                //    //        dr["TotalDue"] = (dr["TotalDue"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(dr["TotalDue"]);
                //    //    }
                //    //    tblInstalment.Visible = true;
                //    //    lblInstalment.Visible = true;
                //    //    if (dsObj.Tables[0].Rows.Count > 0)
                //    //    {
                //    //        textBox59.Value = "Gross Premium " + "<" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";
                //    //    }
                //    //    tblInstalment.DataSource = dsObj.Tables[5];
                //    //}
                //    txtStampDuty.Value = "9.99";
                //    txtGrossPrem.Value = "9999.99";
                //    txtServiceFee.Value = "9.99";
                //    txtBrokerage.Value = "9.99";
                //    txtInsurerGST.Value = "9999.99";
                //    txtGSTbrokerage.Value = "9.99";
                //    txtServiceFeeGST.Value = "9.99";
                //    txtOtherCharge.Value = "9.99";
                //    txtDiscount.Value = "9.99";
                //    txtPolicystatus.Value = "XXXX";
                //    txtCustPremium.Value = "9999.99";
                //}
                if (dsObj.Tables[0].Rows.Count > 0 && Convert.ToString(dsObj.Tables[0].Rows[0]["CoInsurance"]) == "Y" && Convert.ToString(dsObj.Tables[0].Rows[0]["Installment"]) == "Y")
                {
                    txtStampDuty.Value = "";
                    txtGrossPrem.Value = "";
                    txtServiceFee.Value = "";
                    txtBrokerage.Value = "";
                    txtInsurerGST.Value = "";
                    txtGSTbrokerage.Value = "";
                    txtServiceFeeGST.Value = "";
                    txtOtherCharge.Value = "";
                    txtDiscount.Value = "";
                    txtPolicystatus.Value = "";
                    tblInstalment.Visible = true;
                    lblInstalment.Visible = true;
                    lblInsurer.Visible = true;
                    tblInsurerList.Visible = true;
                    textBox76.Visible = false;
                    txtTotal.Visible = false;
                    textBox73.Value = "";
                    textBox74.Value = "";
                    textBox72.Value = "";
                    textBox71.Value = "";
                    txtCustPremium.Value = "";
                    paneldetail.Visible = true;
                    DataTable objDataTableAgent = new DataTable();
                    objDataTableAgent.Columns.Add("Col1");
                    objDataTableAgent.Columns.Add("Col2");
                    objDataTableAgent.Columns.Add("Col3");
                    objDataTableAgent.Columns.Add("Col4");
                    // int maxRow = dsObj.Tables[3].Rows.Count - 1;
                    for (int i = 0; i <= 1; i++)
                    {
                        DataRow objDataRow = objDataTableAgent.NewRow();
                        objDataRow["Col1"] = "Agent " + (i + 1).ToString();
                        objDataRow["Col2"] = "";
                        // objDataRow["Col2"] = dtAgent.Rows[i]["AgentCode"].ToString();
                        objDataRow["Col3"] = "Agent Comm " + (i + 1).ToString();
                        //objDataRow["Col4"] = dtAgent.Rows[i]["AgentShare"].ToString() + "%";
                        objDataTableAgent.Rows.Add(objDataRow);
                    }
                   // tblAgent.DataSource = objDataTableAgent;
                    DataTable objDataUW = new DataTable();
                    objDataUW.Columns.Add("Col1");
                    objDataUW.Columns.Add("Col2");
                    objDataUW.Columns.Add("Col3");
                    objDataUW.Columns.Add("Col4");
                    objDataUW.Columns.Add("Col5");
                    // int maxRow = dsObj.Tables[2].Rows.Count - 1;
                    for (int i = 0; i <= 1; i++)
                    {
                        DataRow objDataRow = objDataUW.NewRow();
                        objDataRow["Col1"] = "Insurer " + (i + 1).ToString();
                        objDataRow["Col2"] = "";
                        //objDataRow["Col2"] = dtDW.Rows[i]["UnderWriterCode"].ToString();
                        objDataRow["Col3"] = "Premium " + (i + 1).ToString();
                        objDataRow["Col4"] = "";
                        objDataRow["Col5"] = "";
                        //objDataRow["Col4"] = dtDW.Rows[i]["UWShare"].ToString() + "%";
                        //objDataRow["Col5"] = ConvertIntoNumeric(Convert.ToDecimal(dtDW.Rows[i]["TotalDue"].ToString()));
                        objDataUW.Rows.Add(objDataRow);
                    }
                    //tblUW.DataSource = objDataUW;
                }
                else
                {
                    txtStampDuty.Visible = false;
                    txtGrossPrem.Visible = false;
                    txtServiceFee.Visible = false;
                    txtBrokerage.Visible = false;
                    txtInsurerGST.Visible = false;
                    txtGSTbrokerage.Visible = false;
                    txtServiceFeeGST.Visible = false;
                    txtOtherCharge.Visible = false;
                    txtDiscount.Visible = false;
                    txtPolicystatus.Visible = false;
                    textBox31.Visible = false;
                    textBox41.Visible = false;
                    textBox44.Visible = false;
                    textBox52.Visible = false;
                    textBox70.Visible = false;
                    textBox43.Visible = false;
                    textBox40.Visible = false;
                    textBox38.Visible = false;
                    textBox10.Visible = false;
                    textBox36.Visible = false;
                    textBox35.Visible = false;
                    tblInstalment.Visible = false;
                    lblInstalment.Visible = false;
                    lblInsurer.Visible = false;
                    tblInsurerList.Visible = false;
                    textBox76.Visible = false;
                    txtTotal.Visible = false;
                    textBox73.Visible = false;
                    textBox74.Visible = false;
                    textBox72.Visible = false;
                    textBox71.Visible = false;
                    textBox50.Visible = false;
                    textBox53.Visible = false;
                    textBox48.Visible = false;
                    textBox57.Visible = false;
                    textBox55.Visible = false;
                    textBox49.Visible = false;
                    textBox51.Visible = false;
                    textBox47.Visible = false;
                    textBox56.Visible = false;
                    txtTotal.Visible = false;
                    textBox76.Visible = false;
                    tblUW.Visible = false;
                    textBox67.Visible = false;
                    textBox63.Visible = false;
                    tblAgent.Visible = false;
                    textBox61.Visible = false;
                    textBox42.Visible = false;
                    textBox32.Visible = false;
                    textBox59.Visible = false;
                    //panel2.Visible = false;
                    this.paneldetail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0D);
                   // this.detail.CanShrink = false;
                    this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.600001335144043D);
                }
            }
        }

        public static string ConvertIntoNumeric(decimal number)
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
            //String.Format("{0:n}", Convert.ToDouble(number));
            return str;

        }
    }
}