using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Claims;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Claims
{
    public class ECClaimManager
    {
        DataAccess dataAccess = null;
        public ECClaimManager()
        {

        }
        public DataSet GetECClaimsLoadData(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaim.CaseRefNo, objECClaim.PolVersionId };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimsLoadData", "EC_ClaimsLoadData");
        }
        public DataSet InsertUpdateECClaims(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                objECClaim.PageMode ,objECClaim.CaseRefNo,objECClaim.ClaimRefNo,  objECClaim.IssueDate ,objECClaim.IsVoid  ,objECClaim.ClientCode , objECClaim.ClientName , objECClaim.UWClaimNo , 
                objECClaim.MainClassCode ,objECClaim.MainClassName ,objECClaim.PolicyNo ,objECClaim.CoverNoteNo, objECClaim.POIFromDate,objECClaim.POIToDate ,objECClaim.Location ,objECClaim.NotifyBy , objECClaim.NotifyDate,objECClaim.Team ,  
                objECClaim.FirstName , objECClaim.LastName ,objECClaim.DirectLine1,objECClaim.DirectLine2 ,objECClaim.MobileNo1 ,objECClaim.MobileNo2, objECClaim.FaxNo1,objECClaim.FaxNo2,
                objECClaim.Email,objECClaim.ClaimsHandlerCode ,objECClaim.ClaimsHandlerName,objECClaim.SurveyorCode , objECClaim.SurveyorName,  objECClaim.AccountHandlerCode ,objECClaim.AccountHandlerName  ,
                objECClaim.LossAdjusterCode ,objECClaim.LossAdjusterName ,objECClaim.HealthCareCode ,objECClaim.HealthCareName , objECClaim.SolicitorCode , objECClaim.SolicitorName ,objECClaim.InvestigatorCode ,
                objECClaim.InvestigatorName ,objECClaim.UserID,objECClaim.PolicyId, objECClaim.PolVersionId,objECClaim.FileStatus,objECClaim.SurveyorName2,objECClaim.SolicitorName2,objECClaim.LossAdjusterName2,objECClaim.ReceiptInvoiceNo,
            objECClaim.CedantCode,objECClaim.CedantName,objECClaim.CedantClaimNo,objECClaim.CedantPolicyNo,objECClaim.VesselName , objECClaim.NotifyByName  
            };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimInsertUpdate", "InsertEC_ClaimsData");
        }
        public DataSet WICAInsertUpdateECClaims(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                objECClaim.PageMode ,objECClaim.CaseRefNo,objECClaim.ClaimRefNo,  objECClaim.IssueDate ,objECClaim.IsVoid  ,objECClaim.ClientCode , objECClaim.ClientName , objECClaim.UWClaimNo , 
                objECClaim.MainClassCode ,objECClaim.MainClassName ,objECClaim.PolicyNo ,objECClaim.CoverNoteNo, objECClaim.POIFromDate,objECClaim.POIToDate ,objECClaim.Location ,objECClaim.NotifyBy , objECClaim.NotifyDate,objECClaim.Team ,  
                objECClaim.FirstName , objECClaim.LastName ,objECClaim.DirectLine1,objECClaim.DirectLine2 ,objECClaim.MobileNo1 ,objECClaim.MobileNo2, objECClaim.FaxNo1,objECClaim.FaxNo2,
                objECClaim.Email,objECClaim.ClaimsHandlerCode ,objECClaim.ClaimsHandlerName,objECClaim.SurveyorCode , objECClaim.SurveyorName,  objECClaim.AccountHandlerCode ,objECClaim.AccountHandlerName  ,
                objECClaim.LossAdjusterCode ,objECClaim.LossAdjusterName ,objECClaim.HealthCareCode ,objECClaim.HealthCareName , objECClaim.SolicitorCode , objECClaim.SolicitorName ,objECClaim.InvestigatorCode ,
                objECClaim.InvestigatorName ,objECClaim.UserID,objECClaim.PolicyId, objECClaim.PolVersionId,objECClaim.FileStatus,objECClaim.SurveyorName2,objECClaim.SolicitorName2,objECClaim.LossAdjusterName2,objECClaim.ReceiptInvoiceNo,
            objECClaim.CedantCode,objECClaim.CedantName,objECClaim.CedantClaimNo,objECClaim.CedantPolicyNo,objECClaim.VesselName,objECClaim.ClientClaimNo,objECClaim.NotificationNo,objECClaim.SubmissionDate,objECClaim.Department,objECClaim.SubsidiaryClientCode,objECClaim.SubClassCode,objECClaim.SubClassName 
            };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimInsertUpdate", "InsertEC_ClaimsData");
        }
        public DataSet InsertUpdateRecoveryClaim(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objECClaim.PolicyId ,objECClaim.PolVersionId,objECClaim.VesselId , objECClaim.VesselName,objECClaim.ClientName,objECClaim.DateofIncident,objECClaim.RecoveryAmount,objECClaim.RelatedClaimNo,objECClaim.Remark,objECClaim.UserID ,objECClaim.RecoveryNo  
               };
            return dataAccess.LoadDataSet(parameters, "P_Policy_RecoveryClaimInsertUpdate", "InsertRecovery_ClaimsData");
        }

        public DataSet InsertUpdateClaimBilling(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objECClaim.CaseRefNo ,objECClaim.ClaimRefNo,objECClaim.ClaimNo ,
          
                objECClaim.ClientCode,objECClaim.ClientName,objECClaim.UnderwriterCode,objECClaim.UnderwriterName,   objECClaim.ChequeRefNo,objECClaim.Currency,objECClaim.Amount,objECClaim.IssueDate,objECClaim.VesselName,   objECClaim.Casualty,
                
                objECClaim.Remark,objECClaim.UserID,objECClaim.PolicyId,objECClaim.PolVersionId  
               };
            return dataAccess.LoadDataSet(parameters, "P_Policy_ClaimBillingInsertUpdate", "Insert_ClaimBillingData");
        }
        public DataSet InsertUpdateECClaimsUnderwriter(clsECClaimUnderwriter objECClaimUnderwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[16] { objECClaimUnderwriter.CaseRefNo,objECClaimUnderwriter.ClaimRefNo , objECClaimUnderwriter.ClaimNo,objECClaimUnderwriter.RefNo,objECClaimUnderwriter.UnderWriterCode,objECClaimUnderwriter.UnderWriterName ,
                objECClaimUnderwriter.UWShare ,objECClaimUnderwriter.UWLastName ,objECClaimUnderwriter.UWFirstName, objECClaimUnderwriter.UWTelCC ,objECClaimUnderwriter.UWTel ,objECClaimUnderwriter.UWFaxCC,objECClaimUnderwriter.UWFax ,		objECClaimUnderwriter.UWEmail,
                objECClaimUnderwriter.UserID, objECClaimUnderwriter.UWType};
            return dataAccess.LoadDataSet(parameters, "P_ECClaimUnderwriterInserUpdate", "InsertEC_ClaimsUnderwriterData");
        }
        public DataSet GetECClaimData(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaim.CaseRefNo, objECClaim.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_CalimsRegistrationDetails", "EC_CalimsRegistrationDetails");
        }

        //added on 21st December for Standard Letter Billing//
        public DataSet GetCliamStandardLetterRecords(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[21] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.ClaimNo, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.AccidentDate, 
                objECClaim.ReportDate, objECClaim.NotifyDate,objECClaim.PolicyNo, objECClaim.CoverNoteNo,objECClaim.POIFromDate, objECClaim.POIToDate,objECClaim.ChequeRefNo,  objECClaim.ClaimStatus, objECClaim.UnderwriterCode, objECClaim.UnderwriterName,  objECClaim.KeyAccountmanager, objECClaim.Industrytype, objECClaim.CalledFor };// disability grade added by kavita//
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimStandardLetter", "EC_ClaimStandardLetter");
        }
        //end


        //added on 3rd January for Standard Letter Billing//
        public DataSet GetStandardLetter_CliamDetails(string caserefno, string claimrefno, string clientcode )
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { caserefno, claimrefno, clientcode };// disability grade added by kavita//
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimStandardLetter_Details", "P_ClaimStandardLetter_Details");
        }
        public DataSet GetStandardLetter_CliamDetailsCDGI(string caserefno, string claimrefno, string clientcode, string CalledFor)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { caserefno, claimrefno, clientcode, CalledFor };// disability grade added by kavita//
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimStandardLetter_Details", "P_ClaimStandardLetter_Details");
        }
        //end

        //Standard Letter
        public DataSet GetStandardLetterCategory(string TypeOfLetter)
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_StandardLetterListCatgory", "StandardLetterListCatgory");
        }

        public DataSet GetStandardLetterType(string TypeOfLetter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { TypeOfLetter };
            return dataAccess.LoadDataSet(parameters, "P_StandardLetterListType", "StandardLetterListType");
        }
        //end

        public DataSet GetRecoveryClaimData(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objECClaim.VesselId, objECClaim.RecoveryNo, objECClaim.VesselName, objECClaim.ClientName, objECClaim.RelatedClaimNo };
            return dataAccess.LoadDataSet(parameters, "P_GetRecoveryClaimData", "GetRecoveryClaimData");
        }
        public DataSet DeleteRecoveryClaimDetails(string VesselId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { VesselId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_RecoveryClaim_Delete", "PolicyRecoveryDetails");
        }
        public DataSet InsertUpdateECClaimsDetails(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objECClaimDetails.CaseRefNo , objECClaimDetails.ClaimRefNo , objECClaimDetails.ClaimNo, objECClaimDetails.CoverNoteNo	, objECClaimDetails.UnderwriterCode	,objECClaimDetails.UnderwriterName,	objECClaimDetails.UWShare,	    
                objECClaimDetails.ReportDate,objECClaimDetails.InjuredName, objECClaimDetails.LossDetails, objECClaimDetails.DateOfBirth, objECClaimDetails.AccidentDate, objECClaimDetails.Age	,objECClaimDetails.MonthlyEarning, objECClaimDetails.OccupationCode, objECClaimDetails.OccupationDesc	,
                objECClaimDetails.Currency,objECClaimDetails.TotalPaid,objECClaimDetails.AdjusterFee, objECClaimDetails.RecoveryAmount	,objECClaimDetails.Current_OSReserveAmount,objECClaimDetails.Total_Incurred	,objECClaimDetails.Injury_Death_Code,objECClaimDetails.Injury_Death_Desc,	
                objECClaimDetails.Nature_Injury_Code , objECClaimDetails.Nature_Injury_Desc	,objECClaimDetails.Cause_Injury_Code, objECClaimDetails.Cause_Injury_Desc, objECClaimDetails.Body_Injury_Code , objECClaimDetails.Body_Injury_Desc, objECClaimDetails.Permanent_Disability,objECClaimDetails.Claim_Status	,
                objECClaimDetails.Claim_StatusDate	,objECClaimDetails.PaymentStatus ,objECClaimDetails.Alet_AccountHandler	,objECClaimDetails.ECC_Count_Case , objECClaimDetails.CommonLawClaim ,
                objECClaimDetails.PaymentName,objECClaimDetails.PaymentModeCode	,objECClaimDetails.PaymentModeDesc ,objECClaimDetails.PaymentRef ,	objECClaimDetails.ReferenceNo ,objECClaimDetails.UserID,objECClaimDetails.Disability_Grade,objECClaimDetails.BoxNo,objECClaimDetails.DetailedStatus,objECClaimDetails.LossTypeID,objECClaimDetails.LossNatureID 
                , objECClaimDetails.TimeBar,objECClaimDetails.Mortgagee,objECClaimDetails.SumInsured,objECClaimDetails.Deductible,objECClaimDetails.DeductibleCollected,objECClaimDetails.DeductibleType,objECClaimDetails.DeductibleAmount
                , objECClaimDetails.AccidentLocationValue,objECClaimDetails.AccidentLocationText
                ,objECClaimDetails.LocationRemarks
                ,objECClaimDetails.VehicleNo
                ,objECClaimDetails.VehicleName
                ,objECClaimDetails.ReserveAmount
                ,objECClaimDetails.DateOfDischarge
                ,objECClaimDetails.DateUpdated
                ,objECClaimDetails.OutstandingAmount
                ,objECClaimDetails.TypeofHospital
                ,objECClaimDetails.Expenses
                ,objECClaimDetails.GMMActivation
                ,objECClaimDetails.ReferralLetter
                ,objECClaimDetails.SubClassId,
                 objECClaimDetails.AddmissionDate,
                objECClaimDetails.HospitalClinicName
          
            };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimDetails_InsertUpdate", "EC_ClaimDetails_InsertUpdate");
        }
        public DataSet InsertUpdateECClaimsDetailsWICA(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objECClaimDetails.CaseRefNo , objECClaimDetails.ClaimRefNo , objECClaimDetails.ClaimNo, objECClaimDetails.CoverNoteNo	, objECClaimDetails.UnderwriterCode	,objECClaimDetails.UnderwriterName,	objECClaimDetails.UWShare,	    
                objECClaimDetails.ReportDate,objECClaimDetails.InjuredName, objECClaimDetails.LossDetails, objECClaimDetails.DateOfBirth, objECClaimDetails.AccidentDate, objECClaimDetails.Age	,objECClaimDetails.MonthlyEarning, objECClaimDetails.OccupationCode, objECClaimDetails.OccupationDesc	,
                objECClaimDetails.Currency,objECClaimDetails.TotalPaid,objECClaimDetails.AdjusterFee, objECClaimDetails.RecoveryAmount	,objECClaimDetails.Current_OSReserveAmount,objECClaimDetails.Total_Incurred	,objECClaimDetails.Injury_Death_Code,objECClaimDetails.Injury_Death_Desc,	
                objECClaimDetails.Nature_Injury_Code , objECClaimDetails.Nature_Injury_Desc	,objECClaimDetails.Cause_Injury_Code, objECClaimDetails.Cause_Injury_Desc, objECClaimDetails.Body_Injury_Code , objECClaimDetails.Body_Injury_Desc, objECClaimDetails.Permanent_Disability,objECClaimDetails.Claim_Status	,
                objECClaimDetails.Claim_StatusDate	,objECClaimDetails.PaymentStatus ,objECClaimDetails.Alet_AccountHandler	,objECClaimDetails.ECC_Count_Case , objECClaimDetails.CommonLawClaim ,
                objECClaimDetails.PaymentName,objECClaimDetails.PaymentModeCode	,objECClaimDetails.PaymentModeDesc ,objECClaimDetails.PaymentRef ,	objECClaimDetails.ReferenceNo ,objECClaimDetails.UserID,objECClaimDetails.Disability_Grade,objECClaimDetails.BoxNo,objECClaimDetails.DetailedStatus,objECClaimDetails.LossTypeID,objECClaimDetails.LossNatureID 
                , objECClaimDetails.TimeBar,objECClaimDetails.Mortgagee,objECClaimDetails.SumInsured,objECClaimDetails.Deductible,objECClaimDetails.DeductibleCollected,objECClaimDetails.DeductibleType,objECClaimDetails.DeductibleAmount
                , objECClaimDetails.AccidentLocationValue,objECClaimDetails.AccidentLocationText
                ,objECClaimDetails.LocationRemarks
                ,objECClaimDetails.VehicleNo
                ,objECClaimDetails.VehicleName
                ,objECClaimDetails.ReserveAmount
                ,objECClaimDetails.DateOfDischarge
                ,objECClaimDetails.DateUpdated
                ,objECClaimDetails.OutstandingAmount
                ,objECClaimDetails.TypeofHospital
                ,objECClaimDetails.Expenses
                ,objECClaimDetails.GMMActivation
                ,objECClaimDetails.ReferralLetter
                ,objECClaimDetails.SubClassId,
                 objECClaimDetails.AddmissionDate,
                objECClaimDetails.HospitalClinicName,

                objECClaimDetails.ClaimantsNRIC,
                objECClaimDetails.RejectedReason,
                objECClaimDetails.WithdrawReason,
                objECClaimDetails.VoidReason,
                objECClaimDetails.NatureOfInjuryCode,
                objECClaimDetails.NatureOfLossCode,
                objECClaimDetails.LocalityOfInjuryCode,
                objECClaimDetails.NationalityCode,
                objECClaimDetails.ClaimStatusCode,
                objECClaimDetails.DateOfReturnToWork,
                objECClaimDetails.CloseDate,
                objECClaimDetails.ArchiveDate,
                objECClaimDetails.ReturnDocDate,
                objECClaimDetails.RejectedDate,
                objECClaimDetails.WithdrawDate,
                objECClaimDetails.VoidDate,
                objECClaimDetails.ClaimantName
            };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimDetails_InsertUpdate", "EC_ClaimDetails_InsertUpdate");
        }
        public DataSet GetECClaimDetailsData(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaimDetails.CaseRefNo, objECClaimDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_GetClaimDetails", "EC_GetClaimDetails");
        }
        public DataSet GetECClaimFollowUpDiaryData(clsECClaim objECClaim, string strClaimType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaim.CaseRefNo, objECClaim.ClaimRefNo, strClaimType };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimFollowUpDiary", "ECClaimFollowUpDiary");
        }
        public DataSet InsertUpdateClaimSickLeave(clsECClaimSickLeave objECClaimSickLeave)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objECClaimSickLeave.CaseRefNo, objECClaimSickLeave.ClaimRefNo, objECClaimSickLeave.RefNo, objECClaimSickLeave.LeaveFromDate, objECClaimSickLeave.LeaveToDate, objECClaimSickLeave.TotalDay, objECClaimSickLeave.UserID };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsSickLeaveInsertUpdate", "ECClaimsSickLeave");
        }
        public DataSet DeleteECClaimSickLeave(clsECClaimSickLeave objECClaimSickLeave)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimSickLeave.CaseRefNo, objECClaimSickLeave.ClaimRefNo, objECClaimSickLeave.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsSickLeaveDelete", "DeleteECClaimsSickLeave");
        }
        public DataSet InsertUpdateClaimPayment(clsECClaimPayment objECClaimPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[16] { objECClaimPayment.CaseRefNo, objECClaimPayment.ClaimRefNo, objECClaimPayment.RefNo, objECClaimPayment.PaymentDate, objECClaimPayment.PaidAmount, objECClaimPayment.PaymentType, objECClaimPayment.RecoverAmount, objECClaimPayment.ReserveAmount, objECClaimPayment.OSReserveAmount, objECClaimPayment.Remarks, objECClaimPayment.UserID, objECClaimPayment.BankName, objECClaimPayment.ChequeNo, objECClaimPayment.AmountOutstanding, objECClaimPayment.TotalIncurredClaim, objECClaimPayment.PaymentCurrency };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsPaymentInsertUpdate", "ECClaimsPaymentInsertUpdate");
        }
        public DataSet InsertUpdateClaimFeeSettlement(ClsECClaimFeeSettlement objECClaimFee)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objECClaimFee.CaseRefNo, objECClaimFee.ClaimRefNo, objECClaimFee.RefNo, objECClaimFee.PaymentDate, objECClaimFee.PaymentType, objECClaimFee.LegalFee, objECClaimFee.SurveyorFee, objECClaimFee.AdjusterFee, objECClaimFee.Remarks, objECClaimFee.UserID, objECClaimFee.BankName, objECClaimFee.ChequeNo, };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsFeeSettlementInsertUpdate", "ECClaimsFeeSettlementInsertUpdate");
        }
        public DataSet DeleteECClaimFeeSettlement(ClsECClaimFeeSettlement objECClaimFee)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimFee.CaseRefNo, objECClaimFee.ClaimRefNo, objECClaimFee.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsFeeSettlementDelete", "ECClaimsFeeSettlementDelete");
        }
        public DataSet DeleteECClaimPayment(clsECClaimPayment objECClaimPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimPayment.CaseRefNo, objECClaimPayment.ClaimRefNo, objECClaimPayment.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsPaymentDelete", "ECClaimsPaymentDelete");
        }
        public DataSet InsertUpdateClaimClaimentDtls(clsECClaimDetails objECClaimDtl)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objECClaimDtl.CaseRefNo, objECClaimDtl.ClaimRefNo, objECClaimDtl.RefNo, objECClaimDtl.ClaimantName, objECClaimDtl.UserID };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsClaimentInsertUpdate", "ECClaimsClaimentDtls");
        }

        public DataSet InsertUpdateClaimFollowUp(clsECClaimFollowUp objECClaimFollowUp)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[10] { objECClaimFollowUp.CaseRefNo, objECClaimFollowUp.ClaimRefNo, objECClaimFollowUp.RefNo, objECClaimFollowUp.FollowUpCode, objECClaimFollowUp.FollowUpReason, objECClaimFollowUp.FollowUpAlert, objECClaimFollowUp.FollowUpDate, objECClaimFollowUp.UserID, objECClaimFollowUp.TypeName, objECClaimFollowUp.DiaryDescription };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsFollowUpInsertUpdate", "ECClaimsFollowUpInsertUpdate");
        }
        public DataSet InsertUpdateClaimNote(clsECClaimNote objECClaimNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objECClaimNote.CaseRefNo, objECClaimNote.ClaimRefNo, objECClaimNote.ClaimNote, objECClaimNote.User };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsNoteInsertUpdate", "ECClaimsNoteInsertUpdate");
        }
        public DataSet DeleteECClaimFollowUp(clsECClaimFollowUp objECClaimFollowUp)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimFollowUp.CaseRefNo, objECClaimFollowUp.ClaimRefNo, objECClaimFollowUp.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsFollowUpDelete", "ECClaimsFollowUpDelete");
        }
        public DataSet DeleteECClaimClaiment(clsECClaimDetails objECClaimDtls)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimDtls.CaseRefNo, objECClaimDtls.ClaimRefNo, objECClaimDtls.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsClaimentDelete", "ECClaimsClaiment");
        }
        public DataSet GetECClaimUwriter(clsECClaimUnderwriter objECClaimUnderWriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimUnderWriter.CaseRefNo, objECClaimUnderWriter.ClaimRefNo, objECClaimUnderWriter.UnderWriterCode };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimUnderwriterDetails", "ECClaimUnderwriterDetails");
        }
        public DataSet SaveGenerateClaimNo(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaim.CaseRefNo, objECClaim.ClaimRefNo, objECClaim.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EC_GenerateClaimNo", "EC_GenerateClaimNo");
        }
        public DataSet InsertUpdateECClaimFileUpload(clsECClaimFileUpload objECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objECClaimFileUpload.CaseRefNo, objECClaimFileUpload.ClaimRefNo, objECClaimFileUpload.RefNo, objECClaimFileUpload.FileName, objECClaimFileUpload.FileType, objECClaimFileUpload.Remarks, objECClaimFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimFileUploadInsertUpdate", "EC_ClaimFileUploadInsertUpdate");
        }
        public DataSet GetECClaimFileUpload(clsECClaimFileUpload objECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaimFileUpload.CaseRefNo, objECClaimFileUpload.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimFileUploadDetails", "EC_ClaimFileUploadDetails");
        }
        public DataSet DeleteECClaimFileUpload(clsECClaimFileUpload objECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objECClaimFileUpload.CaseRefNo, objECClaimFileUpload.ClaimRefNo, objECClaimFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_ClaimFileUploadDelete", "EC_ClaimFileUploadDetails");
        }

        public DataSet GetECClaimsIncompleteClaimsListEnquiry(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[26] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.Location, objECClaim.ChequeRefNo, objECClaim.Disability_Grade, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.VesselName, userid, objECClaim.KeyAccountmanager, objECClaim.Industrytype, objECClaim.MotorRegNo };// disability grade added by kavita//
            return dataAccess.LoadDataSet(parameters, "P_EC_IncompleteClaimsList", "EC_IncompleteClaimsList");
        }
        public DataSet GetWICAECClaimsIncompleteClaimsListEnquiry(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[29] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.Location, objECClaim.ChequeRefNo, objECClaim.Disability_Grade, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.VesselName, userid, objECClaim.KeyAccountmanager, objECClaim.Industrytype, objECClaim.SubClassName, objECClaim.ClaimantName, objECClaim.NatureofInjury, objECClaim.ClaimInfoStatus };
            return dataAccess.LoadDataSet(parameters, "P_EC_IncompleteClaimsList", "EC_IncompleteClaimsList");
        }
        public DataSet GetECClaimsViewListEnquiry(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[29] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.Location, objECClaim.MotorRegNo, objECClaim.ThirdPartyDetails, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.LossNature, objECClaim.CauseOfLoss, objECClaim.ChequeRefNo, objECClaim.Disability_Grade, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.VesselName, userid, objECClaim.KeyAccountmanager, objECClaim.Industrytype };// disability grade added by kavita//
            return dataAccess.LoadDataSet(parameters, "P_EC_ViewClaimsList", "EC_ViewClaimsList");
        }
        public DataSet GetNonECClaimsIncompleteClaimsListEnquiry(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[25] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.AccidentDate, objECClaim.Location, objECClaim.MotorRegNo, objECClaim.ThirdPartyDetails, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.LossNature, objECClaim.CauseOfLoss, objECClaim.ChequeRefNo, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.KeyAccountmanager, objECClaim.Industrytype };
            return dataAccess.LoadDataSet(parameters, "P_EC_IncompleteNonClaimsList", "EC_IncompleteNonClaimsList");
        }
        public DataSet GetFollowupDiaryListEnquiry(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[30] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.Location, objECClaim.MotorRegNo, objECClaim.ThirdPartyDetails, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.LossNature, objECClaim.CauseOfLoss, objECClaim.ChequeRefNo, objECClaim.Disability_Grade, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.VesselName, userid, objECClaim.KeyAccountmanager, objECClaim.Industrytype,objECClaim.IssueDate  };//Added by Kavita
            return dataAccess.LoadDataSet(parameters, "P_EC_FollowupDiaryList", "EC_FollowupDiaryList");
        }
        public DataSet GetWICAFollowupDiaryListEnquiry(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[34] { objECClaim.IssueFromDate, objECClaim.IssueToDate, objECClaim.ClaimNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.UWClaimNo, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.ClaimStatus, objECClaim.POIFromDate, objECClaim.POIToDate, objECClaim.InjuredName, objECClaim.AccidentDate, objECClaim.Location, objECClaim.MotorRegNo, objECClaim.ThirdPartyDetails, objECClaim.ReportDate, objECClaim.NotifyDate, objECClaim.LossNature, objECClaim.CauseOfLoss, objECClaim.ChequeRefNo, objECClaim.Disability_Grade, objECClaim.UnderwriterCode, objECClaim.UnderwriterName, objECClaim.VesselName, userid, objECClaim.KeyAccountmanager, objECClaim.Industrytype, objECClaim.AccidentDate, objECClaim.ClaimantName, objECClaim.NatureofInjury, objECClaim.ClaimInfoStatus, objECClaim.NatureofLoss };
            return dataAccess.LoadDataSet(parameters, "P_EC_FollowupDiaryList", "EC_FollowupDiaryList");
        }
        public DataSet GetECClaimNewList(clsECClaim objECClaim, int UserId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[14] { objECClaim.ClientCode, objECClaim.ClientName, objECClaim.MainClassName, objECClaim.SubClassName, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.POIFromDate, objECClaim.POIToDate, UserId, objECClaim.KeyAccountmanager, objECClaim.Industrytype, objECClaim.VehicleNo, objECClaim.VesselName, objECClaim.IsDataFromHist };
            return dataAccess.LoadDataSet(parameters, "P_DN_ECClaimsList", "DN_ECClaimsList");
        }
        public DataSet GetClaimSummaryList(clsECClaim objECClaim, int UserId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[25] { objECClaim.IsDataFromHist, objECClaim.pintBrokerId, objECClaim.ConColumName, objECClaim.ConColumValues, objECClaim.sortBy, objECClaim.sortType, UserId, objECClaim.ReportType, objECClaim.ReportColumns, objECClaim.NotifyFromDate, objECClaim.NotifyToDate, objECClaim.ClaimNo, objECClaim.CoverNoteNo, objECClaim.ClientCode, objECClaim.ClientName, objECClaim.PolicyNo, objECClaim.MainClassName, objECClaim.SubClassName, objECClaim.UnderwriterName, objECClaim.VehicleNo, objECClaim.VesselName, objECClaim.DateofLoss, objECClaim.ClaimStatus, objECClaim.InsurerID, objECClaim.ClaimDiary };
            return dataAccess.LoadDataSet(parameters, "P_Get_ClaimSummary", "GetClaimList1");
        }
        //public DataSet GetClaimDetails(clsECClaim objECClaim, int UserId, string id, string reportType)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[8] { objECClaim.IsDataFromHist, objECClaim.pintBrokerId, objECClaim.ConColumName, objECClaim.ConColumValues, UserId, objECClaim.sortBy, objECClaim.sortType, objECClaim.ClaimDiary };
        //    return dataAccess.LoadDataSet(parameters, "Proc_GetClaimDetails", "GetClaimList");
        //}

        //Added by Apurva
        public DataSet GetClaimDetails(clsECClaim objECClaim, int UserId, string id, string reportType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { UserId, id, reportType };
            return dataAccess.LoadDataSet(parameters, "Proc_GetClaimDetails", "GetClaimList");
        }
        public DataSet GetClaimBillingUnderwriterDetails()
        {
            dataAccess = new DataAccess();

            return dataAccess.LoadDataSet("P_Pol_ClaimBilling_Underwriters_Select", "ClaimBillingUnderwriter");
        }

        //added on 23rd nov for claim billing
        public DataSet GetECClaimBilling(clsECClaim objECClaim, int userid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objECClaim.ClientName, objECClaim.UnderwriterName, objECClaim.PolicyNo, objECClaim.CoverNoteNo, objECClaim.VesselName, userid };
            return dataAccess.LoadDataSet(parameters, "P_Pol_GetClaimBilling", "DN_ClaimBilling");
        }
        public DataSet GetECClaimNote(clsECClaimNote objECClaimNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaimNote.CaseRefNo, objECClaimNote.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimsNoteSelect", "Claim_Data");
        }

        public DataSet ViewClaimBilling(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaim.CaseRefNo, objECClaim.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_ViewECClaimBilling", "ViewClaimBilling_Data");
        }

        public DataSet GetBillingType(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objECClaim.PolicyId, objECClaim.PolVersionId };
            return dataAccess.LoadDataSet(parameters, "P_Get_BillingType", "BillingType");
        }

        public DataSet GetAgeingDetails(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objECClaimDetails.ClientName
                ,objECClaimDetails.ClientCode
                ,objECClaimDetails.Class
                ,objECClaimDetails.PeriodofInsuranceFrom
                ,objECClaimDetails.PeriodofInsuranceTo
                ,objECClaimDetails.Insurer
                ,objECClaimDetails.ClaimNo
                ,objECClaimDetails.InsurerClaimNo
                ,objECClaimDetails.NotificationFromDate
                ,objECClaimDetails.NotificationToDate
                ,objECClaimDetails.Ageing
                ,objECClaimDetails.TotalIncured,objECClaimDetails.UserID
            };
            return dataAccess.LoadDataSet(parameters, "P_EC_Get_AgeingDetails", "P_EC_Get_AgeingDetails");
        }

        public DataSet GetLossRatioDetails(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objECClaimDetails.ClientName
                ,objECClaimDetails.ClientCode
                ,objECClaimDetails.PolicyNo
                ,objECClaimDetails.CoverNoteNo
                ,objECClaimDetails.PolicyType
                ,objECClaimDetails.PeriodofInsuranceFrom
                ,objECClaimDetails.PeriodofInsuranceTo
                ,objECClaimDetails.ReportType,objECClaimDetails.UserID
            };
            return dataAccess.LoadDataSet(parameters, "P_EC_Get_LossRatioDetails", "P_EC_Get_LossRatioDetails");
        }

        public DataSet GetAllSubClass()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_Get_AllSubClass", "P_Get_AllSubClass");
        }

        public DataSet GetClaimListingDetails(clsECClaimDetails objECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objECClaimDetails.ClientName
                ,objECClaimDetails.ClientCode
                ,objECClaimDetails.Class
                ,objECClaimDetails.CoverNoteNo
                ,objECClaimDetails.PolicyNo
                ,objECClaimDetails.PeriodofInsuranceFrom
                ,objECClaimDetails.PeriodofInsuranceTo
                ,objECClaimDetails.Insurer
                ,objECClaimDetails.Claim_Status,objECClaimDetails.UserID
            };
            return dataAccess.LoadDataSet(parameters, "P_EC_Get_ClaimListingDetails", "P_EC_Get_ClaimListingDetails");
        }
    }
}
