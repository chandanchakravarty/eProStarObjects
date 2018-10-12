namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;   
    using System.Collections.Generic;
    using System.Web;
    using BusinessObjectLayer.BrokingModule.Reports;

    /// <summary>
    /// Summary description for ltrInsurerOutpatient.
    /// </summary>
    public partial class ltrInsurerOutpatient : Telerik.Reporting.Report
    {
        public ltrInsurerOutpatient()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrInsurerOutpatient(List<clsEBLetter> objLetter)
        {
            InitializeComponent();
            //string appPath =  HttpContext.Current.Request.ApplicationPath;
            //string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            //Image image1 = Image.FromFile(physicalPath+@"\Images\MIBLetterhead.jpg");
            //pictureBox1.Value = image1;
            table1.DataSource = objLetter;
            
        }
    }
}