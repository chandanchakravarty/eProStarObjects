using System;
using EtrekReports.text;
using EtrekReports.text.pdf;
using EtrekReports.text.html;
using System.Web;
using System.IO;
using EtrekReports.text.xml;
using System.Xml;
//using System.Object;
//using System.Xml.Linq;
using System.Data;

namespace  Utility.PDFGenerator
{
	/// <summary>
	/// Summary description for EtrekReportEvents.
	/// </summary>
    public class PDFGeneratorEvents : PdfPageEventHelper
    {
        private bool isPageBordered = true;
        private bool isPageNumbered = true;
        private bool isDebitNote = false;
        private bool isUWCopy = false;
        protected bool blPrintFooter = true;
        protected int intPageCnt = 0;
        protected Font fontDocContent = null;
        protected Font fontNote = null;
        protected Font fontNoteItalic = null;
        protected Font fontTimes12B = null;
        protected Font fontTimes8 = null;
        protected Font fontSimsun8 = null;

        protected string strBranchName = "";
        protected string strBranchAddress = "";
        protected string strBranchTelNo = "";
        protected string strBranchFaxNo = "";
        protected string strBranchEmail = "";
        protected string strBranchWebsite = "";
        protected string strCompanyAddl = "";
        protected string strBranchAddl = "";

        protected string strCompanyName = "";
        protected string strAddress = "";
        protected string strTelNo = "";
        protected string strFaxNo = "";
        protected string strEmail = "";
        protected string strWebsite = "";

        protected Image strHeaderLogo = null;
        protected Image strLogo = null;
        protected Image strCIBLogo = null;
        protected string strLogoNote = "";
        protected string strUserBasedAccess = "";

        public string Branchname
        {
            get { return strBranchName; }
            set { strBranchName = value; }
        }
        public string BranchAddress
        {
            get { return strBranchAddress; }
            set { strBranchAddress = value; }
        }
        public string BranchTelno
        {
            get { return strBranchTelNo; }
            set { strBranchTelNo = value; }
        }
        public string BranchFaxNo
        {
            get { return strBranchFaxNo; }
            set { strBranchFaxNo = value; }
        }
        public string BranchEmailid
        {
            get { return strBranchEmail; }
            set { strBranchEmail = value; }
        }
        public string BranchWebsite
        {
            get { return strBranchWebsite; }
            set { strBranchWebsite = value; }
        }
        public string Companyname
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }
        public string Telno
        {
            get { return strTelNo; }
            set { strTelNo = value; }
        }
        public string FaxNo
        {
            get { return strFaxNo; }
            set { strFaxNo = value; }
        }
        public string Emailid
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string Website
        {
            get { return strWebsite; }
            set { strWebsite = value; }
        }
        public Image Logo
        {
            get { return strLogo; }
            set { strLogo = value; }
        }
        public Image CIBLogo
        {
            get { return strCIBLogo; }
            set { strCIBLogo = value; }
        }
        public Image HeaderLogo
        {
            get { return strHeaderLogo; }
            set { strHeaderLogo = value; }
        }
        public string LogoNote
        {
            get { return strLogoNote; }
            set { strLogoNote = value; }
        }
        public bool PageBordered
        {
            get { return isPageBordered; }
            set { isPageBordered = value; }
        }
        public bool ShowPageNumber
        {
            get { return isPageNumbered; }
            set { isPageNumbered = value; }
        }
        public bool DebitNote
        {
            get { return isDebitNote; }
            set { isDebitNote = value; }
        }
        public bool UWCOPY
        {
            get { return isUWCopy; }
            set { isUWCopy = value; }
        }
        public bool PrintFooter
        {
            get
            { return blPrintFooter; }
            set
            { blPrintFooter = value; }
        }
        public string UserBasedAccess
        {
            get { return strUserBasedAccess; }
            set { strUserBasedAccess = value; }
        }
        public PDFGeneratorEvents()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            string strFontpath = HttpContext.Current.Server.MapPath("~/Fonts/simsun.ttc");
            BaseFont bf1 = BaseFont.CreateFont(strFontpath.ToString().Trim() + ",1", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font fontNoteCh = new Font(bf1, 6, Font.NORMAL);
            fontDocContent = FontFactory.GetFont(FontFactory.TIMES, 8, Font.BOLD);
            fontNote = FontFactory.GetFont(FontFactory.TIMES, 6, Font.NORMAL);
            fontNoteItalic = FontFactory.GetFont(FontFactory.TIMES, 8, Font.ITALIC);
            fontTimes12B = FontFactory.GetFont(FontFactory.TIMES, 12, Font.BOLD);
            fontTimes8 = FontFactory.GetFont(FontFactory.TIMES, 8, Font.NORMAL);
            fontSimsun8 = new Font(bf1, 8, Font.NORMAL);

            try
            {
                intPageCnt++;
                Rectangle page = document.PageSize;

                PdfPTable tblHeader = new PdfPTable(1);
                int[] flColWidthHeader = { 25 };
                tblHeader.SetWidths(flColWidthHeader);
                tblHeader.WidthPercentage = 100;
                tblHeader.TotalWidth = page.Width / 4;
                tblHeader.DefaultCell.Border = Rectangle.NO_BORDER;
                tblHeader.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_LEFT;

                PdfPCell pdfcellogoHeader = new PdfPCell(HeaderLogo, true);
                pdfcellogoHeader.PaddingTop = 7;
                pdfcellogoHeader.PaddingLeft = 2;
                pdfcellogoHeader.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                pdfcellogoHeader.Border = Rectangle.NO_BORDER;
                pdfcellogoHeader.Colspan = 1;

                tblHeader.AddCell(pdfcellogoHeader);
                tblHeader.WriteSelectedRows(0, -1, page.Width / 8, page.Height - document.TopMargin + tblHeader.TotalHeight - 50, writer.DirectContent);

                PdfPTable tblFooter = new PdfPTable(4);
                int[] flColWidth = { 5, 5, 5, 5 };
                tblFooter.SetWidths(flColWidth);
                tblFooter.WidthPercentage = 100;
                tblFooter.TotalWidth = page.Width - document.LeftMargin - document.RightMargin - 170;
                tblFooter.DefaultCell.Border = Rectangle.NO_BORDER;
                tblFooter.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

                if (strUserBasedAccess.ToUpper() == "XIMCO")
                {
                    // -- Branch name
                    PdfPCell pdfcelBranch = new PdfPCell();
                    pdfcelBranch.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelBranch.Border = Rectangle.NO_BORDER;
                    pdfcelBranch.Colspan = 2;

                    Paragraph myparaBranch = new Paragraph(strBranchName.Trim(), fontDocContent);
                    myparaBranch.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelBranch.AddElement(myparaBranch);
                    tblFooter.AddCell(pdfcelBranch);

                    // -- Company name
                    PdfPCell pdfcel = new PdfPCell();
                    pdfcel.HorizontalAlignment = Rectangle.ALIGN_CENTER;
                    pdfcel.Border = Rectangle.NO_BORDER;
                    pdfcel.Colspan = 2;

                    Paragraph mypara = new Paragraph(strCompanyName.Trim(), fontDocContent);
                    mypara.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcel.AddElement(mypara);
                    tblFooter.AddCell(pdfcel);

                    //Additional details
                    strCompanyAddl = "上   海   全   安   保   险   经   纪   保   险   公   司";
                    if (strCompanyName != "")
                        strBranchAddl = "(A Member of Professional Ins. Brokers Association Limited)\n";


                    // -- Branch name
                    PdfPCell pdfcelBranchL = new PdfPCell();
                    pdfcelBranchL.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelBranchL.Border = Rectangle.NO_BORDER;
                    pdfcelBranchL.Colspan = 2;

                    Paragraph myparaBranchL = new Paragraph(strCompanyAddl.Trim().Replace(" , ,", ""), fontNoteCh);
                    myparaBranchL.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelBranchL.AddElement(myparaBranchL);
                    tblFooter.AddCell(pdfcelBranchL);

                    // -- Company name
                    PdfPCell pdfcelL = new PdfPCell();
                    pdfcelL.HorizontalAlignment = Rectangle.ALIGN_CENTER;
                    pdfcelL.Border = Rectangle.NO_BORDER;
                    pdfcelL.Colspan = 2;

                    Paragraph myparaL = new Paragraph(strBranchAddl.Trim(), fontNote);
                    myparaL.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelL.AddElement(myparaL);
                    tblFooter.AddCell(pdfcelL);

                    // -- Branch Address
                    PdfPCell pdfcelAddressBranch = new PdfPCell();
                    pdfcelAddressBranch.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelAddressBranch.Border = Rectangle.NO_BORDER;
                    pdfcelAddressBranch.Colspan = 2;

                    Paragraph myparaAddressBranch = new Paragraph(strBranchAddress.Trim().Replace(" , ,", ""), fontNoteCh);
                    myparaAddressBranch.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelAddressBranch.AddElement(myparaAddressBranch);
                    tblFooter.AddCell(pdfcelAddressBranch);

                    // -- Company Address
                    PdfPCell pdfcelAddress = new PdfPCell();
                    pdfcelAddress.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelAddress.Border = Rectangle.NO_BORDER;
                    pdfcelAddress.Colspan = 2;

                    Paragraph myparaAddress = new Paragraph(strAddress.Trim(), fontNoteCh);
                    myparaAddress.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelAddress.AddElement(myparaAddress);
                    tblFooter.AddCell(pdfcelAddress);

                    // Branch Phone and fax
                    PdfPCell pdfcelTelNoBranch = new PdfPCell();
                    pdfcelTelNoBranch.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelTelNoBranch.Border = Rectangle.NO_BORDER;//Rectangle.LEFT_BORDER;
                    pdfcelTelNoBranch.Colspan = 2;

                    Paragraph myparaTelNoBranch = new Paragraph(strBranchTelNo.Trim() + ' ' + strBranchFaxNo.Trim(), fontNote);
                    myparaTelNoBranch.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelTelNoBranch.AddElement(myparaTelNoBranch);
                    tblFooter.AddCell(pdfcelTelNoBranch);

                    // Company Phone and fax
                    PdfPCell pdfcelTelNo = new PdfPCell();
                    pdfcelTelNo.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelTelNo.Border = Rectangle.NO_BORDER;
                    pdfcelTelNo.Colspan = 2;

                    Paragraph myparaTelNo = new Paragraph(strTelNo.TrimEnd() + ' ' + strFaxNo.TrimStart(), fontNote);
                    myparaTelNo.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelTelNo.AddElement(myparaTelNo);
                    tblFooter.AddCell(pdfcelTelNo);

                    // Branch email and website
                    PdfPCell pdfcelEmailBranch = new PdfPCell();
                    pdfcelEmailBranch.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmailBranch.Border = Rectangle.NO_BORDER;//Rectangle.BOX;
                    pdfcelEmailBranch.Colspan = 2;

                    Paragraph myparaEmailBranch = new Paragraph(strBranchEmail, fontNote);
                    myparaEmailBranch.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmailBranch.AddElement(myparaEmailBranch);
                    tblFooter.AddCell(pdfcelEmailBranch);

                    //Company email and website
                    PdfPCell pdfcelEmail = new PdfPCell();
                    pdfcelEmail.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmail.Border = Rectangle.NO_BORDER;
                    pdfcelEmail.Colspan = 2;

                    Paragraph myparaEmail = new Paragraph(strEmail, fontNote);
                    myparaEmail.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmail.AddElement(myparaEmail);
                    tblFooter.AddCell(pdfcelEmail);

                    tblFooter.WriteSelectedRows(0, -1, document.LeftMargin + 125, document.BottomMargin + 50, writer.DirectContent);

                    if (Logo != null)
                    {
                        PdfPTable tblFootImage = new PdfPTable(1);
                        int[] fl3ColWidth = { 5 };
                        tblFootImage.SetWidths(fl3ColWidth);
                        tblFootImage.WidthPercentage = 100;
                        tblFootImage.TotalWidth = page.Width - document.LeftMargin - document.RightMargin - 290;
                        tblFootImage.DefaultCell.Border = Rectangle.NO_BORDER;
                        tblFootImage.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

                        PdfPCell pdfcelCIBlogo = new PdfPCell(Logo);
                        pdfcelCIBlogo.PaddingTop = 7;
                        pdfcelCIBlogo.PaddingLeft = 2;
                        pdfcelCIBlogo.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                        pdfcelCIBlogo.Border = Rectangle.NO_BORDER;
                        pdfcelCIBlogo.Colspan = 1;

                        tblFootImage.AddCell(pdfcelCIBlogo);
                        tblFootImage.WriteSelectedRows(0, -1, document.LeftMargin + 20, document.BottomMargin + 50, writer.DirectContent);
                    }
                }
                else
                {   //For Nova
                    // Company name
                    PdfPCell pdfcell = new PdfPCell();
                    pdfcell.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcell.Border = Rectangle.NO_BORDER;
                    pdfcell.Colspan = 4;

                    Paragraph comppara = new Paragraph(strCompanyName, fontTimes12B);
                    pdfcell.AddElement(comppara);
                    tblFooter.AddCell(pdfcell);

                    // Company Address
                    PdfPCell pdfcellAddress = new PdfPCell();
                    pdfcellAddress.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcellAddress.Border = Rectangle.NO_BORDER;
                    pdfcellAddress.Colspan = 4;

                    Paragraph Addresspara = new Paragraph(strAddress.Replace(" , ,", "").Trim(), fontSimsun8);
                    pdfcellAddress.AddElement(Addresspara);
                    tblFooter.AddCell(pdfcellAddress);

                    // Tel No 
                    PdfPCell pdfcelTel = new PdfPCell();
                    pdfcelTel.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelTel.Border = Rectangle.NO_BORDER;
                    pdfcelTel.Colspan = 2;

                    Paragraph Telpara = new Paragraph(strTelNo, fontTimes8);
                    Telpara.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelTel.AddElement(Telpara);
                    tblFooter.AddCell(pdfcelTel);

                    // FAX
                    PdfPCell pdfcelFAX = new PdfPCell();
                    pdfcelFAX.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelFAX.Border = Rectangle.NO_BORDER;
                    pdfcelFAX.Colspan = 2;

                    Paragraph FAXpara = new Paragraph(strFaxNo, fontTimes8);
                    FAXpara.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelFAX.AddElement(FAXpara);
                    tblFooter.AddCell(pdfcelFAX);

                    // Email
                    PdfPCell pdfcelEmail = new PdfPCell();
                    pdfcelEmail.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmail.Border = Rectangle.NO_BORDER;
                    pdfcelEmail.Colspan = 2;

                    Paragraph Emailpara = new Paragraph(strEmail, fontTimes8);
                    Emailpara.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelEmail.AddElement(Emailpara);
                    tblFooter.AddCell(pdfcelEmail);

                    // Website
                    PdfPCell pdfcelWebsite = new PdfPCell();
                    pdfcelWebsite.HorizontalAlignment = Rectangle.ALIGN_LEFT;
                    pdfcelWebsite.Border = Rectangle.NO_BORDER;
                    pdfcelWebsite.Colspan = 2;

                    Paragraph Websitepara = new Paragraph(strWebsite, fontTimes8);
                    Websitepara.Alignment = Rectangle.ALIGN_LEFT;
                    pdfcelWebsite.AddElement(Websitepara);
                    tblFooter.AddCell(pdfcelWebsite);

                    tblFooter.WriteSelectedRows(0, -1, document.LeftMargin + 80, document.BottomMargin + 110, writer.DirectContent);

                    PdfPTable tblFootNote = new PdfPTable(1);
                    int[] fl4ColWidth = { 50 };
                    tblFootNote.SetWidths(fl4ColWidth);
                    tblFootNote.WidthPercentage = 100;
                    tblFootNote.TotalWidth = page.Width - document.LeftMargin - document.RightMargin - 50;
                    tblFootNote.DefaultCell.Border = Rectangle.NO_BORDER;
                    tblFootNote.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

                    // CIB Logo note

                    //  temprary comment need to be change later
                        //if (!strCompanyName.StartsWith("Beijing Nova") && !strBranchName.StartsWith("Beijing Nova"))
                        //{
                        //    strLogoNote = "     A member of the Hong Kong Confederation of Insurance Brokers\n";

                        //    PdfPCell pdfcelCIBlogNote = new PdfPCell();
                        //    pdfcelCIBlogNote.PaddingTop = 10;
                        //    pdfcelCIBlogNote.HorizontalAlignment = Rectangle.ALIGN_CENTER;
                        //    pdfcelCIBlogNote.Border = Rectangle.NO_BORDER;
                        //    pdfcelCIBlogNote.Colspan = 1;

                        //    Paragraph myparaLogoNote;
                        //    Chunk c1 = new Chunk(strCIBLogo, 0, 0);
                        //    Chunk c2 = new Chunk(strLogoNote, fontTimes8);
                        //    Phrase p1 = new Phrase();
                        //    p1.Add(c1);
                        //    p1.Add(c2);
                        //    myparaLogoNote = new Paragraph(p1);

                        //    myparaLogoNote.Alignment = Rectangle.ALIGN_LEFT;
                        //    pdfcelCIBlogNote.AddElement(myparaLogoNote);
                        //    tblFootNote.AddCell(pdfcelCIBlogNote);

                        //    tblFootNote.WriteSelectedRows(0, -1, document.LeftMargin + 80, document.BottomMargin + 30, writer.DirectContent);
                        //}
                    
                    // Draw a rectangular box around Debit Note/Credit Advice Header
                    Graphic grx = new Graphic();
                    if (isDebitNote)
                    {
                        grx.Rectangle(240, 710, 120, 30);
                        grx.Stroke();
                        document.Add(grx);
                    }
                    if (isUWCopy)
                    {
                        grx.Rectangle(355, 710, 188, 30);
                        grx.Stroke();
                        document.Add(grx);
                    }
                }

                PdfContentByte cb = writer.DirectContent;
                if (isPageNumbered)
                {
                    cb.BeginText();
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.SetFontAndSize(bf, 9);
                    cb.SetTextMatrix(275, 10);
                    cb.ShowText("- " + document.PageNumber.ToString() + " -");
                    cb.EndText();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void WritePDF(string FileName, string TextToWrite, Rectangle pageSize, bool landscape)
        {
            string filePath = HttpContext.Current.Server.MapPath("PDF");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += "/" + FileName + ".pdf";
            Document document = new Document();
            if (landscape)
                document.SetPageSize(pageSize.Rotate());
            else
                document.SetPageSize(pageSize);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();
            EtrekReports.text.html.simpleparser.HTMLWorker hw = new EtrekReports.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(TextToWrite));
            
            document.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filePath);
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.WriteFile(filePath);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
        }

        //
        public void WriteXMLToPDF(string FileName, string TextToWrite, Rectangle pageSize, bool landscape)
        {

            string filePath = HttpContext.Current.Server.MapPath("PDF");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += "/" + FileName + ".pdf";
            Document document = new Document();
            if (landscape)
                document.SetPageSize(pageSize.Rotate());
            else
                document.SetPageSize(pageSize);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();
            //EtrekReports.text.html.simpleparser.HTMLWorker hw = new EtrekReports.text.html.simpleparser.HTMLWorker(document);
            //hw.Parse(new StringReader(TextToWrite));
            //ITextHandler xmlHandler = new ITextHandler(document);
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(TextToWrite); // error thrown here
            //XDocument doc;
            // using (StringReader s = new StringReader(TextToWrite))
            //{
            //    doc = XDocument.Load(s);
            //}
            ITextHandler xmlHandler = new ITextHandler(document);

            // step 4: we parse the document
            xmlHandler.Parse(TextToWrite);






            document.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filePath);
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.WriteFile(filePath);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
        }



    }
}
