namespace eProStarReports.Letters
{
    using System;
    using System.Data;
    using System.Web;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Reflection;

    /// <summary>
    /// Summary description for PrintDebitNote.
    /// </summary>
    public partial class PrintCoverNote : Telerik.Reporting.Report
    {
        public PrintCoverNote()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public PrintCoverNote(DataSet dsSlip, string CalledFrom, string sCopyFor, DataTable finalSlipData)
        {
            InitializeComponent();

            //COMPANY DETAILS
            if (dsSlip.Tables[1].Rows.Count > 0)
            {
                textBox9.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyName"]);
                textBox11.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd1"]);
                textBox13.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd2"]);
                textBox15.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd3"]);
                textBox16.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd4"]);
                textBox17.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["EMail"]);
            }

            if (CalledFrom == "Quotation")
                textBox7.Value = "QUOTATION SLIP";
            else
                textBox7.Value = "CLOSING SLIP";

            textBox8.Value = sCopyFor;

            if (finalSlipData != null && finalSlipData.Rows.Count > 0)
            {
                table1.DataSource = finalSlipData;
            }

            //LegislationNote
            if (dsSlip.Tables[8] != null && dsSlip.Tables[8].Rows.Count > 0)
            {
                if (CalledFrom == "Quotation")
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;

                    textBox38.Value = Convert.ToString(dsSlip.Tables[8].Rows[0]["LegislationNote"]);

                    if (sCopyFor == "For Underwriter")
                    {
                        textBox4.Visible = false;
                        textBox38.Visible = false;
                        textBox5.Visible = false;
                    }
                    else
                    {
                        textBox4.Visible = true;
                        textBox38.Visible = true;
                        textBox5.Visible = true;
                    }
                }
                else
                {
                    textBox4.Visible = false;
                    textBox38.Visible = false;
                    textBox5.Visible = false;

                    textBox2.Value = Convert.ToString(dsSlip.Tables[8].Rows[0]["LegislationNote"]);

                    if (sCopyFor == "For Underwriter")
                    {
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                    }
                    else
                    {
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                    }

                }
            }
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = (Telerik.Reporting.Processing.Table)sender;
            Telerik.Reporting.Processing.ITableCell cell = null;
            foreach (Telerik.Reporting.Processing.TableRow row in table.Rows)
            {
                for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                {
                    cell = null;
                    cell = row.GetCell(colIndex);
                    if (cell.RowIndex == row.Index)
                    {
                        Telerik.Reporting.Processing.ReportItem item = cell.Item;

                        // Here you can do something with the report item
                        if (((Telerik.Reporting.Processing.TextBox)(item)).Text == "Quotation No." || ((Telerik.Reporting.Processing.TextBox)(item)).Text == "Address")
                        {
                            //colIndex = colIndex + 1; // second column
                            //cell = row.GetCell(colIndex);
                            ////cell.Item.Width = cell.Item.Width.Add(Telerik.Reporting.Drawing.Unit.Inch(1.2673234939575195D));
                            ////cell.Item.Size = new SizeU() { Width = Telerik.Reporting.Drawing.Unit.Inch(3.2673234939575195D) };

                            //Telerik.Reporting.HtmlTextBox textBoxTable = new Telerik.Reporting.HtmlTextBox();
                            //textBoxTable.Value = ((Telerik.Reporting.Processing.TextBox)(cell.Item)).Text; //"=Fields." + dt2.Columns[i].ColumnName;
                            //textBoxTable.Size = new SizeU(Unit.Inch(4.2), cell.Item.Height);
                            //table1.Body.SetCellContent(row.Index, colIndex, textBoxTable, 1, 2);

                            //colIndex = colIndex + 1; // third column
                            //cell = row.GetCell(colIndex);
                            //cell.Item.Visible = false;
                        }
                    }
                    else
                    {
                        // Do nothing. This is part of a merged table cell.
                    }
                }
            }
        }

        private static PropertyInfo RowHeightProperty = typeof(Telerik.Reporting.Processing.TableRow).GetProperty("Height", BindingFlags.Instance | BindingFlags.NonPublic);

        private void detail_ItemDataBound(object sender, EventArgs e)
        {
            //Telerik.Reporting.Processing.DetailSection detail = (Telerik.Reporting.Processing.DetailSection)sender;
            //Telerik.Reporting.Processing.TextBox txtHierarchicalEntityID = (Telerik.Reporting.Processing.TextBox)detail.ChildElements.Find("txtHierarchicalEntityID", true)[0];
            //Telerik.Reporting.Processing.Table tblReport = (Telerik.Reporting.Processing.Table)detail.ChildElements.Find("tblReport", true)[0];

            //int hierarchicalEntityID = Convert.ToInt32(txtHierarchicalEntityID.Text);

            //dsReporting dsBindingData = new dsReporting();

            //foreach (dsReporting.AssessmentResultsChartRow currRow in dsRaw.AssessmentResultsChart.Rows)
            //    if ((int)currRow["HierarchicalEntityID"] == hierarchicalEntityID)
            //        dsBindingData.AssessmentResultsChart.ImportRow(currRow);

            //dsBindingData.AcceptChanges();

            //tblReport.DataSource = dsBindingData.AssessmentResultsChart;
        }

        //public PrintCoverNote(DataSet dsSlip, DataTable dtTopHeaderDetails, string CalledFrom, string sCopyFor, DataSet dsRiskDetails, DataSet dsCondition, DataSet dsWarranties, DataSet dsMajor, DataTable dtExcessDeductable)
        //{
        //    InitializeComponent();

        //    //COMPANY DETAILS
        //    if (dsSlip.Tables[1].Rows.Count > 0)
        //    {
        //        textBox1.Value = dsSlip.Tables[1].Rows[0]["CompanyName"].ToString();
        //        textBox2.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd1"]);
        //        textBox3.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd2"]);
        //        textBox4.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd3"]);
        //        textBox5.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["CompanyAdd4"]);
        //        textBox6.Value = Convert.ToString(dsSlip.Tables[1].Rows[0]["EMail"]);
        //    }

        //    if (CalledFrom == "Quotation")
        //        textBox7.Value = "QUOTATION SLIP";
        //    else
        //        textBox7.Value = "CLOSING SLIP";

        //    textBox8.Value = sCopyFor;

        //    //TOP DETAILS
        //    if (dtTopHeaderDetails != null && dtTopHeaderDetails.Rows.Count > 0)
        //    {
        //        //panel2.Visible = true;
        //        table1.DataSource = dtTopHeaderDetails;
        //    }

        //    //Risk Location(s)
        //    textBox9.Value = "Risk Location(s)";
        //    if (dsSlip.Tables[4] != null && dsSlip.Tables[4].Rows.Count > 0)
        //    {
        //        //panel3.Visible = true;
        //        table2.DataSource = dsSlip.Tables[4];
        //    }

        //    //Risk Details
        //    if (dsRiskDetails.Tables[0] != null && dsRiskDetails.Tables[0].Rows.Count > 0)
        //    {
        //        //panel4.Visible = true;
        //        table3.DataSource = dsRiskDetails.Tables[0];
        //    }

        //    //Dynamic Risk Template
        //    textBox13.Value = "Dynamic Risk Template";
        //    if (dsSlip.Tables[5] != null && dsSlip.Tables[5].Rows.Count > 0)
        //    {
        //        //panel1.Visible = true;
        //        table4.DataSource = dsSlip.Tables[5];
        //    }

        //    //Condition
        //    textBox25.Value = "Condition(s)";
        //    if (dsCondition.Tables[0] != null && dsCondition.Tables[0].Rows.Count > 0)
        //    {
        //        //table5.Visible = true;
        //        table5.DataSource = dsCondition.Tables[0];
        //    }

        //    //Major Exclusion(s)
        //    textBox16.Value = "Major Exclusion(s)";
        //    if (dsMajor.Tables[0] != null && dsMajor.Tables[0].Rows.Count > 0)
        //    {
        //        //table6.Visible = true;
        //        table6.DataSource = dsMajor.Tables[0];
        //    }

        //    //Warranties
        //    textBox21.Value = "Warranties";
        //    if (dsWarranties.Tables[0] != null && dsWarranties.Tables[0].Rows.Count > 0)
        //    {
        //        //table7.Visible = true;
        //        table7.DataSource = dsWarranties.Tables[0];
        //    }

        //    //Excess Deductable
        //    textBox24.Value = "Excess Deductable";
        //    if (dtExcessDeductable != null && dtExcessDeductable.Rows.Count > 0)
        //    {
        //        //table8.Visible = true;
        //        table8.DataSource = dtExcessDeductable;
        //    }
        //    if (dsSlip.Tables[7] != null && dsSlip.Tables[7].Rows.Count > 0)
        //    {
        //        textBox34.Value = Convert.ToDecimal(dsSlip.Tables[7].Rows[0]["TotalSumInsured"]).ToString("#,##0.00");
        //        textBox35.Value = Convert.ToDecimal(dsSlip.Tables[7].Rows[0]["TotalPremium"]).ToString("#,##0.00");
        //        textBox36.Value = Convert.ToDecimal(dsSlip.Tables[7].Rows[0]["UWBrokerageAmount"]).ToString("#,##0.00");
        //        textBox37.Value = Convert.ToString(dsSlip.Tables[7].Rows[0]["UnderwriterName"]);
        //    }

        //    //LegislationNote
        //    if (dsSlip.Tables[8] != null && dsSlip.Tables[8].Rows.Count > 0)
        //    {
        //        textBox38.Value = Convert.ToString(dsSlip.Tables[8].Rows[0]["LegislationNote"]);
        //        if (sCopyFor == "For Underwriter")
        //            textBox38.Visible = false;
        //        else
        //            textBox38.Visible = true;
        //    }
        //}
    }
}