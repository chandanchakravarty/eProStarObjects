using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessAccessLayer.SystemAdmin.UserSetup;
using BusinessObjectLayer.SystemAdmin.UserSetup;
using System.Globalization;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Web;
using System.Linq;
using BusinessAccessLayer.BrokingModule.BrokingSystem;
using System.Web.UI.WebControls;
using BusinessAccessLayer.SystemAdmin.ClientSetup;
using BusinessAccessLayer.SystemAdmin.AnalysisCode;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;


namespace BusinessAccessLayer.Common
{

    public class clsCommon
    {
        DataRow[] dr;
        DataAccess dataAccess = new DataAccess();
        //Added By Neetu

        public DataSet GetActivityNextStatus(int ActivityRefId, string CurrentStatus)
        {
            DataTable dt = new DataTable();
            Object[] parameters = new Object[2] { ActivityRefId,CurrentStatus };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_GetNextStatus", "P_GetNextStatus");
            return ds;
        }

        public string GetNoOfLevelApprovalRequired(int ActivityRefId)
        {
                         
            object NoOfApproval= dataAccess.GetScalerValue("SELECT ApprovalLevel FROM TM_ApprovalActivities Where ActivityRefID="+Convert.ToString(ActivityRefId));
            return Convert.ToString(NoOfApproval);
        }

        public DataSet GetClientSource(int ClientId)
        {
            object[] parameters = new Object[1] { ClientId };
            return dataAccess.LoadDataSet(parameters, "P_GetClientSourceById", "ClientSourceList");
        }



        public DataSet GetInsurerType(int Id)
        {

            DataTable dt = new DataTable();
            Object[] parameters = new Object[1] { Id };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_GetInsuserType", "TM_Lookups");
            return ds;
        }

        public DataSet GetSecurityType()
        {

            DataTable dt = new DataTable();
            Object[] parameters = new Object[] {};
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_GetSecurityType", "TM_Lookups");
            return ds;


        }

        public DataSet GetInsurerSecurityType(int UWId)
        {

            DataTable dt = new DataTable();
            Object[] parameters = new Object[] { UWId };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_GetInsurerSecurityType", "TM_Lookups");
            return ds;


        }


        public DataSet F_GetLookUpData(string category)
        {
            Object[] parametes = new Object[1] { category };
            string[] tableList ={ 
                "stausType"
            };
            return dataAccess.LoadDataSets(parametes, "P_ADM_Lookup", tableList);
        }
        public DataSet GetFireTariffGroupCode()
        {
            return (new DataAccess()).LoadDataSet("P_TM_FireTariffGroupCode", "TM_FireTariffGroupCode");
        }
        public DataSet GetVehicleDetailMaster()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_IRM_VehicleDetailMaster", "TM_VehicleDetailMaster");
        }
        public DataSet GetMotorcycleType()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_IRM_MotorcycleType", "TM_Lookups");
        }
        public DataSet  Announcement(clsDashBoard obj)
        {

            Object[] parametes = new Object[3] { obj.Title, obj.LoginId, obj.DepartmentId };
           
            return dataAccess.LoadDataSet(parametes, "Sp_AnnouncementBroadcast", "Announcement");
        }
        public DataSet GetCovToInclude(int ClassId, int CompanyId, string classCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { ClassId, CompanyId, classCode };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_SelectCovToInclude", "TM_ClassMaster");
        }
        public DataSet GetCode(string strCode, string strDesc)
        {
            Object[] parametes = new Object[5] { strCode, strDesc, string.Empty, string.Empty, string.Empty };
            return dataAccess.LoadDataSet(parametes, "P_Adm_CodeRunningNo_GeneratorSel", "GetCode");
        }
        public DataSet GetCountry(string countrycode)
        {
            object[] parameters = new Object[1] { countrycode };
            return dataAccess.LoadDataSet(parameters, "P_TM_Country_Select", "GetCountry");
        }

        public DataSet GetNationality()
        {
            object[] parameters = new Object[1] { "N" };
            return dataAccess.LoadDataSet(parameters, "p_TMCountry_sel", "NationalityList");

        }
        public DataSet GetTerritory( int TertId)
        {
            //object[] parameters = new Object[5] {  TertId ,objterritorymaster.EffFrom,objterritorymaster.EffFrom1,objterritorymaster.EffTo,objterritorymaster.EffTo1};
            //return dataAccess.LoadDataSet(parameters, "P_TM_TerritoryMaster_Select", "TerritoryList");
            object[] parameters = new Object[5] { TertId,null,null,null,null };
            return dataAccess.LoadDataSet(parameters, "P_TM_TerritoryMaster_Select", "TerritoryList");
        }
        public DataSet GetTerritoryByCode(string countryCode)
        {
            object[] parameters = new Object[1] { countryCode };
            return dataAccess.LoadDataSet(parameters, "P_TM_TerritoryMaster_SelectByCode", "TerritoryList");
        }
        public DataSet GetOccupation(string OccupationCode)
        {
            object[] parameters = new Object[1] { OccupationCode };
            return dataAccess.LoadDataSet(parameters, "P_TM_Occupation_Select", "Occupation");
        }
        public DataSet GetProvince(int provinceid)
        {
            object[] parameters = new Object[1] { provinceid };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster_Select", "ProvinceList");
        }
        public DataSet GetProvinceByTertID(int TerritoryId)
        {
            object[] parameters = new Object[1] { TerritoryId };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster_SelectByTertId", "ProvinceList");

        }
        public DataSet GetContactType()
        {
            return dataAccess.LoadDataSet("P_TMContactType_Sel", "ContactType");
        }

        public DataSet GetCustomerType()
        {
            return dataAccess.LoadDataSet("P_TMCustomerType_Sel", "Customertype");
        }


        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="RecId"></param>
        /// <param name="RecForId"></param>
        /// <param name="RecFortype"></param>
        /// <returns></returns>
           #region Added by neetu 10jan 2017
        public DataSet CheckForApprovalVisible(string RecId, string RecForId, string RecFortype)
        {
            //Method to Approval button visibility
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { RecId, RecForId, RecFortype };
            return dataAccess.LoadDataSet(parameters, "P_Agent_CheckForApprovalVisible", "pol_Contacts_UnApprovedInfo");
        }
          #endregion


        #region Added  By neetu 13 may 2016
        public DataSet GetIndustryType()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_TM_IndustryTypeMasterGetData", "TM_IndustryTypeMaster");
        }
        //
        public DataSet GetKeyAccountManger()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_TM_UserMaster", "TM_UserMaster");
        }

        //
        public DataSet GetDocumentCompilenace()
        {

            return dataAccess.LoadDataSet("P_TM_DocumentComplianceMaster", "TM_DocumentComplianceMaster");

        }

        //
        public DataSet GetRiskProfile()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_TM_RiskProfileMasterGetData", "TM_RiskProfileMaster");
        }
        #endregion


        //added by kavita kaushik on 12th june
        public DataSet GetDistrictByProvinceID(int TerrId,  int ProvinceId)
        {
            object[] parameters = new Object[2] {TerrId ,ProvinceId };
            return dataAccess.LoadDataSet(parameters, "P_TM_DistrictMaster_SelectByProvinceId", "DistrictList");

        }
        //end

        // Added by Kumar Rituraj on 13th May 2015
        public DataSet GetProvinceByTertCode(string code)
        {
            object[] parameters = new Object[1] { code };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster_SelectByTertCode", "ProvinceList");

        }
        //added by kavita on 19th Dec.
        public DataSet GetCityByProviceID(int territoryId, int ProvinceId)
        {
            object[] parameters = new Object[2] {territoryId, ProvinceId};
            return dataAccess.LoadDataSet(parameters, "P_TM_City_Select", "CityList");

        }
        public DataSet GetDistrictByProviceID(int territoryId, int ProvinceId)
        {
            object[] parameters = new Object[2] { territoryId, ProvinceId };
            return dataAccess.LoadDataSet(parameters, "P_TM_District_Select", "DistrictList");

        }
        public DataSet GetSubDistrictByDistrictID(int territoryId, int ProvinceId, int district)
        {
            object[] parameters = new Object[3] { territoryId, ProvinceId, district};
            return dataAccess.LoadDataSet(parameters, "P_TM_SubDistrict_Select", "SubDistrictList");

        }
        // Added by Kumar Rituraj on 13th May 2015
        public DataSet GetCityByTertCodeProviceID(string terTcode, int ProvinceId)
        {
            object[] parameters = new Object[2] { terTcode, ProvinceId };
            return dataAccess.LoadDataSet(parameters, "P_TM_City_SelectBYTertCode_ProvinceId", "CityList");

        }
        public DataSet GetClass(int classid)
        {
            object[] parameters = new Object[1] { classid };
            return dataAccess.LoadDataSet(parameters, "P_TM_ClassMaster_Select", "MainClassList");
        }
        public DataSet GetCompany(int companyid)
        {
            object[] parameters = new Object[1] { companyid };
            //return dataAccess.LoadDataSet(parameters, "P_TM_CompanyMaster_Select", "CompanyList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet(parameters, "P_TM_CompanyMaster_SelectByCompanyId", "CompanyList");
        }

        public DataSet GetTeam(int teamId)
        {
            object[] parameters = new Object[1] { teamId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamList", "TeamList");
        }

        //public DataSet GetCorpGrpType()
        //{
        //    return (new DataAccess()).LoadDataSet("SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='CorpGrpType' and IsActiveYN='Y' order by Lookup_ID asc", "TM_Lookups");
        //}

        public DataSet BindTeam(int teamId)
        {
            object[] parameters = new Object[1] { teamId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamListBind", "TeamList");
        }
        public DataSet GetScreenElementAccess(string ScreenId, int UserId)
        {
            object[] parameters = new Object[2] { ScreenId, UserId };
            return dataAccess.LoadDataSet(parameters, "Proc_getScreenElementsAccessRights", "ScreenAccessList");
        }
        //public DataSet GetGroupAccess(string groupaccesscd)
        //{
        //    object[] parameters = new Object[1] { groupaccesscd };
        //    return dataAccess.LoadDataSet(parameters, "P_TM_UsrGrpAccessMaster_Select", "GroupList");
        //}
        public DataSet GetGroupAccess(string groupAccessCode)
        {
            object[] parameters = new Object[1] { groupAccessCode };
            //return dataAccess.LoadDataSet(parameters, "P_TM_UsrGrpAccessMaster_Select", "GroupAccessList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet(parameters, "P_TM_UsrGrpAccessMaster_SelectByGrpCode", "GroupAccessList");
        }
        public DataSet GetGrade(int gradeid, string status)
        {
            object[] parameters = new Object[2] { gradeid, status };
            return dataAccess.LoadDataSet(parameters, "P_SysAdm_USetup_GradeSelect", "GradeList");
        }
        public DataSet GetUserApproval(int userid)
        {
            object[] parameters = new Object[0] { };
            //return dataAccess.LoadDataSet(parameters, "P_TM_UserMaster_Select", "UserList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet(parameters, "P_TM_UserMaster_SelectByUserId", "UserList");
        }

        public DataSet GetUserApprovalbyTeam(int teamId)
        {
            object[] parameters = new Object[1] { teamId };
            //return dataAccess.LoadDataSet(parameters, "P_TM_UserMaster_Select", "UserList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet(parameters, "[P_TM_UserMaster_SelectUserByTeamId]", "UserList");
        }
        public DataSet getCurrency()
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[1] { 0 };
            ds = dataAccess.LoadDataSet(parametes, "P_TM_CurrencyMaster_Select", "CurrencySelect");
            return ds;
        }
        public DataSet GetClass()
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { 0 };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_Select", "ClassSelect");
        }
        public DataSet GetSubClass(int subclassid)
        {
            object[] parameters = new Object[1] { subclassid };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassForEmpBenefit_Select", "SubClassList");
        }
        //added by kavita kaushik for Motor, IH, and EB Class
        public DataSet GetSubClassForEB_IH_MT(int subclassid,string classcode)
        {
            object[] parameters = new Object[2] { subclassid ,classcode };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassFor_EB_MT_IH_Select", "SubClassListFor_EB_IH_MT");
        }
        //end
        public DataSet GetSubClassExcess(int classid)
        {
            object[] parameters = new Object[1] { classid };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassMaster_ClassId_Select", "SubClassListOnClassId");
        }
        //Added by Apurva
        public DataSet GetSubClassInvoice(int classid)
        {
            object[] parameters = new Object[1] { classid };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassMaster_Select_Invoice", "SubClassListOnClassId");
        }
        public DataSet GetSubClassEB(int CompId)
        {
            object[] parameters = new Object[1] { CompId };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassMaster_EBByTeam", "SubClassListOnClassId");
        }
        public DataSet GetDepartment(string DepartmentCode, string status)
        {
            object[] parameters = new Object[2] { DepartmentCode, status };
            return dataAccess.LoadDataSet(parameters, "P_Adm_DepartmentList", "DepartmentList");
        }
        public DataSet GetBranch(int BranchId)
        {
            object[] parameters = new Object[1] { BranchId };
            return dataAccess.LoadDataSet(parameters, "P_TM_BranchMaster_Select", "BranchList");
        }
        public DataSet GetCompBranch(int CompanyId)
        {
            object[] parameters = new Object[1] { CompanyId };
            return dataAccess.LoadDataSet(parameters, "P_TM_UserGrpCompBranch_Select", "CompBranchList");
        }
        public DataSet GetUser(int UserId)
        {
            object[] parameters = new Object[1] { UserId };
            return dataAccess.LoadDataSet(parameters, "P_TM_Suspension_Select", "UserList");
        }
        public DataSet GetUserAll(int UserId)
        {
            object[] parameters = new Object[] { };
            //return dataAccess.LoadDataSet(parameters, "P_TM_UserMaster_Select", "UserListAll");
            return dataAccess.LoadDataSet(parameters, "P_TM_UserMaster_SelectByUserId", "UserList");
        }
        public DataSet LoadTemplate(int ClassId)
        {
            object[] parameters = new Object[] { ClassId };
            return dataAccess.LoadDataSet(parameters, "P_TM_TemplateMaster_Select", "TemplateList");
        }
        public DataSet LoadUserReassignHistory(string HistFor, int foruser)
        {
            object[] parameters = new Object[2] { HistFor, foruser };
            return dataAccess.LoadDataSet(parameters, "P_TM_UserReassignHistory_Select", "HistList");
        }


        //Client Autocomplete
        public DataSet GetClientAutomatically(string clr)
        {
            Object[] parameters = new Object[1] {  clr };
            return dataAccess.LoadDataSet(parameters, "[P_TM_UserMaster_SelectUserAutomatically]", "GetClientAutomatically");
        }

        public DataSet SaveUnApprovedInfo(clsUnApprovedInfo objUnApproved, string company)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecId,
                                                objUnApproved.RecForType,
                                                objUnApproved.RecordFor,
                                                objUnApproved.RecForId,
                                                objUnApproved.RecForModule,
                                                objUnApproved.Code,
                                                objUnApproved.AppliedBy,
                                                objUnApproved.AppStatus,
                                                objUnApproved.LoginUserId,
                                                objUnApproved.RecData,
                                                objUnApproved.PageMethod,
                                                company
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_InsertUpdate", "UnApprovedClientInfo");
        }
        public DataSet GetRecCode(string recForType, string country)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { recForType, country };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetRunningCode", "ClientCode");
        }
        public DataSet ChangeStatus(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecForType,
                                                objUnApproved.RecForId,                                      
                                                objUnApproved.AppStatus,
                                                objUnApproved.RecordFor,
                                                objUnApproved.RecId,
                                                objUnApproved.LoginUserId,
                                                null
                                                    };

            return dataAccess.LoadDataSet(parameters, "P_ChangeRequestStatus", "Status");
            //return dataAccess.ExecuteNonQuery("P_ChangeRequestStatus", parameters);
            //return dataAccess.LoadDataSet(parameters, "P_ConfirmRequest", "ConfirmRequest");
        }
        public DataSet GetMails(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecForType,
                                                objUnApproved.RecForId,                                      
                                                objUnApproved.RecordFor,
                                                objUnApproved.AppStatus,
                                                objUnApproved.LoginUserId,
                                                objUnApproved.RecId

                                                    };

            return dataAccess.LoadDataSet(parameters, "P_GetAuthorityMail", "MailAddress");
            //return dataAccess.ExecuteNonQuery("P_ChangeRequestStatus", parameters);
            //return dataAccess.LoadDataSet(parameters, "P_ConfirmRequest", "ConfirmRequest");
        }
        public DataSet SaveRejectReason(clsUnApprovedInfo objUnApproved)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecForId,
                                                objUnApproved.RecordFor,
                                                objUnApproved.RecForType,                                                                
                                                objUnApproved.AppStatus,
                                                objUnApproved.RejectReason,
                                                objUnApproved.RecId,
                                                objUnApproved.LoginUserId
                                                    };

            return dataAccess.LoadDataSet(parameters, "P_SaveRejectReason", "Reject");
            //return dataAccess.ExecuteNonQuery("P_ChangeRequestStatus", parameters);
            //return dataAccess.LoadDataSet(parameters, "P_ConfirmRequest", "ConfirmRequest");
        }
        public bool Check3rdApprovalLevel(string company)
        {
            string selectedCompany = company;
            CompanyMasterManager objCompany = new CompanyMasterManager();
            clsCompanyMaster obj = new clsCompanyMaster();
            obj.CompanyId = Convert.ToInt32(selectedCompany);
            DataSet ds = new DataSet();
            ds = objCompany.LoadCompany(obj);
            bool Is3rdLvlReq = Convert.ToBoolean(ds.Tables[0].Rows[0]["is3LevelAprvReq"]);
            return Is3rdLvlReq;
        }
        public DataSet GetClassByCompanyId(int ClassId, int CompanyId)
        {
            dataAccess = new DataAccess();

            Object[] parametes = new Object[] { ClassId, CompanyId, HttpContext.Current.Session["UserId"].ToString() };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_SelectByCompanyId", "TM_ClassMaster");
        }

        public DataSet GetSubClassByClassId_CompanyId(int ClassId, int CompanyId)
        {
            object[] parameters = new Object[] { ClassId, CompanyId };
            return dataAccess.LoadDataSet(parameters, "P_TM_SubClassMaster_SelectByClassId_CompanyId", "TM_SubClassMaster");
        }
        //added by kavita on 11th Augest
        public DataSet GetMultipleSubClass_ByPolicy(long PolicyId, int PolicyVerId, int ClassId)
        {
            object[] parameters = new Object[] {PolicyId,PolicyVerId, ClassId };
            return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyMultipleSubClass_Select", "TM_MultipleSubClassMaster");
        }
        //end
        //added by kavita on 4th March

        //added by Arvind Redmine#35870
        public DataSet GetMultipleSubClass_ByDebitNoteNo(string strCaseRefNo, string strDebitNoteNo)
        {
            object[] parameters = new Object[] { strCaseRefNo, strDebitNoteNo};
            return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyMultipleSubClass_SelectByDebitNote", "TM_MultipleSubClassMaster");
        }
        //end
        //added by Arvind Redmine#35870

        public DataSet GetRIMultipleSubClass_ByPolicy(string TranRefNo, string CovernoteNo)
        {
            object[] parameters = new Object[] { TranRefNo, CovernoteNo };
            return dataAccess.LoadDataSet(parameters, "P_RICN_MultipleSubClass_Select", "TM_MultipleSubClassMaster");
        }
        //end
        public DataSet GetEBSubClass()
        {
            dataAccess = new DataAccess();
            // Object[] parametes = new Object[] { ClassId, CompanyId };
            return dataAccess.LoadDataSet("P_Pol_EBSubClass_Select", "TM_SubClassMaster");
        }
        public DataSet GetCurrencyEffInCurrDate()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("P_IRM_DDLCurrencyEffInCurrDate", "TM_CurrencyMaster");
        }

        //added by kavita or bind User Associated on 9th Sept.//
        public DataSet GetAccountUserAssociated()
        {
            //return dataAccess.LoadDataSet(parameters, "P_TM_UsrGrpAccessMaster_Select", "GroupAccessList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet("P_Account_Users_Associated", "AC_Users");
        }
        // end of code//


        //added by kavita or bind User Associated on 9th Sept.//
        public DataSet GetSettlementEnquiryBy()
        {
            //return dataAccess.LoadDataSet(parameters, "P_TM_UsrGrpAccessMaster_Select", "GroupAccessList"); //Commented by Satya Prakash
            return dataAccess.LoadDataSet("P_SettlementEnquiryBy", "TM_UserMaster");
        }
        // end of code//

        //added by kavita for access client based info//
        public string GetClient()
        {

            string strclient = ClsSingleton.GetSysParamValues("Client");
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("P_GetClient", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strclient = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strclient;
        }
        //end of code//

        //Added by Apurva
        public string GetCustomizedClient()
        {

            string strclient = ClsSingleton.GetSysParamValues("CustomizedClient");
            return strclient;
        }

        //added by kavita for access Multiple SubClass Status//
        public string GetMultipleSubClassStatus()
        {

            string strMultiClass = ClsSingleton.GetSysParamValues("IsMultipleSubClass");
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("P_Get_IsMultipleSubClassStatus", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strMultiClass = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strMultiClass;
        }
        //end of code//




        //added by kavita for access EB Required Status//
        public string GetEBModuleRquiredStatus()
        {

            string strEBRequired = ClsSingleton.GetSysParamValues("IsEBModuleRequired"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("P_Get_IsEBModuleRequiredStatus", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strEBRequired = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strEBRequired;
        }
        //end of code//


//Added By Prateek on 16 July 2015
        public string IsChineseRequired()
        {

            string strChineseReq = ClsSingleton.GetSysParamValues("IsChineseRequired"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("SELECT KeyValue FROM Sys_Params WHERE KeyWord='IsChineseRequired'", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strChineseReq = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strChineseReq;
        }

        public string IsPotentialApprovalReq()
        {

            string strPotentialApprovalReq = ClsSingleton.GetSysParamValues("IsPotentialAppReq"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("SELECT KeyValue FROM Sys_Params WHERE KeyWord='IsPotentialAppReq'", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strPotentialApprovalReq = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strPotentialApprovalReq;
        }
//end of code
        //Added By Prateek on 16 July 2015
        public string CountryCode()
        {

            string strCountryCode = ClsSingleton.GetSysParamValues("CountryCode"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("SELECT KeyValue FROM Sys_Params WHERE KeyWord='CountryCode'", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strCountryCode = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strCountryCode;
        }
        


        //added by kavita for access Date Format//
        public string GetDateFormat()
        {
            string strDateformate = ClsSingleton.GetSysParamValues("DateFormat"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("P_Get_DateFormat", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strclient = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strDateformate;

        }

        public string GetDefaultCurrency()
        {
            string strCurrency = "";
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet("P_GetDEfaultCurrenyCode", "Currency");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    strCurrency = Convert.ToString(ds.Tables[0].Rows[0]["CurrencyCode"]);
            }
            return strCurrency;

        }
        //end of code//





        //added by kavita for access Client CSS//
        public string GetClientCSS()
        {
            string strclient = ClsSingleton.GetSysParamValues("ClientCss"); 
            //dataAccess = new DataAccess();
            //DataSet ds = new DataSet();
            //ds = dataAccess.LoadDataSet("P_Get_ClientCSS", "sys_Params");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //        strclient = Convert.ToString(ds.Tables[0].Rows[0]["KeyValue"]);
            //}
            return strclient;

        }
        //end of code//
        public static string ConvertFormatMONddyyyy(string str, string dateformat)
        {
            string formatdate = "";
            if (!String.IsNullOrEmpty(str))
            {
                DateTime EffecTo = DateTime.Now;
                if (DateTime.TryParseExact(str, dateformat, null, DateTimeStyles.None, out EffecTo))
                    formatdate = EffecTo.ToString("dd/MM/yyyy");
                //string formatdate = "";
                //if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                //{

                //    string mm_des, dd1;

                //    string dd, mm, yy;
                //    mm_des = str.Substring(0, 3);
                //    mm = "";
                //    if (mm_des.ToUpper() == "JAN")
                //    {
                //        mm = "01";
                //    }
                //    else if (mm_des.ToUpper() == "FEB")
                //    {
                //        mm = "02";
                //    }
                //    else if (mm_des.ToUpper() == "MAR")
                //    {
                //        mm = "03";
                //    }
                //    else if (mm_des.ToUpper() == "APR")
                //    {
                //        mm = "04";
                //    }
                //    else if (mm_des.ToUpper() == "MAY")
                //    {
                //        mm = "05";
                //    }
                //    else if (mm_des.ToUpper() == "JUN")
                //    {
                //        mm = "06";
                //    }
                //    else if (mm_des.ToUpper() == "JUL")
                //    {
                //        mm = "07";
                //    }
                //    else if (mm_des.ToUpper() == "AUG")
                //    {
                //        mm = "08";
                //    }
                //    else if (mm_des.ToUpper() == "SEP")
                //    {
                //        mm = "09";
                //    }
                //    else if (mm_des.ToUpper() == "OCT")
                //    {
                //        mm = "10";
                //    }
                //    else if (mm_des.ToUpper() == "NOV")
                //    {
                //        mm = "11";
                //    }
                //    else if (mm_des.ToUpper() == "DEC")
                //    {
                //        mm = "12";
                //    }
                //    dd1 = str.Substring(5, 1);
                //    if (dd1 == ",")
                //    {
                //        dd = "0" + str.Substring(4, 1);
                //        yy = str.Substring(7, 4);
                //    }
                //    else
                //    {
                //        dd = str.Substring(4, 2);
                //        yy = str.Substring(8, 4);
                //    }
                //    formatdate = dd + '/' + mm + '/' + yy;
            }
            else if (dateformat.Equals("dd/MM/yyyy", StringComparison.OrdinalIgnoreCase))
            {
                formatdate = str;
            }
            return formatdate;
            // }


        }
        /// <summary>
        /// For converting dmy To Other Format
        /// Used for display and Data Retrival
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dateformat"></param>
        /// <returns></returns>
        public static string convertFormatddmmyyyy(string str, string dateformat)
        {
            if (!String.IsNullOrEmpty(str))
            {

                string formatdate = "";
                if (dateformat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase))
                {

                    string dd = "", mm = "", mm_des = "", yyyy = "";
                    if ((str.Substring(1, 1) == "/") && (str.Substring(3, 1) == "/"))
                    {
                        dd = "0" + str.Substring(0, 1);
                        mm = "0" + str.Substring(2, 1);
                        yyyy = str.Substring(4, 4);

                    }
                    else if ((str.Substring(2, 1) == "/") && (str.Substring(4, 1) == "/"))
                    {
                        dd = str.Substring(0, 2);
                        mm = "0" + str.Substring(3, 1);
                        yyyy = str.Substring(5, 4);
                    }
                    else if ((str.Substring(1, 1) == "/") && (str.Substring(4, 1) == "/"))
                    {
                        dd = "0" + str.Substring(0, 1);
                        mm = str.Substring(2, 2);
                        yyyy = str.Substring(5, 4);
                    }
                    else if ((str.Substring(2, 1) == "/") && (str.Substring(5, 1) == "/"))
                    {
                        dd = str.Substring(0, 2);
                        mm = str.Substring(3, 2);
                        yyyy = str.Substring(6, 4);
                    }



                    switch (mm)
                    {
                        case "01":
                            mm_des = "Jan";
                            break;
                        case "02":
                            mm_des = "Feb";
                            break;
                        case "03":
                            mm_des = "Mar";
                            break;
                        case "04":
                            mm_des = "Apr";
                            break;
                        case "05":
                            mm_des = "May";
                            break;
                        case "06":
                            mm_des = "Jun";
                            break;
                        case "07":
                            mm_des = "Jul";
                            break;
                        case "08":
                            mm_des = "Aug";
                            break;
                        case "09":
                            mm_des = "Sep";
                            break;
                        case "10":
                            mm_des = "Oct";
                            break;
                        case "11":
                            mm_des = "Nov";
                            break;
                        case "12":
                            mm_des = "Dec";
                            break;
                    }

                    formatdate = mm_des + " " + dd + "," + " " + yyyy;
                }
                else if (dateformat.Equals("dd/MM/yyyy", StringComparison.OrdinalIgnoreCase))
                {
                    formatdate = str;

                }
                return formatdate;

            }

            else
            {
                return "";
            }
        }
        /// <summary>
        /// Get value of perticular keyword from sys param table on the bases of client
        /// </summary>
        /// <param name="Keyword"> keyword that need to be avialable in sys param table</param>
        /// <returns>get value associated with that keyword</returns>
        public string Get_SysParamValues(string Keyword)
        {
            string keyValue = string.Empty;
            keyValue = ClsSingleton.GetSysParamValues(Keyword);
            return keyValue;
        }
        private DataSet Get_SysParamValues()
        {
            string Keyword = ""; // get all sysparams active rows
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { Keyword };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_Get_SysParamValues", "SysParams");
            return ds;
        }
        public DataSet GetCommonData()
        { 
            DataSet ds = new DataSet();
            ds.Tables.Add(Get_SysParamValues().Tables[0].Copy());
            return ds;
        }
        /// <summary>
        /// Get all Users Under Login User
        /// </summary>
        /// <param name="id">logged in user id </param>
        /// <returns>user login name of all users under login id</returns>
        public static string GetUsersUnderLoginUsers(int id)
        {
            string str = "";
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { id };
            DataSet dsUsersUnderLogin = dataAccess.LoadDataSet(parameters, "P_TM_GetAllUsersUnderLoginUser", "P_TM_GetAllUsersUnderLoginUser");
            //DataSet dsUsersUnderLogin = objLoginBI.GetAllUsersUnderLoginUser(Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"]));
            if (dsUsersUnderLogin != null && dsUsersUnderLogin.Tables[0].Rows.Count > 0 && dsUsersUnderLogin.Tables[0].Rows[0]["UserName"].ToString() != "")
            {
                string[] strUsers = dsUsersUnderLogin.Tables[0].AsEnumerable().Select(x => x["UserName"].ToString().Replace("'", "''")).ToArray();
                str = "'" + string.Join("','", strUsers) + "'";
            }
            return str;
        }
        /// <summary>
        /// Get String for data filteration on the bases of user type
        /// </summary>
        /// <param name="userId">Id of user who logged in</param>
        /// <param name="compId">associated company id for logged in user id</param>
        /// <param name="BranchId">branch id associated with company id</param>
        /// <param name="teamId">associated team id for logged in user id</param>
        /// <returns>return filtered string and used further on data table </returns>
        public static string getFilteredRecordsBy_Team_Comp_Branch_ID(string userId, string compId, string BranchId, string teamId)
        {
            string strFilter = "TeamId= '" + teamId + "' and CompanyId ='" + compId + "'" + "and BranchID = '" + BranchId + "'";
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { userId };
            DataSet dsUsersUnderLogin = dataAccess.LoadDataSet(parameters, "P_TM_GetAllUsersUnderLoginUser", "P_TM_GetAllUsersUnderLoginUser");
            if (dsUsersUnderLogin != null && dsUsersUnderLogin.Tables.Count > 1 && dsUsersUnderLogin.Tables[1].Rows.Count > 0)
            {
                if (dsUsersUnderLogin.Tables[1].Rows[0]["IsAccountUser"].ToString() == "Y" || dsUsersUnderLogin.Tables[1].Rows[0]["AccessLevel"].ToString() == "Y")
                {
                    strFilter = "CompanyId ='" + compId + "'" + "and BranchID = '" + BranchId + "'";
                }
            }
            return strFilter;
        }
     
        public static  string GetClassType()
        {

            string strclasstype = "";
            DataAccess dataAccess = new DataAccess();
            Object[] parametes = new Object[] {  HttpContext.Current.Session["UserId"].ToString() };
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet(parametes,"P_Pol_GetClassType", "TM_ClassType");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    strclasstype = Convert.ToString(ds.Tables[0].Rows[0]["ClassType"]);
            }
            return strclasstype;
        }

        #region VehicleDetail

        public DataSet GetUnits()
        {
            return (new DataAccess()).LoadDataSet("P_BM_Vehicle_Unit", "BM_VehicleUnits");
        }

        #endregion

        //Added By Ravi Maurya
        #region NewClientRequest

        public DataSet GetClientMaster(int teamID, string pagename)
        {
            DataTable dt = new DataTable();
            Object[] parameters = new Object[2] { teamID, pagename };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_ClientMasterSelect", "BM_ClientMaster");
            return ds;   
        }

        public DataSet GetClientMaster(int teamID)
        {
            //DataTable dt = new DataTable();
            //Object[] parameters = new Object[2] { teamID ,null};
            //DataSet ds = dataAccess.LoadDataSet(parameters, "P_ClientMasterSelect", "BM_ClientMaster");
            //return ds;
            DataSet ds =GetClientMaster(teamID, null);
            return ds;
        }
    
        public DataTable GetGrdServicingExecutive(int ClientId, string Type)
        {
            DataTable dt = new DataTable();
            Object[] parameters = new Object[] { ClientId, Type };
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_Executive_Select", "ExecutiveSelect");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
      
        public DataSet GetStateList(int StateId)
        {
            object[] parameters = new Object[1] { StateId };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster", "StateList");
        }
        
        #endregion


        #region LocationInterest

        public DataSet GetConstruction()
        {
            return (new DataAccess()).LoadDataSet("P_BM_LocationInterest_Construction", "BM_LocationInterestConstruction");
        }

        public DataSet GetPIAM()
        {
            return (new DataAccess()).LoadDataSet("P_BM_LocationInterest_PIAM", "BM_LocationInterestPIAM");
        }

        public DataSet GetLocationInterestDescription()
        {
            return (new DataAccess()).LoadDataSet("P_BM_LocationInterest_Description", "BM_LocationInterestDescription");
        }
        #endregion


        #region ExtraneousPerilsMaster

        public DataSet GetExtraneousRules()
        {
            return (new DataAccess()).LoadDataSet("SELECT Lookup_ID AS 'Rules_ID',  Lookup_desc AS 'Rules_DESC' FROM TM_Lookups WHERE Category = 'EXTRAPERILS' AND IsActiveYN = 'Y' order by Lookup_ID asc", "TM_Lookups");
        }

        #endregion

        #region CorpGrpMaster
        public DataSet GetCorpGrpType()
        {
            return (new DataAccess()).LoadDataSet("SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='CorpGrpType' and IsActiveYN='Y' order by Lookup_ID asc", "TM_Lookups");
        }
        #endregion

        public DataSet GetRepColumn()
        {
            return (new DataAccess()).LoadDataSet("SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='EnqRepCol' and IsActiveYN='Y' order by [Lookup_ID] asc", "TM_Lookups");
        }

        public DataSet GetInsurerType()
        {
            return (new DataAccess()).LoadDataSet("SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='InsurerType' and IsActiveYN='Y' order by [Lookup_ID] asc", "TM_Lookups");
        }
        public DataSet GetBnDisplay()
        {
            return (new DataAccess()).LoadDataSet(" SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='BnDisplay' and IsActiveYN='Y' order by [Lookup_ID] asc", "TM_Lookups");

        }
        public DataSet GstBranch()
        {
            return (new DataAccess()).LoadDataSet(" Select BranchID,BranchCode,BranchName from TM_BranchMaster", "TM_BranchMaster");
        }

        public DataSet GetProfitCentre()
        {
            return (new DataAccess()).LoadDataSet(" SELECT ProfitCentreId,ProfitCentreDesc FROM TM_ProfitCentreMaster WHERE IsActive = 'Y' AND ISNULL(ProfitCentreDesc, '') != ''", "TM_ProfitCentreMaster");
        }

        public DataSet GetFundCode()
        {
            return (new DataAccess()).LoadDataSet("  SELECT DISTINCT [Lookup_value],[Description] FROM TM_Lookups where Category='FundCode' and IsActiveYN='Y'   order by [Description] asc", "TM_Lookups");
        }

        public DataSet GstRegion()
        {
            return (new DataAccess()).LoadDataSet(" Select RegionId,RegionCode,RegionName from TM_RegionMaster", "TM_RegionMaster");
        }
        public DataSet GstTaxType()
        {
            return (new DataAccess()).LoadDataSet(" SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='GstTaxType' and IsActiveYN='Y' order by [Lookup_ID] asc", "TM_Lookups");
        }
        public DataSet getGSTRate(string Taxype)
        {
            string[] parameters = new string[] { Taxype };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_Get_GSTExchaneRate", "TM_GSTRate");
        }
        public DataSet GstSusTermReasons()
        {
            return (new DataAccess()).LoadDataSet("Select ReasonId,ReasonDesc from TM_SusTermReasonMaster", "TM_SusTermReasonMaster");
        }
        //added by Saurabh on 30th Mar 2016.//
        public DataTable GetTimeStampDetails(string id, string idFieldName, string tableName)
        {
            DataTable dt = new DataTable();
            
            Object[] parameters = new Object[] { id, idFieldName, tableName };
            tableName = "dt" + tableName;
            DataSet ds = dataAccess.LoadDataSet(parameters, "P_GetTimeStampDetail", tableName);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataSet GetsProvince(int provinceid = 0)
        {
            object[] parameters = new Object[1] { provinceid };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster_Select", "ProvinceList");
        }

        public DataSet GetLookUp()
        {
            return dataAccess.LoadDataSet("GetSubclasslookupValues", "bnclass");
        }
        public DataSet GetUnderWriter()
        {
            return dataAccess.LoadDataSet("GetCurrentUnderWriterFromMaster", "bnclass");
        }

        public DataSet GetOffShoreUnderWriter()
        {
            return dataAccess.LoadDataSet("GetoffshoreUnderWriterFromMaster", "bnclass");
        }

        public string BindCodePrefix(string strcode)
        {
            string strCodePrefix = "";
            dataAccess = new DataAccess();
            string[] parameters = new string[] { strcode };
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet(parameters, "P_GetGeneratedCode", "TM_CodeGenerationSetup");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    strCodePrefix = Convert.ToString(ds.Tables[0].Rows[0]["Prefix"]);
            }
            return strCodePrefix;
        }

        // added for #21705
        public DataSet GetTransactionType()
        {
            return (new DataAccess()).LoadDataSet(" SELECT DISTINCT [Lookup_ID],[Lookup_value],[Description] FROM TM_Lookups where Category='DebitNoteType' and IsActiveYN='Y' order by [Lookup_ID] asc", "TM_Lookups");
        }


        #region for binding Nationality dropdown

        public void BindNationality(DropDownList ddlNationality)
        {
            clsCommon objCommon = new clsCommon();
            ddlNationality.DataSource = GetNationality();
            ddlNationality.DataTextField = "Nationality";
            ddlNationality.DataValueField = "Nationality";
            ddlNationality.DataBind();
            ddlNationality.Items.Insert(0, new ListItem("Please Select", ""));
        }
        #endregion




        #region for binding Bind Corporate Group dropdown

        public void BindCorporateGroup(DropDownList ddlCorporateGroup)
        {
            CorpGrpManager objBAL = new CorpGrpManager();
            ddlCorporateGroup.DataSource = objBAL.LoadCorporateGroupMasterForDropDown("INT");
            ddlCorporateGroup.DataTextField = "CorpGroupDesc";
            ddlCorporateGroup.DataValueField = "CorpGroupId";
            ddlCorporateGroup.DataBind();
            ddlCorporateGroup.Items.Insert(0, new ListItem("Please Select", ""));
        }
        #endregion


        #region for binding Bind BindSuspension Termination dropdown

        public void BindSuspension(DropDownList ddlSuspReason,DropDownList ddlTerminationReason)
        {
            clsSuspTermReasonMaster obj = new clsSuspTermReasonMaster();
            BM_SuspTermReasonMaster objBAL = new BM_SuspTermReasonMaster();
            DataSet dsRecord = objBAL.LoadSuspensionTerminationReasonMaster(obj);
            ddlSuspReason.DataSource = ddlTerminationReason.DataSource = dsRecord;
            ddlSuspReason.DataTextField =  ddlTerminationReason.DataTextField = "ReasonDesc";
            ddlSuspReason.DataValueField =  ddlTerminationReason.DataValueField  = "ReasonId";
            ddlSuspReason.DataBind();
            ddlSuspReason.Items.Insert(0, new ListItem("Please Select", ""));
            ddlTerminationReason.DataBind();
            ddlTerminationReason.Items.Insert(0, new ListItem("Please Select", ""));
        }

        public void BindGSTCodeRate(DropDownList ddlGSTCodeRate)
        {
            var objVSWMgr = new VAT_SBT_WHT_Manager();
            var dvVSW = new DataView(objVSWMgr.getGSTRate("").Tables["TM_GSTRate"], "", "GSTCode ASC", DataViewRowState.CurrentRows);
            ddlGSTCodeRate.DataSource = dvVSW;
            ddlGSTCodeRate.DataTextField = "GSTCode";
            ddlGSTCodeRate.DataValueField = "ID";
            ddlGSTCodeRate.DataBind();
            ddlGSTCodeRate.Items.Insert(0, new ListItem("Please Select", ""));
        }
        public void BindBranch(DropDownList ddlBranch)
        {
            Client_BranchMasterManager objBal = new Client_BranchMasterManager();
            clsBranchMaster objBol = new clsBranchMaster();
            DataSet ds = objBal.LoadBranchMaster(objBol);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "BranchName";
            ddlBranch.DataValueField = "BranchID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Please Select", ""));

        }

        public void BindRegion(DropDownList ddlRegion)
        {
            RegionManager objBal = new RegionManager();
            clsRegion objBol = new clsRegion();
            ddlRegion.DataSource = objBal.getRegionAll(objBol);
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "RegionId";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Please Select", ""));
        }
        #endregion


        #region for binding day and month dropdowns
        public void BindDateOfBirth(DropDownList ddlDay, DropDownList ddlMonth, string strDateFormat)
        {
            ddlDay.Items.Insert(0, new ListItem("Select", ""));
            ddlMonth.Items.Insert(0, new ListItem("Select", ""));
            for (int index = 1; index <= 31; index++)
            {
                if (index <= 9)
                    ddlDay.Items.Add(new ListItem("0" + index.ToString(), index.ToString()));
                else
                    ddlDay.Items.Add(new ListItem(index.ToString(), index.ToString()));
            }

            if (strDateFormat.Equals("dd/mm/yyyy", StringComparison.OrdinalIgnoreCase) == true)
            {

                for (int monthIndex = 1; monthIndex <= 12; monthIndex++)
                {
                    if (monthIndex <= 9)
                        ddlMonth.Items.Add(new ListItem("0" + monthIndex.ToString(), monthIndex.ToString()));
                    else
                        ddlMonth.Items.Add(new ListItem(monthIndex.ToString(), monthIndex.ToString()));
                }
            }
            else if (strDateFormat.Equals("MMM dd, yyyy", StringComparison.OrdinalIgnoreCase) == true)
            {
                ddlMonth.Items.Add(new ListItem("Jan", "1"));
                ddlMonth.Items.Add(new ListItem("Feb", "2"));
                ddlMonth.Items.Add(new ListItem("Mar", "3"));
                ddlMonth.Items.Add(new ListItem("Apr", "4"));
                ddlMonth.Items.Add(new ListItem("May", "5"));
                ddlMonth.Items.Add(new ListItem("Jun", "6"));
                ddlMonth.Items.Add(new ListItem("Jul", "7"));
                ddlMonth.Items.Add(new ListItem("Aug", "8"));
                ddlMonth.Items.Add(new ListItem("Sep", "9"));
                ddlMonth.Items.Add(new ListItem("Oct", "10"));
                ddlMonth.Items.Add(new ListItem("Nov", "11"));
                ddlMonth.Items.Add(new ListItem("Dec", "12"));
            }

        }
        #endregion


        #region for binding Client Source
        public void BindClientSource(DataSet ClientMaster, DropDownList ddlClientSource)
        {
            DataTable res = new DataTable();
            res = ClientMaster.Tables[0];
            try
            {
                if (res.Rows.Count > 0)
                {
                    ddlClientSource.DataSource = res;
                    ddlClientSource.DataTextField = "DESC";
                    ddlClientSource.DataValueField = "ID";
                    ddlClientSource.DataBind();
                }
                ddlClientSource.Items.Insert(0, new ListItem("[Please Select]", "0"));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                res.Dispose();
            }
        }

        #endregion




        #region for binding Client Segment
        public void BindDropDown(DataTable dt, DropDownList ddldropdown, string datatextfield, string datavaluefield)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    ddldropdown.DataSource = dt;
                    ddldropdown.DataTextField = datatextfield;
                    ddldropdown.DataValueField = datavaluefield;
                    ddldropdown.DataBind();
                }
                ddldropdown.Items.Insert(0, new ListItem("[Please Select]", "0"));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }
        }
        #endregion


        #region for binding Team

        public void BindTeamDropDown(DataTable dt, DropDownList ddlServicingTeam, DropDownList ddlMarketingTeam, string datatextfield, string datavaluefield)
        {

            try
            {
                if (dt.Rows.Count > 0)
                {
                    ddlServicingTeam.DataSource = dt;
                    ddlServicingTeam.DataTextField = datatextfield;
                    ddlServicingTeam.DataValueField = datavaluefield;
                    ddlServicingTeam.DataBind();

                    ddlMarketingTeam.DataSource = dt;
                    ddlMarketingTeam.DataTextField = datatextfield;
                    ddlMarketingTeam.DataValueField = datavaluefield;
                    ddlMarketingTeam.DataBind();
                }
                ddlServicingTeam.Items.Insert(0, new ListItem("[Please Select]", "0"));
                ddlMarketingTeam.Items.Insert(0, new ListItem("[Please Select]", "0"));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }
        }
        #endregion




        #region for binding CustomerType
        public void BindCustomerType(DropDownList ddlAMLACustomerType)
        {
            DataSet CustomerType = new DataSet();
            CustomerType = GetCustomerType();
            ddlAMLACustomerType.DataSource = CustomerType;
            ddlAMLACustomerType.DataTextField = "VALUE";
            ddlAMLACustomerType.DataValueField = "ID";
            ddlAMLACustomerType.DataBind();
            ddlAMLACustomerType.Items.Insert(0, new ListItem("Please Select", ""));

        }

        #endregion


        #region for binding MScode
        public void BindMSCode(int sob, int scId, DropDownList ddlMasterSCode)
        {
            if (sob != -1)
            {
                DataSet ds = new DataSet();
                SCManager objSC = new SCManager();
                clsSourceCode obj = new clsSourceCode();
                obj.SOBId = sob;
                ds = objSC.getSC(obj);
                DataView dv = new DataView(objSC.getSC(obj).Tables[0], "", "SCodeName ASC", DataViewRowState.CurrentRows);
                if (scId != 0)
                {
                    dv.RowFilter = "SCodeId =" + scId + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                else
                {
                    dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                ddlMasterSCode.DataSource = dv;
                ddlMasterSCode.DataTextField = "SCodeName";
                ddlMasterSCode.DataValueField = "SCodeId";
                ddlMasterSCode.DataBind();
                ddlMasterSCode.Items.Insert(0, new ListItem("Please Select", "-1"));
                dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
                foreach (DataRow row in dr)
                {
                    if (dr != null && dr.Length > 0 && scId != 0 && scId == Convert.ToInt32(row["SCodeId"]))
                    {
                        ddlMasterSCode.Items.FindByValue(scId.ToString()).Attributes.Add("style", "color:red");
                    }
                }
            }
            else
            {
                ddlMasterSCode.Items.Clear();
                ddlMasterSCode.Items.Insert(0, new ListItem("Please Select", "-1"));
            }
        }
        #endregion
        #region for binding SOB dropdown
        public void BindSOB(int sobId, DropDownList ddlSOB)
        {
            DataSet ds = new DataSet();
            SOBManager objSOB = new SOBManager();
            objSOB = new SOBManager();
            clsSOB obj = new clsSOB();
            ds = objSOB.getSOB(obj);
            DataView dv = new DataView(objSOB.getSOB(obj).Tables[0], "", "SOBName ASC", DataViewRowState.CurrentRows);
            if (sobId != 0)
            {
                dv.RowFilter = "SOBId =" + sobId + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
            }
            else
            {
                dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
            }
            ddlSOB.DataSource = dv;
            ddlSOB.DataTextField = "SOBName";
            ddlSOB.DataValueField = "SOBId";
            ddlSOB.DataBind();
            ddlSOB.Items.Insert(0, new ListItem("Please Select", "-1"));
            dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
            foreach (DataRow row in dr)
            {
                if (dr != null && dr.Length > 0 && sobId != 0 && sobId == Convert.ToInt32(row["sobId"]))
                {
                    ddlSOB.Items.FindByValue(sobId.ToString()).Attributes.Add("style", "color:red");
                }
            }
        }
        #endregion



        #region for binding SSC1 Dropdown
        public void BindSSC1(int mscode, int ssc1Id, DropDownList ddlSSC1)
        {
            if (mscode != -1)
            {
                DataSet ds = new DataSet();
                SubsidiarySCode1Manager objSSC1 = new SubsidiarySCode1Manager();
                clsSubsidiarySCode1 obj = new clsSubsidiarySCode1();
                obj.SCodeId = mscode;
                ds = objSSC1.getSSC1(obj);
                DataView dv = new DataView(objSSC1.getSSC1(obj).Tables[0], "", "SSCode1Name ASC", DataViewRowState.CurrentRows);
                if (ssc1Id != 0)
                {
                    dv.RowFilter = "SSCode1Id =" + ssc1Id + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                else
                {
                    dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                ddlSSC1.DataSource = dv;
                ddlSSC1.DataTextField = "SSCode1Name";
                ddlSSC1.DataValueField = "SSCode1Id";
                ddlSSC1.DataBind();
                ddlSSC1.Items.Insert(0, new ListItem("Please Select", "-1"));
                dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
                foreach (DataRow row in dr)
                {
                    if (dr != null && dr.Length > 0 && ssc1Id != 0 && ssc1Id == Convert.ToInt32(row["SSCode1Id"]))
                    {
                        ddlSSC1.Items.FindByValue(ssc1Id.ToString()).Attributes.Add("style", "color:red");
                    }
                }
            }
            else
            {
                ddlSSC1.Items.Clear();
                ddlSSC1.Items.Insert(0, new ListItem("Please Select", "-1"));
            }
        }
        #endregion
        #region for binding SSC1 Dropdown
        public void BindSSC2(int ssc1, int ssc2Id, DropDownList ddlSSC2)
        {
            DataSet ds = new DataSet();
            if (ssc1 != -1)
            {
                SubsidiarySCode2Manager objSSC2 = new SubsidiarySCode2Manager();
                clsSubsidiarySCode2 obj = new clsSubsidiarySCode2();
                obj.SSCode1Id = ssc1;
                ds = objSSC2.getSSC2(obj);
                DataView dv = new DataView(objSSC2.getSSC2(obj).Tables[0], "", "SSCode2Name ASC", DataViewRowState.CurrentRows);
                if (ssc2Id != 0)
                {
                    dv.RowFilter = "SSCode2Id =" + ssc2Id + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                else
                {
                    dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                ddlSSC2.DataSource = dv;
                ddlSSC2.DataTextField = "SSCode2Name";
                ddlSSC2.DataValueField = "SSCode2Id";
                ddlSSC2.DataBind();
                ddlSSC2.Items.Insert(0, new ListItem("Please Select", "-1"));
                dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
                foreach (DataRow row in dr)
                {
                    if (dr != null && dr.Length > 0 && ssc2Id != 0 && ssc2Id == Convert.ToInt32(row["SSCode2Id"]))
                    {
                        ddlSSC2.Items.FindByValue(ssc2Id.ToString()).Attributes.Add("style", "color:red");
                    }
                }
            }
            else
            {
                ddlSSC2.Items.Clear();
                ddlSSC2.Items.Insert(0, new ListItem("Please Select", "-1"));
            }
        }
        #endregion


        #region for binding SourceCode Dropdown
        public void BindSourceCode(int ssc2, int scode, DropDownList ddlSourceCode)
        {
            DataSet ds = new DataSet();
            if (ssc2 != -1)
            {
                clsSCMasterManager objSCBI = new clsSCMasterManager();
                clsSourceCodeMaster obj = new clsSourceCodeMaster();
                obj.SSCode2Id = ssc2;
                obj.IsGroupMandatory = "";
                ds = objSCBI.getSCMaster(obj);
                DataView dv = new DataView(objSCBI.getSCMaster(obj).Tables[0], "", "SCode ASC", DataViewRowState.CurrentRows);
                if (scode != 0)
                {
                    dv.RowFilter = "SCId =" + scode + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                else
                {
                    dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                ddlSourceCode.DataSource = dv;
                ddlSourceCode.DataTextField = "SCode";
                ddlSourceCode.DataValueField = "SCId";
                ddlSourceCode.DataBind();
                ddlSourceCode.Items.Insert(0, new ListItem("Please Select", "-1"));
                dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
                foreach (DataRow row in dr)
                {
                    if (dr != null && dr.Length > 0 && scode != 0 && scode == Convert.ToInt32(row["SCId"]))
                    {
                        ddlSourceCode.Items.FindByValue(scode.ToString()).Attributes.Add("style", "color:red");
                    }
                }
            }
            else
            {
                ddlSourceCode.Items.Clear();
                ddlSourceCode.Items.Insert(0, new ListItem("Please Select", "-1"));
            }
        }
        #endregion
        #region for binding BindGroup Dropdown
        public void BindGroup(int sourcecode, int group, DropDownList ddlGroup)
        {
            DataSet ds = new DataSet();
            if (sourcecode != -1)
            {
                clsGroupManager objGroupBI = new clsGroupManager();
                clsGroupMaster obj = new clsGroupMaster();
                obj.SCId = sourcecode;
                ds = objGroupBI.getGroupData(obj);
                DataView dv = new DataView(objGroupBI.getGroupData(obj).Tables[0], "", "GroupCode ASC", DataViewRowState.CurrentRows);
                if (group != 0)
                {
                    dv.RowFilter = "GroupId =" + group + " or Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                else
                {
                    dv.RowFilter = "Effectivetodate1 Is NULL or Effectivetodate1 >= '" + DateTime.Now.Date + "'";
                }
                ddlGroup.DataSource = dv;
                ddlGroup.DataTextField = "GroupCode";
                ddlGroup.DataValueField = "GroupId";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("Please Select", "-1"));
                dr = ds.Tables[0].Select("Effectivetodate1 <= '" + DateTime.Now.Date + "'");
                foreach (DataRow row in dr)
                {
                    if (dr != null && dr.Length > 0 && group != 0 && group == Convert.ToInt32(row["GroupId"]))
                    {
                        ddlGroup.Items.FindByValue(group.ToString()).Attributes.Add("style", "color:red");
                    }
                }
            }
            else
            {
                ddlGroup.Items.Clear();
                ddlGroup.Items.Insert(0, new ListItem("Please Select", "-1"));
            }
        }
        #endregion

        #region for binding drop down for insurer

        
        public void BindDropDown(DataSet ds, DropDownList ddldropdown,string datatextfield, string datavaluefield)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddldropdown.DataSource = ds;
                    ddldropdown.DataTextField = datatextfield;
                    ddldropdown.DataValueField = datavaluefield;
                    ddldropdown.DataBind();
                }
                ddldropdown.Items.Insert(0, new ListItem("[Please Select]", "0"));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }
        }
        #endregion

        public DataSet F_GetLookUpDataWithActive(string Category)
        {

            dataAccess = new DataAccess();
            string[] parameters = new string[] { Category };
            return dataAccess.LoadDataSet(parameters, "P_GetLookUpDataWithActive", "TM_Lookups");
        }


        public DataSet LoadClientReassignHistory(string HistFor, int forPolicy)
        {
            object[] parameters = new Object[2] { HistFor, forPolicy };
            return dataAccess.LoadDataSet(parameters, "P_TM_ClientReassignHistory_Select", "HistList");
        }


        #region EnumSection
        
        public enum SavedStage
        {
            DEBIT,
            CLIENT,
            INSTALMENT,
            ATTACHMENT,
            COMPLETED
        }    

        public enum CalledFrom
        {
            MODIFYDEBITENOTEWITHCN
        }

        public enum EproClientCode
        {
            Galaxy,
            Acclaim,
            KIB
        }

        #endregion
    }

    //added by Pravesh on 23 March 17 for Singalton
    /// <summary>
    /// Summary description for Singleton.
    /// </summary>
    public sealed class ClsSingleton : System.Data.DataSet
    {
        static ClsSingleton lObjSingletonDataSet = new ClsSingleton();
        private static readonly object padlock = new object();
        private static DataRow[] foundRows = null;
        // Constructor
        static ClsSingleton()
        {
            loadData();
        }

        #region public methods

        public static string GetSysParamValues(string Keyword)
        {

            return lObjSingletonDataSet.Tables["SysParams"].Select("KeyWord='" + Keyword + "'").Length > 0 ?
                    lObjSingletonDataSet.Tables["SysParams"].Select("KeyWord='" + Keyword + "'")[0]["KeyValue"].ToString() : "";
        }
       
        //Setting the Country data 
        public static DataTable Country
        {
            get
            {
                lObjSingletonDataSet = getSinglotonObject();
                return lObjSingletonDataSet.Tables["Country"];
            }
        }
        //Setting the State data 
        public static DataTable State
        {
            get
            {
                lObjSingletonDataSet = getSinglotonObject();
                return lObjSingletonDataSet.Tables["State"];
            }
        }
        //currency
        public static DataTable Currency
        {
            get
            {
                lObjSingletonDataSet = getSinglotonObject();
                return lObjSingletonDataSet.Tables["Currency"];
            }
        }
        //Function for Reset the object
        public static void ResetObject()
        {
            loadData();
        }
        #endregion

        #region private
        private static ClsSingleton getSinglotonObject()
        {
            if(lObjSingletonDataSet==null)
                loadData();
            return lObjSingletonDataSet;
        }
        //Function for Filling the data into the dataset
        private static void loadData()
        {
            lock (padlock)
            {
                clsCommon lObjCommon = new clsCommon();
                lObjSingletonDataSet = null;
                lObjSingletonDataSet = new ClsSingleton();
                foreach (DataTable dt in lObjCommon.GetCommonData().Tables)
                {
                    lObjSingletonDataSet.Tables.Add(dt.Copy());
                }
                
            }
        }
        #endregion

        
    }
    //added by Pravesh on 12 Feb 18 for DataMaper for two objects
    public class DataMapper
    {
        #region Public static methods

        public static void Map(object source, object target, bool suppressExceptions, params string[] ignoreList)
        {
            List<string> ignore = new List<string>(ignoreList);
            foreach (var propertyName in GetPropertyNames(source.GetType()))
            {
                if (!ignore.Contains(propertyName))
                {
                    try
                    {
                        object value = source.GetType().GetProperty(propertyName).GetValue(source, null);
                        target.GetType().GetProperty(propertyName).SetValue(target, value, null);
                    }
                    catch (Exception ex)
                    {
                        if (!suppressExceptions)
                            throw new ArgumentException(
                                String.Format("Data Mapping Exception {0}", propertyName), ex);
                    }
                }
            }
        }

        private static IList<string> GetPropertyNames(Type sourceType)
        {
            List<string> result = new List<string>();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(sourceType);
            foreach (PropertyDescriptor item in props)
                if (item.IsBrowsable)
                    result.Add(item.Name);
            return result;
        }

        #endregion
    }
    
}
