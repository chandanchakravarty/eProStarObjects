using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_FireTariffGroupMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadFireTariffGroupMaster(clsFireTariffGroupMaster objFireTariffGroupMaster)
        {
            object[] parameters = new object[] { objFireTariffGroupMaster.FireTariffGroupId, objFireTariffGroupMaster.GroupCode, objFireTariffGroupMaster.Classification, objFireTariffGroupMaster.EffFromDate, objFireTariffGroupMaster.EffFromDate1, objFireTariffGroupMaster.EffToDate, objFireTariffGroupMaster.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_FireTariffGroupMaster_Select", "TM_FireTariffGroupMaster");
        }

        public DataSet SaveFireTariffGroupMaster(clsFireTariffGroupMaster objFireTariffGroupMaster)
        {
            object[] parameters = new object[] { objFireTariffGroupMaster.FireTariffGroupId,
                                                 objFireTariffGroupMaster.GroupCode,
                                                 objFireTariffGroupMaster.Classification,                                                 
                                                 objFireTariffGroupMaster.EffFromDate,
                                                 objFireTariffGroupMaster.EffToDate,
                                                 objFireTariffGroupMaster.User
                                              };
            dataAccessDS = new DataAccess();
            //return Convert.ToString(dataAccessDS.GetScalarValue(parameters, "P_TM_FireTariffGroupMaster_InsertUpdate"));
            return dataAccessDS.LoadDataSet(parameters, "P_TM_FireTariffGroupMaster_InsertUpdate", "TM_FireTariffGroupMaster");

        }
    }

    public class BM_FireTariffMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadFireTariffMaster(clsFireTariffMaster objFireTariffMaster)
        {
            object[] parameters = new object[] { objFireTariffMaster.FireTariffGroupId, objFireTariffMaster.FireTariffId, objFireTariffMaster.Code, objFireTariffMaster.TOClassification };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_FireTariffMaster_Select", "TM_FireTariffMaster");
        }

        public DataSet SaveFireTariffMaster(clsFireTariffMaster objFireTariffMaster)
        {
            object[] parameters = new object[] { objFireTariffMaster.FireTariffId,
                                                    objFireTariffMaster.FireTariffGroupId,
                                                    objFireTariffMaster.Code,
                                                    objFireTariffMaster.TOClassification,
                                                    objFireTariffMaster.ConstructionClassification1A,
                                                    objFireTariffMaster.ConstructionClassification1B,
                                                    objFireTariffMaster.ConstructionClassification2,
                                                    objFireTariffMaster.ConstructionClassification3,
                                                    objFireTariffMaster.WarrantyApplicable,                                                    
                                                    objFireTariffMaster.User
                                              };
            dataAccessDS = new DataAccess();            
            return dataAccessDS.LoadDataSet(parameters, "P_TM_FireTariffMaster_InsertUpdate", "TM_FireTariffMaster");

        }
    }
}
