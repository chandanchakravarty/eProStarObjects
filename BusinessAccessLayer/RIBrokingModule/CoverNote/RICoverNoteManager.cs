using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.CoverNote;
//using BusinessObjectLayer.BrokingModule.BrokingSystem;
//using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using System.Data.SqlClient;

namespace BusinessAccessLayer.RIBrokingModule.CoverNote
{
    
    public class RICoverNoteManager
    {
        DataAccess dataAccess = new DataAccess();

        public DataSet GeneralInfoLoadInitialValues()
        {
            Object[] parametes = new Object[0];
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_LoadInitialValues", "LoadInitialValues");
        }  
        public DataSet LoadSubClass(string strMainClass)
        {
            Object[] parametes = new Object[1] {strMainClass};
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_LoadSubClass", "LoadSubClass");
        }

        public DataSet GetCoverNoteDetails(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            object[] parameters = new object[] { objRICNGeneralInformation.CoverNoteNo, objRICNGeneralInformation.TranRefNo };
            return dataAccess.LoadDataSet(parameters, "P_RICN_GetPolicyStatus", "PolicyStatus");
        }

        public DataSet CancelPolicyStatus(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            object[] parameters = new object[] { objRICNGeneralInformation.CoverNoteNo, objRICNGeneralInformation.TranRefNo, objRICNGeneralInformation.CoverNoteStatus};
            return dataAccess.LoadDataSet(parameters, "P_RICN_Cancel_RenewalRecord", "CancelPolicy");
        }

        public DataSet GetPopSerachData(ClsRICNPopUp objClsRICNPopUp)
        {
            Object[] parametes = new Object[] { 
                                objClsRICNPopUp.Code,   
                                objClsRICNPopUp.Name, 
                                objClsRICNPopUp.Type ,
                                objClsRICNPopUp.MainClass, 
                                objClsRICNPopUp.SubClass, 
                                objClsRICNPopUp.Province, 
                                objClsRICNPopUp.TranRefNo 
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_GetPopupSearchData", "GetPopupSearchData");
        }
        //

        public DataSet GetPopSearchDataForEnquiry(ClsRICNPopUp objClsRICNPopUp)
        {
            Object[] parametes = new Object[] { 
                                objClsRICNPopUp.Code,   
                                objClsRICNPopUp.Name, 
                                objClsRICNPopUp.Type ,
                                objClsRICNPopUp.MainClass, 
                                objClsRICNPopUp.SubClass, 
                                objClsRICNPopUp.Province, 
                                objClsRICNPopUp.TranRefNo 
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_CedantInfo_GetPopupSearchData", "GetPopupSearchData");
        }


        public DataSet GetSourceCodeByClientID(string strCode)
        {
            Object[] parametes = new Object[1] { strCode};
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_GetSourceCodeByClientID", "GetSourceCodeByClientID");
        }

        public DataSet SaveGeneralInformation(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[] 
            {  
                objRICNGeneralInformation.TranRefNo,
                objRICNGeneralInformation.CoverNoteNo,
                objRICNGeneralInformation.MainClass,
                objRICNGeneralInformation.Fail,
                objRICNGeneralInformation.Void,
                objRICNGeneralInformation.PeriodFrom,
                objRICNGeneralInformation.PeriodTo,
                objRICNGeneralInformation.PeriodFromHours,
                objRICNGeneralInformation.PeriodFromMins,
                objRICNGeneralInformation.PeriodToHours,
                objRICNGeneralInformation.PeriodToMins,
                objRICNGeneralInformation.POIBDI,
                objRICNGeneralInformation.RetroactiveDate,
                objRICNGeneralInformation.ReinsuranceFrom,
                objRICNGeneralInformation.ReinsuranceTo,
                objRICNGeneralInformation.RIBDI,
                objRICNGeneralInformation.TestingFrom,
                objRICNGeneralInformation.TestingTo,
                 objRICNGeneralInformation.ExtensionFrom,
                objRICNGeneralInformation.ExtensionTo,
                objRICNGeneralInformation.MaintenanceFrom,
                objRICNGeneralInformation.MaintenanceTo,
                objRICNGeneralInformation.MaintHours,
                objRICNGeneralInformation.Maint,
                objRICNGeneralInformation.IssueDate,
                objRICNGeneralInformation.FollowupDate,
                objRICNGeneralInformation.FollowUpReason,
                objRICNGeneralInformation.FollowUpStatus,
                objRICNGeneralInformation.CedantCode,
                objRICNGeneralInformation.CedantName,
                objRICNGeneralInformation.CedantRefNo,
                objRICNGeneralInformation.ReinsuredCode,
                objRICNGeneralInformation.ReinsuredName,
                objRICNGeneralInformation.PolicyNo,
                objRICNGeneralInformation.NWIRefNo,
                objRICNGeneralInformation.Project,
                objRICNGeneralInformation.Business,
                objRICNGeneralInformation.Territory,
                objRICNGeneralInformation.Form,
                objRICNGeneralInformation.Currency,
                objRICNGeneralInformation.Handler,
                objRICNGeneralInformation.CoverNotetype,
                objRICNGeneralInformation.CoverNoteStatus,
                objRICNGeneralInformation.Summary,
                objRICNGeneralInformation.MarketMode,
                objRICNGeneralInformation.Basis,
                objRICNGeneralInformation.UserId,
                objRICNGeneralInformation.SelectedSubClass,
                objRICNGeneralInformation.SelectedInsured,
                objRICNGeneralInformation.IsRISlip,
                //objRICNGeneralInformation.Purpose,
                objRICNGeneralInformation.PPW,
                objRICNGeneralInformation.IsRetro,
                objRICNGeneralInformation.SourceCNNumber
            };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_InsertUpdate", "GenInfoInsertUpdate");
        }

        public DataSet GetRenewalLetterInfo(ClsRICNGeneralInformation objClsRICNGeneralInformation, int UserId)
        {
            object[] parameters = new object[] { objClsRICNGeneralInformation.CoverNoteNo, objClsRICNGeneralInformation.TranRefNo, UserId };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Policy_RenewalLetterInfo_Select_RI", "RenewalLetterList_RI");
        }

        public DataSet SaveGeneralInformation_Endorse(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[] 
            {  
                objRICNGeneralInformation.TranRefNo,
                objRICNGeneralInformation.CoverNoteNo,
                objRICNGeneralInformation.MainClass,
                objRICNGeneralInformation.Fail,
                objRICNGeneralInformation.Void,
                objRICNGeneralInformation.PeriodFrom,
                objRICNGeneralInformation.PeriodTo,
                objRICNGeneralInformation.PeriodFromHours,
                objRICNGeneralInformation.PeriodFromMins,
                objRICNGeneralInformation.PeriodToHours,
                objRICNGeneralInformation.PeriodToMins,
                objRICNGeneralInformation.POIBDI,
                objRICNGeneralInformation.RetroactiveDate,
                objRICNGeneralInformation.ReinsuranceFrom,
                objRICNGeneralInformation.ReinsuranceTo,
                objRICNGeneralInformation.RIBDI,
                objRICNGeneralInformation.TestingFrom,
                objRICNGeneralInformation.TestingTo,
                 objRICNGeneralInformation.ExtensionFrom,
                objRICNGeneralInformation.ExtensionTo,
                objRICNGeneralInformation.MaintenanceFrom,
                objRICNGeneralInformation.MaintenanceTo,
                objRICNGeneralInformation.MaintHours,
                objRICNGeneralInformation.Maint,
                objRICNGeneralInformation.IssueDate,
                objRICNGeneralInformation.FollowupDate,
                objRICNGeneralInformation.FollowUpReason,
                objRICNGeneralInformation.FollowUpStatus,
                objRICNGeneralInformation.CedantCode,
                objRICNGeneralInformation.CedantName,
                objRICNGeneralInformation.CedantRefNo,
                objRICNGeneralInformation.ReinsuredCode,
                objRICNGeneralInformation.ReinsuredName,
                objRICNGeneralInformation.PolicyNo,
                objRICNGeneralInformation.NWIRefNo,
                objRICNGeneralInformation.Project,
                objRICNGeneralInformation.Business,
                objRICNGeneralInformation.Territory,
                objRICNGeneralInformation.Form,
                objRICNGeneralInformation.Currency,
                objRICNGeneralInformation.Handler,
                objRICNGeneralInformation.CoverNotetype,
                objRICNGeneralInformation.CoverNoteStatus,
                objRICNGeneralInformation.Summary,
                objRICNGeneralInformation.MarketMode,
                objRICNGeneralInformation.Basis,
                objRICNGeneralInformation.UserId,
                objRICNGeneralInformation.SelectedSubClass,
                objRICNGeneralInformation.SelectedInsured,
                objRICNGeneralInformation.IsRISlip,
                objRICNGeneralInformation.Purpose,
                objRICNGeneralInformation.EndorseEffFromDate,
                objRICNGeneralInformation.RenStatus,
                objRICNGeneralInformation.PPW,
                objRICNGeneralInformation.IsRetro
            };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_InsertUpdate_Endorse", "GenInfoInsertUpdate");
        }

        public DataSet LapsedInvitedRenewal(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[] 
            {  
                objRICNGeneralInformation.TranRefNo,
                objRICNGeneralInformation.CoverNoteNo,
                objRICNGeneralInformation.MainClass,
                objRICNGeneralInformation.Fail,
                objRICNGeneralInformation.Void,
                objRICNGeneralInformation.PeriodFrom,
                objRICNGeneralInformation.PeriodTo,
                objRICNGeneralInformation.PeriodFromHours,
                objRICNGeneralInformation.PeriodFromMins,
                objRICNGeneralInformation.PeriodToHours,
                objRICNGeneralInformation.PeriodToMins,
                objRICNGeneralInformation.POIBDI,
                objRICNGeneralInformation.RetroactiveDate,
                objRICNGeneralInformation.ReinsuranceFrom,
                objRICNGeneralInformation.ReinsuranceTo,
                objRICNGeneralInformation.RIBDI,
                objRICNGeneralInformation.TestingFrom,
                objRICNGeneralInformation.TestingTo,
                objRICNGeneralInformation.ExtensionFrom,
                objRICNGeneralInformation.ExtensionTo,
                objRICNGeneralInformation.MaintenanceFrom,
                objRICNGeneralInformation.MaintenanceTo,
                objRICNGeneralInformation.MaintHours,
                objRICNGeneralInformation.Maint,
                objRICNGeneralInformation.IssueDate,
                objRICNGeneralInformation.FollowupDate,
                objRICNGeneralInformation.FollowUpReason,
                objRICNGeneralInformation.FollowUpStatus,
                objRICNGeneralInformation.CedantCode,
                objRICNGeneralInformation.CedantName,
                objRICNGeneralInformation.CedantRefNo,
                objRICNGeneralInformation.ReinsuredCode,
                objRICNGeneralInformation.ReinsuredName,
                objRICNGeneralInformation.PolicyNo,
                objRICNGeneralInformation.NWIRefNo,
                objRICNGeneralInformation.Project,
                objRICNGeneralInformation.Business,
                objRICNGeneralInformation.Territory,
                objRICNGeneralInformation.Form,
                objRICNGeneralInformation.Currency,
                objRICNGeneralInformation.Handler,
                objRICNGeneralInformation.CoverNotetype,
                objRICNGeneralInformation.CoverNoteStatus,
                objRICNGeneralInformation.Summary,
                objRICNGeneralInformation.MarketMode,
                objRICNGeneralInformation.Basis,
                objRICNGeneralInformation.UserId,
                objRICNGeneralInformation.SelectedSubClass,
                objRICNGeneralInformation.SelectedInsured,
                objRICNGeneralInformation.IsRISlip,
                objRICNGeneralInformation.Purpose,
                objRICNGeneralInformation.EndorseEffFromDate,
                objRICNGeneralInformation.RenStatus
            };
            return dataAccess.LoadDataSet(parametes, "P_RICN_LapsedInvitedRenewal", "GenInfoInsertUpdate");
        }

        public DataSet GetCoverNoteGeneralInformation(string strCode, string StrPurpose, string strTranRefNo)
        {
            Object[] parametes = new Object[3] { strCode, StrPurpose, strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_GetData", "GenInfoGetData");
        }
        public DataSet GetRIRefNoInformation(string strTranRefNo)
        {
            Object[] parametes = new Object[] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenRIRefNoInfo_GetData", "GenRIInfoGetData");
        }

        public DataSet GetCovernoteRetrocessionData(string strCode,  string strTranRefNo)
        {
            Object[] parametes = new Object[2] { strCode,  strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RI_Retrocession_GetData", "GenRetroGetData");
        }

        public DataSet  GetRICNPrintCoverNoteData(string CoverNoteNo, string strTranRefNo)
        {
            Object[] parametes = new Object[2] { CoverNoteNo, strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PrintCoverNoteData_Select", "PrintRICNGetData");
        }

        public DataSet GetOutStaningRenewalGeneralInformation(string strCode, string StrPurpose, string strTranRefNo)
        {
            Object[] parametes = new Object[3] { strCode, StrPurpose, strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_GetData_OutStaningRenewal", "GenInfoGetData");
        }

        public DataSet MaintainCoverNoteGeneralSubClass(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[5] 
                                {  
                                objRICNGeneralInformation.MaintainType,
                                objRICNGeneralInformation.TranRefNo,   
                                objRICNGeneralInformation.CoverNoteNo, 
                                objRICNGeneralInformation.SubClassCode,
                                objRICNGeneralInformation.SubClassName
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_MaintaniSubClass", "MaintaniSubClass");
        }

        public DataSet MaintainCoverNoteGeneralCopyRISlipInfo(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[1] 
                                {  
                                objRICNGeneralInformation.CoverNoteNo
                                };
            return dataAccess.LoadDataSet(parametes, "P_pol_Policy_RIModule_RISlip_CopyDefault", "MaintainCoverNoteGeneralCopyRISlipInfo");
        }

        public DataSet MaintainCoverNoteGeneralInsured(ClsRICNGeneralInformation objRICNGeneralInformation)
        {
            Object[] parametes = new Object[5] 
                                {  
                                objRICNGeneralInformation.MaintainType,
                                objRICNGeneralInformation.TranRefNo,   
                                objRICNGeneralInformation.CoverNoteNo, 
                                objRICNGeneralInformation.ClientCode,
                                objRICNGeneralInformation.ClientName
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_MaintainInsurer", "MaintainInsurer");
        }

        public DataSet CoverageLoadInitialValues(string strReferenceCode, string strCoverNoteNo)
        {
            Object[] parametes = new Object[2] { strReferenceCode, strCoverNoteNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_LoadInitialValues", "LoadInitialValues");
        }
        public DataSet RICoverageLoadInitialValues(string strReferenceCode, string strCoverNoteNo,int classid, int subclassid)
        {
            Object[] parametes = new Object[4] { strReferenceCode, strCoverNoteNo,classid,subclassid  };
            return dataAccess.LoadDataSet(parametes, "P_RI_SlipUWCoverage_SelectByClassAndSubClass", "TemplateDetail");
        }
        public DataSet GetCoverageIntersetInsured(clsRICNCoverage objClsRICNCoverage)
        {
            Object[] parametes = new Object[] {
                                    objClsRICNCoverage.TranRefNo, 
                                    objClsRICNCoverage.MainClass, 
                                    objClsRICNCoverage.SubClassCode,
                                    objClsRICNCoverage.Mode,
                                    objClsRICNCoverage.Id
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_GetIntInsured", "IntInsured");
        }

        public DataSet SaveCoverage(clsRICNCoverage objClsRICNCoverage)
        {
            Object[] parametes = new Object[] {
                                    objClsRICNCoverage.TranRefNo, 
                                    objClsRICNCoverage.GeographicalLimit, 
                                    objClsRICNCoverage.TradingLimit,
                                    objClsRICNCoverage.ByAir,
                                    objClsRICNCoverage.PerLand,
                                    objClsRICNCoverage.PerWater,
                                    objClsRICNCoverage.Voyage,
                                    objClsRICNCoverage.Earthquake,
                                    objClsRICNCoverage.SRCC,
                                    objClsRICNCoverage.Thyphoon,
                                    objClsRICNCoverage.Terrorism,
                                    objClsRICNCoverage.LoginUserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_InsertUpdate", "InsertUpdate");
        }

        public DataSet GetCoverageDetails(string strTranRefNo)
        {
            Object[] parametes = new Object[] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_GetData", "GetData");
        }

        public DataSet UpdateJurisdiction(string strTranRefNo, string strJurisdiction, int intSubClassCode, string strCoverage)
        {
            Object[] parametes = new Object[] { strTranRefNo, strJurisdiction, intSubClassCode, strCoverage };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_UpdateJurisdiction", "UpdateJurisdiction");
        }

        public DataSet UpdateIntersetInsured(clsRICNCoverage objClsRICNCoverage)
        {
            Object[] parametes = new Object[] {
                                    objClsRICNCoverage.TranRefNo, 
                                    objClsRICNCoverage.MainClass, 
                                    objClsRICNCoverage.SubClassCode,
                                    objClsRICNCoverage.Id,
                                    objClsRICNCoverage.Category,
                                    objClsRICNCoverage.Description
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Coverage_IntInsuredUpdate", "IntInsuredUpdate");
        }

        public DataSet GetLocationItems(ClsRICNLocationItems objClsRICNLocationItems)
        {
            Object[] parametes = new Object[] {
                                    objClsRICNLocationItems.TranRefNo, 
                                    objClsRICNLocationItems.MainClass, 
                                    objClsRICNLocationItems.SubClassCode,
                                    objClsRICNLocationItems.Mode,
                                    objClsRICNLocationItems.LocatioId,
                                    objClsRICNLocationItems.UserId

                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_LocationItem_GetLocationItems", "LocationItems");
        }
        public DataSet UpdateLocationItems(ClsRICNLocationItems objClsRICNLocationItems)
        {
            Object[] parametes = new Object[] {
                                    objClsRICNLocationItems.TranRefNo, 
                                    objClsRICNLocationItems.MainClass, 
                                    objClsRICNLocationItems.SubClassCode,
                                    objClsRICNLocationItems.LocatioId,
                                    objClsRICNLocationItems.LocationItem,
                                    objClsRICNLocationItems.Description,
                                    objClsRICNLocationItems.Province,
                                    objClsRICNLocationItems.Country,
                                    objClsRICNLocationItems.TSI,
                                    objClsRICNLocationItems.Currency,
                                    objClsRICNLocationItems.TSIOrgCurrency,
                                    objClsRICNLocationItems.UserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RICN_LocationItem_UpdateLocationItems", "UpdateLocationItems");
        }
        public DataSet GetTSILimitSummary(ClsTSILimitSummary ClsTSILimitSummary)
        {
            Object[] parametes = new Object[] {
                                    ClsTSILimitSummary.TranRefNo, 
                                    ClsTSILimitSummary.MainClass, 
                                    ClsTSILimitSummary.SubClassCode,
                                    ClsTSILimitSummary.UserId,
                                    ClsTSILimitSummary.IsClosingSlip,
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_GetSummary", "GetSummary");
        }
        public DataSet GetTSISubLimitSummary(string strCode)
        {
            Object[] parametes = new Object[] { strCode };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSISubLimit_GetSummary", "GetSubLimitSummary");
        }

        public DataSet UpdateTSILimitSummary(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] {
                                    objClsTSILimitSummary.TranRefNo, 
                                    objClsTSILimitSummary.MainClass, 
                                    objClsTSILimitSummary.SubClassCode,
                                    objClsTSILimitSummary.ID,
                                    objClsTSILimitSummary.SumInsured,
                                    objClsTSILimitSummary.DeclaredValue,
                                    objClsTSILimitSummary.LoadingDiscount,
                                    objClsTSILimitSummary.Premium,
                                    objClsTSILimitSummary.UserId,
                                    objClsTSILimitSummary.SumInsuredUpdated,
                                    objClsTSILimitSummary.SumInsuredEndt,
                                    objClsTSILimitSummary.SumInsuredLast,
                                    objClsTSILimitSummary.ReInsurerSharePercent,
                                    objClsTSILimitSummary.ReInsurerShareAmt,
                                    objClsTSILimitSummary.ExRate,
                                    objClsTSILimitSummary.SumInsuredLC,
                                    objClsTSILimitSummary.OriginalPremiumOC,
                                    objClsTSILimitSummary.CedantShare,
                                    objClsTSILimitSummary.CedantSumInsuredAmtOC,
                                    objClsTSILimitSummary.CedantSumInsuredAmtLC,
                                    objClsTSILimitSummary.PlacementPer,
                                    objClsTSILimitSummary.PlacementSumInsuredOC,
                                    objClsTSILimitSummary.PlacementSumInsuredLC,
                                     objClsTSILimitSummary.PlacementPreiumOC,
                                    objClsTSILimitSummary.PlacementPreiumLC

                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_UpdateTSILimitSummary", "UpdateSummary");
        }

        public DataSet Get_RI_PremiumDetailsBySubClass(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.ID };
            return dataAccess.LoadDataSet(parametes, "RI_GetSubClassPremiumDetails", "RI_PremiumDetailsSubClassWise");
        }

        public DataSet Get_RI_PremiumInstallmentDetails(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.ID , objClsTSILimitSummary.CurrencyType};
            return dataAccess.LoadDataSet(parametes, "RI_GetIntallmentDetailsCedent", "RI_PremiumDetailsSubClassWise");
        }

        public DataSet SAVE_RI_PremiumDetailsBySubClass(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.XMLData,objClsTSILimitSummary.IsInstallment, objClsTSILimitSummary.NoOfInstallment, objClsTSILimitSummary.UserId };

            return dataAccess.LoadDataSet(parametes, "RI_SAVESubClassPremiumDetails", "RI_IntallmentDetailsCedent");
        }

        public DataSet Get_RI_PremiumDetailsBySubClassInsurer(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.ID };
            return dataAccess.LoadDataSet(parametes, "RI_GetSubClassPremiumDetailsInsurer", "RI_InsPremDetailsSubClassWise");
        }

        public DataSet Get_RI_PremiumInstallmentDetailsInsurer(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.ID, objClsTSILimitSummary.CurrencyType };
            return dataAccess.LoadDataSet(parametes, "RI_GetIntallmentDetailsInsurer", "RI_InsPremDetailsSubClassWise");
        }

        public DataSet SAVE_RI_PremiumDetailsBySubClassInsurer(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.XMLData, objClsTSILimitSummary.IsInstallment, objClsTSILimitSummary.NoOfInstallment, objClsTSILimitSummary.UserId };

            return dataAccess.LoadDataSet(parametes, "RI_SAVESubClassPremiumDetailsInsurer", "RI_IntallmentDetailsInsurer");
        }

        public DataSet Get_RI_PremiumDetailsBySubClassConsolidate(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] { objClsTSILimitSummary.TranRefNo };
            return dataAccess.LoadDataSet(parametes, "RI_GetSubClassPremiumDetailsConsolidate", "RI_PremiumDetailsSubClassWise");
        }
       
         

        public DataSet UpdateTSILimitPremiumSummarySubTotal(string strTranRefNo)
        {
            Object[] parametes = new Object[] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_UpdatePremiumSummarySubTotal", "UpdatePremiumSummarySubTotal");
        }

        
        public DataSet UpdateTSISubLimitSummary(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] {
                                    objClsTSILimitSummary.TranRefNo, 
                                    objClsTSILimitSummary.Currency,
                                    objClsTSILimitSummary.EQSumInsured,
                                    objClsTSILimitSummary.EQPercentage,
                                    objClsTSILimitSummary.SRCCSumInsured,
                                    objClsTSILimitSummary.SRCCPercentage,
                                    objClsTSILimitSummary.TerrorismSumInsured,
                                    objClsTSILimitSummary.TerrorismPercentage,
                                    objClsTSILimitSummary.TyphoonSumInsured,
                                    objClsTSILimitSummary.TyphoonPercentage,
                                    objClsTSILimitSummary.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_UpdateTSISubLimitSummary", "UpdateSubLimitSummary");
        }
        public DataSet UpdateTSILimitOfLiablity(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] {
                                    objClsTSILimitSummary.TranRefNo, 
                                    objClsTSILimitSummary.ID,
                                    objClsTSILimitSummary.Description,
                                    objClsTSILimitSummary.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_UpdateTSILimitOfLiablity", "TSILimitOfLiablity");
        }
        public DataSet DeleteTSILimitOfLiablity(ClsTSILimitSummary objClsTSILimitSummary)
        {
            Object[] parametes = new Object[] {
                                    objClsTSILimitSummary.TranRefNo, 
                                    objClsTSILimitSummary.ID
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_TSILimit_DeleteTSILimitOfLiablity", "DeleteTSILimitOfLiablity");
        }
        public DataSet UpdateExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            Object[] parametes = new Object[] {
                                    objExcessDeductibleSummary.TranRefNo, 
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
            return dataAccess.LoadDataSet(parametes, "P_RICN_ExcessDeductible_InsertUpdate", "ExcessDeductibleInsertUpdate");
        }
        public DataSet GetExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            Object[] parametes = new Object[] {
                                    objExcessDeductibleSummary.TranRefNo, 
                                    objExcessDeductibleSummary.SubClassCode
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_ExcessDeductible_GetData", "ExcessDeductiblegetData");
        }
        public DataSet DeleteExcessDeductibleSummary(ClsExcessDeductibleSummary objExcessDeductibleSummary)
        {
            Object[] parametes = new Object[] {
                                    objExcessDeductibleSummary.TranRefNo, 
                                    objExcessDeductibleSummary.SubClassCode,
                                    objExcessDeductibleSummary.ID
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_ExcessDeductible_DeleteById", "DeleteById");
        }

        public DataSet UpdateConditions(ClsConditions objConditions)
        {
            Object[] parametes = new Object[] {
                                    objConditions.TranRefNo, 
                                    objConditions.SubClassCode,
                                    objConditions.ID,
                                    objConditions.IsChecked,
                                    objConditions.Clause,
                                    objConditions.Limit,
                                    objConditions.Percentage,
                                    objConditions.ClauseType,
                                    objConditions.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Conditions_InsertUpdate", "ExcessDeductibleInsertUpdate");
        }

        public DataSet RIUpdateConditions(ClsConditions objConditions)
        {
            Object[] parametes = new Object[] {                                    
                                    objConditions.ID,
                                    objConditions.TranRefNo, 
                                    objConditions.CoverNoteNo, 
                                    objConditions.MainClassId,    
                                    objConditions.SubClassCode,                                    
                                    objConditions.frmfor,
                                    objConditions.MainHeader,
                                    objConditions.TitleDescription,
                                    objConditions.UserId,
                                    objConditions.HeaderID,
                                    objConditions.PrintOrder
                                };
            return dataAccess.LoadDataSet(parametes, "P_RI_Conditions_MajEx_Warranty_InsertUpdate", "ExcessDeductibleInsertUpdate");
        }

        public DataSet GetConditions(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.SubClassCode
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Conditions_GetData", "ConditionsGetData");
        }
        public DataSet RIGetConditions(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.SubClassCode,
                                    objClsConditions.frmfor
                                };
            return dataAccess.LoadDataSet(parametes, "P_RI_Conditions_MajEx_Warranty_GetData", "ConditionsGetData");
        }
        public DataSet LoadRiskHeader(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.MainClassId, 
                                    objClsConditions.SubClassCode, 
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.CoverNoteNo,                                    
                                    objClsConditions.frmfor   
                                };
            return dataAccess.LoadDataSet(parametes, "RI_CN_PolicyUWCovDetails_Header_Mapping_Select", "ConditionsGetData");
        }
        public DataSet SearchRiskHeader(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.MainClassId, 
                                    objClsConditions.SubClassCode, 
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.CoverNoteNo,                                    
                                    objClsConditions.frmfor,
                                      objClsConditions.MainHeader,
                            objClsConditions.TitleDescription };
            return dataAccess.LoadDataSet(parametes, "RI_CN_PolicyUWCovDetails_Header_Mapping_SearchData", "ConditionsGetData");
        }
        public DataSet CWERecordsWithHeaderDesc(string TransRefNo,string CoverNoteNo,string frmfor,int ClassId,int SubClassId,string SrchVal,string SrchCond)
        {
            Object[] parametes = new Object[] {
                                    TransRefNo, 
                                    CoverNoteNo, 
                                    frmfor, 
                                    ClassId,
                                    SubClassId,
                                    SrchVal,                                    
                                    SrchCond
                                };
            return dataAccess.LoadDataSet(parametes, "CWERecordsWithHeaderDesc", "CWERecords");
        }
        public DataSet DeleteConditins(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.SubClassCode,
                                    objClsConditions.ID
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Condition_DeleteById", "ConditionDeleteById");
        }
        public DataSet RIDeleteConditins(ClsConditions objClsConditions)
        {
            Object[] parametes = new Object[] {
                                    objClsConditions.TranRefNo, 
                                    objClsConditions.CoverNoteNo, 
                                    objClsConditions.MainClassId,
                                    objClsConditions.SubClassCode,
                                    objClsConditions.frmfor,
                                    objClsConditions.HeaderID
                                };
            return dataAccess.LoadDataSet(parametes, "P_RI_Condition__MajEx_WarrantyDeleteById", "ConditionDeleteById");
        }
        public DataSet GetPremiumBySubClass(ClsMarket objClsMarket)
        {
            Object[] parametes = new Object[] {
                                    objClsMarket.TranRefNo, 
                                    objClsMarket.SubClassCode
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Market_GetPremiumBySubClass", "GetPremiumBySubClass");
        }
        public DataSet UpdateMarket(ClsMarket objMarket)
        {
            Object[] parametes = new Object[] {
                                    objMarket.TranRefNo, 
                                    objMarket.SubClassCode,
                                    objMarket.ID,
                                    objMarket.Prefix,
                                    objMarket.Code,
                                    objMarket.FullName,
                                    objMarket.ReinsurerName,
                                    objMarket.LineSlip,
                                    objMarket.Share,
                                    objMarket.Currency,
                                    objMarket.Amount,
                                    objMarket.TotalDeduction,
                                    objMarket.RefNo,
                                    objMarket.Remarks,
                                    objMarket.UserId,
                                    objMarket.AmountLast,
                                    objMarket.AmountEndt,
                                    objMarket.PremiumRate,
                                    objMarket.Premium,
                                    objMarket.DirectCommRate,
                                    objMarket.DirectComm,
                                    objMarket.RICommRate,
                                    objMarket.RIComm,
                                    objMarket.ForeignLocal,
                                    objMarket.Leader,
                                    objMarket.Brokerage,
                                    objMarket.NetDue,
                                    objMarket.IsBroker,
                                    objMarket.IsClosingSlip,
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Market_InsertUpdate", "MarketInsertUpdate");
        }
        public DataSet GetMarket(ClsMarket objMarket)
        {
            Object[] parametes = new Object[] {
                                    objMarket.TranRefNo, 
                                    objMarket.SubClassCode
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Market_GetData", "MarketGetData");
        }
        public DataSet DeleteMarket(ClsMarket objMarket)
        {
            Object[] parametes = new Object[] {
                                    objMarket.TranRefNo, 
                                    objMarket.SubClassCode,
                                    objMarket.ID
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Market_DeleteById", "MarketDeleteById");
        }
        public DataSet ApplyMarket(ClsMarket objMarket)
        {
            Object[] parametes = new Object[] {
                                    objMarket.TranRefNo, 
                                    objMarket.SubClassCode,
                                    objMarket.Prefix,
                                    objMarket.Code,
                                    objMarket.FullName,
                                    objMarket.ReinsurerName,
                                    objMarket.LineSlip,
                                    objMarket.Share,
                                    objMarket.TotalDeduction,
                                    objMarket.RefNo,
                                    objMarket.Remarks,
                                    objMarket.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Market_ApplyInsert", "MarketApplyInsert");
        }
        public DataSet PremiumSummaryGetList(string strTranRefNo)
        {
            Object[] parametes = new Object[] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummarySubTotal_GetList", "GetList");
        }
        public DataSet PremiumSummaryGetSummary(ClsPremiumSummarySubTotal ObjPremiumSummarySubTotal)
        {
            Object[] parametes = new Object[] { ObjPremiumSummarySubTotal.TranRefNo, ObjPremiumSummarySubTotal.Code, ObjPremiumSummarySubTotal.UserId };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummarySubTotal_GetSummary", "GetSummary");
        }
        public DataSet PremiumSummaryAppy(ClsPremiumSummarySubTotal ObjPremiumSummarySubTotal)
        {
            Object[] parametes = new Object[] { 
                                    ObjPremiumSummarySubTotal.TranRefNo, 
                                    ObjPremiumSummarySubTotal.TotalDays, 
                                    ObjPremiumSummarySubTotal.ProrataDays
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_Apply", "Apply");
        }
        public DataSet PremiumSummaryUpdateReinsuerDetails(ClsPremiumSummarySubTotal ObjPremiumSummarySubTotal)
        {
            Object[] parametes = new Object[] { 
                                    ObjPremiumSummarySubTotal.TranRefNo, 
                                    ObjPremiumSummarySubTotal.SubClassCode, 
                                    ObjPremiumSummarySubTotal.ID,
                                    ObjPremiumSummarySubTotal.Code,
                                    ObjPremiumSummarySubTotal.RIRate,
                                    ObjPremiumSummarySubTotal.RIPremium,
                                    ObjPremiumSummarySubTotal.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_UpdatePremiumDetails", "UpdatePremiumDetails");
        }
        public DataSet PremiumSummaryUpdateClientDetails(ClsPremiumSummarySubTotal ObjPremiumSummarySubTotal)
        {
            Object[] parametes = new Object[] { 
                                    ObjPremiumSummarySubTotal.TranRefNo, 
                                    ObjPremiumSummarySubTotal.SubClassCode, 
                                    ObjPremiumSummarySubTotal.ID, 
                                    ObjPremiumSummarySubTotal.Code, 
                                    ObjPremiumSummarySubTotal.Rate,
                                    ObjPremiumSummarySubTotal.CalcPremium,
                                    ObjPremiumSummarySubTotal.SharePremium,
                                    ObjPremiumSummarySubTotal.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_UpdateClientPremiumDetails", "UpdatePremiumDetails");
        }
        public DataSet PremiumSummaryUpdateAdditionalRiskDetails(ClsPremiumSummarySubTotal ObjPremiumSummarySubTotal)
        {
            Object[] parametes = new Object[] { 
                                    ObjPremiumSummarySubTotal.TranRefNo, 
                                    ObjPremiumSummarySubTotal.ID, 
                                    ObjPremiumSummarySubTotal.SumInsured,
                                    ObjPremiumSummarySubTotal.Rate,
                                    ObjPremiumSummarySubTotal.CalcPremium,
                                    ObjPremiumSummarySubTotal.SharePremium,
                                    ObjPremiumSummarySubTotal.RIRate,
                                    ObjPremiumSummarySubTotal.RIPremium,
                                    ObjPremiumSummarySubTotal.UserId

                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_UpdateAdditionalRiskDetails", "UpdatePremiumDetails");
        }
        public DataSet PremiumSummaryGetTotal(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[] { ObjPremiumSummaryTotal.TranRefNo, ObjPremiumSummaryTotal.UserId };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_GetTotal", "GetTotal");
        }
        public DataSet PremiumSummaryUpdate(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[] { ObjPremiumSummaryTotal.TranRefNo, 
                                                ObjPremiumSummaryTotal.TotalPremium,
                                                ObjPremiumSummaryTotal.Amount,
                                                ObjPremiumSummaryTotal.DepositFollowUpDate,
                                                ObjPremiumSummaryTotal.Installments,
                                                ObjPremiumSummaryTotal.DirectBrokerage,
                                                ObjPremiumSummaryTotal.LongTermAggreement,
                                                ObjPremiumSummaryTotal.PremiumReserve,
                                                ObjPremiumSummaryTotal.RICommission,
                                                ObjPremiumSummaryTotal.ProfitCommision,
                                                ObjPremiumSummaryTotal.TotalRICommision,
                                                ObjPremiumSummaryTotal.TotalEarning ,
                                                ObjPremiumSummaryTotal.IRMBrokerage ,
                                                ObjPremiumSummaryTotal.ReferalCode1 ,
                                                ObjPremiumSummaryTotal.ReferalName1 ,
                                                ObjPremiumSummaryTotal.ReferalPercentage1,
                                                ObjPremiumSummaryTotal.ReferalType1,
                                                ObjPremiumSummaryTotal.ReferalAmount1,
                                                ObjPremiumSummaryTotal.ReferalCode2,
                                                ObjPremiumSummaryTotal.ReferalName2,
                                                ObjPremiumSummaryTotal.ReferalPercentage2,
                                                ObjPremiumSummaryTotal.ReferalType2,
                                                ObjPremiumSummaryTotal.ReferalAmount2 ,
                                                ObjPremiumSummaryTotal.UserId ,
                                                ObjPremiumSummaryTotal.depositPremium ,
                                                ObjPremiumSummaryTotal.TotalEarningEnAmt ,
                                                ObjPremiumSummaryTotal.BrokerageEnAmt,
            ObjPremiumSummaryTotal.IRMBrokerageOption};
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummaryTotal_InsertUpdate", "GetTotal");
        }

        public DataSet PremiumSummaryUpdateInstallments(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[] { ObjPremiumSummaryTotal.TranRefNo, 
                                                ObjPremiumSummaryTotal.InstallmentNo,
                                                ObjPremiumSummaryTotal.InstallmentPercentage,
                                                ObjPremiumSummaryTotal.InstallmentDueDate };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_UpdateInstallments", "UpdateInstallments");
        }

        public DataSet PremiumSummaryGetInstalments(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[] { ObjPremiumSummaryTotal.TranRefNo, ObjPremiumSummaryTotal.Installments };
            return dataAccess.LoadDataSet(parametes, "P_RICN_PremiumSummary_GetInstalments", "GetTotal");
        }

        public DataSet RICoverNoteFileUpload(ClsFileAttachment objFileAttachment)
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
            return dataAccess.LoadDataSet(parameters, "P_RICN_FileAttachment", "FileAttachment");
        }
        public DataSet RICoverNoteGetUploadedFileList(string strCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode };
            return dataAccess.LoadDataSet(parameters, "P_RICN_FileAttachmentList", "FileAttachment");
        }
        public DataSet RICoverNoteDeleteFile(ClsFileAttachment objFileAttachment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objFileAttachment.TranRefNo,objFileAttachment.ID };
            return dataAccess.LoadDataSet(parameters, "P_RICN_FileAttachmentDelete", "FileAttachment");
        }

        public DataSet CoverNoteEnquiryInitialValues()
        {
            Object[] parametes = new Object[0];
            return dataAccess.LoadDataSet(parametes, "P_RICN_Search_CoverNoteEnquiryInitialValues", "LoadInitialValues");
        }
        public DataSet CoverNoteEnquirySearch(ClsCoverNoteEnquiry objCoverNoteEnquiry,int userid)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.CoverNoteNo,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.ClientCode,
                                    objCoverNoteEnquiry.ClientName,
                                    objCoverNoteEnquiry.MainClass,
                                    objCoverNoteEnquiry.Handler,
                                    objCoverNoteEnquiry.CreatedBy,
                                    objCoverNoteEnquiry.Type,
                                    objCoverNoteEnquiry.Status,
                                    objCoverNoteEnquiry.IsRiSlip,
                                    objCoverNoteEnquiry.Purpose,
                                    objCoverNoteEnquiry.From,
                                    objCoverNoteEnquiry.SourceCNNumber,
                                    userid
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Search_CoverNoteRecord", "LoadInitialValues");
        }

        public DataSet ENQ_PolicyRegisterSearch(ClsCoverNoteEnquiry objCoverNoteEnquiry)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.FromDate,
                                    objCoverNoteEnquiry.ToDate,
                                    objCoverNoteEnquiry.InsFromDate1,
                                    objCoverNoteEnquiry.InsFromDate2,
                                    objCoverNoteEnquiry.InsToDate1,
                                    objCoverNoteEnquiry.InsToDate2,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.IsRiSlip,
                                    objCoverNoteEnquiry.MainClass,
                                    objCoverNoteEnquiry.Territory,
                                    objCoverNoteEnquiry.DocRefNo
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_ENQ_PolicyRegister", "ENQ_PolicyRegisterSearch");
        }

        public DataSet ENQ_ClaimRegisterSearch(ClsCoverNoteEnquiry objCoverNoteEnquiry)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.InsFromDate1,
                                    objCoverNoteEnquiry.InsFromDate2,
                                    objCoverNoteEnquiry.InsToDate1,
                                    objCoverNoteEnquiry.InsToDate2,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.ReInsurerCode,
                                    objCoverNoteEnquiry.ReInsurerName,
                                    objCoverNoteEnquiry.ClaimNo,
                                    objCoverNoteEnquiry.PolicyNo
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_ENQ_ClaimRegister", "ENQ_ClaimRegister");
        }

        public DataSet ENQ_ClaimInvoiceRegisterSearch(ClsCoverNoteEnquiry objCoverNoteEnquiry)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.InsFromDate1,
                                    objCoverNoteEnquiry.InsFromDate2,
                                    objCoverNoteEnquiry.InsToDate1,
                                    objCoverNoteEnquiry.InsToDate2,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.ClaimINVNo,
                                    objCoverNoteEnquiry.ClaimINVNoDataMig,
                                    objCoverNoteEnquiry.ClaimNo,
                                    objCoverNoteEnquiry.PolicyNo
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_ENQ_ClaimInvoiceRegister", "ENQ_ClaimInvoiceRegister");
        }

        public DataSet RenewalDiarySearch(ClsCoverNoteEnquiry objCoverNoteEnquiry)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.FromDate,
                                    objCoverNoteEnquiry.ToDate,
                                    objCoverNoteEnquiry.CoverNoteNo,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.ClientCode,
                                    objCoverNoteEnquiry.ClientName,
                                    objCoverNoteEnquiry.MainClass,
                                    objCoverNoteEnquiry.Handler,
                                    objCoverNoteEnquiry.CreatedBy,
                                    objCoverNoteEnquiry.Type,
                                    objCoverNoteEnquiry.Status,
                                    objCoverNoteEnquiry.IsRiSlip,
                                    objCoverNoteEnquiry.Purpose,
                                    objCoverNoteEnquiry.From
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Search_DiaryRecord", "LoadInitialValues");
        }

        public DataSet RenewalEnquirySearch(ClsCoverNoteEnquiry objCoverNoteEnquiry)
        {
            Object[] parametes = new Object[]
                                {
                                    objCoverNoteEnquiry.CoverNoteNo,
                                    objCoverNoteEnquiry.CedantCode,
                                    objCoverNoteEnquiry.CedantName,
                                    objCoverNoteEnquiry.ReinsuredCode,
                                    objCoverNoteEnquiry.ReinsuredName,
                                    objCoverNoteEnquiry.ClientCode,
                                    objCoverNoteEnquiry.ClientName,
                                    objCoverNoteEnquiry.MainClass,
                                    objCoverNoteEnquiry.Handler,
                                    objCoverNoteEnquiry.CreatedBy,
                                    objCoverNoteEnquiry.Type,
                                    objCoverNoteEnquiry.Status,
                                    objCoverNoteEnquiry.IsRiSlip,
                                    objCoverNoteEnquiry.Purpose,
                                    objCoverNoteEnquiry.From
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Search_RenewalRecord", "LoadInitialValues");
        }

        public DataSet CompleteCoverNote(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[]
                                {
                                    ObjPremiumSummaryTotal.TranRefNo,
                                    ObjPremiumSummaryTotal.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_CompleteCoverNote", "CompleteCoverNote");
        }
        public DataSet CompleteRenewal(ClsPremiumSummaryTotal ObjPremiumSummaryTotal)
        {
            Object[] parametes = new Object[]
                                {
                                    ObjPremiumSummaryTotal.TranRefNo,
                                    ObjPremiumSummaryTotal.UserId
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_CompleteCoverNote_Renewal", "CompleteCoverNote");
        }
        public DataSet DeletedSelectedSubClass(string strTranRefNo)
        {
            Object[] parametes = new Object[1] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_GenInfo_DeleteAllSelectedSubClass", "LoadSubClass");
        }
        public DataSet LoadHeader(string strTranRefNo)
        {
            Object[] parametes = new Object[1] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_LoadHeaderDetails", "LoadSubClass");
        }

        public DataSet SavePrintRemarks(ClsFileAttachment objClsFileAttachment)
        {
            Object[] parametes = new Object[] {
                                    objClsFileAttachment.TranRefNo, 
                                    objClsFileAttachment.Remarks,
                                    objClsFileAttachment.UserId,
                                    objClsFileAttachment.PrintedSlipFields,
                                    objClsFileAttachment.Underwriter,
                                    objClsFileAttachment.Client,
                                    objClsFileAttachment.Own,
                                    objClsFileAttachment.UnderwriterCompanyLogo,
                                    objClsFileAttachment.ClientCompanyLogo,
                                    objClsFileAttachment.OwnCompanyLogo,
                                };
            return dataAccess.LoadDataSet(parametes, "P_RICN_Print_InsertUpdate", "PrintInsertUpdate");
        }

        public DataSet GetPrintData(string strCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode };
            return dataAccess.LoadDataSet(parameters, "P_RICN_Print_GetData", "FileAttachment");
        }
        public DataSet LoadMenuDetails(string strTranRefNo)
        {
            Object[] parametes = new Object[1] { strTranRefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_CoverNoteHeaderEnableDisable", "LoadSubClass");
        }

        public DataSet GetFooterForRI(int BranchId, int CompanyId)
        {
            Object[] parametes = new Object[2] { BranchId, CompanyId };
            return dataAccess.LoadDataSet(parametes, "P_FooterForRI", "BranchFooter");
        }

        public DataSet SaveEngineeringDeatils(clsRIQuotation.clsRIEngineeringDetails  objclsEngineeringDetails)
        {
            object[] parameters = new object[] {  
                                                 objclsEngineeringDetails.TranRefNo ,
                                                 objclsEngineeringDetails.CovernoteNo ,
                                                 objclsEngineeringDetails.EngDetailId,
                                                 objclsEngineeringDetails.JobNo,
                                                 objclsEngineeringDetails.CompensationLimit,
                                                 objclsEngineeringDetails.ProjLocationDesc,
                                                 objclsEngineeringDetails.Principal,
                                                 objclsEngineeringDetails.ContractValue,
                                                 objclsEngineeringDetails.CommencementDate,
                                                 objclsEngineeringDetails.CompletionDate,
                                                 objclsEngineeringDetails.Days,
                                                 objclsEngineeringDetails.DefLiabilityPeriodFrom,
                                                 objclsEngineeringDetails.DefLiabilityPeriodTo,
                                                 objclsEngineeringDetails.DefLiabilityDays,
                                                 objclsEngineeringDetails.PremiumRate,
                                                 objclsEngineeringDetails.Total,
                                                 objclsEngineeringDetails.BalanceLia,
                                                 objclsEngineeringDetails.PremiumRatePer,
                                                 objclsEngineeringDetails.CARBalance,
                                                 objclsEngineeringDetails.Balance,
                                                 objclsEngineeringDetails.UserId
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_EngDetails_InsertUpdate", "EngDetailsInsertUpdate");

        }
        public DataSet LoadEngineeringDeatils(clsRIQuotation.clsRIEngineeringDetails objclsEngineeringDetails)
        {
            object[] parameters = new object[] {  
                                                 objclsEngineeringDetails.TranRefNo ,
                                                 objclsEngineeringDetails.CovernoteNo ,
                                                 objclsEngineeringDetails.EngDetailId,
                                                 objclsEngineeringDetails.Mode,
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_EngDetails_GetData", "GetData");

        }

        //added on 3rd March for Motor Details(Motor Class)//
        public DataSet SaveMotorDetails(clsRIQuotation.clsRIMotorDetails  objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objMotorDetails.RefNo, objMotorDetails.TranRefNo , objMotorDetails.CovernoteNo,
            objMotorDetails.VehicleType,objMotorDetails.RegistrationNo,
            objMotorDetails.Make,objMotorDetails.Model,objMotorDetails.EngineNo,objMotorDetails.ChassisNo,
            objMotorDetails.CubicCapacity,objMotorDetails.SeatingCapacity,objMotorDetails.TypeOfBody,
            objMotorDetails.NoOfClaimDiscount,objMotorDetails.FleetNo,objMotorDetails.RegistrationDate,
            objMotorDetails.ManufactureYear,objMotorDetails.CommecimalVehType,objMotorDetails.LicenceExpiryDate,
            objMotorDetails.Licensed,objMotorDetails.BusAirCon,objMotorDetails.BusType, objMotorDetails.UserID , 
            objMotorDetails.VehicleTypeID ,objMotorDetails.VehicleTypeName ,objMotorDetails.CoverageID ,objMotorDetails.CoverageName ,
            objMotorDetails.BasicRate ,objMotorDetails.RatePercentage ,objMotorDetails.SumInsured ,objMotorDetails.Premium,objMotorDetails.MotorMultipleBilling,
            objMotorDetails.Excess};
            return dataAccess.LoadDataSet(parametes, "P_RICN_MotorDetailsInsertUpdate", "PolicyMotorDetailsInsertUpdate");
        }
        public DataSet GetMotorDetails(clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objMotorDetails.TranRefNo , objMotorDetails.CovernoteNo , objMotorDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_MotorDetails", "PolicyMotorDetails");
        }
        public DataSet DeleteMotorDetails(clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objMotorDetails.TranRefNo, objMotorDetails.CovernoteNo, objMotorDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_MotorDetails_Delete", "PolicyMotorDetails");
        }
        public DataSet GetBindMotorDetails(clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { objMotorDetails.TranRefNo, objMotorDetails.CovernoteNo, objMotorDetails.VehicleType, objMotorDetails.RegistrationNo };
            return dataAccess.LoadDataSet(parametes, "P_RICN_MotorDetailsBind", "PolicyMotorDetailsBind");
        }
        public DataSet GetFillDowndownlist(clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objMotorDetails.VehicleType };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorVehicleType", "PolicyMotorDetailsBind");
        }
        public DataSet GetFillMotorTriff(clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objMotorDetails.VehicleTypeID, objMotorDetails.CoverageID };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorTariff", "PolicyMotorDetailsBind");
        }
        //end

        //added on 8th March for Risk Location//
        public DataSet LoadRiskLocationDeatils(clsRIQuotation.clsRIRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  objclsRiskLocations.TranRefNo ,
                                                    objclsRiskLocations.CoverNoteNo ,
                                                    objclsRiskLocations.LocationId,
                                                    objclsRiskLocations.Mode
                                                    ,objclsRiskLocations.LocationDescription
            };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_PolicyMaster_GetRiskLocationDetails", "GetRiskLocationDetails");

        }
        public DataSet SaveRiskLocationDeatils(clsRIQuotation.clsRIRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.TranRefNo,
                                                objclsRiskLocations.CoverNoteNo,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.LocationDescription,
                                                objclsRiskLocations.Address1,
                                                objclsRiskLocations.Address2,
                                                objclsRiskLocations.Address3,
                                                objclsRiskLocations.Country,
                                                objclsRiskLocations.UserId,
                                                objclsRiskLocations.POIFromDate,
                                                objclsRiskLocations.POIToDate,
                                                objclsRiskLocations.RiskLocMutipleBill 
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_RiskLocations_InsertUpdate", "RiskLocationsInsertUpdate");

        }
        public DataSet SaveRiskLocationInterestDeatils(clsRIQuotation.clsRIRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.TranRefNo,
                                                objclsRiskLocations.CoverNoteNo,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.InterestDescription,
                                                objclsRiskLocations.UserId
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_RiskLocationsInterest_InsertUpdate", "RiskLocationsInterestInsertUpdate");

        }

        public DataSet SaveRiskLocationInterestDeatilsNew(clsRIQuotation.clsRiskLocationsInterest  objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.TranRefNo,
                                                objclsRiskLocations.CoverNoteNo,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.InterestDescription,
                                                objclsRiskLocations.UserId,
                                                objclsRiskLocations.InterestHeader,
                                                objclsRiskLocations.SumInsured,
                                                objclsRiskLocations.Valuation,
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_RiskLocationsInterest_InsertUpdateNew", "RiskLocationsInterestInsertUpdate");

        }

        public DataSet DeleteRiskLocationInterestDeatils(clsRIQuotation.clsRiskLocationsInterest objclsRiskLocations, string Mode)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.TranRefNo,
                                                objclsRiskLocations.CoverNoteNo,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.LocationId,
                                                Mode
                                               
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_RiskLocations_InterestDelete", "RiskLocationsInterestInsertUpdate");

        }

        public DataSet DeleteRiskLocationInterestDeatils(clsRIQuotation.clsRIRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.TranRefNo ,
                                                objclsRiskLocations.CoverNoteNo,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_RICN_RiskLocationsInterest_Delete", "RiskLocationsInterestDelete");

        }
        public DataSet GetInterestNew(string TranRefNo, string CoverNoteNo, string strInterestHeader, string strInterestId, string strMode, int intLocationId)
        {
            Object[] parametes = new Object[6] { TranRefNo, CoverNoteNo, strInterestHeader, strInterestId, strMode, intLocationId };
            return dataAccess.LoadDataSet(parametes, "P_RICN_RiskLocations_InterestNew", "Interest");
        }

      //end


        //added on 10th march for motor file upload//
        public void SqlInsertMotorDataTableWithParamNew(string con, DataTable dtTableName, clsRIQuotation.clsRIMotorDetails objMotorDetails)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_RICN_VehicleDetails_BulkInsertNew", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_RICN_VehicleDetails", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]
                {
                    new SqlParameter("@TranRefNo", objMotorDetails.TranRefNo  ),
                    new SqlParameter("@CoverNoteNo", objMotorDetails.CovernoteNo),
                    new SqlParameter("@LoginUserId", objMotorDetails.UserID),
                    new SqlParameter("@IsMultipleBilling", (objMotorDetails.MotorMultipleBilling==true?"Y":"N")),
                    param 
                };
                //scCmd.Parameters.Add(param);
                scCmd.Parameters.AddRange(tvp);
                scCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
        }
     
        public void SqlInsertDataTableWithParamNew(string con, DataTable dtTableName, clsRIQuotation.clsRIRiskLocations  objclsRiskLocations)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_RICN_RiskLocations_BulkInsertNew", sqlcon);
                //SqlCommand scCmd = new SqlCommand("P_Pol_RiskLocations_BulkInsert", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_RICN_Location_Item1", SqlDbType.Structured);
                //  SqlParameter param = new SqlParameter("Type_Location_Item", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]{
                    new SqlParameter("@TranRefNo", objclsRiskLocations.TranRefNo  ),
                    new SqlParameter("@CoverNoteNo", objclsRiskLocations.CoverNoteNo ),
                    new SqlParameter("@LoginUserId", objclsRiskLocations.UserId),
                    new SqlParameter("@IsMultipleBilling", objclsRiskLocations.MultipleBilling),
                    param
                };
                //scCmd.Parameters.Add(param);
                scCmd.Parameters.AddRange(tvp);

                scCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        //END

        // below method are added by praveen verma on 28 Apr 2017.

        public DataSet GetPremium(ClsMarket objMarket)
        {
            Object[] parametes = new Object[] {
                                    objMarket.ID,                                     
                                };
            return dataAccess.LoadDataSet(parametes, "RI_GET_PremiumDetails_CN_Market", "RI_CN_Market");
        }

        public DataSet AddEditPremium(ClsMarket objMarket)
        {
            object[] parameters = new object[] {  
                                                objMarket.TranRefNo,
                                                objMarket.ID,
                                                objMarket.BrokerCode,
                                                objMarket.FullName,  
                                                objMarket.Security,
                                                objMarket.IsLeader,
                                                objMarket.EffectiveDate,
                                                objMarket.SharePerc,
                                                objMarket.Amount,
                                                objMarket.Brokerage,
                                                objMarket.Remarks                                                
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "RI_AddUpdate_PremiumDetails_CN_Market", "RI_CN_Market");
        }

        public DataSet AddEditSlipIntroducer(ClsTSILimitSummary ClsTSILimitSummary)
        {
            object[] parameters = new object[] {  
                                                ClsTSILimitSummary.TranRefNo,                                                
                                                ClsTSILimitSummary.Code,
                                                ClsTSILimitSummary.Name,
                                                ClsTSILimitSummary.basis,
                                                ClsTSILimitSummary.Introducer_Fee,
                                                ClsTSILimitSummary.OriginalCurr,
                                                ClsTSILimitSummary.AmountOC,
                                                ClsTSILimitSummary.LocalCurr,
                                                ClsTSILimitSummary.AmountLC,
                                                ClsTSILimitSummary.UserId                                         
                                                };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "RI_AddUpdate_SlipIntroducer", "RI_SlipIntroducerMapping");
        }

    }
}
