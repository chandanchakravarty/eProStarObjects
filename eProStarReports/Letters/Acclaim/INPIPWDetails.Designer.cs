namespace eProStarReports.Letters.Acclaim
{
    partial class INPIPWDetails
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INPIPWDetails));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.txtPPIWSeq = new Telerik.Reporting.TextBox();
            this.txtPPIW = new Telerik.Reporting.TextBox();
            this.txtImportantNotice = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.7000001668930054D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtPPIWSeq,
            this.txtPPIW,
            this.txtImportantNotice});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.detail.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0D);
            // 
            // txtPPIWSeq
            // 
            this.txtPPIWSeq.CanShrink = true;
            this.txtPPIWSeq.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.40019902586936951D));
            this.txtPPIWSeq.Name = "txtPPIWSeq";
            this.txtPPIWSeq.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.39999938011169434D), Telerik.Reporting.Drawing.Unit.Cm(3.8999996185302734D));
            this.txtPPIWSeq.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIWSeq.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIWSeq.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIWSeq.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIWSeq.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIWSeq.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.txtPPIWSeq.Value = "1.\r\na.\r\n\r\nb.\r\n\r\n2.\r\n\r\na.\r\nb.\r\nc.\r\n3.\r\n\r\na.\r\n4.";
            // 
            // txtPPIW
            // 
            this.txtPPIW.CanShrink = true;
            this.txtPPIW.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40010002255439758D), Telerik.Reporting.Drawing.Unit.Cm(0.40019902586936951D));
            this.txtPPIW.Name = "txtPPIW";
            this.txtPPIW.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.749200820922852D), Telerik.Reporting.Drawing.Unit.Cm(3.8999996185302734D));
            this.txtPPIW.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIW.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIW.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIW.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIW.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPIW.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.txtPPIW.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.txtPPIW.Style.Visible = true;
            this.txtPPIW.Value = resources.GetString("txtPPIW.Value");
            // 
            // txtImportantNotice
            // 
            this.txtImportantNotice.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txtImportantNotice.Name = "txtImportantNotice";
            this.txtImportantNotice.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.7699999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.39999926090240479D));
            this.txtImportantNotice.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtImportantNotice.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.txtImportantNotice.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.txtImportantNotice.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.txtImportantNotice.Style.Font.Bold = true;
            this.txtImportantNotice.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtImportantNotice.Value = "IMPORTANT NOTICE : PREMIUM INSTALMENT PAYMENT WARRANTY";
            // 
            // INPIPWDetails
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "PPIWDetails";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.7699999809265137D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox txtPPIWSeq;
        private Telerik.Reporting.TextBox txtPPIW;
        private Telerik.Reporting.TextBox txtImportantNotice;
    }
}