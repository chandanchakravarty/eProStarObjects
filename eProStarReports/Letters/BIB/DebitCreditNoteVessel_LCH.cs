namespace eProStarReports.Letters.BIB
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
    public partial class DebitCreditNoteVessel_LCH : Telerik.Reporting.Report
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
            SetPremDataDebit(dsObj, strClientCode, strChkInstl);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;
            
        }
        public DebitCreditNoteVessel_LCH(DataSet dsObj, string strUwCode, string strChkInstl, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportDataUw(dsObj);
            SetPremDataCredit(dsObj, strUwCode, strChkInstl);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;

        }

        public DebitCreditNoteVessel_LCH(DataSet dsObj, string strUwCode, string strChkInstl, int printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportDataUw(dsObj);
            SetPremDataCredit(dsObj, strUwCode, strChkInstl);
            if (printlogo == 1)
                picHeader.Visible = true;
            else
                picHeader.Visible = false;

        }
        public DebitCreditNoteVessel_LCH(DataSet dsObj, DataRow dr, string strChkInstl, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            SetReportDataUw(dsObj);
            SetPremDataCredit(dsObj, dr, strChkInstl);
            if (printlogo == "Y")
                picHeader.Visible = true;
            else
                picHeader.Visible = false;

        }

        private void SetReportData(DataSet dsObj, string strClientCode)
        {
            // added for #23256 --begin
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picHeader.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            txtTextDN.Value = "DEBIT NOTE :";
            
            // Values from Table 0 (filtered)
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "MultiPayeeClientCode = '" + strClientCode + "'";
            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable!=null)
            {
                txtDNNumber.Value = dtViewTable.Rows[0]["DebitNoteNo"].ToString();
                txtDate.Value = dtViewTable.Rows[0]["DebitNotedate"].ToString();
                txtAccountCode.Value = dtViewTable.Rows[0]["MultiPayeeClientCode"].ToString();
                txtAccountMonth.Value = dtViewTable.Rows[0]["AccMonth"].ToString() + "/" + dtViewTable.Rows[0]["AccYear"].ToString();
                txtRefNo.Value = dtViewTable.Rows[0]["InsurerDebitNote"].ToString();
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
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();

                // Value from Table 3
                if(dsObj.Tables[3].Rows.Count>0)
                    txtPremCurr.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString();

                textBox21.Visible = false;  // Semicolon to be hidden
                txtTextLCH.Value = txtCompanyName.Value+"."; //Added by Udit for redmine #11681 change company name a/c to client.
                txtTextNote2.Value = "*Note: Please issue cheque payable to "+ txtTextLCH.Value;

            }
        }

        private void SetReportDataUw(DataSet dsObj)
        {
            // added for #23256 --begin
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picHeader.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            txtTextDN.Value = "CREDIT NOTE :";
            
            // Values from Table 0
            if (dsObj.Tables[0].Rows.Count>0)
            {
                txtDate.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
                txtAccountCode.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                txtAccountMonth.Value = dsObj.Tables[0].Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
                txtRefNo.Value = dsObj.Tables[0].Rows[0]["InsurerDebitNote"].ToString();
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
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
                txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();

                // Values from Table 3
                if (dsObj.Tables[3].Rows.Count > 0)
                    txtPremCurr.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString();
                txtTextLCH.Value = txtCompanyName.Value + "."; //Added by Udit for redmine #11681 change company name a/c to client.
                txtTextNote2.Value = "*Note: Please issue cheque payable to " + txtTextLCH.Value;


            }
        }

        private void SetPremDataDebit(DataSet dsObj,string strClientCode, string strCheckedInstl)
        {            
            // Value from Table 0 (filtered)
            DataView dvTemp = new DataView(dsObj.Tables[0]);
            dvTemp.RowFilter = "MultiPayeeClientCode = '" + strClientCode + "'";
            DataTable dtTempTable = dvTemp.ToTable();
            if(dtTempTable.Rows.Count > 0)
            {
                txtDNNumber.Value = dtTempTable.Rows[0]["MultiPayeeDNNum"].ToString();
                txtClientName.Value = dtTempTable.Rows[0]["MultiPayeeClientname"].ToString();
                txtClientAddr.Value = dtTempTable.Rows[0]["MultiPayeeclientAddr"].ToString() + Environment.NewLine + dtTempTable.Rows[0]["MultiPayeeCountry"].ToString();
                decimal tempPrem = Convert.ToDecimal(dtTempTable.Rows[0]["MultiPayeeClientPremium"].ToString());
                txtPremium.Value = tempPrem.ToString("n2");
                txtPremiumDue.Value = tempPrem.ToString("n2");
            }
            
            
            // Values from Table 4
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                // Values from Table 3
                txtCurrency.Value = "(" + dsObj.Tables[3].Rows[0]["Currency"].ToString() + ")";
                txtRemarks.Value = dsObj.Tables[3].Rows[0]["BillingRemarks"].ToString();

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

            //The below may be utilized for future requirements of display vessel detials

            //txtVesselName.Value = dsObj.Tables[3].Rows[0]["VesselName"].ToString();
            //txtRate.Value = "@ " + dsObj.Tables[3].Rows[0]["Rate"].ToString() + " "
            //                + " X " + dsObj.Tables[3].Rows[0]["TotalDay"].ToString() + "/"
            //                + dsObj.Tables[3].Rows[0]["BaseDay"].ToString();
            //txtTextPolOrComm.Value = "COMM:";
            //txtPolCostOrComm.Value = dsObj.Tables[3].Rows[0]["UWBrokerage"].ToString();

        }

        private void SetPremDataCredit(DataSet dsObj, string UwCode, string strCheckedInstl)
        {
            // Value from Table 3  
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                txtCurrency.Value = "(" + dsObj.Tables[3].Rows[0]["Currency"].ToString() + ")";
                txtRemarks.Value = dsObj.Tables[3].Rows[0]["BillingRemarks"].ToString();
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
                decimal tempPremValue = Convert.ToDecimal(dtUwView.Rows[0]["UwIndivPremium"].ToString());

                tempPremValue = -tempPremValue;
                txtPremium.Value = tempPremValue.ToString("n2");
                txtPremiumDue.Value = tempPremValue.ToString("n2");
            }
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

                decimal sumInstlmt = 0;             // added for #23642
                if (sumObject != DBNull.Value)      // added for #23642
                {
                    sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                }
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

                decimal sumInstlmt = 0;             // added for #23642
                if (sumObject != DBNull.Value)      // added for #23642
                {
                    sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                }
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

            txtTextYourShare.Visible = true;
            txtUwSharePer.Visible = true;
            txtUwShareAmt.Visible = true;
            tblUW.Visible = false;
            txtPremiumDue.Visible = false;
            txtTextPremDue.Visible = false;
            txtTotalPremSum.Visible = false;
            txtTextPremium.Value = "NET PREMIUM DUE";
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


        private void SetPremDataCredit(DataSet dsObj, DataRow dr, string strCheckedInstl)
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
            decimal tempPremValue = Convert.ToDecimal(dr["PRUWSharePremium"].ToString());
            tempPremValue = -tempPremValue;
            txtPremium.Value = tempPremValue.ToString("n2");
            txtPremiumDue.Value = tempPremValue.ToString("n2");
                        
            // Values from table 4
            DataView dvUwDNNum = new DataView(dsObj.Tables[4]);
            dvUwDNNum.RowFilter = "UnderWriterCode = '" + dr["UnderWriterCode"] + "'";
            DataTable dtUwViewDNNum = dvUwDNNum.ToTable();
            txtDNNumber.Value = dtUwViewDNNum.Rows[0]["UWDebitNoteNo"].ToString();

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

            txtTextYourShare.Visible = true;
            txtUwSharePer.Visible = true;
            txtUwShareAmt.Visible = true;
            tblUW.Visible = false;
            txtPremiumDue.Visible = false;
            txtTextPremDue.Visible = false;
            txtTotalPremSum.Visible = false;
            txtTextPremium.Value = "NET PREMIUM DUE";
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