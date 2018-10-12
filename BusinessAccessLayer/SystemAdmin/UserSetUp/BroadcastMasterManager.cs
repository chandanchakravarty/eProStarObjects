using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class BroadcastMasterManager
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadBroadcast(clsBroadcastMaster objBroadcast)
        {
            object[] parameters = new object[1] { objBroadcast.BroadCastManagerID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BroadcastMaster_Select", "BroadcastSelect");

        }
        public DataSet LoadBroadcastAll(clsBroadcastMaster objBroadcast)
        {
        
            object[] parameters = new object[] { 
                                                  objBroadcast.BroadcastCode,
                                                  objBroadcast.BroadcastTitle,
                                                  //objBroadcast.Status,
                                                  objBroadcast.BroadcastEffectiveFromDate,
                                                  objBroadcast.BroadcastEffectiveFromDate2,
                                                  objBroadcast.BroadcastEffectiveToDate,
                                                  objBroadcast.BroadcastEffectiveToDate2
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BroadcastMaster_SelectAll", "BroadcastSelect");

        }
        public DataSet SaveBroadcast(clsBroadcastMaster objBroadcast)
        {//
            object[] parameters = new object[] { 
                                                 objBroadcast.BroadCastManagerID,
                                                 objBroadcast.BroadcastCode,
                                                 objBroadcast.BroadcastTitle,
                                                 objBroadcast.BroadcastEffectiveFromDate,
                                                 objBroadcast.BroadcastEffectiveToDate,
                                                 objBroadcast.Status,
                                                 objBroadcast.LoginUserId,
                                                 objBroadcast.BroadCastContent,
                                                 objBroadcast.BroadCastDescription,
                                                 objBroadcast.BroadCastRecurringFrequency,
                                                 objBroadcast.BroadCastRecurringDays,
                                                 objBroadcast.BroadCastIsDepartmentSelected,
                                                 objBroadcast.BroadCastSelectedDepartment,
                                                 objBroadcast.BroadCastIsUserSelected,
                                                 objBroadcast.BroadCastSelectedUser
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BroadcastMaster_InsertUpdate", "BroadcastDetails");

        }
        public DataSet GetDepartmentList()
        {

            object[] parameters = new object[] {  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_TeamAsDepartmentlist_Select", "Team");
            //P_Pol_departmentlist_Select
        }
        public DataSet GetUserList(string TeamIds)
        {

            object[] parameters = new object[] { TeamIds};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_UserlistFromTeam_Select", "UserSelect");
            //P_Userlist_Select
        }
    }
}

