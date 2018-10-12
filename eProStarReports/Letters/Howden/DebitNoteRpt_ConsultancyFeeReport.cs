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
    public partial class DebitNoteRpt_ConsultancyFeeReport : Telerik.Reporting.Report
    {
        public DebitNoteRpt_ConsultancyFeeReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRpt_ConsultancyFeeReport(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type)
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
            // added for #23256 --end

            //txtTextDN.Value = "DEBIT NOTE :";
            if (dsObj.Tables.Contains("reprint"))
            {
                textBox49.Value = "DUPLICATE";
            }

            if (dsObj.Tables.Count > 0)
            {
                string IsPrintLegNote = string.Empty;
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    if (dsObj.Tables[0].Rows[0]["InvoiceNo"] != DBNull.Value)
                        txtCoveNoteNo.Value = txtCoverNote1.Value = ": " + dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["EffectiveDate"] != DBNull.Value)
                        txtCoverNoteDate.Value = ": " + dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value)
                        txtClientCode.Value = txtClientCode1.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();
                    if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                        txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ExecutiveInCharge"] != DBNull.Value)
                        txtServicer.Value = ": " + dsObj.Tables[0].Rows[0]["ExecutiveInCharge"].ToString();
                    if (dsObj.Tables[0].Rows[0]["BillingDueDate"] != DBNull.Value)
                        txtDueDate.Value = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();
                    if (dsObj.Tables[0].Rows[0]["BankName"] != DBNull.Value)
                        txtBankName.Value = "" + dsObj.Tables[0].Rows[0]["BankName"].ToString();
                    if (dsObj.Tables[0].Rows[0]["SwiftCode"] != DBNull.Value)
                        textBox42.Value = "" + dsObj.Tables[0].Rows[0]["SwiftCode"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ACNo"] != DBNull.Value)
                        textBox7.Value = "" + dsObj.Tables[0].Rows[0]["ACNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["Remarks"] != DBNull.Value)
                        txtParticular.Value = ": " + dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                    if (dsObj.Tables[0].Rows[0]["GrossPremCurrency"] != DBNull.Value)
                        txtCurrency.Value = txtCurr1.Value = ": " + dsObj.Tables[0].Rows[0]["GrossPremCurrency"].ToString() + "";
                    txtClientAddress1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorrAddress1"]);
                    txtClientAddress2.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorreAddress2"].ToString());
                    txtClientAddress3.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorreAddress3"].ToString());
                    txtClientAddress4.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["CorrAddress4"].ToString());
                    IsPrintLegNote = Convert.ToString(dsObj.Tables[0].Rows[0]["IsPrintLegNote"]);
                    //if (IsPrintLegNote == "True")
                    //{
                    //    textBox64.Visible = true;
                    //    textBox22.Visible = true;
                    //    textBox20.Visible = true;
                    //    textBox28.Visible = true;
                    //    textBox30.Visible = true;
                    //    textBox33.Visible = true;
                    //    textBox34.Visible = true;
                    //    pnlGeneral.Visible = true;
                    //    pnlLife.Visible = true;
                    //    pnlNonLife.Visible = true;
                    //    detail.Visible = true;
                    //    this.pnlNonLife.Style.Visible = true;
                    //    this.pnlLife.Style.Visible = true;
                    //    this.detail.CanShrink = false;
                    //    this.pnlGeneral.Style.Visible = true;
                    //}
                    //else
                    //{
                    //    textBox64.Visible = false;
                    //    textBox22.Visible = false;
                    //    textBox20.Visible = false;
                    //    textBox28.Visible = false;
                    //    textBox30.Visible = false;
                    //    textBox33.Visible = false;
                    //    textBox34.Visible = false;
                    //    pnlGeneral.Visible = false;
                    //    pnlLife.Visible = false;
                    //    this.pnlNonLife.Style.Visible = false;
                    //    this.pnlLife.Style.Visible = false;
                    //    this.pnlGeneral.Style.Visible = false;
                    //    pnlNonLife.Visible = false;

                    //}
                }
                //PolicyDetails
                //if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value)
                //    txtClassofInsurance.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                //if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value)
                //    txtEndtNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
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
                //    txtCurrency.Value = txtCurr1.Value = ": <" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";       // added for #23642
                //if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value)
                //{
                //    txtAmount.Value = txtAmt1.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));   // added for #23642
                //}
                if (IsPrintLegNote == "True")
                {
                    if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "NLF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                        pnlGeneral.Visible = true;
                    //#32117 
                    //if (dsObj.Tables[0].Rows[0]["CoverageToInclude"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "EB" || dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "V"))
                    //    pnlGeneral.Visible = false;= txtInsuredName.Value

                    if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "LIF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                        pnlLife.Visible = true;

                    if (dsObj.Tables[0].Rows[0]["PremWarranty"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "0"))
                        pnlNonLife.Visible = true;

                    //if (dsObj.Tables[0].Rows[0]["Insured"] != DBNull.Value)
                    //    txtInsuredName.Value = dsObj.Tables[0].Rows[0]["Insured"].ToString();

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

                    if (pnlLife.Visible == false && pnlNonLife.Visible == true)
                    {
                        pnlNonLife.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Cm),
                                                new Telerik.Reporting.Drawing.Unit(13.80, Telerik.Reporting.Drawing.UnitType.Cm));
                    }
                }
            }

            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["CompanyName"]).ToUpper();
                txtCompanyName1.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["CompanyName"]);
                txtCompanyAddress.Value = dsObj.Tables[1].Rows[0]["CompanyAdd1"].ToString() + " " + dsObj.Tables[1].Rows[0]["CompanyAdd2"].ToString() + " " + dsObj.Tables[1].Rows[0]["CompanyAdd3"].ToString() + Environment.NewLine + dsObj.Tables[1].Rows[0]["CompanyAdd4"].ToString();

                //    //txtClientName.Value = dsObj.Tables[2].Rows[0]["ClientName"].ToString();
                //    txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                //    txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                //    txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                //    txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                //    txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
            }

            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtClientName.Value = dsObj.Tables[2].Rows[0]["ClientName"].ToString();
                if (dsObj.Tables[2].Rows[0]["Insured"] != DBNull.Value)
                    txtInsuredName.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
                if (dsObj.Tables[2].Rows[0]["PolicyNo"] != DBNull.Value)
                    txtEndtNo.Value = ": " + dsObj.Tables[2].Rows[0]["PolicyNo"].ToString();
                if (dsObj.Tables[2].Rows[0]["SubClassName"] != DBNull.Value)
                    txtClassofInsurance.Value = ": " + dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                if (dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString() == null || dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString() == "")
                {
                    txtPOIFrom.Visible = false;
                    txtPOITo.Visible = false;
                }
                else
                {
                    txtPOIFrom.Value = ": " + dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString();
                    txtPOITo.Value = "" + dsObj.Tables[2].Rows[0]["EffectiveDateTo"].ToString();
                }
                if (dsObj.Tables[2].Rows[0]["Insurer Name"] != DBNull.Value)
                    txtInsurerName.Value = ": " + dsObj.Tables[2].Rows[0]["Insurer Name"].ToString();
                //txtImpNotice6.Value="6. All Cheques should be crossed and made payable to \"" +dsObj.Tables[2].Rows[0]["TopCompanyName"].ToString()+"\"";
                //txtCompanyName.Value = txtCompanyName1.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                //txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
            }
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                if (dsObj.Tables[3].Rows[0]["ServiceFee"] != DBNull.Value || dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"] != DBNull.Value)
                {
                    txtAmount.Value = txtAmt1.Value = Convert.ToString((dsObj.Tables[3].Rows[0]["ServiceFee"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"]));
                    txtAmount.Value = txtAmt1.Value = ConvertIntoNumeric((dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"] == DBNull.Value) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString()) + Convert.ToDecimal(txtAmt1.Value)));
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
            //    lblInsurer.Visible = true;
            //    //if (dsObj.Tables[4].Rows.Count > 2)
            //    //{
            //    //    tblInsurerList.Visible = true;
            //    //    lblInsurer.Visible = true;
            //    //    tblInsurerList.DataSource = dsObj.Tables[4];
            //    //    txtInsurerName.Value = ": PLEASE SEE ATTACHED";
            //    //}
            //    //if (dsObj.Tables[5].Rows.Count > 0)
            //    //{
            //    //    dsObj.Tables[5].Columns["TotalDue"].DataType = typeof(Decimal);
            //    //    foreach (DataRow dr in dsObj.Tables[5].Rows)
            //    //    {
            //    //        dr["TotalDue"] = (dr["TotalDue"] == DBNull.Value) ?Convert.ToDecimal(0.00) : Convert.ToDecimal(dr["TotalDue"]);
            //    //    }
            //    //    tblInstalment.Visible = true;
            //    //    lblInstalment.Visible = true;
            //    //    if (dsObj.Tables[0].Rows.Count > 0)
            //    //    {
            //    //        textBox39.Value = "Gross Premium " + "<" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";
            //    //    }
            //    //    tblInstalment.DataSource = dsObj.Tables[5];
            //    //}
            //}
            if (dsObj.Tables[0].Rows.Count > 0 && Convert.ToString(dsObj.Tables[0].Rows[0]["CoInsurance"]) == "Y" && Convert.ToString(dsObj.Tables[0].Rows[0]["Installment"]) == "Y")
            {
                tblInstalment.Visible = true;
                lblInstalment.Visible = true;
                lblInsurer.Visible = true;
                textBox76.Visible = false;
                textBox74.Value = "";
                textBox73.Value = "";
                textBox37.Value = "";
                textBox38.Value = "";
                txtTotal.Visible = false;
            }
            else
            {
                textBox76.Visible = false;
                txtTotal.Visible = false;
                this.panel2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0D);
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