using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsUserSuspensionManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadUserSuspension(clsUserSuspension objSuspension)
        {
            object[] parameters = new object[2] { objSuspension.UserId, objSuspension.SuspensionName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserSuspension_Select", "UserSuspensionSelect");
        }
       
        public DataSet SaveUserSuspension(clsUserSuspension objSuspension)
        {
            object[] parameters = new object[] { objSuspension.UserId,
                                                
                                                 objSuspension.UserNameId,
                                                 objSuspension.SuspensionFromDate,
                                                 objSuspension.SuspensionToDate,
                                                 objSuspension.SuspensionReason,
                                                //bjSuspension.ReassignUserId,
                                                 objSuspension.IsActive,
                                                 objSuspension.LoginUserId,
                                                  objSuspension.HistFor
                                                
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserSuspension_InsertUpdate", "UserSuspensionDetail");
        }
       
       
    }
}
