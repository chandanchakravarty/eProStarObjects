namespace eProStarReports.Letters
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


        public DebitNoteRptGeneral_Invoice(DataSet dsObj, string strUWCode, string strCheckedInstl)
        {
           
            InitializeComponent();
      
            // Values from Client Table
            if (dsObj.Tables[0].Rows[0]["ClientName"].ToString() == null || dsObj.Tables[0].Rows[0]["ClientName"].ToString() == "")
            {
                txtClientName.Visible = false;
                txtClientAddr.Visible = false;
            }
            else
            {
                txtClientName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();
                txtClientAddr.Value = dsObj.Tables[0].Rows[0]["ClientAddress"].ToString();
            }
            txtInvoiceNo.Value = dsObj.Tables[0].Rows[0]["InvoiceNo"].ToString();
            txtInvoiceDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtDatePrinted.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
            txtAccNo.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();

            //Values from Table 1
            if (dsObj.Tables[1].Rows.Count > 0)
            {
                txtCompanyName.Value = dsObj.Tables[1].Rows[0]["CompanyName"].ToString();
                txtCompAddr.Value = dsObj.Tables[1].Rows[0]["CompanyAddress"].ToString();
                txtGstNumber.Value = dsObj.Tables[1].Rows[0]["GSTCode"].ToString();
            }
            //Values from Table 2
            if (dsObj.Tables[2].Rows.Count > 0)
            {
                txtInsured.Value = dsObj.Tables[2].Rows[0]["ClientName"].ToString();
                if (txtTotalBrokerage.Value != null || txtTotalBrokerage.Value !="")
                {
                    txtSubClass.Visible = false;
                }
                else
                {
                    txtSubClass.Value = dsObj.Tables[2].Rows[0]["SubClassName"].ToString();
                   
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
                if (txtTotalBrokerage.Value != null)
                {
                    txtTotalBrokerage.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["TotalPremAmount"].ToString()).ToString("n2");
                }
                else
                {
                    txtTotalBrokerage.Visible = false;
                }
                txtGrossPrm.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["Brokerage"].ToString()).ToString("n2");
                txtCommisionPer.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["BrokerageRate"].ToString()).ToString("n2");
                txtCommision.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["Brokerage"].ToString()).ToString("n2");
                txtGstPer.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["BrokerGST"].ToString()).ToString("n2");
                txtGstAmt.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["BrokerGSTAmount"].ToString()).ToString("n2");
                txtTotalAmount.Value = Convert.ToDecimal(dsObj.Tables[3].Rows[0]["TotalAmount"].ToString()).ToString("n2");
            }
            else
            {
                txtTotalBrokerage.Visible = false;
                txtGrossPrm.Visible = false;
                txtCommisionPer.Visible = false;
                txtCommision.Visible = false;
                txtGstPer.Visible = false;
                txtGstAmt.Visible = false;
                txtTotalAmount.Visible = false;
            }
 
        }
    }
}