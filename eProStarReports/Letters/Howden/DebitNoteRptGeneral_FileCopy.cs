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
    public partial class DebitNoteRptGeneral_FileCopy : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneral_FileCopy()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRptGeneral_FileCopy(DataSet dsObj, string strClientCode, string fileCopy)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            string _customizedClient = String.Empty;
            BusinessAccessLayer.Common.clsCommon _cmn = new BusinessAccessLayer.Common.clsCommon();
            _customizedClient = _cmn.GetCustomizedClient();
            if (_customizedClient.ToUpper() == "HOWDENSG")
            {
                textBox2.Value = "Premium";
                //textBox11.Visible = false;
                //txtDebitNoteDate.Visible = false;
                textBox20.Value = textBox20.Value.Replace("1. ", "");
                textBox16.Value = textBox20.Value.Replace("2. ", "");
                textBox33.Value = textBox20.Value.Replace("3. ", "");
                textBox2.Value = "PREMIUM";
                txtGST.Value = "INSURER'S GST";
                textBox28.Value = "TOTAL";
            }
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
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //--start --commented for redmine #34313
                    //if (dsObj.Tables[0].Rows[0]["DebitNoteNo"] != DBNull.Value)
                    //    txtDebitNoteNo.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value)
                    //    txtDebitNoteDate.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value)
                    //    txtClientCode.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                    //    txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["Servicer"] != DBNull.Value)
                    //    txtServicer.Value = ": " + dsObj.Tables[0].Rows[0]["Servicer"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["BillingDueDate"] != DBNull.Value)
                    //    txtDueDate.Value = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["BankId"] != DBNull.Value)
                    //    textBox65.Value = "" + dsObj.Tables[0].Rows[0]["BankId"].ToString();
                    //--- end ----

                    DataTable _dtLabels = new DataTable();
                    _dtLabels.Columns.Add("Col1");
                    _dtLabels.Columns.Add("Col2");

                    DataRow _rowLable = _dtLabels.NewRow();
                    _rowLable["Col1"] = "Debit Note No.";
                    _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                    _dtLabels.Rows.Add(_rowLable);
                    if (_customizedClient.ToUpper() != "HOWDENSG")
                    {
                        _rowLable = _dtLabels.NewRow();
                        _rowLable["Col1"] = "Debit Note Date.";
                        _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
                        _dtLabels.Rows.Add(_rowLable);
                    }
                    _rowLable = _dtLabels.NewRow();
                    _rowLable["Col1"] = "Client Code";
                    _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                    _dtLabels.Rows.Add(_rowLable);

                    _rowLable = _dtLabels.NewRow();
                    _rowLable["Col1"] = "Cover Note No.";
                    _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    _dtLabels.Rows.Add(_rowLable);

                    _rowLable = _dtLabels.NewRow();
                    _rowLable["Col1"] = "Servicer.";
                    _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["Servicer"].ToString();
                    _dtLabels.Rows.Add(_rowLable);

                    _rowLable = _dtLabels.NewRow();
                    _rowLable["Col1"] = "Due Date";
                    _rowLable["Col2"] = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();
                    _dtLabels.Rows.Add(_rowLable);

                    tbluppermenus.DataSource = _dtLabels;

                    if (dsObj.Tables[0].Rows[0]["BankName"] != DBNull.Value)
                        txtBankName.Value = "" + dsObj.Tables[0].Rows[0]["BankName"].ToString();
                    if (dsObj.Tables[0].Rows[0]["SwiftCode"] != DBNull.Value)
                        textBox39.Value = "" + dsObj.Tables[0].Rows[0]["SwiftCode"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ACNo"] != DBNull.Value)
                        textBox37.Value = "" + dsObj.Tables[0].Rows[0]["ACNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["Remarks"] != DBNull.Value)
                        txtParticular.Value = ": " + dsObj.Tables[0].Rows[0]["Remarks"].ToString();

                    //PolicyDetails
                    if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value)
                        txtClassofInsurance.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value)
                        txtPolicyNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
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


                    if (dsObj.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value)
                        if (_customizedClient.ToUpper() == "HOWDENSG")
                        {
                            txtCurrency.Value = txtCurr1.Value = txtCurr2.Value = ": " + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString(); //redmine #34313
                        }
                        else
                        {
                            txtCurrency.Value = txtCurr1.Value = txtCurr2.Value = ": <" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";       // added for #23642
                        }
                    if (dsObj.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value)
                        txtGSTAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value)
                    {
                        txtTotalDue.Value =ConvertIntoNumeric( Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));
                    }
                    if (dsObj.Tables[0].Rows[0]["CLTotalDue"] != DBNull.Value)
                    {
                       // txtAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["CLTotalDue"].ToString()));      // added for #23642
                        txtAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()) - Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()))); // #23516
                        txtCustPremium.Value = txtTotalDue.Value;
                    }

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


                    if (dsObj.Tables[0].Rows[0]["StampDuty"] != DBNull.Value)
                        txtStampDuty.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["StampDuty"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["ServiceFee"] != DBNull.Value)
                        txtServiceFee.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["ServiceFee"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["Premium"] != DBNull.Value)
                        txtGrossPrem.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Premium"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value)
                        txtInsurerGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()));

                    //if (dsObj.Tables[0].Rows[0]["BrokerageRate"] != DBNull.Value)
                    //    txtBrokPer.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerageRate"].ToString())) + "%";
                    //if (dsObj.Tables[0].Rows[0]["Brokerage"] != DBNull.Value)
                    //    txtBrokAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Brokerage"].ToString()));

                    //if (dsObj.Tables[0].Rows[0]["BrokerGST"] != DBNull.Value)
                    //    txtBrokerGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGST"].ToString())) + "%";
                    //if (dsObj.Tables[0].Rows[0]["BrokerGSTAmount"] != DBNull.Value)
                    //    txtBrokerGSTGSTAmt.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGSTAmount"].ToString()));

                    if (dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value)
                        txtServiceFeeGST.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["ServiceFeeGSTAmount"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["OtherCharges"] != DBNull.Value)
                        txtOtherCharge.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["OtherCharges"].ToString()));
                    if (dsObj.Tables[0].Rows[0]["Discount"] != DBNull.Value)
                        txtDiscount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Discount"].ToString()));
                    if (_customizedClient.ToUpper()=="HOWDENSG") // added by redmine #34313
                    {
                        textBox75.Visible = false;
                        if (!String.IsNullOrEmpty(dsObj.Tables[0].Rows[0]["Discount"].ToString()) && dsObj.Tables[0].Rows[0]["Discount"].ToString() != "0.00")
                        {
                            txtCLDiscount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Discount"].ToString()));
                            textBox75.Visible = true;
                        }

                        if (dsObj.Tables[0].Rows[0]["Brokerage"] != DBNull.Value)  //added for redmine #34313
                        {
                            txtBrokerage.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Brokerage"].ToString()));
                        }
                        if (dsObj.Tables[0].Rows[0]["BrokerGSTAmount"] != DBNull.Value)  //added for redmine #34313
                        {
                            txtBrokerageGSTAmount.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["BrokerGSTAmount"].ToString()));
                        }
                        if (dsObj.Tables[0].Rows[0]["PolicyCharge"] != DBNull.Value) //added for redmine #34313
                        {
                            textBox43.Value = "Policy Charges";
                            txtOtherCharge.Value = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["PolicyCharge"]).ToString("#,##0.00");
                        }

                    }
                    
                    //
                    //if (dsObj.Tables[0].Rows[0]["PolicyCharge"] != DBNull.Value)
                    //    txtPolicyCharge.Value = "";// dsObj.Tables[0].Rows[0]["PolicyCharge"].ToString(); 
                    if (dsObj.Tables[0].Rows[0]["ClientName"] != DBNull.Value)
                        txtInsuredName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
                  


                }

                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtClientName.Value =  dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                }

                //Values from Table 2
                if (dsObj.Tables[2].Rows.Count > 0)
                {
                    txtCompanyName.Value = txtCompanyName1.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                    txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
                }

                if (dsObj.Tables[3].Rows.Count > 0)
                {
                    DataTable dtAgent = new DataTable();
                    dtAgent = dsObj.Tables[3];
                    DataTable objDataTableAgent = new DataTable();
                    objDataTableAgent.Columns.Add("Col1");
                    objDataTableAgent.Columns.Add("Col2");
                    objDataTableAgent.Columns.Add("Col3");
                    objDataTableAgent.Columns.Add("Col4");
                    int maxRow = dsObj.Tables[3].Rows.Count - 1;
                    for (int i = 0; i <= maxRow; i++)
                    {
                        DataRow objDataRow = objDataTableAgent.NewRow();
                        objDataRow["Col1"] =( _customizedClient.ToUpper() == "HOWDENSG" ? "Introducer " : "Agent ")  + (i + 1).ToString();
                        objDataRow["Col2"] = dtAgent.Rows[i]["AgentCode"].ToString();
                        objDataRow["Col3"] = ( _customizedClient.ToUpper() == "HOWDENSG" ? "Introducer ":"Agent ")+ "Comm " + (i + 1).ToString();
                        objDataRow["Col4"] = dtAgent.Rows[i]["AgentShare"].ToString() + "%";
                        objDataTableAgent.Rows.Add(objDataRow);
                    }
                    tblAgent.DataSource = objDataTableAgent;
                    //added for redmine #34313
                    if (_customizedClient.ToUpper() == "HOWDENSG" && !String.IsNullOrEmpty(dsObj.Tables[3].Rows[0]["AgentName"].ToString()))
                    {
                        txtIntroducerName.Value = dsObj.Tables[3].Rows[0]["AgentName"].ToString();
                        txtcommValue.Value = dsObj.Tables[3].Rows[0]["TotalDue"].ToString(); //redmine #34313
                    }
                }

                if (_customizedClient.ToUpper() == "HOWDENSG") // added for redmine #34313
                {
                    decimal _grandTotal = 0.00M;
                    //txtGrandTotal.Value = String.Empty;
                    int _rowInfo = 1;
                    DataTable objDataUW = new DataTable();
                    objDataUW.Columns.Add("Col1");
                    objDataUW.Columns.Add("Col2");
                    objDataUW.Columns.Add("Col3");
                    objDataUW.Columns.Add("Col4");
                    objDataUW.Columns.Add("Col5");
                    bool _coInsurer = false;
                    if (!String.IsNullOrEmpty(dsObj.Tables[6].Rows[0]["Coinsurer"].ToString()))
                    {
                        _coInsurer = dsObj.Tables[6].Rows[0]["Coinsurer"].ToString() == "Y" ? true : false;
                    }
                    for (int i = 0; i < dsObj.Tables[4].Rows.Count; i++)
                    {
                        string _label = "Insurer : ";
                        DataRow objDataRow = null;
                        DataRow _objDatablankRow = null;
                        //if (_coInsurer == false && !String.IsNullOrEmpty(dsObj.Tables[4].Rows[i]["UnderwriterName"].ToString()))
                        //{
                        //    _label = _label + dsObj.Tables[4].Rows[i]["UnderwriterName"].ToString();
                        //}
                        //else
                        //{
                        //    _label = dsObj.Tables[4].Rows[i]["UnderwriterName"].ToString();
                        //}
                        
                        if (!String.IsNullOrEmpty(dsObj.Tables[4].Rows[i]["UwCode"].ToString()))
                        {

                            if (_rowInfo == 1)
                            {
                                objDataRow = objDataUW.NewRow();
                                if (_coInsurer == false && !String.IsNullOrEmpty(dsObj.Tables[4].Rows[i]["UnderwriterName"].ToString()))
                                {
                                     objDataRow["Col1"] = "Insurer : ";
                                }
                                else
                                {
                                    objDataRow["Col1"] = String.Empty;
                                }

                                objDataRow["Col2"] = dsObj.Tables[4].Rows[i]["UwCode"].ToString();
                                objDataRow["Col3"] = dsObj.Tables[4].Rows[i]["UnderwriterName"].ToString();;
                                objDataRow["Col4"] = String.Empty;
                                objDataRow["Col5"] = String.Empty;
                                objDataUW.Rows.Add(objDataRow);
                                //_objDatablankRow = setBlankRow(_objDatablankRow, objDataUW);
                                objDataUW.Rows.Add(setBlankRow(_objDatablankRow, objDataUW));
                                _rowInfo++;
                            }
                            if (_rowInfo == 2)
                            {
                                objDataRow = objDataUW.NewRow();
                                objDataRow["Col1"] = "Gross Premium";
                                objDataRow["Col2"] = Convert.ToDecimal(dsObj.Tables[4].Rows[i]["TotalDue"]).ToString("#,##0.00");
                                objDataRow["Col3"] = dsObj.Tables[4].Rows[i]["UWShare"].ToString() + " %";
                                objDataRow["Col4"] = "GST";
                                objDataRow["Col5"] = Convert.ToDecimal(dsObj.Tables[4].Rows[i]["InsurerGSTAmount"]).ToString("#,##0.00");
                                objDataUW.Rows.Add(objDataRow);
                                _rowInfo++;
                            }
                            if (_rowInfo == 3)
                            {
                                objDataRow = objDataUW.NewRow();
                                objDataRow["Col1"] = "Commission";
                                objDataRow["Col2"] = Convert.ToDecimal(dsObj.Tables[4].Rows[i]["Brokerage"]).ToString("#,##0.00");
                                objDataRow["Col3"] = dsObj.Tables[4].Rows[i]["BrokerageRate"].ToString() + " %";
                                objDataRow["Col4"] = "GST";
                                objDataRow["Col5"] = Convert.ToDecimal(dsObj.Tables[4].Rows[i]["PolicyCharge"]).ToString("#,##0.00");
                                objDataUW.Rows.Add(objDataRow);                                
                                _rowInfo++;
                            }
                            if (_rowInfo == 4)
                            {
                                objDataRow = objDataUW.NewRow();
                                objDataRow["Col1"] = "Ins Net Premium";
                                decimal _brokerage = 0.00m;
                                decimal _clientDiscount = 0.00m;
                                decimal _introducerValue = 0.00m;
                                if (!String.IsNullOrEmpty(dsObj.Tables[4].Rows[i]["Brokerage"].ToString()))
                                {
                                    _brokerage = Convert.ToDecimal(dsObj.Tables[4].Rows[i]["Brokerage"]);
                                }
                                if (!String.IsNullOrEmpty(dsObj.Tables[0].Rows[0]["Discount"].ToString()))
                                {
                                    _clientDiscount = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Discount"]);
                                }
                                if (!String.IsNullOrEmpty(dsObj.Tables[3].Rows[0]["TotalDue"].ToString()))
                                {
                                    _introducerValue = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["TotalDue"]);
                                }
                                objDataRow["Col2"] = (_brokerage - _clientDiscount - _introducerValue).ToString("#,##0.00");
                                objDataUW.Rows.Add(objDataRow);
                                objDataUW.Rows.Add(setBlankRow(_objDatablankRow, objDataUW));
                                _rowInfo = 1;
                            }
                        }
                        _grandTotal = _grandTotal + Convert.ToDecimal(dsObj.Tables[4].Rows[i]["TotalDue"]);
                        
                        if (dsObj.Tables[4].Rows.Count > 3)
                        { 
                            txtInsurerName.Value = ": PLEASE SEE ATTACHED";
                        }
                        
                    }

                    if (_coInsurer == true)
                    {
                        DataTable _dt = new DataTable();
                        _dt.Columns.Add("Col1");
                        _dt.Columns.Add("Col2");
                        _dt.Columns.Add("Col3");
                        _dt.Columns.Add("Col4");
                        _dt.Columns.Add("Col5");
                        DataRow objDataRow = _dt.NewRow();
                        objDataRow["Col1"] = "Grand Total: ";
                        objDataRow["Col2"] = _grandTotal.ToString("#,##0.00");
                        objDataRow["Col3"] = String.Empty;
                        objDataRow["Col4"] = String.Empty;
                        objDataRow["Col5"] = String.Empty;
                        _dt.Rows.Add(objDataRow);
                        tblmain.DataSource = objDataUW;
                    }
                    tblUW.DataSource = objDataUW;
                }
                else
                {
                    if (dsObj.Tables[4].Rows.Count > 0)
                    {
                        DataTable dtDW = new DataTable();
                        dtDW = dsObj.Tables[4];
                        tblInsurerList.DataSource = dsObj.Tables[4];
                        DataTable objDataUW = new DataTable();
                        objDataUW.Columns.Add("Col1");
                        objDataUW.Columns.Add("Col2");
                        objDataUW.Columns.Add("Col3");
                        objDataUW.Columns.Add("Col4");
                        objDataUW.Columns.Add("Col5");
                        int maxRow = dsObj.Tables[4].Rows.Count - 1;
                        for (int i = 0; i <= maxRow; i++)
                        {
                            DataRow objDataRow = objDataUW.NewRow();
                            objDataRow["Col1"] = "Insurer " + (i + 1).ToString();
                            objDataRow["Col2"] = dtDW.Rows[i]["UnderWriterCode"].ToString();
                            objDataRow["Col3"] = "Premium " + (i + 1).ToString();
                            objDataRow["Col4"] = dtDW.Rows[i]["UWShare"].ToString() + "%";
                            objDataRow["Col5"] = ConvertIntoNumeric(Convert.ToDecimal(dtDW.Rows[i]["TotalDue"].ToString()));
                            objDataUW.Rows.Add(objDataRow);
                        }
                        tblUW.DataSource = objDataUW;
                    }
                    if (dsObj.Tables[4].Rows.Count > 3)
                    {
                        tblInsurerList.Visible = true;
                        lblInsurer.Visible = true;
                        tblInsurerList.DataSource = dsObj.Tables[4];
                        txtInsurerName.Value = ": PLEASE SEE ATTACHED";

                    }
                }
                if (dsObj.Tables[5].Rows.Count > 0)
                {
                    dsObj.Tables[5].Columns["TotalDue"].DataType = typeof(Decimal);
                    foreach (DataRow dr in dsObj.Tables[5].Rows)
                    {
                        dr["TotalDue"] = (dr["TotalDue"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(dr["TotalDue"]);
                    }
                    //foreach (DataRow dr in dsObj.Tables[5].Rows)
                    //{
                    //    dr["UnderwriterName"] = (dr["UnderwriterName"] == DBNull.Value) ? String.Empty : "Insurer : " + dr["UnderwriterName"].ToString() + dr["UwCode"].ToString();
                    //}
                    tblInstalment.Visible = true;
                    lblInstalment.Visible = true;
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        if (_customizedClient.ToUpper() == "HOWDENSG")
                        {
                            textBox59.Value = "Gross Premium " + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString(); //redmine #34313
                        }
                        else
                        {
                            textBox59.Value = "Gross Premium " + "<" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";
                        }  
                    }
                    
                    tblInstalment.DataSource = dsObj.Tables[5];
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

        private DataRow setBlankRow(DataRow _objDatablankRow, DataTable objDataUW)
        {
            _objDatablankRow = objDataUW.NewRow();
            _objDatablankRow["Col1"] = String.Empty;
            _objDatablankRow["Col2"] = String.Empty;
            _objDatablankRow["Col3"] = String.Empty;
            _objDatablankRow["Col4"] = String.Empty;
            _objDatablankRow["Col5"] = String.Empty;
            return _objDatablankRow;
        }
    }
}