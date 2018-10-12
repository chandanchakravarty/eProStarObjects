using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using BusinessObjectLayer.BrokingModule.Reports;

namespace BusinessAccessLayer.BrokingModule.Reports
{
    public class clsPolicySlipManager
    {
        DataAccess dataAccess = null;
        public DataSet GetPolicySlipList(clsQuotation objQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.DateFormat };
            return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyPrintSlipData_Select", "SlipList");
            
        }

        public DataSet GetPolicySlipListForLCH(clsQuotation objQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.DateFormat };
            return dataAccess.LoadDataSet(parameters, "P_Pol_QuotationSlipPrint", "SlipList");
            
        }

        public DataSet GetPolicySlipListForLCHCoverNote(clsQuotation objQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.DateFormat };
            return dataAccess.LoadDataSet(parameters, "P_Pol_QuotationSlipPrintCoverNoteDetails", "SlipList");

        }

        public DataSet GetBenefitSchedule(clsQuotation objQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.UnderwriterId };
            return dataAccess.LoadDataSet(parameters, "GetBenefitLine", "BenefitLine");

        }

        public DataSet GetRiskType(clsQuotation objQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccess.LoadDataSet(parameters, "GetRiskType", "GetRiskType");

        }
    }

    public class EvenOutReport
    {
        DataAccess dataAccess = null;
        public DataSet GetEvenOutResult(clsEvenOutReport objclsEvenOutReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsEvenOutReport.CompanyId,
                                                 objclsEvenOutReport.BranchId,
                                                 objclsEvenOutReport.SpreadFromDate, 
                                                 objclsEvenOutReport.SpreadToDate,
                                                 objclsEvenOutReport.DebitNoteNo,
                                                 objclsEvenOutReport.DebitNoteNoTo,  
                                                 objclsEvenOutReport.DebitNoteDate,
                                                 objclsEvenOutReport.DebitNoteDateTo, 
                                                 objclsEvenOutReport.BillingCurrency,
                                                 objclsEvenOutReport.ClientCode,
                                                 objclsEvenOutReport.ClientName, 
                                                 objclsEvenOutReport.Group,
                                                 objclsEvenOutReport.SubGroup, 
                                                 objclsEvenOutReport.BNC,
                                                 objclsEvenOutReport.SourceCode
              };
            return dataAccess.LoadDataSet(parameters, "P_DebitNoteEvenOut_Select", "EvenOut");
        }

        public DataSet GetEvenOutResultHKD(clsEvenOutReport objclsEvenOutReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsEvenOutReport.CompanyId,
                                                 objclsEvenOutReport.BranchId,
                                                 objclsEvenOutReport.SpreadFromDate,
                                                 objclsEvenOutReport.SpreadToDate,
                                                 objclsEvenOutReport.DebitNoteNo,
                                                 objclsEvenOutReport.DebitNoteNoTo,  
                                                 objclsEvenOutReport.DebitNoteDate,
                                                 objclsEvenOutReport.DebitNoteDateTo, 
                                                 objclsEvenOutReport.BillingCurrency,
                                                 objclsEvenOutReport.ClientCode,
                                                 objclsEvenOutReport.ClientName,
                                                 objclsEvenOutReport.Group,
                                                 objclsEvenOutReport.SubGroup, 
                                                 objclsEvenOutReport.BNC,
                                                 objclsEvenOutReport.SourceCode};
            return dataAccess.LoadDataSet(parameters, "P_DebitNoteEvenOutHKD_Select", "EvenOut");
        }
    }

    public class ALLECNESummaryReport
    {
        DataAccess dataAccess = null;
        public DataSet GetALLECNESummaryResult(clsALLECNESummaryReport objclsALLECNESummaryReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
               
            objclsALLECNESummaryReport.ClaimType ,
            objclsALLECNESummaryReport.IssueYearFrom ,
            objclsALLECNESummaryReport.IssueYearTo,     
            objclsALLECNESummaryReport.Filestatus 
        };
            string[] tables = { "TblIssueYear", "TblClaimSummary" };
            return dataAccess.LoadDataSets(parameters, "P_ALLECNESummaryReport_Select", tables);
        }
    }

    public class ALLECNEReport
    {
        DataAccess dataAccess = null;
        public DataSet GetALLECNEResult(clsALLECNEReport objclsALLECNEReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
            objclsALLECNEReport.CompanyId ,
            objclsALLECNEReport.BranchId,
            objclsALLECNEReport.Clientname ,
            objclsALLECNEReport.CovernoteNo ,
            objclsALLECNEReport.ClaimType ,
            objclsALLECNEReport.DateofAccidentFrom ,
            objclsALLECNEReport.DateofAccidentTo,
            objclsALLECNEReport.UnderwriterName ,
            objclsALLECNEReport.Filestatus ,
            objclsALLECNEReport.Status,
            objclsALLECNEReport.Group ,
            objclsALLECNEReport.SubGroup,
            objclsALLECNEReport.BusnessNCode,
            objclsALLECNEReport.SourceCode,
            objclsALLECNEReport.Class,
            objclsALLECNEReport.POIDateFrom,
            objclsALLECNEReport.POIDateTo ,
            objclsALLECNEReport.ClaimIssueDateFrom,
            objclsALLECNEReport.ClaimIssueDateTo,
            objclsALLECNEReport.ExpiryPeriodFrom,
            objclsALLECNEReport.ExpiryPeriodTo,
            objclsALLECNEReport.PolicyNo,
            objclsALLECNEReport.InjuryDeath,
            objclsALLECNEReport.CauseofInjury, 
            objclsALLECNEReport.Injurypart ,
            objclsALLECNEReport.LossNature,
            objclsALLECNEReport.CauseOfLoss,
            objclsALLECNEReport.MVRegNo,
            objclsALLECNEReport.Thirdparty
            };
            return dataAccess.LoadDataSet(parameters, "P_ALLECNEReport_Select", "ALLECNEReport");
        }
    }

    public class NEReport
    {
        DataAccess dataAccess = null;
        public DataSet GetNEResult(clsNEReport objclsNEReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                                    objclsNEReport.CompanyId,
                                                    objclsNEReport.BranchId,
                                                    //objclsNEReport.ClientCode,
                                                    objclsNEReport.ClientName,
                                                    objclsNEReport.Group,
                                                    objclsNEReport.SubGroup,
                                                    objclsNEReport.BusnessNCode,
                                                    objclsNEReport.SourceCode,
                                                    objclsNEReport.Status,
                                                    objclsNEReport.DocumentStatus,
                                                    objclsNEReport.Class,
                                                    objclsNEReport.POIDateFrom,
                                                    objclsNEReport.POIDateTo,
                                                    objclsNEReport.ClaimIssueDateFrom,
                                                    objclsNEReport.ClaimIssueDateTo,
                                                    objclsNEReport.ExpiryPeriodFrom,
                                                    objclsNEReport.ExpiryPeriodTo,
                                                    objclsNEReport.ClaimLossDateFrom,
                                                    objclsNEReport.ClaimLossDateTo,
                                                    objclsNEReport.CovernoteNo,
                                                    objclsNEReport.PolicyNo,
                                                    objclsNEReport.LossNature,
                                                    objclsNEReport.MVRegNo,
                                                    objclsNEReport.Thirdparty,
                                                    objclsNEReport.CauseOfLoss
                                                };
            return dataAccess.LoadDataSet(parameters, "P_NEReport_Select", "NEReport");
        }
    }

}
