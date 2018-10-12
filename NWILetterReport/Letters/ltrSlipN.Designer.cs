namespace NWILetterReport
{
    partial class ltrSlipN
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ltrSlipN));
            this.detail = new Telerik.Reporting.DetailSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.htmlTextBox1 = new Telerik.Reporting.HtmlTextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.txtCountry = new Telerik.Reporting.HtmlTextBox();
            this.txtMail = new Telerik.Reporting.HtmlTextBox();
            this.txtAddress = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox5 = new Telerik.Reporting.HtmlTextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.ltrSlipSubreport1 = new NWILetterReport.Letters.ltrSlipSubreport();
            ((System.ComponentModel.ISupportInitialize)(this.ltrSlipSubreport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(6.51815938949585, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.subReport1,
            this.textBox5,
            this.textBox6,
            this.textBox1,
            this.htmlTextBox1,
            this.textBox9,
            this.textBox2});
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // pictureBox1
            // 
            formattingRule1.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=IIf(Fields.PrintCompLogo=\"No\",False,True)", Telerik.Reporting.FilterOperator.Equal, "True")});
            formattingRule1.Style.Visible = true;
            this.pictureBox1.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9339065551757812E-05, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.9999606609344482, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.699999988079071, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pictureBox1.Style.Visible = false;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Name = "textBox20";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3998031616210938, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.36968448758125305, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "Verdana";
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Value = "Confirm acceptance of this quotation and \r\nto effect / renew this insurance as fr" +
                "om ______________ : -\r\n\r\n";
            // 
            // textBox6
            // 
            this.textBox6.CanShrink = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.3697628974914551, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.9999606609344482, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.33015823364257812, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Verdana";
            this.textBox6.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox6.Value = "Authorized Signature with Company Chop";
            // 
            // textBox1
            // 
            this.textBox1.CanShrink = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.0000393390655518, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.3697628974914551, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.3998031616210938, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.64839631319046021, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Value = "";
            // 
            // htmlTextBox1
            // 
            this.htmlTextBox1.CanGrow = false;
            this.htmlTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.000118255615234375, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.70011806488037109, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox1.Name = "htmlTextBox1";
            this.htmlTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3000006675720215, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.49988174438476562, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox1.Style.Font.Bold = true;
            this.htmlTextBox1.Style.Font.Name = "Verdana";
            this.htmlTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.htmlTextBox1.Value = "= IIf(Fields.calledFrom=\"QN\",\"Quotation Slip\",\"Cover Note Slip\")";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.CanGrow = false;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.399960994720459, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999986588954926, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Name = "textBox1";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8000789880752564, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.42735934257507324, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Font.Name = "Verdana";
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "= IIf(Fields.PrintFor=\"UW\",\"For Underwriter\",IIf(Fields.PrintFor=\"CL\",\"For Client" +
                "\",IIf(Fields.PrintFor=\"OWN\",\"For Own Use\",\"\"))) ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.7000002861022949, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.9999210834503174, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.31815910339355469, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox2.Value = "Date:";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.80023699998855591, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtCountry,
            this.txtMail,
            this.txtAddress,
            this.htmlTextBox5});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.Visible = true;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3996453285217285, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtCountry.Style.Font.Bold = true;
            this.txtCountry.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtCountry.Value = "<strong><span style=\"font-size: medium\">htmlTextBox5</span></strong>";
            // 
            // txtMail
            // 
            this.txtMail.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40015792846679688, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3996453285217285, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtMail.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtMail.Value = "<span style=\"font-size: xx-small\">htmlTextBox7</span>";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20007896423339844, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3998427391052246, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtAddress.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtAddress.Value = "<span style=\"font-size: xx-small\">htmlTextBox6</span>";
            // 
            // htmlTextBox5
            // 
            this.htmlTextBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00019709269690793008, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.60023689270019531, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox5.Name = "htmlTextBox5";
            this.htmlTextBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.3996453285217285, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.htmlTextBox5.Value = resources.GetString("htmlTextBox5.Value");
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.2000786066055298, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport1.Name = "subReport1";
            this.subReport1.ReportSource = this.ltrSlipSubreport1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.300079345703125, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(2.7999212741851807, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport1.NeedDataSource += new System.EventHandler(this.subReport1_NeedDataSource);
            // 
            // ltrSlipSubreport1
            // 
            this.ltrSlipSubreport1.Name = "ltrSlipSubreport";
            // 
            // ltrSlipN
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.Font.Name = "Verdana";
            this.Width = new Telerik.Reporting.Drawing.Unit(6.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch);
            this.Name = "ltrSlipN";
            ((System.ComponentModel.ISupportInitialize)(this.ltrSlipSubreport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport subReport1;
        private NWILetterReport.Letters.ltrSlipSubreport ltrSlipSubreport1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.HtmlTextBox htmlTextBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.HtmlTextBox txtCountry;
        private Telerik.Reporting.HtmlTextBox txtMail;
        private Telerik.Reporting.HtmlTextBox txtAddress;
        private Telerik.Reporting.HtmlTextBox htmlTextBox5;
    }
}