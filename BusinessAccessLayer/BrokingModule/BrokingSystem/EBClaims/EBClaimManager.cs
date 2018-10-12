using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class EBClaimManager
    {

        DataAccess dataAccess = null;
        public EBClaimManager()
        {

        }
        public DataSet Get_Cost_PaymentType()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_Cost_PaymentType", "P_Cost_PaymentType");
        }

        public DataSet GetEBClaimMemberList(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objEBClaimDetails.MemberCode, objEBClaimDetails.MemberName, objEBClaimDetails.PassportNo, objEBClaimDetails.ClientCode, objEBClaimDetails.ClientName, objEBClaimDetails.UwriterCode, objEBClaimDetails.UwriterName, objEBClaimDetails.CoverNoteNo, objEBClaimDetails.PolicyNo, objEBClaimDetails.SubClass, objEBClaimDetails.MemberType };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimMemberList", "EB_ClaimMemberList");
        }
        public DataSet GetEBClaimMemberDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBClaimDetails.CaseRefNo, objEBClaimDetails.MemberCode, objEBClaimDetails.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimMemberLoadData", "EB_ClaimMemberLoadData");
        }
        public DataSet GetEBClaimRegistrationMemberDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimDetails.CaseRefNo, objEBClaimDetails.MemberCode, objEBClaimDetails.RefNo, objEBClaimDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimMemberDetails", "EB_ClaimMemberDetails");
        }
        public DataSet GetEBClaimPlanDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBClaimDetails.CoverNoteNo, objEBClaimDetails.PlanName };
            return dataAccess.LoadDataSet(parameters, "P_EBClaim_PlanDetail", "EB_ClaimMemberDetails");
        }
        public DataSet GetEBMemberDetailsAudit(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBClaimDetails.CaseRefNo, objEBClaimDetails.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetailsAudit", "EB_MemberDetails");
        }
        public DataSet GetEBClaimDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBClaimDetails.CaseRefNo, objEBClaimDetails.MemberCode, objEBClaimDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimDetails", "EB_ClaimDetails");
        }
        public DataSet InsertUpdateClaimCostAdjudicationDetails(clsEBClaimCostAdjudicationDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.CoAdId, objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo, 
                objEBClaimDetails.BenefitGroupLineId, objEBClaimDetails.BenefitGroupLineName,objEBClaimDetails.BenefitLineID,objEBClaimDetails.BenefitLineName, 
                objEBClaimDetails.PlanLimit,
                objEBClaimDetails.Deductible, objEBClaimDetails.IncurredAmount, objEBClaimDetails.PaidAmount,
                objEBClaimDetails.GST, objEBClaimDetails.Nonpayableitems, objEBClaimDetails.Balance, 
                objEBClaimDetails.Remarks, objEBClaimDetails.CreatedBy,objEBClaimDetails.Action };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimCostAdjudicationDetailsInsertUpdate", "ClaimCostAdjudicationDetails");
        }
        public DataSet InsertUpdateClaimPaymentDetails(clsEBClaimPaymentDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objEBClaimDetails.ClaimId,objEBClaimDetails.ClaimNo,objEBClaimDetails.PaymentRowId,
objEBClaimDetails.ProductTypeId ,objEBClaimDetails.ProductType,objEBClaimDetails.PaymentTo,objEBClaimDetails.PaymentMethod,
objEBClaimDetails.Cheque_GIRODetails,objEBClaimDetails.DateReceived,objEBClaimDetails.DateSent,objEBClaimDetails.CashAmount,
objEBClaimDetails.MedisaveAmount ,objEBClaimDetails.HospitalAmount,objEBClaimDetails.ShieldPlanAmount,
objEBClaimDetails.TotalReimbursementAmount ,objEBClaimDetails.CashAllowance,objEBClaimDetails.Remarks,objEBClaimDetails.Others,
objEBClaimDetails.CreatedBy,objEBClaimDetails.Action };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimPaymentDetailsInsertUpdate", "ClaimPaymentDetails");
        }

        public DataSet InsertUpdateEBClaimDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[59] {  objEBClaimDetails.CaseRefNo ,objEBClaimDetails.MemberCode,objEBClaimDetails.ClaimRefNo,objEBClaimDetails.MemberRegRefNo, objEBClaimDetails.ClaimNo,objEBClaimDetails.ClaimTypeCode,objEBClaimDetails.ClaimTypeDesc,objEBClaimDetails.IssueDate,objEBClaimDetails.CoverNoteNo	,objEBClaimDetails.SubClassID	,objEBClaimDetails.SubClass,    
                                                    objEBClaimDetails.PolicyNo,objEBClaimDetails.POIFromDate,objEBClaimDetails.POIToDate, objEBClaimDetails.NotifyByCode ,objEBClaimDetails.NotifyBy	,objEBClaimDetails.NotifyDate	, objEBClaimDetails.LocationCode,objEBClaimDetails.Location	 ,objEBClaimDetails.ClientCode	,objEBClaimDetails.ClientName,
                                                    objEBClaimDetails.ClientTeam , objEBClaimDetails.ClientFirstName, objEBClaimDetails.ClientLastName, objEBClaimDetails.ClientEmail,objEBClaimDetails.ClientDirectLine1,objEBClaimDetails.ClientDirectLine2 ,objEBClaimDetails.ClientMobile1, objEBClaimDetails.ClientMobile2	,objEBClaimDetails.ClientFax1,objEBClaimDetails.ClientFax2,
                                                    objEBClaimDetails.UwriterCode,objEBClaimDetails.UwriterName	,objEBClaimDetails.UwClaimNo , objEBClaimDetails.UwriterTeam ,objEBClaimDetails.UwriterFirstName,objEBClaimDetails.UwriterLastName ,objEBClaimDetails.UwriterEmail	,objEBClaimDetails.UwriterDirectLine1 , objEBClaimDetails.UwriterDirectLine2, objEBClaimDetails.UwriterMobile1 ,
                                                    objEBClaimDetails.UwriterMobile2 , objEBClaimDetails.UwriterFax1 ,objEBClaimDetails.UwriterFax2	,objEBClaimDetails.ClaimHandlerCode	,objEBClaimDetails.ClaimHandlerDescription,objEBClaimDetails.SurveyorCode , objEBClaimDetails.SurveyorDescription , objEBClaimDetails.AccountHandlerCode , objEBClaimDetails.AccountHandlerDescription, 
                                                    objEBClaimDetails.LossAdjusterCode, objEBClaimDetails.LossAdjusterDescription, objEBClaimDetails.HealthCareCode ,objEBClaimDetails.HealthCareDescription , objEBClaimDetails.SolicitorCode, objEBClaimDetails.SolicitorDescription, objEBClaimDetails.InvestigatorCode	,objEBClaimDetails.InvestigatoreDescription	,objEBClaimDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimInsertUpdate", "EB_ClaimInsertUpdate");
        }
        public DataSet InsertUpdateEBClaimDetails_Portal(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            //System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter();
            //parameter.ParameterName = "@DiagnosisDescriptions";
            //parameter.SqlDbType = System.Data.SqlDbType.Structured;
            //parameter.TypeName = "EB_DiagnosisDescriptionType";
            //parameter.Value = objEBClaimDetails.DiagnosisDescriptions;  


            Object[] parameters = new Object[] {  objEBClaimDetails.CaseRefNo ,objEBClaimDetails.MemberCode,objEBClaimDetails.ClaimRefNo,objEBClaimDetails.MemberRegRefNo, objEBClaimDetails.ClaimNo,objEBClaimDetails.ClaimTypeCode,objEBClaimDetails.ClaimTypeDesc,objEBClaimDetails.IssueDate,objEBClaimDetails.CoverNoteNo	,objEBClaimDetails.SubClassID	,objEBClaimDetails.SubClass,    
                                                    objEBClaimDetails.PolicyNo,objEBClaimDetails.POIFromDate,objEBClaimDetails.POIToDate, objEBClaimDetails.NotifyByCode ,objEBClaimDetails.NotifyBy	,objEBClaimDetails.NotifyDate	, objEBClaimDetails.LocationCode,objEBClaimDetails.Location	 ,objEBClaimDetails.ClientCode	,objEBClaimDetails.ClientName,
                                                    objEBClaimDetails.ClientTeam , objEBClaimDetails.ClientFirstName, objEBClaimDetails.ClientLastName, objEBClaimDetails.ClientEmail,objEBClaimDetails.ClientDirectLine1,objEBClaimDetails.ClientDirectLine2 ,objEBClaimDetails.ClientMobile1, objEBClaimDetails.ClientMobile2	,objEBClaimDetails.ClientFax1,objEBClaimDetails.ClientFax2,
                                                    objEBClaimDetails.UwriterCode,objEBClaimDetails.UwriterName	,objEBClaimDetails.UwClaimNo , objEBClaimDetails.UwriterTeam ,objEBClaimDetails.UwriterFirstName,objEBClaimDetails.UwriterLastName ,objEBClaimDetails.UwriterEmail	,objEBClaimDetails.UwriterDirectLine1 , objEBClaimDetails.UwriterDirectLine2, objEBClaimDetails.UwriterMobile1 ,
                                                    objEBClaimDetails.UwriterMobile2 , objEBClaimDetails.UwriterFax1 ,objEBClaimDetails.UwriterFax2	,objEBClaimDetails.ClaimHandlerCode	,objEBClaimDetails.ClaimHandlerDescription,objEBClaimDetails.SurveyorCode , objEBClaimDetails.SurveyorDescription , objEBClaimDetails.AccountHandlerCode , objEBClaimDetails.AccountHandlerDescription, 
                                                    objEBClaimDetails.LossAdjusterCode, objEBClaimDetails.LossAdjusterDescription, objEBClaimDetails.HealthCareCode ,objEBClaimDetails.HealthCareDescription , objEBClaimDetails.SolicitorCode, objEBClaimDetails.SolicitorDescription, objEBClaimDetails.InvestigatorCode	,objEBClaimDetails.InvestigatoreDescription	,objEBClaimDetails.UserID,
                                                    objEBClaimDetails.IncurredAdmDate,objEBClaimDetails.InsurerClaimNo,
        objEBClaimDetails.LOGIssued,objEBClaimDetails.LOGRefNo,objEBClaimDetails.DischargeDate,objEBClaimDetails.FirstDocReceived 
           ,objEBClaimDetails.ServiceProvider,objEBClaimDetails.FinalDocReceived,objEBClaimDetails.Others,objEBClaimDetails.SubmissiontoInsurer
          ,objEBClaimDetails.ServiceProviderType,objEBClaimDetails.AdmissionType,objEBClaimDetails.HospitalName,objEBClaimDetails.HospitalType,
         objEBClaimDetails.DiseaseType,objEBClaimDetails.MCDays,objEBClaimDetails.RejectedDate,objEBClaimDetails.RejectedReason,
         objEBClaimDetails.RejectedReturnDocDate,objEBClaimDetails.WithdrawDate,objEBClaimDetails.WithdrawReason,
         objEBClaimDetails.WithdrawReturnDocDate ,objEBClaimDetails.VoidDate,objEBClaimDetails.VoidReason,objEBClaimDetails.ClaimId,
            objEBClaimDetails.PreHospitalizationDays,objEBClaimDetails.PostHospitalizationDays,objEBClaimDetails.PerDisabilitydays,objEBClaimDetails.AmountIncurred};
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimInsertUpdate", "EB_ClaimInsertUpdate");
        }
        public DataSet GetMemberClaimDiagnosisDetails(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimDiagnosisDetailsSelect", "MemberClaimDiagnosisDetails");
        }
        public DataSet GetEBClaimCostAdjudicationCalDetailsSelect(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo, null };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimCostAdjudicationCalDetailsSelect", "ClaimCostAdjudicationCalDetailsSelect");
        }
        public DataSet GetEBClaimClaimPaymentDetailsSelect(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo, null };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimPaymentDetailsSelect", "ClaimPaymentDetailsSelect");
        }
        public DataSet GetClaimTaskDetailsSelect(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimTaskDetailsSelect", "ClaimTaskDetailsSelect");
        }
        public DataSet GetEBNoteDetailsSelect(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimNoteDetailsSelect", "ClaimNoteDetailsSelect");
        }
        public DataSet GetEBClaimDiagnosisDetailsSaveSelect(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimId, objEBClaimDetails.ClaimNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimDiagnosisDetailsSaveSelect", "ClaimDiagnosisDetailsSaveSelect");
        }
        public DataSet GetClaimPendingDocumentsSelect(clsEBClaimDetails objEBClaimDetails, string claimType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimNo, objEBClaimDetails.ClaimId, claimType };
            return dataAccess.LoadDataSet(parameters, "P_ClaimPendingDocumentsSelect", "ClaimPendingDocumentsSelect");
        }

        public DataSet GetClaimClaimBenefitScheduleDetail(int benefitScheduleId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { benefitScheduleId };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitScheduleDetailSelect", "ClaimBenefitScheduleDetail");
        }
        public DataSet GetClaimBenefitLineSelectbyBGroupID(int groupId, string deptType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { groupId, deptType };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitLine_SelectbyBGroupID", "ClaimBenefitLine_SelectbyBGroupID");
        }
        public DataSet GetEBClaimOutstandingList(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimDetails.ClaimNo, objEBClaimDetails.MemberCode, objEBClaimDetails.MemberName,
                objEBClaimDetails.PassportNo, objEBClaimDetails.ClientCode, objEBClaimDetails.ClientName, objEBClaimDetails.UwriterCode, 
                objEBClaimDetails.UwriterName, objEBClaimDetails.CoverNoteNo, objEBClaimDetails.PolicyNo, objEBClaimDetails.SubClass,
                objEBClaimDetails.ClaimTypeDesc,
                objEBClaimDetails.AdmissionDate, objEBClaimDetails.ConsultationToDate,
                objEBClaimDetails.UserID, objEBClaimDetails.ClaimStatus, objEBClaimDetails.IssueFromDate, objEBClaimDetails.IssueToDate,
                objEBClaimDetails.POIFromDate, objEBClaimDetails.POIToDate,
                objEBClaimDetails.CertificateNo,objEBClaimDetails.TagRef,objEBClaimDetails.DependantName,objEBClaimDetails.InsurerClaimNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimOutstandingList", "EB_ClaimOutstandingList");
        }
        public DataSet EBClaimTagDiagnosisDetailsInsertUpdate(EbTagDiagnosisDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBClaimRecordDetails.TagId ,
objEBClaimRecordDetails.ClaimId ,
objEBClaimRecordDetails.ClaimNo ,
objEBClaimRecordDetails.DiagId ,
objEBClaimRecordDetails.MemberCode ,
objEBClaimRecordDetails.TagRef ,
objEBClaimRecordDetails.Action ,
objEBClaimRecordDetails.TagStatus ,
objEBClaimRecordDetails.TagNew ,
objEBClaimRecordDetails.TagDate ,
objEBClaimRecordDetails.UnTagDate ,
objEBClaimRecordDetails.CreatedBy   };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimTagDiagnosisDetailsInsertUpdate", "EB_ClaimTagDiagnosisDetailsInsertUpdate");
        }
        public DataSet InsertUpdateEBClaimRecordDetails(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[15] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo, objEBClaimRecordDetails.MemberRegRefNo, objEBClaimRecordDetails.ClientDate, objEBClaimRecordDetails.InsurerDate, objEBClaimRecordDetails.ConsulationDate, objEBClaimRecordDetails.SubmissionDate, objEBClaimRecordDetails.ReSubmissionDate, objEBClaimRecordDetails.ProviderName, objEBClaimRecordDetails.DoctorName, objEBClaimRecordDetails.UserID, objEBClaimRecordDetails.ConsulationToDate,
             objEBClaimRecordDetails.ToClientDate, objEBClaimRecordDetails.ReSubmissionToInsurerDate};
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordDetailsInsertUpdate", "EB_ClaimRecordDetailsInsertUpdate");
        }
        public DataSet GetEBClaimRecordDetails(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordDetails", "EB_ClaimRecordDetails");
        }
        public DataSet InsertUpdateEBClaimRecordDiagnosis(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo, objEBClaimRecordDetails.DiagnosisRefNo, objEBClaimRecordDetails.DiagnosisCode, objEBClaimRecordDetails.DiagnosisDesc };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordDiagnosisInsertUpdate", "EB_ClaimRecordDiagnosisInsertUpdate");
        }
        public DataSet DeleteEBClaimRecordDiagnosis(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo, objEBClaimRecordDetails.DiagnosisRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordDiagnosisDelete", "EB_ClaimRecordDiagnosisDelete");
        }
        public DataSet InsertUpdateEBClaimRecordProcedure(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo, objEBClaimRecordDetails.ProcedureRefNo, objEBClaimRecordDetails.ProcedureCode, objEBClaimRecordDetails.ProcedureDesc };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordProcedureInsertUpdate", "EB_ClaimRecordProcedureInsertUpdate");
        }
        public DataSet DeleteEBClaimRecordProcedure(clsEBClaimRecordDetails objEBClaimRecordDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimRecordDetails.CaseRefNo, objEBClaimRecordDetails.MemberCode, objEBClaimRecordDetails.ClaimRefNo, objEBClaimRecordDetails.ProcedureRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimRecordProcedureDelete", "EB_ClaimRecordProcedureDelete");
        }
        public DataSet InsertUpdateEBClaimBenefitScheduleDetails(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[13] { objEBClaimBenefitScheduleDetails.CaseRefNo, objEBClaimBenefitScheduleDetails.MemberCode, objEBClaimBenefitScheduleDetails.ClaimRefNo, objEBClaimBenefitScheduleDetails.BenefitScheduleRefNo, objEBClaimBenefitScheduleDetails.BenefitScheduleCode, objEBClaimBenefitScheduleDetails.BenefitScheduleDescription, objEBClaimBenefitScheduleDetails.EntitleAmount, objEBClaimBenefitScheduleDetails.IncurredAmount, objEBClaimBenefitScheduleDetails.PaidAmount, objEBClaimBenefitScheduleDetails.ClaimBalanceAmount, objEBClaimBenefitScheduleDetails.BalanceAmount, objEBClaimBenefitScheduleDetails.ClaimAmount, objEBClaimBenefitScheduleDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitScheduleDetailsInsertUpdate", "EB_ClaimRecordProcedureInsertUpdate");
        }
        public DataSet DeleteEBClaimBenefitScheduleDetails(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimBenefitScheduleDetails.CaseRefNo, objEBClaimBenefitScheduleDetails.MemberCode, objEBClaimBenefitScheduleDetails.ClaimRefNo, objEBClaimBenefitScheduleDetails.BenefitScheduleRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitScheduleDetailsDelete", "EB_ClaimBenefitScheduleDetailsDelete");
        }
        public DataSet InsertUpdateEBClaimBenefitScheduleSummary(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[12] { objEBClaimBenefitScheduleDetails.CaseRefNo, objEBClaimBenefitScheduleDetails.MemberCode, objEBClaimBenefitScheduleDetails.ClaimRefNo, objEBClaimBenefitScheduleDetails.TotalEntitleAmount, objEBClaimBenefitScheduleDetails.TotalIncurredAmount, objEBClaimBenefitScheduleDetails.TotalPaidAmount, objEBClaimBenefitScheduleDetails.TotalClaimBalanceAmount, objEBClaimBenefitScheduleDetails.TotalBalanceAmount, objEBClaimBenefitScheduleDetails.TotalClaimAmount, objEBClaimBenefitScheduleDetails.ShortfallAmount, objEBClaimBenefitScheduleDetails.UserID, objEBClaimBenefitScheduleDetails.PaidDate };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitScheduleSummaryInsertUpdate", "EB_ClaimRecordProcedureInsertUpdate");
        }
        public DataSet InsertUpdateEBClaimLimitSummary(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[10] { objEBClaimBenefitScheduleDetails.CaseRefNo, objEBClaimBenefitScheduleDetails.MemberCode, objEBClaimBenefitScheduleDetails.ClaimRefNo, objEBClaimBenefitScheduleDetails.TotalEntitleAmount, objEBClaimBenefitScheduleDetails.TotalIncurredAmount, objEBClaimBenefitScheduleDetails.TotalPaidAmount, objEBClaimBenefitScheduleDetails.TotalClaimBalanceAmount, objEBClaimBenefitScheduleDetails.TotalBalanceAmount, objEBClaimBenefitScheduleDetails.TotalClaimAmount, objEBClaimBenefitScheduleDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimLimitSummaryInsertUpdate", "EB_ClaimRecordProcedureInsertUpdate");
        }
        public DataSet GetBenefitScheduleLine(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objEBClaimBenefitScheduleDetails.BenefitScheduleCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimLoadData", "EB_ClaimLoadData");
        }
        public DataSet GetEBClaimBenefitScheduleDetails(clsEBClaimBenefitScheduleDetails objEBClaimBenefitScheduleDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBClaimBenefitScheduleDetails.CaseRefNo, objEBClaimBenefitScheduleDetails.MemberCode, objEBClaimBenefitScheduleDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBenefitScheduleDetails", "EB_ClaimBenefitScheduleDetails");
        }
        public DataSet InsertUpdateEBClaimFileUpload(clsEBClaimFileUpload objEBClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objEBClaimFileUpload.CaseRefNo, objEBClaimFileUpload.MemberCode, objEBClaimFileUpload.ClaimRefNo, objEBClaimFileUpload.FileName, objEBClaimFileUpload.FileType, objEBClaimFileUpload.Remarks, objEBClaimFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimFileUploadInsertUpdate", "EB_ClaimBenefitScheduleDetails");
        }
        public DataSet GetEBClaimFileUploadDetails(clsEBClaimFileUpload objEBClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBClaimFileUpload.CaseRefNo, objEBClaimFileUpload.MemberCode, objEBClaimFileUpload.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimFileUploadDetails", "EB_ClaimFileUploadDetails");
        }
        public DataSet DeleteEBClaimFileUploadDetails(clsEBClaimFileUpload objEBClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimFileUpload.CaseRefNo, objEBClaimFileUpload.MemberCode, objEBClaimFileUpload.ClaimRefNo, objEBClaimFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimFileUploadDelete", "EB_ClaimFileUploadDelete");
        }
        public DataSet InsertUpdateEBClaimComplete(clsEBClaimComplete objEBCliamComplete)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[17] { objEBCliamComplete.CaseRefNo, objEBCliamComplete.MemberCode, objEBCliamComplete.ClaimRefNo, 
                objEBCliamComplete.ClaimStatusCode, objEBCliamComplete.ClaimStatusDescription, objEBCliamComplete.IsReceiptReturned,
                objEBCliamComplete.PendingDate, objEBCliamComplete.PendingReason, objEBCliamComplete.RejectDate,
                objEBCliamComplete.RejectReason, objEBCliamComplete.ApprovedDate, objEBCliamComplete.Remarks, 
                objEBCliamComplete.UserID, objEBCliamComplete.OrgRecToCLDate, objEBCliamComplete.ClaimDetailId,
                objEBCliamComplete.ReceivedClientDate,objEBCliamComplete.ReceivedInsurerDate};
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimDetailsInsertUpdate", "EB_ClaimDetailsInsertUpdate");
        }
        public DataSet GetEBClaimCompleteDetails(clsEBClaimComplete objEBCliamComplete)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBCliamComplete.CaseRefNo, objEBCliamComplete.MemberCode, objEBCliamComplete.ClaimRefNo, objEBCliamComplete.ClaimDetailId };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimCompleteDetails", "EB_ClaimCompleteDetails");
        }
        public DataSet InsertUpdateEBClaimLimit(clsEBClaimLimit objEBCliamLimit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objEBCliamLimit.CaseRefNo, objEBCliamLimit.MemberCode, objEBCliamLimit.ClaimRefNo, objEBCliamLimit.BenefitScheduleRefNo, objEBCliamLimit.EntitleAmount, objEBCliamLimit.IncurredAmount, objEBCliamLimit.PaidAmount, objEBCliamLimit.ClaimBalanceAmount, objEBCliamLimit.BalanceAmount, objEBCliamLimit.ClaimAmount, objEBCliamLimit.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimLimitInserUpdate", "EB_ClaimLimitInserUpdate");
        }
        public DataSet GetEBClaimLimitDetails(clsEBClaimLimit objEBCliamLimit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBCliamLimit.CaseRefNo, objEBCliamLimit.MemberCode, objEBCliamLimit.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimLimitDetails", "EB_ClaimLimitDetails");
        }
        public DataSet InsertBatchUploadEBClaim(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.FileName, objEBClaimBatchFileUpload.FileType, objEBClaimBatchFileUpload.UploadBy, objEBClaimBatchFileUpload.EB_NonEB };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBatchUploadInsertUpdate", "EB_ClaimBatchUploadInsertUpdate");
        }
        public DataSet UpdateBatchUploadEBClaim(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.FilePath };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBatchUploadUpdate", "EB_ClaimBatchUploadUpdate");
        }
        public DataSet InsertBatchUploadIHCorporate(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.FileName, objEBClaimBatchFileUpload.FileType, objEBClaimBatchFileUpload.UploadBy, objEBClaimBatchFileUpload.EB_NonEB };
            return dataAccess.LoadDataSet(parameters, "P_IH_ConfirmationSlipBatchUploadInsertUpdate", "IH_ClaimBatchUploadInsertUpdate");
        }
        public DataSet UpdateBatchUploadIHCorporatePolicy(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.FilePath };
            return dataAccess.LoadDataSet(parameters, "P_IH_ConfirmationSlipBatchUploadUpdate", "IH_ConfirmationSlipBatchUploadUpdate");
        }
        public DataSet GetEBClaimBatchFileUploadList(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBClaimBatchFileUpload.FileName, objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.UploadFromDate, objEBClaimBatchFileUpload.UploadToDate, objEBClaimBatchFileUpload.EB_NonEB };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimBatchUploadList", "EB_ClaimBatchUploadList");
        }
        public DataSet GetIHClaimBatchFileUploadList(clsEBClaimBatchFileUpload objEBClaimBatchFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimBatchFileUpload.FileName, objEBClaimBatchFileUpload.RefNo, objEBClaimBatchFileUpload.UploadFromDate, objEBClaimBatchFileUpload.UploadToDate };
            return dataAccess.LoadDataSet(parameters, "P_IH_ClaimBatchUploadList", "IH_ClaimBatchUploadList");
        }

        public DataSet GetEBClaimEntitleAmount(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBClaimDetails.CaseRefNo, objEBClaimDetails.MemberCode, objEBClaimDetails.RefNo, objEBClaimDetails.Benefitlimit };
            return dataAccess.LoadDataSet(parameters, "[P_EBClaimEntitleAmount]", "EBClaimEntitleAmount");
        }



        //for cost adjustification
        public DataSet InsertUpdateEBClaimCostAdjustification(clsCostAdjustification objclsCostadjustification)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[34] { objclsCostadjustification.CaseRefNo, objclsCostadjustification.MemberCode,
                objclsCostadjustification.ClaimRefNo, objclsCostadjustification.RefNo, objclsCostadjustification.BenefitSchedule,
                objclsCostadjustification.BenefitType, objclsCostadjustification.ClaimDate, objclsCostadjustification.ClaimAmount,
                objclsCostadjustification.PaidDate, objclsCostadjustification.PaidAmount, objclsCostadjustification.ExcessAmount,
                objclsCostadjustification.BalanceAmount, objclsCostadjustification.Claim_Date , objclsCostadjustification.Claim_Amount , 
                objclsCostadjustification.PaymentType , objclsCostadjustification.PayeeName , objclsCostadjustification.ChequeNo , 
                objclsCostadjustification.ChequeDate , objclsCostadjustification.BankCode , objclsCostadjustification.BankBranch ,
            objclsCostadjustification.Bankname , objclsCostadjustification.SwiftCode , objclsCostadjustification.AccNo ,
            objclsCostadjustification.Currency , objclsCostadjustification.Deductible , objclsCostadjustification.CoPayment ,
            objclsCostadjustification.BeneficiaryName1,objclsCostadjustification.BeneficiaryName2,objclsCostadjustification.BeneficiaryName3
            ,objclsCostadjustification.Remark,objclsCostadjustification.LoginUserId,
            objclsCostadjustification.PageMethod,objclsCostadjustification.ClaimCurrency,objclsCostadjustification.PaidCurrency  };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimCostAdjustification_InsertUpdate", "EB_ClaimCostAdjustificationInsertUpdate");
        }
        public DataSet ValidIhPolicy(clsEBClaimDetails objEBClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objEBClaimDetails.CorporatePolicyNo };
            return dataAccess.LoadDataSet(parameters, "Pol_ValidIHCorporatePolicy", "ValidIHPolicy");
        }

        public DataSet GetEBClaimCostAdjustification(clsCostAdjustification objclsCostadjustification)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objclsCostadjustification.CaseRefNo, objclsCostadjustification.MemberCode, objclsCostadjustification.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Get_EB_ClaimCostAdjustification", "EBClaimCostAdjustification");
        }
        public DataSet GetDashBordQuery(string CaseRefNo, string ClaimRefNo, string Claimno, string CoverNoteNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { CaseRefNo, ClaimRefNo, Claimno, CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_pol_getDashBord_Query", "EB_ClaimRegistration");
        }

        public DataSet GetClaimListDetails(clsEBClaimComplete objEBCliamComp)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBCliamComp.CaseRefNo, objEBCliamComp.MemberCode, objEBCliamComp.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_ClaimListDetail", "ClaimListDetails");
        }
    }
}
