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
    public partial class DebitNoteRptGeneralPremiumClosing : Telerik.Reporting.Report
    {

        public DebitNoteRptGeneralPremiumClosing()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNoteRptGeneralPremiumClosing(DataSet dsObjC, string strClientCode, string strOriDup, int pageCount,string TotalCount)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            decimal TotalPremium = 0;
            decimal TotalPlusGst = 0;
            decimal TotalStampDuty = 0;
            decimal TotalAmount = 0;
            decimal TotalBrokerage = 0;
            decimal TotalGstBrokerage = 0;
            decimal TotalNetPremium = 0;

            foreach (DataRow row in dsObjC.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            if (pageCount > 0)
                txtPaging.Value = "Page" + " " + pageCount + " of " + TotalCount;
            if (dsObjC.Tables.Count > 0)
            {
                if (dsObjC.Tables[0].Rows.Count > 0)
                {
                    textBox2.Value = (dsObjC.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value) ?
                                                     ": " + dsObjC.Tables[0].Rows[0]["DebitNotedate"].ToString() : ":";
                    txtSlipNo.Value  = (dsObjC.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value) ?
                                                      ": " + dsObjC.Tables[0].Rows[0]["CoverNoteNo"].ToString() : ":";
                    txtParticular.Value = (dsObjC.Tables[0].Rows[0]["Remarks"] != DBNull.Value) ?
                                                        ": " + dsObjC.Tables[0].Rows[0]["Remarks"].ToString() : ":";
                    txtsuminsured.Value = (dsObjC.Tables[0].Rows[0]["SumInsuredAmount"] != DBNull.Value) ?
                                                       ": " + dsObjC.Tables[0].Rows[0]["SumInsuredAmount"].ToString() : ": AS PER PLACEMENT SLIP";
                    if (dsObjC.Tables[0].Rows[0]["PremiumBase"] != DBNull.Value && dsObjC.Tables[0].Rows[0]["PremiumBase"].ToString() == "R")
                    {
                        txtRates.Value = ": "+ Convert.ToString(dsObjC.Tables[0].Rows[0]["Rate"]);
                    }
                    else
                    {
                        txtRates.Value = ": " + "AS PER PLACEMENT SLIP";
                    }
                   
                    if (dsObjC.Tables[0].Rows[0]["POIToDate"].ToString() == null || dsObjC.Tables[0].Rows[0]["POIToDate"].ToString() == "")
                    {
                        txtpolicyfrom.Visible = false;
                        txtpolicyto.Visible = false;
                    }
                    else
                    {
                        txtpolicyfrom.Value = ": " + dsObjC.Tables[0].Rows[0]["POIFromDate"].ToString();
                        txtpolicyto.Value =  dsObjC.Tables[0].Rows[0]["POIToDate"].ToString();
                    }
                    txtClassInsurance.Value = (dsObjC.Tables[0].Rows[0]["SubClassName"] != DBNull.Value) ?
                                                 ": " + dsObjC.Tables[0].Rows[0]["SubClassName"].ToString() : ":";
                    txtBillingParty.Value = (dsObjC.Tables[0].Rows[0]["Billing Party"] != DBNull.Value) ?
                                                        ": " + dsObjC.Tables[0].Rows[0]["Billing Party"].ToString() : ":";
                    textBox46.Value = (dsObjC.Tables[0].Rows[0]["PLUS GST"] != DBNull.Value && Convert.ToInt32(dsObjC.Tables[0].Rows[0]["PLUS GST"]) != 0.0) ?
                                                          dsObjC.Tables[0].Rows[0]["PLUS GST"].ToString() +"%" : "0.00%";
                    textBox74.Value = (dsObjC.Tables[0].Rows[0]["BROKERAGE PER"] != DBNull.Value &&  Convert.ToInt32(dsObjC.Tables[0].Rows[0]["BROKERAGE PER"])!=0) ?
                                                          dsObjC.Tables[0].Rows[0]["BROKERAGE PER"].ToString() + "%" : "0.00%";
                    textBox81.Value = (dsObjC.Tables[0].Rows[0]["BROKERAGE GST"] != DBNull.Value &&  Convert.ToInt32(dsObjC.Tables[0].Rows[0]["BROKERAGE GST"])!=0.0) ?
                                                        dsObjC.Tables[0].Rows[0]["BROKERAGE GST"].ToString() + "%" : "0.00%";
                    if (dsObjC.Tables[5].Rows.Count == 0)
                    {
                        panel1.Visible = false;
                        table2.Visible = false;
                        tblBrokerageDetail.Location = table2.Location;
                        DataTable dtBrokDetail = new DataTable();
                        dtBrokDetail.Columns.Add("Col1");
                        dtBrokDetail.Columns.Add("Col2");
                        dtBrokDetail.Columns.Add("Col3");

                        DataRow objDataRow = dtBrokDetail.NewRow();
                   
                        textBox41.Value = (dsObjC.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value) ?
                                                dsObjC.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() : "";
                        objDataRow = dtBrokDetail.NewRow();
                        decimal GROSSPREMIUMP = (dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"] != DBNull.Value) ?
                                                Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()) : Convert.ToDecimal(0.00);

                        objDataRow["Col1"] = "GROSS PREMIUM";
                        objDataRow["Col2"] = "";
                        objDataRow["Col3"] = ConvertIntoNumeric(GROSSPREMIUMP);                      
                        dtBrokDetail.Rows.Add(objDataRow);

                        objDataRow = dtBrokDetail.NewRow();
                        objDataRow["Col1"] = "PLUS GST";
                        objDataRow["Col2"] = (dsObjC.Tables[0].Rows[0]["PLUS GST"] != DBNull.Value && Convert.ToInt32(dsObjC.Tables[0].Rows[0]["PLUS GST"]) != 0.0) ?
                                                          dsObjC.Tables[0].Rows[0]["PLUS GST"].ToString() + "%" : "0.00%";
                        decimal GST = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value) ?
                                              Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()) : Convert.ToDecimal("0.00"));
                        objDataRow["Col3"] = ConvertIntoNumeric(GST);
                        dtBrokDetail.Rows.Add(objDataRow);

                        objDataRow = dtBrokDetail.NewRow();
                        objDataRow["Col1"] = "STAMP DUTY";
                        objDataRow["Col2"] = "";
                        objDataRow["Col3"] = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["StampDuty"] != DBNull.Value) ?
                                                dsObjC.Tables[0].Rows[0]["StampDuty"].ToString() : "0.00"));                       
                        dtBrokDetail.Rows.Add(objDataRow);

                        decimal TotalAmountValue = (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()) +
                                        Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["StampDuty"].ToString())) +
                                        (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()));
                        objDataRow = dtBrokDetail.NewRow();
                        objDataRow["Col1"] = "TOTAL AMOUNT";
                        objDataRow["Col2"] = "";
                        objDataRow["Col3"] = ConvertIntoNumeric(Convert.ToDecimal(TotalAmountValue));
                        dtBrokDetail.Rows.Add(objDataRow);

                        objDataRow = dtBrokDetail.NewRow();
                        objDataRow["Col1"] = "BROKERAGE";
                        objDataRow["Col2"] = (dsObjC.Tables[0].Rows[0]["BROKERAGE PER"] != DBNull.Value && Convert.ToInt32(dsObjC.Tables[0].Rows[0]["BROKERAGE PER"]) != 0) ?
                                                          dsObjC.Tables[0].Rows[0]["BROKERAGE PER"].ToString() + "%" : "0.00%";
                        decimal BROKERAGEFROMINSURER = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[0].Rows[0]["Brokerage"].ToString() : "0.00");
                        objDataRow["Col3"] = ConvertIntoNumeric(BROKERAGEFROMINSURER);
                        dtBrokDetail.Rows.Add(objDataRow);

                        objDataRow = dtBrokDetail.NewRow();
                        objDataRow["Col1"] = "GST ON BROKERAGE";
                        objDataRow["Col2"] = (dsObjC.Tables[0].Rows[0]["BROKERAGE GST"] != DBNull.Value && Convert.ToInt32(dsObjC.Tables[0].Rows[0]["BROKERAGE GST"]) != 0.0) ?
                                                        dsObjC.Tables[0].Rows[0]["BROKERAGE GST"].ToString() + "%" : "0.00%";
                        decimal GSTONBROKERAGE = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"] != DBNull.Value) ?
                                              dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"].ToString() : "0.00");
                        objDataRow["Col3"] = ConvertIntoNumeric(GSTONBROKERAGE);
                        dtBrokDetail.Rows.Add(objDataRow);

                        objDataRow = dtBrokDetail.NewRow();
                        //decimal NetPremium = (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()) +
                        //                    Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString())) -
                        //                    (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["Brokerage"].ToString()) +
                        //                    Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"].ToString())); 
                        decimal NetPremium = (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()) +
                                       Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["StampDuty"].ToString()) +
                                       Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()))-
                                        (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["Brokerage"].ToString())) -
                                           (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"].ToString()));
                        textBox34.Value = ConvertIntoNumeric(Convert.ToDecimal(NetPremium));
                       
                        tblBrokerageDetail.DataSource = dtBrokDetail;                        
                    }
                }
                //Values from Table 2
                if (dsObjC.Tables[2].Rows.Count > 0)
                {
                    txtCompanyName.Value = txtCompanyName.Value = Convert.ToString(dsObjC.Tables[2].Rows[0]["TopCompanyName"]).ToUpper();
                    txtCompanyAddress.Value = dsObjC.Tables[2].Rows[0]["TopCompanyAddress"].ToString();
                }
                 if (dsObjC.Tables[4].Rows.Count > 0)
                {

                    DataView dvUw = new DataView(dsObjC.Tables[4]);
                    dvUw.RowFilter = "UwCode = '" + strClientCode +"'";
                    txtShare.Value = (dvUw.ToTable().Rows[0]["UWShare"] != DBNull.Value) ?
                                                     ": " + dvUw.ToTable().Rows[0]["UWShare"].ToString() : " :";
                    txtInsured.Value = (dvUw.ToTable().Rows[0]["UnderwriterName"] != DBNull.Value) ?
                                                         dvUw.ToTable().Rows[0]["UnderwriterName"].ToString() : "";
                    txtInsuredAddress1.Value = (dvUw.ToTable().Rows[0]["CorrAddress1"] != DBNull.Value) ?
                                                      dvUw.ToTable().Rows[0]["CorrAddress1"].ToString() : "";
                    txtInsuredAddress2.Value = (dvUw.ToTable().Rows[0]["CorrAddress2"] != DBNull.Value) ?
                                                     dvUw.ToTable().Rows[0]["CorrAddress2"].ToString() : "";
                    txtInsuredAddress3.Value = (dvUw.ToTable().Rows[0]["CorrAddress3"] != DBNull.Value) ?
                                                  dvUw.ToTable().Rows[0]["CorrAddress3"].ToString() : "";
                }
                
                // Values from Table 5 from Proc
                if (dsObjC.Tables[5].Rows.Count > 0)
                {

                    txtDate1.Value = (dsObjC.Tables[5].Rows[0]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[0]["DueDate"].ToString() : "";
                    txtInsta1.Value = "INSTAL.1";

                    txtCurr1.Value = textBox17.Value = (dsObjC.Tables[5].Rows[0]["Currency"] != DBNull.Value) ?
                                   dsObjC.Tables[5].Rows[0]["Currency"].ToString() : "";
                    txtGross1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["Premium"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["Premium"].ToString() : "0.00"));
                    TotalPremium = Convert.ToDecimal(txtGross1.Value);
                    txtGST1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["InsurerGSTAmount"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["InsurerGSTAmount"].ToString() : "0.00"));
                    TotalPlusGst = Convert.ToDecimal(txtGST1.Value);
                    txtStampDuty1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[0]["StampDuty"].ToString() : "0.00"));
                    TotalStampDuty = Convert.ToDecimal(txtStampDuty1.Value);

                    txtTotal1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["TotalPremiumClosing"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["TotalPremiumClosing"].ToString() : "0.00"));

                   //string Total1 = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["Total"] != DBNull.Value) ?
                   //                   dsObjC.Tables[5].Rows[0]["Total"].ToString() : "0.00"));

                   TotalAmount = Convert.ToDecimal(txtTotal1.Value);
                    txtBrokerage1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[0]["Brokerage"].ToString() : "0.00"));
                    TotalBrokerage = Convert.ToDecimal(txtBrokerage1.Value);
                    txtBrokerageGST1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["GSTBrokerageAmt"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["GSTBrokerageAmt"].ToString() : "0.00"));
                    TotalGstBrokerage = Convert.ToDecimal(txtBrokerageGST1.Value);

                    txtNetPremuim1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["NetClosingPremuim"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["NetClosingPremuim"].ToString() : "0.00"));
                    TotalNetPremium = Convert.ToDecimal(txtNetPremuim1.Value);
                    tblBrokerageDetail.Visible = false;

                }
                if (dsObjC.Tables[5].Rows.Count > 1)
                {
                    txtDate2.Value = (dsObjC.Tables[5].Rows[1]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["DueDate"].ToString() : "";
                    txtInsta2.Value = "INSTAL.2";

                    txtCurr2.Value = textBox17.Value = (dsObjC.Tables[5].Rows[1]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[1]["Currency"].ToString() : "";
                    txtGross2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[1]["Premium"].ToString() : "0.00"));
                    TotalPremium += Convert.ToDecimal(txtGross2.Value);
                    txtGST2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["InsurerGSTAmount"].ToString() : "0.00"));
                    TotalPlusGst+= Convert.ToDecimal(txtGST2.Value);
                    txtStampDuty2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[1]["StampDuty"].ToString() : "0.00"));
                    TotalStampDuty += Convert.ToDecimal(txtStampDuty2.Value);
                    txtTotal2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["TotalPremiumClosing"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["TotalPremiumClosing"].ToString() : "0.00"));


                   //string Total2 = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Total"] != DBNull.Value) ?
                   //               dsObjC.Tables[5].Rows[1]["Total"].ToString() : "0.00"));
                   TotalAmount += Convert.ToDecimal(txtTotal2.Value);
                    txtBrokerage2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[1]["Brokerage"].ToString() : "0.00"));
                    TotalBrokerage += Convert.ToDecimal(txtBrokerage2.Value);
                    txtBrokerageGST2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[1]["GSTBrokerageAmt"].ToString() : "0.00"));
                    TotalGstBrokerage += Convert.ToDecimal(txtBrokerageGST2.Value);
                    txtNetPremuim2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["NetClosingPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[1]["NetClosingPremuim"].ToString() : "0.00"));
                    TotalNetPremium += Convert.ToDecimal(txtNetPremuim2.Value);
                    tblBrokerageDetail.Visible = false;
                }
                if (dsObjC.Tables[5].Rows.Count > 2)
                {
                    txtDate3.Value = (dsObjC.Tables[5].Rows[2]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[2]["DueDate"].ToString() : "";
                    txtInsta3.Value = "INSTAL.3";

                    txtCurr3.Value = textBox17.Value = (dsObjC.Tables[5].Rows[2]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[2]["Currency"].ToString() : "";
                    txtGross3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[2]["Premium"].ToString() : "0.00"));
                    TotalPremium += Convert.ToDecimal(txtGross3.Value);
                    txtGST3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[2]["InsurerGSTAmount"].ToString() : "0.00"));
                    TotalPlusGst += Convert.ToDecimal(txtGST3.Value);
                    txtStampDuty3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[2]["StampDuty"].ToString() : "0.00"));
                    TotalStampDuty += Convert.ToDecimal(txtStampDuty3.Value);
                    txtTotal3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["TotalPremiumClosing"] != DBNull.Value) ?
                                                         dsObjC.Tables[5].Rows[2]["TotalPremiumClosing"].ToString() : "0.00"));

                    //string Total3 = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Total"] != DBNull.Value) ?
                    //                  dsObjC.Tables[5].Rows[2]["Total"].ToString() : "0.00"));


                    TotalAmount += Convert.ToDecimal(txtTotal3.Value);
                    txtBrokerage3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[2]["Brokerage"].ToString() : "0.00"));
                    TotalBrokerage += Convert.ToDecimal(txtBrokerage3.Value);
                    txtBrokerageGST3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[2]["GSTBrokerageAmt"].ToString() : "0.00"));
                    TotalGstBrokerage += Convert.ToDecimal(txtBrokerageGST3.Value);
                    txtNetPremuim3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["NetClosingPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[2]["NetClosingPremuim"].ToString() : "0.00"));
                    TotalNetPremium += Convert.ToDecimal(txtNetPremuim3.Value);
                    tblBrokerageDetail.Visible = false;
                }
                if (dsObjC.Tables[5].Rows.Count > 3)
                {
                    txtDate4.Value = (dsObjC.Tables[5].Rows[3]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["DueDate"].ToString() : "";
                    txtInsta4.Value = "INSTAL.4";

                    txtCurr4.Value = textBox17.Value = (dsObjC.Tables[5].Rows[3]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[3]["Currency"].ToString() : "";
                    txtGross4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[3]["Premium"].ToString() : "0.00"));
                    TotalPremium += Convert.ToDecimal(txtGross4.Value);
                    txtGST4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["InsurerGSTAmount"].ToString() : "0.00"));
                    TotalPlusGst += Convert.ToDecimal(txtGST4.Value);
                    txtStampDuty4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[3]["StampDuty"].ToString() : "0.00"));
                    TotalStampDuty += Convert.ToDecimal(txtStampDuty4.Value);
                    txtTotal4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["TotalPremiumClosing"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["TotalPremiumClosing"].ToString() : "0.00"));


                   //string  Total4 = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Total"] != DBNull.Value) ?
                   //                   dsObjC.Tables[5].Rows[3]["Total"].ToString() : "0.00"));
                   TotalAmount += Convert.ToDecimal(txtTotal4.Value);
                    txtBrokerage4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[3]["Brokerage"].ToString() : "0.00"));
                    TotalBrokerage += Convert.ToDecimal(txtBrokerage4.Value);
                    txtBrokerageGST4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[3]["GSTBrokerageAmt"].ToString() : "0.00"));
                    TotalGstBrokerage += Convert.ToDecimal(txtBrokerageGST3.Value);
                    txtNetPremuim4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["NetClosingPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[3]["NetClosingPremuim"].ToString() : "0.00"));
                    TotalNetPremium += Convert.ToDecimal(txtNetPremuim4.Value);
                    tblBrokerageDetail.Visible = false;
                }
                textBox40.Value =Convert.ToString(TotalPremium.ToString("N2"));
                textBox47.Value = Convert.ToString(TotalPlusGst.ToString("N2"));
                textBox8.Value = Convert.ToString(TotalStampDuty.ToString("N2"));
                textBox14.Value = Convert.ToString(TotalAmount.ToString("N2"));
                textBox75.Value = Convert.ToString(TotalBrokerage.ToString("N2"));
                textBox82.Value = Convert.ToString(TotalGstBrokerage.ToString("N2"));
                textBox89.Value = Convert.ToString(TotalNetPremium.ToString("N2"));
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