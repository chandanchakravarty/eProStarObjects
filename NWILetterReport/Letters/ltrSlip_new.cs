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
    using BusinessAccessLayer.BrokingModule.Reports;
    using System.Web;


    /// <summary>
    /// Summary description for ltrSlip_new.
    /// </summary>
    public partial class ltrSlip_new : Telerik.Reporting.Report
    {
        DataTable dtData = null;
        List<clsPrintSlipData> objLetter = null;
        int num = 0;
        //public ltrSlip_new(DataTable dsSlipData, DataSet dsFooterCountry)
        public ltrSlip_new(List<clsPrintSlipData> objLettera, DataSet dsFooterCountry)
        {
            objLetter = objLettera;
            InitializeComponent();
            this.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
        }

        private void table1_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table tb = (Telerik.Reporting.Processing.Table)sender;
            //strUW = "";

            //DataSet dataTable1 = objEBInPatient.GetEBInsurerInpatientLetterList(strUW);
            tb.DataSource = objLetter[num++].lstSlipFields;
        }
        
    }
}