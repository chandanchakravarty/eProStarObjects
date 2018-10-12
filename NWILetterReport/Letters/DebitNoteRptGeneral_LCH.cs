namespace NWILetterReport.Letters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for DebitNoteBill_LCH.
    /// </summary>
    public partial class DebitNoteRptGeneral_LCH : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneral_LCH()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
        }
        public DebitNoteRptGeneral_LCH(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            picHeader.Value = clsReportUtility.setClientLogo();
            txtTextDN.Value = "DEBIT NOTE :";

            // Values from Table 0
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                txtDNNumber.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                txtDate.Value = dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();
                txtAccountCode.Value = dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                txtAccountMonth.Value = dsObj.Tables[0].Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
               // txtRefNo.Value = dsObj.Tables[0].Rows[0]["InsurerDebitNote"].ToString();
                txtRefNo.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtEndmtNo.Value = dsObj.Tables[0].Rows[0]["EndtCtr"].ToString();
                txtSubClass.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                txtPolicyNum.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();
            if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
            {
                txtTextPOI.Visible = false;
                textBox7.Visible = false;
                txtTextMiddle.Visible = false;
                txtPOIFrom.Visible = false;
                txtPOITo.Visible = false;

            }
            else
            {
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            }
                txtSumInsured.Value = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["SumInsuredAmount"].ToString()).ToString("n2");
                tblUW.DataSource = dsObj.Tables[0];
                txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
            }
            object sumShare = DBNull.Value;
            if (sumShare != DBNull.Value)
            {
                sumShare = dsObj.Tables[0].Compute("Sum(UWShare)", "");
                decimal shareTot = Convert.ToDecimal(sumShare);
                txtShareTot.Value = shareTot.ToString("n2");

                tblUW.Visible = true;
            txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();
            }
           

            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
                txtClientName.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                txtClientAddr.Value = dsObj.Tables[1].Rows[0]["clientaddress"].ToString() + Environment.NewLine + dsObj.Tables[1].Rows[0]["ClientAddrCountry"].ToString();
                txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            }
            // Vlaues from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtPremCurr.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                txtCurrency.Value = "(" + dsObj.Tables[2].Rows[0]["Currency"].ToString() + ")";
                txtPremBeforeGst.Value = Convert.ToDecimal(dsObj.Tables[2].Rows[0]["TotalPremiumLessGst"].ToString()).ToString("n2");
                txtGst.Value = Convert.ToDecimal(dsObj.Tables[2].Rows[0]["InsurerGSTAmount"].ToString()).ToString("n2");
                txtTotPrem.Value = Convert.ToDecimal(dsObj.Tables[2].Rows[0]["PRTotalPremium"].ToString()).ToString("n2");
                txtRemarks.Value = dsObj.Tables[2].Rows[0]["BillingRemarks"].ToString();
            }
            
            // Values from Table 3 for client installments
            if (dsObj.Tables.Count > 3 && dsObj.Tables[3].Columns.Contains("ClientShare"))
            {
                DataView dv = new DataView(dsObj.Tables[3]);
                dv.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable = dv.ToTable();

                dv = new DataView(dtViewTable);
                dv.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                dtViewTable = dv.ToTable();

                object sumObject = DBNull.Value;
                sumObject = dtViewTable.Compute("Sum(Premium)", "");
                decimal sumInstlmt = Convert.ToDecimal(sumObject);
                if (sumObject != DBNull.Value)
                {
                     sumInstlmt = Convert.ToDecimal(sumObject);
                     txtTotalPremSum.Value = sumInstlmt.ToString("n2");
                }
                foreach (DataRow row in dtViewTable.Rows)
                {
                    row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (1)).ToString("n2");
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

        public DebitNoteRptGeneral_LCH(DataSet dsObj, string strUWCode, string strCheckedInstl)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            txtTextDN.Value = "CREDIT NOTE :";

            // Values from Table 0
            if (dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
            {
                txtTextPOI.Visible = false;
                textBox7.Visible = false;
                txtTextMiddle.Visible = false;
                txtPOIFrom.Visible = false;
                txtPOITo.Visible = false;

            }
            else
            {
                txtPOIFrom.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
            }
            txtSumInsured.Value = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["SumInsuredAmount"].ToString()).ToString("n2");
            txtAccHandler.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();

            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["TopCompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["TopCompanyAddress"].ToString();
                txtPhone.Value = " "; //dsObj.Tables[1].Rows[0]["TelNo"].ToString();
                txtMailids.Value = dsObj.Tables[1].Rows[0]["TopCompanyEmail"].ToString();
                txtInsured.Value = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
            }
            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtPremCurr.Value = dsObj.Tables[2].Rows[0]["Currency"].ToString();
                txtCurrency.Value = "(" + dsObj.Tables[2].Rows[0]["Currency"].ToString() + ")";
                txtRemarks.Value = dsObj.Tables[2].Rows[0]["BillingRemarks"].ToString();
            }
            ////// Values from filtered Table 0 based on Underwriter
            //////
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "UnderWriterCode = '" + strUWCode + "'";
            DataTable dtViewTable = dv.ToTable();

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtDNNumber.Value = dtViewTable.Rows[0]["UWDebitNote"].ToString();
                txtClientName.Value = dtViewTable.Rows[0]["UnderWriterName"].ToString();
                txtClientAddr.Value = dtViewTable.Rows[0]["UwAddress"].ToString() + Environment.NewLine + dtViewTable.Rows[0]["UwCountry"].ToString();

                txtDate.Value = dtViewTable.Rows[0]["DebitNotedate"].ToString();
                txtAccountCode.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                txtAccountMonth.Value = dtViewTable.Rows[0]["AccMonth"].ToString() + "/" + dsObj.Tables[0].Rows[0]["AccYear"].ToString();
                //txtRefNo.Value = dtViewTable.Rows[0]["InsurerDebitNote"].ToString();
                txtRefNo.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();

                txtEndmtNo.Value = dtViewTable.Rows[0]["EndtCtr"].ToString();

                txtSubClass.Value = dtViewTable.Rows[0]["SubClassName"].ToString();
                txtPolicyNum.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();

                txtPremBeforeGst.Value = "-" + Convert.ToDecimal(dtViewTable.Rows[0]["UWPremLessGst"].ToString()).ToString("n2");
                txtGst.Value = "-" + Convert.ToDecimal(dtViewTable.Rows[0]["InsurerGSTAmount"].ToString()).ToString("n2");
                txtTotPrem.Value = "-" + Convert.ToDecimal(dtViewTable.Rows[0]["UWPremiumShare"].ToString()).ToString("n2");
            }
            // Values from Table 4 for Uw installments
            if (dsObj.Tables.Count > 4 && dsObj.Tables[4].Columns.Contains("UWShare"))
            {
                DataView dvInst = new DataView(dsObj.Tables[4]);
                dvInst.RowFilter = "UnderWriterCode = '" + strUWCode + "'";
                DataTable dtViewTableInst = dvInst.ToTable();

                dvInst = new DataView(dtViewTableInst);
                dvInst.RowFilter = "InstNo IN ( " + strCheckedInstl + ")";
                dtViewTableInst = dvInst.ToTable();
                decimal sumInstlmt=0;
                object sumObject;
                sumObject = dtViewTableInst.Compute("Sum(Premium)", "");
                 sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                if (sumObject != DBNull.Value)
                {
                    sumObject = dtViewTableInst.Compute("Sum(Premium)", "");
                     sumInstlmt = Convert.ToDecimal(sumObject) * (-1);
                     txtTotalPremSum.Value = sumInstlmt.ToString("n2");
                }
                foreach (DataRow row in dtViewTableInst.Rows)
                {
                    row["Premium"] = (Convert.ToDecimal(row["Premium"]) * (-1)).ToString("n2");
                }
                tblPremDebitInst.DataSource = dtViewTableInst;
                txtTotalPremSum.Value = sumInstlmt.ToString("n2");
            }
            else
            {
                tblPremDebitInst.Visible = false;
                txtTotalPremSum.Visible = false;
            }
            txtTotalPremSum.Visible = false;
            tblUW.Visible = false;
            textBox16.Value = "DUE DATE";
            textBox18.Value = "TRANSACTION NO.";
            textBox21.Value = "";
            textBox20.Value = "";
            txtShareTot.Visible = false;
        }
    }
}