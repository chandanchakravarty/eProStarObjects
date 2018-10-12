namespace NWILetterReport.Letters
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
    /// Summary description for DNCNNoteExcess.
    /// </summary>
    public partial class DNCNNoteMotorExcess_LCH : Telerik.Reporting.Report
    {
        public DNCNNoteMotorExcess_LCH()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DNCNNoteMotorExcess_LCH(DataSet dsObj, int showHide)
        {
            //
            // Called for Clients
            //
            InitializeComponent();
            picHeader.Value = clsReportUtility.setClientLogo();
            SetDataOnReport(dsObj);
            MotorPremCalc(dsObj);
            MotorDetails(dsObj.Tables[3].Rows[0], showHide);

        }

        public DNCNNoteMotorExcess_LCH(DataSet dsObj, DataRow drMotorPremDetails, string strIndividualSum, int showHide)
        {
            //
            // Called for Clients
            //
            InitializeComponent();
            picHeader.Value = clsReportUtility.setClientLogo();
            SetDataOnReport(dsObj);
            MotorPremCalc(dsObj, drMotorPremDetails, strIndividualSum);
            MotorDetails(drMotorPremDetails, showHide);
        }

        public DNCNNoteMotorExcess_LCH(DataSet dsObj, int showHide, string UwCode)
        {
            //
            // Called for Underwriters
            //
            InitializeComponent();
            picHeader.Value = clsReportUtility.setClientLogo();
            SetDataOnReportUw(dsObj, UwCode);
            MotorPremCredit(dsObj, UwCode);
            MotorDetails(dsObj.Tables[3].Rows[0], showHide);

        }

        public DNCNNoteMotorExcess_LCH(DataSet dsObj, DataRow drMotorPremDetails, int showHide, string UwCode)
        {
            //
            // Called for Underwriters
            //
            InitializeComponent();
            picHeader.Value = clsReportUtility.setClientLogo();
            SetDataOnReportUw(dsObj, UwCode);
            MotorPremCredit(drMotorPremDetails, UwCode);
            MotorDetails(drMotorPremDetails, showHide);
        }

        public void SetDataOnReport(DataSet dsObj)
        {
            // Values from Table 0
            picHeader.Value = clsReportUtility.setClientLogo();
            txtNoteNumber.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
            txtDate.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
            txtAccountCode.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            txtAccountMonth.Value = dsObj.Tables[0].Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
            txtRefNo.Value = dsObj.Tables[0].Rows[0]["InsurerDebitNote"].ToString();
            txtSubClass.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            txtPolicyNum.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
            {
                txtTextPOI.Visible = false;
                textBox6.Visible = false;
                txtPOIFrom.Visible = false;
                txtTextMiddle.Visible = false;
                txtPOITo.Visible = false;

            }
            else
            {
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            }
            txtCovNote.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
            txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();

            //Values from Table 1
            txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
            txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
            txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
            txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
            txtClientName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            txtClientAddr.Value = dsObj.Tables[1].Rows[0]["clientaddress"].ToString();
            txtCountry.Value = dsObj.Tables[1].Rows[0]["ClientAddrCountry"].ToString();
            txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
        }



        public void SetDataOnReportUw(DataSet dsObj, string UwCode)
        {
            //Values from Table 0
            picHeader.Value = clsReportUtility.setClientLogo();
            txtDate.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
            txtAccountCode.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
            txtAccountMonth.Value = dsObj.Tables[0].Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
            txtRefNo.Value = dsObj.Tables[0].Rows[0]["InsurerDebitNote"].ToString();
            txtSubClass.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
            txtPolicyNum.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
            {
                txtTextPOI.Visible = false;
                textBox6.Visible = false;
                txtPOIFrom.Visible = false;
                txtTextMiddle.Visible = false;
                txtPOITo.Visible = false;

            }
            else
            {
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            }
            txtCovNote.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
            txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();

            // Values from Table 0 (filtered)
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "UnderWriterCode = '" + UwCode + "'";
            DataTable dtViewTable = dv.ToTable();
            txtNoteNumber.Value = dtViewTable.Rows[0]["UwDebitNoteNo"].ToString();

            //Values from Table 1
            txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
            txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
            txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
            txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
            txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
        }

        private void MotorPremCalc(DataSet dsObj, DataRow drPremDetails, string strIndividualSum)
        {
            picHeader.Value = clsReportUtility.setClientLogo();
            decimal tempBasicLessNcd = 0;
            decimal tempofdper = 0;
            decimal tempofdamt = 0;
            decimal tempncdper2 = 0;
            decimal tempncdamt2 = 0;
            decimal tempPremGstPer = 0;
            decimal tempPremGstAmt = 0;
            decimal tempBrokeragePer = 0;
            decimal tempBrkAmnt = 0;
            decimal tempBrkGstPer = 0;
            decimal tempBrkGstAmt = 0;
            decimal shareTot = 0;
            txtTextNoteType.Value = "DEBIT NOTE :";

            // Values from Table 4 (strIndividualSum is from Table 4)
            decimal tempBasic = Convert.ToDecimal(strIndividualSum);

            // Values from Table 3 (individual row)
            txtCurrency.Value = "(" + drPremDetails["Currency"].ToString() + ")";
            txtCoverage.Value = "(" + drPremDetails["CoverageName"].ToString() + ")";
            txtRemarks.Value = drPremDetails["BillingRemarks"].ToString();

            if (Convert.ToDecimal(drPremDetails["OfdRate"].ToString()) > 0)
            {
                txtTextOfd.Visible = true;
                txtOfdPer.Visible = true;
                txtOfdAmt.Visible = true;
                tempofdper = Convert.ToDecimal(drPremDetails["OfdRate"].ToString());
                tempofdamt = Convert.ToDecimal(drPremDetails["OfdAmt"].ToString());
                tempncdper2 = Convert.ToDecimal(drPremDetails["NcdRate"].ToString());
                tempncdamt2 = Convert.ToDecimal(drPremDetails["NcdAmt"].ToString());
                tempBasicLessNcd = tempBasic - (tempncdamt2 + tempofdamt);
            }
            else
            {
                txtTextOfd.Visible = false;
                txtOfdPer.Visible = false;
                txtOfdAmt.Visible = false;
                tempncdper2 = Convert.ToDecimal(drPremDetails["NcdRate"].ToString());
                tempncdamt2 = Convert.ToDecimal(drPremDetails["NcdAmt"].ToString());
                tempBasicLessNcd = tempBasic - tempncdamt2;
            }
            tempPremGstPer = Convert.ToDecimal(drPremDetails["InsurerGSTPer"].ToString());
            tempBrokeragePer = Convert.ToDecimal(drPremDetails["M_UWBrokerage"].ToString());
            tempBrkGstPer = Convert.ToDecimal(drPremDetails["M_BrokerGST"].ToString());
            tempPremGstAmt = (tempBasicLessNcd * tempPremGstPer) / 100;
            tempBrkAmnt = (tempBasicLessNcd * tempBrokeragePer) / 100;
            tempBrkGstAmt = (tempBasicLessNcd * tempBrkGstPer) / 100;

            // Values from Table 3 (grouped)
            DataTable dtnew = dsObj.Tables[3].AsEnumerable()
                                           .GroupBy(r => new { UnderwriterCode = r["UnderwriterCode"] })
                                           .Select(g => g.OrderBy(r => r["UnderwriterCode"]).First())
                                           .CopyToDataTable();
            tblUW.DataSource = dtnew;
            object sumShare;
            sumShare = dtnew.Compute("Sum(UWShare)", "");
            shareTot = Convert.ToDecimal(sumShare);

            // Assigning values to the text boxes
            txtShareTot.Value = shareTot.ToString("n2");
            txtBasicPrem.Value = tempBasic.ToString("n2");
            txtBasicLessNcd.Value = drPremDetails["Currency"].ToString() + " " + tempBasicLessNcd.ToString("n2");
            txtNcdPer2.Value = tempncdper2.ToString("n2") + "%";
            txtNcdAmt.Value = (-tempncdamt2).ToString("n2"); // Since this is debit note for client
            txtOfdPer.Value = tempofdper.ToString("n2") + "%";
            txtOfdAmt.Value = (-tempofdamt).ToString("n2"); // Since this is debit note for client
            txtPremTax.Value = (tempBasicLessNcd + tempPremGstAmt).ToString("n2");
            txtNetPrem.Value = drPremDetails["Currency"].ToString() + " " + (tempBasicLessNcd + tempPremGstAmt).ToString("n2");

            tblUW.Visible = true;
            txtTextBrokerage.Visible = false;
            txtTextBrkTax.Visible = false;
            txtPremTaxPer.Visible = false;
            txtBrkrgPer.Visible = false;
            txtBrkTaxPer.Visible = false;
            txtTextPremTax.Value = "PREMIUM (Incl of GST)";
            txtTextNetPrem.Value = "PREMIUM DUE";
            txtTextNote.Visible = true;
            txtTextNote2.Visible = true;
            txtTextPremTax.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.51, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextPremTax.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.41, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextNetPrem.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.12, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextNcd2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.85, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextOfd.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.0, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextBscPrem.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.7, Telerik.Reporting.Drawing.UnitType.Inch));
        }



        private void MotorPremCalc(DataSet dsObj)
        {
            picHeader.Value = clsReportUtility.setClientLogo();
            decimal tempBasicLessNcd = 0;
            decimal tempofdper = 0;
            decimal tempofdamt = 0;
            decimal tempncdper2 = 0;
            decimal tempncdamt2 = 0;
            decimal tempAvgNcd = 0;
            decimal tempAvgOfd = 0;
            decimal tempBasic = 0;
            decimal tempPremGstPer = 0;
            decimal tempPremGstAmt = 0;
            decimal tempBrokeragePer = 0;
            decimal tempBrkAmnt = 0;
            decimal tempBrkGstPer = 0;
            decimal tempBrkGstAmt = 0;
            decimal shareTot = 0;
            txtTextNoteType.Value = "DEBIT NOTE :";

            // Values from Table 3
            tblUW.DataSource = dsObj.Tables[3];
            txtCurrency.Value = "(" + dsObj.Tables[3].Rows[0]["Currency"].ToString() + ")";
            txtCoverage.Value = "(" + dsObj.Tables[3].Rows[0]["CoverageName"].ToString() + ")";
            txtRemarks.Value = dsObj.Tables[3].Rows[0]["BillingRemarks"].ToString();
            // Adding the premium from all brokers
            for (int i = 0; i < dsObj.Tables[3].Rows.Count; i++)
            {
                tempBasic += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["M_IndividualPrem"].ToString());
            }
            if (Convert.ToDecimal(dsObj.Tables[3].Rows[0]["OfdRate"].ToString()) > 0)
            {
                txtTextOfd.Visible = true;
                txtOfdPer.Visible = true;
                txtOfdAmt.Visible = true;
                for (int i = 0; i < dsObj.Tables[3].Rows.Count; i++)
                {
                    tempofdper += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["OfdRate"].ToString());
                    tempofdamt += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["OfdAmt"].ToString());
                    tempncdper2 += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["NcdRate"].ToString());
                    tempncdamt2 += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["NcdAmt"].ToString());
                }
                tempAvgNcd = Convert.ToDecimal(tempncdper2 / dsObj.Tables[3].Rows.Count);
                tempAvgOfd = Convert.ToDecimal(tempofdper / dsObj.Tables[3].Rows.Count);
                tempncdamt2 = -tempncdamt2; // Since this is debit note for client
                tempofdamt = -tempofdamt; // Since this is debit note for client
                tempBasicLessNcd = tempBasic + tempncdamt2 + tempofdamt;
            }
            else
            {
                txtTextOfd.Visible = false;
                txtOfdPer.Visible = false;
                txtOfdAmt.Visible = false;
                for (int i = 0; i < dsObj.Tables[3].Rows.Count; i++)
                {
                    tempncdper2 += Convert.ToDecimal(dsObj.Tables[3].Rows[i]["NcdRate"].ToString());
                    tempncdamt2 = Convert.ToDecimal(dsObj.Tables[3].Rows[i]["NcdAmt"].ToString());
                }
                tempAvgNcd = Convert.ToDecimal(tempncdper2 / dsObj.Tables[3].Rows.Count);
                tempncdamt2 = -tempncdamt2;
                tempBasicLessNcd = tempBasic + tempncdamt2;
            }
            tempPremGstPer = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["InsurerGSTPer"].ToString());
            tempBrokeragePer = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["M_UWBrokerage"].ToString());
            tempBrkGstPer = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["M_BrokerGST"].ToString());
            tempPremGstAmt = (tempBasicLessNcd * tempPremGstPer) / 100;
            tempBrkAmnt = (tempBasicLessNcd * tempBrokeragePer) / 100;
            tempBrkGstAmt = (tempBasicLessNcd * tempBrkGstPer) / 100;

            DataTable dtnew = dsObj.Tables[3].AsEnumerable()
                                           .GroupBy(r => new { UnderwriterCode = r["UnderwriterCode"] })
                                           .Select(g => g.OrderBy(r => r["UnderwriterCode"]).First())
                                           .CopyToDataTable();
            tblUW.DataSource = dtnew;
            object sumShare;
            sumShare = dtnew.Compute("Sum(UWShare)", "");
            shareTot = Convert.ToDecimal(sumShare);

            // Assigning values to the text boxes
            txtShareTot.Value = shareTot.ToString("n2");
            txtBasicPrem.Value = tempBasic.ToString("n2");
            txtBasicLessNcd.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString() + " " + tempBasicLessNcd.ToString("n2");
            txtNcdPer2.Value = tempAvgNcd.ToString("n2") + "%";
            txtNcdAmt.Value = (-tempncdamt2).ToString("n2");
            txtOfdPer.Value = tempAvgOfd.ToString("n2") + "%";
            txtOfdAmt.Value = (-tempofdamt).ToString("n2");
            txtPremTax.Value = (tempBasicLessNcd + tempPremGstAmt).ToString("n2");
            txtNetPrem.Value = dsObj.Tables[3].Rows[0]["Currency"].ToString() + " " + (tempBasicLessNcd + tempPremGstAmt).ToString("n2");

            tblUW.Visible = true;
            txtTextBrokerage.Visible = false;
            txtTextBrkTax.Visible = false;
            txtPremTaxPer.Visible = false;
            txtBrkrgPer.Visible = false;
            txtBrkTaxPer.Visible = false;
            txtTextPremTax.Value = "PREMIUM (Incl of GST)";
            txtTextNetPrem.Value = "PREMIUM DUE";
            txtTextNote.Visible = true;
            txtTextNote2.Visible = true;
            txtTextPremTax.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.51, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextPremTax.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.41, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextNetPrem.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.12, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextNcd2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.85, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextOfd.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.0, Telerik.Reporting.Drawing.UnitType.Inch));
            txtTextBscPrem.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.09, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.7, Telerik.Reporting.Drawing.UnitType.Inch));
        }


        private void MotorPremCredit(DataRow drPremDetails, string UwCode)
        {
            picHeader.Value = clsReportUtility.setClientLogo();
            decimal tempBasic = 0;
            decimal tempPremGstPer = 0;
            decimal tempPremGstAmt = 0;
            decimal tempBrokeragePer = 0;
            decimal tempBrkAmnt = 0;
            decimal tempBrkGstPer = 0;
            decimal tempBrkGstAmt = 0;
            decimal tempBasicLessNcd = 0;
            decimal tempofdper = 0;
            decimal tempofdamt = 0;
            decimal tempncdper2 = 0;
            decimal tempncdamt2 = 0;
            txtTextNoteType.Value = "CREDIT NOTE :";
            txtClientName.Value = string.Empty;
            txtClientAddr.Value = string.Empty;
            txtCountry.Value = string.Empty;

            // Values from Table 3 (individual rows)
            txtClientName.Value = drPremDetails["UnderwriterName"].ToString();
            txtClientAddr.Value = drPremDetails["UwAddress"].ToString();
            txtCountry.Value = drPremDetails["UwAddrCountry"].ToString();
            txtRemarks.Value = drPremDetails["BillingRemarks"].ToString();
            txtCurrency.Value = "(" + drPremDetails["Currency"].ToString() + ")";
            txtCoverage.Value = "(" + drPremDetails["CoverageName"].ToString() + ")";

            tempBasic = Convert.ToDecimal(drPremDetails["M_IndividualPrem"].ToString());
            tempBasic = -tempBasic; // Since this is credit note for Underwriter
            if (Convert.ToDecimal(drPremDetails["OfdRate"].ToString()) > 0)
            {
                txtTextOfd.Visible = true;
                txtOfdPer.Visible = true;
                txtOfdAmt.Visible = true;
                tempofdper = Convert.ToDecimal(drPremDetails["OfdRate"].ToString());
                tempofdamt = Convert.ToDecimal(drPremDetails["OfdAmt"].ToString());
                tempncdper2 = Convert.ToDecimal(drPremDetails["NcdRate"].ToString());
                tempncdamt2 = Convert.ToDecimal(drPremDetails["NcdAmt"].ToString());
                tempBasicLessNcd = tempBasic + tempncdamt2 + tempofdamt;
            }
            else
            {
                txtTextOfd.Visible = false;
                txtOfdPer.Visible = false;
                txtOfdAmt.Visible = false;
                tempncdper2 = Convert.ToDecimal(drPremDetails["NcdRate"].ToString());
                tempncdamt2 = Convert.ToDecimal(drPremDetails["NcdAmt"].ToString());
                tempBasicLessNcd = tempBasic + tempncdamt2;
            }
            tempPremGstPer = Convert.ToDecimal(drPremDetails["InsurerGSTPer"].ToString());
            tempBrokeragePer = Convert.ToDecimal(drPremDetails["M_UWBrokerage"].ToString());
            tempBrkGstPer = Convert.ToDecimal(drPremDetails["M_BrokerGST"].ToString());
            tempPremGstAmt = (Math.Abs(tempBasicLessNcd) * tempPremGstPer) / 100;
            tempBrkAmnt = (Math.Abs(tempBasicLessNcd) * tempBrokeragePer) / 100;
            tempBrkGstAmt = (Math.Abs(tempBrkAmnt) * tempBrkGstPer) / 100;
            tempPremGstAmt = -tempPremGstAmt; // Since this is credit note for Underwriter

            // Assigning values to the text boxes
            txtBasicPrem.Value = tempBasic.ToString("n2");
            txtBasicLessNcd.Value = tempBasicLessNcd.ToString("n2");
            txtOfdPer.Value = tempofdper.ToString("n2") + "%";
            txtOfdAmt.Value = (tempofdamt).ToString("n2");
            txtNcdPer2.Value = tempncdper2.ToString("n2") + "%";
            txtNcdAmt.Value = (tempncdamt2).ToString("n2");
            txtPremTaxPer.Value = "S " + tempPremGstPer.ToString("n2") + "%"; ;
            txtPremTax.Value = tempPremGstAmt.ToString("n2");
            txtBrokerage.Value = tempBrkAmnt.ToString("n2");
            txtBrkrgPer.Value = "G " + tempBrokeragePer.ToString() + "%"; ;
            txtBrkTaxPer.Value = "S " + tempBrkGstPer.ToString("n2") + "%"; ;
            txtBrkTax.Value = tempBrkGstAmt.ToString("n2");
            txtNetPrem.Value = ((tempBasicLessNcd + tempPremGstAmt) + tempBrkAmnt + tempBrkGstAmt).ToString("n2");

            tblUW.Visible = false;
            txtTextPremTax.Value = "PREMIUM TAX";
            txtTextNetPrem.Value = "NET PREMIUM DUE";
            txtTextBrokerage.Visible = true;
            txtTextBrkTax.Visible = true;
            txtPremTaxPer.Visible = true;
            txtBrkrgPer.Visible = true;
            txtBrkTaxPer.Visible = true;
            txtTextNote.Visible = false;
            txtTextNote2.Visible = false;
            txtShareTot.Visible = false;
        }



        private void MotorPremCredit(DataSet dsObj, string UwCode)
        {
            picHeader.Value = clsReportUtility.setClientLogo();
            decimal tempBasic = 0;
            decimal tempTotBasic = 0;
            decimal tempTotBasicLessNcd = 0;
            decimal tempPremGstPer = 0;
            decimal tempPremGstAmt = 0;
            decimal tempBrokeragePer = 0;
            decimal tempBrkAmnt = 0;
            decimal tempBrkGstPer = 0;
            decimal tempBrkGstAmt = 0;
            decimal tempBasicLessNcd = 0;
            decimal tempofdper = 0;
            decimal tempofdamt = 0;
            decimal tempncdper2 = 0;
            decimal tempncdamt2 = 0;
            decimal tempAvgNcd = 0;
            decimal tempAvgOfd = 0;
            decimal tempTotPremGstPer = 0;
            decimal tempTotPremGstAmt = 0;
            decimal tempTotBrokGstPer = 0;
            decimal tempTotBrokGstAmt = 0;
            decimal tempTotBrokeragePer = 0;
            decimal tempTotBrokerageAmt = 0;
            decimal tempAvgPremGstPer = 0;
            decimal tempAvgBrokGstPer = 0;
            decimal tempAvgBrokeragePer = 0;
            txtTextNoteType.Value = "CREDIT NOTE :";

            // Values from Table 3 (filtered)

            DataView dv = new DataView(dsObj.Tables[3]);
            dv.RowFilter = "UnderWriterCode = '" + UwCode + "'";
            DataTable dtViewTable = dv.ToTable();
            txtCurrency.Value = "(" + dtViewTable.Rows[0]["Currency"].ToString() + ")";
            txtCoverage.Value = "(" + dtViewTable.Rows[0]["CoverageName"].ToString() + ")";
            txtClientName.Value = string.Empty;
            txtClientAddr.Value = string.Empty;
            txtCountry.Value = string.Empty;
            txtClientName.Value = dtViewTable.Rows[0]["UnderwriterName"].ToString();
            txtClientAddr.Value = dtViewTable.Rows[0]["UwAddress"].ToString();
            txtCountry.Value = dtViewTable.Rows[0]["UwAddrCountry"].ToString();
            txtRemarks.Value = dtViewTable.Rows[0]["BillingRemarks"].ToString();

            for (int i = 0; i < dtViewTable.Rows.Count; i++)
            {
                tempBasic = Convert.ToDecimal(dtViewTable.Rows[i]["M_IndividualPrem"].ToString());
                tempBasic = -tempBasic;
                tempTotBasic += tempBasic;
                if (Convert.ToDecimal(dtViewTable.Rows[i]["OfdRate"].ToString()) > 0)
                {
                    txtTextOfd.Visible = true;
                    txtOfdPer.Visible = true;
                    txtOfdAmt.Visible = true;
                    tempofdper += Convert.ToDecimal(dtViewTable.Rows[i]["OfdRate"].ToString());
                    tempofdamt += Convert.ToDecimal(dtViewTable.Rows[i]["OfdAmt"].ToString());
                    tempncdper2 += Convert.ToDecimal(dtViewTable.Rows[i]["NcdRate"].ToString());
                    tempncdamt2 += Convert.ToDecimal(dtViewTable.Rows[i]["NcdAmt"].ToString());
                    tempAvgNcd = Convert.ToDecimal(tempncdper2 / dtViewTable.Rows.Count);
                    tempAvgOfd = Convert.ToDecimal(tempofdper / dtViewTable.Rows.Count);
                    tempBasicLessNcd = tempBasic + tempncdamt2 + tempofdamt;
                    tempTotBasicLessNcd += tempBasicLessNcd;
                }
                else
                {
                    txtTextOfd.Visible = false;
                    txtOfdPer.Visible = false;
                    txtOfdAmt.Visible = false;
                    tempncdper2 += Convert.ToDecimal(dtViewTable.Rows[i]["NcdRate"].ToString());
                    tempncdamt2 += Convert.ToDecimal(dtViewTable.Rows[i]["NcdAmt"].ToString());
                    tempAvgNcd = Convert.ToDecimal(tempncdper2 / dtViewTable.Rows.Count);
                    tempBasicLessNcd = tempBasic + tempncdamt2;
                    tempTotBasicLessNcd += tempBasicLessNcd;
                }
                tempPremGstPer = Convert.ToDecimal(dtViewTable.Rows[0]["InsurerGSTPer"].ToString());
                tempTotPremGstPer += tempPremGstPer;
                tempBrokeragePer = Convert.ToDecimal(dtViewTable.Rows[0]["M_UWBrokerage"].ToString());
                tempTotBrokeragePer += tempBrokeragePer;
                tempBrkGstPer = Convert.ToDecimal(dtViewTable.Rows[0]["M_BrokerGST"].ToString());
                tempTotBrokGstPer += tempBrkGstPer;
                tempPremGstAmt = (Math.Abs(tempBasicLessNcd) * tempPremGstPer) / 100;
                tempTotPremGstAmt += tempPremGstAmt;
                tempBrkAmnt = (Math.Abs(tempBasicLessNcd) * tempBrokeragePer) / 100;
                tempTotBrokerageAmt += tempBrkAmnt;
                tempBrkGstAmt = (Math.Abs(tempBrkAmnt) * tempBrkGstPer) / 100;
                tempTotBrokGstAmt += tempBrkGstAmt;
            }
            tempTotPremGstAmt = -tempTotPremGstAmt;
            tempAvgPremGstPer = tempTotPremGstPer / dtViewTable.Rows.Count;
            tempAvgBrokeragePer = tempTotBrokeragePer / dtViewTable.Rows.Count;
            tempAvgBrokGstPer = tempTotBrokGstPer / dtViewTable.Rows.Count;

            // Assigning values to the text boxes
            txtBasicPrem.Value = tempTotBasic.ToString("n2");
            txtOfdPer.Value = tempAvgOfd.ToString("n2") + "%";
            txtOfdAmt.Value = (tempofdamt).ToString("n2");
            txtNcdPer2.Value = tempAvgNcd.ToString("n2") + "%";
            txtNcdAmt.Value = (tempncdamt2).ToString("n2");
            txtBasicLessNcd.Value = tempTotBasicLessNcd.ToString("n2");
            txtPremTaxPer.Value = "S " + tempAvgPremGstPer.ToString("n2") + "%"; ;
            txtPremTax.Value = tempTotPremGstAmt.ToString("n2");
            txtBrokerage.Value = tempTotBrokerageAmt.ToString("n2");
            txtBrkrgPer.Value = "G " + tempAvgBrokeragePer.ToString() + "%"; ;
            txtBrkTaxPer.Value = "S " + tempAvgBrokGstPer.ToString("n2") + "%"; ;
            txtBrkTax.Value = tempTotBrokGstAmt.ToString("n2");
            txtNetPrem.Value = ((tempTotBasicLessNcd + tempTotPremGstAmt) + tempTotBrokerageAmt + tempTotBrokGstAmt).ToString("n2");

            tblUW.Visible = false;
            txtTextPremTax.Value = "PREMIUM TAX";
            txtTextNetPrem.Value = "NET PREMIUM DUE";
            txtTextBrokerage.Visible = true;
            txtTextBrkTax.Visible = true;
            txtPremTaxPer.Visible = true;
            txtBrkrgPer.Visible = true;
            txtBrkTaxPer.Visible = true;
            txtTextNote.Visible = false;
            txtTextNote2.Visible = false;
            txtShareTot.Visible = false;
        }


        private void MotorDetails(DataRow drMotorPremDetails, int showHide)
        {
            picHeader.Value = clsReportUtility.setClientLogo();
            // Values from Table 3 (row-wise)
            if (showHide == 0)
            {
                txtRegNo.Visible = false;
                txtMake.Visible = false;
                txtCc.Visible = false;
                txtYear.Visible = false;
                txtEngNo.Visible = false;
                txtChasis.Visible = false;
                txtNcdPer1.Visible = false;
                txtExcess.Visible = false;
                txtCovNote.Visible = false;
            }
            else
            {
                txtRegNo.Visible = true;
                txtMake.Visible = true;
                txtCc.Visible = true;
                txtYear.Visible = true;
                txtEngNo.Visible = true;
                txtChasis.Visible = true;
                txtNcdPer1.Visible = true;
                txtExcess.Visible = true;
                txtCovNote.Visible = true;

                txtRegNo.Value = drMotorPremDetails["RegistrationNo"].ToString();
                txtMake.Value = drMotorPremDetails["MakeModel"].ToString();
                txtCc.Value = drMotorPremDetails["CubicCapacity"].ToString();
                txtYear.Value = drMotorPremDetails["ManufactureYear"].ToString();
                txtEngNo.Value = drMotorPremDetails["EngineNo"].ToString();
                txtChasis.Value = drMotorPremDetails["ChassisNo"].ToString();
                txtNcdPer1.Value = drMotorPremDetails["NoOfClaimDiscount"].ToString();
                txtExcess.Value = drMotorPremDetails["Excess"].ToString();
            }
        }
    }
}