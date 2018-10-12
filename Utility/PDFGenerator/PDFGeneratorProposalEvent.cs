using System;
using System.Collections.Generic;
using System.Text;
using EtrekReports.text;
using EtrekReports.text.pdf;

namespace Utility.PDFGenerator
{
    public class PDFGeneratorProposalEvent : PdfPageEventHelper
    {
        protected string strLogoFilePath = "";
        protected string strStampFilePath = "";
        protected string strSignatureFilePath = "";
        protected string strPageCopiesName = "";
        protected bool blPrintFooter = true;
        protected int intPageCnt = 0;
        protected Font fontDocContentBOLD = null;
        protected Font fontDocContentNote = null;
        protected Font fontDocContent = null;        
        protected Font fontDocNormal = null;
        protected Font fontDocNormalNote = null;
        protected Font fontDocContentSmall = null;
        protected string strCompanyName = "";
        protected string strCompanyAdd1 = "";
        protected string strCompanyAdd2 = "";
        protected string strCompanyAdd3 = "";
        protected string strCompanyAdd4 = "";
        protected string strCompanyAdd5 = "";        

        public PDFGeneratorProposalEvent()
        { 
        }
        public PDFGeneratorProposalEvent(string LogoFilePath)
        {
            strLogoFilePath = LogoFilePath;			
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            fontDocContent = FontFactory.GetFont("Arial", 18, Font.NORMAL);
            fontDocContentBOLD = FontFactory.GetFont("Arial", 18, Font.BOLD);
            fontDocNormal = FontFactory.GetFont("Arial", 8, Font.BOLD);
            fontDocNormalNote = FontFactory.GetFont("Arial", 9, Font.BOLD);
            fontDocContentNote = FontFactory.GetFont("CourierNew", 9, Font.BOLD);
            strCompanyName = "MSIG Insurance (Singapore) Pte. Ltd.";
            strCompanyAdd1 = "(Company Registration No. 200412212G)";
            strCompanyAdd2 = "4 Shenton Way #21-01 SGX Centre 2 Singapore 068807";
            strCompanyAdd3 = "Tel : 68277888 Fax : 68277800 www.msig.com.sg";
            try
            {
                intPageCnt++;

                Rectangle page = document.PageSize;

                PdfPTable tblHeader = new PdfPTable(3);
                int[] flColWidth = { 12, 73, 15 };
                tblHeader.SetWidths(flColWidth);
                tblHeader.WidthPercentage = 100;
                tblHeader.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;
                tblHeader.DefaultCell.Border = Rectangle.NO_BORDER;
                tblHeader.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

                PdfPCell pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_TOP;
                pdfcel.Border = Rectangle.NO_BORDER;
                int[] iTransp1 = { 0, 0 };
                Image imgLogo = Image.GetInstance(strLogoFilePath);
                imgLogo.ScalePercent(90F);
                imgLogo.Transparency = iTransp1;
                pdfcel.AddElement(imgLogo);
                tblHeader.AddCell(pdfcel);

                pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_TOP;
                pdfcel.Border = Rectangle.NO_BORDER;
                Paragraph mypara = new Paragraph(strCompanyName + "\n", fontDocContent);
                mypara.Leading = 15;
                Paragraph paraAddr = new Paragraph(strCompanyAdd1 + "\n", fontDocNormal);
                paraAddr.Add(new Phrase(strCompanyAdd2 + "\n" + strCompanyAdd3, fontDocNormalNote));
                paraAddr.Leading = 10;
                pdfcel.AddElement(mypara);
                pdfcel.AddElement(paraAddr);
                tblHeader.AddCell(pdfcel);

                pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_TOP;
                pdfcel.Border = Rectangle.NO_BORDER;                
                tblHeader.AddCell(pdfcel);
                tblHeader.WriteSelectedRows(0, -1, document.LeftMargin, 835, writer.DirectContent);


                pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_JUSTIFIED;
                pdfcel.Border = Rectangle.NO_BORDER;

                PdfPTable tblfooter = new PdfPTable(5);
                int[] flColWidth1 = { 49, 3, 14, 18, 16 };
                tblfooter.SetWidths(flColWidth1);
                tblfooter.WidthPercentage = 100;
                tblfooter.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;
                tblfooter.DefaultCell.Border = Rectangle.NO_BORDER;
                tblfooter.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

                pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_JUSTIFIED;
                pdfcel.Border = Rectangle.NO_BORDER;

                Paragraph paraFooter1 = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER, 6, Font.UNDERLINE, Color.RED));
                paraFooter1.FirstLineIndent = 10;
                paraFooter1.Leading = 6;
                paraFooter1.Alignment = Element.ALIGN_CENTER;
                paraFooter1.Font.SetStyle(1);
                pdfcel.AddElement(paraFooter1);                
                tblfooter.AddCell(pdfcel);

                pdfcel = new PdfPCell();
                pdfcel.HorizontalAlignment = Rectangle.ALIGN_JUSTIFIED;
                pdfcel.Border = Rectangle.NO_BORDER;
                tblfooter.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin + 270,writer.DirectContent);
                
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
