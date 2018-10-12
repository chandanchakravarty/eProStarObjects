namespace NWILetterReport.Letters
{
    partial class ltrSlipSubreport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9339065551757812E-05, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.9892102479934692, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.39996066689491272, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Verdana";
            this.textBox1.Value = "=Fields.FieldName";
            // 
            // textBox2
            // 
            this.textBox2.Culture = new System.Globalization.CultureInfo("");
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.9892889261245728, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9339065551757812E-05, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox1";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.0107111930847168, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.39992132782936096, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Name = "Verdana";
            this.textBox2.Style.Visible = true;
            this.textBox2.Value = "=Fields.FieldValue";
            // 
            // ltrSlipSubreport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Name = "ltrSlipSubreport";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
    }
}