namespace eProStarReports.Letters.LCH
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Linq;

    /// <summary>
    /// Summary description for CreditNoteMarine_LCH.
    /// </summary>
    internal partial class DebitCreditNoteVessel_LCH : Telerik.Reporting.Report
    {
        public DebitCreditNoteVessel_LCH()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
        }

        public DebitCreditNoteVessel_LCH(DataSet dsObj, string strClientCode, string strChkInstl, int clientFlag, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportData(dsObj, strClientCode);
            ClientShowHideControl();
            SetPremDataDebit(dsObj, strClientCode, strChkInstl);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;
        }





        public DebitCreditNoteVessel_LCH(DataSet dsObj, string strUwCode, string strChkInstl, string sUWCrNotePrintOptions, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportDataUw(dsObj);
            UWShowHideControl(sUWCrNotePrintOptions);
            SetPremDataCredit(dsObj, strUwCode, strChkInstl, sUWCrNotePrintOptions);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;
        }

        public DebitCreditNoteVessel_LCH(DataSet dsObj, DataRow dr, string strChkInstl, string sUWCrNotePrintOptions, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportDataUw(dsObj);
            UWShowHideControl(sUWCrNotePrintOptions);
            SetPremDataCredit(dsObj, dr, strChkInstl, sUWCrNotePrintOptions);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;
        }

        private void ClientShowHideControl()
        {
            textBox22.Visible = false;
            textBox23.Visible = false;
            txtShareTot.Visible = false;

            txtTextRef.Visible = false;
            txtRefNo.Visible = false;
            textBox13.Visible = false;

            //PREMIUM
            txtTextPremium.Visible = true;
            txtPremium.Visible = true;

            //PREMIUM TAX S
            txtTextPremiumTax.Visible = false;
            txtPremiumTax.Visible = false;
            txtPremiumGST.Visible = false;

            //PREMIUM DUE	
            txtTextPremDue.Visible = true;
            txtPremiumDue.Visible = true;

            //BROKERAGE G
            txtTextBrokerage.Visible = false;
            txtBrokerage.Visible = false;
            txtUWBrokerage.Visible = false;

            //BROKERAGE TAX S
            txtTextBrokerageTax.Visible = false;
            txtBrokerageTax.Visible = false;
            txtBrokerGST.Visible = false;

            //NET PREMIUM DUE
            txtTextNetPremiumDue.Visible = false;
            txtNetPremiumDue.Visible = false;
        }

        private void UWShowHideControl(string sUWCrNotePrintOptions)
        {
            if (!string.IsNullOrEmpty(sUWCrNotePrintOptions))
            {
                if (sUWCrNotePrintOptions == "0")
                {
                    txtTextSumIns.Visible = false;
                    textBox20.Visible = false;
                    txtPremCurr.Visible = false;
                    txtSumInsured.Visible = false;

                    txtTextYourShare.Visible = false;
                    textBox21.Visible = false;
                    txtUwSharePer.Visible = false;
                    txtUwShareAmt.Visible = false;

                    txtTextRef.Visible = false;
                    txtRefNo.Visible = false;
                    textBox13.Visible = false;

                    //PREMIUM
                    txtTextPremium.Visible = true;
                    txtPremium.Visible = true;

                    //PREMIUM TAX S
                    txtTextPremiumTax.Visible = true;
                    txtPremiumTax.Visible = true;
                    txtPremiumGST.Visible = true;

                    //PREMIUM DUE	
                    txtTextPremDue.Visible = true;
                    txtPremiumDue.Visible = true;

                    //BROKERAGE G
                    txtTextBrokerage.Visible = true;
                    txtBrokerage.Visible = true;
                    txtUWBrokerage.Visible = true;

                    //BROKERAGE TAX S
                    txtTextBrokerageTax.Visible = true;
                    txtBrokerageTax.Visible = true;
                    txtBrokerGST.Visible = true;

                    //NET PREMIUM DUE
                    txtTextNetPremiumDue.Visible = true;
                    txtNetPremiumDue.Visible = true;
                }
                if (sUWCrNotePrintOptions == "1")
                {
                    txtTextSumIns.Visible = false;
                    textBox20.Visible = false;
                    txtPremCurr.Visible = false;
                    txtSumInsured.Visible = false;

                    txtTextYourShare.Visible = false;
                    textBox21.Visible = false;
                    txtUwSharePer.Visible = false;
                    txtUwShareAmt.Visible = false;

                    txtTextRef.Visible = false;
                    txtRefNo.Visible = false;
                    textBox13.Visible = false;

                    //PREMIUM
                    txtTextPremium.Visible = true;
                    txtPremium.Visible = true;

                    //PREMIUM TAX S
                    txtTextPremiumTax.Visible = false;
                    txtPremiumTax.Visible = false;
                    txtPremiumGST.Visible = false;

                    //PREMIUM DUE	
                    txtTextPremDue.Visible = true;
                    txtPremiumDue.Visible = true;

                    //BROKERAGE G
                    txtTextBrokerage.Visible = true;
                    txtBrokerage.Visible = true;
                    txtUWBrokerage.Visible = true;

                    //BROKERAGE TAX S
                    txtTextBrokerageTax.Visible = false;
                    txtBrokerageTax.Visible = false;
                    txtBrokerGST.Visible = false;

                    //NET PREMIUM DUE
                    txtTextNetPremiumDue.Visible = true;
                    txtNetPremiumDue.Visible = true;
                }
                if (sUWCrNotePrintOptions == "2")
                {
                    txtTextSumIns.Visible = false;
                    textBox20.Visible = false;
                    txtPremCurr.Visible = false;
                    txtSumInsured.Visible = false;

                    txtTextYourShare.Visible = true;
                    textBox21.Visible = true;
                    txtUwSharePer.Visible = true;
                    txtUwShareAmt.Visible = true;

                    txtTextRef.Visible = false;
                    txtRefNo.Visible = false;
                    textBox13.Visible = false;

                    //PREMIUM
                    txtTextPremium.Visible = false;
                    txtPremium.Visible = false;

                    //PREMIUM TAX S
                    txtTextPremiumTax.Visible = false;
                    txtPremiumTax.Visible = false;
                    txtPremiumGST.Visible = false;

                    //PREMIUM DUE	
                    txtTextPremDue.Visible = false;
                    txtPremiumDue.Visible = false;

                    //BROKERAGE G
                    txtTextBrokerage.Visible = false;
                    txtBrokerage.Visible = false;
                    txtUWBrokerage.Visible = false;

                    //BROKERAGE TAX S
                    txtTextBrokerageTax.Visible = false;
                    txtBrokerageTax.Visible = false;
                    txtBrokerGST.Visible = false;

                    //NET PREMIUM DUE
                    txtTextNetPremiumDue.Visible = true;
                    txtNetPremiumDue.Visible = true;
                }
            }
            else
            {
                txtTextRef.Visible = true;
                txtRefNo.Visible = true;
                textBox13.Visible = true;

                //PREMIUM
                txtTextPremium.Visible = false;
                txtPremium.Visible = false;

                //PREMIUM TAX S
                txtTextPremiumTax.Visible = false;
                txtPremiumTax.Visible = false;
                txtPremiumGST.Visible = false;

                //PREMIUM DUE	
                txtTextPremDue.Visible = false;
                txtPremiumDue.Visible = false;

                //BROKERAGE G
                txtTextBrokerage.Visible = false;
                txtBrokerage.Visible = false;
                txtUWBrokerage.Visible = false;

                //BROKERAGE TAX S
                txtTextBrokerageTax.Visible = false;
                txtBrokerageTax.Visible = false;
                txtBrokerGST.Visible = false;

                //NET PREMIUM DUE
                txtTextNetPremiumDue.Visible = false;
                txtNetPremiumDue.Visible = false;
            }
        }

        private void SetReportData(DataSet dsObj, string strClientCode)
        {
            txtTextDN.Value = "DEBIT NOTE :";

            // Values from Table 0 (filtered)
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "MultiPayeeClientCode = '" + strClientCode + "'";
            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable != null)
            {
                txtDNNumber.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                txtDate.Value = dtViewTable.Rows[0]["DebitNotedate"].ToString();
                txtAccountCode.Value = dtViewTable.Rows[0]["MultiPayeeClientCode"].ToString();
                txtAccountMonth.Value = dtViewTable.Rows[0]["AccMonth"].ToString() + "/" + dtViewTable.Rows[0]["AccYear"].ToString();
                //txtRefNo.Value = dtViewTable.Rows[0]["InsurerDebitNote"].ToString();
                txtRefNo.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

                txtSubClass.Value = dtViewTable.Rows[0]["SubClassName"].ToString();
                txtPolicyNum.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtInsured.Value = dtViewTable.Rows[0]["MultiPayeeClientname"].ToString();
                if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                {
                    txtTextPOI.Visible = false;
                    textBox19.Visible = false;
                    txtPOIFrom.Visible = false;
                    txtTextMiddle.Visible = false;
                    txtPOITo.Visible = false;

                }
                else
                {
                    txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                    txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();
                }
                txtSumInsured.Value = Convert.ToDecimal(dtViewTable.Rows[0]["SumInsuredAmount"].ToString()).ToString("n2");
                txtAccHandler.Value = dtViewTable.Rows[0]["Primary_AccountHandler"].ToString();

                // Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                    txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                    txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                    txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
                }
                else
                {
                    txtCompanyName.Value = "";
                    txtCompAddr.Value = "";
                    txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                    txtMailids.Value = "";
                }



                // Value from Table 3
                if (dsObj.Tables[3].Rows.Count > 0)
                    txtPremCurr.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString();
                else
                    txtPremCurr.Value = "";

                textBox21.Visible = false;  // Semicolon to be hidden

            }
        }

        private void SetReportDataUw(DataSet dsObj)
        {
            txtTextDN.Value = "CREDIT NOTE :";

            // Values from Table 0
            txtDate.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
            txtAccountCode.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            txtAccountMonth.Value = dsObj.Tables[0].Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
            // txtRefNo.Value = dsObj.Tables[0].Rows[0]["InsurerDebitNote"].ToString();
            txtRefNo.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

            txtSubClass.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            txtPolicyNum.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
            {
                txtTextPOI.Visible = false;
                textBox19.Visible = false;
                txtPOIFrom.Visible = false;
                txtTextMiddle.Visible = false;
                txtPOITo.Visible = false;

            }
            else
            {
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            }
            txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
            txtSumInsured.Value = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["SumInsuredAmount"].ToString()).ToString("n2");

            // Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
                txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            }

            else
            {
                txtCompanyName.Value = "";
                txtCompAddr.Value = "";
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = "";
                txtInsured.Value = "";
            }

            // Values from Table 3
            if (dsObj.Tables[3].Rows.Count > 0)
                txtPremCurr.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString();
            else
                txtPremCurr.Value = "";



        }

        private void SetPremDataDebit(DataSet dsObj, string strClientCode, string strCheckedInstl)
        {
            // Value from Table 0 (filtered)
            DataView dvTemp = new DataView(dsObj.Tables[0]);
            dvTemp.RowFilter = "MultiPayeeClientCode = '" + strClientCode + "'";
            DataTable dtTempTable = dvTemp.ToTable();

            txtDNNumber.Value = dtTempTable.Rows[0]["MultiPayeeDNNum"].ToString();
            txtClientName.Value = dtTempTable.Rows[0]["MultiPayeeClientname"].ToString();
            txtClientAddr.Value = dtTempTable.Rows[0]["MultiPayeeclientAddr"].ToString() + Environment.NewLine + dtTempTable.Rows[0]["MultiPayeeCountry"].ToString();
            //decimal tempPrem = Convert.ToDecimal(dtTempTable.Rows[0]["MultiPayeeClientPremium"].ToString());
            decimal tempPrem = Convert.ToDecimal(dtTempTable.Rows[0]["TotalDue"].ToString());
            txtPremium.Value = tempPrem.ToString("n2");
            txtPremiumDue.Value = tempPrem.ToString("n2");

            // Values from Table 3
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                txtCurrency.Value = "(" + dsObj.Tables[3].Rows[0]["Currency"].ToString() + ")";
                txtRemarks.Value = dsObj.Tables[3].Rows[0]["BillingRemarks"].ToString();
            }
            else
            {
                txtCurrency.Value = "";
                txtRemarks.Value = "";
            }

            // Values from Table 4
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                DataTable dtnew = dsObj.Tables[3].AsEnumerable()
                                                  .GroupBy(r => new { UnderwriterCode = r["UnderWriterCode"] })
                                                  .Select(g => g.OrderBy(r => r["UnderWriterCode"]).First())
                                                  .CopyToDataTable();
                tblUW.DataSource = dtnew;
                tblUW.Visible = true;
                object sumShare;
                sumShare = dtnew.Compute("Sum(UWShare)", "");
                decimal shareTot = Convert.ToDecimal(sumShare);
                txtShareTot.Value = shareTot.ToString();

            }

            // Value from Table 5 (For clients installments)
            if (strCheckedInstl != "")
            {
                if (dsObj.Tables.Count > 5 && dsObj.Tables[5].Columns.Contains("ClientShare"))
                {
                    DataView dv = new DataView(dsObj.Tables[5]);
                    dv.RowFilter = "ClientCode = '" + strClientCode + "'";
                    DataTable dtViewTable = dv.ToTable();

                    dv = new DataView(dtViewTable);
                    dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                    dtViewTable = dv.ToTable();

                    tblPremDebitInst.DataSource = dtViewTable;
                    // Declare an object variable.
                    object sumObject;
                    sumObject = dtViewTable.Compute("Sum(Premium)", "");
                    foreach (DataRow row in dtViewTable.Rows)
                    {
                        row["Premium"] = Convert.ToDecimal(row["Premium"]).ToString("n2");
                    }
                    txtTotalPremSum.Value = Convert.ToDecimal(sumObject).ToString("n2");


                }
                else
                {
                    tblPremDebitInst.Visible = false;
                    txtTotalPremSum.Visible = false;
                }
            }
            else
            {
                tblPremDebitInst.Visible = false;
                txtTotalPremSum.Visible = false;
            }

            //The below may be utilized for future requirements of display vessel detials

            //txtVesselName.Value = dsObj.Tables[3].Rows[0]["VesselName"].ToString();
            //txtRate.Value = "@ " + dsObj.Tables[3].Rows[0]["Rate"].ToString() + " "
            //                + " X " + dsObj.Tables[3].Rows[0]["TotalDay"].ToString() + "/"
            //                + dsObj.Tables[3].Rows[0]["BaseDay"].ToString();
            //txtTextPolOrComm.Value = "COMM:";
            //txtPolCostOrComm.Value = dsObj.Tables[3].Rows[0]["UWBrokerage"].ToString();

        }

        private void SetPremDataCredit(DataSet dsObj, string UwCode, string strCheckedInstl, string sUWCrNotePrintOptions)
        {
            // Value from Table 3   
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                txtCurrency.Value = "(" + dsObj.Tables[3].Rows[0]["Currency"].ToString() + ")";
                txtRemarks.Value = dsObj.Tables[3].Rows[0]["BillingRemarks"].ToString();
            }
            else
            {
                txtCurrency.Value = "";
                txtRemarks.Value = "";

            }

            // Values from Table 4 (filtered)
            DataView dvUw = new DataView(dsObj.Tables[4]);
            dvUw.RowFilter = "UnderWriterCode = '" + UwCode + "'";
            DataTable dtUwView = dvUw.ToTable();
            if (dtUwView.Rows.Count > 0)
            {
                txtDNNumber.Value = dtUwView.Rows[0]["UWDebitNoteNo"].ToString();
                txtUwSharePer.Value = dtUwView.Rows[0]["UWShare"].ToString() + " %";
                txtUwShareAmt.Value = Convert.ToDecimal(dtUwView.Rows[0]["UwShareAmount"].ToString()).ToString("n2");
                txtClientName.Value = dtUwView.Rows[0]["UnderWriterName"].ToString();
                txtClientAddr.Value = dtUwView.Rows[0]["UwAddress"].ToString() + Environment.NewLine + dtUwView.Rows[0]["UwAddrCountry"].ToString();

                if (!string.IsNullOrEmpty(sUWCrNotePrintOptions))
                {
                    if (sUWCrNotePrintOptions == "0")
                    {
                        #region <With GST>
                        //PREMIUM
                        decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                        tempPremValue = -tempPremValue;
                        txtPremium.Value = tempPremValue.ToString("n2");

                        //PREMIUM TAX S
                        decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                        tempPremTax = -tempPremTax;
                        txtPremiumTax.Value = tempPremTax.ToString("n2");

                        decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                        txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                        //PREMIUM DUE
                        decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                        tempPremDue = -tempPremDue;
                        txtPremiumDue.Value = tempPremDue.ToString("n2");

                        //BROKERAGE G
                        decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                        txtBrokerage.Value = tempBrokerage.ToString("n2");

                        decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                        txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                        //BROKERAGE TAX S
                        decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                        txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                        decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                        txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                        //NET PREMIUM DUE
                        decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString()));
                        txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                        #endregion
                    }
                    if (sUWCrNotePrintOptions == "1")
                    {
                        #region <Without GST>

                        //PREMIUM
                        decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                        tempPremValue = -tempPremValue;
                        txtPremium.Value = tempPremValue.ToString("n2");

                        //PREMIUM TAX S
                        decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                        tempPremTax = -tempPremTax;
                        txtPremiumTax.Value = tempPremTax.ToString("n2");

                        decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                        txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                        //PREMIUM DUE
                        decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                        tempPremDue = -tempPremDue;
                        txtPremiumDue.Value = tempPremDue.ToString("n2");

                        //BROKERAGE G
                        decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                        txtBrokerage.Value = tempBrokerage.ToString("n2");

                        decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                        txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                        //BROKERAGE TAX S
                        decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                        txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                        decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                        txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                        //NET PREMIUM DUE
                        decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()));
                        txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                        #endregion
                    }
                    if (sUWCrNotePrintOptions == "2")
                    {
                        #region <Custom>

                        //PREMIUM
                        decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                        tempPremValue = -tempPremValue;
                        txtPremium.Value = tempPremValue.ToString("n2");

                        //PREMIUM TAX S
                        decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                        tempPremTax = -tempPremTax;
                        txtPremiumTax.Value = tempPremTax.ToString("n2");

                        decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                        txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                        //PREMIUM DUE
                        decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                        tempPremDue = -tempPremDue;
                        txtPremiumDue.Value = tempPremDue.ToString("n2");

                        //BROKERAGE G
                        decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                        txtBrokerage.Value = tempBrokerage.ToString("n2");

                        decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                        txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                        //BROKERAGE TAX S
                        decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                        txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                        decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                        txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                        //NET PREMIUM DUE
                        decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString()));
                        txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                        #endregion
                    }
                }
                else
                {
                    decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["UwIndivPremium"].ToString());
                    tempPremValue = -tempPremValue;
                    txtPremium.Value = tempPremValue.ToString("n2");
                    txtPremiumDue.Value = tempPremValue.ToString("n2");
                }
            }
            if (strCheckedInstl != "")
            {
                // Values from Table 6 for Under writer installments
                if (dsObj.Tables.Count > 6 && dsObj.Tables[6].Columns.Contains("UWShare"))
                {
                    // Value from Table 6 (filtered)
                    DataView dv = new DataView(dsObj.Tables[6]);
                    dv.RowFilter = "UnderWriterCode = '" + UwCode + "'";
                    DataTable dtViewTable = dv.ToTable();

                    dv = new DataView(dtViewTable);
                    if (strCheckedInstl != "")
                    {
                        dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                    }
                    dtViewTable = dv.ToTable();
                    // Declare an object variable.
                    object sumObject;
                    sumObject = dtViewTable.Compute("Sum(Premium)", "");
                    decimal sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                    foreach (DataRow row in dtViewTable.Rows)
                    {
                        row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (-1)).ToString("n2");
                    }
                    tblPremDebitInst.DataSource = dtViewTable;
                    txtTotalPremSum.Value = sumInstlmt.ToString("n2");

                }
                // Values from Table 5 for Under writer installments
                //(This will be some unique case when clients installments do not show up)
                else if (dsObj.Tables.Count > 5 && dsObj.Tables[5].Columns.Contains("UWShare"))
                {
                    // Value from Table 5 (filtered)
                    DataView dv = new DataView(dsObj.Tables[5]);
                    dv.RowFilter = "UnderWriterCode = '" + UwCode + "'";
                    DataTable dtViewTable = dv.ToTable();

                    dv = new DataView(dtViewTable);
                    if (strCheckedInstl != "")
                    {
                        dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                    }
                    dtViewTable = dv.ToTable();
                    // Declare an object variable.
                    object sumObject;
                    sumObject = dtViewTable.Compute("Sum(Premium)", "");
                    decimal sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                    foreach (DataRow row in dtViewTable.Rows)
                    {
                        row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (-1)).ToString("n2");
                    }
                    tblPremDebitInst.DataSource = dtViewTable;
                    txtTotalPremSum.Value = sumInstlmt.ToString("n2");
                }
                else
                {
                    tblPremDebitInst.Visible = false;
                    txtTotalPremSum.Visible = false;
                }
            }
            else
            {
                tblPremDebitInst.Visible = false;
                txtTotalPremSum.Visible = false;
            }

            //txtTextYourShare.Visible = true;
            //txtUwSharePer.Visible = true;
            //txtUwShareAmt.Visible = true;
            tblUW.Visible = false;

            txtTotalPremSum.Visible = false;
            if (string.IsNullOrEmpty(sUWCrNotePrintOptions))
            {
                txtTextPremium.Value = "NET PREMIUM DUE";
                txtTextPremDue.Visible = false;
                txtPremiumDue.Visible = false;
            }
            textBox7.Value = "";
            textBox12.Value = "";
            textBox2.Value = "DUE DATE";
            textBox4.Value = "TRANSACTION NO.";
            txtTextNote.Visible = false;
            txtTextNote2.Visible = false;
            txtShareTot.Visible = false;
            txtAmountText.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.8, Telerik.Reporting.Drawing.UnitType.Inch));
            txtAmountText.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.76, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
        }

        private void SetPremDataCredit(DataSet dsObj, DataRow dr, string strCheckedInstl, string sUWCrNotePrintOptions)
        {
            // Value from Table 3 
          
                txtCurrency.Value = "(" + dr["Currency"].ToString() + ")";
                txtRemarks.Value = dr["BillingRemarks"].ToString();
       

            DataView dvUw = new DataView(dsObj.Tables[3]);
            dvUw.RowFilter = "UnderWriterCode = '" + dr["UnderWriterCode"] + "'";
            DataTable dtUwView = dvUw.ToTable();

            txtUwSharePer.Value = dr["UWShare"].ToString() + " %";
            txtUwShareAmt.Value = Convert.ToDecimal(dr["UwShareAmount"].ToString()).ToString("n2");
            txtClientName.Value = dr["UnderWriterName"].ToString();
            txtClientAddr.Value = dr["UwAddress"].ToString() + Environment.NewLine + dr["UwAddrCountry"].ToString();

            if (!string.IsNullOrEmpty(sUWCrNotePrintOptions))
            {
                if (sUWCrNotePrintOptions == "0")
                {
                    #region <With GST>
                    //PREMIUM
                    decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                    tempPremValue = -tempPremValue;
                    txtPremium.Value = tempPremValue.ToString("n2");

                    //PREMIUM TAX S
                    decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                    tempPremTax = -tempPremTax;
                    txtPremiumTax.Value = tempPremTax.ToString("n2");

                    decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                    txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                    //PREMIUM DUE
                    decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                    tempPremDue = -tempPremDue;
                    txtPremiumDue.Value = tempPremDue.ToString("n2");

                    //BROKERAGE G
                    decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                    txtBrokerage.Value = tempBrokerage.ToString("n2");

                    decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                    txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                    //BROKERAGE TAX S
                    decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                    txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                    decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                    txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                    //NET PREMIUM DUE
                    decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString()));
                    txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                    #endregion
                }
                if (sUWCrNotePrintOptions == "1")
                {
                    #region <Without GST>

                    //PREMIUM
                    decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                    tempPremValue = -tempPremValue;
                    txtPremium.Value = tempPremValue.ToString("n2");

                    //PREMIUM TAX S
                    decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                    tempPremTax = -tempPremTax;
                    txtPremiumTax.Value = tempPremTax.ToString("n2");

                    decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                    txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                    //PREMIUM DUE
                    decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                    tempPremDue = -tempPremDue;
                    txtPremiumDue.Value = tempPremDue.ToString("n2");

                    //BROKERAGE G
                    decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                    txtBrokerage.Value = tempBrokerage.ToString("n2");

                    decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                    txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                    //BROKERAGE TAX S
                    decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                    txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                    decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                    txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                    //NET PREMIUM DUE
                    decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()));
                    txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                    #endregion
                }
                if (sUWCrNotePrintOptions == "2")
                {
                    #region <Custom>

                    //PREMIUM
                    decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString());
                    tempPremValue = -tempPremValue;
                    txtPremium.Value = tempPremValue.ToString("n2");

                    //PREMIUM TAX S
                    decimal tempPremTax = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                    tempPremTax = -tempPremTax;
                    txtPremiumTax.Value = tempPremTax.ToString("n2");

                    decimal PremiumGST = Convert.ToDecimal(dtUwView.Rows[0]["InsurerGST"].ToString());
                    txtPremiumGST.Value = PremiumGST.ToString("n2") + " %";

                    //PREMIUM DUE
                    decimal tempPremDue = Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString());
                    tempPremDue = -tempPremDue;
                    txtPremiumDue.Value = tempPremDue.ToString("n2");

                    //BROKERAGE G
                    decimal tempBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString());
                    txtBrokerage.Value = tempBrokerage.ToString("n2");

                    decimal UWBrokerage = Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerage"].ToString());
                    txtUWBrokerage.Value = UWBrokerage.ToString("n2") + " %";

                    //BROKERAGE TAX S
                    decimal tempBrokerageTax = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString());
                    txtBrokerageTax.Value = tempBrokerageTax.ToString("n2");

                    decimal BrokerGST = Convert.ToDecimal(dtUwView.Rows[0]["BrokerGST"].ToString());
                    txtBrokerGST.Value = BrokerGST.ToString("n2") + " %";

                    //NET PREMIUM DUE
                    decimal tempNetPremiumDue = (Convert.ToDecimal(dtUwView.Rows[0]["TotalPremium"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["PolicyCharge"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["InsurerGSTAmount"].ToString())) - (Convert.ToDecimal(dtUwView.Rows[0]["UWBrokerageAmount"].ToString()) + Convert.ToDecimal(dtUwView.Rows[0]["BrokerGSTAmount"].ToString()));
                    txtNetPremiumDue.Value = tempNetPremiumDue.ToString("n2");

                    #endregion
                }
            }
            else
            {
                decimal tempPremValue = Convert.ToDecimal(dr["PRUWSharePremium"].ToString());
                tempPremValue = -tempPremValue;
                txtPremium.Value = tempPremValue.ToString("n2");
                txtPremiumDue.Value = tempPremValue.ToString("n2");
            }

            // Values from table 4
            DataView dvUwDNNum = new DataView(dsObj.Tables[4]);
            dvUwDNNum.RowFilter = "UnderWriterCode = '" + dr["UnderWriterCode"] + "'";
            DataTable dtUwViewDNNum = dvUwDNNum.ToTable();
            txtDNNumber.Value = dtUwViewDNNum.Rows[0]["UWDebitNoteNo"].ToString();
            if (strCheckedInstl != "")
            {
                // Values from Table 6 for Under writer installments
                if (dsObj.Tables.Count > 6 && dsObj.Tables[6].Columns.Contains("UWShare"))
                {
                    // Value from Table 6 (filtered)
                    DataView dv = new DataView(dsObj.Tables[6]);
                    dv.RowFilter = "UnderWriterCode = '" + dr["UnderWriterCode"] + "'";
                    DataTable dtViewTable = dv.ToTable();
                    if (dtViewTable.Rows.Count > 0)
                    {
                        dv = new DataView(dtViewTable);
                        if (strCheckedInstl != "")
                        {
                            dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                        }
                        dtViewTable = dv.ToTable();

                        object sumObject;
                        sumObject = dtViewTable.Compute("Sum(Premium)", "");
                        decimal sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                        foreach (DataRow row in dtViewTable.Rows)
                        {
                            row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (-1)).ToString("n2");
                        }
                        tblPremDebitInst.DataSource = dtViewTable;
                        txtTotalPremSum.Value = sumInstlmt.ToString("n2");
                    }
                    else
                    {
                        tblPremDebitInst.Visible = false;
                        txtTotalPremSum.Visible = false;
                    }

                }
                // Values from Table 5 for Under writer installments
                //(This will be some unique case when clients installments do not show up)
                else if (dsObj.Tables.Count > 5 && dsObj.Tables[5].Columns.Contains("UWShare"))
                {
                    // Value from Table 5 (filtered)
                    DataView dv = new DataView(dsObj.Tables[5]);
                    dv.RowFilter = "UnderWriterCode = '" + dr["UnderWriterCode"] + "'";
                    DataTable dtViewTable = dv.ToTable();
                    if (dtViewTable.Rows.Count > 0)
                    {
                        dv = new DataView(dtViewTable);
                        if (strCheckedInstl != "")
                        {
                            dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                        }
                        dtViewTable = dv.ToTable();

                        object sumObject;
                        sumObject = dtViewTable.Compute("Sum(Premium)", "");
                        decimal sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                        foreach (DataRow row in dtViewTable.Rows)
                        {
                            row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (-1)).ToString("n2");
                        }
                        tblPremDebitInst.DataSource = dtViewTable;
                        txtTotalPremSum.Value = sumInstlmt.ToString("n2");
                    }
                    else
                    {
                        tblPremDebitInst.Visible = false;
                        txtTotalPremSum.Visible = false;
                    }
                }
                else
                {
                    tblPremDebitInst.Visible = false;
                    txtTotalPremSum.Visible = false;
                }
            }
            else
            {
                tblPremDebitInst.Visible = false;
                txtTotalPremSum.Visible = false;
            }

            //txtTextYourShare.Visible = true;
            //txtUwSharePer.Visible = true;
            //txtUwShareAmt.Visible = true;
            tblUW.Visible = false;
            txtTotalPremSum.Visible = false;

            if (string.IsNullOrEmpty(sUWCrNotePrintOptions))
            {
                txtTextPremium.Value = "NET PREMIUM DUE";
                txtTextPremDue.Visible = false;
                txtPremiumDue.Visible = false;
            }

            textBox7.Value = "";
            textBox12.Value = "";
            textBox2.Value = "DUE DATE";
            textBox4.Value = "TRANSACTION NO.";
            //The below may be utilized for future requirements of display vessel detials
            /*txtTextDuty.Visible = false;
            txtDutyCost.Visible = true;
            txtTextPolOrComm.Value = "POLICY COST:";*/
            txtTextNote.Visible = false;
            txtTextNote2.Visible = false;
            txtShareTot.Visible = false;
            txtAmountText.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.8, Telerik.Reporting.Drawing.UnitType.Inch));
            txtAmountText.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.76, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
        }
    }
}