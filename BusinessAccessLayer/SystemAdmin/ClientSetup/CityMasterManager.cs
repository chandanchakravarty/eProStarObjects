using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class CityMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadCity(clsCityMaster objCity)
        {
            object[] parameters = new object[1] { objCity.CityId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CityMaster_Select", "CitySelect");

        }

        //function added by kavita kaushik for select record based on search parameters//
        public DataSet LoadCityAll(clsCityMaster objCity)
        {
            object[] parameters = new object[4] {objCity.AreaCode ,objCity.CityName,objCity.ProvinceName ,objCity.TerrName};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CityMaster_SelectAll", "CitySelectAll");

        }
        //end of function//

        public DataSet SaveCity(clsCityMaster objCity)
        {
            object[] parameters = new object[] { objCity.CityId,
                                                 objCity.AreaCode,
                                                 objCity.TerritoryId,
                                                 objCity.ProvinceId,
                                                 objCity.CityName,
                                                 objCity.CityNameChinese,
                                                 objCity.User,
                                                 objCity.isActive
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CityMaster_InsertUpdate", "CityDetail");

        }
    }
}
