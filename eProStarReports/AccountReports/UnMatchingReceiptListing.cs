namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    //using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for UnMatchingReceiptListing.
    /// </summary>
   internal partial class UnMatchingReceiptListing : Telerik.Reporting.Report
    {
        public UnMatchingReceiptListing()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public UnMatchingReceiptListing(DataSet DS)
        {
            InitializeComponent();

           
            if (DS.Tables[0].Rows.Count > 0)
            {
                object Totalamt;
                Totalamt = DS.Tables[0].Compute("Sum(BankAmount)", "");
                textBox12.Value = Totalamt.ToString();
                table1.DataSource = DS.Tables[0];
            }

           
        }
    }
}