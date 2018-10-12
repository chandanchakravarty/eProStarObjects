using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class UserReassignmentManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadUserReassingnment(int MassTransfId)
        {
            object[] parameters = new object[1] { MassTransfId };
            string[] tablename = new string[1] { "UserReassingnment" };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSets(parameters, "P_TM_UserReassingnment_Select", tablename);
        }
        public DataSet LoadUserReassingnmentAll(int MassTransfId, int UserId)
        {
            object[] parameters = new object[2] { MassTransfId,UserId };
            string[] tablename = new string[1] { "UserReassingnment" };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSets(parameters, "P_TM_UserReassingnment_SelectAll", tablename);
        }
        public DataSet LoadUnAprovedClientByAppAuthId(int AppAuthId)
        {
            object[] parameters = new object[1] { AppAuthId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserReassingnment_SelectClientsByAppAuth", "ClientList");
        }
        public DataSet SaveUserReassingnment(clsUserReassingnment objReAsgn)
        {
            object[] parameters = new object[] { objReAsgn.ReassingnmentId,
                                                 objReAsgn.CurrentUserId,
                                                 objReAsgn.ReassignUserId,
                                                  objReAsgn.UserList,
                                                 objReAsgn.ReassignfromDate,
                                                 objReAsgn.Reassigntodate,
                                                 objReAsgn.Remarks,
                                                 objReAsgn.UserId,
                                                 objReAsgn.isActive,
                                                 objReAsgn.HistFor,
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserReassingnment_InsertUpdate", "UserReassingnmentDetail");
        }

        public DataSet LoadPolicyDetailsByAccountHandlerId(int AccountHandlerId, string Clientid, string MainClass, string SubClass)
        {
            object[] parameters = new object[4] { AccountHandlerId, Clientid, MainClass, SubClass };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_PolicyMasterDetails_Select", "PolicyMasterDetails");
        }
        public DataSet LoadProducerDetailsByAccountHandlerId(int AccountHandlerId)
        {
            object[] parameters = new object[1] { AccountHandlerId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "ProducerDetails_Select", "ProducerDetails");
        }

        public DataSet SaveClientReassingnment(clsUserReassingnment objReAsgn)
        {
            object[] parameters = new object[] { objReAsgn.ReassingnmentId,
                                                 objReAsgn.CurrentUserId,
                                                 objReAsgn.ReassignUserId,
                                                  objReAsgn.UserList,
                                                 objReAsgn.ReassignfromDate,
                                                 objReAsgn.Reassigntodate,
                                                 objReAsgn.Remarks,
                                                 objReAsgn.UserId,
                                                 objReAsgn.isActive,
                                                 objReAsgn.HistFor,
                                                 objReAsgn.PolVersionList,
                                                 objReAsgn.HandlerType
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ClientReassingnment_InsertUpdate", "ClientReassingnmentDetail");
        }
    }
}
