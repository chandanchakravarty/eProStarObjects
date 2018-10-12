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
    /// Summary description for ltrECEnglishFormEnquiry.
    /// </summary>
   internal partial class ltrECEnglishFormEnquiry : Telerik.Reporting.Report
    {
       public List<clsECLetter> objLetter = new List<clsECLetter>();
        int num = 0;
        public ltrECEnglishFormEnquiry()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrECEnglishFormEnquiry(List<clsECLetter> objLettera, DataSet dsFooterCountry)
        {

            objLetter = objLettera;
            
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            foreach (clsECLetter ecletter in objLettera)
            {
                this.textBox84.Value = ecletter.ClaimNo;
                this.textBox86.Value = ecletter.NameOfInjured;
                this.textBox88.Value = (ecletter.DateOfAccident).Substring(0,ecletter.DateOfAccident.IndexOf(" "));         

                this.textBox147.Value = ecletter.ClaimHandler;
                
            }
            //table1.DataSource = objLetter;
        }

        private void textBox84_ItemDataBound(object sender, EventArgs e)
        {
            var procTextBox = (Telerik.Reporting.Processing.TextBox)sender;
          
            //var procSubReport = (Telerik.Reporting.Processing.SubReport)procTextBox.Report.ChildElements.Find("subReport1", true)[0];
            //foreach (clsECLetter ecletter in objLetter)
            //{
            //    var procSubReport = ecletter.ClaimNo;
            
            //    var procSubReportTextBox = (Telerik.Reporting.Processing.TextBox)procSubReport.InnerReport.ChildElements.Find("textBox84", true)[0];
            //    procTextBox.Value = procSubReportTextBox.Value;
            //}

            foreach (clsECLetter ecletter in objLetter)
            {
                this.textBox84.Value = ecletter.ClaimNo;
                //this.textBox86.Value = ecletter.NameOfInjured;
                //this.textBox88.Value = ecletter.DateOfAccident;
                //this.textBox147.Value = ecletter.ClaimHandler;
                //this.textBox149.Value = DateTime.Now.ToString();
            }

        }


    }
}