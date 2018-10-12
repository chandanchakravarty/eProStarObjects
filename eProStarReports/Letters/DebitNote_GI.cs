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
    /// Summary description for DebitNote_GI.
    /// </summary>
    public partial class DebitNote_GI : Telerik.Reporting.Report
    {
        public DebitNote_GI()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public DebitNote_GI(DataSet dsObj, string compName, string printlogo)
        {
            InitializeComponent();
            if (printlogo == "Y")
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtCompanyName.Value = compName;
                txtRefNo.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                txtIssuedDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
                txtDuedate.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                txtClientName.Value = dsObj.Tables[0].Rows[0]["Name"].ToString();
                txtClientAddr.Value = dsObj.Tables[0].Rows[0]["Address"].ToString().ToUpper();
                //txtComName.Value = dsObj.Tables[0].Rows[0]["TopCompanyName"].ToString().ToUpper();

                txtInsurerName.Value = dsObj.Tables[0].Rows[0]["UnderwriterName"].ToString();

                txtTypeOfIns.Value = dsObj.Tables[0].Rows[0]["TypeOfInsurance"].ToString();

                txtPolicyNo.Value = dsObj.Tables[0].Rows[0]["policyno"].ToString();
                txtEndtNo.Value = dsObj.Tables[0].Rows[0]["EndorsementNo"].ToString();
                txtPOI.Value = dsObj.Tables[0].Rows[0]["InsuredPeriod"].ToString();

                txtPremium.Value =  string.Format("{0:0,0.00}",Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalPremium"]));
                txtPremiumDue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["StampDuty"].ToString()));


                txtTax.Value =  string.Format("{0:0,0.00}",Convert.ToDouble(dsObj.Tables[0].Rows[0]["WHTAmount"].ToString()));

                txtVAT.Value =  string.Format("{0:0,0.00}",Convert.ToDouble(dsObj.Tables[0].Rows[0]["VATSBT"].ToString()));

                txtTotal.Value = string.Format("{0:0,0.00}",Convert.ToDouble( dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));

                txtRemarks.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();



            }
        }
    }
}