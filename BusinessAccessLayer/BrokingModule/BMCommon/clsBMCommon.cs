using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;


namespace BusinessAccessLayer.BrokingModule.BMCommon
{
    public  class clsBMCommon
    {        
        DataAccess dataAccess = new DataAccess();
        public DataSet GetBankDetailForTeleTransfer()
        {
            Object[] parametes = new Object[] {  };
            return dataAccess.LoadDataSet(parametes, "P_TM_GetBankDetailsForTeleTrans", "P_TM_GetBankDetailsForTeleTrans");
        }

        public DataSet GetSchemeType(string calledFrom)
        {
            Object[] parametes = new Object[] { calledFrom };
            return dataAccess.LoadDataSet(parametes, "P_Get_IHPremuimRating_Scheme", "P_Get_IHPremuimRating_Scheme");
        }
        public DataSet GetInterestNew(int intPolicyId, int intPolicyVersionId, string strInterestHeader, string strInterestId, string strMode, int intLocationId)
        {
            Object[] parametes = new Object[6] { intPolicyId, intPolicyVersionId, strInterestHeader, strInterestId, strMode, intLocationId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_RiskLocations_InterestNew", "Interest");
        }

        public DataSet GetDebitNoteWOCoverNoteDefault()
        {
            return dataAccess.LoadDataSet("P_Adm_LoadDebitWOCoverNote", "DebitNoteWOCoverNoteList");
        }
        public DataSet GetSubClassCode(string strMainClassCode)
        {
            Object[] parametes = new Object[] { strMainClassCode,0};
            return dataAccess.LoadDataSet(parametes,"P_Adm_SubClassCode", "LoadSubClassList");
        }

        public DataSet GetSubClassCode(string strMainClassCode, int CompanyId)
        {
            Object[] parametes = new Object[] { strMainClassCode, CompanyId };
            return dataAccess.LoadDataSet(parametes, "P_Adm_SubClassCode", "LoadSubClassList");
        }
        public DataSet GetClient(string strClientCode,string strClientName,string strSelectClientCode)
        {
            Object[] parametes = new Object[3] { strClientCode, strClientName, strSelectClientCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_ClientMaster", "LoadClientList");
        }
        public DataSet GetEBClient(string strClientCode, string strClientName, string strSelectClientCode)
        {
            Object[] parametes = new Object[3] { strClientCode, strClientName, strSelectClientCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_EBClientMaster", "EBClientMaster");
        }
        public DataSet GetEBSubClass()
        {
            return dataAccess.LoadDataSet("P_EBSubClassList", "EBSubClassList");
        }
        public DataSet GetBranch(string strBranchCode, string strBranchName)
        {
            Object[] parametes = new Object[2] { strBranchCode, strBranchName};
            return dataAccess.LoadDataSet(parametes, "P_Adm_BranchMaster", "LoadBranchList");
        }
        public DataSet GetUwriter(string strUWriterCode, string strUWriterName, string strSelectUwriterCode, string strUWriterShortName, string strType)
        {
            Object[] parametes = new Object[5] { strUWriterCode, strUWriterName, strSelectUwriterCode, strUWriterShortName, strType };
            return dataAccess.LoadDataSet(parametes, "P_Adm_UnderWriterMaster", "LoadUWriterList");
        }
        public DataSet GetAgentBroker(string strAgentBrokerCode, string strAgentBrokerName,string strSelectUwriterCode)
        {
            Object[] parametes = new Object[3] { strAgentBrokerCode, strAgentBrokerName ,strSelectUwriterCode};
            return dataAccess.LoadDataSet(parametes, "P_Adm_AgentBrokerMaster", "LoadAgentBrokerList");
        }
        public DataSet GetDiagnosis(string strDiagnosisCode, string strDiagnosisName, string strSelectDiagnosisCode)
        {
            Object[] parametes = new Object[3] { strDiagnosisCode, strDiagnosisName, strSelectDiagnosisCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_DiagnosisMaster", "LoadDiagnosisList");
        }
        public DataSet GetSurgicalProcedure(string strSurgicalProcedureCode, string strSurgicalProcedureName, string strSelectSurgicalProcedureCode)
        {
            Object[] parametes = new Object[3] { strSurgicalProcedureCode, strSurgicalProcedureName, strSelectSurgicalProcedureCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_SurgicalProcedureMaster", "LoadSurgicalProcedureList");
        }
        //Added On 14th May 2015 By Kumar Rituraj
        public DataSet GetLossTypeByClassId(int Classid)
        {
            Object[] parametes = new Object[1] { Classid };
            return dataAccess.LoadDataSet(parametes, "SP_LossTypeMasterBYClass", "LossTypeMaster");
        }
        public DataSet GetLossNatureByClassIdLossType(int Classid,int LossTypeId)
        {
            Object[] parametes = new Object[2] { Classid, LossTypeId };
            return dataAccess.LoadDataSet(parametes, "SP_LossNatureMasterBYClassIdnLosstypeId", "LossNatureMaster");
        }
        public DataSet GetECClaimDefault()
        {
            return dataAccess.LoadDataSet("P_EC_LoadDefaultData", "EC_LoadDefaultData");
        }
        public DataSet GetRNClaimDefaultDefault()
        {
            return dataAccess.LoadDataSet("P_RN_LoadDefaultDataDefault", "RN_LoadDefaultDataDefault");
        }
        public DataSet GetECClaimDetailsDefault()
        {
            return dataAccess.LoadDataSet("P_EC_LoadDefaultClaimDetails", "EC_LoadDefaultClaimDetails");
        }
        public DataSet GetECClaimFollowUpReason()
        {
            return dataAccess.LoadDataSet("p_CA_FollowupReasonMaster_Bind", "CA_FollowupReasonMaster");
        }


        public DataSet GetFollowUp(string strFollowUpCode, string strFollowUpName)
        {
            Object[] parametes = new Object[2] { strFollowUpCode, strFollowUpName};
            return dataAccess.LoadDataSet(parametes, "P_Adm_FollowupReasonMaster", "LoadAgentBrokerList");
        }
        public DataSet GetEBMemberDefault()
        {
            return dataAccess.LoadDataSet("P_EB_LoadMemberDefaultData", "EB_LoadMemberDefaultData");
        }
        public DataSet GetEBMemberOrganisationDefault()
        {
            return dataAccess.LoadDataSet("P_EB_LoadMemberOrganisationData", "EB_LoadMemberOrganisationData");
        }
        public DataSet GetEBMemberRegistrationDefault( string strClientCode)
        {
            Object[] parametes = new Object[] { strClientCode };
            return dataAccess.LoadDataSet(parametes, "P_EB_MemberRegistrationLoadData", "EB_MemberRegistrationLoadData");
        }
        public DataSet GetIHMemberRegistrationDefault(string strmembercode, string strcaseref)
        {
            Object[] parametes = new Object[] { strmembercode, strcaseref  };
            return dataAccess.LoadDataSet(parametes, "P_IH_MemberRegistrationLoadData", "P_IH_MemberRegistrationLoadData");
        }
        
        public DataSet GetEBMemberPaymentDefault()
        {
            return dataAccess.LoadDataSet("P_EB_MemberPaymentDetaultData", "EB_MemberPaymentDetaultData");
        }
        public DataSet GetEBMemberAddressDefault()
        {
            return dataAccess.LoadDataSet("P_EB_GetMemberAddressDefaultData", "EB_GetMemberAddressDefaultData");
        }
        public DataSet GetEBMemberUnderwriterDefault()
        {
            return dataAccess.LoadDataSet("P_EB_MemberUnderwriterDefaultData", "EB_MemberUnderwriterDefaultData");
        }
        public DataSet GetEBClaimDefault()
        {
            return dataAccess.LoadDataSet("P_EB_LoadDefaultData", "EB_LoadDefaultData");
        }

        public DataSet GetEBClaimStatus()
        {
            return dataAccess.LoadDataSet("P_EB_ClaimStatus", "EB_ClaimStatus");
        }
        public DataSet GetEBMemberStatusDefaultData()
        {
            return dataAccess.LoadDataSet("P_EB_MemberStatusDefaultData", "EB_MemberStatusList");
        }
        public DataSet GetInterest(int intPolicyId, int intPolicyVersionId, string strInterestHeader, string strInterestId, string strMode,int intLocationId)
        {
            Object[] parametes = new Object[6] { intPolicyId, intPolicyVersionId, strInterestHeader, strInterestId, strMode, intLocationId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_RiskLocations_Interest", "Interest");
        }
        public Int32 GetNoOfAgents()
        {
            int intRetVal = -1;
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet("EXEC P_GetNoOfAgents");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    intRetVal = Convert.ToInt32(ds.Tables[0].Rows[0]["KeyValue"].ToString());
                }
            }
            return intRetVal;
        }
        public static DataSet getBankDetails(int BankId, int companyId)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { BankId, companyId };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetBankDetails", "BankList");
        }

        public static DataSet getCoverageToIncludeFromTeamId(int teamId)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { teamId };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetCoverageFromTeamId", "CoverageToInclude");
        }
        public string GetCorporateGroupByClientId(string ClientCode)
        {
            string strCGrp = "";
            DataSet ds = new DataSet();
            Object[] parameter = new Object[1] { ClientCode };
            ds = dataAccess.LoadDataSet(parameter,"P_Get_CorpGrpByClientCode","Corporatedesc");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strCGrp = Convert.ToString(ds.Tables[0].Rows[0]["CorpGroupDesc"].ToString());
                }
            }
            return strCGrp;
        }


    }
}
