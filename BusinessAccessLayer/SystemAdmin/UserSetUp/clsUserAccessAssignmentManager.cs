using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
     
    public class clsUserAccessAssignmentManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadUserAssignmentAll(clsUserAccessAssignmentMaster objUser)
        {

            object[] parameters = new object[] { objUser.UserId, objUser.UserLoginId, objUser.FirstName, objUser.LastName, objUser.Team, objUser.UserLevelId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserAssignment_Select", "P_TM_UserAssignment_Select");
        }

        public DataSet LoadUserAssignmentAllRecords(clsUserAccessAssignmentMaster objUser)
        {

            object[] parameters = new object[] { objUser.UserId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserAssignment_SelectAll", "P_TM_UserAssignment_SelectAll");
        }

        public DataSet LoadUserAssignmentSetUpAll(clsUserAccessAssignmentMaster objUser)
        {

            object[] parameters = new object[] { objUser.UserId, objUser.UserLoginId, objUser.FirstName, objUser.UserLevelId, objUser.TeamId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserAssignment_SetUp_Select", "P_TM_UserAssignment_SetUp_Select");

        }

        public DataSet SaveUserAssignment(clsUserAccessAssignmentMaster objUser)
        {

            object[] parameters = new object[] { objUser.UserId, objUser.TxnView, objUser.ViewTxn, objUser.LoggedIn_UserName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserAssignment_InsertUpdate", "P_TM_UserAssignment_InsertUpdate");

        }
        public DataSet LoadOneLevelLowUser(int managerId)
        {

            object[] parameters = new object[] { managerId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_GetOneLevelLowId", "P_TM_GetOneLevelLowId");

        }


        public DataSet GetUsersForAutoSelect(int userId)
        {

            object[] parameters = new object[] { userId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_GetUsersForAutoSelect", "P_TM_GetUsersForAutoSelect");

        }

        public DataSet GetUserLevel()
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { };
            return dataAccessDS.LoadDataSet(parameters, "P_User_Level_Select", "P_User_Level_Select");
        }
    }
}
