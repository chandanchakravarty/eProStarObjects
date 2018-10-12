namespace NWILetterReport.Letters
{
    partial class ltrClientSettled
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ltrClientSettled));
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.txtFiller1 = new Telerik.Reporting.TextBox();
            this.htmlTextBox1 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox2 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox3 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox4 = new Telerik.Reporting.HtmlTextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.txtCountry = new Telerik.Reporting.HtmlTextBox();
            this.txtAddress = new Telerik.Reporting.HtmlTextBox();
            this.txtMail = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox5 = new Telerik.Reporting.HtmlTextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(7, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(new Telerik.Reporting.Drawing.Unit(6.4999213218688965, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(new Telerik.Reporting.Drawing.Unit(6.924959659576416, Telerik.Reporting.Drawing.UnitType.Inch)));
            this.table1.Body.SetCellContent(0, 0, this.panel1);
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9378803194267675E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9378803194267675E-05, Telerik.Reporting.Drawing.UnitType.Inch));
            this.table1.Name = "table1";
            tableGroup2.Grouping.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup2.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup2);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(6.924959659576416, Telerik.Reporting.Drawing.UnitType.Inch));
            this.table1.ItemDataBinding += new System.EventHandler(this.table1_ItemDataBinding);
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox15,
            this.txtFiller1,
            this.htmlTextBox1,
            this.htmlTextBox2,
            this.htmlTextBox3,
            this.htmlTextBox4,
            this.textBox5,
            this.textBox6});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.099960602819919586, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099960602819919586, Telerik.Reporting.Drawing.UnitType.Inch));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(6.924959659576416, Telerik.Reporting.Drawing.UnitType.Inch));
            this.panel1.Style.Font.Name = "Verdana";
            this.panel1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.panel1.StyleName = "";
            // 
            // textBox1
            // 
            this.textBox1.Format = "{0:" + (strDateFormat == "dd/MM/yyyy" ? "dd MMMM yyyy" : strDateFormat) + "}";
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19996058940887451, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999606132507324, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Name = "Verdana";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Value = "= Now()";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.500039279460907, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999606132507324, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19992136955261231, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "Verdana";
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Style.Font.Underline = true;
            this.textBox2.Value = "Private & Confidential";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.89996069669723511, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.Font.Name = "Verdana";
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Value = "=Fields.ClientName1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.6999607086181641, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29992103576660156, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Style.Font.Name = "Verdana";
            this.textBox4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox4.Value = "= \"Dear \" + Fields.ClientFirstName + \",\"";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996075332164764, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.5998821258544922, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.29992151260376, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20007865130901337, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox8.Style.Font.Name = "Verdana";
            this.textBox8.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox8.Style.Padding.Bottom = new Telerik.Reporting.Drawing.Unit(0.05000000074505806, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox8.Value = "Servicing Account Handler";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996075332164764, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1000396013259888, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Style.Font.Name = "Verdana";
            this.textBox9.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox9.Value = "=Fields.Clientaddress";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996075332164764, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.3001184463500977, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Style.Font.Name = "Verdana";
            this.textBox10.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox10.Value = "=Fields.ContactCountry";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.17912805080413818, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.800039529800415, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19992129504680634, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Style.Font.Name = "Verdana";
            this.textBox11.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox11.Value = "=Fields.ClaimHandlerDescription";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996090233325958, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(6.2999610900878906, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29976335167884827, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox15.Value = "(This is a computer-generated letter. No signature is required)";
            // 
            // txtFiller1
            // 
            this.txtFiller1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.2000393867492676, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtFiller1.Name = "txtFiller1";
            this.txtFiller1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19968478381633759, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtFiller1.Value = "Encl";
            // 
            // htmlTextBox1
            // 
            this.htmlTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.9999605417251587, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox1.Name = "htmlTextBox1";
            this.htmlTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.279088020324707, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29984250664711, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox1.Style.Font.Bold = true;
            this.htmlTextBox1.Style.Font.Underline = true;
            this.htmlTextBox1.Value = "= \"Re: Claim Document(s)- \" + Fields.ClaimNo";
            // 
            // htmlTextBox2
            // 
            this.htmlTextBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(5.3998031616210938, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox2.Name = "htmlTextBox2";
            this.htmlTextBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2790884971618652, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.60000038146972656, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox2.Value = "<ul><li>Claim Statement</li><li>Pending/Rejected</li><li>Return Original Receipts" +
                "</li></ul><p></p>";
            // 
            // htmlTextBox3
            // 
            this.htmlTextBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.4999608993530273, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox3.Name = "htmlTextBox3";
            this.htmlTextBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.279088020324707, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.69999980926513672, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox3.Value = "<p><strong></strong></p><p><strong></strong></p><p><strong>Employee Benefits Depa" +
                "rtment</strong></p><strong><p><strong>Nova Insurance&nbsp;Consultants Limited</s" +
                "trong></p></strong>";
            // 
            // htmlTextBox4
            // 
            this.htmlTextBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996066391468048, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(2.2998819351196289, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox4.Name = "htmlTextBox4";
            this.htmlTextBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.279088020324707, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.2999213933944702, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox4.Value = resources.GetString("htmlTextBox4.Value");
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.17912805080413818, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(4.0000395774841309, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Name = "textBox11";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.49984264373779297, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.Font.Name = "Verdana";
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Value = "=Fields.SecondaryHandlerDescription";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.20833337306976318, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.69988173246383667, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Name = "textBox3";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.2999210357666016, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Style.Font.Name = "Verdana";
            this.textBox6.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox6.Value = "=Fields.ClientName";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(1.0000005960464478, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtCountry,
            this.txtAddress,
            this.txtMail,
            this.htmlTextBox5});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9378803194267675E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4998817443847656, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtCountry.Style.Font.Bold = true;
            this.txtCountry.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtCountry.Value = "<strong><span style=\"font-size: medium\">htmlTextBox5</span></strong>";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20007896423339844, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtAddress.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtAddress.Value = "<span style=\"font-size: xx-small\">htmlTextBox6</span>";
            // 
            // txtMail
            // 
            this.txtMail.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40015792846679688, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtMail.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
            this.txtMail.Value = "<span style=\"font-size: xx-small\">htmlTextBox7</span>";
            // 
            // htmlTextBox5
            // 
            this.htmlTextBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.020872751250863075, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.7000001072883606, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox5.Name = "htmlTextBox5";
            this.htmlTextBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.4998817443847656, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.htmlTextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.htmlTextBox5.Value = resources.GetString("htmlTextBox5.Value");
            // 
            // ltrClientSettled
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "ltrClientShortfall";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(9.5, Telerik.Reporting.Drawing.UnitType.Point);
            this.Width = new Telerik.Reporting.Drawing.Unit(6.4999604225158691, Telerik.Reporting.Drawing.UnitType.Inch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox txtFiller1;
        private Telerik.Reporting.HtmlTextBox htmlTextBox1;
        private Telerik.Reporting.HtmlTextBox htmlTextBox2;
        private Telerik.Reporting.HtmlTextBox htmlTextBox3;
        private Telerik.Reporting.HtmlTextBox htmlTextBox4;
        private Telerik.Reporting.HtmlTextBox txtCountry;
        private Telerik.Reporting.HtmlTextBox txtAddress;
        private Telerik.Reporting.HtmlTextBox txtMail;
        private Telerik.Reporting.HtmlTextBox htmlTextBox5;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
    }
}