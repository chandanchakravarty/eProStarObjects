namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for ReceiptLst.
    /// </summary>
    public partial class ReceiptLst : Telerik.Reporting.Report
    {
        public ReceiptLst()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReceiptLst(DataSet ds,string Rpttype)
        {
            InitializeComponent();
            textBox7.Value = "L.C.H.(S) PTE LTD";
            textBox8.Value = ((Rpttype == "R") ? "RECEIPT " : "PAYMENT ") + "LISTING";
            textBox9.Value = "Accounting Month/Year : " + ((ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["Month"].ToString() + "/" + ds.Tables[0].Rows[0]["Year"].ToString() : "");            
            txtBkAmtLC.Value = (ds.Tables[0].Rows.Count>0) ? ds.Tables[0].Rows[0]["LocalAmtTot"].ToString() : "" ;
            txtGrndAmtFc.Value = (ds.Tables[0].Rows.Count > 0) ? "(" + ds.Tables[0].Rows[0]["AmountFCTot"].ToString() + ")" : "";
            txtRecPayNo.Value = ((Rpttype == "R") ? "Receipt " : "Payment ") + " No.";
            txtRecPay.Value = "Amt " + ((Rpttype == "R") ? "Rec'd " : "Paid ");
            txtRepId.Value = "lch_" + ((Rpttype == "R") ? "receipt" : "payment") + "_listing_" + DateTime.Now.ToString("HH:mm");
            //textBox18.Value = ""; 'lch_receipt_listing_' + Now().tostring("HH:mm")
            //textBox17.Value = "";
            //textBox16.Value = "";
            table1.DataSource = ds.Tables[0];
           
        }
    }
}