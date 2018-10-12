using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.Admin;
using DataAccessLayer;

namespace BusinessAccessLayer.Admin
{
    public class clsLoginManager
    {
        DataAccess dataAccess = null;

        public DataSet GetAllUsersUnderLoginUser(int id)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { id };
            return dataAccess.LoadDataSet(parametes, "P_TM_GetAllUsersUnderLoginUser", "P_TM_GetAllUsersUnderLoginUser");
        }
        public DataSet ValidateUser(clsLogin objLogin)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objLogin.UserName, objLogin.Password };
            return dataAccess.LoadDataSet(parametes, "P_GetUser", "UserInfo");
        }
        public DataSet GetOldPassword(clsLogin objLogin)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objLogin.UserLoginId};
            return dataAccess.LoadDataSet(parametes, "P_GetOldPassword", "OldPassword");
        }
        public DataSet SavePassword(clsLogin objLogin)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objLogin.UserLoginId,
                                                objLogin.Password
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SaveNewPassword", "SaveNewPassword");
        }
        public DataSet UpdateLoginDetails(clsLogin objLogin, string strLock)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { objLogin.UserName, strLock, objLogin.IPAddress, objLogin.UserSessionId };
            return dataAccess.LoadDataSet(parametes, "P_UpdateLoginDetails", "UpdateLogindetails");
        }
        public DataSet GetUserInfo(clsLogin objLogin)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objLogin.UserLoginId };
            return dataAccess.LoadDataSet(parametes, "P_GetUserInfo", "UserInfo");
        }
        public DataSet GetUserCompany(clsLogin objLogin)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objLogin.UserLoginId };
            return dataAccess.LoadDataSet(parametes, "P_GetUserCompanies", "UserCompanies");
        }
        public DataSet GetUserCompanyTeam(clsLogin objLogin,int intTeamId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objLogin.UserLoginId, intTeamId };
            return dataAccess.LoadDataSet(parametes, "P_GetUserCompaniesTeam", "UserCompanies");
        }
        public DataSet GetCompanyByID(int intCompId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { intCompId };
            return dataAccess.LoadDataSet(parameters, "P_GetCompanyByID", "CompanyDetails");
        }
        public DataSet IsUserHavingBrnAccess(string UserLoginId, int intBrnId, int intCompId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] {UserLoginId, intBrnId ,intCompId};
            return dataAccess.LoadDataSet(parameters, "P_IsUserHavingBrnAccess", "UserHavingBrnAccess");
        }





        public DataSet IsCheckEndorsemnet(int Policyid,int polversionid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] {Policyid, polversionid };
            return dataAccess.LoadDataSet(parameters, "P_IsCheckEndorsement", "UserHavingBrnAccess");
        }
        public DataSet GetInternalReleaseVersionNumber()
        {
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet("GetInternalReleaseNumber", "InternalReleaseNumber");

        }
        public DataSet UpdateLogOut(clsLogin objLogin)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objLogin.UserLoginId, objLogin.UserSessionId };
            return dataAccess.LoadDataSet(parametes, "P_UserLogout", "UserLogout");
        }
    }
}
