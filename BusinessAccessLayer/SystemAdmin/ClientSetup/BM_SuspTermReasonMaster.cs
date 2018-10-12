using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class BM_SuspTermReasonMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadSuspensionTerminationReasonMaster(clsSuspTermReasonMaster objSuspTermReasonMaster)
        {
            object[] parameters = new object[] { objSuspTermReasonMaster.ReasonId, objSuspTermReasonMaster.ReasonDescription, objSuspTermReasonMaster.EffFromDate, objSuspTermReasonMaster.EffFromDate1, objSuspTermReasonMaster.EffToDate, objSuspTermReasonMaster.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SusTermReasonMaster_Select", "TM_SusTermReasonMaster");
        }

        public DataSet SaveSuspensionTerminationReasonMaster(clsSuspTermReasonMaster objSuspTermReasonMaster)
        {
            object[] parameters = new object[] { objSuspTermReasonMaster.ReasonId,
                                                 objSuspTermReasonMaster.ReasonDescription,                                                 
                                                 objSuspTermReasonMaster.EffFromDate,
                                                 objSuspTermReasonMaster.EffToDate,
                                                 objSuspTermReasonMaster.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SusTermReasonMaster_InsertUpdate", "TM_SusTermReasonMaster");

        }

        
    }
}
