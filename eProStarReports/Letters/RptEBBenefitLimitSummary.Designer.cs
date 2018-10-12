namespace eProStarReports.Letters
{
    partial class RptEBBenefitLimitSummary
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txtUWName = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.BenefitLimitHeader = new Telerik.Reporting.PageHeaderSection();
            this.txtHeader = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.CtabBenefitLimit = new Telerik.Reporting.Crosstab();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.txtClientname = new Telerik.Reporting.TextBox();
            this.txtClass = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.txtPoiFromdate = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.txtPOItodate = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.txtSubClass = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.txtQuotationno = new Telerik.Reporting.TextBox();
            this.txtCoverNote = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Verdana";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.StyleName = "";
            this.textBox1.Value = "=Fields.PlanName";
            // 
            // txtUWName
            // 
            this.txtUWName.Name = "txtUWName";
            this.txtUWName.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtUWName.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.txtUWName.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtUWName.Style.Font.Bold = true;
            this.txtUWName.Style.Font.Name = "Verdana";
            this.txtUWName.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtUWName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtUWName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtUWName.Value = "=Fields.UnderwriterName";
            // 
            // textBox2
            // 
            formattingRule1.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("IIF(Fields.BenefitLineID <> 0,True,\r\nIsNull(Fields.BenefitLineName,True))", Telerik.Reporting.FilterOperator.NotEqual, "true")});
            formattingRule1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            formattingRule1.Style.Font.Bold = true;
            this.textBox2.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "=Fields.BenefitLineName";
            // 
            // BenefitLimitHeader
            // 
            this.BenefitLimitHeader.Height = new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Cm);
            this.BenefitLimitHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtHeader});
            this.BenefitLimitHeader.Name = "BenefitLimitHeader";
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.00010002215276472271, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.00010002215276472271, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(16.003311157226562, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.0997002124786377, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtHeader.Style.BackgroundColor = System.Drawing.Color.Orange;
            this.txtHeader.Style.Font.Bold = true;
            this.txtHeader.Style.Font.Name = "Verdana";
            this.txtHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtHeader.Value = "Benefit Schedule Limit Summary";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(4.20020055770874, Telerik.Reporting.Drawing.UnitType.Cm);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.CtabBenefitLimit,
            this.table1});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // CtabBenefitLimit
            // 
            this.CtabBenefitLimit.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.CtabBenefitLimit.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.59999990463256836, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.CtabBenefitLimit.Body.SetCellContent(0, 0, this.textBox20);
            tableGroup2.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.PlanName")});
            tableGroup2.GroupKeepTogether = true;
            tableGroup2.Name = "Planname";
            tableGroup2.ReportItem = this.textBox1;
            tableGroup2.Sorting.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.PlanName", Telerik.Reporting.SortDirection.Asc)});
            tableGroup1.ChildGroups.Add(tableGroup2);
            tableGroup1.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.UnderwriterName")});
            tableGroup1.Name = "ColumnGroup";
            tableGroup1.ReportItem = this.txtUWName;
            tableGroup1.Sorting.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.UnderwriterName", Telerik.Reporting.SortDirection.Asc)});
            this.CtabBenefitLimit.ColumnGroups.Add(tableGroup1);
            this.CtabBenefitLimit.Corner.SetCellContent(0, 0, this.textBox3, 2, 1);
            this.CtabBenefitLimit.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox20,
            this.txtUWName,
            this.textBox1,
            this.textBox3,
            this.textBox2});
            this.CtabBenefitLimit.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.400200366973877, Telerik.Reporting.Drawing.UnitType.Cm));
            this.CtabBenefitLimit.Name = "CtabBenefitLimit";
            tableGroup5.Name = "Group4";
            tableGroup4.ChildGroups.Add(tableGroup5);
            tableGroup4.Name = "Group3";
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.BenefitGroupLineName"),
            new Telerik.Reporting.Grouping("=Fields.BenefitGroup"),
            new Telerik.Reporting.Grouping("=Fields.BenefitLineID")});
            tableGroup3.Name = "BenefitLineName";
            tableGroup3.ReportItem = this.textBox2;
            tableGroup3.Sorting.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.BGOrderNo", Telerik.Reporting.SortDirection.Asc),
            new Telerik.Reporting.Sorting("=Fields.BenefitLineID", Telerik.Reporting.SortDirection.Asc),
            new Telerik.Reporting.Sorting("=Fields.BLOrderNo", Telerik.Reporting.SortDirection.Asc)});
            this.CtabBenefitLimit.RowGroups.Add(tableGroup3);
            this.CtabBenefitLimit.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.7999999523162842, Telerik.Reporting.Drawing.UnitType.Cm));
            this.CtabBenefitLimit.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.CtabBenefitLimit.Style.Visible = true;
            // 
            // textBox20
            // 
            formattingRule2.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("IIF(Fields.BenefitLineID <> 0,True,\r\nIsNull(Fields.BenefitLineName,True))", Telerik.Reporting.FilterOperator.NotEqual, "true")});
            formattingRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            formattingRule2.Style.Font.Bold = true;
            this.textBox20.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox20.Format = "{0:N2}";
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.Font.Name = "Verdana";
            this.textBox20.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox20.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.StyleName = "";
            this.textBox20.Value = "=IIf(Fields.BenefitGroup <> \"grp\",CDbl(Fields.LimitAmt), \"\")";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1.2000000476837158, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Verdana";
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.StyleName = "";
            this.textBox3.Value = "Benefit Line Name";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4.0034122467041016, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm)));
            this.table1.Body.SetCellContent(0, 1, this.textBox7);
            this.table1.Body.SetCellContent(0, 2, this.textBox8);
            this.table1.Body.SetCellContent(0, 3, this.txtClientname);
            this.table1.Body.SetCellContent(0, 0, this.txtClass);
            this.table1.Body.SetCellContent(2, 0, this.textBox5);
            this.table1.Body.SetCellContent(3, 0, this.textBox12);
            this.table1.Body.SetCellContent(3, 1, this.txtPoiFromdate);
            this.table1.Body.SetCellContent(3, 2, this.textBox14);
            this.table1.Body.SetCellContent(3, 3, this.txtPOItodate);
            this.table1.Body.SetCellContent(1, 0, this.textBox16);
            this.table1.Body.SetCellContent(1, 1, this.txtSubClass);
            this.table1.Body.SetCellContent(1, 2, this.textBox18);
            this.table1.Body.SetCellContent(1, 3, this.txtQuotationno);
            this.table1.Body.SetCellContent(2, 1, this.txtCoverNote, 1, 3);
            tableGroup6.Name = "Group1";
            this.table1.ColumnGroups.Add(tableGroup6);
            this.table1.ColumnGroups.Add(tableGroup7);
            this.table1.ColumnGroups.Add(tableGroup8);
            this.table1.ColumnGroups.Add(tableGroup9);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox8,
            this.txtClientname,
            this.txtClass,
            this.textBox5,
            this.textBox12,
            this.txtPoiFromdate,
            this.textBox14,
            this.txtPOItodate,
            this.textBox16,
            this.txtSubClass,
            this.textBox18,
            this.txtQuotationno,
            this.txtCoverNote});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm));
            this.table1.Name = "table1";
            tableGroup11.Name = "Group2";
            tableGroup12.Name = "Group5";
            tableGroup13.Name = "Group3";
            tableGroup14.Name = "Group4";
            tableGroup10.ChildGroups.Add(tableGroup11);
            tableGroup10.ChildGroups.Add(tableGroup12);
            tableGroup10.ChildGroups.Add(tableGroup13);
            tableGroup10.ChildGroups.Add(tableGroup14);
            tableGroup10.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup10.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup10);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(16.003410339355469, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2.3999998569488525, Telerik.Reporting.Drawing.UnitType.Cm));
            this.table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Name = "Verdana";
            this.textBox7.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Employee Benefits";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Verdana";
            this.textBox8.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "Client\'s Name";
            // 
            // txtClientname
            // 
            this.txtClientname.Name = "txtClientname";
            this.txtClientname.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtClientname.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtClientname.Style.Font.Bold = false;
            this.txtClientname.Style.Font.Name = "Verdana";
            this.txtClientname.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtClientname.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // txtClass
            // 
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.0034117698669434, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtClass.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtClass.Style.Font.Bold = true;
            this.txtClass.Style.Font.Name = "Verdana";
            this.txtClass.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtClass.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm);
            this.txtClass.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtClass.StyleName = "";
            this.txtClass.Value = "Class";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.0034117698669434, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "Verdana";
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "";
            this.textBox5.Value = "Cover Note No.";
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.0034117698669434, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Name = "Verdana";
            this.textBox12.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox12.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "";
            this.textBox12.Value = "Policy From Date";
            // 
            // txtPoiFromdate
            // 
            this.txtPoiFromdate.Name = "txtPoiFromdate";
            this.txtPoiFromdate.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtPoiFromdate.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPoiFromdate.Style.Font.Bold = false;
            this.txtPoiFromdate.Style.Font.Name = "Verdana";
            this.txtPoiFromdate.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtPoiFromdate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtPoiFromdate.StyleName = "";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Name = "Verdana";
            this.textBox14.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.StyleName = "";
            this.textBox14.Value = "To Date";
            // 
            // txtPOItodate
            // 
            this.txtPOItodate.Name = "txtPOItodate";
            this.txtPOItodate.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtPOItodate.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtPOItodate.Style.Font.Bold = false;
            this.txtPOItodate.Style.Font.Name = "Verdana";
            this.txtPOItodate.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtPOItodate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtPOItodate.StyleName = "";
            // 
            // textBox16
            // 
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.0034117698669434, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Verdana";
            this.textBox16.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox16.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Cm);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.StyleName = "";
            this.textBox16.Value = "Sub Class";
            // 
            // txtSubClass
            // 
            this.txtSubClass.Name = "txtSubClass";
            this.txtSubClass.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtSubClass.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtSubClass.Style.Font.Bold = false;
            this.txtSubClass.Style.Font.Name = "Verdana";
            this.txtSubClass.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtSubClass.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtSubClass.StyleName = "";
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Name = "Verdana";
            this.textBox18.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.StyleName = "";
            this.textBox18.Value = "Quotation No.";
            // 
            // txtQuotationno
            // 
            this.txtQuotationno.Name = "txtQuotationno";
            this.txtQuotationno.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.60000002384185791, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtQuotationno.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtQuotationno.Style.Font.Bold = false;
            this.txtQuotationno.Style.Font.Name = "Verdana";
            this.txtQuotationno.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtQuotationno.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtQuotationno.StyleName = "";
            // 
            // txtCoverNote
            // 
            this.txtCoverNote.Name = "txtCoverNote";
            this.txtCoverNote.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.59999996423721313, Telerik.Reporting.Drawing.UnitType.Cm));
            this.txtCoverNote.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.txtCoverNote.Style.Font.Bold = false;
            this.txtCoverNote.Style.Font.Name = "Verdana";
            this.txtCoverNote.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtCoverNote.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtCoverNote.StyleName = "";
            // 
            // RptEBBenefitLimitSummary
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.BenefitLimitHeader,
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(2.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(2.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(2.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(2.5399999618530273, Telerik.Reporting.Drawing.UnitType.Cm);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(16.011337280273438, Telerik.Reporting.Drawing.UnitType.Cm);
            this.Name = "RptEBBenefitLimitSummary";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection BenefitLimitHeader;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox txtHeader;
        private Telerik.Reporting.Crosstab CtabBenefitLimit;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox txtClientname;
        private Telerik.Reporting.TextBox txtClass;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox txtCoverNote;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox txtPoiFromdate;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox txtPOItodate;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox txtSubClass;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox txtQuotationno;
        private Telerik.Reporting.TextBox txtUWName;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox2;
    }
}