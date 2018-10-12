using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Claims;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Claims
{
    public class NonECClaimManager
    {
        DataAccess dataAccess = null;
        public NonECClaimManager() 
        { 

        }        
        public DataSet InsertUpdateECClaims(clsNonECClaim objNonECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[45] { 
                objNonECClaim.PageMode ,objNonECClaim.CaseRefNo,objNonECClaim.ClaimRefNo,  objNonECClaim.IssueDate ,objNonECClaim.IsVoid  ,objNonECClaim.ClientCode , objNonECClaim.ClientName , objNonECClaim.UWClaimNo , 
                objNonECClaim.MainClassCode ,objNonECClaim.MainClassName ,objNonECClaim.PolicyNo ,objNonECClaim.CoverNoteNo, objNonECClaim.POIFromDate,objNonECClaim.POIToDate ,objNonECClaim.Location ,objNonECClaim.NotifyBy , objNonECClaim.NotifyDate,objNonECClaim.Team ,  
                objNonECClaim.FirstName , objNonECClaim.LastName ,objNonECClaim.DirectLine1,objNonECClaim.DirectLine2 ,objNonECClaim.MobileNo1 ,objNonECClaim.MobileNo2, objNonECClaim.FaxNo1,objNonECClaim.FaxNo2,
                objNonECClaim.Email,objNonECClaim.ClaimsHandlerCode ,objNonECClaim.ClaimsHandlerName,objNonECClaim.SurveyorCode , objNonECClaim.SurveyorName,  objNonECClaim.AccountHandlerCode ,objNonECClaim.AccountHandlerName  ,
                objNonECClaim.LossAdjusterCode ,objNonECClaim.LossAdjusterName ,objNonECClaim.HealthCareCode ,objNonECClaim.HealthCareName , objNonECClaim.SolicitorCode , objNonECClaim.SolicitorName ,objNonECClaim.InvestigatorCode ,
                objNonECClaim.InvestigatorName ,objNonECClaim.UserID,objNonECClaim.PolicyId, objNonECClaim.PolVersionId , objNonECClaim.FileStatus};
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimInsertUpdate", "InsertEC_ClaimsData");
        }
        public DataSet InsertUpdateECClaimsUnderwriter(clsNonECClaimUnderwriter objNonECClaimUnderwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[15] { objNonECClaimUnderwriter.CaseRefNo,objNonECClaimUnderwriter.ClaimRefNo , objNonECClaimUnderwriter.ClaimNo,objNonECClaimUnderwriter.RefNo,objNonECClaimUnderwriter.UnderWriterCode,objNonECClaimUnderwriter.UnderWriterName ,
                objNonECClaimUnderwriter.UWShare ,objNonECClaimUnderwriter.UWLastName ,objNonECClaimUnderwriter.UWFirstName, objNonECClaimUnderwriter.UWTelCC ,objNonECClaimUnderwriter.UWTel ,objNonECClaimUnderwriter.UWFaxCC,objNonECClaimUnderwriter.UWFax ,		objNonECClaimUnderwriter.UWEmail,objNonECClaimUnderwriter.UserID};
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimUnderwriterInserUpdate", "InsertEC_ClaimsUnderwriterData");
        }
        public DataSet GetECClaimData(clsNonECClaim objNonECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objNonECClaim.CaseRefNo, objNonECClaim.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_NonCalimsRegistrationDetails", "EC_CalimsRegistrationDetails");
        }
        public DataSet InsertUpdateECClaimsDetails(clsNonECClaimDetails objNonECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[32] {  objNonECClaimDetails.CaseRefNo ,objNonECClaimDetails.ClaimRefNo,objNonECClaimDetails.ClaimNo ,objNonECClaimDetails.CoverNoteNo ,objNonECClaimDetails.UnderwriterCode, objNonECClaimDetails.UnderwriterName ,objNonECClaimDetails.UWShare ,
                    objNonECClaimDetails.ReportDate ,objNonECClaimDetails.LossDate ,objNonECClaimDetails.Currency ,objNonECClaimDetails.LossNatureCode,objNonECClaimDetails.LossNature ,objNonECClaimDetails.ClaimAmount ,objNonECClaimDetails.CauseOfLossCode,objNonECClaimDetails.CauseOfLoss ,objNonECClaimDetails.TotalPaid ,objNonECClaimDetails.MotorRegNo ,
                    objNonECClaimDetails.AdjusterFee ,objNonECClaimDetails.ThirdPartyDetails ,objNonECClaimDetails.Current_OSReserveAmount ,objNonECClaimDetails.LossDetails ,objNonECClaimDetails.Total_Incurred ,objNonECClaimDetails.Claim_Status ,objNonECClaimDetails.Claim_StatusDate ,
                    objNonECClaimDetails.PaymentStatus ,objNonECClaimDetails.Alet_AccountHandler, objNonECClaimDetails.PaymentName ,objNonECClaimDetails.PaymentModeCode ,objNonECClaimDetails.PaymentModeDesc ,objNonECClaimDetails.PaymentRef , objNonECClaimDetails.ReferenceNo, objNonECClaimDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EC_NonClaimDetails_InsertUpdate", "EC_ClaimDetails_InsertUpdate");
        }
        public DataSet GetECClaimDetailsData(clsNonECClaimDetails objNonECClaimDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objNonECClaimDetails.CaseRefNo, objNonECClaimDetails.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_GetNonClaimDetails", "GetNonClaimDetails");
        }
        public DataSet GetECClaimFollowUpDiaryData(clsECClaim objECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objECClaim.CaseRefNo, objECClaim.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECClaimFollowUpDiary", "ECClaimFollowUpDiary");
        }        
        public DataSet InsertUpdateClaimPayment(clsNonECClaimPayment objNonECClaimPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objNonECClaimPayment.CaseRefNo, objNonECClaimPayment.ClaimRefNo, objNonECClaimPayment.RefNo, objNonECClaimPayment.PaymentDate, objNonECClaimPayment.PaidAmount, objNonECClaimPayment.PaymentType, objNonECClaimPayment.RecoverAmount, objNonECClaimPayment.ReserveAmount, objNonECClaimPayment.OSReserveAmount, objNonECClaimPayment.Remarks, objNonECClaimPayment.UserID };
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimsPaymentInsertUpdate", "ECNonClaimsPaymentInsertUpdate");
        }
        public DataSet DeleteECClaimPayment(clsNonECClaimPayment objNonECClaimPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objNonECClaimPayment.CaseRefNo, objNonECClaimPayment.ClaimRefNo, objNonECClaimPayment.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimsPaymentDelete", "ECNonClaimsPaymentDelete");
        }
        public DataSet InsertUpdateClaimFollowUp(clsNonECClaimFollowUp objNonECClaimFollowUp)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[8] { objNonECClaimFollowUp.CaseRefNo, objNonECClaimFollowUp.ClaimRefNo, objNonECClaimFollowUp.RefNo, objNonECClaimFollowUp.FollowUpCode, objNonECClaimFollowUp.FollowUpReason, objNonECClaimFollowUp.FollowUpAlert, objNonECClaimFollowUp.FollowUpDate, objNonECClaimFollowUp.UserID };
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimsFollowUpInsertUpdate", "ECNonClaimsFollowUpInsertUpdate");
        }
        public DataSet DeleteECClaimFollowUp(clsNonECClaimFollowUp objNonECClaimFollowUp)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objNonECClaimFollowUp.CaseRefNo, objNonECClaimFollowUp.ClaimRefNo, objNonECClaimFollowUp.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_ECNonClaimsFollowUpDelete", "ECNonClaimsFollowUpDelete");
        }
        public DataSet GetECClaimUwriter(clsNonECClaimUnderwriter objNonECClaimUnderWriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objNonECClaimUnderWriter.CaseRefNo, objNonECClaimUnderWriter.ClaimRefNo, objNonECClaimUnderWriter.UnderWriterCode };
            return dataAccess.LoadDataSet(parameters, "P_ECNoClaimUnderwriterDetails", "ECNoClaimUnderwriterDetails");
        }
        public DataSet SaveGenerateClaimNo(clsNonECClaim objNonECClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objNonECClaim.CaseRefNo, objNonECClaim.ClaimRefNo, objNonECClaim.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EC_GenerateNonClaimNo", "NonECGenerateNonClaimNo");
        }
        public DataSet InsertUpdateECClaimFileUpload(clsNonECClaimFileUpload objNonECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objNonECClaimFileUpload.CaseRefNo, objNonECClaimFileUpload.ClaimRefNo, objNonECClaimFileUpload.RefNo, objNonECClaimFileUpload.FileName, objNonECClaimFileUpload.FileType, objNonECClaimFileUpload.Remarks, objNonECClaimFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_EC_NonClaimFileUploadInsertUpdate", "EC_ClaimFileUploadInsertUpdate");
        }
        public DataSet GetECClaimFileUpload(clsNonECClaimFileUpload objNonECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objNonECClaimFileUpload.CaseRefNo, objNonECClaimFileUpload.ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_NonClaimFileUploadDetails", "EC_ClaimFileUploadDetails");
        }
        public DataSet DeleteECClaimFileUpload(clsNonECClaimFileUpload objNonECClaimFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objNonECClaimFileUpload.CaseRefNo, objNonECClaimFileUpload.ClaimRefNo, objNonECClaimFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EC_NonClaimFileUploadDelete", "EC_ClaimFileUploadDetails");
        }


    }
}
