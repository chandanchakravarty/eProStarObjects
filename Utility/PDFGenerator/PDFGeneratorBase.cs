using System;
using EtrekReports.text;
using EtrekReports.text.pdf;
using System.IO;
using System.Web;
namespace Utility.PDFGenerator
{
	/// <summary>
	/// Summary description for EtrekReportsBase.
	/// </summary>
	public class PDFGeneratorBase
	{
        protected Document docPDF = null;
        protected bool isPDFCreated = false;
        protected const int mDefaultFontSize = 11;
		protected const int mintLeftBorder		= 24;
		protected const int mintRightBorder		= 24;
		protected const int mintTopBorder		= 35;
		protected const int mintBottomBorder	= 35;
		
		protected const int mintTotPageWidth	= 595;
		protected const int mintTotPageHeight	= 842;
		
		protected const int mintPageWidth		= mintTotPageWidth - (mintLeftBorder + mintRightBorder);
		protected const int mintPageHeight		= mintTotPageHeight - (mintTopBorder + mintBottomBorder + 10);
		protected const int mintPageRightEdge	= mintTotPageWidth - mintRightBorder;
		protected const int mintPageTopStart	= mintTopBorder + 45;
		protected const int mintPageBottomEnd	= mintTopBorder + mintPageHeight; 
		protected const int mintPageLeftStart	= mintLeftBorder;
                
		protected Font fontDocHdrBold		= null;	
	    protected Font fontDocHdrBoldCh = null;
		protected Font fontNote				= null;
        protected Font fontNoteCh = null;
		protected Font fontNoteUnderline	= null;
        protected Font fontNoteUnderlineCh = null;
		protected Font fontDocContent		= null;
        protected Font fontDocContentCh = null;
		protected Font fontDocContentUnderline= null;
        protected Font fontDocContentUnderlineCh = null;
		protected Font fontDocContentBoldUnderline= null;
        protected Font fontDocContentBoldUnderlineCh = null;
		protected Font fontNoteBold			= null;
        protected Font fontNoteBoldCh= null;	
		protected Font fontNoteBoldItalic			= null;
        protected Font fontThai = null;
        protected Font fontThaiSmall = null;
		
        protected PDFGeneratorBase()
		{

            //FontFactory.Register("c:\\windows\\fonts\\ARIALUNI.TTF");
      
            //fontNote = FontFactory.GetFont("");

           // string strFontpath = System.Configuration.ConfigurationSettings.AppSettings["FileFontCh"].ToString().Trim();
            string strFontpath = "";
            string strFontpathThai = "";
            if (System.Web.HttpContext.Current.Session["ClientCSS"] != null && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["ClientCSS"].ToString()))
            {
                 strFontpath = HttpContext.Current.Server.MapPath("~/" + System.Web.HttpContext.Current.Session["ClientCSS"] + "/Fonts/wt011.ttf");
                 strFontpathThai = HttpContext.Current.Server.MapPath("~/" + System.Web.HttpContext.Current.Session["ClientCSS"] + "/Fonts/Kinnari.ttf");
            }
            else
            {
                strFontpath = HttpContext.Current.Server.MapPath("~/PurpleBlueGray/Fonts/wt011.ttf");
                strFontpathThai = HttpContext.Current.Server.MapPath("~/PurpleBlueGray/Fonts/Kinnari.ttf");
            }
            FontFactory.Register(strFontpath);
            FontFactory.Register(strFontpathThai);
            BaseFont basefont  = BaseFont.CreateFont(strFontpath.ToString().Trim(), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont basefontThai = BaseFont.CreateFont(strFontpathThai.ToString().Trim(), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            
            fontDocHdrBold = FontFactory.GetFont("Arial Unicode MS", 18, Font.BOLD);
            //fontDocHdrBoldCh = FontFactory.GetFont("Arial Unicode MS", 18, Font.BOLD);
            fontDocHdrBoldCh = new  Font(basefont, 18, Font.BOLD);
            fontNote = FontFactory.GetFont("Arial Unicode MS", 10, Font.NORMAL);
           // fontNoteCh = FontFactory.GetFont("Arial Unicode MS", 10, Font.NORMAL);
            fontNoteCh = new Font(basefont, 10, Font.NORMAL);
            fontNoteBold = FontFactory.GetFont("Arial Unicode MS", 10, Font.BOLD);
            //fontNoteBoldCh = FontFactory.GetFont("Arial Unicode MS", 10, Font.BOLD);
            fontNoteBoldCh = new Font(basefont, 10, Font.BOLD);
            fontNoteUnderline = FontFactory.GetFont("Arial Unicode MS", 9, Font.UNDERLINE);
            //fontNoteUnderlineCh = FontFactory.GetFont("Arial Unicode MS", 9, Font.UNDERLINE);
            fontNoteUnderlineCh = new Font(basefont, 9, Font.UNDERLINE);
            fontDocContent = FontFactory.GetFont("Arial Unicode MS", 9, Font.NORMAL);
            //fontDocContentCh = FontFactory.GetFont("Arial Unicode MS", 9, Font.NORMAL);
            fontDocContentCh = new Font(basefont, 9, Font.NORMAL);

            fontDocContentUnderline = FontFactory.GetFont("Arial Unicode MS", 10, Font.NORMAL);
            //fontDocContentUnderlineCh = FontFactory.GetFont("Arial Unicode MS", 10, Font.NORMAL);
            fontDocContentUnderlineCh = new Font(basefont, 10, Font.NORMAL);

			fontDocContentUnderline.SetStyle(Font.UNDERLINE);

            fontDocContentBoldUnderline = FontFactory.GetFont("Arial Unicode MS", 10, Font.BOLD);
            fontDocContentBoldUnderlineCh = FontFactory.GetFont("Arial Unicode MS", 10, Font.BOLD);
            //fontDocContentBoldUnderlineCh = new Font(basefont, 10, Font.BOLD);

			fontDocContentBoldUnderline.SetStyle(Font.UNDERLINE);

            fontThai = new Font(basefontThai, 8, Font.NORMAL);
            fontThaiSmall = new Font(basefontThai, 5.5f, Font.NORMAL);
		}
		protected string strPDFFilePath= "";
		protected string strLogoFilePath= "";
        protected string strSignatureFilePath = "";
        protected string strCategory = "";
		public string PDFFilePath
		{
			get 
			{
				return strPDFFilePath;
			}
			set 
			{ 
				strPDFFilePath = value;
			}
		}
		public string LogoFilePath
		{
			get 
			{
				return strLogoFilePath;
			}
			set 
			{ 
				strLogoFilePath = value;
			}
		}
        public string SignatureFilePath
        {
            get
            {
                return strSignatureFilePath;
            }
            set
            {
                strSignatureFilePath = value;
            }
        }
       
       

        public string PrintType
        {
            get
            {
                return strCategory;
            }
            set
            {
                strCategory = value;
            }
        }
		
		protected Paragraph getParagraph(string strParaContent, string strContentType, int intLeading, int intFirstLineIndent)
		{
            Font fontCurrFont = GetFontStyle(strContentType);
			
			Paragraph prToReturn = new Paragraph(strParaContent,fontCurrFont);
			
			if(intLeading > 0)
				prToReturn.Leading = intLeading;
			if(intFirstLineIndent > 0)
				prToReturn.FirstLineIndent = intFirstLineIndent;

			return prToReturn;
		}
       
		protected Cell getCell(string strCellText, string strContentType, string strHoriAlign, string strVeticalAlign,int intColSpan, bool blIsBordered,int intLeading, bool blLeftBorder, bool blTopBorder, bool blRightBorder, bool blBottomBorder)
		{
			Cell clCellToReturn = getCell(strCellText, strContentType, strHoriAlign, strVeticalAlign, intColSpan, blIsBordered, intLeading);
			if (blRightBorder) 
				clCellToReturn.Border = clCellToReturn.Border | Cell.RIGHT_BORDER;
			if (blLeftBorder) 
				clCellToReturn.Border = clCellToReturn.Border | Cell.LEFT_BORDER;
			if (blTopBorder) 
				clCellToReturn.Border = clCellToReturn.Border | Cell.TOP_BORDER;
			if (blBottomBorder) 
				clCellToReturn.Border = clCellToReturn.Border | Cell.BOTTOM_BORDER;
			clCellToReturn.BorderWidth = 1;
			return clCellToReturn;
		}
		protected Cell getCell(string strCellText, string strContentType, string strHoriAlign, string strVeticalAlign,int intColSpan, bool blIsBordered,int intLeading)
		{
			Cell clCellToReturn = new Cell();
			Font fontCurrFont = null;
			
			if(!blIsBordered)
				clCellToReturn.Border = Cell.NO_BORDER;
			//fix the horizontal alignmentment
			switch(strHoriAlign.ToUpper())
			{
				case "CENTER":
					clCellToReturn.HorizontalAlignment = Element.ALIGN_CENTER;
					break;
				case "RIGHT":
					clCellToReturn.HorizontalAlignment = Element.ALIGN_RIGHT;
					break;
				case "LEFT":
					clCellToReturn.HorizontalAlignment = Element.ALIGN_LEFT;
					break;
				case "JUSTIFY":
					clCellToReturn.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
					break;
					
				default:
					clCellToReturn.HorizontalAlignment = Element.ALIGN_LEFT;
					break;
			}
			switch(strVeticalAlign.ToUpper())
			{
				case "MIDDLE":
					clCellToReturn.VerticalAlignment = Element.ALIGN_MIDDLE;
					break;
				case "TOP":
					clCellToReturn.VerticalAlignment = Element.ALIGN_TOP;
					break;
				case "BOTTOM":
					clCellToReturn.VerticalAlignment = Element.ALIGN_BOTTOM;
					break;
				default:
					clCellToReturn.VerticalAlignment = Element.ALIGN_MIDDLE;
					break;
			}
			
			if(intColSpan > 1)
				clCellToReturn.Colspan = intColSpan;
            fontCurrFont = GetFontStyle(strContentType);
			Paragraph phTemp = new Paragraph(strCellText,fontCurrFont);
			clCellToReturn.Add(phTemp);
			
			if(intLeading > 0)
				clCellToReturn.Leading = intLeading;
			else if(intLeading == 0)
				clCellToReturn.Leading = 7; // if zero value is passed its defaulted to 7
			else if(intLeading < 0)
				clCellToReturn.Leading = 3;
			return clCellToReturn;
		}
        private Font GetFontStyle(string strContentType)
        {
            Font fontCurrFont = null;
            switch (strContentType.ToUpper())
            {
                case "DOC_HEADER":
                    fontCurrFont = fontDocHdrBoldCh;
                    break;
                case "NOTE":
                    fontCurrFont = fontNoteCh;
                    break;
                case "NOTE_UNDERLINE":
                    fontCurrFont = fontNoteUnderlineCh;
                    break;
                case "DOC_CONTENT":
                    fontCurrFont = fontDocContentCh;
                    break;
                case "NOTE_BOLD":
                    fontCurrFont = fontNoteBoldCh;
                    break;
                
                case "DOC_CONTENT_UNDERLINE":
                    fontCurrFont = fontDocContentUnderlineCh;
                    break;
                case "DOC_CONTENT_BOLD_ITALIC":
                    fontCurrFont = fontNoteBoldItalic;
                    break;

                //case "DOC_HEADERCH":
                //    fontCurrFont = fontDocHdrBoldCh;
                //    break;
                //case "NOTECH":
                //    fontCurrFont = fontNoteCh;
                //    break;
                //case "NOTE_UNDERLINECH":
                //    fontCurrFont = fontNoteUnderlineCh;
                //    break;
                //case "DOC_CONTENTCH":
                //    fontCurrFont = fontDocContentCh;
                //    break;
                //case "NOTE_BOLDCH":
                //    fontCurrFont = fontNoteBoldCh;
                //    break;
                case "NOTECH":
                    fontCurrFont = fontThai;
                    break;
                
                default:
                    fontCurrFont = fontDocContentCh;
                    break;
            }
            return fontCurrFont;
        }
		protected Table getTable(int intCol, int intRow,float flWidthPercentage, int[] intArrColWidth, float flCellSpacing, float flCellPadding, bool blIsBordered, bool blIsAutoFillEmptyCells)
		{
			Table TblToReturn = null;
			if ( intRow > 0)
			{
				TblToReturn = new Table(intCol,intRow);
			}
			else
			{
				TblToReturn = new Table(intCol);
			}

			if (flWidthPercentage >= 0)
			{
				TblToReturn.WidthPercentage = flWidthPercentage; 
			}
			
			if(flCellSpacing >= 0 )
			{
				TblToReturn.Cellspacing = flCellSpacing;
			}

			if(flCellPadding >= 0)
			{
				TblToReturn.Cellspacing = flCellPadding;
			}
			if(intArrColWidth.Length > 0 )
			{
				TblToReturn.SetWidths(intArrColWidth);
			}
			if(blIsBordered)
			{
				TblToReturn.Border = Table.BOX;
			}
			else
			{
				TblToReturn.Border = Table.NO_BORDER;
			}
			if(blIsAutoFillEmptyCells)
				TblToReturn.AutoFillEmptyCells = true;
			
			
			return TblToReturn;
		}
        protected void createAndOpenNewDoc(bool blAttachEvents)
        {
            docPDF = new Document(PageSize.A4, mintLeftBorder, mintRightBorder, mintTopBorder - 10, mintBottomBorder - 5);
            FileStream fsPDFStream = new FileStream(strPDFFilePath, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPDF, fsPDFStream);
            if (blAttachEvents)
                pdfWriter.PageEvent = new PDFGeneratorEvents();
            docPDF.Open();
            isPDFCreated = true;
        }

        protected void closeDoc()
        {
            if (isPDFCreated)
            {
                if (docPDF != null)
                {
                    docPDF.Close();
                    docPDF = null;
                    isPDFCreated = false;
                }
            }
        }
	}
}
