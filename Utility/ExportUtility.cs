using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EtrekReports.text.html.simpleparser;
using EtrekReports.text.pdf;


public class GridViewExportUtil
{
    public static void Export(string fileName, GridView gv, string LoginName, string withRender, string[] relData,string DateFormat)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                Table table = new Table();

                table.GridLines = gv.GridLines;

                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }
                table.RenderControl(htw);

                if (withRender.ToUpper() == "REN")
                    rptRenewalListstyle(LoginName, DateFormat);
                else if (withRender.ToUpper() == "CLINV")
                    rptInvoiceListstyle(LoginName,DateFormat);
                else if (withRender.ToUpper() == "BKR")
                    rptBrokeragestyle(LoginName, DateFormat);
                else if (withRender.ToUpper() == "OCL")
                    rptOutstandingClaimListstyle(LoginName, relData, DateFormat);
                if (withRender.ToUpper() == "OSCP")
                    rptOSLossesClaimPaymentheader(LoginName, (relData[0] == null ? "" : relData[0].ToString()), (relData[1] == null ? "" : relData[1].ToString()), DateFormat);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    public static void ExportPDFContrlReport(string fileName, GridView gv, string LoginName, string withRender, string[] relData)
    {
        HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        //HttpContext.Current.Response.ContentType = "application/ms-excel";
        //HttpContext.Current.Response.ContentType = "application/pdf";

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".pdf");
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                Table table = new Table();

                //table.GridLines = gv.GridLines;

                if (gv.HeaderRow != null)
                {
                    gv.HeaderStyle.Font.Bold = true;
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    gv.HeaderRow.Font.Bold = true;
                    table.Rows.Add(gv.HeaderRow);
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }
                table.RenderControl(htw);

                //table.HeaderRow.Style.Add("width", "15%");
                //gvData.HeaderRow.Style.Add("font-size", "10px");
                //gvData.Style.Add("text-decoration", "none");
                //gvData.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                //gvData.Style.Add("font-size", "8px");

                StringReader sr = new StringReader(sw.ToString());
                StringReader sr1 = new StringReader(withRender);
                EtrekReports.text.Document pdfDoc = new EtrekReports.text.Document(EtrekReports.text.PageSize.A2, 7f, 7f, 7f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);

                pdfDoc.Open();

                //Read string contents using stream reader and convert html to parsed content
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(withRender), null);

                //Get each array values from parsed elements and add to the PDF document
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as EtrekReports.text.IElement);
               // htmlparser.Parse(sr1);
                htmlparser.Parse(sr);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();

                //if (withRender.ToUpper() == "REN")
                //    rptRenewalListstyle(LoginName);
                //else if (withRender.ToUpper() == "CLINV")
                //    rptInvoiceListstyle(LoginName);
                //else if (withRender.ToUpper() == "BKR")
                //    rptBrokeragestyle(LoginName);
                //else if (withRender.ToUpper() == "OCL")
                //    rptOutstandingClaimListstyle(LoginName, relData);
                //if (withRender.ToUpper() == "OSCP")
                //    rptOSLossesClaimPaymentheader(LoginName, (relData[0] == null ? "" : relData[0].ToString()), (relData[1] == null ? "" : relData[1].ToString()));
                //HttpContext.Current.Response.Write(sw.ToString());
                //HttpContext.Current.Response.End();
            }
        }
    }

    public static void ExportFromGrid(GridView gvData, string fileName, HttpResponse Response,Page _Page)
    {
        if (gvData != null)
        {
            
            if (gvData.Rows.Count > 0)
            {
                
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToShortDateString() + ".xls");
                Response.Charset = "";
                _Page.EnableViewState = false;
                //grdPolicyUWPlanPremRatesDtls.ShowHeader = false;
                //If you want the option to open the Excel file without saving than 
                //comment out the line below 
                //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache); 
                // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //<%@ Page Language="C#" EnableEventValidation ="false"
                Response.Buffer = true;
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter ExcelHtmlWriter = new HtmlTextWriter(stringWrite);
                gvData.HeaderStyle.BackColor = System.Drawing.Color.Orange;
                gvData.HeaderRow.Enabled = false;
                gvData.Columns[gvData.Columns.Count - 1].Visible = false;
                gvData.RenderControl(ExcelHtmlWriter);
                string style = @"<style> .text { mso-number-format:0\.00;text-align:right; } </style> ";
                Response.Write(style);
                Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'></font></td></tr></Table> ");

                Response.Write(stringWrite.ToString());
                gvData.ShowHeader = true;
                Response.Flush();
                Response.End();
            }
        }
    }
    public static void ExportFromGrid(GridView gvData, string fileName, HttpResponse Response, Page _Page,string PageName)
    {
        if (gvData != null)
        {

            if (gvData.Rows.Count > 0)
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToShortDateString() + ".xls");
                Response.Charset = "";
                _Page.EnableViewState = false;
                //grdPolicyUWPlanPremRatesDtls.ShowHeader = false;
                //If you want the option to open the Excel file without saving than 
                //comment out the line below 
                //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache); 
                // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //<%@ Page Language="C#" EnableEventValidation ="false"
                Response.Buffer = true;
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter ExcelHtmlWriter = new HtmlTextWriter(stringWrite);
                gvData.HeaderStyle.BackColor = System.Drawing.Color.Orange;
                gvData.HeaderRow.Enabled = false;
                gvData.Columns[gvData.Columns.Count - 1].Visible = false;
                if (PageName.Contains("frmDebitNoteEnquiry"))
                {
                    gvData.Columns[12].Visible = true;
                    gvData.Columns[gvData.Columns.Count - 2].Visible = false;
                    gvData.Columns[gvData.Columns.Count - 3].Visible = false;
                }
                gvData.RenderControl(ExcelHtmlWriter);
                string style = @"<style> .text { mso-number-format:0\.00;text-align:right; } </style> ";
                Response.Write(style);
                Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'></font></td></tr></Table> ");

                Response.Write(stringWrite.ToString());
                gvData.ShowHeader = true;
                Response.Flush();
                Response.End();
            }
        }
    }
    private static void rptRenewalListstyle(string LoginName,string DateFormat)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>INTERNATIONAL</b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b> REINSURANCE </b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>MANAGEMENT LIMITED </b></font></td></tr></Table><br/>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'><b>Renewal/Expiry List</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Print Date and Time : " +  System.DateTime.Now.ToString(DateFormat+" hh:mm:ss") + "</font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Login : " + LoginName + "</font></td></tr></Table><br/><br/><br/>");
    }

    private static void rptInvoiceListstyle(string LoginName, string DateFormat)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Company : <b>INTERNATIONAL</b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b> REINSURANCE </b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>MANAGEMENT LIMITED </b></font></td></tr></Table><br/>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Report : <b>Claim Invoice Report</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Print Date : " + System.DateTime.Now.ToString(DateFormat+" hh:mm:ss") + "</font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Login : " + LoginName + "</font></td></tr></Table><br/><br/><br/>");
    }
   
    private static void rptOutstandingClaimListstyle(string LoginName, string [] reldata,string DateFormat)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Report : <b>Outstanding Claims Report</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Broker : <b>ALL</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Cedant : <b>ALL</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Reinsurer : <b>" + reldata[1] + "(" + reldata[0] + ")</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Print Date and Time: <b>" + System.DateTime.Now.ToString(DateFormat+" hh:mm:ss") + "</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Login : <b>" + LoginName + "</b></font></td></tr></Table><br/><br/><br/>");
    }

    private static void rptBrokeragestyle(string LoginName, string DateFormat)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Company : <b>INTERNATIONAL</b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b> REINSURANCE </b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>MANAGEMENT LIMITED </b></font></td></tr></Table><br/>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Report : <b>Brokerage Report</b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Print Date : " + System.DateTime.Now.ToString(DateFormat+" hh:mm:ss") + "</font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Login : " + LoginName + "</font></td></tr></Table><br/><br/><br/>");
    }

    private static void rptOSLossesClaimPaymentheader(string LoginName, string Address, string CityName,string DateFormat)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Company :</font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>INTERNATIONAL</b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b> REINSURANCE </b></font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='4'><b>MANAGEMENT LIMITED </b></font></td></tr></Table><br/>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>To : " + Address + "</font></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'>Report : <b>O/S Losses & Claims </b></font></td></td><td width = '100%' align = 'Left'><font face='verdana, arial' size='2'><b>Payment Bordereau </b></font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>&nbsp;" + CityName + "</font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Print Date : " + System.DateTime.Now.ToString(DateFormat+" hh:mm:ss") + "</font></td></tr></Table>");
        HttpContext.Current.Response.Write("<table><tr><td width = '100%' align = 'Left'><font face='verdana, arial' size='1'>Login : " + LoginName + "</font></td></tr></Table><br/><br/><br/>");
 
    }
    public static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExport(current);
            }
        }
    }

}

//ExcelHelper.cs

public class ExcelHelper
{
    //Row limits older excel verion per sheet, the row limit for excel 2003 is 65536
    const int rowLimit = 65000;

    private static string getWorkbookTemplate()
    {
        var sb = new StringBuilder(818);
        sb.AppendFormat(@"<?xml version=""1.0""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<?mso-application progid=""Excel.Sheet""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:o=""urn:schemas-microsoft-com:office:office""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:x=""urn:schemas-microsoft-com:office:excel""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:html=""http://www.w3.org/TR/REC-html40"">{0}", Environment.NewLine);
        sb.AppendFormat(@" <Styles>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""Default"" ss:Name=""Normal"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Alignment ss:Vertical=""Bottom""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Borders/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Interior/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <NumberFormat/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Protection/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""s62"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#ffffff""{0}", Environment.NewLine);
        sb.AppendFormat(@"    ss:Bold=""1""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"    <Interior ss:Color=""#666666"" ss:Pattern=""Solid""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""s63"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <NumberFormat ss:Format=""Short Date""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);

        sb.AppendFormat(@" <Style ss:ID=""s64"">{0}", Environment.NewLine); // redmine #34160
        sb.AppendFormat(@" <NumberFormat ss:Format=""#,##0.00""/>{0}", Environment.NewLine);
        sb.AppendFormat(@" </Style>{0}", Environment.NewLine);
        
        sb.AppendFormat(@" </Styles>{0}", Environment.NewLine);
        sb.Append(@"{0}\r\n</Workbook>");
        return sb.ToString();
    }

    private static string replaceXmlChar(string input)
    {
        input = input.Replace("&", "&amp");
        input = input.Replace("<", "&lt;");
        input = input.Replace(">", "&gt;");
        input = input.Replace("\"", "&quot;");
        input = input.Replace("'", "&apos;");
        return input;
    }

    private static string getCell(Type type, object cellData)
    {
        var data = (cellData is DBNull) ? "" : cellData;
        if (type.Name.Contains("Int") || type.Name.Contains("Double") || type.Name.Contains("Decimal"))
            if (type.Name.Contains("Decimal"))
            {
                return string.Format("<Cell ss:StyleID=\"s64\"><Data ss:Type=\"Number\">{0}</Data></Cell>", !string.IsNullOrEmpty(Convert.ToString(data))? Math.Round(Convert.ToDecimal(data), 2): 0 );
            }
            else
	        {
                return string.Format("<Cell><Data ss:Type=\"Number\">{0}</Data></Cell>", data);
	        }
           
        if (type.Name.Contains("Date") && data.ToString() != string.Empty)
        {
            return string.Format("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"DateTime\">{0}</Data></Cell>", Convert.ToDateTime(data).ToString("yyyy-MM-dd"));
        }
        return string.Format("<Cell><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(data.ToString()));
    }

    private static string getWorksheets(DataSet source)
    {
        var sw = new StringWriter();
        if (source == null || source.Tables.Count == 0)
        {
            sw.Write("<Worksheet ss:Name=\"Sheet1\">\r\n<Table>\r\n<Row><Cell><Data ss:Type=\"String\"></Data></Cell></Row>\r\n</Table>\r\n</Worksheet>");
            return sw.ToString();
        }
        foreach (DataTable dt in source.Tables)
        {
            if (dt.Rows.Count == 0)
                sw.Write("<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) + "\">\r\n<Table>\r\n<Row><Cell  ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell></Row>\r\n</Table>\r\n</Worksheet>");
            else
            {
                //write each row data                
                var sheetCount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((i % rowLimit) == 0)
                    {
                        //add close tags for previous sheet of the same data table
                        if ((i / rowLimit) > sheetCount)
                        {
                            sw.Write("\r\n</Table>\r\n</Worksheet>");
                            sheetCount = (i / rowLimit);
                        }
                        sw.Write("\r\n<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) +
                                 (((i / rowLimit) == 0) ? "" : Convert.ToString(i / rowLimit)) + "\">\r\n<Table>");
                        //write column name row
                        sw.Write("\r\n<Row>");
                        foreach (DataColumn dc in dt.Columns)
                            sw.Write(string.Format("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName)));
                        sw.Write("</Row>");
                    }
                    sw.Write("\r\n<Row>");
                    foreach (DataColumn dc in dt.Columns)
                        sw.Write(getCell(dc.DataType, dt.Rows[i][dc.ColumnName]));
                    sw.Write("</Row>");
                }
                sw.Write("\r\n</Table>\r\n</Worksheet>");
            }
        }

        return sw.ToString();
    }

    public static string GetExcelXml(DataTable dtInput, string filename)
    {
        var excelTemplate = getWorkbookTemplate();
        var ds = new DataSet();
        ds.Tables.Add(dtInput.Copy());
        var worksheets = getWorksheets(ds);
        var excelXml = string.Format(excelTemplate, worksheets);
        return excelXml;
    }

    public static string GetExcelXml(DataSet dsInput, string filename)
    {
        var excelTemplate = getWorkbookTemplate();
        var worksheets = getWorksheets(dsInput);
        var excelXml = string.Format(excelTemplate, worksheets);
        return excelXml;
    }

    public static void ToExcel(DataSet dsInput, string filename, HttpResponse response)
    {
        var excelXml = GetExcelXml(dsInput, filename);
        response.Clear();
        response.AppendHeader("Content-Type", "application/vnd.ms-excel");
        response.AppendHeader("Content-disposition", "attachment; filename=" + filename);
        response.Write(excelXml);
        response.Flush();
        response.End();
    }

    public static void ToExcel(DataTable dtInput, string filename, HttpResponse response)
    {
        var ds = new DataSet();
        ds.Tables.Add(dtInput.Copy());
        ToExcel(ds, filename, response);
    }
}

