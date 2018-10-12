namespace eProStarReports.Letters.BIB
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for PremiumReport.
    /// </summary>
    internal partial class PremiumReport : Telerik.Reporting.Report
    {
        public PremiumReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public PremiumReport(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string PolicyFrom, string PolicyTo, string ClientCode, string ClientSource, string status)

         {
             InitializeComponent();
             table1.DataSource = dsObj.Tables[0];

             if (dsObj.Tables[1].Rows.Count > 0)
             {

                

                 if (dsObj.Tables[1].Rows[0]["SumGrossPremiumAmount"] != DBNull.Value) txtSumGrosspremium.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumGrossPremiumAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumTotalDue"] != DBNull.Value) txtNetSumDue.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumTotalDue"]));
                 if (dsObj.Tables[1].Rows[0]["SumBrokerage"] != DBNull.Value) txtSumBrokerage.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerage"])); 
                 if (dsObj.Tables[1].Rows[0]["SumBrokerGSTAmount"] != DBNull.Value) txtNetPremiumUnderwriter.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerGSTAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumConsultancy_Fee"] != DBNull.Value) txtSumConsultancyFee.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumConsultancy_Fee"])); 
                 if (dsObj.Tables[1].Rows[0]["SumComm_Inward"] != DBNull.Value) txtSumCommInward.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumComm_Inward"]));
                 if (dsObj.Tables[1].Rows[0]["SumBrokerageAgent"] != DBNull.Value) txtSumIntroducer.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerageAgent"]));
                 if (dsObj.Tables[1].Rows[0]["SumPolicyCharge"] != DBNull.Value) textBox30.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumPolicyCharge"]));
                 if (dsObj.Tables[1].Rows[0]["SumLodingByInsurerAmount"] != DBNull.Value) textBox2.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumLodingByInsurerAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumDiscountByInsurerAmount"] != DBNull.Value) textBox8.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumDiscountByInsurerAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumInsurerGSTAmount"] != DBNull.Value) textBox10.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumInsurerGSTAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumDiscount"] != DBNull.Value) textBox12.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumDiscount"]));
                 if (dsObj.Tables[1].Rows[0]["SumServiceFee"] != DBNull.Value) textBox14.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumServiceFee"]));
                 if (dsObj.Tables[1].Rows[0]["SumServiceFeeGSTAmount"] != DBNull.Value) textBox16.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumServiceFeeGSTAmount"]));
                 if (dsObj.Tables[1].Rows[0]["SumStampDuty"] != DBNull.Value) textBox18.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumStampDuty"]));
                 if (dsObj.Tables[1].Rows[0]["SumOtherCharges"] != DBNull.Value) textBox20.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumOtherCharges"]));
                 if (dsObj.Tables[1].Rows[0]["SumTotalPremium"] != DBNull.Value) textBox22.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumTotalPremium"]));

                 //txtSumGrosspremium.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumGrossPremiumAmount"]));
                 //  txtNetSumDue.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumTotalDue"]));
                 //  txtSumBrokerage.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerage"]));
                 //  txtNetPremiumUnderwriter.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerGSTAmount"]));

                 //  //Changed made according to ASAi Suggestion                
                 // // txtSumConsultancyFee.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumserviceFeeGst"]));
                 //  //txtSumCommInward.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerGSTAmount"]));

                 //  txtSumConsultancyFee.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumConsultancy_Fee"]));
                 //  txtSumCommInward.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumComm_Inward"]));

                 //  txtSumIntroducer.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerageAgent"]));

                 //  textBox30.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumPolicyCharge"]));
                 //  textBox2.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumLodingByInsurerAmount"]));
                 //  textBox8.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumDiscountByInsurerAmount"]));
                 //  textBox10.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumInsurerGSTAmount"]));
                 //  textBox12.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumDiscount"]));
                 //  textBox14.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumServiceFee"]));
                 //  textBox16.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumServiceFeeGSTAmount"]));
                 //  textBox18.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumStampDuty"]));
                 //  textBox20.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumOtherCharges"]));
                 //  //textBox20.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumOtherCharges"]));
                 ////Changed made according to ASAi Suggestion
                 //  //textBox22.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerage"]));
                 //  textBox22.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumTotalPremium"]));
                 //}
                  
                   //textBox20.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumOtherCharges"]));
                  // textBox22.Value = ConvertIntoNumeric(Convert.ToDecimal(dsObj.Tables[1].Rows[0]["SumBrokerage"]));
                     
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