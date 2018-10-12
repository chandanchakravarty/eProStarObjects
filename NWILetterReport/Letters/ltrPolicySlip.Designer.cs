namespace NWILetterReport.Letters
{
    partial class ltrPolicySlip
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(2.0000393390655518, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(1.8853963613510132, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4.1041474342346191, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.66184896230697632, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.SetCellContent(0, 0, this.textBox4);
            this.table1.Body.SetCellContent(0, 1, this.textBox5);
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox5});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch));
            this.table1.Name = "table1";
            tableGroup3.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup3.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup3);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.9895439147949219, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.66184896230697632, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8853963613510132, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.66184896230697632, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Value = "=Fields.FieldName";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.1041474342346191, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.66184896230697632, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Value = "=Fields.FieldValue";
            // 
            // ltrPolicySlip
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Name = "ltrPolicySlip";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
    }
}