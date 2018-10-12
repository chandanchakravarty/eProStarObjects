using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
   public class clsClientReassignment
    {
       DataAccess dataAccess = null;

       public DataSet GetClientReassignmentList(ClientReassignment objClientAssi)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[7] {   objClientAssi.ClientReassignmentId,
                                                   objClientAssi.ClientId,
                                                   objClientAssi.ClientCode,
                                                   objClientAssi.ClientName,
                                                   objClientAssi.SEUserId,
                                                   objClientAssi.MEUserId,
                                                   objClientAssi.ClientShortName};
           return dataAccess.LoadDataSet(parameters, "[P_TM_ClientReassignment_Select]", "ClientreassignmentList");
       }

       public DataSet SaveClientReassignmentList(ClientReassignment objClientAssi)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[9] {   objClientAssi.ClientReassignmentId,
                                                   objClientAssi.ClientId,
                                                   objClientAssi.SEUserId,
                                                   objClientAssi.SeEffectiveDateFrom,
                                                   objClientAssi.SeEffectiveDateTo,
                                                   objClientAssi.MEUserId,
                                                   objClientAssi.MeEffectiveDateFrom,
                                                   objClientAssi.MeEffectiveDateTo,
                                                   objClientAssi.CreatedBy};
           return dataAccess.LoadDataSet(parameters, "[P_TM_ClientReassignment_InsertUpdate]", "SaveClientreassignmentList");
       }
      
    }
}
