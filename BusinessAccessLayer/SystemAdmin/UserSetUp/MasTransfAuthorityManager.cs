using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class MasTransfAuthorityManager
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadMasTransfAuthority(int MassTransfId)
        {
            object[] parameters = new object[1] { MassTransfId };
            string[] tablename = new string[2] { "MassTransfAuthMaster", "MassTransfAuthDetail" };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSets(parameters, "P_TM_MassTransfAuthMaster_Select", tablename);

        }

        public DataSet LoadAllMasTransfAuthority(clsMasTransfAuthority objMTAInfo)
        {
            dataAccessDS = new DataAccess();                

            Object[] parameters = new Object[4] { objMTAInfo.UserId  , objMTAInfo.reassignuserName , objMTAInfo.EffectivefromDate , objMTAInfo.EffFromDate1};
            return dataAccessDS.LoadDataSet(parameters, "P_Adm_MassTransferAuthorityListAll", "MassTransferAuthorityList");
        }

        public DataSet LoadUsersByAppAuthId(int AppAuthId)
        {
            object[] parameters = new object[1] { AppAuthId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MassTransfAuthMaster_SelectUsersByAppAuth", "UsersList");
        }

        public DataSet LoadUsersReassignmentHistory(int AppAuthId)
        {
            object[] parameters = new object[1] { AppAuthId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_UserReassignmentHistory", "UsersList");
        }
        public DataSet SaveMasTransfAuthority(clsMasTransfAuthority objMTA,string xmlUsersFile)
        {
            object[] parameters = new object[] { objMTA.MassTransfAuthId,
                                                 objMTA.CurrentUserId,
                                                 objMTA.ReassignUserId,
                                                 objMTA.EffectivefromDate,
                                                 objMTA.Effectivetodate,
                                                 objMTA.UserId,
                                                 objMTA.isActive,
                                                 objMTA.HistFor,
                                                 xmlUsersFile   
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MassTransfAuthMaster_InsertUpdate", "MassTransfAuthDetail");
        }


    }
}
