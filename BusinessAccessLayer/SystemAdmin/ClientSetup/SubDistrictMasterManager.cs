using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
  public   class SubDistrictMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadSubDistrict(clsSubDistrictMaster objSubDistrict)
        {
            object[] parameters = new object[1] { objSubDistrict.SubDistrictId  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubDistrictMaster_Select", "SubDistrictSelect");

        }
    
        //function added by kavita kaushik for select record based on search parameters//
        public DataSet LoadSubDistrictAll(clsSubDistrictMaster objSubDistrict)
        {
            object[] parameters = new object[5] { objSubDistrict.AreaCode, objSubDistrict.SubDistrictName,objSubDistrict.DistrictName , objSubDistrict.ProvinceName, objSubDistrict.TerrName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubDistrictMaster_SelectAll", "SubDistrictSelectAll");

        }
        //end of function//

        public DataSet SaveSubDistrict(clsSubDistrictMaster objSubDistrict)
        {
            object[] parameters = new object[] { objSubDistrict.SubDistrictId ,
                                                 objSubDistrict.DistrictId ,
                                                 objSubDistrict.TerritoryId,
                                                 objSubDistrict.ProvinceId,
                                              
                                                  objSubDistrict.AreaCode,
                                                 objSubDistrict.SubDistrictName ,
                                                 objSubDistrict.SubDistrictNameChinese ,
                                                 objSubDistrict.User,
                                                 objSubDistrict.isActive
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubDistrictMaster_InsertUpdate", "SubDistrictDetail");

        }
    }
    
}
