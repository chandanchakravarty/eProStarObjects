using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;
using DataAccessLayer;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class RI_ProvinceMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadProvince(clsRI_ProvinceMaster objProvince)
        {
            object[] parameters = new object[1] { objProvince.ProvinceId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProvinceMaster_Select", "ProvinceSelect");

        }
        public DataSet SaveProvince(clsRI_ProvinceMaster objProvince)
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
