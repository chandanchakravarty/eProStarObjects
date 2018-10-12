using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BACommonTypes
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBMCommonTypesDetail(clsBACommonTypes objclsBACommonTypes)
        {
            object[] parameters = new object[] { objclsBACommonTypes.frmfor, objclsBACommonTypes.BATypeId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BACommonTypes_Select", "TM_BACommonTypes");

        }

        public DataSet LoadBMCommonTypesDetailAll(clsBACommonTypes objclsBACommonTypes)
        {
            object[] parameters = new object[] { objclsBACommonTypes.frmfor, objclsBACommonTypes.BATypeName ,objclsBACommonTypes.EffFromDate,objclsBACommonTypes.EffFromDate1 ,objclsBACommonTypes.EffToDate,objclsBACommonTypes.EffToDate1  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BACommonTypes_SelectAll", "TM_BACommonTypesAll");

        }

        public DataSet SaveBMCommonTypesDetail(clsBACommonTypes objclsBACommonTypes)
        {
            object[] parameters = new object[] { objclsBACommonTypes.frmfor,
                                                 objclsBACommonTypes.BATypeId,
                                                 objclsBACommonTypes.BATypeName,
                                                 objclsBACommonTypes.EffFromDate,
                                                 objclsBACommonTypes.EffToDate,
                                                 objclsBACommonTypes.User,
                                                 objclsBACommonTypes.Status,
                                                 objclsBACommonTypes.VehicleType,
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BACommonTypes_InsertUpdate", "TM_BACommonTypes");
        }
    }
}
