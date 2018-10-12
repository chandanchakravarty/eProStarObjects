namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using System.Data;
    using BusinessObjectLayer.BrokingModule.Reports;
    using BusinessAccessLayer.BrokingModule.Reports;

    /// <summary>
    /// Summary description for ltrECChineseFormEnquiry.
    /// </summary>
   internal partial class ltrECChineseFormEnquiry : Telerik.Reporting.Report
    {
        List<clsECLetter> objLetter = new List<clsECLetter>();
        int num = 0;
        public ltrECChineseFormEnquiry()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrECChineseFormEnquiry(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;

            //
            // Required for telerik Reporting designer support
            //


            InitializeComponent();

            foreach (clsECLetter chineseletter in objLettera)
            {
                this.textBox7.Value = chineseletter.ClaimNo;
                this.textBox2.Value = chineseletter.NameOfInjured;
                this.textBox5.Value = (chineseletter.DateOfAccident).Substring(0,chineseletter.DateOfAccident.IndexOf(" "));
                this.textBox78.Value = (chineseletter.ClaimHandler).Trim();


            }
            //table1.DataSource = objLetter;          
            
                    
            
        }
    }
}