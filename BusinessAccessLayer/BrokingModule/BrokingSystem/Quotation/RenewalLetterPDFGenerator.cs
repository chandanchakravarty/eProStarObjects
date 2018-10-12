using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EtrekReports.text;
using EtrekReports.text.pdf;
using Utility.PDFGenerator;
using Utility;
using BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using System.IO;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class RenewalLetterPDFGenerator : PDFGeneratorBase
    {
        protected PDFGeneratorEvents ereEvents = null;
        protected Cell clCurrCell = null;
        private string strText = "";
        CoverNoteManager objCoverNoteBI = new CoverNoteManager();
        QuotationManager objQuotationManager = new QuotationManager();
        protected string Attention = "";
        protected string UserName = "";
        protected string UserDesignation = "";
        protected string Address1 = "";
        protected string Address2 = "";
        protected string Address3 = "";
        protected string ContentHeader = "";
        protected string ContentSubject = "";
        protected string ContentPara1 = "";
        protected string ContentPara2 = "";
        protected string ContentPara3 = "";
        protected string ContentPara4 = "";
        protected string ContentFooter = "";
        protected string CoverNoteNo = "";
        protected string POIFromDate = "";
        protected string POIToDate = "";
        protected string ClientName = "";
      


        public bool CreateRenewalLetterPDF(clsQuotation objQuotation,int userId)
        {
            bool blCreationSuccess = true;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();

                
                DataSet dsRenLetterInfo = new DataSet();
                dsRenLetterInfo = objCoverNoteBI.GetRenewalLetterInfo(objQuotation, userId);
                foreach (DataRow dRow in dsRenLetterInfo.Tables[1].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    Attention = dsRenLetterInfo.Tables[1].Rows[0]["ClientName"].ToString();
                    UserName = dsRenLetterInfo.Tables[1].Rows[0]["AuthName"].ToString();
                    UserDesignation = dsRenLetterInfo.Tables[1].Rows[0]["AuthDesignation"].ToString();
                    Address1 = dsRenLetterInfo.Tables[1].Rows[0]["Address1"].ToString();
                    Address2 = dsRenLetterInfo.Tables[1].Rows[0]["Address2"].ToString();
                    Address3 = dsRenLetterInfo.Tables[1].Rows[0]["Address3"].ToString();
                    ContentHeader = dsRenLetterInfo.Tables[1].Rows[0]["Header"].ToString();
                    ContentSubject = dsRenLetterInfo.Tables[1].Rows[0]["ContentSubject"].ToString();
                    ContentPara1 = dsRenLetterInfo.Tables[1].Rows[0]["Para1"].ToString();
                    ContentPara2 = dsRenLetterInfo.Tables[1].Rows[0]["Para2"].ToString();
                    ContentPara3 = dsRenLetterInfo.Tables[1].Rows[0]["Para3"].ToString();
                    ContentPara4 = dsRenLetterInfo.Tables[1].Rows[0]["Para4"].ToString();
                    ContentFooter = dsRenLetterInfo.Tables[1].Rows[0]["Footer"].ToString();
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateRenewalPDF(dRow);
                    docPDF.NewPage();
                }
                DataSet dsPolicyDetail = new DataSet();
                dsPolicyDetail = objQuotationManager.LoadQuotationClientDetail(objQuotation);
                foreach (DataRow dRow in dsPolicyDetail.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    ClientName = dsPolicyDetail.Tables[0].Rows[0]["ClientName"].ToString();
                    POIFromDate = dsPolicyDetail.Tables[0].Rows[0]["POIFromDate1"].ToString();
                    POIToDate = dsPolicyDetail.Tables[0].Rows[0]["POIToDate1"].ToString();
                    CoverNoteNo = dsPolicyDetail.Tables[0].Rows[0]["PolicyNo"].ToString();
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreatePolicyDetailPDF(dRow);
                    docPDF.NewPage();
                   
                }
               
            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;
        }
        protected void createAndOpenNewDoc()
        {
            docPDF = new Document(PageSize.A4, mintLeftBorder, mintRightBorder, mintTopBorder, mintBottomBorder);
            createDirectory(strPDFFilePath);
            FileStream fsPDFStream = new FileStream(strPDFFilePath, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPDF, fsPDFStream);
            pdfWriter.PageEvent = ereEvents;
            docPDF.Open();
            isPDFCreated = true;
        }
        private void createDirectory(string path)
        {
            string dirInfo = Path.GetDirectoryName(path);
            if (Directory.Exists(dirInfo) == false)
            {
                try
                {
                    Directory.CreateDirectory(dirInfo);
                }
                catch
                {
 
                }
            }
        }
        private void CreateRenewalPDF(DataRow dr)
        {
            PdfPTable tblContent = getRenLetterTable();
           // PdfPTable tblContent = new PdfPTable(1);
           //// tblContent.AutoFillEmptyCells = true;
           // tblContent.WidthPercentage = 100;
           //// tblContent.Border = Table.NO_BORDER;
           //// tblContent.Cellspacing = 2;
           //// tblContent.DefaultCellBorder = Cell.PARAGRAPH;
           // tblContent.InsertTable(getRenLetterTable());
            docPDF.Add(tblContent);


        }
        private void CreatePolicyDetailPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getPolicyDetailTable());
            docPDF.Add(tblContent);
        }

        public bool CreateRIRenewalLetterPDF(ClsRenewalLetter_RI objQuotation, int userId)
        {
            bool blCreationSuccess = true;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                DataSet dsRenLetterInfo = new DataSet();
                dsRenLetterInfo = objCoverNoteBI.GetRIRenewalLetterInfo(objQuotation, userId);
                foreach (DataRow dRow in dsRenLetterInfo.Tables[1].Rows)
                {
                    Attention = dsRenLetterInfo.Tables[1].Rows[0]["ClientName"].ToString();
                    UserName = dsRenLetterInfo.Tables[1].Rows[0]["AuthName"].ToString();
                    UserDesignation = dsRenLetterInfo.Tables[1].Rows[0]["AuthDesignation"].ToString();
                    Address1 = dsRenLetterInfo.Tables[1].Rows[0]["Address1"].ToString();
                    Address2 = dsRenLetterInfo.Tables[1].Rows[0]["Address2"].ToString();
                    Address3 = dsRenLetterInfo.Tables[1].Rows[0]["Address3"].ToString();
                    ContentHeader = dsRenLetterInfo.Tables[1].Rows[0]["Header"].ToString();
                    ContentSubject = dsRenLetterInfo.Tables[1].Rows[0]["ContentSubject"].ToString();
                    ContentPara1 = dsRenLetterInfo.Tables[1].Rows[0]["Para1"].ToString();
                    ContentPara2 = dsRenLetterInfo.Tables[1].Rows[0]["Para2"].ToString();
                    ContentPara3 = dsRenLetterInfo.Tables[1].Rows[0]["Para3"].ToString();
                    ContentPara4 = dsRenLetterInfo.Tables[1].Rows[0]["Para4"].ToString();
                    ContentFooter = dsRenLetterInfo.Tables[1].Rows[0]["Footer"].ToString();
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateRenewalPDF(dRow);
                    docPDF.NewPage();
                }
                //DataSet dsPolicyDetail = new DataSet();
                //dsPolicyDetail = objQuotationManager.LoadRIQuotationClientDetail(objQuotation);
                //foreach (DataRow dRow in dsPolicyDetail.Tables[0].Rows)
                //{
                //    ClientName = dsPolicyDetail.Tables[0].Rows[0]["ClientName"].ToString();
                //    POIFromDate = dsPolicyDetail.Tables[0].Rows[0]["POIFromDate1"].ToString();
                //    POIToDate = dsPolicyDetail.Tables[0].Rows[0]["POIToDate1"].ToString();
                //    CoverNoteNo = dsPolicyDetail.Tables[0].Rows[0]["PolicyNo"].ToString();
                //    ereEvents.ShowPageNumber = true;
                //    //ereEvents.PrintFooter = false;
                //    ereEvents.UWCOPY = false;
                //    CreatePolicyDetailPDF(dRow);
                //    docPDF.NewPage();
                //}
            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;
        }


        private PdfPTable getRenLetterTable()
        {
            //Table tblFirstSec = new Table(2);
            //int[] flColWidth = {20,80};
            //tblFirstSec.SetWidths(flColWidth);
            //tblFirstSec.AutoFillEmptyCells = true;
            //tblFirstSec.WidthPercentage = 100;
            //tblFirstSec.Border = Table.PARAGRAPH;
            //tblFirstSec.Cellspacing = 2;


            //strText = "Letter Detail";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 2, false, 10);
            //clCurrCell.Border = Cell.PARAGRAPH;
            //tblFirstSec.AddCell(clCurrCell);


            //tblFirstSec.AddCell(new Phrase("Attention", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Attention, new Font(Font.HELVETICA, 5f, Font.NORMAL)));


            //tblFirstSec.AddCell(new Phrase("Address", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Address1, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Address2, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Address3, new Font(Font.HELVETICA, 5f, Font.NORMAL)));



            //tblFirstSec.AddCell(new Phrase("Content", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentHeader, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentSubject, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentPara1, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentPara2, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentPara3, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentPara4, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(ContentFooter, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(UserName, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("Designation", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(UserDesignation, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //return tblFirstSec;

            PdfPTable tblLetter = new PdfPTable(2);
            int[] flColWidth = { 20, 80 };
            tblLetter.SetWidths(flColWidth);
            tblLetter.WidthPercentage = 100;
            //tblFooter. = true;
            //tblFooter.TotalWidth = page.Width - document.LeftMargin - document.RightMargin;
            tblLetter.DefaultCell.Border = Rectangle.NO_BORDER;
            //tblFooter.DefaultCell.HorizontalAlignment = Rectangle.ALIGN_CENTER;

            PdfPCell pdfcel = new PdfPCell();
            pdfcel.HorizontalAlignment = Rectangle.ALIGN_CENTER;
            pdfcel.Border = Rectangle.NO_BORDER;
            pdfcel.Colspan = 2;
            Paragraph myparaAttention = new Paragraph(Attention, fontNote);
            Paragraph myparaAddress1 = new Paragraph(Address1, fontNote);
            Paragraph myparaAddress2 = new Paragraph(Address2, fontNote);
            Paragraph myparaAddress3 = new Paragraph(Address3, fontNote);

            Paragraph myparaHeader = new Paragraph(ContentHeader, fontNote);
            Paragraph myparaSubject = new Paragraph(ContentSubject, fontNote);
            Paragraph myparaPara1 = new Paragraph(ContentPara1, fontNote);
            Paragraph space1 = new Paragraph("\n", fontNote);
            Paragraph myparaPara2 = new Paragraph(ContentPara2, fontNote);
            Paragraph myparaPara3 = new Paragraph(ContentPara3, fontNote);
            Paragraph myparaPara4 = new Paragraph(ContentPara4, fontNote);
            Paragraph myparaFooter = new Paragraph(ContentFooter, fontNote);
            Paragraph myparaUserName = new Paragraph(UserName, fontNote);
            Paragraph myparaDesignation = new Paragraph(UserDesignation, fontNote);

            myparaAttention.Alignment = Rectangle.ALIGN_LEFT;
            myparaAddress1.Alignment = Rectangle.ALIGN_LEFT;
            myparaAddress2.Alignment = Rectangle.ALIGN_LEFT;
            myparaAddress3.Alignment = Rectangle.ALIGN_LEFT;
            myparaHeader.Alignment = Rectangle.ALIGN_LEFT;
            myparaSubject.Alignment = Rectangle.ALIGN_LEFT;
            myparaPara1.Alignment = Rectangle.ALIGN_LEFT;
            myparaPara2.Alignment = Rectangle.ALIGN_LEFT;
            myparaPara3.Alignment = Rectangle.ALIGN_LEFT;
            myparaPara4.Alignment = Rectangle.ALIGN_LEFT;
            myparaFooter.Alignment = Rectangle.ALIGN_LEFT;
            myparaUserName.Alignment = Rectangle.ALIGN_LEFT;
            myparaDesignation.Alignment = Rectangle.ALIGN_LEFT;
           
            
            pdfcel.AddElement(myparaAttention);
            pdfcel.AddElement(myparaAddress1);
            pdfcel.AddElement(myparaAddress2);
            pdfcel.AddElement(myparaAddress3);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(space1);
            
            pdfcel.AddElement(myparaHeader);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaSubject);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaPara1);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaPara2);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaPara3);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaPara4);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(space1);
            pdfcel.AddElement(myparaFooter);
            pdfcel.AddElement(myparaUserName);
            pdfcel.AddElement(myparaDesignation);

            tblLetter.AddCell(pdfcel);
            return tblLetter;
        }
        private Table getPolicyDetailTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;


            strText = "Policy Detail";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            tblFirstSec.AddCell(new Phrase("Policy No", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase(CoverNoteNo, new Font(Font.HELVETICA, 5f, Font.NORMAL)));


            tblFirstSec.AddCell(new Phrase("POI From Date", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase(POIFromDate, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("POI To Date", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase(POIToDate, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Client Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase(ClientName, new Font(Font.HELVETICA, 5f, Font.NORMAL)));


            return tblFirstSec;
        }
    }
}
