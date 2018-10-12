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
    /// Summary description for ltrInsurerOutpatient1.
    /// </summary>
    public partial class ltrInsurerOutpatient1 : Telerik.Reporting.Report
    {
        public ltrInsurerOutpatient1()
        {
            InitializeComponent();
        }

        public ltrInsurerOutpatient1(List<clsEBLetter> objLetter,DataSet dsFooterCountry)
        {
            InitializeComponent();
            //string appPath =  HttpContext.Current.Request.ApplicationPath;
            //string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            //Image image1 = Image.FromFile(physicalPath+@"\Images\MIBLetterhead.jpg");
            //pictureBox1.Value = image1;
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