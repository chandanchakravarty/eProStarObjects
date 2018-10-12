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
    internal partial class DebitNoteRptGeneral_Invoice : Telerik.Reporting.Report
    {
        public DebitNoteRptGeneral_Invoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public DebitNoteRptGeneral_Invoice(DataSet dsObj, string CaseRefNo, string DebitNoteNo, string Type)
        {
           
            InitializeComponent();

            // added for #23256 --begin
            foreach (DataRow row in dsObj.Tables["LogoInformation"].Rows)
            {
                picBox1.Visible = row["PrintCompLogo"].ToString() == "Yes" ? true : false;
            }
            // added for #23256 --end

            // Values from Client Table
            if (dsObj.Tables[0].Rows[0]["InsurerName"].ToString() == null || dsObj.Tables[0].Rows[0]["InsurerName"].ToString() == "")
            {
                txtClientName.Visible = false;
                txtClientAddr.Visible = false;
            }
            else
            {
                if (dsObj.Tables[0].Rows[0]["InsurerName"] != DBNull.Value)
                txtClientName.Value = dsObj.Tables[0].Rows[0]["InsurerName"].ToString();
                if (dsObj.Tables[0].Columns.Contains("InsurerAddress"))
                {
                if (dsObj.Tables[0].Rows[0]["InsurerAddress"] != DBNull.Value)
                txtClientAddr.Value = dsObj.Tables[0].Rows[0]["InsurerAddress"].ToString();
                }
            }
            txtInvoiceNo.Value = dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
            txtInvoiceDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtDatePrinted.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtAccNo.Value = dsObj.Tables[0].Rows[0]["AccountNo"].ToString();

            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString();
                if (dsObj.Tables[0].Columns.Contains("CompanyAddress"))
                {
                    if (dsObj.Tables[0].Rows[0]["CompanyAddress"] != DBNull.Value)
                    txtCompAddr.Value = dsObj.Tables[1].Rows[0]["CompanyAddress"].ToString();
                }
                txtGstNumber.Value = dsObj.Tables[1].Rows[0]["GSTCode"].ToString();
            }
            //New Fields

            txtAttention.Value = dsObj.Tables[0].Rows[0]["Attention"].ToString();
            txtRemark.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();
            txtExecutiveInCharge.Value = dsObj.Tables[0].Rows[0]["ExecutiveInCharge"].ToString();
            txtCompantInNotice.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString();
           
            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtInsured.Value = dsObj.Tables[2].Rows[0]["Insured"].ToString();
                if (txtSubClass.Value != null || txtSubClass.Value != "")
                {
                    txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                    
                }
                else
                {
                    txtSubClass.Visible = false;
                   
                }
                //txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                txtPOIFrom.Value = dsObj.Tables[2].Rows[0]["POIFromDate"].ToString();
                txtPOITo.Value = dsObj.Tables[2].Rows[0]["POIToDate"].ToString();
                txtEffectiveFrom.Value = dsObj.Tables[2].Rows[0]["EffectiveDateFrom"].ToString();
                TxtEffectiveTo.Value = dsObj.Tables[2].Rows[0]["EffectiveDateTo"].ToString();
                TxtCrossRefence.Value = dsObj.Tables[2].Rows[0]["CrossReference"].ToString();
            }

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