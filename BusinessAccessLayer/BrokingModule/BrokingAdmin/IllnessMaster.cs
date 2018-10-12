using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class IllnessMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadIllnessMasterDetail(clsIllnessMaster objclsIllnessMaster)
        {
            object[] parameters = new object[] { objclsIllnessMaster.IllnessId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IllnessMaster_Select", "TM_IllnessMaster");

        }

        public DataSet SaveIllnessMasterDetail(clsIllnessMaster objclsIllnessMaster)
        {
            object[] parameters = new object[] { 
                                                 objclsIllnessMaster.ClassId,
                                                 objclsIllnessMaster.SubClassId,
                                                 objclsIllnessMaster.IllnessId,
                                                 objclsIllnessMaster.Header,
                                                 objclsIllnessMaster.Title,
                                                 objclsIllnessMaster.IllnessDescription,
                                                 objclsIllnessMaster.EffectiveDateFrom,
                                                 objclsIllnessMaster.EffectiveDateTo,
                                                 objclsIllnessMaster.User,
                                                 objclsIllnessMaster.Status
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IllnessMaster_InsertUpdate", "TM_IllnessMaster");
        }
    }
}
