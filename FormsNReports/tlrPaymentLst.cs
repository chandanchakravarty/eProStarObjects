namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    //using AcclaimAcc;
    
    
    /// <summary>
    /// Summary description for tlrPaymentLst.
    /// </summary>
    public partial class tlrPaymentLst : Telerik.Reporting.Report
    {
        public tlrPaymentLst()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
         
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrPaymentLst(DataSet Ds)
        {
            //TxtType.Value = "Payment";
            //table1.DataSource = Ds.Tables[0];
            //TxtChequeRef.Value = Ds.Tables[0].Rows[0]["TranNo"].ToString();
            //TxtBankCode.Value = "DATE" + Ds.Tables[0].Rows[0]["TranDate"].ToString() + " ACCOUNT DETAILS [ - ] +" + Ds.Tables[0].Rows[0]["TranType"].ToString() +"";
            //TxtAmount.Value = Ds.Tables[0].Rows[0]["Amount"].ToString();
            //TxtCurr.Value = "";
            //TxtExRate.Value = Ds.Tables[0].Rows[0]["ExRate"].ToString();
            //TxtGLdetails.Value = Ds.Tables[0].Rows[0]["GLCode"].ToString();
            //TxtdebitAmt.Value = Ds.Tables[0].Rows[0]["DebitAmount"].ToString();
            //TxtCreditAmt.Value = Ds.Tables[0].Rows[0]["CreditAmount"].ToString();

         
        }
    }
}