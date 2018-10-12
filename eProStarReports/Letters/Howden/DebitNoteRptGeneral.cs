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
    public partial class DebitNoteRptGeneral : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneral()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRptGeneral(DataSet dsObj, string strClientCode, string strOriDup)
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
            string _customizedClient = String.Empty;
            BusinessAccessLayer.Common.clsCommon _cmn = new BusinessAccessLayer.Common.clsCommon();
            _customizedClient = _cmn.GetCustomizedClient();
            if (dsObj.Tables.Count > 0)
            {
                // Values from Table 0
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //commented for redmine #34313
                    //if (dsObj.Tables[0].Rows[0]["DebitNoteNo"] != DBNull.Value)
                    //    txtCoveNoteNo.Value = txtCoverNote1.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value)
                    //    txtCoverNoteDate.Value = ": " + dsObj.Tables[0].Rows[0]["DebitNotedate"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["ClientCode"] != DBNull.Value)
                    //    txtClientCode.Value = txtClientCode1.Value = ": " + dsObj.Tables[0].Rows[0]["ClientCode"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                    //    txtClosingSlipNo.Value = ": " + dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["Servicer"] != DBNull.Value)
                    //    txtServicer.Value = ": " + dsObj.Tables[0].Rows[0]["Servicer"].ToString();       // added for #23642
                    //if (dsObj.Tables[0].Rows[0]["BillingDueDate"] != DBNull.Value)
                    //    txtDueDate.Value = ": " + dsObj.Tables[0].Rows[0]["BillingDueDate"].ToString();       // added for #23642
                    //--End --- 

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

                    tbllables.DataSource = _dtLabels;

                    if (dsObj.Tables[0].Rows[0]["BankName"] != DBNull.Value)
                        txtBankName.Value = "" + dsObj.Tables[0].Rows[0]["BankName"].ToString();
                    if (dsObj.Tables[0].Rows[0]["SwiftCode"] != DBNull.Value)
                        textBox42.Value = "" + dsObj.Tables[0].Rows[0]["SwiftCode"].ToString();
                    if (dsObj.Tables[0].Rows[0]["ACNo"] != DBNull.Value)
                        textBox7.Value = "" + dsObj.Tables[0].Rows[0]["ACNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["Remarks"] != DBNull.Value)
                        txtParticular.Value = ": " + dsObj.Tables[0].Rows[0]["Remarks"].ToString();


                    

                    //PolicyDetails
                    if (dsObj.Tables[0].Rows[0]["SubClassName"] != DBNull.Value)
                        txtClassofInsurance.Value = ": " + dsObj.Tables[0].Rows[0]["SubClassName"].ToString();       // added for #23642
                    if (dsObj.Tables[0].Rows[0]["PolicyNo"] != DBNull.Value)
                        txtEndtNo.Value = ": " + dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();       // added for #23642
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
                            txtCurrency.Value = txtCurr1.Value = ": " + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString(); //redmine #34313
                        }
                        else
                        {
                            txtCurrency.Value = txtCurr1.Value = ": <" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";       // added for #23642
                        }
                        
                    if (dsObj.Tables[0].Rows[0]["TotalDue"] != DBNull.Value)
                    {
                        txtAmount.Value = txtAmt1.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));   // added for #23642
                    }

                    if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "NLF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                        pnlGeneral.Visible = true;
                    //#32117 
                    //if (dsObj.Tables[0].Rows[0]["CoverageToInclude"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "EB" || dsObj.Tables[0].Rows[0]["CoverageToInclude"].ToString() == "V"))
                    //    pnlGeneral.Visible = false;= txtInsuredName.Value

                    if (dsObj.Tables[0].Rows[0]["SubClassType"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["SubClassType"].ToString() == "LIF") && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "1"))
                        pnlLife.Visible = true;
                   
                    if (dsObj.Tables[0].Rows[0]["PremWarranty"] != DBNull.Value && (dsObj.Tables[0].Rows[0]["PremWarranty"].ToString() == "0"))
                        pnlNonLife.Visible = true;

                    if (dsObj.Tables[0].Rows[0]["ClientName"] != DBNull.Value)
                        txtInsuredName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
   
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

                    //if (pnlLife.Visible == false && pnlNonLife.Visible == true)
                    //{
                    //    pnlNonLife.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.01, Telerik.Reporting.Drawing.UnitType.Cm),
                    //                            new Telerik.Reporting.Drawing.Unit(13.80, Telerik.Reporting.Drawing.UnitType.Cm));
                    //}                   
                }

                //Values from Table 1
                if (dsObj.Tables[1].Rows.Count > 0)
                {
                    txtClientName.Value  = dsObj.Tables[1].Rows[0]["ClientName"].ToString();
                    txtClientAddress1.Value = dsObj.Tables[1].Rows[0]["ClientAddress1"].ToString();
                    txtClientAddress2.Value = dsObj.Tables[1].Rows[0]["ClientAddress2"].ToString();
                    txtClientAddress3.Value = dsObj.Tables[1].Rows[0]["ClientAddress3"].ToString();
                    txtClientAddress4.Value = dsObj.Tables[1].Rows[0]["ClientAddress4"].ToString();
                    txtClientAddress5.Value = Convert.ToString(dsObj.Tables[1].Rows[0]["PostalCode"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["ProvinceName"]) + " " + Convert.ToString(dsObj.Tables[1].Rows[0]["TerritoryName"]);
                }

                //Values from Table 2
                if (dsObj.Tables[2].Rows.Count > 0)
                {
                    //txtImpNotice6.Value="6. All Cheques should be crossed and made payable to \"" +dsObj.Tables[2].Rows[0]["TopCompanyName"].ToString()+"\"";
                    txtCompanyName.Value = txtCompanyName1.Value = Convert.ToString(dsObj.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                    txtCompanyAddress.Value = dsObj.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
                }

                if (_customizedClient.ToUpper() == "HOWDENSG")
                {
                    if (dsObj.Tables[4].Rows.Count > 3) // fixed for redmine #34313 as per document.
                    {
                        tblInsurerList.Visible = true;
                        lblInsurer.Visible = true;
                        tblInsurerList.DataSource = dsObj.Tables[4];
                        txtInsurerName.Value = ": PLEASE SEE ATTACHED";
                    }
                }
                else
                {
                    if (dsObj.Tables[4].Rows.Count > 2) 
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
                        dr["TotalDue"] = (dr["TotalDue"] == DBNull.Value) ?Convert.ToDecimal(0.00) : Convert.ToDecimal(dr["TotalDue"]);
                    }
                    tblInstalment.Visible = true;
                    lblInstalment.Visible = true;
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        if (_customizedClient.ToUpper() == "HOWDENSG")
                        {
                            textBox39.Value = "Gross Premium " +  dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString(); //redmine #34313
                        }
                        else
                        {
                            textBox39.Value = "Gross Premium " + "<" + dsObj.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() + ">";
                        }
                        
                    }
                    tblInstalment.DataSource = dsObj.Tables[5];
                }
            }
            
            if (_customizedClient.ToUpper() == "HOWDENSG")
            {
                //textBox11.Visible = false;
                //txtCoverNoteDate.Visible = false;
                textBox20.Value = textBox20.Value.Replace("1. ", "");
                textBox28.Value = textBox20.Value.Replace("2. ", "");
                textBox33.Value = textBox20.Value.Replace("3. ", "");
                textBox2.Value = "GROSS PREMIUM TO BE COLLECTED ON BEHALF OF INSURER";
                textBox39.Value = "Gross Premium (Incl GST)";
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