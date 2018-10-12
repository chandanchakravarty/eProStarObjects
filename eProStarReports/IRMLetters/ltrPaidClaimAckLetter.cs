namespace eProStarReports.IRMLetters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using BusinessObjectLayer.RIBrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for ltrPaidClaimAckLetter.
    /// </summary>
   internal partial class ltrPaidClaimAckLetter : Telerik.Reporting.Report
    {
        public ltrPaidClaimAckLetter()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrPaidClaimAckLetter(List<clsLetter> objLetter, DataSet dsFooterCountry, DataSet dsCurrency)
        {
            InitializeComponent();
            table3.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                htmlTextBox3.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                htmlTextBox4.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                htmlTextBox6.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
        }

        private void table1_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
        }

    }
}