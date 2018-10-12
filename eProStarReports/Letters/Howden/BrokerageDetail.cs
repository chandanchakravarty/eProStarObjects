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
    public partial class BrokerageDetail : Telerik.Reporting.Report
    {
        public BrokerageDetail()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public BrokerageDetail(DataSet dsObjC, string strClientCode)
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
                // Values from Table 0
                if (dsObjC.Tables[0].Rows.Count > 0)
                {
                    if (dsObjC.Tables[0].Rows[0]["CoverNoteNo"] != DBNull.Value)
                        txtCoverNoteNo.Value = dsObjC.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                    if (dsObjC.Tables[0].Rows[0]["DebitNotedate"] != DBNull.Value)
                        txtDate.Value = dsObjC.Tables[0].Rows[0]["DebitNotedate"].ToString();

                    DataTable dtBrokDetail = new DataTable();
                    dtBrokDetail.Columns.Add("Col1");
                    dtBrokDetail.Columns.Add("Col2");
                    dtBrokDetail.Columns.Add("Col3");

                    DataRow objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = "TOTAL";
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "DEBIT NOTE REF.";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = (dsObjC.Tables[0].Rows[0]["DebitNoteNo"] != DBNull.Value) ?
                                            dsObjC.Tables[0].Rows[0]["DebitNoteNo"].ToString() : "";
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "CURRENCY";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = (dsObjC.Tables[0].Rows[0]["SumInsuredCurrency"] != DBNull.Value) ?
                                            dsObjC.Tables[0].Rows[0]["SumInsuredCurrency"].ToString() : "";
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    decimal GROSSPREMIUMP = (dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"] != DBNull.Value) ?
                                            Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()) : Convert.ToDecimal(0.00);

                    objDataRow["Col1"] = "GROSS PREMIUM";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = ConvertIntoNumeric(GROSSPREMIUMP);
                   // ConvertIntoNumeric(Convert.ToDecimal(NetPremium));
                    dtBrokDetail.Rows.Add(objDataRow);
                   
                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "GST";
                    objDataRow["Col2"] = "";
                    decimal GST = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"] != DBNull.Value) ?
                                          Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString()) : Convert.ToDecimal("0.00"));
                    objDataRow["Col3"] = ConvertIntoNumeric(GST);
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "STAMP DUTY";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] =ConvertIntoNumeric(Convert.ToDecimal( (dsObjC.Tables[0].Rows[0]["StampDuty"] != DBNull.Value) ?
                                            dsObjC.Tables[0].Rows[0]["StampDuty"].ToString() : "0.00"));
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "DISCOUNT TO CLIENT";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] =ConvertIntoNumeric(Convert.ToDecimal( (dsObjC.Tables[0].Rows[0]["Discount"] != DBNull.Value) ?
                                            dsObjC.Tables[0].Rows[0]["Discount"].ToString() : "0.00"));
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "BROKERAGE FROM INSURER";
                    objDataRow["Col2"] = "";
                    decimal BROKERAGEFROMINSURER = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["Brokerage"] != DBNull.Value) ?
                                        dsObjC.Tables[0].Rows[0]["Brokerage"].ToString() : "0.00");
                    objDataRow["Col3"] = ConvertIntoNumeric(BROKERAGEFROMINSURER);
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "GST ON BROKERAGE";
                    objDataRow["Col2"] = "";
                    decimal GSTONBROKERAGE = Convert.ToDecimal((dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"] != DBNull.Value) ?
                                          dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"].ToString() : "0.00");
                    objDataRow["Col3"] = ConvertIntoNumeric(GSTONBROKERAGE);
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    decimal NetPremium = (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["GrossPremiumAmount"].ToString()) +
                                        Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["InsurerGSTAmount"].ToString())) -
                                        (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["Brokerage"].ToString()) +
                                        Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["BrokerGSTAmount"].ToString()));
                    objDataRow["Col1"] = "NETT PREMIUM (TO UNDERWRITER)";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = ConvertIntoNumeric(Convert.ToDecimal(NetPremium));
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    decimal brokerage = (Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["Brokerage"].ToString()) -
                                       Convert.ToDecimal(dsObjC.Tables[0].Rows[0]["Discount"].ToString()));
                    objDataRow["Col1"] = "NETT BROKERAGE";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = ConvertIntoNumeric(Convert.ToDecimal(brokerage));
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "CODE **";
                    objDataRow["Col2"] = "";
                    objDataRow["Col3"] = (dsObjC.Tables[0].Rows[0]["DebitNoteType"] != DBNull.Value) ?
                                          dsObjC.Tables[0].Rows[0]["DebitNoteType"].ToString() : "";
                    dtBrokDetail.Rows.Add(objDataRow);

                    objDataRow = dtBrokDetail.NewRow();
                    objDataRow["Col1"] = "REINSURANCE (YES OR NO)";
                    objDataRow["Col2"] = (dsObjC.Tables[0].Rows[0]["Reinsurance"] != DBNull.Value) ?
                                          dsObjC.Tables[0].Rows[0]["Reinsurance"].ToString() : "";
                    objDataRow["Col3"] = "";
                    dtBrokDetail.Rows.Add(objDataRow);

                    tblBrokerageDetail.DataSource = dtBrokDetail;
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