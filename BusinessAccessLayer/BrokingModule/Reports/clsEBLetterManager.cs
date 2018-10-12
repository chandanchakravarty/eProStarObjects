using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Claims;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using BusinessObjectLayer.BrokingModule.Reports;

namespace BusinessAccessLayer.BrokingModule.Reports
{
    public class clsEBLetterManager
    {
        DataAccess dataAccess = null;
        public DataSet GetEBClaimLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_EBLetter_Select", "EB_LetterList");
        }
        public DataSet GetEBMovementLetterList(string CovernoteNo, string ReportNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CovernoteNo, ReportNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_MovementEBLetter_Select", "EB_LetterList");
        }
        public DataSet GetEBInsurerInpatientLetterList(string UWCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { UWCode };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_EBInsurerInpatient_Select", "EB_LetterList");
        }
        public DataSet GetFooterCountry(string strModule)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strModule };
            return dataAccess.LoadDataSet(parameters, "P_TM_FooterCountry_Select", "FooterCountryList");
        }
        public DataSet GetFooterAddress(int polid,int polverid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { polid, polverid };
            return dataAccess.LoadDataSet(parameters, "P_TM_FooterCompanyAddress_Select", "FooterCountryList");
        }


        public DataSet GetEBLetterClaimOutstandingList(clsEBClaimDetails objEBClaimDetails, string SPRClaimStatus)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[21] { objEBClaimDetails.ClaimNo, objEBClaimDetails.MemberCode, objEBClaimDetails.MemberName, objEBClaimDetails.PassportNo, objEBClaimDetails.ClientCode, objEBClaimDetails.ClientName, objEBClaimDetails.UwriterCode, objEBClaimDetails.UwriterName, objEBClaimDetails.CoverNoteNo, objEBClaimDetails.PolicyNo, objEBClaimDetails.SubClass, objEBClaimDetails.ClaimTypeDesc, objEBClaimDetails.AdmissionDate, objEBClaimDetails.UserID, objEBClaimDetails.ClaimStatus, objEBClaimDetails.IssueFromDate, objEBClaimDetails.IssueToDate, objEBClaimDetails.POIFromDate, objEBClaimDetails.POIToDate, objEBClaimDetails.CertificateNo, SPRClaimStatus };
            //Object[] parameters = new Object[20] { objEBClaimDetails.ClaimNo, objEBClaimDetails.MemberCode, objEBClaimDetails.MemberName, objEBClaimDetails.PassportNo, objEBClaimDetails.ClientCode, objEBClaimDetails.ClientName, objEBClaimDetails.UwriterCode, objEBClaimDetails.UwriterName, objEBClaimDetails.CoverNoteNo, objEBClaimDetails.PolicyNo, objEBClaimDetails.SubClass, objEBClaimDetails.ClaimTypeDesc, objEBClaimDetails.AdmissionDate, objEBClaimDetails.UserID, objEBClaimDetails.ClaimStatus, objEBClaimDetails.IssueFromDate, objEBClaimDetails.IssueToDate, objEBClaimDetails.POIFromDate, objEBClaimDetails.POIToDate, objEBClaimDetails.CertificateNo };
            return dataAccess.LoadDataSet(parameters, "P_EBLetter_ClaimOutstandingList", "EB_ClaimOutstandingList");
        }
        public DataSet GetECLetterClaimOutstandingList(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[22] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.Location, objECClaim.MotorRegNo, objECClaim.ThirdPartyDetails, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.LossNature, objECClaim.CauseOfLoss, objECClaim.ChequeRefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECLetter_ViewClaimsList", "EC_ViewClaimsList");
        }
        public DataSet GetBusinessLetterList(clsBusinessReport objBusiness)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] { 
                objBusiness.CompanyId, 
                objBusiness.BranchId, 
                objBusiness.ClientCode, 
                objBusiness.ClientName, 
                objBusiness.UnderwriterCode,
                objBusiness.UnderwriterName, 
                objBusiness.AgentCode, 
                objBusiness.AgentName, 
                objBusiness.Group, 
                objBusiness.SubGroup, 
                objBusiness.BNC,
                objBusiness.SourceCode,
                objBusiness.MainClass,
                objBusiness.POIFromDate, 
                objBusiness.POIToDate,
                objBusiness.DNFromDate, 
                objBusiness.DNToDate,
                objBusiness.UnderwriterShortName,
                objBusiness.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RPT_InsuranceMgmtReport", "TM_DebitNoteWOCoverNote");
        }

        public DataSet GetBusinessToAGLetterList(clsBusinessReport objBusiness)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] { 
                objBusiness.CompanyId, 
                objBusiness.BranchId, 
                objBusiness.ClientCode, 
                objBusiness.ClientName, 
                objBusiness.UnderwriterCode,
                objBusiness.UnderwriterName, 
                objBusiness.AgentCode, 
                objBusiness.AgentName, 
                objBusiness.Group, 
                objBusiness.SubGroup, 
                objBusiness.BNC,
                objBusiness.SourceCode,
                objBusiness.MainClass,
                objBusiness.POIFromDate, 
                objBusiness.POIToDate,
                objBusiness.DNFromDate, 
                objBusiness.DNToDate ,
                objBusiness.UnderwriterShortName,
                objBusiness.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RPT_BusinessToAGReport", "TM_DebitNoteWOCoverNote");
        }

        public DataSet GetBusinessToUNLetterList(clsBusinessReport objBusiness)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] { 
                objBusiness.CompanyId, 
                objBusiness.BranchId, 
                objBusiness.ClientCode, 
                objBusiness.ClientName, 
                objBusiness.UnderwriterCode,
                objBusiness.UnderwriterName, 
                objBusiness.AgentCode, 
                objBusiness.AgentName, 
                objBusiness.Group, 
                objBusiness.SubGroup, 
                objBusiness.BNC,
                objBusiness.SourceCode,
                objBusiness.MainClass,
                objBusiness.POIFromDate, 
                objBusiness.POIToDate,
                objBusiness.DNFromDate, 
                objBusiness.DNToDate,
                objBusiness.UnderwriterShortName,objBusiness.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RPT_BusinessToUNReport", "TM_DebitNoteWOCoverNote");
        }

        public DataSet GetECClaimLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_ECLetter_Select", "EC_LetterList");
        }

        /// <summary>
        ///  developed by Ebix India on 22nd Nov, 2012
        /// </summary>
        /// <returns></returns>
        public DataSet GetECChineseEnglishLetterList(String caseRefNo, String claimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { caseRefNo, claimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_ECChineseEnglishLetter_Select", "EC_ChineseEnglishLetterList");
        }
        public DataSet GetECPARLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_ECPARLetter_Select", "EC_ParLetterList");
        }
        public DataSet GetEBRenewalLetterList(long PolicyId, int PolVersionId, string DebitNoteNo, string LetterType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { PolicyId, PolVersionId, DebitNoteNo, LetterType };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_EBRenewalLetter_Select", "EB_RenewalLetterList");
        }
        public DataSet GetEnquiryList(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[25] { 
                objEnquiryReport.DNFromDate, 
                objEnquiryReport.DNToDate, 
                objEnquiryReport.POIFromDate, 
                objEnquiryReport.POIToDate, 
                objEnquiryReport.ClientName,
                objEnquiryReport.ClientCode, 
                objEnquiryReport.AccountHandler, 
                objEnquiryReport.MainClass, 
                objEnquiryReport.SubClass, 
                objEnquiryReport.UnderwriterName, 
                objEnquiryReport.GlobalProgram,
                objEnquiryReport.BusinessType,
                objEnquiryReport.RenewalType,
                objEnquiryReport.RenewalStatus, 
                objEnquiryReport.ClaimStatus,
                objEnquiryReport.Team, 
                objEnquiryReport.AgentName,
                objEnquiryReport.KeyAccountmanager,
                objEnquiryReport.Industrytype,
                objEnquiryReport.ProfitCentre,
                objEnquiryReport.Branch
                ,objEnquiryReport.AccountingMonthFrom
                ,objEnquiryReport.AccountingMonthTo
                ,objEnquiryReport.ReportBy,objEnquiryReport.UserId
            };
            return dataAccess.LoadDataSetWithTimeout(parameters, "P_Pol_EnquiryReport", "EnquiryReport");
        }
        public DataSet GetProductionList(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[30] { 
                objEnquiryReport.DNFromDate, 
                objEnquiryReport.DNToDate, 
                objEnquiryReport.POIFromDate, 
                objEnquiryReport.POIToDate, 
                objEnquiryReport.PlacementClosingNo,
                objEnquiryReport.ClientName,
                objEnquiryReport.ClientCode, 
                objEnquiryReport.AccountHandler, 
                objEnquiryReport.MainClass, 
                objEnquiryReport.SubClass, 
                objEnquiryReport.UnderwriterName, 
                objEnquiryReport.GlobalProgram,
                objEnquiryReport.BusinessType,
                objEnquiryReport.RenewalType,
                objEnquiryReport.Team, 
                objEnquiryReport.AgentName ,
                objEnquiryReport.KeyAccountmanager,
                objEnquiryReport.Industrytype,
                objEnquiryReport.ProfitCentre,
                objEnquiryReport.Branch
                ,objEnquiryReport.AccountingMonthFrom
                ,objEnquiryReport.AccountingMonthTo
                ,objEnquiryReport.ReportBy
                ,objEnquiryReport.DivisionalGrouping
                ,objEnquiryReport.ProjectTitle
               ,objEnquiryReport.BillingParty
               ,objEnquiryReport.ClientSourceCode
               ,objEnquiryReport.MasterClient
               ,objEnquiryReport.CorporateGroup,
               objEnquiryReport.UserId
               
            };
            return dataAccess.LoadDataSetWithTimeout(parameters, "P_Pol_ProductionReport", "ProductionReport");
        }
        public DataSet GetProducerList(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { 
                objEnquiryReport.ClientName, 
                objEnquiryReport.AccountHandler, 
                objEnquiryReport.MainClass, 
                objEnquiryReport.SubClass, 
                objEnquiryReport.AccountingMonthFrom,
                objEnquiryReport.AccountingMonthTo               
            };
            return dataAccess.LoadDataSetWithTimeout(parameters, "P_Pol_ProducERReport", "ProducerReport");
        }
        public DataSet GetPremiumSummary(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[18] { 
                objEnquiryReport.DNFromDate, 
                objEnquiryReport.DNToDate, 
                objEnquiryReport.POIFromDate, 
                objEnquiryReport.POIToDate, 
                objEnquiryReport.PlacementClosingNo,
                objEnquiryReport.ClientName,
                objEnquiryReport.ClientCode, 
                objEnquiryReport.AgentId,
                objEnquiryReport.MainClass, 
                objEnquiryReport.UnderwriterName,
                objEnquiryReport.ProfitCenter,
                objEnquiryReport.Branch
                ,objEnquiryReport.AccountingMonthFrom
                ,objEnquiryReport.AccountingMonthTo
                ,objEnquiryReport.ReportBy,
                objEnquiryReport.UserId,
                objEnquiryReport.SubClass,
                objEnquiryReport.Team
            };
            return dataAccess.LoadDataSetWithTimeout(parameters, "P_Pol_PremiumSummaryReport", "PremiumSummaryReport");
        }
        public DataSet GetMainClass(clsEnquiryReport objMainClass)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[20] { 
                objMainClass.DNFromDate, 
                objMainClass.DNToDate, 
                objMainClass.PlacementClosingNo,
                objMainClass.ClientName,
                objMainClass.ClientCode, 
                objMainClass.AccountHandler, 
                objMainClass.MainClass, 
                objMainClass.UnderwriterName, 
                objMainClass.GlobalProgram,
                objMainClass.BusinessType,
                objMainClass.RenewalType,
                objMainClass.AgentName,
                objMainClass.ProfitCentre,
                objMainClass.Branch
                ,objMainClass.AccountingMonthFrom
                ,objMainClass.AccountingMonthTo
                ,objMainClass.ReportType
                ,objMainClass.UserId
                ,objMainClass.TeamID //Redmine #33818
                ,objMainClass.CustomizedClient //Redmine #33818
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_MainClassReport", "MainClass");
        }
        public DataSet GetPremiumStatus(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[20] { 
                objEnquiryReport.POIFromDate, 
                objEnquiryReport.POIToDate, 
                objEnquiryReport.PlacementClosingNo,
                objEnquiryReport.MainClass,
                objEnquiryReport.SubClass ,
                objEnquiryReport.ClientName,
                objEnquiryReport.ClientCode, 
                objEnquiryReport.AgentId,
                objEnquiryReport.AccountHandler,
                objEnquiryReport.PolicyNo,
                objEnquiryReport.VehicleNo,
                objEnquiryReport.PremiumStatus,
                objEnquiryReport.DNCNNo,
                objEnquiryReport.Team,
                objEnquiryReport.KeyAccountmanager,
                objEnquiryReport.Industrytype,
                objEnquiryReport.ProfitCenter,
                objEnquiryReport.Branch,
                objEnquiryReport.ProjectTitle,objEnquiryReport.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_PremiumStatusReport1", "PremiumStatus");
        }
        public DataSet GetMasterClientReport(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[15] { 
                objReportParams.ReportType,
                objReportParams.DNFromDate, 
                objReportParams.DNToDate, 
                objReportParams.ClientName,
                objReportParams.ClientCode,
                objReportParams.AccountHandler, 
                objReportParams.PolicyNo, 
                objReportParams.MainClass, 
                objReportParams.UnderwriterName,
                objReportParams.ProfitCenter,
                objReportParams.Branch
                ,objReportParams.AccountingMonthFrom
                ,objReportParams.AccountingMonthTo
                ,objReportParams.ReportBy,
                objReportParams.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_MasterClientReport", "MasterClient");
        }
        public DataSet GetUnsuccessfulQuotations(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[10] { 
                objReportParams.DNFromDate, 
                objReportParams.DNToDate, 
                objReportParams.ClientName,
                objReportParams.ClientCode,
                objReportParams.AccountHandler, 
                objReportParams.MainClass, 
                objReportParams.UnderwriterName,
                  objReportParams.ProfitCenter,
                objReportParams.Branch,objReportParams.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Unsuccessful_Quotations", "UnsuccessfulQuotations");
        }
        public DataSet GetLapsedReport(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[15] { 
                objReportParams.POIFromDate, 
                objReportParams.POIToDate, 
                objReportParams.DNFromDate, 
                objReportParams.DNToDate, 
                objReportParams.ClientName,
                objReportParams.ClientCode,
                objReportParams.AccountHandler, 
                objReportParams.MainClass, 
                objReportParams.SubClass,
                objReportParams.UnderwriterName,
                objReportParams.VehicleNo,
                objReportParams.Team,
                objReportParams.ProfitCenter,
                objReportParams.Branch,objReportParams.UserId

            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_LapsedReport", "LapsedReport");
        }
        public DataSet GetTransactionLog(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[15] { 
                objReportParams.POIFromDate, 
                objReportParams.POIToDate, 
                objReportParams.PlacementClosingNo,
                objReportParams.QuotationNo,
                objReportParams.ClientName,
                objReportParams.ClientCode,
                objReportParams.AccountHandler, 
                objReportParams.MainClass, 
                objReportParams.UnderwriterName,
                objReportParams.EndorsementNo,
                objReportParams.ProfitCenter,
                objReportParams.Branch,
                objReportParams.Team,
                objReportParams.SubClass,objReportParams.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Transaction_Log", "TransactionLog");
        }
        public DataSet GetUserLog(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { 
                objReportParams.AccountHandler, 
                objReportParams.LogInNameTo,
                objReportParams.POIFromDate, 
                objReportParams.POIToDate ,objReportParams.UserId
            };
            return dataAccess.LoadDataSet(parameters, "P_POL_UserLogDetails", "UserLog");
        }
       
        public DataSet GetClaimEnquiryList(clsEnquiryReport objEnquiryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[18] { 
                 objEnquiryReport.POIFromDate
                ,objEnquiryReport.POIToDate
                ,objEnquiryReport.LossFromDate
                ,objEnquiryReport.LossToDate
                ,objEnquiryReport.NotificationFromDate
                ,objEnquiryReport.NotificationToDate
                ,objEnquiryReport.MasterClientName
                ,objEnquiryReport.MasterClientCode
                ,objEnquiryReport.ClientName
                ,objEnquiryReport.ClientCode
                ,objEnquiryReport.MainClass
                ,objEnquiryReport.SubClass
                ,objEnquiryReport.DivisionalGrouping
                ,objEnquiryReport.KeyAccountmanager
                ,objEnquiryReport.UnderwriterName
                ,objEnquiryReport.Team
                ,objEnquiryReport.AgentName,objEnquiryReport.UserId

            };
            return dataAccess.LoadDataSetWithTimeout(parameters, "P_Pol_ClaimEnquiryReport", "ClaimEnquiryReport");
        }
        public DataSet GetClaimTimeBarReport(clsEnquiryReport objReportParams)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { 
                objReportParams.LossFromDate, 
                objReportParams.LossToDate, 
                objReportParams.UnderwriterName,
                objReportParams.ClientCode,               
                objReportParams.MainClass, 
                objReportParams.ClaimStatus
            };
            return dataAccess.LoadDataSet(parameters, "P_RptClaimTimeBar", "RptClaimTimeBar");
        }
    }
}
