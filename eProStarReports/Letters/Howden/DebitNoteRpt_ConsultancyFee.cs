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
    internal partial class DebitNoteRpt_ConsultancyFee : Telerik.Reporting.Report
    {
        public DebitNoteRpt_ConsultancyFee()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public DebitNoteRpt_ConsultancyFee(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type)
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
                    textBox9.Visible = false;
                    textBox11.Visible = false;
                    textBox20.Visible = false;
                    // textBox21.Visible = false;
                }
                else
                {
                    txtClientName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString().ToUpper();
                    textBox9.Value = dsObj.Tables[0].Rows[0]["CorrAddress1"].ToString();
                    textBox11.Value = dsObj.Tables[0].Rows[0]["CorreAddress2"].ToString();
                    textBox20.Value = dsObj.Tables[0].Rows[0]["CorreAddress3"].ToString();
                    // textBox21.Value = dsObj.Tables[0].Rows[0]["CorrAddress4"].ToString();
                }
            }
            else
            {
                txtClientName.Value = (dsObj.Tables[2].Columns.Contains("ClientName") == true) ?
                    dsObj.Tables[2].Rows[0]["ClientName"].ToString().ToUpper() : "";
            }
            txtInvoiceNo.Value = dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
            txtInvoiceDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtDatePrinted.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtAccNo.Value = dsObj.Tables[0].Rows[0]["AccountNo"].ToString();


            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString().ToUpper();
                textBox3.Value = dsObj.Tables[1].Rows[0]["CompanyAdd1"].ToString();
                textBox22.Value = dsObj.Tables[1].Rows[0]["CompanyAdd2"].ToString();
                textBox4.Value = dsObj.Tables[1].Rows[0]["CompanyAdd3"].ToString();
                textBox7.Value = dsObj.Tables[1].Rows[0]["CompanyAdd4"].ToString();
                txtGstNumber.Value = dsObj.Tables[1].Rows[0]["GSTCode"].ToString();
            }
            //New Fields

            txtAttention.Value = dsObj.Tables[0].Rows[0]["Attention"].ToString().ToUpper();
            txtRemark.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
            txtExecutiveInCharge.Value = dsObj.Tables[0].Rows[0]["ExecutiveInCharge"].ToString();
            txtCompantInNotice.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString();

            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtInsured.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
                txtPolicyNo.Value = dsObj.Tables[2].Rows[0]["PolicyNo"].ToString();
                txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                txtEndNo.Value = dsObj.Tables[2].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[2].Rows[0]["POIToDate"].ToString();
                txtEffectiveFrom.Value = dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString();
                TxtEffectiveTo.Value = dsObj.Tables[2].Rows[0]["EffectiveDateTo"].ToString();
                TxtCrossRefence.Value = dsObj.Tables[2].Rows[0]["CrossReference"].ToString();
                if (dsObj.Tables[2].Columns.Contains("EndtInsurerNo") == true)      // added for #23642
                {
                    txtEndNo.Value = dsObj.Tables[2].Rows[0]["EndtInsurerNo"].ToString();
                }
            }


            if (dsObj.Tables[3].Rows.Count > 0)
            {
                txtCommisionPer.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"].ToString()).ToString("n2");
                txtCommision.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFee"].ToString()).ToString("n2");
                txtGstPer.Value = dsObj.Tables[3].Rows[0]["ServiceFeeGSTPer"].ToString();
                txtGstAmt.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["ServiceFeeGSTAmount"].ToString()).ToString("n2");
                txtTotalAmount.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["TotalDue"].ToString()).ToString("n2");
            }
            else
            {
                txtCommisionPer.Visible = false;
                txtCommision.Visible = false;
                txtGstPer.Visible = false;
                txtGstAmt.Visible = false;
                txtTotalAmount.Visible = false;
            }

        }
    }
}