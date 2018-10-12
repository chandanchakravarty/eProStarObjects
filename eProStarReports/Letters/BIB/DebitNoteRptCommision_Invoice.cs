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
    /// Summary description for Report1.
    /// </summary>
    internal partial class DebitNoteRptCommision_Invoice : Telerik.Reporting.Report
    {
        public DebitNoteRptCommision_Invoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public DebitNoteRptCommision_Invoice(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type)
        {
            InitializeComponent();

            // added for #23256 --begin
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            if (dsObj.Tables[0].Columns.Contains("ClientName") == true)      // added for #23642
            {
                // Values from Client Table
                if (dsObj.Tables[0].Rows[0]["ClientName"].ToString() == null || dsObj.Tables[0].Rows[0]["ClientName"].ToString() == "")
                {
                    txtClientName.Visible = false;
                    textBox23.Visible = false;
                    textBox24.Visible = false;
                    textBox26.Visible = false;
                    textBox31.Visible = false;
                }
                else
                {
                    txtClientName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString().ToUpper();
                    textBox23.Value = dsObj.Tables[0].Rows[0]["CorrAddress1"].ToString();
                    textBox24.Value = dsObj.Tables[0].Rows[0]["CorreAddress2"].ToString();
                    textBox26.Value = dsObj.Tables[0].Rows[0]["CorreAddress3"].ToString();
                    textBox31.Value = dsObj.Tables[0].Rows[0]["CorrAddress4"].ToString();
                }
            }
            txtInvoiceNo.Value = dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
            txtInvoiceDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtDatePrinted.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtAccNo.Value = dsObj.Tables[0].Rows[0]["AccountNo"].ToString();
            //New feilds
            txtAttention.Value = dsObj.Tables[0].Rows[0]["Attention"].ToString().ToUpper();
            txtRemark.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
            txtExecutive.Value = dsObj.Tables[0].Rows[0]["ExecutiveInCharge"].ToString();
            txtCompanyInNotice.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString().ToUpper();
            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString().ToUpper();
                textBox7.Value = dsObj.Tables[1].Rows[0]["CompanyAdd1"].ToString();
                textBox22.Value = dsObj.Tables[1].Rows[0]["CompanyAdd2"].ToString();
                textBox11.Value = dsObj.Tables[1].Rows[0]["CompanyAdd3"].ToString();
                textBox21.Value = dsObj.Tables[1].Rows[0]["CompanyAdd4"].ToString();
                txtGstNumber.Value = dsObj.Tables[1].Rows[0]["GSTCode"].ToString();
            }
            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtInsured.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
               // txtInsured1.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
                //if (txtSubClass.Value != null || txtSubClass.Value != "")
                //{
                //    txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                  
                //}
                //else
                //{
                //    txtSubClass.Visible = false;
                   
                //}
                txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                //txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["POIFromDate"].ToString();
                //txtPOITo.Value = dsObj.Tables[2].Rows[0]["POIToDate"].ToString();
                txtEffectiveFrom.Value = dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString();
                TxtEffectiveTo.Value = dsObj.Tables[2].Rows[0]["EffectiveDateTo"].ToString();
                TxtCrossRefence.Value = dsObj.Tables[2].Rows[0]["CrossReference"].ToString();
                txtPolicyNo.Value = dsObj.Tables[2].Rows[0]["PolicyNo"].ToString();

                if (dsObj.Tables[2].Columns.Contains("EndtInsurerNo") == true)      // added for #23642
                {
                    txtEndorsementNo.Value = dsObj.Tables[2].Rows[0]["EndtInsurerNo"].ToString();
                }
            }

            //Values from table 3
            if (dsObj.Tables[3].Rows.Count > 0)
            {
                // added for #23642
                if (dsObj.Tables[3].Columns.Contains("ServiceFee") == true) txtCommision.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"].ToString()).ToString("n2");
                if (dsObj.Tables[3].Columns.Contains("ServiceFeeGSTPer") == true) txtGstPer.Value = dsObj.Tables[3].Rows[0]["ServiceFeeGSTPer"].ToString();
                if (dsObj.Tables[3].Columns.Contains("ServiceFeeGSTAmount") == true) txtGstAmt.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString()).ToString("n2");
                if (dsObj.Tables[3].Columns.Contains("TotalDue") == true) txtTotalAmount.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["TotalDue"].ToString()).ToString("n2");
                if (dsObj.Tables[3].Columns.Contains("OtherCharges") == true) txtOtherCharge.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["OtherCharges"].ToString()).ToString("n2");

                if (dsObj.Tables[3].Columns.Contains("ServiceFeeTypeValue") == true) textBox53.Value = (dsObj.Tables[3].Rows[0]["ServiceFeeTypeValue"].ToString()) == "0" ? "CONSULTANCY FEE" : (dsObj.Tables[3].Rows[0]["ServiceFeeTypeValue"].ToString().ToUpper());
                if (dsObj.Tables[3].Columns.Contains("ServiceFeeTypeValue") == true) textBox56.Value = (dsObj.Tables[3].Rows[0]["OtherChargeTypeValue"].ToString()) == "0" ? "OTHER CHARGES" : (dsObj.Tables[3].Rows[0]["OtherChargeTypeValue"].ToString().ToUpper());
               
            }
            else
            {
                txtCommision.Visible = false;
                txtGstPer.Visible = false;
                txtGstAmt.Visible = false;
                txtTotalAmount.Visible = false;
                txtOtherCharge.Visible = false;
            }

 
        }
    }
}