namespace eProStarReports.Letters.Acclaim
{
    partial class INPPWDetails
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INPPWDetails));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.txtTextPPW = new Telerik.Reporting.TextBox();
            this.txtPPWSequence = new Telerik.Reporting.TextBox();
            this.txtImportantNotice = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtTextPPW,
            this.txtPPWSequence,
            this.txtImportantNotice});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.detail.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0D);
            // 
            // txtTextPPW
            // 
            this.txtTextPPW.CanShrink = true;
            this.txtTextPPW.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44659984111785889D), Telerik.Reporting.Drawing.Unit.Cm(0.40019902586936951D));
            this.txtTextPPW.Name = "txtTextPPW";
            this.txtTextPPW.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.749200820922852D), Telerik.Reporting.Drawing.Unit.Cm(2.6200003623962402D));
            this.txtTextPPW.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.txtTextPPW.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.txtTextPPW.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.txtTextPPW.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.txtTextPPW.Style.Visible = true;
            this.txtTextPPW.Value = resources.GetString("txtTextPPW.Value");
            // 
            // txtPPWSequence
            // 
            this.txtPPWSequence.CanShrink = true;
            this.txtPPWSequence.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.046400591731071472D), Telerik.Reporting.Drawing.Unit.Cm(0.40019902586936951D));
            this.txtPPWSequence.Name = "txtPPWSequence";
            this.txtPPWSequence.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.39999938011169434D), Telerik.Reporting.Drawing.Unit.Cm(2.6200003623962402D));
            this.txtPPWSequence.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPWSequence.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPPWSequence.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.txtPPWSequence.Value = "1.\r\n\r\n\r\n2.\r\n\r\na.\r\nb.\r\nc.\r\n3.";
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
            this.txtImportantNotice.Value = "IMPORTANT NOTICE : PREMIUM PAYMENT WARRANTY";
            // 
            // INPPWDetails
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "ImportantNoticeDetails";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.7710633277893066D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox txtTextPPW;
        private Telerik.Reporting.TextBox txtPPWSequence;
        private Telerik.Reporting.TextBox txtImportantNotice;
    }
}