using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class RegionMaster
    {
        DataAccess dataAccess = null;

        public DataSet GetRegionDetails(clsRegionMaster objRegion)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objRegion.RegionID, objRegion.RegionCode, objRegion.RegionName, objRegion.EffFrom, objRegion.EffFrom1, objRegion.EffTo, objRegion.EffTo1 };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetRegionDetails", "RegionDetails");
        }

        public DataSet SaveRegionDetails(clsRegionMaster objRegion)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objRegion.RegionID,
                objRegion.RegionCode,
                objRegion.RegionName,
                objRegion.EffFrom ,
                objRegion.EffTo  ,
                objRegion.CreatedBy
            };

            return dataAccess.LoadDataSet(parameters, "P_TM_RegionDetails_InsertUpdate", "RegionInsertUpdate");
        }
    }
}
