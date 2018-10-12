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
    /// Summary description for ltrMedicalPaid.
    /// </summary>
    public partial class ltrMedicalPaid : Telerik.Reporting.Report
    {
        public ltrMedicalPaid()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrMedicalPaid(List<clsEBRenewalLetter> objLetter, DataSet dsFooterCountry)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            table1.DataSource = objLetter;
            if (dsFooterCountry != null && dsFooterCountry.Tables != null && dsFooterCountry.Tables.Count > 0 && dsFooterCountry.Tables[0].Rows.Count > 0)
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString().Replace("&", "&amp;").Replace("'", "&apos;").ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString().Replace("&", "&amp;").Replace("'", "&apos;").ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString().Replace("&", "&amp;").Replace("'", "&apos;").ToString();
            }
            
        }
    }
}