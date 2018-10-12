using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.Claims;
using BusinessAccessLayer.RIBrokingModule.Claims;
using BusinessObjectLayer.RIBrokingModule.CoverNote;

namespace BusinessAccessLayer.RIBrokingModule.Claims
{
    public class RIClaimManager
    {
        DataAccess dataAccess = new DataAccess();
        public DataSet GetCoverNoteForClaim(RIClaimSearch objRIClaimSearch)
        {
            Object[] parametes = new Object[]
                                    {
                                        objRIClaimSearch.CoverNoteNo,
                                        objRIClaimSearch.CedantCode,
                                        objRIClaimSearch.CedantName,
                                        objRIClaimSearch.ReinsuredCode,
                                        objRIClaimSearch.ReinsuredName,
                                        objRIClaimSearch.ClientCode,
                                        objRIClaimSearch.ClientName,
                                        objRIClaimSearch.CedantPolicyNo,
                                        objRIClaimSearch.MainClass,
                                        objRIClaimSearch.Handler,
                                        objRIClaimSearch.CreatedBy,
                                        objRIClaimSearch.From,
                                        objRIClaimSearch.ClaimNo,
                                        objRIClaimSearch.CedantClaimNo,
                                        objRIClaimSearch.SubClass,
                                        objRIClaimSearch.DateOfLoss
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RICM_CoverNoteSearch", "CoverNoteSearch");
        }

        public DataSet GetCoverNoteForClaimMovement(RIClaimSearch objRIClaimSearch)
        {
            Object[] parametes = new Object[]
                                    {
                                        objRIClaimSearch.CoverNoteNo,
                                        objRIClaimSearch.CedantCode,
                                        objRIClaimSearch.CedantName,
                                        objRIClaimSearch.ReinsuredCode,
                                        objRIClaimSearch.ReinsuredName,
                                        objRIClaimSearch.ClientCode,
                                        objRIClaimSearch.ClientName,
                                        objRIClaimSearch.CedantPolicyNo,
                                        objRIClaimSearch.MainClass,
                                        objRIClaimSearch.Handler,
                                        objRIClaimSearch.CreatedBy,
                                        objRIClaimSearch.From,
                                        objRIClaimSearch.ClaimNo,
                                        objRIClaimSearch.CedantClaimNo,
                                        objRIClaimSearch.SubClass,
                                        objRIClaimSearch.DateOfLoss,
                                        objRIClaimSearch.MovementNo
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RICM_MOV_CoverNoteSearch", "CoverNoteSearch");
        }

        public DataSet GetClaimSummary(RIClaimSummary objRIClaimSummary)
        {
            Object[] parametes = new Object[] { 
                                    objRIClaimSummary.TranRefNo,
                                    objRIClaimSummary.ClaimNo,
                                    objRIClaimSummary.PageMode
            };
            return dataAccess.LoadDataSet(parametes, "P_RICM_GetClaimSummary", "GetClaimSummary");
        }

        public DataSet GetInsuredById(string strID)
        {
            Object[] parametes = new Object[] { strID };
            return dataAccess.LoadDataSet(parametes, "P_RICM_GetInsuredById", "GetInsuredById");
        }

        public DataSet GetSubClassById(string strID)
        {
            Object[] parametes = new Object[] { strID };
            return dataAccess.LoadDataSet(parametes, "P_RICM_GetSubClassById", "GetSubClassById");
        }

        public DataSet SaveUpdateCliamSummary(RIClaimSummary objRIClaimSummary)
        {
            Object[] parametes = new Object[] {  
                                    objRIClaimSummary.TranRefNo,
                                    objRIClaimSummary.ClaimNo,
                                    objRIClaimSummary.CoverNoteNo,
                                    objRIClaimSummary.MainClass,
                                    objRIClaimSummary.SubClassCode,
                                    objRIClaimSummary.CedantClaimNo,
                                    objRIClaimSummary.PolicyNo,
                                    objRIClaimSummary.OtherReference,
                                    objRIClaimSummary.CedantCode,
                                    objRIClaimSummary.CedantName,
                                    objRIClaimSummary.CedantRefNo,
                                    objRIClaimSummary.Description,
                                    objRIClaimSummary.NWIClaimRef,
                                    objRIClaimSummary.Project,
                                    objRIClaimSummary.ReinsuredCode,
                                    objRIClaimSummary.ReinsuredName,
                                    objRIClaimSummary.ClientRefNo,
                                    objRIClaimSummary.Currency,
                                    objRIClaimSummary.MainExpiry,
                                    objRIClaimSummary.PeriodFrom,
                                    objRIClaimSummary.PeriodTo,
                                    objRIClaimSummary.Insured,
                                    objRIClaimSummary.ClientName,
                                    objRIClaimSummary.Jurisdiction,
                                    objRIClaimSummary.DateOfLoss,
                                    objRIClaimSummary.NatureOfLoss,
                                    objRIClaimSummary.Remarks,
                                    objRIClaimSummary.Comments,
                                    objRIClaimSummary.UserId
                                    ,objRIClaimSummary.NotifyDt
                                    ,objRIClaimSummary.DairyDT
                                    ,objRIClaimSummary.DairyDesc
            };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimSummaryInsertUpdate", "ClaimSummaryInsertUpdate");
        }

        public DataSet SaveClaimDescription(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { 
                                    objClaimDetails.ClaimNo,
                                    objClaimDetails.Description,
                                    objClaimDetails.UserId,
                                     objClaimDetails.RelClaimNo ,
            objClaimDetails.LossDetails ,
            objClaimDetails.DTOfAccident ,
            objClaimDetails.Occupation,
            objClaimDetails.MonthlyEarn ,
            objClaimDetails.CurrencyCode ,
            objClaimDetails.ServeyorID ,
            objClaimDetails.LossAdjustID ,
            objClaimDetails.LawyerID,
            objClaimDetails.TPAID ,
            objClaimDetails.InvestigatorID,
            objClaimDetails.PermanentDisability,
            objClaimDetails.Status ,
            objClaimDetails.PaymentStatus ,
            objClaimDetails.CedantLossAmt ,
            objClaimDetails.DeductAmt ,
            objClaimDetails.Expenses,
            objClaimDetails.OurClaimResvAmt,
            objClaimDetails.OurDeductAmt,
            objClaimDetails.ClaimDesc,
            objClaimDetails.OurExpensesAmt,
            objClaimDetails.OurRecoveryAmt,
            objClaimDetails.OurClaimPaidAmt ,
            objClaimDetails.IncurredClaimAmt,
            objClaimDetails.InjuryDeathID,
            objClaimDetails.clmDetailsDesc,
            objClaimDetails.CedantLossCurr,
          objClaimDetails.DeductCurr,
          objClaimDetails.ExpensesCurr,
          objClaimDetails.OClaimResCurr,
          objClaimDetails.ODeductCurr,
          objClaimDetails.OExpenCurr,
          objClaimDetails.ORecovCurr,
          objClaimDetails.OClaimPaidCurr
                                                };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDescriptionInsertUpdate", "ClaimDescriptionInsertUpdate");
        }

        public DataSet SaveClaimLocation(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { 
                                    objClaimDetails.ClaimNo,
                                    objClaimDetails.LocationID,
                                    objClaimDetails.Location,
                                    objClaimDetails.LocationDescription,
                                    objClaimDetails.Province,
                                    objClaimDetails.Country,
                                    objClaimDetails.UserId
                                                };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsLocationInsertUpdate", "ClaimDetailsLocationInsertUpdate");
        }

        public DataSet SaveClaimShareDetails(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { 
                                     objClaimDetails.ClaimNo,
                                     objClaimDetails.Share,
                                     objClaimDetails.CurrencyCode,
                                     objClaimDetails.ShareClaimResvAmt,
                                     objClaimDetails.ShareDeductAmt ,
                                     objClaimDetails.ShareExpensesAmt,
                                     objClaimDetails.ShareRecoveryAmt,
                                     objClaimDetails.ShareClaimPaidAmt,
                                     objClaimDetails.ShareIncurredClaimAmt,
                                     objClaimDetails.ReInsuCode,
                                     objClaimDetails.ReInsuName,
                                     objClaimDetails.UserId,
                                     objClaimDetails.ClaimShareID
                                     };
            return dataAccess.LoadDataSet(parametes, "P_RI_ClaimShareDetails", "ClaimShareDetails");
        }
        public DataSet SaveClaimShareDetailsovement(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { 
                                     objClaimDetails.ClaimNo,
                                     objClaimDetails.Share,
                                     objClaimDetails.CurrencyCode,
                                     objClaimDetails.ShareClaimResvAmt,
                                     objClaimDetails.ShareDeductAmt ,
                                     objClaimDetails.ShareExpensesAmt,
                                     objClaimDetails.ShareRecoveryAmt,
                                     objClaimDetails.ShareClaimPaidAmt,
                                     objClaimDetails.ShareIncurredClaimAmt,
                                     objClaimDetails.ReInsuCode,
                                     objClaimDetails.ReInsuName,
                                     objClaimDetails.UserId,
                                     objClaimDetails.ClaimShareID
                                     };
            return dataAccess.LoadDataSet(parametes, "P_RI_ClaimShareDetailsMovement", "ClaimShareDetails");
        }
        public DataSet GetClaimDeatilsData(string strClaimNo, string strFrom, string strTransNo, string MovementNos)
        {
            Object[] parametes = new Object[] { strClaimNo, strFrom, strTransNo, MovementNos };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsGetData", "ClaimDetailsGetData");
        }
        public DataSet GetClaimHistoryDeatilsData(string strClaimNo, string strFrom, string strTransNo)
        {
            Object[] parametes = new Object[] { strClaimNo, strTransNo };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimHistoryGetData", "ClaimHistoryDetailsGetData");
        }
        public DataSet DeleteClaimLocation(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { objClaimDetails.ClaimNo, objClaimDetails.LocationID };
            return dataAccess.LoadDataSet(parametes, "P_RICM_DeleteClaimLocation", "DeleteClaimLocation");
        }

        public DataSet SaveClaimMovement(RIClaimDetails objClaimDetails)
        {
            Object[] parametes = new Object[] { 
                                    objClaimDetails.ClaimNo,
                                    objClaimDetails.Movement,
                                    objClaimDetails.CauseCode,
                                    objClaimDetails.Cause,
                                    objClaimDetails.Currency,
                                    objClaimDetails.ClaimAmount,
                                    objClaimDetails.DeductibleExcess,
                                    objClaimDetails.Expenses,
                                    objClaimDetails.Recovery,
                                    objClaimDetails.ClaimPaid,
                                    objClaimDetails.ClaimReserve,
                                    objClaimDetails.IncurredClaim,
                                    objClaimDetails.CashCall,
                                    objClaimDetails.Remarks,
                                    objClaimDetails.Comments,
                                    objClaimDetails.UserId, 
                                    objClaimDetails.CedantLossAmt ,
                                    objClaimDetails.DeductAmt ,
                                    objClaimDetails.ExpensesAmt

            };

            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsMovementInsertUpdate", "ClaimDetailsMovementInsertUpdate");
        }

        public DataSet GetClaimDeatilsCollectionData(string strClaimNo, string strUserCode)
        {
            Object[] parametes = new Object[] { strClaimNo, strUserCode };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsCollectionGetData", "ClaimDetailsCollectionGetData");
        }
        public DataSet SaveDetailsCollection(RIClaimDetailsCollection objRIClaimDetailsCollection)
        {
            Object[] parametes = new Object[] { 
                                    objRIClaimDetailsCollection.ClaimNo,
                                    objRIClaimDetailsCollection.ID,
                                    objRIClaimDetailsCollection.MovementNo,
                                    objRIClaimDetailsCollection.IsChanged,
                                    objRIClaimDetailsCollection.IsAdded,
                                    objRIClaimDetailsCollection.CodePrefix,
                                    objRIClaimDetailsCollection.Code,
                                    objRIClaimDetailsCollection.RIApplication,
                                    objRIClaimDetailsCollection.Reinsurer,
                                    objRIClaimDetailsCollection.Share,
                                    objRIClaimDetailsCollection.RefNo,
                                    objRIClaimDetailsCollection.PaidAmount,
                                    objRIClaimDetailsCollection.Reserve,
                                    objRIClaimDetailsCollection.InvoiceNo,
                                    objRIClaimDetailsCollection.Status,
                                    objRIClaimDetailsCollection.SettlementCurrency,
                                    objRIClaimDetailsCollection.ReceiptNo,
                                    objRIClaimDetailsCollection.DOS,
                                    objRIClaimDetailsCollection.SettlementAmount,
                                    objRIClaimDetailsCollection.UserId};

            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsCollectionInsertUpdate", "ClaimDetailsCollectionInsertUpdate");
        }
        public DataSet DeleteClaimCollectionReinsurer(RIClaimDetailsCollection objRIClaimDetailsCollection)
        {
            Object[] parametes = new Object[] { 
                                                objRIClaimDetailsCollection.ClaimNo, 
                                                objRIClaimDetailsCollection.MovementNo, 
                                                objRIClaimDetailsCollection.ID 
                                                };
            return dataAccess.LoadDataSet(parametes, "P_RICM_DeleteClaimCollectionReinsurer", "DeleteClaimCollectionReinsurer");
        }

        public DataSet GetClaimInvoiceData(string strClaimNo, string RefsNos, string MovementNos)
        {
            Object[] parametes = new Object[] { strClaimNo, RefsNos,MovementNos };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimInvoiceGetData", "ClaimInvoiceGetData");
        }

        public DataSet ClaimFileUpload(ClsFileAttachment objFileAttachment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                        objFileAttachment.TranRefNo,
                        objFileAttachment.SavedFileName, 
                        objFileAttachment.FileName, 
                        objFileAttachment.FileType, 
                        objFileAttachment.Remarks, 
                        objFileAttachment.UserId,
                        objFileAttachment.UploadFolderPath };
            return dataAccess.LoadDataSet(parameters, "P_RICM_FileAttachment", "FileAttachment");
        }

        public DataSet ClaimGetUploadedFileList(string strCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode};
            return dataAccess.LoadDataSet(parameters, "P_RICM_FileAttachmentList", "FileAttachment");
        }
        public DataSet ClaimDeleteUploadedFile(ClsFileAttachment objFileAttachment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objFileAttachment.TranRefNo, objFileAttachment.ID };
            return dataAccess.LoadDataSet(parameters, "P_RICM_FileAttachmentDelete", "FileAttachment");
        }
        public DataSet CompleteClaim(string strCode, string strUser)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode, strUser };
            return dataAccess.LoadDataSet(parameters, "P_RICM_CompleteClaim", "CompleteClaim");
        }
        public DataSet GetClaimDeatilsCollectionDataByMovement(string strClaimNo, string strMovementNo)
        {
            Object[] parametes = new Object[] { strClaimNo, strMovementNo };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimDetailsCollectionGetDataByMovement", "ClaimDetailsCollectionGetDataByMovement");
        }
        public DataSet GetClaimRemarksByMovement(string strClaimNo, string strMovementNo)
        {
            Object[] parametes = new Object[] { strClaimNo, strMovementNo };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimRemarksByMovement", "ClaimRemarksByMovement");
        }

        public DataSet LoadHeader(string strClaimNo)
        {
            Object[] parametes = new Object[1] { strClaimNo };
            return dataAccess.LoadDataSet(parametes, "P_RICM_LoadClaimHeaderDetails", "Lo adClaimHeaderDetails");
        }
        public DataSet LoadMenuDetails(string strClaimNo)
        {
            Object[] parametes = new Object[1] { strClaimNo };
            return dataAccess.LoadDataSet(parametes, "P_RICM_ClaimMenuEnableDisable", "LoadClaimMenuDetails");
        }
        public DataSet InsertUpdateRIClaimClaimentDtls(RIClaimDetails objECClaimDtl)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objECClaimDtl.ClaimNo, objECClaimDtl.RefNo, objECClaimDtl.ClaimentName, objECClaimDtl.UserId };
            return dataAccess.LoadDataSet(parameters, "P_RI_RIClaimsClaimentInsertUpdate", "RIClaimsClaimentDtls");
        }
        public DataSet DeleteRIClaimClaiment(int claimentIDs)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { claimentIDs };
            return dataAccess.LoadDataSet(parameters, "P_RI_ClaimsClaimentDelete", "RIClaimsClaiment");
        }
    }
}
