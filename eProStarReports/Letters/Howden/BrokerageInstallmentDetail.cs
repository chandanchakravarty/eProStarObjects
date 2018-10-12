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
    public partial class BrokerageInstallmentDetail : Telerik.Reporting.Report
    {
        public BrokerageInstallmentDetail()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BrokerageInstallmentDetail(DataSet dsObjC, string strClientCode)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            // added for #23256 --begin
            foreach (DataRow row in dsObjC.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            //txtTextDN.Value = "DEBIT NOTE :";

            if (dsObjC.Tables.Count > 0)
            {
                // Values from Table 5 from Proc
                if (dsObjC.Tables[5].Rows.Count > 0)
                {
                    if (dsObjC.Tables[0].Rows.Count > 0)
                    {
                        if (dsObjC.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                            txtCoverNoteNo.Value = dsObjC.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                        if (dsObjC.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value)
                            txtDate.Value = dsObjC.Tables[0].Rows[0]["DebitNotedate"].ToString();
                    }

                    txtDate1.Value = (dsObjC.Tables[5].Rows[0]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[0]["DueDate"].ToString() : "";
                    txtInsta1.Value = "INSTAL.1";
                    txtDebitNote1.Value = (dsObjC.Tables[5].Rows[0]["DebitNoteNo"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[0]["DebitNoteNo"].ToString() : "";
                    txtCurr1.Value = (dsObjC.Tables[5].Rows[0]["Currency"] != DBNull.Value) ?
                                   dsObjC.Tables[5].Rows[0]["Currency"].ToString() : "";
                    txtGross1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["Premium"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["Premium"].ToString() : "0.00"));
                    txtGST1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[0]["InsurerGSTAmount"].ToString() : "0.00"));
                    txtStampDuty1.Value =ConvertIntoNumeric(Convert.ToDecimal( (dsObjC.Tables[5].Rows[0]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[0]["StampDuty"].ToString() : "0.00"));
                    txtTotal1.Value =ConvertIntoNumeric(Convert.ToDecimal( (dsObjC.Tables[5].Rows[0]["Total"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[0]["Total"].ToString() : "0.00"));
                    txtDiscount1.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["discount"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[0]["discount"].ToString() : "0.00"));
                    txtBrokerage1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[0]["Brokerage"].ToString() : "0.00"));
                    txtBrokerageGST1.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["GSTBrokerageAmt"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["GSTBrokerageAmt"].ToString() : "0.00"));
                    txtNetPremuim1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["NetPremuim"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["NetPremuim"].ToString() : "0.00"));
                    txtNetBrok1.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[0]["NetBrokerage"] != DBNull.Value) ?
                                     dsObjC.Tables[5].Rows[0]["NetBrokerage"].ToString() : "0.00"));
                }
                if (dsObjC.Tables[5].Rows.Count > 1)
                {
                    txtDate2.Value = (dsObjC.Tables[5].Rows[1]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["DueDate"].ToString() : "";
                    txtInsta2.Value = "INSTAL.2";
                    txtDebitNote2.Value = (dsObjC.Tables[5].Rows[1]["DebitNoteNo"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[1]["DebitNoteNo"].ToString() : "";
                    txtCurr2.Value = (dsObjC.Tables[5].Rows[1]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[1]["Currency"].ToString() : "";
                    txtGross2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[1]["Premium"].ToString() : "0.00")) ;
                    txtGST2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["InsurerGSTAmount"].ToString() : "0.00"));
                    txtStampDuty2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[1]["StampDuty"].ToString() :  "0.00"));
                    txtTotal2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Total"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[1]["Total"].ToString() :  "0.00"));
                    txtDiscount2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["discount"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[1]["discount"].ToString() :  "0.00"));
                    txtBrokerage2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[1]["Brokerage"].ToString() : "0.00"));
                    txtBrokerageGST2.Value =ConvertIntoNumeric(Convert.ToDecimal( (dsObjC.Tables[5].Rows[1]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[1]["GSTBrokerageAmt"].ToString() :  "0.00"));
                    txtNetPremuim2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["NetPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[1]["NetPremuim"].ToString() : "0.00"));
                    txtNetBrok2.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[1]["NetBrokerage"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[1]["NetBrokerage"].ToString() : "0.00"));
                }
                if (dsObjC.Tables[5].Rows.Count > 2)
                {
                    txtDate3.Value = (dsObjC.Tables[5].Rows[2]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[2]["DueDate"].ToString() : "";
                    txtInsta3.Value = "INSTAL.3";
                    txtDebitNote3.Value = (dsObjC.Tables[5].Rows[2]["DebitNoteNo"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[2]["DebitNoteNo"].ToString() : "";
                    txtCurr3.Value = (dsObjC.Tables[5].Rows[2]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[2]["Currency"].ToString() : "";
                    txtGross3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[2]["Premium"].ToString() : "0.00"));
                    txtGST3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[2]["InsurerGSTAmount"].ToString() : "0.00"));
                    txtStampDuty3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[2]["StampDuty"].ToString() : "0.00"));
                    txtTotal3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Total"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[2]["Total"].ToString() : "0.00"));
                    txtDiscount3.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["discount"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[2]["discount"].ToString() :"0.00"));
                    txtBrokerage3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[2]["Brokerage"].ToString() : "0.00"));
                    txtBrokerageGST3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[2]["GSTBrokerageAmt"].ToString() : "0.00"));
                    txtNetPremuim3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["NetPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[2]["NetPremuim"].ToString() : "0.00"));
                    txtNetBrok3.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[2]["NetBrokerage"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[2]["NetBrokerage"].ToString() : "0.00"));
                }
                if (dsObjC.Tables[5].Rows.Count > 3)
                {
                    txtDate4.Value = (dsObjC.Tables[5].Rows[3]["DueDate"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["DueDate"].ToString() : "";
                    txtInsta4.Value = "INSTAL.4";
                    txtDebitNote4.Value = (dsObjC.Tables[5].Rows[3]["DebitNoteNo"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[3]["DebitNoteNo"].ToString() : "";
                    txtCurr4.Value = (dsObjC.Tables[5].Rows[3]["Currency"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[3]["Currency"].ToString() : "";
                    txtGross4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Premium"] != DBNull.Value) ?
                                        dsObjC.Tables[5].Rows[3]["Premium"].ToString() : "0.00"));
                    txtGST4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["InsurerGSTAmount"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["InsurerGSTAmount"].ToString() :  "0.00"));
                    txtStampDuty4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["StampDuty"] != DBNull.Value) ?
                                          dsObjC.Tables[5].Rows[3]["StampDuty"].ToString() :  "0.00"));
                    txtTotal4.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Total"] != DBNull.Value) ?
                                      dsObjC.Tables[5].Rows[3]["Total"].ToString() :  "0.00"));
                    txtDiscount4.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["discount"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[3]["discount"].ToString() : "0.00"));
                    txtBrokerage4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["Brokerage"] != DBNull.Value) ?
                                            dsObjC.Tables[5].Rows[3]["Brokerage"].ToString() : "0.00"));
                    txtBrokerageGST4.Value =ConvertIntoNumeric( Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["GSTBrokerageAmt"] != DBNull.Value) ?
                                             dsObjC.Tables[5].Rows[3]["GSTBrokerageAmt"].ToString() :  "0.00"));
                    txtNetPremuim4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["NetPremuim"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[3]["NetPremuim"].ToString() : "0.00"));
                    txtNetBrok4.Value = ConvertIntoNumeric(Convert.ToDecimal((dsObjC.Tables[5].Rows[3]["NetBrokerage"] != DBNull.Value) ?
                                         dsObjC.Tables[5].Rows[3]["NetBrokerage"].ToString() : "0.00"));
                }

                if (dsObjC.Tables[0].Rows.Count > 0)
                {
                    txtType.Value = (dsObjC.Tables[0].Rows[0]["DebitNoteType"] != DBNull.Value) ?
                                              dsObjC.Tables[0].Rows[0]["DebitNoteType"].ToString() : "";
                    txtReinsurance.Value = (dsObjC.Tables[0].Rows[0]["Reinsurance"] != DBNull.Value) ?
                                         dsObjC.Tables[0].Rows[0]["Reinsurance"].ToString() : "";
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
    }
}