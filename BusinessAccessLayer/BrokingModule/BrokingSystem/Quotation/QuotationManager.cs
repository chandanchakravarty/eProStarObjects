using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class QuotationManager
    {

        DataAccess dataAccessDS = null;


        public DataSet GetPolicyStatus(int PolicyId, int PolversionId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { PolicyId, PolversionId };
            return dataAccessDS.LoadDataSet(parameters, "P_GetPolicyStatus", "P_CN_GetIntroducerDetails");
        }





        public DataSet GetPolicyAgentDetailsFromClient(int clientId, clsPolicyAgent _objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { clientId, _objPolicyAgent.PolicyId, _objPolicyAgent.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_CN_GetIntroducerDetails", "P_CN_GetIntroducerDetails");
        }

        public DataSet GetPolicyIntroducerPrem(clsPolicyAgent _objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { _objPolicyAgent.PolicyId, _objPolicyAgent.PolVersionId, _objPolicyAgent.id, _objPolicyAgent.IsEndorsement, _objPolicyAgent.UWId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Introducer_TotalDue", "P_Pol_Introducer_TotalDue");
        }

        public DataSet SavePremiumIntroducerDetail(clsPolicyAgent _objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { _objPolicyAgent.PolicyId, _objPolicyAgent.PolVersionId, _objPolicyAgent.AgentId, _objPolicyAgent.Currency, _objPolicyAgent.TotalPremium, _objPolicyAgent.Totalbrokerage, _objPolicyAgent.IntroducerShare, _objPolicyAgent.TotalDue, _objPolicyAgent.User, _objPolicyAgent.id, _objPolicyAgent.IsEndorsement, _objPolicyAgent.AutoId, _objPolicyAgent.UWId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Introduce_InsertUpdate", "P_Pol_Introduce_InsertUpdate");
        }


        public DataSet SavePremiumIntroducerDetail_Instalment(clsPolicyAgent _objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { _objPolicyAgent.PolicyId, _objPolicyAgent.PolVersionId, _objPolicyAgent.AgentId, _objPolicyAgent.Currency, _objPolicyAgent.TotalPremium, _objPolicyAgent.Totalbrokerage, _objPolicyAgent.IntroducerShare, _objPolicyAgent.TotalDue, _objPolicyAgent.User, _objPolicyAgent.id, _objPolicyAgent.PeriodFrom, _objPolicyAgent.PeriodTo, _objPolicyAgent.DebitNoteDate, _objPolicyAgent.InstNo, _objPolicyAgent.InstPercentage };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Introduce_Instalment_InsertUpdate", "P_Pol_Introduce_InsertUpdate");
        }


        public DataSet getVesselId(string subSlipCN)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { subSlipCN };
            return dataAccessDS.LoadDataSet(parametes, "P_pol_getvesselID_From_Subslip", "P_pol_getvesselID_From_Subslip");
        }
        public DataSet getPrintCovernaote(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_PrintCoverNote", "P_PrintCoverNote");
        }
        public DataSet getUWCodeForVesselId(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Get_UW_For_Vessel", "P_Get_UW_For_Vessel");
        }

        public DataSet GetSysParamValue()
        {

            object[] parameters = new object[] { "StampDuty" };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_GetValue_SysParam", "P_GetValue_SysParam");
        }
        public DataSet IsBillingRequired(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_IsBillingRequired", "Pol_IsBillingRequired");
        }
        public DataSet LoadQuotationClientDetail(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_pol_ClientMaster_Select", "Pol_PolicyMaster");
        }

        public DataSet LoadRenewalLapsedReason(long renewallapsedreason)
        {

            object[] parameters = new object[] { renewallapsedreason };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_GetRenewalLapsedReason", "TM_RenewalLapsedMaster");
        }
        public DataSet LoadActiveUnderwriterDetail(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "p_Pol_ActivePolicyUnderwrites", "Pol_PolicyUnderwriters");
        }


        public DataSet LoadRIQuotationCedantDetail(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.RefNo, objclsQuotation.CoverNoteNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "RI_CN_pol_ClientMaster_Select", "RIVesselDetails");
        }
        public DataSet LoadRIQuotationClientDetail(ClsRenewalLetter_RI objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_pol_ClientMaster_Select", "Pol_PolicyMaster");
        }

        public DataSet SaveQuotationClientDetail(clsQuotation objclsQuotation, int LoginTeamId)
        {
            object[] parameters = new object[] {    objclsQuotation.PolicyId, 
                                                    objclsQuotation.PolVersionId, 
                                                    objclsQuotation.ClientId, 
                                                    objclsQuotation.MainClassId, 
                                                    objclsQuotation.SubClassId, 
                                                    objclsQuotation.BenefitScheduleId,
                                                    objclsQuotation.BusinessType,
                                                    objclsQuotation.IsGlobal, 
                                                    objclsQuotation.BusinessDesc, 
                                                    objclsQuotation.Remarks, 
                                                    objclsQuotation.IsComplete, 
                                                    objclsQuotation.User, 
                                                    objclsQuotation.IsActive, 
                                                    objclsQuotation.CompanyId, 
                                                    objclsQuotation.BranchID, 
                                                    objclsQuotation.SourcePolicyNo, 
                                                    objclsQuotation.Pol_Status,
                                                    objclsQuotation.scrfor, LoginTeamId,
                                                    objclsQuotation.FirstName,
                                                    objclsQuotation.LastName,
                                                    objclsQuotation.Salutation,
                                                    objclsQuotation.JobTitle,
                                                    objclsQuotation.GeneralLineCode,
                                                    objclsQuotation.GeneralLineNo,
                                                    objclsQuotation.DirectLineCode,
                                                    objclsQuotation.DirectLineNo,
                                                    objclsQuotation.MobileNoCode,
                                                    objclsQuotation.MobileNo,
                                                    objclsQuotation.FaxNoCode,
                                                    objclsQuotation.FaxNo,
                                                    objclsQuotation.Email,
                                                    objclsQuotation.CorrAddress1,
                                                    objclsQuotation.CorrAddress2,
                                                    objclsQuotation.CorrAddress3,
                                                    objclsQuotation.CorrAddress4,
                                                    objclsQuotation.Country,
                                                    objclsQuotation.PolicyType ,
                                                    objclsQuotation.IsStdBenefitSchedule,
                                                    objclsQuotation.QuotationNo,
                                                    objclsQuotation.HistoricalData,
                                                    objclsQuotation.IsReinsurance,
                                                    objclsQuotation.Designation,
                                                    objclsQuotation.CorporateGroup,
                                                    objclsQuotation.IsHOC,
                                                    objclsQuotation.PlanType
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_ClientDetails_InsertUpdate", "Pol_PolicyMaster");
        }
        //added by kavita for multiple sub class(Marine main class)
        public DataSet SaveMultipleSubClassForMarine(clsQuotation objclsQuotation)
        {
            return SaveMultipleSubClassForMarine(objclsQuotation, 0);
        }
        public DataSet SaveMultipleSubClassForMarine(clsQuotation objclsQuotation, int isNew)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.MainClassId, objclsQuotation.SubClassId, objclsQuotation.SubClassName, objclsQuotation.User, isNew };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMultipleSubClass_InsertUpdate", "Pol_PolicyMasterMultipleSubClass");

        }

        public DataSet DeleteMultipleSubClassforMarine(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] {   objclsQuotation.PolicyId,
                                                    objclsQuotation.PolVersionId,
                                                    objclsQuotation.MainClassId,
                                                    objclsQuotation.SubClassId
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_MultipleSubClassforMarine_Delete", "P_Pol_MultipleSubClassDelete");
        }

        public DataSet SelectMultipleSubClassforMarine(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new object[4] {   objclsQuotation.PolicyId ,
                                                    objclsQuotation.PolVersionId,
                                                    objclsQuotation.MainClassId,
                                                    objclsQuotation.ItemFor
                                                 
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_POL_MultipleSubClassForMarine_Select", "P_POL_MultiSubclassForMarine_Select");
        }
        //end
        public DataSet SaveQuotationFrontingUWDetail(clsQuotation objclsQuotation, string xmlFile)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, xmlFile, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_FrontingPolicyUnderwriter_Update", "Pol_FrontingPolicyMaster");

        }

        public DataSet SaveQuotationUWDetail(clsQuotation objclsQuotation, string xmlFile)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, xmlFile, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriter_Update", "Pol_PolicyMaster");

        }

        public DataSet SelectInCompleteQuotation(clsInCompleteQuotation objInCompleteQuotation)
        {
            // object[] parameters = new object[] { objInCompleteQuotation.POIFromDate, objInCompleteQuotation.POIEndDate, objInCompleteQuotation.QuotationNo, objInCompleteQuotation.CovernoteNo, objInCompleteQuotation.ClientCode, objInCompleteQuotation.ClientName, objInCompleteQuotation.UnderwriterCode, objInCompleteQuotation.UnderwriterName, objInCompleteQuotation.MainClassId, objInCompleteQuotation.SubClassId, objInCompleteQuotation.AccountHandler, objInCompleteQuotation.CreatedBy, objInCompleteQuotation.IsInc, objInCompleteQuotation.frmFor,objInCompleteQuotation.scrFor };
            object[] parameters = new object[] { objInCompleteQuotation.POIFromDate, objInCompleteQuotation.POIEndDate, objInCompleteQuotation.QuotationNo, objInCompleteQuotation.CovernoteNo, objInCompleteQuotation.ClientCode, objInCompleteQuotation.ClientName, objInCompleteQuotation.UnderwriterCode, objInCompleteQuotation.UnderwriterName,objInCompleteQuotation.UnderwriterShortName, objInCompleteQuotation.MainClassId, objInCompleteQuotation.SubClassId, objInCompleteQuotation.AccountHandler, objInCompleteQuotation.CreatedBy, objInCompleteQuotation.IsInc, objInCompleteQuotation.frmFor, objInCompleteQuotation.scrFor, 
                                                 objInCompleteQuotation.PolicyNumber, objInCompleteQuotation.IsHOC, objInCompleteQuotation.ReferenceNo, objInCompleteQuotation.RenewalType, objInCompleteQuotation.RenewalStatus,objInCompleteQuotation.PaymentMode,objInCompleteQuotation.EBRenewalLetterType,objInCompleteQuotation.ClientType,objInCompleteQuotation.DateFormat, objInCompleteQuotation.Status, objInCompleteQuotation.Channel,objInCompleteQuotation.userID  ,objInCompleteQuotation.DivisionalGrouping,objInCompleteQuotation.KeyAccountmanager,objInCompleteQuotation.Industrytype,objInCompleteQuotation.ProjectTitle,
                                                 objInCompleteQuotation.SrchPPWStatus,objInCompleteQuotation.TeamId};

            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_POL_InCompleteQuotation_Select", "P_POL_InCompleteQuotation_Select");
        }



        //added for Renewal Diary on DashBoard Screen
        public DataSet SelectRenewal_FollowUp(clsInCompleteQuotation objInCompleteQuotation)
        {
            // object[] parameters = new object[] { objInCompleteQuotation.POIFromDate, objInCompleteQuotation.POIEndDate, objInCompleteQuotation.QuotationNo, objInCompleteQuotation.CovernoteNo, objInCompleteQuotation.ClientCode, objInCompleteQuotation.ClientName, objInCompleteQuotation.UnderwriterCode, objInCompleteQuotation.UnderwriterName, objInCompleteQuotation.MainClassId, objInCompleteQuotation.SubClassId, objInCompleteQuotation.AccountHandler, objInCompleteQuotation.CreatedBy, objInCompleteQuotation.IsInc, objInCompleteQuotation.frmFor,objInCompleteQuotation.scrFor };
            object[] parameters = new object[] { objInCompleteQuotation.POIFromDate, objInCompleteQuotation.POIEndDate, objInCompleteQuotation.DiaryType };

            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_getRenewal_FollowUp_Diary", "P_POL_Renewal_FollowUp");
        }
        //end

        public DataSet SelectPolicyEnquiry(clsInCompleteQuotation objInCompleteQuotation, int userid)
        {

            object[] parameters = new object[] { objInCompleteQuotation.EnquiryType, objInCompleteQuotation.ClientCode, objInCompleteQuotation.ClientName,
                objInCompleteQuotation.Group, objInCompleteQuotation.SubGroup, objInCompleteQuotation.BNC, objInCompleteQuotation.SourceCode,
                objInCompleteQuotation.UnderwriterCode, objInCompleteQuotation.UnderwriterName,
            objInCompleteQuotation.POIFromDate , objInCompleteQuotation.POIEndDate, objInCompleteQuotation.DebitNoteDateFrom, objInCompleteQuotation.DebitNoteDateTo,
            objInCompleteQuotation.PolicyNumber, objInCompleteQuotation.VehicalNo, objInCompleteQuotation.Location,objInCompleteQuotation.InsuredPerson,objInCompleteQuotation.DateFormat
            ,objInCompleteQuotation.VehicalName,objInCompleteQuotation.BillingParty,userid,objInCompleteQuotation.ProjectTitle,objInCompleteQuotation.TeamId,objInCompleteQuotation.UnderwriterShortName};

            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_POL_PolicyEnquiry_Select", "P_POL_PolicyEnquiry_Select");
        }



        public DataSet ENQ_ClientEnquiry(clsClientEnquiry objClientEnquiry)
        {
            object[] parameters = new object[] { objClientEnquiry.ClientCode, objClientEnquiry.ClientName, objClientEnquiry.ClientType, objClientEnquiry.BusinessNatureCode, objClientEnquiry.Group, objClientEnquiry.EffFromDate, objClientEnquiry.EffToDate, objClientEnquiry.ForAudit, objClientEnquiry.DateFormat, objClientEnquiry.Corelated, objClientEnquiry.BusinessType, objClientEnquiry.ClientSource, objClientEnquiry.ClientStatus };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_ClientEnquiry", "ClientEnquiry");
        }

        public DataSet ENQ_UnderwriterEnquiry(clsUnderwriterEnquiry objUnderwriterEnquiry)
        {
            object[] parameters = new object[] { objUnderwriterEnquiry.UNCode, objUnderwriterEnquiry.UNName, objUnderwriterEnquiry.UNShortName, objUnderwriterEnquiry.Email, objUnderwriterEnquiry.EffFromDate, objUnderwriterEnquiry.EffToDate, objUnderwriterEnquiry.ForAudit, objUnderwriterEnquiry.DateFormat };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_UnderwriterEnquiry", "UnderwriterEnquiry");
        }

        public DataSet ENQ_CoverNoteEnquiry(clsCoverNoteEnquiry objclsCoverNoteEnquiry, int userid)
        {
            object[] parameters = new object[] { objclsCoverNoteEnquiry.POIFrom, objclsCoverNoteEnquiry.POITo, objclsCoverNoteEnquiry.ClientCode, objclsCoverNoteEnquiry.ClientName, objclsCoverNoteEnquiry.MAinClass, objclsCoverNoteEnquiry.SubClass, objclsCoverNoteEnquiry.CoverNoteNo, objclsCoverNoteEnquiry.DateFormat, userid };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_CoverNoteEnquiry", "CoverNoteEnquiry");
        }

        public DataSet ENQ_BirthdayEnquiry(clsBirthdayEnquiry objBirthdayEnquiry)
        {
            object[] parameters = new object[] { objBirthdayEnquiry.BDayMonth, objBirthdayEnquiry.Day1, objBirthdayEnquiry.Month1, objBirthdayEnquiry.Year1, objBirthdayEnquiry.Day2, objBirthdayEnquiry.Month2, objBirthdayEnquiry.Year2 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_BirthdayEnquiry", "BirthdayEnquiry");
        }

        public DataSet ENQ_AgentEnquiry(clsAgentEnquiry objAgentEnquiry)
        {
            object[] parameters = new object[] { objAgentEnquiry.AGCode, objAgentEnquiry.AGType, objAgentEnquiry.EffFromDate, objAgentEnquiry.EffToDate, objAgentEnquiry.ForAudit, objAgentEnquiry.DateFormat, objAgentEnquiry.AGName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_AgentEnquiry", "AgentEnquiry");
        }

        public DataSet ENQ_GetClass()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ENQ_BindingSet", "Group");
        }

        public DataSet SaveAgentCommission(long policyId,int polVersionId,string agentId,string AgentCommision)
        {
            object[] parameters = new object[4] { policyId, polVersionId, agentId, AgentCommision };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_CommissionInsert", "Pol_PolicyMasterAgent");

        }
        public DataSet GetInsertedAgentCommissionInPolicy(long policyId, int polVersionId)
        {
            object[] parameters = new object[2] { policyId, polVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_GetInsertedCommission", "Pol_PolicyMasterAgent");

        }

        public DataSet SaveQuotationDetail(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[52] {      // added EndorsementCategory parameter and icremented object array length from 46 to 47. For Redmine #21705.
                                                 objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objclsQuotation.BusinessType,
                                                 objclsQuotation.RenewalType,
                                                 objclsQuotation.PrimaryAccHandler,
                                                 objclsQuotation.SecondaryAccHandler,
                                                 objclsQuotation.DateType,
                                                 objclsQuotation.POIHeader,
                                                 objclsQuotation.POIFooter,
                                                 objclsQuotation.POIFromDate,
                                                 objclsQuotation.POIFromTimeHH,
                                                 objclsQuotation.POIFromTimeMM,
                                                 objclsQuotation.POIToDate,
                                                 objclsQuotation.POIToTimeHH,
                                                 objclsQuotation.POIToTimeMM,
                                                 objclsQuotation.POIBothDaysInclude,
                                                 objclsQuotation.MaintainPeriodHeader,
                                                 objclsQuotation.MaintainPeriodFooter,
                                                 objclsQuotation.MaintenancePeriodFromDate,
                                                 objclsQuotation.MaintenancePeriodFromDateHH,
                                                 objclsQuotation.MaintenancePeriodFromDateMM,
                                                 objclsQuotation.MaintenancePeriodToDate,
                                                 objclsQuotation.MaintenancePeriodToDateHH,
                                                 objclsQuotation.MaintenancePeriodToDateMM,
                                                 objclsQuotation.MaintainPeriodBothDaysInclude,
                                                 objclsQuotation.MonthsThereafter,
                                                 objclsQuotation.EBPolicyCurrency,
                                                 objclsQuotation.EBPremiumCurrency,
                                                 objclsQuotation.UWCoinsuranceApplicable,
                                                 objclsQuotation.BrokerageType,
                                                 objclsQuotation.User,
                                                 objclsQuotation.EndorsementNo,
                                                 objclsQuotation.EndorsementType,
                                                 objclsQuotation.EndorsementEffdate,
                                                 objclsQuotation.EndorsementRemark,
                                                 objclsQuotation.IsReinsurance,                                                
                                                 objclsQuotation.RiskDetailsSubClassType ,  
                                                 objclsQuotation.IsFrontingPolicy ,
                                                 objclsQuotation.PolicyUniqueNo,
                                                 objclsQuotation.Product,
                                                 objclsQuotation.ModeOfPayment,
                                                 objclsQuotation.DivisionalGrouping,
                                                 objclsQuotation.BillingType,
                                                 objclsQuotation.HistoricalData,
                                                 objclsQuotation.RiskLocationType,
                                                 objclsQuotation.IsBillingleadInsurer,    //Added for redmine 18341 
                                                 objclsQuotation.EndorsementCategory,    // added for #21705
                                                 objclsQuotation.NoOfYears,    // added for redmine 21283
                                                 objclsQuotation.PolicyAnniversaryDate,    // added for redmine 21283
                                                 objclsQuotation.MasterPolicyNo,    // added for redmine 23512
                                                 objclsQuotation.ReplacingPolicyNo,
                                                  objclsQuotation.ReinsurerDetails
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_QuotationDetails_InsertUpdate", "Pol_PolicyMaster");

        }


        public DataSet GetAgentDetails(string AgentId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { AgentId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_AgentMaster", "AgentMasterList");
        }

        public DataSet GetPolicyAgentDetails(clsPolicyAgent objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] { objPolicyAgent.PolicyId, objPolicyAgent.PolVersionId, objPolicyAgent.id };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_Select", "AgentMasterList");
        }

        public DataSet GetPolicyAgentDetailsEndt(clsPolicyAgent objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] { objPolicyAgent.PolicyId, objPolicyAgent.PolVersionId, objPolicyAgent.id };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_Select_Endt", "AgentMasterList");
        }

        public DataSet GetPolicyAgentDetailsShare(clsPolicyAgent objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { objPolicyAgent.AgentId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_Select_Share", "AgentMasterList");
        }


        public DataSet GetPolicyAgentDetailsDNWOCNShare(string objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { objPolicyAgent };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_DNWOCN_Share", "AgentMasterList");
        }

        public DataSet GetUnderwriterDetails(string UnderwriterId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { UnderwriterId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_UnderwriterMaster", "UnderwriterMasterList");
        }
        public DataSet GetFrontingPolicyUnderwriterDetails(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_FrontingPolicyUnderwriters_Select", "FrontingUnderwriterMasterList");
        }

        public DataSet GetClaimFrontingPolicyUnderwriterDetails(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_EC_ClaimsFrontingPolicyData", "ClaimFrontingUnderwriterMasterList");
        }
        public DataSet GetPolicyUnderwriterDetails(clsPolicyUnderwriter objPolicyUnderwriter)
        {

            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.VesselId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_Select", "UnderwriterMasterList");
        }
        //public DataSet GetVesselUWDetails(clsVesselDetails objVesselDetails)
        //{
        //    dataAccessDS = new DataAccess();
        //    Object[] parametes = new Object[2] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId };
        //    return dataAccessDS.LoadDataSet(parametes, "[P_Pol_QuotationVesselUnderwriters_Select]", "PolicyVesselUWDetails");
        //}
        public DataSet GetpaymentmodeDetails()
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccessDS.LoadDataSet("IH_PaymentMode", "PaymentMode");
        }
        public DataSet GetPolicyUnderwriterProductDetails(clsQuotation objPolicy)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objPolicy.UWCode };
            return dataAccessDS.LoadDataSet(parameters, "IH_Policy_UWProductDetails", "UnderwriterProductList");
        }
        public DataSet GetPolicyUnderwriterProductAvailability(clsQuotation objPolicy, double productcode)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objPolicy.UWCode, productcode };
            return dataAccessDS.LoadDataSet(parameters, "Get_IH_Policy_UWProductAvailability", "UnderwriterProductAvalibility");
        }


        public DataSet GetDivisionalGroupingDetails()
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccessDS.LoadDataSet("P_Pol_GetDivisionalGrouping", "DivisionalGrouping");
        }
        public DataSet getGSTSErviceFee()
        {

            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet("P_Get_GSTServiceFee", "TM_GST");
        }
        public DataSet GetPolicyVesselUnderwriterDetails(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.VesselId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_VesselUnderwriters_Select", "VesselUnderwriterMasterList");
        }
        public DataSet GetPolicyVesselDetails(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyVesselDetails_Select", "VesselList");
        }
        public DataSet GetPolicyIHInsuredName(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyIHInsuredDetails_Select", "IHInsuredList");
        }

        public DataSet GetPolicyUnderwriterDueDetail(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_TotalDue_Select", "UnderwritersDue");
        }
        public DataSet GetPolicyUnderwriterDueDetailBilling(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.VesselId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_TotalDue_Select_Billing", "UnderwritersDue");
        }
        public DataSet GetPolicyUnderwriterDetailsTotalDue(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_TotalDue", "UnderwriterDue");
        }

        public DataSet GetPolicyUnderwriterDetailsTotalDueLeadBilling(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_TotalDue_LeadBilling", "UnderwriterDue");
        }

        public DataSet GetPolicyVesselUnderwriterDetailsTotalDue(clsPolicyUnderwriter objPolicyUnderwriter, string VesselId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[5] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId, objPolicyUnderwriter.ID, VesselId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_VesselUnderwriters_TotalDue", "UnderwriterDue");
        }
        public void DeletePolicyAgent(clsPolicyAgent objPolicyAgent)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] {   objPolicyAgent.PolicyId,
                                                    objPolicyAgent.PolVersionId,
                                                    objPolicyAgent.AgentId,
                                                    objPolicyAgent.User
            
                                                };
            dataAccessDS.ExecuteNonQuery("P_Pol_PolicyAgents_Delete", parameters);
        }

        public void DeletePolicyUnderwriter(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    objPolicyUnderwriter.UWId,
                                                    objPolicyUnderwriter.User
            
                                                };
            dataAccessDS.ExecuteNonQuery("P_Pol_PolicyUnderwriters_Delete", parameters);
        }
        public void DeleteFRontingPolicyUnderwriter(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    objPolicyUnderwriter.UWId,
                                                    objPolicyUnderwriter.User
            
                                                };
            dataAccessDS.ExecuteNonQuery("P_Pol_FrontingPolicyUnderwriters_Delete", parameters);
        }
        public DataSet SavePolicyAgent(clsPolicyAgent objPolicyAgent, string AgentIds)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[4] {   objPolicyAgent.PolicyId,
                                                    objPolicyAgent.PolVersionId,
                                                    AgentIds,
                                                    objPolicyAgent.User
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAgents_Insert", "AgentMasterList");
        }


        public DataSet SaveFrontingPolicyUnderwriters(clsPolicyUnderwriter objPolicyUnderwriter, string UWIds, int LoginTeamId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[5] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    UWIds,
                                                    objPolicyUnderwriter.User,
                                                    LoginTeamId
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_FrontingPolicyUnderwriters_Insert", "FrontingUnderwriterMasterList");
        }

        public DataSet SavePolicyUnderwriters(clsPolicyUnderwriter objPolicyUnderwriter, string UWIds, int LoginTeamId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[5] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    UWIds,
                                                    objPolicyUnderwriter.User,
                                                    LoginTeamId
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_Insert", "UnderwriterMasterList");
        }

        public DataSet GetRiskHeaderTemplateId(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { objclsCoverageRiskHeader.PolicyUWCovDetailId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_SelectTemplateId", "Pol_PolicyUWCovDetails_Header");

        }

        public DataSet LoadRiskHeader(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                objclsCoverageRiskHeader.BM_TemplateId, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId,
                                                
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_Mapping_Select", "Pol_PolicyUWCovDetails_Header");

        }

        public DataSet SearchData(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                objclsCoverageRiskHeader.BM_TemplateId, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId,
                                                objclsCoverageRiskHeader.MainHeader,
                                                objclsCoverageRiskHeader.TitleDescription,
                                                objclsCoverageRiskHeader.GroupHeader 
                                                
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_ConditionWarrantyExclusion_Search", "Pol_PolicyUWCovDetails_Search");

        }

        //
        public DataSet SearchDataForLAW(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                               
                                             
                                                objclsCoverageRiskHeader.PolicyId, 
                                               
                                                objclsCoverageRiskHeader.PolVersionId,
                                                objclsCoverageRiskHeader.frmFor,
                                                objclsCoverageRiskHeader.ClassId,
                                                objclsCoverageRiskHeader.SubClassId,
                                                objclsCoverageRiskHeader.MainHeader,
                                                objclsCoverageRiskHeader.TitleDescription,
                                                objclsCoverageRiskHeader.GroupHeader 
                                                
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyDetails_Header_Template_Mapping_SelectFORLAW", "Pol_PolicyUWCovDetails_Search");

        }


        public DataSet LoadRiskHeaderWithoutUW(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                //objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                //objclsCoverageRiskHeader.BM_TemplateId, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId,
                                                objclsCoverageRiskHeader.frmFor,
                                                objclsCoverageRiskHeader.ClassId,
                                                objclsCoverageRiskHeader.SubClassId

            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyDetails_Header_Template_Mapping_Select", "Pol_PolicyUWCovDetails_Header_Template");
        }

        public DataSet LoadHeader(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                objclsCoverageRiskHeader.BM_TemplateId, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_Mapping_Selectbyorder", "Pol_PolicyUWCovDetails_Header");

        }
        public DataSet UpdateSortOrder(string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={
                                  xmltempDetail
                                };

            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetailsHeader_SortOrder_Update", "Pol_PolicyUWCovDetails_Header");

        }


        public DataSet SaveRiskHeader(clsCoverageRiskHeader objclsCoverageRiskHeader, string ISSaveOrder)
        {
            object[] parameters = new object[] { objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                    objclsCoverageRiskHeader.BM_TemplateId, 
                                                    objclsCoverageRiskHeader.HeaderId, 
                                                    objclsCoverageRiskHeader.frmFor, 
                                                    objclsCoverageRiskHeader.PrintOrder, 
                                                    objclsCoverageRiskHeader.MainHeader, 
                                                    objclsCoverageRiskHeader.TitleDescription, 
                                                    objclsCoverageRiskHeader.User, 
                                                    objclsCoverageRiskHeader.ToIncluded, 
                                                    objclsCoverageRiskHeader.PolicyId, 
                                                    objclsCoverageRiskHeader.PolVersionId ,
                                                    objclsCoverageRiskHeader.GroupHeader,
                                                    ISSaveOrder,
                                                    objclsCoverageRiskHeader.UWID ,
                                                    objclsCoverageRiskHeader.ClassId,
                                                    objclsCoverageRiskHeader.SubClassId 

                                    };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_Mapping_InsertUpdate", "Pol_PolicyUWCovDetails_Header");

        }

        public DataSet AddRiskHeader(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                objclsCoverageRiskHeader.BM_TemplateId, 
                                                objclsCoverageRiskHeader.HeaderId, 
                                                objclsCoverageRiskHeader.frmFor, 
                                                objclsCoverageRiskHeader.PrintOrder, 
                                                objclsCoverageRiskHeader.MainHeader, 
                                                objclsCoverageRiskHeader.TitleDescription, 
                                                objclsCoverageRiskHeader.User, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId ,
                                                objclsCoverageRiskHeader.GroupHeader,
                                                objclsCoverageRiskHeader.ClassId,
                                                objclsCoverageRiskHeader.SubClassId,
                                                objclsCoverageRiskHeader.HeaderDescription,
                                                objclsCoverageRiskHeader.TariffReferenceCode,
                                                objclsCoverageRiskHeader.EffFromDate,
                                                objclsCoverageRiskHeader.EffToDate,
                                                objclsCoverageRiskHeader.ToPrint,
                                                objclsCoverageRiskHeader.ConditionType

                                               
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_Mapping_Insert", "Pol_PolicyUWCovDetails_Header");

        }
        public DataSet AddVesselRiskHeader(string VesselId, clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { VesselId,
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId ,
                                                objclsCoverageRiskHeader.HeaderId, 
                                                objclsCoverageRiskHeader.MainHeader, 
                                                objclsCoverageRiskHeader.TitleDescription,
                                                objclsCoverageRiskHeader.frmFor, 
                                                objclsCoverageRiskHeader.User, 
                                                objclsCoverageRiskHeader.UWID 
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyVesselUWCovDetails_Header_Mapping_Insert", "Pol_PolicyUWCovDetails_Header");

        }
        public DataSet GetPolicyUnderwriterPlans(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UWPlans_Select", "UnderwriterPlanList");
        }

        public DataSet GetPolicyDetails(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_pol_policyCNDetail_PolicyDetails", "pol_policyCNDetail");
        }

        public DataSet GetProductDetails(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_ProductDetails", "pol_policyMaster");
        }

        public DataSet GetPolicyIHPlans(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "GetIHPlanName_Sp", "IHPlanList");
        }

        public DataSet SavePolicyUnderwriterPlans(clsPolicyUnderwriterPlans objUWPlans)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[7] {  
                                                    objUWPlans.PolicyId,
                                                    objUWPlans.PolVersionId,
                                                    objUWPlans.UWPlanId,
                                                    objUWPlans.PolPlanId,
                                                    objUWPlans.PlanName,
                                                    objUWPlans.User,
                                                    objUWPlans.IsStdBSL
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UWPlans_InsertUpdate", "UnderwriterPlanList");
        }
        public void DeletePolicyUnderwriterPlans(clsPolicyUnderwriterPlans objUWPlans)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[3] {  
                                                    objUWPlans.UWPlanId,
                                                    objUWPlans.PolPlanId,
                                                    objUWPlans.User
            
                                                };
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UWPlans_Delete", "UnderwriterPlanList");
            dataAccessDS.ExecuteNonQuery("P_Pol_PolicyMaster_UWPlans_Delete", parameters);
        }
        public DataSet GetPolicyAnnPremSec1(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.VessedId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAnnPremSec1_Select", "Pol_PolicyAnnPremSec1");

        }
        public DataSet GetPolicyVesselAnnPremSec1(clsQuotation objQuotation, string VesselId)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.UnderwriterId, VesselId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyVesselAnnPremSec1_Select", "Pol_PolicyVesselAnnPremSec1");

        }
        public DataSet GetPolicyAnnPremSec2(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAnnPremSec2_Select", "Pol_PolicyAnnPremSec2");

        }
        public DataSet GetAllCurrency(long policyId, int polVersionId, string code, string Name)
        {
            object[] parameters = new object[] { policyId, polVersionId, code, Name };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Adm_Currency", "CurrencyList");

        }
        public DataSet SaveAnnualPremSec1(long PolicyId, int PolVersionId, string xmlData)
        {
            object[] parameters = new object[3] {PolicyId,
                                                PolVersionId,
                                                xmlData };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_AnnualPremSec1_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveAnnualPremSec2(long PolicyId, int PolVersionId, string xmlData)
        {
            object[] parameters = new object[3] {PolicyId,
                                                PolVersionId,
                                                xmlData };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_AnnualPremSec2_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SavePremiumDetail(clsQuotation objclsQuotation, clsPolicyUnderwriter objUnderwriter)  //changed by megha to merge Aasai changes
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objUnderwriter.UWId, //added by megha to merge Aasai changes
                                                 objUnderwriter.VesselId,
                                                 objclsQuotation.BaseDay,
                                                 objclsQuotation.TotalDay,
                                                 objclsQuotation.Currency,
                                                 objclsQuotation.SumInsured,
                                                 objclsQuotation.Rate,
                                                 objclsQuotation.SumInsuredLocalCurr,
                                                 objclsQuotation.Multiplier,
                                                 objclsQuotation.PremiumLocalCurr,
                                                 objclsQuotation.TotalPremium,
                                                 objclsQuotation.AdditionalPremium,
                                                 objclsQuotation.ClientDiscount,
                                                 objclsQuotation.ClientDiscountRate,
                                                 objclsQuotation.TotalSurcharge,
                                                 objclsQuotation.TotalPremiumSurcharge,
                                                 objclsQuotation.SpecialDiscount,
                                                 objclsQuotation.SpecialDiscountRate,
                                                 objclsQuotation.DueFromClient,
                                                 objclsQuotation.HandlingFeePercent,
                                                 objclsQuotation.HandlingFeeAmount,
                                                objclsQuotation.MultipleBillPayor,
                                                objclsQuotation.Installments,
                                                objclsQuotation.NoOfInstallments,
                                                objclsQuotation.MultipleLocations,
                                                objclsQuotation.BillingRemarks,
                                                objclsQuotation.UWTotalShare,
                                                objclsQuotation.UWTotalSharedPremium,
                                                objclsQuotation.UWTotalBrokerage,
                                                objclsQuotation.UWTotalFees,
                                                 objclsQuotation.User,
                                                 objUnderwriter.ID, //added by megha to merge Aasai changes
                                                 objclsQuotation.Currency,
                                                 objclsQuotation.SumInsured,
                                                 objclsQuotation.Rate,
                                                 objclsQuotation.SumInsuredLocalCurr,
                                                objclsQuotation.TotalPremium,
                                                objclsQuotation.PremiumLocalCurr, //till here
                                                objclsQuotation.ManualOverwritePremium,
                                                objUnderwriter.TotalPremiumLAW,
                                                objUnderwriter.StDutyLAW,
                                                objUnderwriter.TaxTypeLAW,
                                                objUnderwriter.TaxLAW,
                                                objUnderwriter.SpDiscLAW,
                                                objUnderwriter.WHTPercentLAW,
                                                objUnderwriter.NetPayLAW,
                                                objUnderwriter.TaxLawrdb,
                                                objUnderwriter.StDutyLAWAmt,
                                                objUnderwriter.PolicyCharge ,
                                                objUnderwriter.InsurerGSTPer,
                                                objUnderwriter.InsurerGSTPerId,
                                                objUnderwriter.InsurerGSTAmount ,
                                                objUnderwriter.ServiceFee ,
                                                objUnderwriter.ServiceFeeGSTPer ,
                                                objUnderwriter.ServiceFeeGSTPerId ,
                                                 objUnderwriter.ServiceFeeGSTAmount ,
                                                  objUnderwriter.StampDuty ,
                                                   objUnderwriter.SpDiscPerLAW,
                                                   objUnderwriter.NettPremium,
                                                objUnderwriter.NCDPer,
                                                objUnderwriter.NCDAmount,
                                                objUnderwriter.LoadingByInsurerPer,
                                                objUnderwriter.LoadingByInsurerAmt,
                                                objUnderwriter.DiscountByInsurerPer,
                                                objUnderwriter.DiscountByInsurerAmt,
                                                objUnderwriter.OtherCharges,
                                                objUnderwriter.DisplayIn,
                                                objUnderwriter.ServiceFeeType,
                                                objUnderwriter.OtherChargesFeeType,
                                                 objclsQuotation.PremiumBase
                                                 };
            dataAccessDS = new DataAccess();
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_PremiumDetails_InsertUpdate", "Pol_PolicyMaster");
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UnderwriterPremiumDetails_InsertUpdate", "Pol_PolicyMaster");

        }

        public DataSet SavePremiumUWDetail(long PolicyId, int PolVersionId, string xmlFile)
        {
            object[] parameters = new object[] { PolicyId, PolVersionId, xmlFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Premium_PolicyUnderwriter_Update", "Pol_PolicyMaster");

        }

        public DataSet SavePremiumINTDetail(long PolicyId, int PolVersionId, string xmlFile)
        {
            object[] parameters = new object[] { PolicyId, PolVersionId, xmlFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Premium_Intoducer_Update", "Pol_PolicyMaster");

        }

        public DataSet SavePremiumINTDetailEndt(long PolicyId, int PolVersionId, string xmlFile)
        {
            object[] parameters = new object[] { PolicyId, PolVersionId, xmlFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Premium_Intoducer_Update_Endt", "Pol_PolicyMaster");

        }

        public DataSet DeletePolicyAnnPremSec1(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.SecId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyAnnPremSec1_Delete", "Pol_PolicyAnnPremSec1");

        }

        public DataSet getPolicyUWId(int UWid)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { UWid };
            return dataAccessDS.LoadDataSet(parametes, "P_Policy_GetUWID", "PolicyGetUWID");
        }
        public DataSet getPolicyUWCovDetailId(clsPolicyUWCovDetails objclsPolicyUWCovDetails)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objclsPolicyUWCovDetails.PolUWCovId, objclsPolicyUWCovDetails.FieldLabel };
            return dataAccessDS.LoadDataSet(parametes, "P_PolicyUWCovDetailId_SelectbyPolUWCovId_FieldLabel", "PolicyUWCovDetailId");
        }
        public DataSet getLocation(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PolicyUWCovDetails_Pol_Location_Select", "Pol_Location");
        }
        public DataSet getLocationPremium(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[2] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "Pol_Policy_Location_Select", "Pol_LocationPremium");
        }
        public DataSet getPremiumSummary(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[3] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UWCoinsuranceApplicable };
            return dataAccessDS.LoadDataSet(parametes, "Pol_Policy_PremiuarySummary", "PremiuarySummary");
        }
        public DataSet getPremiumSummaryLocal(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[3] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UWCoinsuranceApplicable };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_PremiuarySummaryHKD", "PremiuarySummary");
        }

        //Added for RM #2029
        public DataSet getINTPremiumSummary(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[2] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PremiumINTSummary", "PremiuaryINTSummary");
        }
        // Added for 12165
        public DataSet getINTPremiumSummaryEndt(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[2] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PremiumINTSummaryEndt", "PremiuaryINTSummary");
        }

        public DataSet getPremiumSummaryLocalEndt(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[3] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UWCoinsuranceApplicable };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_PremiuarySummaryHKD_Endt", "PremiuarySummary");
        }

        public DataSet getCompletedPolicy()
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PolicyMaster_PolicyNo", "Pol_PolicyMaster");
        }

        public DataSet getPolicyNo(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objclsQuotation.PolicyNo, objclsQuotation.ItemFor };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PolicyMaster_PolVersionId_Select", "Pol_PolicyMaster");
        }
        public DataSet LoadCopyQuatation(clsQuotation objclsQuotation, int LoginTeamId)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objclsQuotation.SourcePolicyId, objclsQuotation.SourcePolVersionId, objclsQuotation.PolicyId, objclsQuotation.PolVersionId, LoginTeamId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_PolicyMaster_CopyQuotation", "Pol_PolicyMaster");
        }
        public DataSet GetProRataSec1(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_prorataSec1_Select", "Pol_PolicyProRataSec1");

        }
        public DataSet GetProRataSec2(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_prorataSec2_Select", "Pol_PolicyProRataSec2");

        }
        public DataSet CompleteQuotation(clsQuotation objQuotation, string isEB)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.User, isEB, objQuotation.scrfor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Complete", "Pol_PolicyComplete");

        }
        public DataSet QuotedQuotation(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId, objQuotation.User, objQuotation.scrfor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Quote", "Pol_PolicyQuoted");
        }
        public DataSet SaveProRataPremiumUWDetail(long PolicyId, int PolVersionId, string xmlFile)
        {
            object[] parameters = new object[] { PolicyId, PolVersionId, xmlFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_ProRataPremium_PolicyUnderwriter_Update", "Pol_PolicyMaster");

        }
        public DataSet SaveProRataSec1(long PolicyId, int PolVersionId, string xmlData)
        {
            object[] parameters = new object[3] {PolicyId,
                                                PolVersionId,
                                                xmlData };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_ProrataSec1_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveProRataSec2(long PolicyId, int PolVersionId, string xmlData)
        {
            object[] parameters = new object[3] {PolicyId,
                                                PolVersionId,
                                                xmlData };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_ProrataSec2_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveProRataPremiumDetail(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objclsQuotation.ProRataBaseDay,
                                                 objclsQuotation.ProRataTotalDay,
                                                 objclsQuotation.ProRataCurrency,
                                                 objclsQuotation.ProRataPremium,
                                                 objclsQuotation.ProRataAdditionalPremium,
                                                 objclsQuotation.ProRataClientDiscount,
                                                 objclsQuotation.ProRataTotalSurcharge,
                                                 objclsQuotation.ProRataPremiumSurcharge,
                                                 objclsQuotation.ProRataSpecialDiscount,
                                                 //objclsQuotation.ProRataHandlingFeeRate,
                                                 objclsQuotation.ProRataHandlingFeeAmount,
                                                 objclsQuotation.ProRataDueFromClient,
                                                 objclsQuotation.ProRataUWTotalShare,
                                                 objclsQuotation.ProRataUWTotalSharedPremium,
                                                 objclsQuotation.ProRataUWTotalBrokerage,
                                                 objclsQuotation.ProRataUWTotalFees,
                                                 objclsQuotation.User
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_ProRataPremiumDetails_InsertUpdate", "Pol_PolicyMaster");

        }
        public bool IsCompleteQuotation(clsQuotation objclsQuotation)
        {
            DataSet dsResult = new DataSet();
            dsResult = this.LoadQuotationClientDetail(objclsQuotation);
            if (dsResult.Tables["Pol_PolicyMaster"].Rows.Count > 0)
            {
                string isComplete = dsResult.Tables["Pol_PolicyMaster"].Rows[0]["IsComplete"].ToString();
                string Pol_Status = dsResult.Tables["Pol_PolicyMaster"].Rows[0]["Pol_Status"].ToString();
                string PolicyNo = dsResult.Tables["Pol_PolicyMaster"].Rows[0]["PolicyNo"].ToString();
                //if (!string.IsNullOrEmpty(PolicyNo))
                //{
                //    if (isComplete == "True" && Pol_Status != "QPEND" && Pol_Status != "QAMEND" )
                //    //if (isComplete == "True" && Pol_Status != "QPEND" && Pol_Status != "QAMEND" && Pol_Status != "CNPEND")
                //    {
                //        return false; // enable = false
                //    }
                //    else
                //    {
                //        return true;  // enable = true
                //    }

                // }
                //else
                // {
                //    if (isComplete == "True" && Pol_Status != "CNPEND")
                //    //if (isComplete == "True" && Pol_Status != "QPEND" && Pol_Status != "QAMEND" && Pol_Status != "CNPEND")
                //    {
                //        return false; // enable = false
                //    }
                //    else
                //    {
                //        return true;  // enable = true
                //   }

                //}
                if (isComplete == "True" && Pol_Status == "QCOMP")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "QAMEND")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNGEN")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CNPEND")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNAMEN")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNEIP")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNCOMP")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CNRMKT")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CNRIP")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNRINV")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CNEXIP")
                {
                    return true;

                }
                if (isComplete == "True" && Pol_Status == "CNHOLD")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "LAPSED")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CANCIP")
                {
                    return false;

                }
                if (isComplete == "True" && Pol_Status == "CNCANC")
                {
                    return false;

                }

            }
            return true;  // enable = true
        }

        public DataSet GetPolicyID_SelectbyPolUWCovId(clsUWCoverage objclsUWCoverage)
        {
            object[] parameters = new object[] { objclsUWCoverage.PolUWCovId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCoverage_SelectbyPolUWCovId", "Pol_PolicyUWCoverage");


        }
        public DataSet GetPolicyUWPlans(clsPolicyUnderwriterPlans objUWPlan)
        {
            object[] parameters = new object[] { objUWPlan.UWPlanId, objUWPlan.PolicyId, objUWPlan.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_GetPlans", "Pol_PolicyUWPlans");


        }

        public DataSet GetPlansfor(clsPolicyUnderwriterPlans objUWPlan)
        {
            object[] parameters = new object[] { objUWPlan.PlanName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_ADM_Lookup", "Pol_PolicyUWPlans");


        }
        public DataSet GetPolicyEBUWPlanPremRateDetails(long policyId, int polVersionId, clsEBPolicyUnderwriterPlans objEBUWPlans)
        {
            object[] parameters = new object[] { policyId,
                                                 polVersionId,
                                                 objEBUWPlans.UWPlanId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EBUWPlanPremRate_Select", "Pol_PolicyUWPlans");


        }
        public DataSet SavePolicyEBUnderwriterPlans(clsEBPolicyUnderwriterPlans objEBUWPlans)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[7] {  
                                                    objEBUWPlans.UWPlanPremRateId,
                                                    objEBUWPlans.PolPlanId,
                                                    objEBUWPlans.UWPlanId,
                                                    objEBUWPlans.PlanFor,
                                                    objEBUWPlans.User,
                                                    objEBUWPlans.PolicyId,
                                                    objEBUWPlans.PolVersionId
            
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EBUWPlan_InsertUpdate", "UnderwriterPlanList");
        }
        public DataSet SaveEBUWPlanPremRateDetail(string xmlFile, string user)
        {
            object[] parameters = new object[2] { xmlFile, user };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Premium_EBPolicyUWPlanPremRate_Update", "Pol_PolicyUWPlanPrem");

        }
        public void DeleteEBUWPlanPremRate(clsEBPolicyUnderwriterPlans objEBUWPlans)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] {  
                                                    objEBUWPlans.UWPlanPremRateId
                                                    
                                                };
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UWPlans_Delete", "UnderwriterPlanList");
            dataAccessDS.ExecuteNonQuery("P_Pol_Policy_EBUWPlanPremRate_Delete", parameters);
        }
        public DataSet GetPolicyEBUnderwriterDetail(long policyId, int polVersionId, clsEBPolicyUnderwriterPlans objEBUWPlans)
        {
            object[] parameters = new object[] { policyId,
                                                 polVersionId,
                                                 objEBUWPlans.UWPlanId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_GetEBUnderwriterDetail", "Pol_PolicyUWPlans");


        }
        public DataSet GetPolicyAdditionalPrem(clsAdditionprem objAddPrem)
        {
            object[] parameters = new object[] { objAddPrem.PolicyId,
                                                 objAddPrem.PolVersionId,
                                                 objAddPrem.UWId,
                                                 objAddPrem.ID 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Pol_Policy_AdditionalPrem_select", "Pol_PolicyAddPrem");


        }
        public DataSet SavePolicyAdditionalPrem(long policyId, int polVersionId, string xmlData)
        {
            object[] parameters = new object[] { policyId,
                                                 polVersionId,                                                 
                                                 xmlData
                                                 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_AdditionalPrem_InsertUpdate", "Pol_PolicyAddPrem");


        }
        public DataSet SavePolicyAdditionalPrem(long policyId, int polVersionId, int UWId, int ID, string xmlData)
        {
            object[] parameters = new object[] { policyId,
                                                 polVersionId,                                   
                                                 UWId,
                                                 ID ,
                                                 xmlData
                                                 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_AdditionalPrem_InsertUpdate", "Pol_PolicyAddPrem");


        }
        public void DeletePolicyAddPrem(clsAdditionprem objAddPrem)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] {  
                                                   objAddPrem.PolicyAddnlPremId
                                                    
                                                };
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UWPlans_Delete", "UnderwriterPlanList");
            dataAccessDS.ExecuteNonQuery("P_Pol_Policy_AdditionalPrem_Delete", parameters);
        }
        public DataSet GetUWPlanPremRatesDetailSummary(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UnderwriterId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWPlanPremRatesDetailSummary_Select", "Pol_PolicyUWPlanPremRatesDetailSummary");

        }
        public DataSet GetUWPlanPremRatesDetailSummaryReport(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UnderwriterId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWPlanPremRatesDetailSummary_Report_Test", "Pol_PolicyUWPlanPremRatesDetailSummary");
            //return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWPlanPremRatesDetailSummary_Report", "Pol_PolicyUWPlanPremRatesDetailSummary");

        }
        public DataSet GetAccountHandlers(int userId)
        {
            object[] parameters = new object[] { userId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_GetAccountHandlers", "Pol_PolicyAccHandlers");

        }

        //Added by Apurva for Redmine #35903
        public DataSet GetPrimaryAccountHandlers(int userId)
        {
            object[] parameters = new object[] { userId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_GetPrimaryAccountHandlers", "Pol_PolicyAccHandlers");

        }

        public DataSet GetRenewalLapsedReason()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_GetRenewalLapsedMaster", "TM_RenewalLapsedMaster");

        }

        public DataSet GetAccountHandlersForMailSend()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_GetAccountHandlersForMailSend", "Pol_PolicyAccHandlers");

        }
        public DataSet UpdateMailToAccountHandler(int userId)
        {
            object[] parameters = new object[] { userId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_AccountHandlersForMailSendUpdate", "TM_UserMaster");
        }

        public DataSet GetMailToAccountHandler(int userId)
        {
            object[] parameters = new object[] { userId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_MailToAccountHandler", "MailToAccountHandler");
        }


        public DataSet GetQuotationStatusUnderwriter(clsQuotedStatus objclsQuotedStatus)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objclsQuotedStatus.PolicyId, objclsQuotedStatus.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyQuotedStatus_UW_Select", "Pol_PolicyQuotedStatus");
        }

        public DataSet SaveQuotationStatusUnderwriter(clsQuotedStatus objclsQuotedStatus)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {  objclsQuotedStatus.QuotedStatusId,
            objclsQuotedStatus.PolicyId ,
            objclsQuotedStatus.PolVersionId ,
            objclsQuotedStatus.PolUWId ,
            objclsQuotedStatus.RepliedDate,
            objclsQuotedStatus.QuotedStatus ,
            objclsQuotedStatus.Rate,
            objclsQuotedStatus.Premium ,
            objclsQuotedStatus.Interest ,
            objclsQuotedStatus.SumInsured,
            objclsQuotedStatus.QuotedStatusRemarks ,
            objclsQuotedStatus.IsActive,
            objclsQuotedStatus.User,
            objclsQuotedStatus.DeductibleExcess,
            objclsQuotedStatus.Brokerage
            };

            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyQuotedStatus_UWDetails_InsertUpdate", "Pol_PolicyQuotedStatus");
        }

        public DataSet GetQuotationStatusCL(clsQuotedStatus objclsQuotedStatus)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objclsQuotedStatus.PolicyId, objclsQuotedStatus.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyQuotedStatus_CL_Select", "Pol_PolicyQuotedStatusClient");
        }

        public DataSet SaveQuotationStatusCL(clsQuotedStatus objclsQuotedStatus)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {  objclsQuotedStatus.QuotedStatusId,
            objclsQuotedStatus.PolicyId ,
            objclsQuotedStatus.PolVersionId ,
            objclsQuotedStatus.QuotedStatus ,
            objclsQuotedStatus.QuotedStatusRemarks ,
            objclsQuotedStatus.IsActive,
            objclsQuotedStatus.User};

            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyQuotedStatusClient_InsertUpdate", "Pol_PolicyQuotedStatusClient");
        }

        public DataSet GetQuotationUWPreferrence(clsQuotationUWPreferrence objclsQuotationUWPreferrence)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objclsQuotationUWPreferrence.PolicyId, objclsQuotationUWPreferrence.PolVersionId };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWPreferrence_Select", "Pol_PolicyUWPreferrence");
        }

        public DataSet SaveQuotationUWPreferrence(clsQuotationUWPreferrence objclsQuotationUWPreferrence)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {  
            objclsQuotationUWPreferrence.PolicyId ,
            objclsQuotationUWPreferrence.PolVersionId ,
            objclsQuotationUWPreferrence.PolUWId,
            objclsQuotationUWPreferrence.IsPreferred,
            objclsQuotationUWPreferrence.PreferrenceOrder,
            objclsQuotationUWPreferrence.User,
            objclsQuotationUWPreferrence.IsActive
            };

            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWPreferrence_InsertUpdate", "Pol_PolicyUWPreferrence");
        }
        public DataSet GetPolicyUnderwriterAnnPremSec1(clsAnnualPremSec1 objAnnSec1)
        {
            object[] parameters = new object[] { objAnnSec1.PolicyId, objAnnSec1.PolVersionId, objAnnSec1.UWId, objAnnSec1.ID, objAnnSec1.CoverageType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriterAnnPremSec1_Select", "Pol_PolicyAnnPremSec1");

        }

        public DataSet GetPolicyVesselUnderwriterAnnPremSec1(clsAnnualPremSec1 objAnnSec1, string VesselId)
        {
            object[] parameters = new object[] { objAnnSec1.PolicyId, objAnnSec1.PolVersionId, objAnnSec1.UWId, objAnnSec1.ID, objAnnSec1.CoverageType, VesselId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyVesselUnderwriterAnnPremSec1_Select", "Pol_PolicyVesselAnnPremSec1");

        }
        public DataSet GetPolicyUnderwriterAnnPremSec2(clsAnnualPremSec2 objAnnSec2)
        {
            object[] parameters = new object[] { objAnnSec2.PolicyId, objAnnSec2.PolVersionId, objAnnSec2.UWId, objAnnSec2.ID, objAnnSec2.CoverageType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriterAnnPremSec2_Select", "Pol_PolicyAnnPremSec2");

        }
        public DataSet GetPolicyUnderwriterById(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId, objPolicyUnderwriter.UWId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_SelectById", "P_Pol_PolicyUnderwriters");
        }
        public DataSet SaveUnderwriterPremiumDetail(clsQuotation objclsQuotation, clsPolicyUnderwriter objUnderwriter)
        {
            object[] parameters = new object[] { 
                                                objclsQuotation.PolicyId,
                                                objclsQuotation.PolVersionId,
                                                objUnderwriter.UWId,
                                                objUnderwriter.VesselId,
                                                objclsQuotation.BaseDay,
                                                objclsQuotation.TotalDay,
                                                objUnderwriter.UWCurrency,
                                                objUnderwriter.UWSumInsured,
                                                objUnderwriter.UWRate,
                                                objUnderwriter.UWSumInsuredLocalCurr,
                                                objUnderwriter.UWMultiplier,
                                                objUnderwriter.UWPremiumLocalCurr,
                                                objUnderwriter.UWTotalPremium,
                                                objUnderwriter.UWAdditionalPremium,
                                                objUnderwriter.UWClientDiscount,
                                                objUnderwriter.UWClientDiscountRate,
                                                objUnderwriter.UWTotalSurcharge,
                                                objUnderwriter.UWTotalPremiumSurcharge,
                                                objUnderwriter.UWSpecialDiscount,
                                                objUnderwriter.UWSpecialDiscountRate,
                                                objUnderwriter.UWDueFromClient,
                                                objUnderwriter.UWHandlingFeeRate,
                                                objUnderwriter.UWHandlingFeeAmount,
                                                objclsQuotation.MultipleBillPayor,
                                                objclsQuotation.Installments,
                                                objclsQuotation.NoOfInstallments,
                                                objclsQuotation.MultipleLocations,
                                                objclsQuotation.BillingRemarks,
                                                objclsQuotation.UWTotalShare,
                                                objclsQuotation.UWTotalSharedPremium,
                                                objclsQuotation.UWTotalBrokerage,
                                                objclsQuotation.UWTotalFees,
                                                objclsQuotation.User,
                                                objUnderwriter.ID,
                                                objUnderwriter.UWCurrency,
                                                objUnderwriter.UWSumInsured,
                                                objUnderwriter.UWRate,
                                                objUnderwriter.UWSumInsuredLocalCurr ,
                                                objUnderwriter.UWTotalPremium,
                                                objUnderwriter.UWPremiumLocalCurr,
                                                objclsQuotation.ManualOverwritePremium,
                                                objUnderwriter.TotalPremiumLAW,
                                                objUnderwriter.StDutyLAW, 
                                                objUnderwriter.TaxTypeLAW ,
                                                objUnderwriter.TaxLAW ,
                                                objUnderwriter.SpDiscLAW, 
                                                objUnderwriter.WHTPercentLAW ,
                                                objUnderwriter.NetPayLAW,
                                                objUnderwriter.TaxLawrdb,
                                                objUnderwriter.StDutyLAWAmt,
                                                objUnderwriter.PolicyCharge ,
                                                objUnderwriter.InsurerGSTPer,
                                                objUnderwriter.InsurerGSTPerId,
                                                objUnderwriter.InsurerGSTAmount,
                                                objUnderwriter.ServiceFee,
                                                objUnderwriter.ServiceFeeGSTPer,
                                                objUnderwriter.ServiceFeeGSTPerId,
                                                objUnderwriter.ServiceFeeGSTAmount,
                                                objUnderwriter.StampDuty,
                                                objUnderwriter.SpDiscPerLAW,
                                                objUnderwriter.NettPremium,
                                                objUnderwriter.NCDPer,
                                                objUnderwriter.NCDAmount,
                                                objUnderwriter.LoadingByInsurerPer,
                                                objUnderwriter.LoadingByInsurerAmt,
                                                objUnderwriter.DiscountByInsurerPer,
                                                objUnderwriter.DiscountByInsurerAmt,
                                                objUnderwriter.OtherCharges,
                                                objUnderwriter.DisplayIn,
                                                objUnderwriter.ServiceFeeType,
                                                objUnderwriter.OtherChargesFeeType,
                                                 objclsQuotation.PremiumBase
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UnderwriterPremiumDetails_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveUnderwriterAnnualPremSec1(long PolicyId, int PolVersionId, string xmlData, int UWId, int ID, string strCoverageType, string VesselId)
        {
            object[] parameters = new object[7] {   PolicyId,
                                                    PolVersionId,
                                                 
                                                    xmlData,
                                                    UWId,   
                                                    ID,
                                                    strCoverageType,
                                                       VesselId
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterAnnualPremSec1_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveUnderwriterAnnualPremSec2(long PolicyId, int PolVersionId, string xmlData, int UWId, int ID, string strCoverageType)
        {
            object[] parameters = new object[6] {PolicyId,
                                                PolVersionId,
                                                xmlData,
                                                UWId   ,   
                                                ID,
                                                strCoverageType};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterAnnualPremSec2_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet GetPolicyUnderwriterProRataSec1(clsProRataSec1 objProRataSec1)
        {
            object[] parameters = new object[] { objProRataSec1.PolicyId, objProRataSec1.PolVersionId, objProRataSec1.UWId, objProRataSec1.ID, objProRataSec1.CoverageType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterProrataSec1_Select", "Pol_PolicyAnnPremSec1");

        }
        public DataSet GetPolicyUnderwriterProRataSec2(clsProRataSec2 objProRataSec2)
        {
            object[] parameters = new object[] { objProRataSec2.PolicyId, objProRataSec2.PolVersionId, objProRataSec2.UWId, objProRataSec2.ID, objProRataSec2.CoverageType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterProrataSec2_Select", "Pol_PolicyAnnPremSec2");

        }
        public DataSet SaveUnderwriterProRataSec1(long PolicyId, int PolVersionId, string xmlData, int UWId, int intId, string strCoverage)
        {
            object[] parameters = new object[6] {PolicyId,
                                                PolVersionId,
                                                xmlData,
                                                 UWId, intId, strCoverage };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterProrataSec1_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveUnderwriterProRataSec2(long PolicyId, int PolVersionId, string xmlData, int UWId, int intId, string strCoverage)
        {
            object[] parameters = new object[6] {PolicyId,
                                                PolVersionId,
                                                xmlData,
                                                 UWId , intId, strCoverage  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_UnderwriterProrataSec2_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SaveProRataUnderwriterPremiumDetail(clsQuotation objclsQuotation, clsPolicyUnderwriter objUnderwriter)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId,
                                                 objclsQuotation.PolVersionId,
                                                 objUnderwriter.UWId,
                                                 objclsQuotation.ProRataBaseDay,
                                                 objclsQuotation.ProRataTotalDay,
                                                 objUnderwriter.UWProRataCurrency,
                                                 objUnderwriter.UWProRataTotalPremium,
                                                 objUnderwriter.UWProRataAdditionalPremium,
                                                 objUnderwriter.UWProRataClientDiscount,
                                                 objUnderwriter.UWProRataTotalSurcharge,
                                                 objUnderwriter.UWProRataPremiumSurcharge,
                                                 objUnderwriter.UWProRataSpecialDiscount,
                                                 //objclsQuotation.ProRataHandlingFeeRate,
                                                 objUnderwriter.UWProRataHandlingFeeAmount,
                                                 objUnderwriter.UWProRataDueFromClient,
                                                 objclsQuotation.ProRataUWTotalShare,
                                                 objclsQuotation.ProRataUWTotalSharedPremium,
                                                 objclsQuotation.ProRataUWTotalBrokerage,
                                                 objclsQuotation.ProRataUWTotalFees,
                                                 objclsQuotation.User
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_UnderwriterProRataPremiumDetails_InsertUpdate", "Pol_PolicyMaster");

        }
        public DataSet SavePolicyCoverNoteUnderwriters(clsPolicyUnderwriter objPolicyUnderwriter, string UWIds, int LoginTeamId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[7] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    UWIds,
                                                    objPolicyUnderwriter.User,
                                                    objPolicyUnderwriter.Leader,
                                                    LoginTeamId,
                                                    objPolicyUnderwriter.IsLowtonIH,
               
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverNoteUnderwriters_Insert", "UnderwriterMasterList");
        }
        public DataSet GetUnderwriterByPolicy(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] {  objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_SelectByPolicy", "UnderwritersSelectByPolicy");


        }
        public DataSet GetGridPolicyRowCount(int Attach_ID, string Attach_For, string strCoverageToInclude, clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] {  Attach_ID,Attach_For,strCoverageToInclude,objclsQuotation.PolicyId,
                                                    objclsQuotation.PolVersionId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_GetFileAttachDetails_Policy", "PolicyRowCount");


        }
        public DataSet GetCoverageToInclude(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] {  objclsQuotation.PolicyId,
                                                    objclsQuotation.PolVersionId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_GetCoverageToInclude", "UnderwritersSelectByPolicy");


        }
        public DataSet GetPolicyTypePrem(clsQuotation objclsQuotation, string InsurdRefNo)
        {
            object[] parameters = new object[] {  objclsQuotation.PolicyId,
                                                    objclsQuotation.PolVersionId,InsurdRefNo};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_GetIHPolicyPrem", "UnderwritersSelectByPolicy");


        }

        public DataSet LoadRiskLocationDeatils(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  objclsRiskLocations.PolicyId,
                                                    objclsRiskLocations.PolVersionId,
                                                    objclsRiskLocations.LocationId,
                                                    objclsRiskLocations.Mode
                                                    ,objclsRiskLocations.LocationDescription
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_GetRiskLocationDetails", "GetRiskLocationDetails");

        }
        public DataSet SaveRiskLocationDeatils(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.LocationDescription,
                                                objclsRiskLocations.Address1,
                                                objclsRiskLocations.Address2,
                                                objclsRiskLocations.Address3,
                                                  objclsRiskLocations.Address4,
                                                objclsRiskLocations.Country,
                                                  objclsRiskLocations.State,
                                                objclsRiskLocations.UserId,
                                                objclsRiskLocations.POIFromDate,
                                                objclsRiskLocations.POIToDate
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocations_InsertUpdate", "RiskLocationsInsertUpdate");

        }
        public DataSet SaveRiskLocationInterestDeatils(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.InterestDescription,
                                                objclsRiskLocations.UserId
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocationsInterest_InsertUpdate", "RiskLocationsInterestInsertUpdate");

        }

        public DataSet SaveRiskLocationInterestDeatilsNew(clsRiskLocationsInterest objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.InterestDescription,
                                                objclsRiskLocations.UserId,
                                                objclsRiskLocations.InterestHeader,
                                                objclsRiskLocations.SumInsured,
                                                objclsRiskLocations.Valuation,
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocationsInterest_InsertUpdateNew", "RiskLocationsInterestInsertUpdate");

        }

        public DataSet DeleteRiskLocationInterestDeatils(clsRiskLocationsInterest objclsRiskLocations, string Mode)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.InterestId,
                                                objclsRiskLocations.LocationId,
                                                Mode
                                               
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocations_InterestDelete", "RiskLocationsInterestInsertUpdate");

        }


        public DataSet DeleteRiskLocationInterestDeatils(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.LocationId,
                                                objclsRiskLocations.InterestId,
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocationsInterest_Delete", "RiskLocationsInterestDelete");

        }
        public DataSet SaveEngineeringDeatils(clsEngineeringDetails objclsEngineeringDetails)
        {
            object[] parameters = new object[] {  
                                                 objclsEngineeringDetails.PolicyId,
                                                 objclsEngineeringDetails.PolVersionId,
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
                                                 objclsEngineeringDetails.UserId,
                                                 objclsEngineeringDetails.LimitOfLiabilty

                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_EngDetails_InsertUpdate", "EngDetailsInsertUpdate");

        }
        public DataSet LoadEngineeringDeatils(clsEngineeringDetails objclsEngineeringDetails)
        {
            object[] parameters = new object[] {  
                                                 objclsEngineeringDetails.PolicyId,
                                                 objclsEngineeringDetails.PolVersionId,
                                                 objclsEngineeringDetails.EngDetailId,
                                                 objclsEngineeringDetails.Mode,
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_EngDetails_GetData", "GetData");

        }

        public DataSet GetRiskLocationBilling(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocations_GetBillingInfo", "RiskLocationsGetBillingInfo");
        }

        public DataSet UpdateRiskLocationBilling(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] {  
                                                objclsRiskLocations.PolicyId,
                                                objclsRiskLocations.PolVersionId,
                                                objclsRiskLocations.MultipleBilling,
                                                objclsRiskLocations.subClassBilling
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_RiskLocations_UpdateBillingInfo", "RiskLocationsUpdateBillingInfo");

        }

        public DataSet LoadCoverageType(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] {  objclsQuotation.PolicyId,
                                                    objclsQuotation.PolVersionId,
                                                    objclsQuotation.scrfor
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PremiumDetails_GetCoverageDetails", "GetCoverageDetails");

        }
        public DataSet LoadConditionWarratyMajorExclusionInitialValues(clsPolicyUnderwriter objPolicyUnderwriter, string scrFor, int classid, int subclassid)
        {
            object[] parameters = new object[] {objPolicyUnderwriter.PolicyId,
                                                objPolicyUnderwriter.PolVersionId,
                                                objPolicyUnderwriter.UWId,
                                                scrFor,
                                                classid,
                                                subclassid 
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_LoadCWMEInitialValues", "LoadCWMEInitialValues");


        }
        public DataSet LoadConditionWarratyMajorExclusionInitialValuesLAW(clsPolicyUnderwriter objPolicyUnderwriter, string scrFor)
        {
            object[] parameters = new object[] {objPolicyUnderwriter.PolicyId,
                                                objPolicyUnderwriter.PolVersionId,
                                                objPolicyUnderwriter.UWId,
                                                scrFor
                                                
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Underwriters_LoadCWMEInitialValues", "LoadCWMEInitialValues");


        }
        public DataSet DeleteAllTemplateDetailsByUnderwriter(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { 
                                                objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                objclsCoverageRiskHeader.PolicyId, 
                                                objclsCoverageRiskHeader.PolVersionId, 
                                                objclsCoverageRiskHeader.frmFor 
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_Header_Mapping_DeleteAll", "DeleteAll");

        }
        public DataSet GetPolicyVesselUnderwriterTotalPremiumId(clsPolicyUnderwriter objPolicyUnderwriter, string VesselId)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID ,
                                                VesselId 
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyVesselUnderwriters_GetTotalPremiumByID", "GetTotalPremiumByID");

        }
        public DataSet GetPolicyUnderwriterTotalPremiumId(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID ,
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_GetTotalPremiumByID", "GetTotalPremiumByID");

        }
        public DataSet GetPolicyUnderwriterTotalPremiumIdBilling(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.UWId ,
                                                objPolicyUnderwriter.ID ,
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_GetTotalPremiumByID_Billing", "GetTotalPremiumByID");

        }
        public DataSet GetPolicyRiskLocationProrataDays(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            object[] parameters = new object[] { 
                                                objPolicyUnderwriter.PolicyId, 
                                                objPolicyUnderwriter.PolVersionId, 
                                                objPolicyUnderwriter.ID ,
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_RiskLocationProrataDays", "RiskLocationProrataDays");

        }
        public DataSet GetTransLogDetails(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { 
                                                objclsQuotation.PolicyId, 
                                                objclsQuotation.PolVersionId, 
                                                objclsQuotation.ClientId,
                                                objclsQuotation.TransLogID,
                                                objclsQuotation.TransLogEndorseID,
                                                objclsQuotation.TblPrimaryKeysValues,
                                                objclsQuotation.MCDFor
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TransLogDetail_Select", "TM_TransLogDetail");

        }
        public DataSet GetTransLogEndorseDetails(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { 
                                                objclsQuotation.PolicyId, 
                                                objclsQuotation.PolVersionId, 
                                                objclsQuotation.TransLogID
                                            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TransLogEndorseDetail_Select", "TM_TransLogEndorseDetail");

        }
        public DataSet GetPolicyEBUWPlanPrem(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, 
                                                objclsQuotation.PolVersionId
                                                 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EBPolicyUWPlanPrem_Select", "Pol_PolicyUWPrem");


        }
        public DataSet GetPolicyPrintSlip(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyPrintSlip_Select", "Pol_PolicyMaster");
        }
        public DataSet SavePolicyPrintSlipFields(clsQuotation objclsQuotation, string PrintFields)
        {
            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.User, PrintFields };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyPrintSlipFields_Update", "Pol_PolicyMaster");

        }
        public DataSet GetPolicyPrintSlipData(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.DateFormat };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyPrintSlipData_Select", "Pol_PolicyMaster");
        }
        public DataSet GetPolicyPrintSlipUserDefinedFields(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyPrintSlipUserDefinedFields_Select", "Pol_PolicyMaster");
        }
        public DataSet SavePolicyPrintSlipCoverageFields(clsQuotation objclsQuotation, string FieldLabel, int TemplateId)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, FieldLabel, TemplateId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyPrintSlipCoverageFields_Update", "Pol_PolicyMaster");
        }

        public DataSet GetClaimValidation(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.CoverNoteNo, objclsQuotation.PlanNames };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_CovernotePlan_select", "ClaimUpload");
        }

        public DataSet GetCoverNoteInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.CoverNoteNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_CoverNoteInfoSelect", "ClaimUpload");
        }

        public DataSet GetItemInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.ItemFor, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemark_Select", "pol_PolicyCovExcessRemark");
        }

        public DataSet SaveItemInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.PolicyId, objclsQuotation.PolVersionId, 
                objclsQuotation.ItemFor,objclsQuotation.OrderNo,objclsQuotation.ItemText, objclsQuotation.RowCellText, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemark_InsertUpdate", "pol_PolicyCovExcessRemark");
        }

        public DataSet RemoveItemInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.PolicyId, objclsQuotation.PolVersionId, 
                objclsQuotation.ItemFor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemark_Delete", "pol_PolicyCovExcessRemark");
        }

        public DataSet SaveCoverageSectionInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.PolicyId, objclsQuotation.PolVersionId, 
                objclsQuotation.ItemFor,objclsQuotation.RowType, objclsQuotation.HeaderCellText, objclsQuotation.RowCellText,objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSection_Insert", "Pol_PolicyCoverageSection");
        }
        public DataSet SaveRowCoverageSectionInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.RowId,objclsQuotation.ItemId, objclsQuotation.PolicyId, objclsQuotation.PolVersionId, 
                objclsQuotation.ItemFor,objclsQuotation.RowType,objclsQuotation.RowCellText,objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSectionRow_Insert", "Pol_PolicyCoverageSection");
        }

        public DataSet GetCoverageSectionInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.ItemFor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSection_Select", "Pol_PolicyCoverageSection");
        }

        public DataSet GetCoverageSubSectionInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.TableId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyCoverageSubSection_SelectAll", "Pol_PolicyCoverageSubSection");
        }

        public DataSet SaveCoverageSubSectionInfo(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.RowId, objclsQuotation.ItemId, objclsQuotation.TableId,objclsQuotation.PolicyId,objclsQuotation.PolVersionId,objclsQuotation.RowType,
                objclsQuotation.Field1, objclsQuotation.Field2, objclsQuotation.Field3, objclsQuotation.Field4, objclsQuotation.Field5, objclsQuotation.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_Insert", "Pol_PolicyCoverageSubSection");
        }

        public DataSet GetCoverageSubSection(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyCoverageSubSection_Select", "Pol_PolicyCoverageSubSection");
        }

        public DataSet RemoveCoverageSubSection(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.TableId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_Delete", "Pol_PolicyCoverageSubSection");
        }
        public DataSet RemoveCoverageSubSectionRow(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.ItemId, objclsQuotation.TableId, objclsQuotation.RowId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_DeleteRow", "Pol_PolicyCoverageSubSection");
        }

        public DataSet GetPrintHeaderFooter(clsQuotation objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            string[] Tables = { "CompanyFooter", "BranchFooter", "PrintLogo" };
            return dataAccessDS.LoadDataSets(parameters, "P_PrintHeaderFooter_Select", Tables);
        }


        //
        public void SqlInsertDataTableWithParamNew(string con, DataTable dtTableName, clsRiskLocations objclsRiskLocations)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_Pol_RiskLocations_BulkInsertNew", sqlcon);
                //SqlCommand scCmd = new SqlCommand("P_Pol_RiskLocations_BulkInsert", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_Location_Item1", SqlDbType.Structured);
                //  SqlParameter param = new SqlParameter("Type_Location_Item", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]{
                    new SqlParameter("@PolicyId", objclsRiskLocations.PolicyId ),
                    new SqlParameter("@PolVersionId", objclsRiskLocations.PolVersionId),
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




        public void SqlInsertDataTableWithParam(string con, DataTable dtTableName, clsRiskLocations objclsRiskLocations)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_Pol_RiskLocations_BulkInsert", sqlcon);
                //SqlCommand scCmd = new SqlCommand("P_Pol_RiskLocations_BulkInsert", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_Location_Item", SqlDbType.Structured);
                //  SqlParameter param = new SqlParameter("Type_Location_Item", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]{
                    new SqlParameter("@PolicyId", objclsRiskLocations.PolicyId ),
                    new SqlParameter("@PolVersionId", objclsRiskLocations.PolVersionId),
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

        public DataSet filldropdownBusinessType()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "sp_BusinessType", "BusinessType");
        }

        public DataSet FillDDLBusinessType(string category)
        {
            object[] parameters = new object[1] { category};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "GetBusinessType", "BusinessType");
        }
        public DataSet filldropdownVesselStatus()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "sp_VesselStatus", "VesselStatus");
        }
        public DataSet filldropdownBrokerageType(string category)
        {
            Object[] parameters = new Object[1] { category };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_ADM_Lookup", "P_ADM_Lookup");
        }
        public void SqlInsertMotorDataTableWithParam(string con, DataTable dtTableName, clsMotorDetails objMotorDetails)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_Pol_VehicleDetails_BulkInsert", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_VehicleDetails_Item", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]
                {
                    new SqlParameter("@PolicyId", objMotorDetails.PolicyId ),
                    new SqlParameter("@PolVersionId", objMotorDetails.PolVersionId),
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
        public void SqlInsertMotorDataTableWithParamNew(string con, DataTable dtTableName, clsMotorDetails objMotorDetails)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(con);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_Pol_VehicleDetails_BulkInsertNew", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("Type_VehicleDetails_Item1", SqlDbType.Structured);
                param.Value = dtTableName;
                SqlParameter[] tvp = new SqlParameter[]
                {
                    new SqlParameter("@PolicyId", objMotorDetails.PolicyId ),
                    new SqlParameter("@PolVersionId", objMotorDetails.PolVersionId),
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
        public DataSet getPaymentMode(clsQuotation objQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_Policy_PaymentMode", "TM_DebitNotewoCoverNoteDetails");
        }

        public DataTable GetSubClassRenewalType(int subClassId)
        {
            object[] parameters = new object[] { subClassId };
            dataAccessDS = new DataAccess();
            return (dataAccessDS.LoadDataSet(parameters, "P_Get_SubClass_RenewalType", "P_Get_SubClass_RenewalType")).Tables[0];
        }
        public DataTable GetGetPolicyCurrency(clsPolicyUnderwriter objPolicyUnderwriter)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objPolicyUnderwriter.PolicyId, objPolicyUnderwriter.PolVersionId };
            return (dataAccessDS.LoadDataSet(parameters, "P_GetPolicyCurrency", "GetPolicyCurrency")).Tables[0];
        }

        public DataSet GetLocationInterestDescription(clsRiskLocations objclsRiskLocations)
        {
            object[] parameters = new object[] { objclsRiskLocations.PolicyId,
                                                    objclsRiskLocations.PolVersionId
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_BM_LocationInterest_Description", "BM_LocationInterestDescription");
        }
        public SqlDataReader BindLocationInterestDescription(int PolicyId, int PolVersionId)
        {
            DatabaseInteraction dbInteraction = null;
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@PolicyId ", PolicyId);
            dbInteraction.AddParameter("@PolVersionId ", PolVersionId);
            try
            {
                return dbInteraction.getDataReader("P_BM_Get_LocationInterest_Description");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getRiskLocationDetails(clsRiskLocations objclsRiskLocations)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { objclsRiskLocations.PolicyId, objclsRiskLocations.PolVersionId };
            return dataAccessDS.LoadDataSet(parametes, "P_Pol_RiskLocationDetails", "Pol_RiskLocationDetails");
        }

        public DataSet SaveTemplateHeader(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                    objclsCoverageRiskHeader.BM_TemplateId, 
                                                    objclsCoverageRiskHeader.HeaderId, 
                                                    objclsCoverageRiskHeader.frmFor, 
                                                    objclsCoverageRiskHeader.PolicyId, 
                                                    objclsCoverageRiskHeader.PolVersionId ,
                                                    objclsCoverageRiskHeader.GroupHeader,
                                                    objclsCoverageRiskHeader.ClassId,
                                                    objclsCoverageRiskHeader.SubClassId, 
                                                    objclsCoverageRiskHeader.UWID,
                                                    objclsCoverageRiskHeader.User,
                                                    objclsCoverageRiskHeader.ConditionType,
                                                     objclsCoverageRiskHeader.HeaderDescription,
                                                    objclsCoverageRiskHeader.HeaderFullDescription

                                    };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUW_Quotation_Header_Mapping_InsertUpdate", "Pol_PolicyUWCovDetails_Header");

        }

        public DataSet GetPolicyMinimumPremiumAmount(string subclassid, string currencyid, string underwriterid)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[] { subclassid, currencyid, underwriterid };
            return dataAccessDS.LoadDataSet(parametes, "GetInsurerMinimumPremium", "MinimumPremium");
        }

        public DataSet LoadAccountHandlerClientDetail(clsQuotation objclsQuotation)
        {

            object[] parameters = new object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyMaster_AccountHandler_Select", "Pol_PolicyMaster");
        }

        public DataSet CheckMultibillingInsertedData(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_MultiBilling_InsertCheck", "Pol_PolicyMaster");

        }

        public DataSet CheckAmendmentDataValidation(clsQuotation objQuotation)
        {
            object[] parameters = new object[] { objQuotation.PolicyId, objQuotation.PolVersionId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCheckAmendmentValidation_Select", "Pol_PolicyAnnPremSec1");

        }

        public DataSet SaveCopyCoverNoteUnderwriters(clsPolicyUnderwriter objPolicyUnderwriter, string UWIds, int LoginTeamId, string calledfrom)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {   objPolicyUnderwriter.PolicyId,
                                                    objPolicyUnderwriter.PolVersionId,
                                                    UWIds,
                                                    objPolicyUnderwriter.User,
                                                    objPolicyUnderwriter.Leader,
                                                    LoginTeamId,
                                                    objPolicyUnderwriter.IsLowtonIH,
                                                    calledfrom
               
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverNoteUnderwriters_Insert_CopyQuotn", "UnderwriterMasterList");
        }

        public DataSet GetPresavedDescription(clsCoverageRiskHeader objclsCoverageRiskHeader)
        {
            object[] parameters = new object[] { objclsCoverageRiskHeader.PolicyUWCovDetailId, 
                                                    objclsCoverageRiskHeader.BM_TemplateId, 
                                                    objclsCoverageRiskHeader.HeaderId, 
                                                    objclsCoverageRiskHeader.frmFor, 
                                                    objclsCoverageRiskHeader.MainHeader, 
                                                    objclsCoverageRiskHeader.PolicyId, 
                                                    objclsCoverageRiskHeader.PolVersionId ,
                                                    objclsCoverageRiskHeader.UWID ,
                                                    objclsCoverageRiskHeader.ClassId,
                                                    objclsCoverageRiskHeader.SubClassId 

                                    };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Header_Mapping_GetTitleDescription", "Pol_PolicyUWCovDetails_Header");

        }

        public DataSet SecurityUpdateAndSelect(clsQuotation objclsQuotation, string mode)
        {
            object[] parameters = new object[9] {
                 objclsQuotation.PolicyId,
                objclsQuotation.PolVersionId,
                objclsQuotation.UnderwriterId,
                mode,
                objclsQuotation.Security,
                objclsQuotation.SecurityType,
                objclsQuotation.Share_Percent,
                objclsQuotation.Sum_Insured,
                objclsQuotation.Security_Premium
                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Security_UpdateAndSelect", "Security_UpdateAndSelect");

        }


        public DataSet SecurityInsertUpdate(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[11] {
                objclsQuotation.SecurityId,
                objclsQuotation.PolicyId,
                objclsQuotation.PolVersionId,
                objclsQuotation.UnderwriterId,
                objclsQuotation.Security,
                objclsQuotation.SecurityType,
                objclsQuotation.Sum_Insured,
                objclsQuotation.Share_Percent,
                objclsQuotation.Security_Premium,
                objclsQuotation.User,
                objclsQuotation.IsActive
                
                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_UnderwriterSecurity_InsertUpdate", "Pol_UnderwriterSecurity");

        }


        public DataSet GetUnderwriterSecurity(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[4] {
                objclsQuotation.SecurityId,
                objclsQuotation.PolicyId,
                objclsQuotation.PolVersionId,
                objclsQuotation.UnderwriterId,
                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UnderwriterSecurity_Select", "Pol_UnderwriterSecurity");

        }

        public DataSet DeleteUnderwriterSecurity(clsQuotation objclsQuotation)
        {
            object[] parameters = new object[4] {
                objclsQuotation.SecurityId,
                objclsQuotation.PolicyId,
                objclsQuotation.PolVersionId,
                objclsQuotation.UnderwriterId,
                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UnderwriterSecurity_Delete", "Pol_UnderwriterSecurity");

        }

        public DataSet SaveQuotationMemoDetail(clsMemotab objclsQuotation)
        {
            object[] parameters = new object[] {   objclsQuotation.MemoId, objclsQuotation.PolicyId, 
                                                    objclsQuotation.PolVersionId, 
                                                    objclsQuotation.MemoDate, 
                                                    objclsQuotation.Remarks, 
                                                    objclsQuotation.CreatedBy, 
                                                    objclsQuotation.LastUpdatedBy,
                                                    objclsQuotation.IsActive ,
                                                    objclsQuotation.TranType
                                                   
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_PolicyMemo_InsertUpdate", "Pol_PolicyMemoDetails");
        }
        public DataSet getMemoDetailsList(clsMemotab objclsQuotation)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId};
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_MemoDetails", "P_Pol_DemoDetails");
        }

        public DataSet SaveAndDeletePolicyEBSinglePlans(clsEBPolicyUnderwriterPlans objEBUWPlans, String Mode)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {  
                                                    objEBUWPlans.UWPlanPremRateId,
                                                    objEBUWPlans.PolicyId,
                                                    objEBUWPlans.PolVersionId,
                                                    objEBUWPlans.PolPlanId,
                                                    objEBUWPlans.SumInsured,
                                                    objEBUWPlans.PremRate,
                                                    objEBUWPlans.RateBy1000,
                                                    objEBUWPlans.NoOfLives,
                                                    objEBUWPlans.TotalPrem,
                                                    objEBUWPlans.User,
                                                    Mode 
                                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EBSinglePlan_InsertUpdate", "UnderwriterPlanList");
        }

        public DataSet GetSinglePlans(clsEBPolicyUnderwriterPlans objEBUWPlans)
        {
            object[] parameters = new object[3] {
                                                     objEBUWPlans.PolicyId,
                                                    objEBUWPlans.PolVersionId,
                                                    objEBUWPlans.PolPlanId,
                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_EBSinglePlanPremRate_Select", "Pol_UnderwriterSecurity");

        }

        public DataSet SaveEBSinglePlanPremRateDetail(string xmlFile, string user, int PolicyId, int PolversionId, int PolId)
        {
            object[] parameters = new object[5] { xmlFile, user, PolicyId, PolversionId, PolId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_Premium_EBPolicySinglePlanPremRate_Update", "Pol_PolicyUWPlanPrem");

        }


        public DataSet GetPolicyStatusForEndorsementPending(int PolicyId, int PolversionId)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] { PolicyId, PolversionId };
            return dataAccessDS.LoadDataSet(parameters, "P_GetPolicyStatusForEndorsementPending", "P_CN_GetIntroducerDetails");
        }
      
       
    }
}
