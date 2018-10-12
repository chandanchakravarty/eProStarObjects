using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
   
   public class ConditionMaster
    {
       DataAccess dataAccessDS = null;
       public DataSet LoadCondtionDetail(clsConditionMaster objConditionMaster)
       {
           object[] parameters = new object[] { objConditionMaster.ConditionId };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionMaster_Select", "TM_ConditionMaster");

       }

       public DataSet SaveConditionDetail(clsConditionMaster objConditionMaster)
       {
           object[] parameters = new object[] {  objConditionMaster.ClassID,
                                                 objConditionMaster.SubClassID,
                                                 objConditionMaster.ConditionId,
                                                 objConditionMaster.ConditionHeader,
                                                 objConditionMaster.ConditionHeaderCH,
                                                 objConditionMaster.ConditionDescription,
                                                 objConditionMaster.EffectiveDateFrom,
                                                 objConditionMaster.EffectiveDateTo,
                                                 objConditionMaster.User,
                                                 objConditionMaster.Status
                                              };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionMaster_InsertUpdate", "TM_ConditionMaster");
       }


    }
}
