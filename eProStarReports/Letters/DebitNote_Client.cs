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
    /// Summary description for DebitNote_Client.
    /// </summary>
   internal partial class DebitNote_Client : Telerik.Reporting.Report
    {
        public DebitNote_Client(DataRow dRow,string Type)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
           
            //tblIhRating.DataSource = dt;
            //tblPremium.DataSource = ds.Tables[3];
            txtDebitNote.Style.Font.Name  = txtType.Style.Font.Name = txtRefNo.Style.Font.Name = txtDueDate.Style.Font.Name = txtIssuDate.Style.Font.Name = txtNameAndAdd.Style.Font.Name = txtUniAdd.Style.Font.Name = txtUniEnd.Style.Font.Name = txtUniInsu.Style.Font.Name = txtUniInter.Style.Font.Name = txtUniName.Style.Font.Name = txtUniPeriod.Style.Font.Name = txtUniPolicy.Style.Font.Name = txtUniPrem.Style.Font.Name = txtUniStamp.Style.Font.Name = txtUniTax.Style.Font.Name = txtUniTerm.Style.Font.Name = txtUniTotal.Style.Font.Name = txtUniTypeOfIns.Style.Font.Name = txtUniWHT.Style.Font.Name = "Arial Unicode MS";

            txtComp.Value = dRow["UnderwriterName"].ToString();
            txtInsuran.Value = dRow["TypeOfInsurance"].ToString();
            txtPolicy.Value = dRow["policyno"].ToString();
            txtEnd.Value = dRow["EndorsementNo"].ToString();
            txtInsuredPeriod.Value = dRow["InsuredPeriod"].ToString();

            txtPremuim.Value = dRow["Premium"].ToString();
            txtStampDuty.Value = dRow["StampDuty"].ToString();
            txtTax.Value = dRow["Tax"].ToString();
            txtVat.Value = dRow["WHTAmount"].ToString();
            txtTotal.Value = dRow["TotalDue"].ToString();

            txtName.Value = dRow["Name"].ToString();
            txtAddress.Value = dRow["Address"].ToString();

            txtRefNo1.Value = dRow["DebitNoteNo"].ToString();
            txtIssueDate1.Value = dRow["EffectiveDate"].ToString();
            txtDueDate1.Value = dRow["EffectiveDate"].ToString();

            txtType.Value = Type;
        }
    }
}