namespace eProStarReports.Letters.LAW
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
    public partial class IHPrintFormat_Annually : Telerik.Reporting.Report
    {
        public IHPrintFormat_Annually()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public IHPrintFormat_Annually(DataSet dsObj, string compName, string printlogo)
        {
            InitializeComponent();
            if (printlogo == "Y")
                pictureBox1.Visible = true;
            else
                pictureBox1.Visible = false;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                if (dsObj.Tables[0].Rows[0]["ContactPerson"].ToString() != "")
                    txtContactPerson.Value = dsObj.Tables[0].Rows[0]["ContactPerson"].ToString();
                else
                    txtContactPerson.Visible = false;
                if (dsObj.Tables[0].Rows[0]["DirectLineNo"].ToString() != "")
                    txtPhnNo.Value = dsObj.Tables[0].Rows[0]["DirectLineCode"].ToString() +"-"+ dsObj.Tables[0].Rows[0]["DirectLineNo"].ToString();
                else
                    txtPhnNo.Visible = false;
                if (dsObj.Tables[0].Rows[0]["Email"].ToString() != "")
                    txtEmail.Value = dsObj.Tables[0].Rows[0]["Email"].ToString();
                else
                    txtEmail.Visible = false;
                txtArea.Value = dsObj.Tables[0].Rows[0]["PlanType"].ToString();
                txtProgram .Value = dsObj.Tables[0].Rows[0]["Program"].ToString();
                txtDeductible.Value = Convert.ToDecimal(dsObj.Tables[0].Rows[0]["DEductible"]).ToString("#,##0.00");
                txtMode.Value = dsObj.Tables[0].Rows[0]["PModeName"].ToString();
               // txtDate.Value = "From " + dsObj.Tables[0].Rows[0]["POIFromDate"].ToString() + " To " + dsObj.Tables[0].Rows[0]["POIToDate"].ToString();
                txtDate.Value =  dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();

                table4.DataSource = dsObj;
                if (dsObj.Tables[0].Rows[0]["PModeName"].ToString().Equals("Quarterly"))
                {
                    textBox3.Visible = true;
                    textBox3.Value = "The total due for each subsequent installment (2nd - 4th) is " + Convert.ToDecimal(dsObj.Tables[0].Compute("Sum(PremiumRate)", "")).ToString("#,##0.00") + "(THB)";
                }
                else if (dsObj.Tables[0].Rows[0]["PModeName"].ToString().Equals("Annually"))
                {
                    textBox3.Visible = false;
                }
                else
                {
                    textBox3.Visible = true;
                    textBox3.Value = "The total due for each subsequent installment (2nd) is " + Convert.ToDecimal(dsObj.Tables[0].Compute("Sum(PremiumRate)", "")).ToString("#,##0.00") + "(THB)";
                }
                // txtCompanyName.Value = compName;
                // txtRefNo.Value = dsObj.Tables[0].Rows[0]["DebitNoteNo"].ToString();
                // txtIssuedDate.Value = dsObj.Tables[0].Rows[0]["EffectiveDate"].ToString();
                //// txtDuedate.Value = dsObj.Tables[0].Rows[0]["POIFromDate"].ToString();
                // txtClientName.Value = dsObj.Tables[0].Rows[0]["Name"].ToString();
                // txtClientAddr.Value = dsObj.Tables[0].Rows[0]["Address"].ToString().ToUpper();
                // //txtComName.Value = dsObj.Tables[0].Rows[0]["TopCompanyName"].ToString().ToUpper();

                // txtInsurerName.Value = dsObj.Tables[0].Rows[0]["UnderwriterName"].ToString();

                // txtTypeOfIns.Value = dsObj.Tables[0].Rows[0]["TypeOfInsurance"].ToString();

                // txtPolicyNo.Value = dsObj.Tables[0].Rows[0]["policyno"].ToString();
                // txtEndtNo.Value = dsObj.Tables[0].Rows[0]["EndorsementNo"].ToString();
                // txtPOI.Value = dsObj.Tables[0].Rows[0]["InsuredPeriod"].ToString();
                // txtPremium.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalPremium"]));
                // txtPremiumDue.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["StampDuty"].ToString()));


                // txtTax.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["WHTAmount"].ToString()));

                // txtVAT.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["VATSBT"].ToString()));

                // txtTotal.Value = string.Format("{0:0,0.00}", Convert.ToDouble(dsObj.Tables[0].Rows[0]["TotalDue"].ToString()));
                // txtRemarks.Value = dsObj.Tables[0].Rows[0]["Remarks"].ToString();



            }
        }

        public static string convertIntoNumeric(decimal number)
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

            return str;

        }
    }
}