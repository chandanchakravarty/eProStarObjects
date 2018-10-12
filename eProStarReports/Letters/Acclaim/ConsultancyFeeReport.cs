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
    /// Summary description for ConsultancyFeeReport.
    /// </summary>
    public partial class ConsultancyFeeReport : Telerik.Reporting.Report
    {
        public ConsultancyFeeReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }



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
        public ConsultancyFeeReport(DataSet dsObj, string strClientCode, string clientFlag, string printlogo)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();

            this.pictureBox1.Value = ReportsUtility.ClientLogo;
            if (printlogo == "Y")
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                if (clientFlag == "Tax")
                {

                   
                    decimal totaldue = Convert.ToDecimal(dsObj.Tables[2].Rows[0]["DueFromClient"]);
                  if (totaldue>=0)
                  {
                      txtDebitNote.Value = "TAX INVOICE";
                  }
                  else
                  {
                      txtDebitNote.Value = "Credit Note";
                  }
                   
                    txtOfficeCopy.Visible = false;

                    table4.Visible = false;
                    //tblfooterpolicy.Visible = false;
                    //tblfootergst.Visible = false;
                    //tblfooterinsurer.Visible = false;
                    //tblfooterintroducer.Visible = false;
                    //tblfooter.Visible = false;

                }
                //else if (clientFlag == "DebitOfficeCopy")
                //{
                //    txtDebitNote.Value = "DEBIT NOTE";
                //    txtOfficeCopy.Value = "OFFICE COPY";
                //    txtPremium.Value = decimal.Parse(dsObj.Tables[2].Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                //    txtpremiumgst.Value = "Premium";
                //    txtchargesgst.Value = "Charges";
                //    txtCharges.Value = decimal.Parse(dsObj.Tables[2].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                //    txtDiscount.Visible = true;
                //    txtdiscountshow.Visible = true;
                //    txtDiscount.Value = decimal.Parse(dsObj.Tables[2].Rows[0]["Discount"].ToString()).ToString("#,##0.00");
                //    txtPolicyStatus.Value = ""; //dsObj.Tables[2].Rows[0]["PolicyStatus"].ToString();
                //    txtRenewalType.Value = "";//dsObj.Tables[2].Rows[0]["TotalDue"].ToString();
                //    txtDivisionalGroup.Value = dsObj.Tables[3].Rows[0]["DivisionalGroupingName"].ToString();
                //    txtGrossPremium.Value = decimal.Parse(dsObj.Tables[3].Rows[0]["Premium"].ToString()).ToString("#,##0.00");
                //    txtGstonPremium.Value = decimal.Parse( dsObj.Tables[3].Rows[0]["InsurerGSTAmount"].ToString()).ToString("#,##0.00");
                //    txtCharge.Value = decimal.Parse(dsObj.Tables[3].Rows[0]["PolicyCharge"].ToString()).ToString("#,##0.00");
                //    //  txtGstonCharges.Value = dsObj.Tables[3].Rows[0]["InsurerGSTAmount"].ToString();
                //    txtGrossBrokerage.Value = decimal.Parse(dsObj.Tables[4].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");
                //    txtGrossBroPer.Value = dsObj.Tables[4].Rows[0]["BrokerageRate"].ToString() + " %";
                //    txtgstbrokerage.Value = decimal.Parse(dsObj.Tables[4].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");

                //}
                else if (clientFlag == "TaxOfficeCopy")
                {
                    decimal totalduec = Convert.ToDecimal(dsObj.Tables[2].Rows[0]["DueFromClient"]);
                    if (totalduec >= 0)
                    {
                        txtDebitNote.Value = "TAX INVOICE";
                    }
                    else
                    {
                        txtDebitNote.Value = "Credit Note";
                    }
                  
                    txtOfficeCopy.Value = "OFFICE COPY";

                    //txtPolicyStatus.Value = ""; //dsObj.Tables[2].Rows[0]["PolicyStatus"].ToString();
                    //txtRenewalType.Value = "";//dsObj.Tables[2].Rows[0]["TotalDue"].ToString();
                    //txtDivisionalGroup.Value = dsObj.Tables[3].Rows[0]["DivisionalGroupingName"].ToString();
                    //txtGrossPremium.Value = decimal.Parse(dsObj.Tables[2].Rows[0]["ServiceFee"].ToString()).ToString("#,##0.00");
                    //txtGstonPremium.Value = decimal.Parse(dsObj.Tables[2].Rows[0]["ServiceFeeGSTAmount"].ToString()).ToString("#,##0.00");

                    //txtgrossprem.Value = "Service Fee";
                    //txtgstservicefee.Value = "GST on Service Fee";

                    //txtchargesshow.Value="";
                    //// txtgstchargeshow.Visible = false;
                    //txtCharge.Value = "";
                    //txtGstonCharges.Visible = false;

                    //txtGrossBrokerage.Value = decimal.Parse(dsObj.Tables[4].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");
                    //txtGrossBroPer.Value = dsObj.Tables[4].Rows[0]["BrokerageRate"].ToString() + " %";
                    //txtgstbrokerage.Value = decimal.Parse(dsObj.Tables[4].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");

                    //tblfooterinsurer.Visible = false;
                }

                DataView dv = new DataView(dsObj.Tables[0]);
                dv.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTable = dv.ToTable();
                if (dtViewTable != null)
                {
                    txtCompanyName.Value = dtViewTable.Rows[0]["ClientName"].ToString();
                    txtAddress.Value = dtViewTable.Rows[0]["BillingAddress1"].ToString();
                    txtBillingAdd2.Value = dtViewTable.Rows[0]["BillingAddress2"].ToString();
                    txtBillingAdd34.Value = dtViewTable.Rows[0]["BillingAddressLast"].ToString();

                    if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()) && String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingPostalCode"].ToString()))
                    {
                        txtCountryNamewithPostalCode.Value = "";
                    }
                    else if (String.IsNullOrEmpty(dtViewTable.Rows[0]["BillingCountry"].ToString()))
                    {
                        txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    }
                    else if (String.IsNullOrEmpty(dsObj.Tables[0].Rows[0]["BillingPostalCode"].ToString()))
                    {
                        txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString();
                    }
                    else
                    {
                        txtCountryNamewithPostalCode.Value = dtViewTable.Rows[0]["BillingCountry"].ToString() + ", " + dtViewTable.Rows[0]["BillingPostalCode"].ToString();
                    }


                   txtDocNo.Value = dtViewTable.Rows[0]["ClientDebitNoteNo"].ToString();
                    txtDate.Value = dsObj.Tables[0].Rows[0]["CreatedDate"].ToString();
                    txtClientCode.Value = dtViewTable.Rows[0]["ClientCode"].ToString();
                    txtCoverNote.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    txtDueDate.Value = dsObj.Tables[0].Rows[0]["duedate"].ToString();
                    txtServicer.Value = dsObj.Tables[0].Rows[0]["Primary_AccountHandler"].ToString();

                    txtInsuredDetails.Value = dsObj.Tables[0].Rows[0]["DebitNoteTo"].ToString();

                    if (dsObj.Tables[0].Rows[0]["SubClassName"].ToString().Trim() != "Please Select")
                    {
                        string str = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();
                        string x = "-";
                        if (str.Contains(x))
                        {
                            string[] strSplit = str.Split('-');
                            //txtClassofInsurance.Value = strSplit[1].ToString();
                            var index = str.IndexOf("-");
                            txtClassofInsurance.Value = index < 0 ? str : str.Substring(index + 1);
                        }
                        else
                            txtClassofInsurance.Value = dsObj.Tables[0].Rows[0]["SubClassName"].ToString();

                    }
                    else
                    {
                        txtClassofInsurance.Value = dsObj.Tables[0].Rows[0]["MainClassName"].ToString();

                    }

                    if (dsObj.Tables[0].Rows[0]["SubClassName"].ToString().Trim() == "Please Select" && dsObj.Tables[0].Rows[0]["MainClassName"].ToString().Trim() == "Please Select")
                    {
                        txtClassofInsurance.Value = "";
                    }

                    txtPolicyNo.Value = dsObj.Tables[0].Rows[0]["policyNo"].ToString();
                    if (dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() != "" && dsObj.Tables[0].Rows[0]["POIToDate"].ToString() != "")
                        txtPolicyPeriod.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() + " To " + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                    else if (dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() != "" && dsObj.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                        txtPolicyPeriod.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                    else
                        txtPolicyPeriod.Value = "";
                    if (dsObj.Tables[0].Rows[0]["EndtInsurerNo"].ToString() != "")
                        txtEndtNo.Value = dsObj.Tables[0].Rows[0]["EndtInsurerNo"].ToString();
                    else
                    {
                        txtEndtNo.Visible = false;
                        textBox11.Visible = false;
                    }
                    if (dsObj.Tables[0].Rows[0]["EndtEffectivetDate"].ToString() != "")
                        txtEndtEffectivedate.Value = dsObj.Tables[0].Rows[0]["EndtEffectivetDate"].ToString();
                    else
                    {
                        textBox12.Visible = false;
                        txtEndtEffectivedate.Visible = false;
                    }

                    txtDescription.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
                }

                textBox14.Value = "Payment to be made via cheque to \"" + dsObj.Tables[1].Rows[0]["CompanyName"].ToString() + "\" or bank transfer to :";
                txtBankName.Value = dsObj.Tables[1].Rows[0]["BankName"].ToString();
                //txtBankCode.Value = dsObj.Tables[1].Rows[0]["BankCode"].ToString();
                //txtBranceCode.Value = dsObj.Tables[1].Rows[0]["BranchName"].ToString();
                txtAccountNo.Value = dsObj.Tables[1].Rows[0]["ACNo"].ToString();
                txtSwiftCode.Value = dsObj.Tables[1].Rows[0]["SwiftCode"].ToString();

                txtCurrency.Value = dsObj.Tables[0].Rows[0]["GrossPremCurrency"].ToString();

                DataView dvAmount = new DataView(dsObj.Tables[2]);
                dvAmount.RowFilter = "ClientCode = '" + strClientCode + "'";
                DataTable dtViewTableAmount = dvAmount.ToTable();
                if (dtViewTableAmount != null)
                {

                    if (!(Convert.ToDouble(dtViewTableAmount.Rows[0]["ServiceFee"]) == Convert.ToDouble(0)))
                    {
                        txtPremium.Value = convertIntoNumeric(decimal.Parse(dtViewTableAmount.Rows[0]["ServiceFee"].ToString()));
                    }
                    else
                    {

                        txtPremium.Value = decimal.Parse(dtViewTableAmount.Rows[0]["ServiceFee"].ToString()).ToString("#,##0.00");
                    }


                    txtpremiumgst.Value = "Service Fee";
                    txtchargesgst.Value = "GST";

                    if (!(Convert.ToDouble(dtViewTableAmount.Rows[0]["ServiceFeeGSTAmount"]) == Convert.ToDouble(0)))
                    {
                        txtCharges.Value = convertIntoNumeric(decimal.Parse(dtViewTableAmount.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                    }
                    else
                    {

                        txtCharges.Value = decimal.Parse(dtViewTableAmount.Rows[0]["ServiceFeeGSTAmount"].ToString()).ToString("#,##0.00");
                    }

                    //txtDiscount.Visible = false;
                    //txtdiscountshow.Visible = false;

                    if (!(Convert.ToDouble(dtViewTableAmount.Rows[0]["TotalDue"]) == Convert.ToDouble(0)))
                    {
                        txtTotalDue.Value = convertIntoNumeric(decimal.Parse(dtViewTableAmount.Rows[0]["TotalDue"].ToString()));
                    }
                    else
                    {

                        txtTotalDue.Value = decimal.Parse(dtViewTableAmount.Rows[0]["TotalDue"].ToString()).ToString("#,##0.00");
                    }



                }
                // txtgstchargeshow.Visible = false;
                //txtGstonCharges.Visible = false;

                if (clientFlag != "Tax")
                {


                    int minRows = 6;
                    int maxRows = 0;
                    int intRows = 2 + dsObj.Tables[4].Rows.Count + dsObj.Tables[5].Rows.Count;
                    int introducerRows = dsObj.Tables[5].Rows.Count;
                    int insurerRows = dsObj.Tables[4].Rows.Count;
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

                    DataView dvAmount2 = new DataView(dsObj.Tables[2]);
                    dvAmount2.RowFilter = "ClientCode = '" + strClientCode + "'";
                    DataTable dtViewTableAmount2 = dvAmount2.ToTable();

                    for (int i = 1; i <= maxRows; i++)
                    {
                        DataRow objDataRow = objDataTable.NewRow();
                        DataTable table;
                        table = dsObj.Tables[4];
                        if (i == 1)
                        {
                            objDataRow["Col1"] = "Policy Status";
                            objDataRow["Col2"] = dsObj.Tables[6].Rows[0]["DebitNoteType"].ToString();
                            //objDataRow["Col3"] = "Gross Brokerage";
                            //objDataRow["Col4"] = "";
                            //objDataRow["Col5"] = table.Compute("Sum(BrokerageRate)", "").ToString() + " %"; // dsObj.Tables[4].Rows[0]["BrokerageRate"].ToString() + " %";
                            //objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(Brokerage)", "").ToString()).ToString("#,##0.00"); //decimal.Parse(dsObj.Tables[4].Rows[0]["BrokerGSTAmount"].ToString()).ToString("#,##0.00");
                        }
                        if (i == 2)
                        {
                            objDataRow["Col1"] = "Renewal Type";
                            objDataRow["Col2"] = dsObj.Tables[7].Rows[0]["RenewalType"].ToString();
                            //objDataRow["Col3"] = "GST on Brokerage";
                            //objDataRow["Col4"] = "";
                            //objDataRow["Col5"] = "";
                            //objDataRow["Col6"] = decimal.Parse(table.Compute("Sum(BrokerGSTAmount)", "").ToString()).ToString("#,##0.00");// decimal.Parse(dsObj.Tables[4].Rows[0]["Brokerage"].ToString()).ToString("#,##0.00");
                        }

                        if (i >= 3)
                        {
                            if (i == 3)
                            {
                                objDataRow["Col1"] = "Divisional Grouping";
                                if (dsObj.Tables[3].Rows.Count>0)
                                {
                                    objDataRow["Col2"] = dsObj.Tables[3].Rows[0]["DivisionalGroupingName"].ToString();
                                }
                                else
                                {
                                    objDataRow["Col2"] = "";
                                }
                            }
                            else if (i == 4)
                            {
                                objDataRow["Col1"] = "Service Fee";

                                if (!(Convert.ToDouble(dtViewTableAmount2.Rows[0]["ServiceFee"].ToString()) == Convert.ToDouble(0.0)))
                                {
                                    objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTableAmount2.Rows[0]["ServiceFee"].ToString()));
                                }
                                else
                                {

                                    objDataRow["Col2"] = decimal.Parse(dtViewTableAmount2.Rows[0]["ServiceFee"].ToString()).ToString("#,##0.00");
                                }

                            }
                            else if (i == 5)
                            {
                                objDataRow["Col1"] = "GST on Service Fee";
                                if (!(Convert.ToDouble(dtViewTableAmount2.Rows[0]["ServiceFeeGSTAmount"].ToString()) == Convert.ToDouble(0.0)))
                                {
                                    objDataRow["Col2"] = convertIntoNumeric(decimal.Parse(dtViewTableAmount2.Rows[0]["ServiceFeeGSTAmount"].ToString()));
                                }
                                else
                                {

                                    objDataRow["Col2"] = decimal.Parse(dtViewTableAmount2.Rows[0]["ServiceFeeGSTAmount"].ToString()).ToString("#,##0.00");
                                }





                               

                            }
                            else if (i == 6)
                            {
                                objDataRow["Col1"] = "Charges";
                                objDataRow["Col2"] = "";
                            }
                            else
                            {
                                objDataRow["Col1"] = "";
                                objDataRow["Col2"] = "";
                            }

                        }

                        if (introducerRows > 0)
                        {
                            //Bind from Introducer Table

                            objDataRow["Col3"] = "Introducer " + (introducerRowIndex + 1).ToString();
                            objDataRow["Col4"] = dsObj.Tables[5].Rows[introducerRowIndex]["AGENTNAME"].ToString();
                            objDataRow["Col5"] = dsObj.Tables[5].Rows[introducerRowIndex]["AgentShare"].ToString() + " %";


                            if (!(Convert.ToDouble(dsObj.Tables[5].Rows[introducerRowIndex]["PREMIUM"]) == Convert.ToDouble(0.0)))
                            {
                                objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dsObj.Tables[5].Rows[introducerRowIndex]["PREMIUM"].ToString()));
                            }
                            else
                            {

                                objDataRow["Col6"] = decimal.Parse(dsObj.Tables[5].Rows[introducerRowIndex]["PREMIUM"].ToString()).ToString("#,##0.00");
                            }
                            introducerRows--;
                            introducerRowIndex++;


                        }
                        else if (insurerRows > 0)
                        {
                            if (dsObj.Tables[4].Rows[insurerRowIndex]["UnderWriterCode"].ToString() != "")
                            {
                                //Bind from Insurer Table
                                objDataRow["Col3"] = "Insurer " + (insurerRowIndex + 1).ToString();
                                objDataRow["Col4"] = dsObj.Tables[4].Rows[insurerRowIndex]["UnderWriterName"].ToString();
                                objDataRow["Col5"] = dsObj.Tables[4].Rows[insurerRowIndex]["UWShare"].ToString() + " %";

                                if (!(Convert.ToDouble(dsObj.Tables[4].Rows[insurerRowIndex]["Premium"]) == Convert.ToDouble(0.0)))
                                {
                                    objDataRow["Col6"] = convertIntoNumeric(decimal.Parse(dsObj.Tables[4].Rows[insurerRowIndex]["Premium"].ToString()));
                                }
                                else
                                {

                                    objDataRow["Col6"] = decimal.Parse(dsObj.Tables[4].Rows[insurerRowIndex]["Premium"].ToString()).ToString("#,##0.00");
                                }


                                insurerRows--;
                                insurerRowIndex++;
                            }
                        }
                        else
                        {
                            objDataRow["Col3"] = "";
                            objDataRow["Col4"] = "";
                            objDataRow["Col5"] = "";
                            objDataRow["Col6"] = "";
                        }
                        objDataTable.Rows.Add(objDataRow);
                    }
                    table4.DataSource = objDataTable;

                }
            }
        }
    }
}