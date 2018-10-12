namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using BusinessObjectLayer.BrokingModule.Reports;
    using System.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for ltrMovementCover.
    /// </summary>
   internal partial class ltrMovementCover : Telerik.Reporting.Report
    {
        public ltrMovementCover()
        {
            
            InitializeComponent();

            
        }
        public ltrMovementCover(List<clsEBLetter> objLetter, DataSet dsFooterCountry)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            table1.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            
        }
    }
}