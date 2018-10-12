namespace eProStarReports.Letters.Acclaim
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    // using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PremiumInstalmentPaymentWarranty_OfficeCopy.
    /// </summary>
    public partial class PremiumInstalmentPaymentWarranty_OfficeCopy : Telerik.Reporting.Report
    {
        private DataRow emptyRow;
        public PremiumInstalmentPaymentWarranty_OfficeCopy()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PremiumInstalmentPaymentWarranty_OfficeCopy(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, String Username)
        {

            InitializeComponent();
            //if (dsObj.Tables[6].Rows.Count > 0)
            //{
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "ClientCode = '" + strClientCode + "'";
            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable != null)
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
                    txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString() + ", " + dtViewTable.Rows[0]["BillingPostalCode"].ToString() ;
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
                    txtContactPersonName.Value = "Ms/Mr " + dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;
                //panel6.Visible = false;
                //textBox4.Visible = false;
                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
            {
                txtEndtNo1.Visible = true;
                txtEndtNo.Visible = true;
                txtEndtNo1.Value = dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString();
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
            txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "'";
            DataTable dtViewTable1 = dv1.ToTable();
            if (dtViewTable1 != null)
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    txtBankCode.Visible = false;
                    txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    txtBankCode1.Visible = false;
                    txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "CREDIT NOTE";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    txtBankCode.Visible = true;
                    txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    txtBankCode1.Visible = true;
                    txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }
                txtPremium1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));
                //txtPremiumCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    txtCharges1.Visible = true;
                    //txtChargesCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    //txtChargesCr.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;                    
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {
                    txtDiscount1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    txtDiscount.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                //txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();

                txtTotalDue1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                //txtTotalDueCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }

            int minRows = 6;
            int maxRows = 0;
            int intRows = 2 + dsObj.Tables[12].Rows.Count + dsObj.Tables[13].Rows.Count;
            int introducerRows = dsObj.Tables[13].Rows.Count;
            int insurerRows = dsObj.Tables[12].Rows.Count;
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

            for (int i = 1; i <= maxRows; i++)
            {
                DataRow objDataRow = objDataTable.NewRow();                
                DataTable table;
                table = dsObj.Tables[12];
                if (i == 1)
                {
                    objDataRow["Col1"] = "Policy Status";
                    objDataRow["Col2"] = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    objDataRow["Col3"] = "Gross Brokerage";
                    objDataRow["Col4"] = "";
                    if (dtViewTable1.Rows.Count > 1)
                    {
                        objDataRow["Col5"] = ""; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        //objDataRow["Col6"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientWiseBrok"].ToString()));
                        objDataRow["Col6"] = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString()).ToString("#,##0.00");
                    }
                    else
                    {
                        objDataRow["Col5"] = table.Compute("Sum(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                    }
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
                    objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(BrokerGSTAmount)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");                   
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
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()).ToString("#,##0.00");
                    }
                    else if (i == 5)
                    {
                        objDataRow["Col1"] = "GST on Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["InsurerGSTAmount"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["GSTONPremium"].ToString()).ToString("#,##0.00");

                    }
                    else if (i == 6)
                    {
                        objDataRow["Col1"] = "Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()).ToString("#,##0.00");

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
                        objDataRow["Col4"] = dsObj.Tables[13].Rows[introducerRowIndex]["AGENTNAME"].ToString();
                        objDataRow["Col5"] = dsObj.Tables[13].Rows[introducerRowIndex]["AgentShare"].ToString() + " %";
                        objDataRow["Col6"] = decimal.Parse(dsObj.Tables[13].Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                        introducerRows--;
                        introducerRowIndex++;


                    }
                    else if (insurerRows > 0)
                    {
                        //Bind from Insurer Table
                        objDataRow["Col3"] = "Insurer " + (insurerRowIndex + 1).ToString();
                        objDataRow["Col4"] = dsObj.Tables[12].Rows[insurerRowIndex]["UnderWriterName"].ToString();
                        objDataRow["Col5"] = dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString() + " %";
                        decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));
                        objDataRow["Col6"] = decimal.Parse((aa / 100).ToString()).ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
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


        #region Added By neetu Sinha
        public PremiumInstalmentPaymentWarranty_OfficeCopy(DataSet dsObj, string strClientCode, string strCheckedInstl, int clientFlag, String Username,string installment)
        {

            InitializeComponent();
            //if (dsObj.Tables[6].Rows.Count > 0)
            //{
            DataView dv = new DataView(dsObj.Tables[0]);
            dv.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";

            DataTable dtViewTable = dv.ToTable();
            if (dtViewTable != null)
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
                    txtContactPersonName.Value = "Ms/Mr " + dtViewTable.Rows[0]["ClientContactName"].ToString();
                }

                //txtInsuredName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                txtInsuredName.Value = dtViewTable.Rows[0]["DebitNoteTo"].ToString();

                txtClass1.Value = dtViewTable.Rows[0]["SubClassName"].ToString().Replace(",", "");
                txtPolicyNo1.Value = dtViewTable.Rows[0]["PolicyNo"].ToString();
                txtPOIFrom.Value = dtViewTable.Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dtViewTable.Rows[0]["POIToDate"].ToString();

                panel2.Visible = true;
                panel3.Visible = true;
                //panel6.Visible = false;
                //textBox4.Visible = false;
                txtDescription1.Value = dtViewTable.Rows[0]["Remarks"].ToString();
                txtCurrecny1.Value = dtViewTable.Rows[0]["Currency"].ToString();

                //txtCurrencyCr.Value = dtViewTable.Rows[0]["Currency"].ToString();

            }
            txtCompanyName.Value = "Payment to be made via cheque to \"" + dsObj.Tables[10].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
            if (dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString() != "NA")
            {
                txtEndtNo1.Visible = true;
                txtEndtNo.Visible = true;
                txtEndtNo1.Value = dsObj.Tables[2].Rows[0]["EndorsementNo"].ToString();
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
            txtBankCode1.Value = dsObj.Tables[1].Rows[0]["bankcode"].ToString();
            //txtAddress1.Value = dsObj.Tables[1].Rows[0]["address1"].ToString();
            //txtAddess2.Value = dsObj.Tables[1].Rows[0]["address2"].ToString();
            //txtAddress3.Value = dsObj.Tables[1].Rows[0]["address3"].ToString();
            txtAccNo1.Value = dsObj.Tables[1].Rows[0]["acno"].ToString();
            txtBranchCode1.Value = dsObj.Tables[1].Rows[0]["branchname"].ToString();
            txtSwiftCode1.Value = dsObj.Tables[1].Rows[0]["swiftcode"].ToString();

            DataView dv1 = new DataView(dsObj.Tables[3]);
            dv1.RowFilter = "ClientCode = '" + strClientCode + "' and instno='" + strCheckedInstl + "'";

            DataTable dtViewTable1 = dv1.ToTable();
            if (dtViewTable1 != null)
            {
                if (Convert.ToDouble(dtViewTable.Rows[0]["TotalPremAmount"]) < 0 || Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"]) < 0)
                {
                    txtCompanyName.Visible = false;
                    txtBank.Visible = false;
                    txtBankCode.Visible = false;
                    txtBranchCode.Visible = false;
                    txtAccNo.Visible = false;
                    txtSwiftCode.Visible = false;
                    txtBank1.Visible = false;
                    txtBankCode1.Visible = false;
                    txtBranchCode1.Visible = false;
                    txtAccNo1.Visible = false;
                    txtSwiftCode1.Visible = false;

                    textBox5.Visible = false;
                    textBox6.Visible = true;
                    txtDebitNote.Value = "CREDIT NOTE";
                }
                else
                {
                    txtCompanyName.Visible = true;
                    txtBank.Visible = true;
                    txtBankCode.Visible = true;
                    txtBranchCode.Visible = true;
                    txtAccNo.Visible = true;
                    txtSwiftCode.Visible = true;
                    txtBank1.Visible = true;
                    txtBankCode1.Visible = true;
                    txtBranchCode1.Visible = true;
                    txtAccNo1.Visible = true;
                    txtSwiftCode1.Visible = true;

                    textBox6.Visible = false;
                }
                txtPremium1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));
                //txtPremiumCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()));

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"]) == Convert.ToDouble(0)))
                {
                    txtCharges1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    txtCharges1.Visible = true;
                    //txtChargesCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()));
                    //txtChargesCr.Visible = true;
                    txtCharges.Visible = true;
                }
                else
                {
                    txtCharges1.Visible = false;
                    txtCharges.Visible = false;
                }

                if (!(Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"]) == Convert.ToDouble(0)))
                {
                    txtDiscount1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    txtDiscount1.Visible = true;
                    txtDiscount.Visible = true;
                    //txtDiscountCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientDiscountAmount"].ToString()));
                    //txtDiscountCr.Visible = true;
                }
                else
                {
                    txtDiscount1.Visible = false;
                    txtDiscount.Visible = false;
                    //txtDiscountCr.Visible = false;
                }

                //txtduedatevalue.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtwarrentydate.Value = dsObj.Tables[0].Rows[0]["DebitNoteDate"].ToString();
                //txtservicefeevalue.Value = dsObj.Tables[3].Rows[0]["ServiceFee"].ToString();

                txtTotalDue1.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));
                //txtTotalDueCr.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["DueFromClient"].ToString()));

            }

            int minRows = 6;
            int maxRows = 0;
            int intRows = 2 + dsObj.Tables[12].Rows.Count + dsObj.Tables[13].Rows.Count;
            //int introducerRows = dsObj.Tables[13].Rows.Count;
            ///int insurerRows = dsObj.Tables[12].Rows.Count;
            DataView dv3 = new DataView(dsObj.Tables[12]);
            dv3.RowFilter = " instno ='" + strCheckedInstl + "'";
            DataTable dtinsurer = dv3.ToTable();
            int insurerRows = dtinsurer.Rows.Count;

            DataView dvI = new DataView(dsObj.Tables[13]);
            dvI.RowFilter = " instno ='" + strCheckedInstl + "'";
            DataTable dtintroducer = dvI.ToTable();
            int introducerRows = dtintroducer.Rows.Count;


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

            for (int i = 1; i <= maxRows; i++)
            {
                DataRow objDataRow = objDataTable.NewRow();
                DataTable table;
              //  table = dsObj.Tables[12];
                DataView dv4 = new DataView(dsObj.Tables[12]);
                dv4.RowFilter = " instno ='" + strCheckedInstl + "'";
                table = dv4.ToTable();
                if (i == 1)
                {
                    objDataRow["Col1"] = "Policy Status";
                    objDataRow["Col2"] = dsObj.Tables[14].Rows[0]["DebitNoteType"].ToString();
                    objDataRow["Col3"] = "Gross Brokerage";
                    objDataRow["Col4"] = "";
                    if (dtViewTable1.Rows.Count > 1)
                    {
                        objDataRow["Col5"] = ""; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        //objDataRow["Col6"] = string.Format("{0:0,0.00}", Convert.ToDouble(dtViewTable1.Rows[0]["ClientWiseBrok"].ToString()));
                        objDataRow["Col6"] = decimal.Parse(dtViewTable1.Compute("Sum(ClientWiseBrok)", "").ToString()).ToString("#,##0.00");
                    }
                    else
                    {
                        objDataRow["Col5"] = table.Compute("Avg(BrokerageRate)", "").ToString() + " %"; //dsObj.Tables[12].Rows[0]["BrokerageRate"].ToString() + " %";
                        objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                    }
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
                    objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(BrokerGSTAmount)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[12].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");                   
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
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["PremiumWithoutGST"].ToString()).ToString("#,##0.00");
                    }
                    else if (i == 5)
                    {
                        objDataRow["Col1"] = "GST on Premium";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["InsurerGSTAmount"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["GSTONPremium"].ToString()).ToString("#,##0.00");

                    }
                    else if (i == 6)
                    {
                        objDataRow["Col1"] = "Charges";
                        //objDataRow["Col2"] = decimal.Parse(dsObj.Tables[11].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                        objDataRow["Col2"] = decimal.Parse(dtViewTable1.Rows[0]["Totalpolicycharge"].ToString()).ToString("#,##0.00");

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
                            objDataRow["Col6"] = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                            introducerRows--;
                            introducerRowIndex++;
                        }

                        else
                        {
                            objDataRow["Col3"] = "Introducer " + "1".ToString();
                            objDataRow["Col4"] = dtintroducer.Rows[introducerRowIndex]["AGENTNAME"].ToString();
                            objDataRow["Col5"] = dtintroducer.Rows[introducerRowIndex]["AgentShare"].ToString() + " %";
                            objDataRow["Col6"] = decimal.Parse(dtintroducer.Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
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
                            objDataRow["Col4"] = dtinsurer.Rows[insurerRowIndex]["UnderWriterName"].ToString();
                            objDataRow["Col5"] = dtinsurer.Rows[insurerRowIndex]["UWShare"].ToString() + " %";
                            //objDataRow["Col6"] = decimal.Parse(dtinsurer.Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            //insurerRows--;
                            decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));
                            objDataRow["Col6"] = decimal.Parse((aa / 100).ToString()).ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                            insurerRows--;
                            insurerRowIndex++;
                        }
                        else
                        {
                            objDataRow["Col3"] = "Insurer " + "1".ToString();
                            // objDataRow["Col4"] = dsObj.Tables[12].Rows[insurerRowIndex]["UnderWriterName"].ToString();
                            objDataRow["Col4"] = dtinsurer.Rows[0]["UnderWriterName"].ToString();
                            objDataRow["Col5"] = dtinsurer.Rows[0]["UWShare"].ToString() + " %";
                            //objDataRow["Col6"] = decimal.Parse(dtinsurer.Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                            //insurerRows--;
                            decimal aa = (decimal.Parse(dtViewTable1.Rows[0]["PRTotalPremium"].ToString()) * decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["UWShare"].ToString()));
                            objDataRow["Col6"] = decimal.Parse((aa / 100).ToString()).ToString("#,##0.00");//decimal.Parse(dsObj.Tables[12].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
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
    }
}