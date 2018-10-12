namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using BusinessObjectLayer.BrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for ltrClientShortfall.
    /// </summary>
    public partial class ltrClientSettled : Telerik.Reporting.Report
    {
        public string strDateFormat = "";
        public ltrClientSettled()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrClientSettled(List<clsEBLetter> objLetter,DataSet dsFooterCountry, string DateFormat)
        {
            //
            // Required for telerik Reporting designer support
            //
            strDateFormat = DateFormat;
            InitializeComponent();
            table1.DataSource = objLetter;
            //added by kavita
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            
            
        }
        public List<string> GetOptions()
        {
            List<string> lstOptions = new List<string>();
            lstOptions.Add("Shortfall");
            lstOptions.Add("Pending/Rejected");
            lstOptions.Add("Return Original Receipts");
            return lstOptions;
        }

        private void table1_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
            
            
            
        }
    }
}