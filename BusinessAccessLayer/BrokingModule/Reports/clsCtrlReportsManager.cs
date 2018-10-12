using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.Reports;

namespace BusinessAccessLayer.BrokingModule.Reports
{
    public class clsCtrlReportsManager
    {
        DataAccess dataAccess = null;
        public DataSet GetUWrList(clsControlReports objControlReports)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objControlReports.UnderwriterCode, objControlReports.CountryCode };
            return dataAccess.LoadDataSet(parameters, "P_ContentReports_UWDetails", "UnderWriterDetails");
        }

        public DataSet GetAgentList(clsControlReports objControlReports)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objControlReports.AgentCode, objControlReports.CountryCode };
            return dataAccess.LoadDataSet(parameters, "P_ContentReports_AgentDetails", "AgentDetails");
        }
        public DataSet GetAnalysisCodeList(clsControlReports objControlReports)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objControlReports.IsSourceCode, objControlReports.IsBranchCode, objControlReports.IsClassCode, objControlReports.IsNRP, objControlReports.IsBusinessNatureCode };

            return dataAccess.LoadDataSet(parameters, "P_ContentReports_AnalysisCodeDetails", "AnalysisCodeDetails");
        }

        public DataSet GetGroupandSubGroup(clsControlReports objControlReports)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objControlReports.GroupCode, objControlReports.SubGroupCode };

            return dataAccess.LoadDataSet(parameters, "P_ContentReports_GroupandSubGroup", "GroupandSubGroupDetails");
        }


        public DataSet GetClaimsCodeList(clsControlReports objctrlRpt)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objctrlRpt.IsClaimHandler, objctrlRpt.IsAccountHandler, objctrlRpt.IsHealthCare, objctrlRpt.IsSurveyor, objctrlRpt.IsLossAdjuster, objctrlRpt.IsSolicitor, objctrlRpt.IsNatureofInjury, objctrlRpt.IsCauseofInjury, objctrlRpt.IsPartofBodyInjured, objctrlRpt.IsLossNature, objctrlRpt.IsCauseofLoss };

            return dataAccess.LoadDataSet(parameters, "P_ContentReports_ClaimsCodeDetails", "ClaimsCodeDetails");
        }


        public DataSet GetClientList(clsControlReports objctrlRpt)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[25] { objctrlRpt.ClientCode, objctrlRpt.PreviousClientCode,  objctrlRpt.RecordType, objctrlRpt.VIPType ,objctrlRpt.CoRelatedClient , objctrlRpt.Type,
            objctrlRpt.BusinessType ,objctrlRpt.CorporateGroup,  objctrlRpt.ClientSource, objctrlRpt.IndustryType,objctrlRpt.EffFromDate , objctrlRpt.EffToDate,  objctrlRpt.KeyAccountManager, objctrlRpt.Intrducer1Code ,
            objctrlRpt.Intrducer2Code , objctrlRpt.GroupId, objctrlRpt.SubGroupId, objctrlRpt.BNCID, objctrlRpt.Lapsed, objctrlRpt.SendNote, objctrlRpt.SourceCodeId, objctrlRpt.CountryCode, objctrlRpt.IsCorprate, objctrlRpt.ISVIP, objctrlRpt.TeamId };

            return dataAccess.LoadDataSet(parameters, "P_ContentReports_ClientDetails", "ClientDetails");
        }
        //public DataSet GetClientListAcclaim(clsControlReports objctrlRpt)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[15] { objctrlRpt.ClientCode,
        //    objctrlRpt.PreviousClientCode,  objctrlRpt.RecordType, objctrlRpt.VIPType ,objctrlRpt.CoRelatedClient , objctrlRpt.Type,
        //    objctrlRpt.BusinessType ,objctrlRpt.CorporateGroup,  objctrlRpt.ClientSource, objctrlRpt.IndustryType,objctrlRpt.EffFromDate , objctrlRpt.EffToDate,  objctrlRpt.KeyAccountManager, objctrlRpt.Intrducer1Code ,
        //    objctrlRpt.Intrducer2Code };

        //    return dataAccess.LoadDataSet(parameters, "P_ContentReports_ClientDetails", "ClientDetails");
        //}


        public DataSet GetCoverNoteRegisterList(clsCNRegister objCNRegister)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] {  
                                    objCNRegister.CompanyId,
                                    objCNRegister.BranchId,
                                    objCNRegister.ClientCode ,
                                    objCNRegister.Group ,
                                    objCNRegister.SubGroup ,
                                    objCNRegister.BusnessNCode ,
                                    objCNRegister.SourceCode ,
                                    objCNRegister.DebitNoteIssue ,
                                    objCNRegister.POIDateFrom ,
                                    objCNRegister.POIDateTo,
                                    objCNRegister.ExpiryPeriodFrom ,
                                    objCNRegister.ExpiryPeriodTo ,
                                    objCNRegister.CoverNoteDateFrom ,
                                    objCNRegister.CoverNoteDateTo ,
                                    objCNRegister.Class ,
                                    objCNRegister.CoverNoteFrom,
                                    objCNRegister.CoverNoteTo ,
                                    objCNRegister.Status ,
                                    objCNRegister.BusinessType 
            };
            return dataAccess.LoadDataSet(parameters, "P_ContentReports_CoverNoteRegisterList", "UnderWriterDetails");
        }




        public DataSet GetPotentialClientList(clsControlReports objctrlRpt)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { 
                objctrlRpt.ClientCode, 
                objctrlRpt.GroupId, 
                objctrlRpt.SubGroupId, 
                objctrlRpt.BNCID, 
                objctrlRpt.SourceCodeId, 
                objctrlRpt.CountryCode, 
                objctrlRpt.IsCorprate, 
                objctrlRpt.ISVIP, 
                objctrlRpt.PolClientCode 
            };

            return dataAccess.LoadDataSet(parameters, "P_ControlReports_PolClientDetails", "PolClientDetails");
        }


        //
        public DataSet GetPotentialClientListUnapproved(clsControlReports objctrlRpt)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { 
                
                objctrlRpt.ClientCode,
                 objctrlRpt.PolClientCode,
                //objctrlRpt.GroupId, 
                //objctrlRpt.SubGroupId, 
                //objctrlRpt.BNCID, 
                //objctrlRpt.SourceCodeId, 
                objctrlRpt.CountryCode, 
                objctrlRpt.IsCorprate, 
                objctrlRpt.ISVIP
                 
            };

            return dataAccess.LoadDataSet(parameters, "P_ControlReports_PolClientDetails_UnApproved", "PolClientDetails");
        }


        public DataSet GetQuotationRegisterList(clsCNRegister objCNRegister)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] {  
                                    objCNRegister.CompanyId,
                                    objCNRegister.BranchId,
                                    objCNRegister.ClientCode ,
                                    objCNRegister.Group ,
                                    objCNRegister.SubGroup ,
                                    objCNRegister.BusnessNCode ,
                                    objCNRegister.SourceCode ,
                                    objCNRegister.DebitNoteIssue ,
                                    objCNRegister.POIDateFrom ,
                                    objCNRegister.POIDateTo,
                                    objCNRegister.ExpiryPeriodFrom ,
                                    objCNRegister.ExpiryPeriodTo ,
                                    objCNRegister.CoverNoteDateFrom ,
                                    objCNRegister.CoverNoteDateTo ,
                                    objCNRegister.Class ,
                                    objCNRegister.CoverNoteFrom,
                                    objCNRegister.CoverNoteTo ,
                                    objCNRegister.Status ,
                                    objCNRegister.BusinessType 
            };
            return dataAccess.LoadDataSet(parameters, "P_ContentReports_QuotationRegisterList", "UnderWriterDetails");
        }

        public DataSet GetPremiumAnalysisList(clsCNRegister objCNRegister)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[14] {  
                                    objCNRegister.CompanyId,
                                    objCNRegister.BranchId,
                                    objCNRegister.ClientCode,
                                    objCNRegister.UNCode,
                                    objCNRegister.Group,
                                    objCNRegister.SubGroup,
                                    objCNRegister.BusnessNCode,
                                    objCNRegister.SourceCode,
                                    objCNRegister.POIDateFrom,
                                    objCNRegister.POIDateTo,
                                    objCNRegister.ExpiryPeriodFrom,
                                    objCNRegister.ExpiryPeriodTo,
                                    objCNRegister.DNDateFrom,
                                    objCNRegister.DNDateTo
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RPT_PremiumAnalysis", "PremiumAnalysis");
        }

        public DataSet GetSuccessionReportList(clsCNRegister objCNRegister)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[14] {  
                                    objCNRegister.CompanyId,
                                    objCNRegister.BranchId,
                                    objCNRegister.PotentialClientCode,
                                    objCNRegister.ClientCode,
                                    objCNRegister.Status,
                                    objCNRegister.BusinessType,
                                    objCNRegister.POIDateFrom,
                                    objCNRegister.POIDateTo,
                                    objCNRegister.ExpiryPeriodFrom,
                                    objCNRegister.ExpiryPeriodTo,
                                    objCNRegister.QuotationDateFrom,
                                    objCNRegister.QuotationDateTo,
                                    objCNRegister.QuotationNo,
                                    objCNRegister.Class
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RPT_Succession", "Succession");
        }
    }
}
