using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class CoverNoteManager
    {
        DataAccess dataAccessDS = null;

        public DataSet GetIsCheckEndorsementType(int polid)
        {
            object[] parameters = new object[] { polid };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_FindEndorsementType", "EndorsementType");

        }



        public DataSet GetIntroducerducerDetaisForSummary(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.VessedId, objclsQuotation.IsEndorse };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IntroducerSummary", "P_IntroducerSummary");
        }

        public DataSet GetCoverNoteDetails(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_CoverNoteDetails_Select", "CoverNoteList");
        }


        public DataSet SaveCoverNoteDetail(clsQuotation objclsQuotation, string process,
            string UpfrontDuedateStatus,
            string DdlPPWWaiveStatus)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objclsQuotation.PolicyNo,
                                                 objclsQuotation.EndorsementNo,
                                                 objclsQuotation.PrevPolicyNo,
                                                 objclsQuotation.InsurerDBNote,
                                                 objclsQuotation.BillingDate,
                                                 objclsQuotation.PremiumRate,
                                                 objclsQuotation.FollowupDate,
                                                 objclsQuotation.FollowupReason,
                                                 objclsQuotation.EndDebitNoteNo,
                                                 objclsQuotation.EndBillingDate,
                                                 objclsQuotation.User,
                                                 //added by himanshu for 18065
                                                 objclsQuotation.InsurerTaxInvoice,
                                                 objclsQuotation.PolicyReceivedDate,
                                                 //objclsQuotation.InsurerTaxInvoiceNumber,
                                                 objclsQuotation.PPW_Waive_Status,
                                                 objclsQuotation.NewDate,
                                                 objclsQuotation.EndrsmntStartDate,
                                                 objclsQuotation.EndrsmntEndDate,
                                                 process,
                                                 UpfrontDuedateStatus,
                                                 DdlPPWWaiveStatus
                                                  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_CoverNoteDetails_InsertUpdate", "CoverNoteList");

        }
        public DataSet GetPolicyHistory(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyHistory_Select", "CoverNoteList");
        }
        public DataSet GetRenewalChkListDetails(clsRenewalChkList objRenewalChkList)
        {
            object[] parameters = new object[] { objRenewalChkList.PolicyId, objRenewalChkList.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyRenewalChkList_Select", "CoverNoteList");
        }
        public DataSet GetRenewalRemarketList(clsRenRemarket objRemarket)
        {
            object[] parameters = new object[] { objRemarket.PolicyId, objRemarket.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenRemarketList_Select", "RemarketList");
        }
        public DataSet SaveRenRemarketList(clsRenewalChkList objRenewalChkList, string xmlData, string SubClassXml)
        {
            object[] parameters = new object[] { objRenewalChkList.PolicyId,
                                                 objRenewalChkList.PolVersionId,
                                                 xmlData,
                                                 SubClassXml
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenRemarketList_InsertUpdate", "RemarketList");

        }
        public DataSet SaveRenewalChkListDetail(clsRenewalChkList objRenewalChkList)
        {
            object[] parameters = new object[] { objRenewalChkList.PolicyId,
                                                 objRenewalChkList.PolVersionId,
                                                 objRenewalChkList.PolicyNo,
                                                 objRenewalChkList.Insurer,
                                                 objRenewalChkList.PaymentMode,
                                                 objRenewalChkList.RenewalDate,
                                                 objRenewalChkList.ClmsExpForLast2YrsYN,
                                                    objRenewalChkList.ClmsExpForLast2YrsDate,
                                                    objRenewalChkList.ClmsExpForLast2YrsRemarks,
                                                    objRenewalChkList.RenewalOfferYN,
                                                    objRenewalChkList.RenewalOfferDate,
                                                    objRenewalChkList.RenewalOfferRemarks,
                                                    objRenewalChkList.RenOfferFrwdToMrkgClgsDate,
                                                    objRenewalChkList.UpdateCensusYN,
                                                    objRenewalChkList.UpdateCensusDate,
                                                    objRenewalChkList.UpdateCensusRemarks,
                                                    objRenewalChkList.OverageOverseaLoadingYN,
                                                    objRenewalChkList.OverageOverseaLoadingRemarks,
                                                    objRenewalChkList.PrpslToClientYN,
                                                    objRenewalChkList.PrpslToClientDate,
                                                    objRenewalChkList.PrpslToClientRemarks,
                                                    objRenewalChkList.PrpslToClientRevised1YN,
                                                    objRenewalChkList.PrpslToClientRvsd1Date,
                                                    objRenewalChkList.PrpslToClientRvsd1Remarks,
                                                    objRenewalChkList.PrpslToClientRvsd2YN,
                                                    objRenewalChkList.PrpslToClientRvsd2Date,
                                                    objRenewalChkList.PrpslToClientRvsd2Remarks,
                                                    objRenewalChkList.CntctClientDscussRnwlYN,
                                                    objRenewalChkList.CntctClientDscussRnwlDate,
                                                    objRenewalChkList.MediTopPromotionYN,
                                                    objRenewalChkList.MediTopPromotionDate,
                                                    objRenewalChkList.MeetingWithClientYN,
                                                    objRenewalChkList.MeetingWithClientDate,
                                                    objRenewalChkList.VaccinationYN,
                                                    objRenewalChkList.VaccinationDate,
                                                    objRenewalChkList.MeetingWithClient2ndYN,
                                                    objRenewalChkList.MeetingWithClient2ndDate,
                                                    objRenewalChkList.StaffBriefingYN,
                                                    objRenewalChkList.StaffBriefingDate,
                                                    objRenewalChkList.MeetingWithClient3rdYN,
                                                    objRenewalChkList.MeetingWithClient3rdDate,
                                                    objRenewalChkList.AfterSalesServiceYN,
                                                    objRenewalChkList.AfterSalesServiceDate,
                                                    objRenewalChkList.RcvdCnfmtnSlpFrmClientYN,
                                                    objRenewalChkList.RcvdCnfmtnSlpFrmClientDate,
                                                    objRenewalChkList.RcvdCnfmtnSlpFrmClientRemarks,
                                                    objRenewalChkList.MakeCnfmtnToInsurerYN,
                                                    objRenewalChkList.MakeCnfmtnToInsurerDate,
                                                    objRenewalChkList.MakeCnfmtnToInsurerRemarks,
                                                    objRenewalChkList.PolicyEndrsmntIssuedYN,
                                                    objRenewalChkList.PolicyEndrsmntDate,
                                                    objRenewalChkList.PolicyEndrsmntRemarks,
                                                    objRenewalChkList.SOSCardMdclCardYN,
                                                    objRenewalChkList.SOSCardMdclCardDate,
                                                    objRenewalChkList.SOSCardMdclCardRemarks,
                                                    objRenewalChkList.MmbrBookletLeafletYN,
                                                    objRenewalChkList.MmbrBookletLeafletDate,
                                                    objRenewalChkList.MmbrBookletLeafletRemarks,
                                                    objRenewalChkList.PanelDoctorLstYN,
                                                    objRenewalChkList.PanelDoctorLstDate,
                                                    objRenewalChkList.PanelDoctorLstRemarks,
                                                    objRenewalChkList.PremiumBillYN,
                                                    objRenewalChkList.PremiumBillDate,
                                                    objRenewalChkList.PremiumBillRemarks,
                                                    objRenewalChkList.PremiumBillAdjstmntYN,
                                                    objRenewalChkList.PremiumBillAdjstmntDate,
                                                    objRenewalChkList.PremiumBillAdjstmntRemarks,
                                                    objRenewalChkList.ExistingBrokerage,
                                                    objRenewalChkList.ExistingPremium,
                                                    objRenewalChkList.RenewalBrokerage,
                                                    objRenewalChkList.RenewalPremium,
                                                    objRenewalChkList.InsurerName,
                                                    objRenewalChkList.Marketing,
                                                    objRenewalChkList.Admin,
                                                    objRenewalChkList.DcmntsFrwdToAdminColleagueOn,
                                                    objRenewalChkList.User
                                                 
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_RenewalChkListDetails_InsertUpdate", "RenewalChkList");

        }
        public DataSet GetDiaryInfo(clsDiaryInfo objDiaryInfo)
        {
            object[] parameters = new object[] { //objDiaryInfo.DiaryId,
                                                objDiaryInfo.PolicyId, objDiaryInfo.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_DiaryInfo_Select", "DiaryList");
        }
        public DataSet GetIRMDiaryInfo(clsDiaryInfo_RI objDiaryInfo)
        {
            object[] parameters = new object[] { objDiaryInfo.CoverNoteNo, objDiaryInfo.TranRefNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "RI_Renewal_DiaryInfo_Select", "DiaryList");
        }
        public DataSet SaveDiaryInfo(clsDiaryInfo objDiaryInfo)
        {
            object[] parameters = new object[] { //objDiaryInfo.DiaryId,
                                                 objDiaryInfo.PolicyId,
                                                 objDiaryInfo.PolVersionId,
                                                 objDiaryInfo.DiaryDate,
                                                 objDiaryInfo.DiaryDesc,
                                                 objDiaryInfo.Status,
                                                 objDiaryInfo.ReDiaryDate,
                                                 objDiaryInfo.User
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_DiaryInfo_InsertUpdate", "DiaryList");

        }
        public DataSet SaveDiaryInfo_RI(clsDiaryInfo_RI objDiaryInfo)
        {
            object[] parameters = new object[] { objDiaryInfo.CoverNoteNo,
                                                 objDiaryInfo.TranRefNo,
                                                 objDiaryInfo.DiaryDesc,
                                                 objDiaryInfo.Status,
                                                 objDiaryInfo.ReDiaryDate,
                                                 objDiaryInfo.User
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "RI_Renewal_DiaryInfo_InsertUpdate", "DiaryList");
        }
        public DataSet GetRenewalLetterInfo(clsQuotation objclsQuotation, int UserId)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, UserId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenewalLetterInfo_Select", "RenewalLetterList");
        }
        public DataSet GetRIRenewalLetterInfo(ClsRenewalLetter_RI objclsQuotation, int UserId)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, UserId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenewalLetterInfo_Select_RI", "RenewalLetterList");
        }
        public DataSet SaveRenLetterInfo(ClsRenewalLetter objRenLetter)
        {
            object[] parameters = new object[] { objRenLetter.PolicyId,
                                                 objRenLetter.PolVersionId,
                                                 objRenLetter.ClientId,
                                                 objRenLetter.Content,
                                                 objRenLetter.UserId,
                                                 objRenLetter.AuthName,
                                                 objRenLetter.AuthDesignation,
                                                 objRenLetter.User

                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenewalLetterInfo_InsertUpdate", "RenewalLetterList");
        }
        public DataSet SaveRenLetterInfo_RI(ClsRenewalLetter_RI objRenLetter)
        {
            object[] parameters = new object[] { objRenLetter.PolicyId,
                                                 objRenLetter.PolVersionId,
                                                 objRenLetter.ClientId,
                                                 objRenLetter.Content,
                                                 objRenLetter.UserId,
                                                 objRenLetter.AuthName,
                                                 objRenLetter.AuthDesignation,
                                                 objRenLetter.User

                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RenewalLetterInfo_InsertUpdate_RI", "Pol_PolicyRenewalLetter_RI");
        }
        public DataSet GetRenewalClaimListing(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RenClaimDetails_Select", "ClaimList");
        }
        public DataSet UpdateRenStatus(clsQuotation objclsQuotation, string Status)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, Status,objclsQuotation.RenewalReasonId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_ChangePolicyStatus", "ClaimList");
        }
        public DataSet UpdateRenStatus_RI(ClsRenewalLetter_RI objclsQuotation, string Status)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, Status };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_ChangePolicyStatus_RI", "RI_CN_GeneralInformation");
        }
        public DataSet RemarketPolicy(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_Remarket", "Remarket");
        }
        public DataSet RenewPolicy(clsQuotation objclsQuotation, int LoginTeamId)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.RenPolStatus, objclsQuotation.User, LoginTeamId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RenewPolicy", "RenewedPolicy");
        }
        public DataSet RevisedPolicy(clsQuotation objclsQuotation, int LoginTeamId)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.RenPolStatus, objclsQuotation.User, LoginTeamId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RevisedPolicy", "RenewedPolicy");
        }
        public DataSet ExtendPolicy(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.POIFromDate, objclsQuotation.POIToDate, objclsQuotation.MaintenancePeriodFromDate, objclsQuotation.MaintenancePeriodToDate, objclsQuotation.User, objclsQuotation.RenPolStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyExtension_InsertUpdate", "ExtendedPolicy");
        }
        public DataSet GetExtendedDetails(clsQuotation objclsQuotation, bool IsExtended)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, IsExtended };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyExtension_Select", "ExtendedPolicy");

        }
        public DataSet CancelPolicyStatus(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.Pol_Status };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_CancelPolicyStatus", "ExtendedPolicy");

        }
        public DataSet HoldPolicy(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.POIFromDate, objclsQuotation.POIToDate, objclsQuotation.MaintenancePeriodFromDate, objclsQuotation.MaintenancePeriodToDate, objclsQuotation.User, objclsQuotation.RenPolStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyHoldCover_InsertUpdate", "ExtendedPolicy");
        }
        public DataSet GetPolicyEndtSec1(clsAnnualPremSec1 objAnnSec1, string PolStatus)
        {
                object[] parameters = new object[] { objAnnSec1.PolicyId, objAnnSec1.PolVersionId, objAnnSec1.UWId, objAnnSec1.ID, objAnnSec1.CoverageType, PolStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtSec1_Select", "Pol_PolicyAnnPremSec1");

        }
        public DataSet GetPolicyEndtBilledSec1(clsAnnualPremSec1 objAnnSec1, string PolStatus)
        {
            object[] parameters = new object[] { objAnnSec1.PolicyId, objAnnSec1.PolVersionId, objAnnSec1.UWId, objAnnSec1.ID, objAnnSec1.CoverageType, PolStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtBilledSec1_Select", "Pol_PolicyAnnPremSec1");

        }

        public DataSet GetPolicyEndtSec2(clsAnnualPremSec2 objAnnSec2, string polStatus)
        {
            object[] parameters = new object[] { objAnnSec2.PolicyId, objAnnSec2.PolVersionId, objAnnSec2.UWId, objAnnSec2.ID, objAnnSec2.CoverageType, polStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtSec2_Select", "Pol_PolicyAnnPremSec2");

        }
        public DataSet GetPolicyEndtUnderwriterTotalPremiumId(clsPolicyUnderwriter objPolicyUnderwriter, string PolStatus)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID ,
                                                PolStatus
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_GetTotalPremiumByID_Endt", "GetTotalPremiumByID");

        }
        public DataSet GetPolicyEndtBilledUnderwriterTotalPremiumId(clsPolicyUnderwriter objPolicyUnderwriter, string PolStatus)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID ,
                                                PolStatus
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_GetTotalPremiumByID_PremBilled", "GetTotalPremiumByID");

        }
        public DataSet GetPolicyEndtUnderwriterDetailsTotalDue(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_TotalDue_Endt", "UnderwriterDue");
        }

        public DataSet GetPolicyEndtBilledUnderwriterDetailsTotalDue(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_TotalDue_EndtBilled", "UnderwriterDue");
        }

        public DataSet GetPolicyEndtPremBilledToDate(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID 
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyDetails_GetPremBilledToDate_Endt", "PremBilledToDate");

        }

        public DataSet SaveEndtSec1(long PolicyId, int PolVersionId, string xmlData, int UWId, string ID, string strCoverageType)
        {
            object[] parameters = new object[6] {   PolicyId,
                                                    PolVersionId,
                                                    xmlData,
                                                    UWId,   
                                                    ID,
                                                    strCoverageType
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtSec1_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveEndtSec2(long PolicyId, int PolVersionId, string xmlData, int UWId, int ID, string strCoverageType)
        {
            object[] parameters = new object[6] {PolicyId,
                                                PolVersionId,
                                                xmlData,
                                                UWId   ,   
                                                ID,
                                                strCoverageType};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtSec2_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveEndtPremiumUWDetail(long PolicyId, int PolVersionId, string xmlFile)
        {
            object[] parameters = new object[] { PolicyId, PolVersionId, xmlFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtUWTotalDue_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveEndtPremiumDetail(clsQuotation objclsQuotation, clsPolicyUnderwriter objUnderwriter, bool manualOverwrite)  //changed by megha to merge Aasai changes
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objUnderwriter.UWId, //added by megha to merge Aasai changes
                                                 objclsQuotation.TotalPremium,
                                                 objclsQuotation.AdditionalPremium,
                                                 objclsQuotation.ClientDiscount,
                                                 objclsQuotation.TotalSurcharge,
                                                 objclsQuotation.TotalPremiumSurcharge,
                                                 objclsQuotation.SpecialDiscount,
                                                 objclsQuotation.SpecialDiscountRate,
                                                 objclsQuotation.DueFromClient,
                                                 objclsQuotation.HandlingFeeAmount,
                                                 objclsQuotation.POIFromDate,
                                                 objclsQuotation.POIToDate,
                                                 objclsQuotation.User,
                                                 objUnderwriter.ID, //added by megha to merge Aasai changes
                                                manualOverwrite,
                                                objUnderwriter.TotalPremiumLAW,
                                                objUnderwriter.StDutyLAW,
                                                objUnderwriter.TaxTypeLAW,
                                                objUnderwriter.TaxLAW,
                                                objUnderwriter.SpDiscLAW,
                                                objUnderwriter.WHTPercentLAW,
                                                objUnderwriter.NetPayLAW,
                                                objUnderwriter.TaxLawrdb,
                                                objUnderwriter.StDutyLAWAmt,
                                                objUnderwriter.WHTAMT,
                                                objUnderwriter.NetPayClient,
                                                objUnderwriter.PolicyCharge,
                                                objUnderwriter.InsurerGSTPer,
                                                objUnderwriter.InsurerGSTPerId,
                                                objUnderwriter.InsurerGSTAmount ,
                                                objclsQuotation.ClientDiscountRate,
                                                objUnderwriter.ServiceFee,
                                                objUnderwriter.ServiceFeeGSTPer,
                                                objUnderwriter.ServiceFeeGSTPerId,
                                                objUnderwriter.ServiceFeeGSTAmount,
                                                objUnderwriter.StampDuty,
                                                objUnderwriter.NettPremium,
                                                objUnderwriter.NCDPer,
                                                objUnderwriter.NCDAmount,
                                                objUnderwriter.LoadingByInsurerPer,
                                                objUnderwriter.LoadingByInsurerAmt,
                                                objUnderwriter.DiscountByInsurerPer,
                                                objUnderwriter.DiscountByInsurerAmt

                                                 };
            dataAccessDS = new DataAccess();
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_PremiumDetails_InsertUpdate", "Pol_PolicyMaster");
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_EndtPremiumDetails_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet getPremiumHistory(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[2] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "Pol_Policy_HistoryPremiuarySummary", "PremiuarySummary");
        }
        public DataSet GetNonLeaderUW(long PolicyId, int PolVersionId, int leader, string strUWriterCode, string strUWriterName, string strSelectUwriterCode, string strUWriterShortName)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[7] { PolicyId, PolVersionId, leader, strUWriterCode, strUWriterName, strSelectUwriterCode, strUWriterShortName };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_NonLeaderUW_Select", "LoadUWriterList");
        }
        public DataSet GetPolicyUnderwriterDetailsTotalDueCNNo(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_TotalDue_NonLeader", "UnderwriterDue");
        }
        public DataSet getEndtPremiumSummary(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[3] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UWCoinsuranceApplicable };
            return dataAccessDS.LoadDataSet(parametes, "Pol_Policy_EndorsementPremiuarySummary", "PremiuarySummary");
        }
        public DataSet CancelEndorsement(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RefreshEndorsement", "CancelExtension");

        }
        public DataSet IsInsertedDiaryInfo(clsDiaryInfo objDiaryInfo)
        {
            object[] parameters = new object[] { //objDiaryInfo.DiaryId,
                                                objDiaryInfo.PolicyId, objDiaryInfo.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_DiaryInfo_IsInserted", "DiaryList");
        }
        public DataSet DeleteAllPremiumMultibilling(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] { 
                                                
                                                objclsRiskLocations.PolicyId, 
                                                objclsRiskLocations.PolVersionId 
                                                
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Premium_MultiBillingDetails_Delete", "DeleteAll");

        }
        public DataSet ConfirmCancelPolicy(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.Pol_Status };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_ConfirmPolicyCancellation", "CancelPolicy");

        }
        public DataSet IsInsertEndtData(clsAnnualPremSec1 objAnnSec1)
        {
            object[] parameters = new object[] { objAnnSec1.PolicyId, objAnnSec1.PolVersionId, objAnnSec1.UWId, objAnnSec1.ID, objAnnSec1.CoverageType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtData_IsInsert", "CancelPolicy");


        }
        public bool IsBillingComplete(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EndtData_IsInsert", "CancelPolicy");
            return Convert.ToBoolean(dataAccessDS.GetScalarValue(parameters, "P_Pol_PolicyBilling_IsComplete"));


        }
        public DataSet GetPolicyInfo(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.CoverNoteNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCNDetail_Select", "Pol_PolicyCNDetail");


        }
        public DataSet UpdateExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            object[] parametes = new object[] {
                                    objExcessDeductibleSummary.PolicyId, 
                                    objExcessDeductibleSummary.PolicyVerId, 
                                    objExcessDeductibleSummary.SubClassCode,
                                    objExcessDeductibleSummary.ID,
                                    objExcessDeductibleSummary.IsChecked,
                                    objExcessDeductibleSummary.Category,
                                    objExcessDeductibleSummary.Currency,
                                    objExcessDeductibleSummary.Amount,
                                    objExcessDeductibleSummary.Percentage,
                                    objExcessDeductibleSummary.Basis,
                                    objExcessDeductibleSummary.UserId
                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_ExcessDeductible_InsertUpdate", "ExcessDeductibleInsertUpdate");
        }
        public DataSet GetExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            object[] parametes = new object[] {
                                    objExcessDeductibleSummary.PolicyId, 
                                    objExcessDeductibleSummary.PolicyVerId, 
                                    objExcessDeductibleSummary.SubClassCode
                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_ExcessDeductible_GetData", "ExcessDeductiblegetData");
        }
        public DataSet GetCoverNotePolicyDetails(string policyNo)
        {
            object[] parameters = new object[] { policyNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "GetmasterPolicydetails", "CoverNoteDtl");
        }
        public DataSet DeleteExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            object[] parametes = new object[] 
            {
                                    objExcessDeductibleSummary.PolicyId, 
                                    objExcessDeductibleSummary.PolicyVerId, 
                                    objExcessDeductibleSummary.SubClassCode,
                                    objExcessDeductibleSummary.ID
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_ExcessDeductible_DeleteById", "DeleteById");
        }
    }
}
