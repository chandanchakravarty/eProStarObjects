using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using EtrekReports.text;
using EtrekReports.text.pdf;
using Utility.PDFGenerator;
using Utility;
using BusinessAccessLayer.BrokingModule.BrokingSystem;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{

    public class DebitNoteWOCNPDFGenerator : PDFGeneratorBase
    {
        protected PDFGeneratorEvents ereEvents = null;
        protected Cell clCurrCell = null;
        private string strText = "";
        private new Font fontNote = null;
        private new Font fontNoteUnderline = null;
        private new Font fontDocContent = null;
        private Font fontDocContentBold = null;
        private Font fontDocContentNote = null;
        private Font fontSmallNote = null;
        private Font fontSmallNoteBold = null;
        private Font fontMini = null;
        private Font fontConstantNote = null;
        private Font fontConstantMiddleNote = null;
        private Font fontConstantSmallNote = null;
        DataSet ds = null;
        DebiteNoteWOCoverNoteManager objDebitNoteMgr = new DebiteNoteWOCoverNoteManager();

        protected string mstrDebitNoteType = "";
        protected string mstrDebitNoteNo = "";
        protected string mstrClientName = "";
        protected string mstrClientCode = "";
        protected string mstrInstNo = "";
        protected string mstrRefNo = "";

        protected string mstrBranchCode = "";
        protected string mstrDebitNoteDate = "";
        protected string mstrClass = "";
        protected string mstrCoverNoteNo = "";
        protected string mstrPeriod = "";
        protected string mstrCurrency = "";

        protected string mstrPremium = "";
        protected string mstrSurcharge = "";
        protected string mstrSurchargeRate = "";

        protected string mstrDiscount = "";
        protected string mstrDiscountRate = "";
        protected string mstrHandlingFee = "";
        protected string mstrHandlingFeeRate = "";
        protected string mstrLeaderfee = "";
        protected string mstrLeaderfeeRate = "";



        protected string mstrTotal = "";


        protected string mstrBrokerage = "";
        protected string mstrBrokerageRate = "";

        protected string mstrNetAmount = "";
        protected string mstrUWShare = "";
        protected string mstrInsurerName = "";
        protected string mstrPolicyNo = "";
        protected string mstrUwriterName = "";
        protected string mstrUwriterCode = "";

        protected string mstrAgentName = "";
        protected string mstrAgentCode = "";
        protected string mstrAgentShare = "";

        protected string mstrPaymentStatus = "";
        protected string mstrRemarks = "";
        protected string mstrBillingNo = "";
        protected string mstrPaymentMethod = "";
        protected string mstrPayeeName = "";
        private string compName = string.Empty;
        private string IsLegislationNotePrint = "";
        private string mstrLegislationNote = "";
        private string mstrLocationNo = "";
        private string mstrLocationDesc = "";
        private string mstrSurcharge1 = "";
        private string mstrLang = "";
        private string mstrBrokerageType = "";
        private string mstrOther_Charges = "";

        string IsMUlLocation = "N";
        int CountMulLocation = 0;
        string PolicyStatus = "";

        // Consolidated debit note report field added by Rituraj
       // string mstrRptClientOfficerName = "Olivia Huang ";
        string mstrRptClientOfficerName = " ";
       // string mstrRptClientName = "Atieva Shanghai, Inc. ";
        string mstrRptClientName = "";
        string mstrRptsubject = "Re: Insurance Documents ";
       // string mstrRptHeaderDate = "May 22, 2012 ";
        
        string mstrRptHeaderDate = "";
        string mstrRptGreeting = "Dear ";
        string mstrRptRptDtl = " We enclose here with the documents in respect of your company insurance issued by ";
       // string mstrRptOrgnname = " Chubb Insurance (China) Company limited. ";
        string mstrRptOrgnname = "";
        string mstrRptOrgnlastWord = " as follows : ";
        string mstrRpt1stheader = " I. Insurance Policy in respect of : ";
        //string mstrRpt1stTabColClassName = "Property All Risks Insurance ";
        string mstrRpt1stTabColClassName = "";
        string mstrRptPolicyNoHead = "---Policy No.";
        //string mstrRptPolicyNo = " 93508733 ";
        string mstrRptPolicyNo = "";
        string mstrRptPolicyNoHeader = "Policy No. ";
        string mstrRptClassHeader = " Class ";
        string mstrRptPremiumsHdr = " Premiums ";
        string mstrRptPremiumColm = "";
        string mstrRpt2ndHeader = "II. Premium Debit Note in respect of the above captioned covers as follows : ";
        string mstrRptTotalPremiumDueHeader = " Total Premiums Due: ";
        string mstrRptCurrency = "";

        string mstrRpt3rdLastline = "We hope you will find the above in order, ";
        string mstrRpt2ndLastLine = "Best regards! ";
        string mstrRptlastline = " Yours sincerely ";
        //string mstrRptLastLineName = "Minhui Chen";
        string mstrRptLastLineName = "";
        string[] StrCaseRefArry = null;
        // Finished here
        public DebitNoteWOCNPDFGenerator()
        {
            //
            // TODO: Add constructor logic here
            //
            fontDocHdrBold = FontFactory.GetFont("Arial", 15, Font.BOLD);
            fontNote = FontFactory.GetFont(FontFactory.COURIER, 9, Font.NORMAL);
            fontNoteUnderline = FontFactory.GetFont("Arial", 9, Font.UNDERLINE);
            fontDocContent = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            fontDocContentNote = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            fontDocContentBold = FontFactory.GetFont("Arial", 10, Font.BOLD);
            fontSmallNote = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL);
            fontSmallNoteBold = FontFactory.GetFont(FontFactory.COURIER, 7, Font.BOLD);
            fontMini = FontFactory.GetFont("Arial", 5, Font.NORMAL);
            fontConstantNote = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            fontConstantMiddleNote = FontFactory.GetFont("Arial", 9, Font.BOLD);
            fontConstantSmallNote = FontFactory.GetFont("Arial", 8, Font.NORMAL);
        }

        //(string strCaseRefNo, string strDebitNoteNo, string strRefNo, string strUWRefNo, string strAgRefNo, string companyName, string HeaderLogo, string FooterLogo )

        public bool CreateBatchDebitNotePDF(string strCaseRefNoArr, string strDebitNoteNoArr, string strRefNoArr, string strUWRefNoArr, string strAgRefNoArr, string companyName, string strLogoPathHeaderArr, string FooterLogo)
        {
            bool blCreationSuccess = false;
            ereEvents = new PDFGeneratorEvents();
            compName = companyName;
            try
            {
                createAndOpenNewDoc();
                char[] splitchar = { ',' };
                strCaseRefNoArr = strCaseRefNoArr.Substring(0, strCaseRefNoArr.Length - 1);
                strDebitNoteNoArr = strDebitNoteNoArr.Substring(0, strDebitNoteNoArr.Length - 1);
                strRefNoArr = strRefNoArr.Substring(0, strRefNoArr.Length - 1);
                strUWRefNoArr = strUWRefNoArr.Substring(0, strUWRefNoArr.Length - 1);
                strAgRefNoArr = strAgRefNoArr.Substring(0, strAgRefNoArr.Length - 1);
                strLogoPathHeaderArr = strLogoPathHeaderArr.Substring(0, strLogoPathHeaderArr.Length - 1);

                
                string[] strCaseRefNo = strCaseRefNoArr.Split(splitchar, strCaseRefNoArr.Length);
                string[] strDebitNoteNo = strDebitNoteNoArr.Split(splitchar, strDebitNoteNoArr.Length);
                string[] strRefNo = strRefNoArr.Split(splitchar, strRefNoArr.Length);
                string[] strUWRefNo = strUWRefNoArr.Split(splitchar, strUWRefNoArr.Length);
                string[] strAgRefNo = strAgRefNoArr.Split(splitchar, strAgRefNoArr.Length);
                string[] strLogoPathHeader = strLogoPathHeaderArr.Split(splitchar, strLogoPathHeaderArr.Length);

                string _refNo = string.Empty;
                string _uwRefNo = string.Empty;
                string _agentRefno = string.Empty;
                string strClientiPlus1 = string.Empty;

                for (int i = 0; i < strCaseRefNo.Length; i++)
                {
                    ds = new DataSet();
                    if (strRefNo.Length <= i)
                        _refNo = "0";
                    else
                        _refNo = strRefNo[i].ToString();
                    if (strUWRefNo.Length <= i)
                        _uwRefNo = "0";
                    else
                        _uwRefNo = strUWRefNo[i].ToString();
                    if (strAgRefNo.Length <= i)
                        _agentRefno = "0";
                    else
                        _agentRefno = strAgRefNo[i].ToString();
                    ds = objDebitNoteMgr.GetDebitNotePrintDetails(strCaseRefNo[i].ToString(), strDebitNoteNo[i].ToString(), _refNo, _uwRefNo, _agentRefno);
                    getFooter(strCaseRefNo[i].ToString());
                    //System.Drawing.Image CIB = System.Drawing.Image.FromFile(FooterLogo);
                    EtrekReports.text.Image ImageHeaderLogo = EtrekReports.text.Image.GetInstance(strLogoPathHeader[i].ToString());
                    EtrekReports.text.Image CIB = EtrekReports.text.Image.GetInstance(FooterLogo);
                    ereEvents.HeaderLogo = ImageHeaderLogo;
                    CIB.ScaleAbsolute(13f, 13f);
                    ereEvents.Logo = CIB;
                    ereEvents.LogoNote = "A Member of the Hong Kong Confederation Of Insurance Brokers";

                    DataSet dsCoverage = objDebitNoteMgr.getPrintCovernaote(strCaseRefNo[i].ToString());
                    string CoverageToInclude = "";
                    if (dsCoverage != null && dsCoverage.Tables.Count > 0 && dsCoverage.Tables[0].Rows.Count > 0)
                    {
                        CoverageToInclude = dsCoverage.Tables[0].Rows[0]["CoverageToInclude"].ToString().Trim().ToUpper();
                    }
                    if (ds.Tables.Count > 4)
                    {
                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            IsMUlLocation = ds.Tables[5].Rows[0]["MultipleLocations"].ToString();
                            CountMulLocation = Convert.ToInt32(ds.Tables[5].Rows[0]["CountLocations"]);
                            PolicyStatus = ds.Tables[5].Rows[0]["PolicyStatus"].ToString();
                            mstrLang = ds.Tables[5].Rows[0]["Lang"].ToString();
                        }

                    }

                    int j = 0;
                    if (CoverageToInclude != "IH")
                    {
                        foreach (DataRow dRow in ds.Tables[0].Rows)
                        {

                            mstrDebitNoteType = dRow["DebitNoteType"].ToString().Trim();
                            mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                            mstrClientName = dRow["ClientName"].ToString().Trim();
                            mstrClientCode = dRow["ClientCode"].ToString().Trim();
                            mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                            mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                            // mstrClass = dRow["MainClassName"].ToString().Trim();
                            mstrClass = dRow["SubClassName"].ToString().Trim();
                            mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                            mstrPeriod = dRow["Period"].ToString().Trim();
                            mstrCurrency = dRow["Currency"].ToString().Trim();

                            //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                            //mstrTotal =  Convert.ToDecimal( dRow["Total"].ToString().Trim()).ToString("#,##0.00");
                            mstrCurrency = dRow["Currency"].ToString().Trim();
                            mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                            if (dRow["Other_Charges"] != DBNull.Value)
                                mstrOther_Charges = Convert.ToDecimal(dRow["Other_Charges"].ToString().Trim()).ToString("#,##0.00");
                            else
                                mstrOther_Charges = "0.00";

                            mstrSurcharge = Convert.ToDecimal(dRow["Surcharge"].ToString().Trim()).ToString("#,##0.00");
                            mstrSurchargeRate = dRow["SurchargeRate"].ToString().Trim();
                            mstrDiscount = Convert.ToDecimal(dRow["SpecialDiscount"].ToString().Trim()).ToString("#,##0.00");
                            mstrDiscountRate = dRow["SpecialDiscountRate"].ToString().Trim();
                            mstrHandlingFee = Convert.ToDecimal(dRow["Fees"].ToString().Trim()).ToString("#,##0.00");
                            mstrHandlingFeeRate = dRow["FeesRate"].ToString().Trim();
                            mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                            mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                            mstrPaymentStatus = dRow["PaymentStatusDesc"].ToString().Trim();
                            mstrBillingNo = dRow["InsurerDebitNote"].ToString().Trim();
                            mstrPaymentMethod = dRow["PaymentMode"].ToString().Trim();
                            if (!dRow["PaymentMode"].ToString().Trim().Equals("C"))
                            {
                                compName = dRow["payableto"].ToString().Trim();
                            }
                            mstrPayeeName = dRow["InsuredName"].ToString().Trim();
                            mstrRemarks = dRow["Remarks"].ToString().Trim();
                            mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();

                            if (ds.Tables[0].Columns.Contains("InstNo"))
                            {
                                if (dRow["InstNo"] != DBNull.Value)
                                {
                                    mstrInstNo = dRow["InstNo"].ToString().Trim();
                                }
                                else
                                    mstrInstNo = "0";
                            }
                            else
                                mstrInstNo = "0";


                            if (dRow.Table.Columns.Contains("LocationDescription"))
                            {
                                mstrLocationDesc = dRow["LocationDescription"].ToString().Trim();
                                mstrLocationNo = dRow["LocationNo"].ToString().Trim();
                            }


                            if (ds.Tables.Count > 3)
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                    mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                            }
                            if (mstrInstNo != "0")
                            {
                                if (j == 0)
                                {
                                    if (ds.Tables.Count > 5)
                                    {
                                        DataTable dtClientMain = new DataTable();
                                        DataView dv = new DataView(ds.Tables[6]);
                                        dv.RowFilter = "ClientCode='" + mstrClientCode + "'";
                                        dtClientMain = dv.ToTable();

                                        ereEvents.ShowPageNumber = false;
                                        ereEvents.DebitNote = true;
                                        ereEvents.PrintFooter = true;
                                        ereEvents.UWCOPY = false;
                                        CreateClientDebitNotePDFMaster(dtClientMain);
                                        docPDF.NewPage();
                                        blCreationSuccess = true;
                                    }

                                }
                                else
                                {
                                    if (j < ds.Tables[0].Rows.Count)
                                    {
                                        strClientiPlus1 = ds.Tables[0].Rows[j - 1]["ClientCode"].ToString().Trim();
                                        if (mstrClientCode != strClientiPlus1)
                                        {
                                            DataTable dtClientMain = new DataTable();
                                            DataView dv = new DataView(ds.Tables[6]);
                                            dv.RowFilter = "ClientCode='" + mstrClientCode + "'";
                                            dtClientMain = dv.ToTable();
                                            ereEvents.ShowPageNumber = false;
                                            ereEvents.DebitNote = true;
                                            ereEvents.PrintFooter = true;
                                            ereEvents.UWCOPY = false;
                                            CreateClientDebitNotePDFMaster(dtClientMain);
                                            docPDF.NewPage();
                                            blCreationSuccess = true;
                                        }
                                    }
                                }
                            }
                            ereEvents.ShowPageNumber = false;
                            ereEvents.DebitNote = true;
                            ereEvents.PrintFooter = true;
                            ereEvents.UWCOPY = false;
                            CreateClientDebitNotePDF(dRow);
                            docPDF.NewPage();
                            blCreationSuccess = true;

                            j++;
                        }
                    }
                    j = 0;
                    foreach (DataRow dRow in ds.Tables[1].Rows)
                    {

                        mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                        mstrClientName = dRow["ClientName"].ToString().Trim();
                        mstrClientCode = dRow["ClientCode"].ToString().Trim();
                        mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                        mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                        // mstrClass = dRow["MainClassName"].ToString().Trim();
                        mstrClass = dRow["SubClassName"].ToString().Trim();
                        mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                        mstrPeriod = dRow["Period"].ToString().Trim();
                        mstrCurrency = dRow["Currency"].ToString().Trim();

                        mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        mstrBrokerage = dRow["Brokerage"].ToString().Trim();
                        mstrBrokerageRate = dRow["BrokerageRate"].ToString().Trim();
                        mstrSurcharge = Convert.ToDecimal(dRow["Surcharge"].ToString().Trim()).ToString("#,##0.00");
                        mstrLeaderfee = dRow["Fees"].ToString().Trim();
                        mstrLeaderfeeRate = dRow["FeesRate"].ToString().Trim();
                        mstrNetAmount = Convert.ToDecimal(dRow["NetAmount"].ToString().Trim()).ToString("#,##0.00");
                        mstrUWShare = dRow["UWShare"].ToString().Trim();
                        mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                        //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        //mstrBrokerage = Convert.ToDecimal( dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                        //mstrNetAmount =  Convert.ToDecimal(dRow["NetAmount"].ToString().Trim()).ToString("#,##0.00");
                        //mstrUWShare =  Convert.ToDecimal(dRow["UWShare"].ToString().Trim()).ToString("#,##0.00");
                        //mstrTotal =  Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");
                        mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                        mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();
                        mstrUwriterCode = dRow["UnderWriterCode"].ToString().Trim();
                        mstrUwriterName = dRow["UnderWriterName"].ToString().Trim();
                        mstrRemarks = dRow["Remarks"].ToString().Trim();
                        if (ds.Tables[1].Columns.Contains("InstNo"))
                        {
                            if (dRow["InstNo"] != DBNull.Value)
                            {
                                mstrInstNo = dRow["InstNo"].ToString().Trim();
                            }
                            else
                                mstrInstNo = "0";
                        }
                        else
                            mstrInstNo = "0";

                        if (ds.Tables.Count > 3)
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                                mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                        }
                        if (mstrInstNo != "0")
                        {
                            if (j == 0)
                            {
                                if (ds.Tables.Count > 6)
                                {
                                    DataTable dtClientMain = new DataTable();
                                    DataView dv = new DataView(ds.Tables[7]);
                                    dv.RowFilter = "UnderWriterCode='" + mstrUwriterCode+"'";
                                    dtClientMain = dv.ToTable();
                                    ereEvents.ShowPageNumber = false;
                                    ereEvents.DebitNote = false;
                                    ereEvents.PrintFooter = true;
                                    ereEvents.UWCOPY = true;
                                    CreateUwriterDebitNotePDFMaster(dtClientMain);
                                    docPDF.NewPage();
                                    blCreationSuccess = true;
                                }

                            }
                            else
                            {
                                if (j < ds.Tables[1].Rows.Count)
                                {
                                    strClientiPlus1 = ds.Tables[1].Rows[j - 1]["UnderWriterCode"].ToString().Trim();
                                    if (mstrUwriterCode != strClientiPlus1)
                                    {
                                        DataTable dtClientMain = new DataTable();
                                        DataView dv = new DataView(ds.Tables[7]);
                                        dv.RowFilter = "UnderWriterCode='" + mstrUwriterCode + "'";
                                        dtClientMain = dv.ToTable();
                                        ereEvents.ShowPageNumber = false;
                                        ereEvents.DebitNote = false;
                                        ereEvents.PrintFooter = true;
                                        ereEvents.UWCOPY = true;
                                        CreateUwriterDebitNotePDFMaster(dtClientMain);
                                        docPDF.NewPage();
                                        blCreationSuccess = true;
                                    }
                                }
                            }
                        }

                        ereEvents.ShowPageNumber = false;
                        ereEvents.DebitNote = false;
                        ereEvents.UWCOPY = true;
                        CreateUwriterDebitNotePDF(dRow);
                        docPDF.NewPage();
                        blCreationSuccess = true;
                        j++;
                    }
                    j = 0;
                    foreach (DataRow dRow in ds.Tables[2].Rows)
                    {
                        mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                        mstrClientName = dRow["ClientName"].ToString().Trim();
                        mstrClientCode = dRow["ClientCode"].ToString().Trim();
                        mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                        mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                        // mstrClass = dRow["MainClassName"].ToString().Trim();
                        mstrClass = dRow["SubClassName"].ToString().Trim();
                        mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                        mstrPeriod = dRow["Period"].ToString().Trim();
                        mstrCurrency = dRow["Currency"].ToString().Trim();

                        mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        mstrBrokerage = Convert.ToDecimal(dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                        mstrAgentShare = dRow["AgentShare"].ToString().Trim();
                        mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                        //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        //mstrBrokerage =  Convert.ToDecimal( dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                        //mstrAgentShare=  Convert.ToDecimal(dRow["AgentShare"].ToString().Trim()).ToString("#,##0.00");
                        //mstrTotal = Convert.ToDecimal(dRow["TotalDue"].ToString().Trim()).ToString("#,##0.00");


                        mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                        mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();
                        mstrAgentCode = dRow["AgentCode"].ToString().Trim();
                        mstrAgentName = dRow["AgentName"].ToString().Trim();
                        mstrRemarks = dRow["Remarks"].ToString().Trim();
                        if (ds.Tables[2].Columns.Contains("InstNo"))
                        {
                            if (dRow["InstNo"] != DBNull.Value )
                            {
                                mstrInstNo = dRow["InstNo"].ToString().Trim();
                            }
                            else
                                mstrInstNo = "0";
                        }
                        else
                            mstrInstNo = "0";

                        if (ds.Tables.Count > 3)
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                                mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                        }
                        if (mstrInstNo != "0")
                        {
                            if (j == 0)
                            {
                                if (ds.Tables.Count > 7)
                                {
                                    DataTable dtClientMain = new DataTable();
                                    DataView dv = new DataView(ds.Tables[8]);
                                    dv.RowFilter = "AgentCode='" + mstrAgentCode + "'";
                                    dtClientMain = dv.ToTable();
                                    ereEvents.ShowPageNumber = false;
                                    ereEvents.DebitNote = false;
                                    ereEvents.PrintFooter = true;
                                    ereEvents.UWCOPY = true;
                                    CreateAgentDebitNotePDFMaster(dtClientMain);
                                    docPDF.NewPage();
                                    blCreationSuccess = true;
                                }

                            }
                            else
                            {
                                if (j < ds.Tables[2].Rows.Count)
                                {
                                    strClientiPlus1 = ds.Tables[2].Rows[j - 1]["AgentCode"].ToString().Trim();
                                    if (mstrAgentCode != strClientiPlus1)
                                    {
                                        DataTable dtClientMain = new DataTable();
                                        DataView dv = new DataView(ds.Tables[8]);
                                        dv.RowFilter = "AgentCode='" + mstrAgentCode + "'";
                                        dtClientMain = dv.ToTable();
                                        ereEvents.ShowPageNumber = false;
                                        ereEvents.DebitNote = false;
                                        ereEvents.PrintFooter = true;
                                        ereEvents.UWCOPY = true;
                                        CreateAgentDebitNotePDFMaster(dtClientMain);
                                        docPDF.NewPage();
                                        blCreationSuccess = true;
                                        j++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                if (blCreationSuccess)
                {
                    closeDoc();
                }
            }
            return blCreationSuccess;

        }

        
        public void getFooter(string strcaseRefNo)
        {
      
            DataSet dsFooter = objDebitNoteMgr.GetDebitNoteFooterDetail(strcaseRefNo);
            if (dsFooter.Tables["BranchFooter"].Rows.Count > 0)
            {
                if (dsFooter.Tables["BranchFooter"].Rows[0]["BranchName"].ToString() != "Default")
                {
                    ereEvents.Branchname = dsFooter.Tables["BranchFooter"].Rows[0]["BranchName"].ToString();
                    ereEvents.BranchAddress = dsFooter.Tables["BranchFooter"].Rows[0]["Contact"].ToString();
                    ereEvents.BranchTelno = dsFooter.Tables["BranchFooter"].Rows[0]["Telephone"].ToString();
                    ereEvents.BranchFaxNo = dsFooter.Tables["BranchFooter"].Rows[0]["Fax"].ToString();
                    ereEvents.BranchEmailid = dsFooter.Tables["BranchFooter"].Rows[0]["Email"].ToString();
                    ereEvents.BranchWebsite = dsFooter.Tables["BranchFooter"].Rows[0]["Website"].ToString();
                }
            }
            if (dsFooter.Tables["CompanyFooter"].Rows.Count > 0)
            {
                if (dsFooter.Tables["CompanyFooter"].Rows[0]["CompanyName"].ToString() != "Default")
                {
                    ereEvents.Companyname = dsFooter.Tables["CompanyFooter"].Rows[0]["CompanyName"].ToString();
                    ereEvents.Address = dsFooter.Tables["CompanyFooter"].Rows[0]["Contact"].ToString();
                    ereEvents.Telno = dsFooter.Tables["CompanyFooter"].Rows[0]["Telephone"].ToString();
                    ereEvents.FaxNo = dsFooter.Tables["CompanyFooter"].Rows[0]["Fax"].ToString();
                    ereEvents.Emailid = dsFooter.Tables["CompanyFooter"].Rows[0]["Email"].ToString();
                    ereEvents.Website = dsFooter.Tables["CompanyFooter"].Rows[0]["Website"].ToString();
                }
            }
            //strLogoPathHeader = Server.MapPath(dsFooter.Tables["PrintLogo"].Rows[0]["LogoPath"].ToString());
        }
        
        public void getConsolidatedDebitNoteFooter(string strcaseRefNo)
        {
            strcaseRefNo = strcaseRefNo.Substring(0, (strcaseRefNo.Length - 1));

            DataSet dsFooter = objDebitNoteMgr.GetDebitNoteFooterDetail(strcaseRefNo);
            if (dsFooter.Tables["BranchFooter"].Rows[0]["BranchName"].ToString() != "Default")
            {
                ereEvents.Branchname = dsFooter.Tables["BranchFooter"].Rows[0]["BranchName"].ToString();
                ereEvents.BranchAddress = dsFooter.Tables["BranchFooter"].Rows[0]["Contact"].ToString();
                ereEvents.BranchTelno = dsFooter.Tables["BranchFooter"].Rows[0]["Telephone"].ToString();
                ereEvents.BranchFaxNo = dsFooter.Tables["BranchFooter"].Rows[0]["Fax"].ToString();
                ereEvents.BranchEmailid = dsFooter.Tables["BranchFooter"].Rows[0]["Email"].ToString();
                ereEvents.BranchWebsite = dsFooter.Tables["BranchFooter"].Rows[0]["Website"].ToString();
            }
            if (dsFooter.Tables["CompanyFooter"].Rows[0]["CompanyName"].ToString() != "Default")
            {
                ereEvents.Companyname = dsFooter.Tables["CompanyFooter"].Rows[0]["CompanyName"].ToString();
                ereEvents.Address = dsFooter.Tables["CompanyFooter"].Rows[0]["Contact"].ToString();
                ereEvents.Telno = dsFooter.Tables["CompanyFooter"].Rows[0]["Telephone"].ToString();
                ereEvents.FaxNo = dsFooter.Tables["CompanyFooter"].Rows[0]["Fax"].ToString();
                ereEvents.Emailid = dsFooter.Tables["CompanyFooter"].Rows[0]["Email"].ToString();
                ereEvents.Website = dsFooter.Tables["CompanyFooter"].Rows[0]["Website"].ToString();
            }
            //strLogoPathHeader = Server.MapPath(dsFooter.Tables["PrintLogo"].Rows[0]["LogoPath"].ToString());
        }

        public bool CreateDebitNotePDF(string strCaseRefNo, string strDebitNoteNo, string strRefNo, string strUWRefNo, string strAgRefNo, string companyName, string HeaderLogo, string FooterLogo,string dateformat,string CoverageToInclude)
        {
            bool blCreationSuccess = false;
            string strClientiPlus1 = "";
            compName = companyName;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                ds = objDebitNoteMgr.GetDebitNotePrintDetails(strCaseRefNo, strDebitNoteNo, strRefNo, strUWRefNo, strAgRefNo);
                getFooter(strCaseRefNo);
                //System.Drawing.Image CIB = System.Drawing.Image.FromFile(FooterLogo);
               // EtrekReports.text.Image ImageHeaderLogo = EtrekReports.text.Image.GetInstance(HeaderLogo);
                //EtrekReports.text.Image CIB = EtrekReports.text.Image.GetInstance(FooterLogo);
                //ereEvents.HeaderLogo = ImageHeaderLogo;
                //CIB.ScaleAbsolute(13f, 13f);
               // ereEvents.Logo = CIB;
                ereEvents.LogoNote = "A Member of the Hong Kong Confederation Of Insurance Brokers";
                if (ds.Tables.Count > 4)
                {
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        IsMUlLocation = ds.Tables[5].Rows[0]["MultipleLocations"].ToString();
                        CountMulLocation = Convert.ToInt32(ds.Tables[5].Rows[0]["CountLocations"]);
                        PolicyStatus = ds.Tables[5].Rows[0]["PolicyStatus"].ToString();
                        mstrLang = ds.Tables[5].Rows[0]["Lang"].ToString();
                        mstrBrokerageType = ds.Tables[5].Rows[0]["BrokerageType"].ToString();
                    }

                }
                int i = 0;
                if (CoverageToInclude != "IH")
                {
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        mstrDebitNoteType = dRow["DebitNoteType"].ToString().Trim();

                        mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                        mstrClientName = dRow["ClientName"].ToString().Trim();
                        mstrClientCode = dRow["ClientCode"].ToString().Trim();

                        mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                        if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                        {
                            mstrDebitNoteDate = dRow["DebitNoteDate1"].ToString().Trim();
                        }
                        else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                        {
                            mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                        }
                        // mstrClass = dRow["MainClassName"].ToString().Trim();
                        mstrClass = dRow["SubClassName"].ToString().Trim();
                        mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                        if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                        {
                            mstrPeriod = dRow["Period1"].ToString().Trim();
                        }
                        else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                        {
                            mstrPeriod = dRow["Period"].ToString().Trim();
                        }
                        mstrCurrency = dRow["Currency"].ToString().Trim();

                        //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        //mstrTotal =  Convert.ToDecimal( dRow["Total"].ToString().Trim()).ToString("#,##0.00");
                        mstrCurrency = dRow["Currency"].ToString().Trim();
                        mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                        if (dRow["Other_Charges"] != DBNull.Value)
                            mstrOther_Charges = Convert.ToDecimal((dRow["Other_Charges"].ToString().Trim() == "" ? "0" : dRow["Other_Charges"].ToString().Trim())).ToString("#,##0.00");
                        else
                            mstrOther_Charges = "0.00";
                        mstrSurcharge = Convert.ToDecimal(dRow["Surcharge"].ToString().Trim()).ToString("#,##0.00");
                        mstrSurchargeRate = dRow["SurchargeRate"].ToString().Trim();
                        mstrDiscount = Convert.ToDecimal(dRow["SpecialDiscount"].ToString().Trim()).ToString("#,##0.00");
                        mstrDiscountRate = dRow["SpecialDiscountRate"].ToString().Trim();
                        mstrHandlingFee = Convert.ToDecimal(dRow["Fees"].ToString().Trim()).ToString("#,##0.00");
                        mstrHandlingFeeRate = dRow["FeesRate"].ToString().Trim();
                        mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                        mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                        mstrPaymentStatus = dRow["PaymentStatusDesc"].ToString().Trim();
                        mstrBillingNo = dRow["InsurerDebitNote"].ToString().Trim();
                        mstrPaymentMethod = dRow["PaymentMode"].ToString().Trim();
                        if (!dRow["payableto"].ToString().Trim().ToUpper().Equals("C"))
                        {
                            compName = dRow["payableto"].ToString().Trim();
                        }
                        mstrPayeeName = dRow["InsuredName"].ToString().Trim();
                        mstrRemarks = dRow["Remarks"].ToString().Trim();
                        mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();

                        if (ds.Tables[0].Columns.Contains("InstNo"))
                        {
                            if (dRow["InstNo"] != DBNull.Value)
                            {
                                mstrInstNo = dRow["InstNo"].ToString().Trim();
                            }
                            else
                                mstrInstNo = "0";
                        }
                        else
                            mstrInstNo = "0";


                        if (dRow.Table.Columns.Contains("LocationDescription"))
                        {
                            mstrLocationDesc = dRow["LocationDescription"].ToString().Trim();
                            mstrLocationNo = dRow["LocationNo"].ToString().Trim();
                        }


                        if (ds.Tables.Count > 3)
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                                mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                        }
                        if (mstrInstNo != "0")
                        {
                            if (i == 0)
                            {
                                if (ds.Tables.Count > 5)
                                {
                                    DataTable dtClientMain = new DataTable();
                                    DataView dv = new DataView(ds.Tables[6]);
                                    dv.RowFilter = "ClientCode='" + mstrClientCode + "'";
                                    dtClientMain = dv.ToTable();

                                    ereEvents.ShowPageNumber = false;
                                    ereEvents.DebitNote = true;
                                    ereEvents.PrintFooter = true;
                                    ereEvents.UWCOPY = false;
                                    CreateClientDebitNotePDFMaster(dtClientMain);
                                    docPDF.NewPage();
                                    blCreationSuccess = true;
                                }

                            }
                            else
                            {
                                if (i < ds.Tables[0].Rows.Count)
                                {
                                    strClientiPlus1 = ds.Tables[0].Rows[i - 1]["ClientCode"].ToString().Trim();
                                    if (mstrClientCode != strClientiPlus1)
                                    {
                                        DataTable dtClientMain = new DataTable();
                                        DataView dv = new DataView(ds.Tables[6]);
                                        dv.RowFilter = "ClientCode='" + mstrClientCode + "'";
                                        dtClientMain = dv.ToTable();
                                        ereEvents.ShowPageNumber = false;
                                        ereEvents.DebitNote = true;
                                        ereEvents.PrintFooter = true;
                                        ereEvents.UWCOPY = false;
                                        CreateClientDebitNotePDFMaster(dtClientMain);
                                        docPDF.NewPage();
                                        blCreationSuccess = true;
                                    }
                                }
                            }
                        }
                        ereEvents.ShowPageNumber = false;
                        ereEvents.DebitNote = true;
                        ereEvents.PrintFooter = true;
                        ereEvents.UWCOPY = false;
                        CreateClientDebitNotePDF(dRow);
                        docPDF.NewPage();
                        blCreationSuccess = true;

                        i++;
                    }
                }
                i = 0;
                foreach (DataRow dRow in ds.Tables[1].Rows)
                {

                    mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                    mstrClientName = dRow["ClientName"].ToString().Trim();
                    mstrClientCode = dRow["ClientCode"].ToString().Trim();
                    mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                    if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrDebitNoteDate = dRow["DebitNoteDate1"].ToString().Trim();
                    }
                    else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                    }
                    // mstrClass = dRow["MainClassName"].ToString().Trim();
                    mstrClass = dRow["SubClassName"].ToString().Trim();
                    mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                    if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrPeriod = dRow["Period1"].ToString().Trim();
                    }
                    else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrPeriod = dRow["Period"].ToString().Trim();
                    }
                    mstrCurrency = dRow["Currency"].ToString().Trim();

                    mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                    mstrBrokerage = dRow["Brokerage"].ToString().Trim();
                    mstrBrokerageRate = dRow["BrokerageRate"].ToString().Trim();
                    mstrSurcharge = Convert.ToDecimal(dRow["Surcharge"].ToString().Trim()).ToString("#,##0.00");
                    mstrLeaderfee = dRow["Fees"].ToString().Trim();
                    mstrLeaderfeeRate = dRow["FeesRate"].ToString().Trim();
                    mstrNetAmount = Convert.ToDecimal(dRow["NetAmount"].ToString().Trim()).ToString("#,##0.00");
                    mstrUWShare = dRow["UWShare"].ToString().Trim();
                    mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                    //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                    //mstrBrokerage = Convert.ToDecimal( dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                    //mstrNetAmount =  Convert.ToDecimal(dRow["NetAmount"].ToString().Trim()).ToString("#,##0.00");
                    //mstrUWShare =  Convert.ToDecimal(dRow["UWShare"].ToString().Trim()).ToString("#,##0.00");
                    //mstrTotal =  Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");
                    mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                    mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();
                    mstrUwriterCode = dRow["UnderWriterCode"].ToString().Trim();
                    mstrUwriterName = dRow["UnderWriterName"].ToString().Trim();
                    mstrRemarks = dRow["Remarks"].ToString().Trim();
                    if (ds.Tables[1].Columns.Contains("InstNo"))
                    {
                        if (dRow["InstNo"] != DBNull.Value)
                        {
                            mstrInstNo = dRow["InstNo"].ToString().Trim();
                        }
                        else
                            mstrInstNo = "0";
                    }
                    else
                        mstrInstNo = "0";

                    if (ds.Tables.Count > 3)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                            mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                    }
                    if (mstrInstNo != "0")
                    {
                        if (i == 0)
                        {
                            if (ds.Tables.Count > 6)
                            {
                                DataTable dtClientMain = new DataTable();
                                DataView dv = new DataView(ds.Tables[7]);
                                dv.RowFilter = "UnderWriterCode='" + mstrUwriterCode + "'";
                                dtClientMain = dv.ToTable();
                                ereEvents.ShowPageNumber = false;
                                ereEvents.DebitNote = false;
                                ereEvents.PrintFooter = true;
                                ereEvents.UWCOPY = true;
                                CreateUwriterDebitNotePDFMaster(dtClientMain);
                                docPDF.NewPage();
                                blCreationSuccess = true;
                            }

                        }
                        else
                        {
                            if (i < ds.Tables[1].Rows.Count)
                            {
                                strClientiPlus1 = ds.Tables[1].Rows[i - 1]["UnderWriterCode"].ToString().Trim();
                                if (mstrUwriterCode != strClientiPlus1)
                                {
                                    DataTable dtClientMain = new DataTable();
                                    DataView dv = new DataView(ds.Tables[7]);
                                    dv.RowFilter = "UnderWriterCode='" + mstrUwriterCode + "'";
                                    dtClientMain = dv.ToTable();
                                    ereEvents.ShowPageNumber = false;
                                    ereEvents.DebitNote = false;
                                    ereEvents.PrintFooter = true;
                                    ereEvents.UWCOPY = true;
                                    CreateUwriterDebitNotePDFMaster(dtClientMain);
                                    docPDF.NewPage();
                                    blCreationSuccess = true;
                                }
                            }
                        }
                    }

                    ereEvents.ShowPageNumber = false;
                    ereEvents.DebitNote = false;
                    ereEvents.UWCOPY = true;
                    CreateUwriterDebitNotePDF(dRow);
                    docPDF.NewPage();
                    blCreationSuccess = true;
                    i++;
                }
                i = 0;
                foreach (DataRow dRow in ds.Tables[2].Rows)
                {
                    mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                    mstrClientName = dRow["ClientName"].ToString().Trim();
                    mstrClientCode = dRow["ClientCode"].ToString().Trim();
                    mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                     if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrDebitNoteDate = dRow["DebitNoteDate1"].ToString().Trim();
                    }
                     else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                     {
                         mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                     }
                    // mstrClass = dRow["MainClassName"].ToString().Trim();
                    mstrClass = dRow["SubClassName"].ToString().Trim();
                    mstrCoverNoteNo = dRow["CoverNoteNo"].ToString().Trim();
                     if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                    {
                        mstrPeriod = dRow["Period1"].ToString().Trim();
                    }
                     else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                     {
                         mstrPeriod = dRow["Period"].ToString().Trim();
                     }
                    mstrCurrency = dRow["Currency"].ToString().Trim();

                    mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                    mstrBrokerage = Convert.ToDecimal(dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                    mstrAgentShare = dRow["AgentShare"].ToString().Trim();
                    mstrTotal = Convert.ToDecimal(dRow["Total"].ToString().Trim()).ToString("#,##0.00");

                    //mstrPremium =  Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                    //mstrBrokerage =  Convert.ToDecimal( dRow["Brokerage"].ToString().Trim()).ToString("#,##0.00");
                    //mstrAgentShare=  Convert.ToDecimal(dRow["AgentShare"].ToString().Trim()).ToString("#,##0.00");
                    //mstrTotal = Convert.ToDecimal(dRow["TotalDue"].ToString().Trim()).ToString("#,##0.00");


                    mstrInsurerName = dRow["InsuredName"].ToString().Trim();
                    mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();
                    mstrAgentCode = dRow["AgentCode"].ToString().Trim();
                    mstrAgentName = dRow["AgentName"].ToString().Trim();
                    mstrRemarks = dRow["Remarks"].ToString().Trim();
                    if (ds.Tables[2].Columns.Contains("InstNo"))
                    {
                        if (dRow["InstNo"] != DBNull.Value)
                        {
                            mstrInstNo = dRow["InstNo"].ToString().Trim();
                        }
                        else
                            mstrInstNo = "0";
                    }
                    else
                        mstrInstNo = "0";

                    if (ds.Tables.Count > 3)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                            mstrLegislationNote = ds.Tables[3].Rows[0]["LegislationNote"].ToString();
                    }
                    if (mstrInstNo != "0")
                    {
                        if (i == 0)
                        {
                            if (ds.Tables.Count > 7)
                            {
                                DataTable dtClientMain = new DataTable();
                                DataView dv = new DataView(ds.Tables[8]);
                                dv.RowFilter = "AgentCode='" + mstrAgentCode + "'";
                                dtClientMain = dv.ToTable();
                                ereEvents.ShowPageNumber = false;
                                ereEvents.DebitNote = false;
                                ereEvents.PrintFooter = true;
                                ereEvents.UWCOPY = true;
                                CreateAgentDebitNotePDFMaster(dtClientMain);
                                docPDF.NewPage();
                                blCreationSuccess = true;
                            }

                        }
                        else
                        {
                            if (i < ds.Tables[2].Rows.Count)
                            {
                                strClientiPlus1 = ds.Tables[2].Rows[i - 1]["AgentCode"].ToString().Trim();
                                if (mstrAgentCode != strClientiPlus1)
                                {
                                    DataTable dtClientMain = new DataTable();
                                    DataView dv = new DataView(ds.Tables[8]);
                                    dv.RowFilter = "AgentCode='" + mstrAgentCode + "'";
                                    dtClientMain = dv.ToTable();
                                    ereEvents.ShowPageNumber = false;
                                    ereEvents.DebitNote = false;
                                    ereEvents.PrintFooter = true;
                                    ereEvents.UWCOPY = true;
                                    CreateAgentDebitNotePDFMaster(dtClientMain);
                                    docPDF.NewPage();
                                    blCreationSuccess = true;
                                }
                            }
                        }
                    }
                    ereEvents.ShowPageNumber = false;
                    ereEvents.DebitNote = false;
                    ereEvents.UWCOPY = true;
                    CreateAgentDebitNotePDF(dRow);
                    docPDF.NewPage();
                    blCreationSuccess = true;
                    i++;
                }
            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                if (blCreationSuccess)
                {
                    closeDoc();
                }
            }
            return blCreationSuccess;

        }

        public bool CreateConsolidatedDebitNotePDF(string strCaseRefNo,string strDebitNoteNo, string companyName, string dateformat, string strLogoPathHeaderArr, string FooterLogo)
        {
            bool blCreationSuccess = false;
            string strClientiPlus1 = "";
            compName = companyName;
            
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();

                ds = objDebitNoteMgr.GetConsolidatedDebitNotePrintDetails(strCaseRefNo, strDebitNoteNo);
                StrCaseRefArry = strCaseRefNo.Split('~');

                //getFooter(StrCaseRefArry[0].ToString());
                //ereEvents.LogoNote = "A Member of the Hong Kong Confederation Of Insurance Brokers";

                ereEvents.ShowPageNumber = false;
               
                ereEvents.PrintFooter = true;//true
                

                CreateConsolidatedDebitNotePDFMaster(ds.Tables[0]);
                docPDF.NewPage();
                blCreationSuccess = true;

                ////foreach (DataRow dRow in ds.Tables[0].Rows)
                ////{
                ////    mstrClientName = dRow["ClientName"].ToString().Trim();
                ////    mstrClass = dRow["MainClassName"].ToString().Trim();
                ////    mstrCurrency = dRow["Currency"].ToString().Trim();

                ////    if (dRow["Premium"].ToString() != "")
                ////        mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                ////    //mstrPremium = Convert.ToDecimal(dRow["Premium"].ToString().Trim()).ToString("#,##0.00");
                ////    else
                ////        mstrPremium = dRow["Premium"].ToString().Trim();
                ////    mstrTotal += mstrPremium;

                ////    mstrPolicyNo = dRow["PolicyNo"].ToString().Trim();

                ////   // mstrDebitNoteNo = dRow["DebitNoteNo"].ToString().Trim();
                    


                ////    mstrBranchCode = dRow["BranchCode"].ToString().Trim();
                ////    if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                ////    {
                ////        mstrDebitNoteDate = dRow["DebitNoteDate1"].ToString().Trim();
                ////    }
                ////    else if (dateformat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase))
                ////    {
                ////        mstrDebitNoteDate = dRow["DebitNoteDate"].ToString().Trim();
                ////    }

                ////    int i=0;
                ////    if (i < ds.Tables[0].Rows.Count)
                ////    {

                ////            DataTable dtClientMain = new DataTable();
                ////            DataView dv = new DataView(ds.Tables[0]);
                ////            //dv.RowFilter = "ClientCode='" + mstrClientCode + "'";
                ////            dtClientMain = dv.ToTable();
                ////            ereEvents.ShowPageNumber = false;
                ////            //ereEvents.DebitNote = true;
                ////            ereEvents.PrintFooter = true;
                ////            //ereEvents.UWCOPY = false;
                         
                ////            CreateConsolidatedDebitNotePDFMaster(dtClientMain);
                ////            docPDF.NewPage();
                ////            blCreationSuccess = true;
                      
                ////    }
                ////}
            }

            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                if (blCreationSuccess)
                {
                    closeDoc();
                }
            }
            return blCreationSuccess;

        }
        private void CreateClientDebitNotePDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getClientFirstTable());
            docPDF.Add(tblContent);
        }
        private Table getClientFirstTable()
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);

            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "信貸忠告 ";
                else
                    strText = "Credit Advice ";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "繳費通知書 ";
                else
                    strText = "Debit Note";
            }
            clCurrCell = getCell(strText, "DOC_HEADER", "CENTER", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號: ";
                else
                    strText = "Credit Advice No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號: ";
                else
                    strText = "Debit Note No.";
            }

            if (mstrInstNo != "0")
            {
                mstrDebitNoteNo += "-" + mstrInstNo;
            }
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "客戶名稱: ";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "客戶編號:";
            else
                strText = "Client Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrClientCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);



            if (mstrLocationNo != "")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "位置";
                else
                    strText = "Location";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrLocationNo;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrLocationDesc;
                clCurrCell = getCell(strText, "NOTE", "JUSTIFY", "MIDDLE", 2, false, 0);
  
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "業務部門:";
            else
                strText = "Branch Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrBranchCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "日期:";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險種類:";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "暫保單編號:";
            else
                strText = "Cover Note No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險期限: ";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            // Premium
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險費: ";
            else
                strText = "Premium";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            if (mstrSurcharge != "0.00")
            {
                if (ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[4].Rows[0]["Surcharge"].ToString() != "N")
                    {

                        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            mstrSurcharge1 = ds.Tables[4].Rows[i]["Surcharge"].ToString();
                            mstrSurchargeRate = ds.Tables[4].Rows[i]["SurchargeRate"].ToString();

                            if (i == 0)
                            {

                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrLang == "C")
                                    strText = "保險徵費: ";
                                else
                                    strText = "Surcharge";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrSurcharge1 == "0.00" && mstrSurchargeRate == "" && ds.Tables[4].Rows.Count == 1)
                                    strText = mstrSurcharge;
                                else
                                    strText = mstrSurcharge1;

                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);
                            }
                            else
                            {
                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = "";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                            }
                        }
                    }
                    else
                    {
                        // For Surcharge
                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        if (mstrLang == "C")
                            strText = "保險徵費: ";
                        else
                            strText = "Surcharge";
                        clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrCurrency;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurcharge;
                        clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurchargeRate;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);
                    }
                }
                else
                {
                    // For Surcharge
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    if (mstrLang == "C")
                        strText = "保險徵費: ";
                    else
                        strText = "Surcharge";
                    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrCurrency;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurcharge;
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurchargeRate;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
            }

            if (mstrDiscount != "0.00")
            {
                // For discount
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "折扣 ";
                else
                    strText = "Discount";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrDiscount;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrDiscountRate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            //Other Charges
            if (Convert.ToDouble(mstrOther_Charges == "" ? "0" : mstrOther_Charges) > 0.00)
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "其他收费:";
                else
                    strText = "Other Charges:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrOther_Charges;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }


            if (mstrHandlingFee != "0.00")
            {
                //Handling Fee
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "手续费 ";
                else
                    strText = "Handling Fee";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrHandlingFee;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrHandlingFeeRate.Replace("(0.00%)", "");
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            // Total
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "合計:";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "这一数额是由于演示 ";
            else
                strText = "This amount is due on presentation";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "请在进行 " + mstrPaymentMethod.ToString().Trim().ToUpper() + " 应付 \"" + compName + "\"";
            else
                strText = "PLEASE MAKE " + mstrPaymentMethod.ToString().Trim().ToUpper() + " PAYABLE TO \"" + compName + "\"";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "***** " + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            if (mstrLegislationNote.Trim() != "")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrLegislationNote;
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            if (mstrInstNo != "0")
            {
                //strText = "";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);
                //strText = "REMARKS:";
                //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);


                //strText = "";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);
                //strText = "*****Official Policy No.";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);


                //strText = "";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);
                //strText = "*****Insured Contract: ";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);



                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (mstrLang == "C")
                    strText = "*****" + ToOrdinal(Convert.ToInt32(mstrInstNo)) + " 分期付款到期 " + mstrDebitNoteDate;
                else
                    strText = "*****" + ToOrdinal(Convert.ToInt32(mstrInstNo)) + " installment due on " + mstrDebitNoteDate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;


            return tblFirstSec;
        }
        private Table getClientFirstTableMaster(DataTable dt)
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "信贷忠告";
                else
                    strText = "Credit Advice ";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "繳費通知書";
                else
                    strText = "Debit Note";
            }
            clCurrCell = getCell(strText, "DOC_HEADER", "CENTER", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號: ";
                else
                    strText = "Credit Advice No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號:";
                else
                    strText = "Debit Note No.";
            }

            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "客戶名稱: ";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "客戶編號: ";
            else
                strText = "Client Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            strText = mstrClientCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);



            if (mstrLocationNo != "")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "位置 ";
                else
                    strText = "Location";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrLocationNo;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrLocationDesc;
                clCurrCell = getCell(strText, "NOTE", "JUSTIFY", "MIDDLE", 2, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "業務部門: ";
            else
                strText = "Branch Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrBranchCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "日期: ";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險種類: ";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "暫保單編號: ";
            else
                strText = "Cover Note No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險期限: ";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            // Premium
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險費:";
            else
                strText = "Premium";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            if (mstrSurcharge != "0.00")
            {
                if (ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[4].Rows[0]["Surcharge"].ToString() != "N")
                    {

                        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            mstrSurcharge1 = ds.Tables[4].Rows[i]["Surcharge"].ToString();
                            mstrSurchargeRate = ds.Tables[4].Rows[i]["SurchargeRate"].ToString();

                            if (i == 0)
                            {

                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrLang == "C")
                                    strText = "保險徵費: ";
                                else
                                    strText = "Surcharge";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrSurcharge1 == "0.00" && mstrSurchargeRate == "" && ds.Tables[4].Rows.Count == 1)
                                    strText = mstrSurcharge;
                                else
                                    strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);
                            }
                            else
                            {
                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = "";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                            }
                        }
                    }
                    else
                    {
                        // For Surcharge
                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        if (mstrLang == "C")
                            strText = "保險徵費: ";
                        else
                            strText = "Surcharge";
                        clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrCurrency;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurcharge;
                        clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurchargeRate;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);
                    }
                }
                else
                {
                    // For Surcharge
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    if (mstrLang == "C")
                        strText = "保險徵費: ";
                    else
                        strText = "Surcharge";
                    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrCurrency;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurcharge;
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurchargeRate;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
            }

            if (mstrDiscount != "0.00")
            {
                // For discount
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "折扣: ";
                else
                    strText = "Discount";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrDiscount;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrDiscountRate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            //Other Charges
            if (Convert.ToDouble(mstrOther_Charges == "" ? "0" : mstrOther_Charges) > 0.00)
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "其他收费:";
                else
                    strText = "Other Charges:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrOther_Charges;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            if (mstrHandlingFee != "0.00")
            {
                //Handling Fee
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "手续费: ";
                else
                    strText = "Handling Fee";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrHandlingFee;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = mstrHandlingFeeRate.Replace("(0.00%)", "");
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            // Total
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "合計: ";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "这一数额是由于演示";
            else
                strText = "This amount is due on presentation";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "请在进行 " + mstrPaymentMethod.ToString().Trim().ToUpper() + " 应付 \"" + compName + "\"";
            else
                strText = "PLEASE MAKE " + mstrPaymentMethod.ToString().Trim().ToUpper() + " PAYABLE TO \"" + compName + "\"";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注： ";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            if (mstrLegislationNote.Trim() != "")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                strText = "***** " + mstrLegislationNote;
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。 ";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "REMARKS:";
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Official Policy No.";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Insured Contract: ";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            if (mstrLang == "C")
                strText = "*****由 " + NumberToWords(dt.Rows.Count) + "(" + dt.Rows.Count.ToString() + ") 分期";
            else
                strText = "*****By " + NumberToWords(dt.Rows.Count) + "(" + dt.Rows.Count.ToString() + ") installments";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            for (var inti = 0; inti < dt.Rows.Count; inti++)
            {
                DataRow ndr = dt.Rows[inti];
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (mstrLang == "C")
                    strText = "*****" + ToOrdinal(inti + 1) + " 分期付款到期 " + ndr["DebitNoteDate"].ToString();
                else
                    strText = "*****" + ToOrdinal(inti + 1) + " installment due on " + ndr["DebitNoteDate"].ToString();
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "E.&.O.E";
            else
                strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;

            return tblFirstSec;
        }
        private void CreateClientDebitNotePDFMaster(DataTable dt)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getClientFirstTableMaster(dt));
            docPDF.Add(tblContent);

        }
        private Table getConsolidatedDebitNoteTableMaster(DataTable dt)
        {

            mstrRptPolicyNo = " Policy No. ";
            decimal  ttlPremium = 0;
            
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };

            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            mstrRptHeaderDate = dt.Rows[0]["Currdate"].ToString();
            mstrRptClientOfficerName = dt.Rows[0]["ClientName"].ToString();
            mstrRptClientName = dt.Rows[0]["BranchName"].ToString();
            mstrRptOrgnname = dt.Rows[0]["BranchName"].ToString();
            mstrRptLastLineName = dt.Rows[0]["ClientName"].ToString();

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            strText = "                                   ";//+  mstrRptClientOfficerName; 

            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            strText = "   " +  mstrRptClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 5);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptHeaderDate + "   ";
            clCurrCell = getCell(strText, "NOTE", "RIGHT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "   Dear ";//+ mstrRptClientOfficerName; 
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

           

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            

            strText = mstrRptsubject;
            clCurrCell = getCell(strText, "NOTE_BOLD", "CENTER", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "  " + mstrRptRptDtl;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptOrgnname + mstrRptOrgnlastWord;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //strText = mstrRptOrgnlastWord;
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 2, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "  " +  mstrRpt1stheader;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            // data looping for 1st table
            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            foreach (DataRow dr in dt.Rows )
            {
                mstrRpt1stTabColClassName = dr["MainClassName"].ToString();
                mstrRptPolicyNo = mstrRptPolicyNoHead + dr["PolicyNo"].ToString();

                strText = "\n";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (dr["MainClassName"].ToString() != "")
                {
                    strText = mstrRpt1stTabColClassName;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
                    clCurrCell.Border = Cell.LEFT_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
                else
                {
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
                    clCurrCell.Border = Cell.LEFT_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
                if (dr["PolicyNo"].ToString() != "")
                {
                    strText = mstrRptPolicyNo;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 2, false, 0);
                    clCurrCell.Border = Cell.RIGHT_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
                else
                {
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 2, false, 0);
                    clCurrCell.Border = Cell.RIGHT_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
            }

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "  "+ mstrRpt2ndHeader;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            
            // data looping for 2nd table

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptPolicyNoHeader;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Center", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOX;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptClassHeader;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Center", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.BOX;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptPremiumsHdr;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Center", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOX;
            tblFirstSec.AddCell(clCurrCell);

            

            foreach (DataRow dr in dt.Rows)
            {
                mstrRpt1stTabColClassName = dr["MainClassName"].ToString();
                mstrRptPolicyNo =  dr["PolicyNo"].ToString();
                mstrRptPremiumColm = dr["Premium"].ToString();
                mstrRptCurrency =  dr["Currency"].ToString();

               


               
                if (dr["PolicyNo"].ToString() != "")
                {

                    strText = mstrRptPolicyNo;
                    clCurrCell = getCell(strText, "NOTE", "left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                }
                else
                {
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                }
                if (dr["MainClassName"].ToString() != "")
                {
                    strText = mstrRpt1stTabColClassName;
                    clCurrCell = getCell(strText, "NOTE", "left", "MIDDLE", 3, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                }
                else
                {
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "left", "MIDDLE", 3, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                }

                if (dr["Premium"].ToString() != "")
                {
                    ttlPremium = Convert.ToDecimal(mstrRptPremiumColm.ToString());

                    mstrRptPremiumColm = mstrRptCurrency + " " + mstrRptPremiumColm;
                    strText = mstrRptPremiumColm;
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                }
                else
                {
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.BOX;
                    tblFirstSec.AddCell(clCurrCell);
                
                }

                if (dr["Premium"].ToString() != "")

                { 
                    ttlPremium += ttlPremium;
                    
                }

            }

            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.BOX;
            tblFirstSec.AddCell(clCurrCell);

            strText = mstrRptTotalPremiumDueHeader;
            clCurrCell = getCell(strText, "NOTE_BOLD", "Center", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.BOX;
            tblFirstSec.AddCell(clCurrCell);

            if (ttlPremium >=0)
            {
                strText = mstrRptCurrency + " " + ttlPremium.ToString();
                clCurrCell = getCell(strText, "NOTE_BOLD", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOX;
                tblFirstSec.AddCell(clCurrCell);
            }
            else
            {
                strText = mstrRptCurrency ;
                clCurrCell = getCell(strText, "NOTE_BOLD", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOX;
                tblFirstSec.AddCell(clCurrCell);
            
            }
            strText = "\n";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = " " + mstrRpt3rdLastline;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = " " + mstrRpt2ndLastLine;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            strText = " "+ mstrRptlastline;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "                         ";//+ mstrRptLastLineName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            getFooter(StrCaseRefArry[0].ToString());
            ereEvents.LogoNote = "A Member of the Hong Kong Confederation Of Insurance Brokers";

            tblFirstSec.TableFitsPage = true;

            return tblFirstSec;
        }

        private void CreateUwriterDebitNotePDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getUwriterFirstTable());
            docPDF.Add(tblContent);
        }
        private Table getUwriterFirstTable()
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "承销商复制";
            else
                strText = "UNDERWRITER COPY   ";
            clCurrCell = getCell(strText, "DOC_HEADER", "RIGHT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號:";
                else
                    strText = "Debit Note No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號:";
                else
                    strText = "Credit Advice No.";
            }
            if (mstrInstNo != "0")
            {
                if (mstrDebitNoteNo.Trim().Length > 0)
                {
                    if (mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 5, 5).Contains("SA"))
                    {
                        string strUWCode = mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 5, 5);
                        mstrDebitNoteNo = mstrDebitNoteNo.Substring(0, mstrDebitNoteNo.Length - 5) + "-" + mstrInstNo + strUWCode;

                    }
                    else
                    {
                        string strUWCode = mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 2, 2);
                        mstrDebitNoteNo = mstrDebitNoteNo.Substring(0, mstrDebitNoteNo.Length - 2) + "-" + mstrInstNo + strUWCode;
                    }
                }
            }
            //strText = "Credit Advice No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Five Column
            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrUwriterName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險公司編號:";
            else
                strText = "U/W Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrUwriterCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "日期:";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "Insured";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險種類:";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Column
            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "出單指示編號:";
            else
                strText = "Closing No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Column
            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險期限:";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Column
            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保單號碼:";
            else
                strText = "Policy No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Column
            strText = mstrPolicyNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險費:";
            else
                strText = "Premium";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrBrokerage != "0.00")
            {

                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


                //Second Column
                if (mstrLang == "C")
                    strText = "經紀費:";
                else
                    strText = "Brokerage";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrBrokerage;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                if (mstrBrokerageType.Trim() == "%")
                    strText = mstrBrokerageRate;
                else
                    strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            if (mstrSurcharge != "0.00")
            {
                if (ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[4].Rows[0]["Surcharge"].ToString() != "N")
                    {

                        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            mstrSurcharge1 = ds.Tables[4].Rows[i]["Surcharge"].ToString();
                            mstrSurchargeRate = ds.Tables[4].Rows[i]["SurchargeRate"].ToString();

                            if (i == 0)
                            {

                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrLang == "C")
                                    strText = "保險徵費:";
                                else
                                    strText = "Surcharge";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);
                            }
                            else
                            {
                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = "";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                            }
                        }
                    }
                    else
                    {
                        // For Surcharge
                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        if (mstrLang == "C")
                            strText = "保險徵費:";
                        else
                            strText = "Surcharge";
                        clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrCurrency;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurcharge;
                        clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);
                    }
                }
                else
                {
                    // For Surcharge
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    if (mstrLang == "C")
                        strText = "保險徵費:";
                    else
                        strText = "Surcharge";
                    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrCurrency;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurcharge;
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
            }
            //if (mstrSurcharge != "0.00")
            //{
            //    //First Column
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Second Column
            //    strText = "Surcharge";
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Third Column
            //    strText = mstrCurrency;
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Four Column
            //    strText = mstrSurcharge;
            //    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Five Column
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //}
            if (mstrLeaderfee != "0.00")
            {
                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Second Column
                if (mstrLang == "C")
                    strText = "负责人费";
                else
                    strText = "Leader Fee";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrLeaderfee;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                strText = mstrLeaderfeeRate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }


            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "淨保費:";
            else
                strText = "Net Amount";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrNetAmount;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險公司份額:";
            else
                strText = "U/W Share";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrUWShare;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "合計:";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注：";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            //if (mstrLegislationNote.Trim() != "")
            //{
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //    strText = "***** " + mstrLegislationNote;
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //}


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "This is Credit Advice issued to " + mstrUwriterName;
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                //strText = "This is a computer-generated Debit Note and does not require a signature.";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            if (mstrInstNo != "0")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (mstrLang == "C")
                    strText = "*****" + ToOrdinal(Convert.ToInt32(mstrInstNo)) + " 分期付款到期 " + mstrDebitNoteDate;
                else
                    strText = "*****" + ToOrdinal(Convert.ToInt32(mstrInstNo)) + " installment due on " + mstrDebitNoteDate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "E.&.O.E";
            else
                strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;


            return tblFirstSec;
        }
        private void CreateConsolidatedDebitNotePDFMaster(DataTable dt)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getConsolidatedDebitNoteTableMaster(dt));
            docPDF.Add(tblContent);
        }

        private void CreateUwriterDebitNotePDFMaster(DataTable dt)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getUwriterFirstTableMaster(dt));
            docPDF.Add(tblContent);
        }
        private Table getUwriterFirstTableMaster(DataTable dt)
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "承销商复制";
            else
                strText = "UNDERWRITER COPY   ";
            clCurrCell = getCell(strText, "DOC_HEADER", "RIGHT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號:";
                else
                    strText = "Debit Note No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號:";
                else
                    strText = "Credit Advice No.";
            }
            //strText = "Credit Advice No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Five Column
            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrUwriterName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險公司編號:";
            else
                strText = "U/W Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrUwriterCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "日期:";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "Insured";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險種類:";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "出單指示編號:";
            else
                strText = "Closing No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險期限:";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保單號碼:";
            else
                strText = "Policy No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPolicyNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險費:";
            else
                strText = "Premium";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrBrokerage != "0.00")
            {

                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


                //Second Column
                if (mstrLang == "C")
                    strText = "經紀費:";
                else
                    strText = "Brokerage";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrBrokerage;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                if (mstrBrokerageType == "%")
                    strText = mstrBrokerageRate;
                else
                    strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            if (mstrSurcharge != "0.00")
            {
                if (ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[4].Rows[0]["Surcharge"].ToString() != "N")
                    {

                        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            mstrSurcharge1 = ds.Tables[4].Rows[i]["Surcharge"].ToString();
                            mstrSurchargeRate = ds.Tables[4].Rows[i]["SurchargeRate"].ToString();

                            if (i == 0)
                            {

                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrLang == "C")
                                    strText = "保險徵費:";
                                else
                                    strText = "Surcharge";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                if (mstrSurcharge1 == "0.00" && mstrSurchargeRate == "" && ds.Tables[4].Rows.Count == 1)
                                    strText = mstrSurcharge;
                                else
                                    strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);
                            }
                            else
                            {
                                // For Surcharge
                                strText = "";
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = "";
                                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrCurrency;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurcharge1;
                                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                                strText = mstrSurchargeRate;
                                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                                clCurrCell.Border = Cell.NO_BORDER;
                                tblFirstSec.AddCell(clCurrCell);

                            }
                        }
                    }
                    else
                    {
                        // For Surcharge
                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        if (mstrLang == "C")
                            strText = "保險徵費:";
                        else
                            strText = "Surcharge";
                        clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrCurrency;
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = mstrSurcharge;
                        clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);

                        strText = "";
                        clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                        clCurrCell.Border = Cell.NO_BORDER;
                        tblFirstSec.AddCell(clCurrCell);
                    }
                }
                else
                {
                    // For Surcharge
                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    if (mstrLang == "C")
                        strText = "保險徵費:";
                    else
                        strText = "Surcharge";
                    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrCurrency;
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = mstrSurcharge;
                    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);

                    strText = "";
                    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                    clCurrCell.Border = Cell.NO_BORDER;
                    tblFirstSec.AddCell(clCurrCell);
                }
            }
            //if (mstrSurcharge != "0.00")
            //{
            //    //First Column
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Second Column
            //    strText = "Surcharge";
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Third Column
            //    strText = mstrCurrency;
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Four Column
            //    strText = mstrSurcharge;
            //    clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //    //Five Column
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);

            //}
            if (mstrLeaderfee != "0.00")
            {
                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Second Column
                if (mstrLang == "C")
                    strText = "负责人费";
                else
                    strText = "Leader Fee";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrLeaderfee;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                strText = mstrLeaderfeeRate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }


            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "淨保費:";
            else
                strText = "Net Amount";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrNetAmount;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險公司份額:";
            else
                strText = "U/W Share";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrUWShare;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "合計:";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注：";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //if (mstrLegislationNote.Trim() != "")
            //{
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //    strText = "***** " + mstrLegislationNote;
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //}

            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "This is Credit Advice issued to " + mstrUwriterName;
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                //strText = "This is a computer-generated Debit Note and does not require a signature.";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "REMARKS:";
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Official Policy No.";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Insured Contract: ";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            if (mstrLang == "C")
                strText = "*****由 " + NumberToWords(dt.Rows.Count) + "(" + dt.Rows.Count.ToString() + ") 分期";
            else
                strText = "*****By " + NumberToWords(dt.Rows.Count) + "(" + dt.Rows.Count.ToString() + ") installments";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            for (var inti = 0; inti < dt.Rows.Count; inti++)
            {
                DataRow ndr = dt.Rows[inti];
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (mstrLang == "C")
                    strText = "*****" + ToOrdinal(inti + 1) + " 分期付款到期 " + ndr["DebitNoteDate"].ToString();
                else
                    strText = "*****" + ToOrdinal(inti + 1) + " installment due on " + ndr["DebitNoteDate"].ToString();
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "E.&.O.E";
            else
                strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;

            return tblFirstSec;
        }

        private void CreateAgentDebitNotePDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getAgentFirstTable());
            docPDF.Add(tblContent);
        }
        private Table getAgentFirstTable()
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;

            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險代理 ";
            else
                strText = "AGENT COPY       ";
            clCurrCell = getCell(strText, "DOC_HEADER", "RIGHT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號:";
                else
                    strText = "Debit Note No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號:";
                else
                    strText = "Credit Advice No.";
            }

            if (mstrInstNo != "0")
            {
                if (mstrDebitNoteNo.Trim().Length > 0)
                {
                    if (mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 5, 5).Contains("SA"))
                    {
                        string strUWCode = mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 5, 5);
                        mstrDebitNoteNo = mstrDebitNoteNo.Substring(0, mstrDebitNoteNo.Length - 5) + "-" + mstrInstNo + strUWCode;

                    }
                    else
                    {
                        string strUWCode = mstrDebitNoteNo.Substring(mstrDebitNoteNo.Length - 2, 2);
                        mstrDebitNoteNo = mstrDebitNoteNo.Substring(0, mstrDebitNoteNo.Length - 2) + "-" + mstrInstNo + strUWCode;
                    }
                }
            }

            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Five Column
            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險代理名稱:";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrAgentName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險代理編號:";
            else
                strText = "Agent Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrAgentCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "日期:";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "Insured";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險種類:";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "暫保單編號:";
            else
                strText = "Cover Note No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保险期限:";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保單號碼:";
            else
                strText = "Policy No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPolicyNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrBrokerage == "0.00")
            {
                if (mstrLang == "C")
                    strText = "费:";
                else
                    strText = "Fee";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "保險費:";
                else
                    strText = "Premium";
            }
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrBrokerage != "0.00")
            {

                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Second Column
                if (mstrLang == "C")
                    strText = "總經紀費:";
                else
                    strText = "Total Brokerage";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrBrokerage;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "代理份額:";
            else
                strText = "Your Share";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrAgentShare;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "合計:";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注：";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //if (mstrLegislationNote.Trim() != "")
            //{
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //    strText = "***** " + mstrLegislationNote;
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //}

            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "This is Credit Advice issued to " + mstrAgentName;
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                //strText = "This is a computer-generated Debit Note and does not require a signature.";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            if (mstrInstNo != "0")
            {
                //strText = "";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);
                //strText = "*****Insured Contract: ";
                //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                //clCurrCell.Border = Cell.NO_BORDER;
                //tblFirstSec.AddCell(clCurrCell);



                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                //if (mstrLang == "C")
                //    strText = "折扣: ";
                //else
                strText = "*****" + ToOrdinal(Convert.ToInt32(mstrInstNo)) + " installment due on " + mstrDebitNoteDate;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;


            return tblFirstSec;
        }

        private void CreateAgentDebitNotePDFMaster(DataTable dt)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 5;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getAgentFirstTableMaster(dt));
            docPDF.Add(tblContent);
        }
        private Table getAgentFirstTableMaster(DataTable dt)
        {
            Table tblFirstSec = new Table(5);
            int[] flColWidth = { 13, 30, 7, 15, 28 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 5;


            strText = "\n\n\n\n\n";
            clCurrCell = getCell(strText, "NOTE", "LEFT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrLang == "C")
                strText = "保險代理";
            else
                strText = "AGENT COPY       ";
            clCurrCell = getCell(strText, "DOC_HEADER", "RIGHT", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (PolicyStatus == "CNCANC")
            {
                if (mstrLang == "C")
                    strText = "繳費通知書編號:";
                else
                    strText = "Debit Note No.";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "退費通知書編號:";
                else
                    strText = "Credit Advice No.";
            }
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four Five Column
            strText = mstrDebitNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 25);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險代理名稱:";
            else
                strText = "To";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrAgentName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險代理編號:";
            else
                strText = "Agent Code";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrAgentCode;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "日期:";
            else
                strText = "Date";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrDebitNoteDate;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "客戶名稱:";
            else
                strText = "Insured";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClientName;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "暫保單編號:";
            else
                strText = "Class";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrClass;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "暫保單編號:";
            else
                strText = "Cover Note No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrCoverNoteNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保險期限:";
            else
                strText = "Period of Insurance";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPeriod;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "保單號碼:";
            else
                strText = "Policy No.";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third , Four, Five Column
            strText = mstrPolicyNo;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 3, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrBrokerage == "0.00")
            {
                if (mstrLang == "C")
                    strText = "费 ";
                else
                    strText = "Fee";
            }
            else
            {
                if (mstrLang == "C")
                    strText = "保險費:";
                else
                    strText = "Premium";
            }
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrPremium;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrBrokerage != "0.00")
            {

                //First Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Second Column
                if (mstrLang == "C")
                    strText = "總經紀費:";
                else
                    strText = "Total Brokerage";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Third Column
                strText = mstrCurrency;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Four Column
                strText = mstrBrokerage;
                clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.BOTTOM_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //Five Column
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "代理份額:";
            else
                strText = "Your Share";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrAgentShare;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //First Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Second Column
            if (mstrLang == "C")
                strText = "合計:";
            else
                strText = "Total";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Third Column
            strText = mstrCurrency;
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Four Column
            strText = mstrTotal;
            clCurrCell = getCell(strText, "NOTE", "Right", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.BOTTOM_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //Five Column
            strText = "";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (mstrRemarks != "")
            {

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                if (mstrLang == "C")
                    strText = "备注：";
                else
                    strText = "REMARKS:";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 30);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                strText = "*****" + mstrRemarks;
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 0);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 5, false, 0);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //if (mstrLegislationNote.Trim() != "")
            //{
            //    strText = "";
            //    clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //    strText = "***** " + mstrLegislationNote;
            //    clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //    clCurrCell.Border = Cell.NO_BORDER;
            //    tblFirstSec.AddCell(clCurrCell);
            //}


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "This is Credit Advice issued to " + mstrAgentName;
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            if (IsMUlLocation == "Y")
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                if (PolicyStatus == "CNCANC")
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的的借记票据及不要求签名。 ";
                    else
                        strText = "This is a computer-generated Debit Note and does not require a signature.";
                }
                else
                {
                    if (mstrLang == "C")
                        strText = "这是一个计算机生成的信用咨询和不需要签名。";
                    else
                        strText = "This is a computer-generated Credit Advice and does not require a signature.";
                }
                //strText = "This is a computer-generated Debit Note and does not require a signature.";
                clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }
            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);

            //strText = "REMARKS:";
            //clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 0);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Official Policy No.";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            //strText = "";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);
            //strText = "*****Insured Contract: ";
            //clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
            //clCurrCell.Border = Cell.NO_BORDER;
            //tblFirstSec.AddCell(clCurrCell);


            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            strText = "*****By " + NumberToWords(dt.Rows.Count) + "(" + dt.Rows.Count.ToString() + ") installments";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 20);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            for (var inti = 0; inti < dt.Rows.Count; inti++)
            {
                DataRow ndr = dt.Rows[inti];
                strText = "";
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
                strText = "*****" + ToOrdinal(inti + 1) + " installment due on " + ndr["DebitNoteDate"].ToString();
                clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 4, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);
            }

            strText = "";
            clCurrCell = getCell(strText, "NOTE", "Left", "MIDDLE", 1, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "E.&.O.E";
            clCurrCell = getCell(strText, "NOTE_BOLD", "Left", "MIDDLE", 4, false, 50);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.TableFitsPage = true;

            return tblFirstSec;
        }

        protected void createAndOpenNewDoc()
        {
            docPDF = new Document(PageSize.A4, mintLeftBorder, mintRightBorder, mintTopBorder, mintBottomBorder);
            createFolders(strPDFFilePath);
            FileStream fsPDFStream = new FileStream(strPDFFilePath, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPDF, fsPDFStream);
            pdfWriter.PageEvent = ereEvents;
            docPDF.Open();
            isPDFCreated = true;
        }

        private void createFolders(string strPath)
        {
            //string lastFolderName = Path.GetFileName(Path.GetDirectoryName(strPath));
            string sDirectory = Path.GetDirectoryName(strPath);
            try
            {
                if (!Directory.Exists(sDirectory))
                {
                    Directory.CreateDirectory(sDirectory);
                }
            }
            catch { 

            }

        }


        //protected void SurchargeDebitNoteWithCoverNote(string strCaseRefNo, string mstrDebitNoteNo, string mstrClientCode, string mstrRefNo)
        //{


        //    ds = objDebitNoteMgr.GetDebitNotePrintDetailsSurcharge(strCaseRefNo, mstrDebitNoteNo, mstrClientCode, mstrRefNo);


        //}

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "ZERO";

            if (number < 0)
                return "MINUS " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " HUNDRED ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "AND ";

                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string ToOrdinal(int number)
        {
            if (number < 0) return number.ToString();
            int rem = number % 100;
            if (rem >= 11 && rem <= 13) return number + "th";
            switch (number % 10)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }
    

    
    }
}
