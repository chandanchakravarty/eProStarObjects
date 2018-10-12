namespace eProStarReports.Letters
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
    using BusinessAccessLayer.BrokingModule.Reports;
    using System.Web;

    /// <summary>
    /// Summary description for ltrInsurerInpatient.
    /// </summary>
   internal partial class ltrSlip : Telerik.Reporting.Report
    {
        List<clsPrintSlipData> objLetter = null;
        int num = 0;
        public ltrSlip()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //subReport1.ReportSource = new InPatientSubReport();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrSlip(List<clsPrintSlipData> objLettera, DataSet dsFooterCountry)
        {

            //objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //

            objLetter = objLettera;
            InitializeComponent();
            table1.DataSource = objLetter;
            //string appPath = HttpContext.Current.Request.ApplicationPath;
            //string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            //if(objLetter[num
            //Image image1 = Image.FromFile(physicalPath + @"\Images\mainMenu\logo_homepage.png");
            //pictureBox1.Value = image1.ToString();
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            //textBox1.v
        }
        //int i = 0;
        private void table2_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            //strUW = "";

            //DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(strUW);
            tb.DataSource = objLetter[num++].lstSlipFields;
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {

        }
    }
}