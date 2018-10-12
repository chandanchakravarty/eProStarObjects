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


        public DebitNoteRptCommision_Invoice(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type, DataTable _taxType = null)
        {
            InitializeComponent();

            // added for #23256 --begin
            textBox1.Value = (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST") ? "DEBIT NOTE" : "TAX INVOICE NOTE";//_taxType.ToUpper() == "SST" ? "CREDIT NOTE" : "TAX CREDIT NOTE";
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
                //txtGstNumber.Value = dsObj.Tables[1].Rows[0]["GSTCode"].ToString();
            }
            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtClientName.Value = dsObj.Tables[2].Rows[0]["ClientName"].ToString().ToUpper();
                if (_taxType.Rows.Count > 0 && _taxType.Rows[0]["TaxType"] != null && _taxType.Rows[0]["TaxType"].ToString() == "SST")
                {
                    txtGstNumber.Visible = false;
                    textBox5.Visible = false;
                    textBox54.Visible = false;
                    txtGstPer.Visible = false;
                    txtGstAmt.Visible = false;
                }
                else
                {
                    txtGstNumber.Value = dsObj.Tables[2].Rows[0]["GSTCode"].ToString();
                }
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
                txtCommisionPer.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["BrokerageRate"].ToString()).ToString("n2");
                txtCommision.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["Brokerage"].ToString()).ToString("n2");
                txtGstPer.Value = dsObj.Tables[3].Rows[0]["BrokerGST"].ToString();
                txtGstAmt.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["BrokerGSTAmount"].ToString()).ToString("n2");
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