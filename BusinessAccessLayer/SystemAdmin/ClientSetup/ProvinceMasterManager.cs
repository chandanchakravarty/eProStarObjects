using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;
namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
  public  class ProvinceMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadProvince(clsProvinceMaster objProvince)
        {
            object[] parameters = new object[1] { objProvince.ProvinceId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProvinceMaster_Select", "ProvinceSelect");
        }

        public DataSet LoadProvinceAll(clsProvinceMaster objProvince)
        {
            object[] parameters = new object[2] { objProvince.TerrName, objProvince.ProvinceName};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProvinceMaster_SelectAll", "ProvinceSelectAll");

        }
              public DataSet SaveProvince(clsProvinceMaster objProvince)
        {
            object[] parameters = new object[] { objProvince.ProvinceId,
                                                 objProvince.TerrotoryId,
                                                 objProvince.ProvinceName,
                                                 objProvince.ProvinceNameChineese,
                                                 objProvince.User,
                                                 objProvince.isActive
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProvinceMaster_InsertUpdate", "ProvinceDetail");

        }
    }
}
