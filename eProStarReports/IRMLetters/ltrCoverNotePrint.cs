namespace eProStarReports.IRMLetters
{
    using System.Collections.Generic;
    using BusinessObjectLayer.RIBrokingModule.Reports;
    using System;
    using System.Data;

    /// <summary>
    /// Summary description for ltrCoverNotePrint.
    /// </summary>
    
   internal partial class ltrCoverNotePrint : Telerik.Reporting.Report
    {
        List<clsPrintCNCombinedData> objCNLetter = null;
        int totCounter = 0;
        int picCounter = 0;

        public ltrCoverNotePrint()
        {
            InitializeComponent();
        }

        public ltrCoverNotePrint(List<clsPrintCNCombinedData> objLetter, DataSet dsFooterCountry, String CoverNoteNo, String header, string IntroText)
        {
            objCNLetter = objLetter;
            InitializeComponent();
            table1.DataSource = objCNLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }
            textBox1.Value = CoverNoteNo;
            textBox2.Value = header;
            if (!String.IsNullOrEmpty(IntroText) && !header.ToLower().Contains("slip"))
            {
                htbIntro.Visible = true;
                htbIntro.Value =  IntroText;
            }
        }

        private void table2_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table destinationTable = (Telerik.Reporting.Processing.Table)sender;
            destinationTable.DataSource = objCNLetter[totCounter++].lstSlipFields;
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {

        }

        private void pictureBox1_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.PictureBox pckBox = (Telerik.Reporting.Processing.PictureBox)sender;
            if (objCNLetter[picCounter].PrintCompLogo == "No")
            {
                pckBox.Visible = false;
                //this.table1.Items[0].Items["pictureBox1"].Visible = false;
            }
            else
            {
                pckBox.Visible = true;
            }
            picCounter++;
        }

        private void pictureBox1_ItemDataBinding(object sender, EventArgs e)
        {

        }

    }
}