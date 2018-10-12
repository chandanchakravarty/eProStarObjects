namespace eProStarReports.IHReports
{
    partial class IHMasterPolicy
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.RptName = new Telerik.Reporting.HtmlTextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.1161513328552246D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19752955436706543D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Value = "Insured";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.0671825408935547D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19752953946590424D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Value = "Number";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.RptName});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // RptName
            // 
            this.RptName.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.9000000953674316D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999986588954926D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.RptName.Name = "RptName";
            this.RptName.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.5000002384185791D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.RptName.Style.Font.Bold = true;
            this.RptName.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(14D, Telerik.Reporting.Drawing.UnitType.Point);
            this.RptName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.RptName.Value = "Master Policy Report";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(2.4000003337860107D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(3.1161513328552246D, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(2.0671825408935547D, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.40247064828872681D, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.SetCellContent(0, 0, this.textBox4);
            this.table1.Body.SetCellContent(0, 1, this.textBox5);
            tableGroup4.ReportItem = this.textBox1;
            tableGroup5.ReportItem = this.textBox2;
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.ColumnGroups.Add(tableGroup5);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox5,
            this.textBox1,
            this.textBox2});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.table1.Name = "table1";
            tableGroup6.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup6.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup6);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.1833338737487793D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.60000020265579224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.1161513328552246D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40247064828872681D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Value = "=InsuredName";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.0671825408935547D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40247067809104919D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Value = "=MemberCode";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // IHMasterPolicy
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(6.2125000953674316D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.Name = "IHMasterPolicy";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.HtmlTextBox RptName;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox4;
    }
}