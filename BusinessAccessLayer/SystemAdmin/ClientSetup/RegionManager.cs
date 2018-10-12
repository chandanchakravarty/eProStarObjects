using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class RegionManager
    {
        DataAccess dataAccess = null;
        clsRegion objinfo = new clsRegion();

        public DataSet getRegionAll(clsRegion objRegioninfo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objRegioninfo.RegionId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_RegionList", "RegionList");
        }

        public DataSet getRegionSrch(clsRegion objRegionnfo)
        {
            dataAccess = new DataAccess();
            if (objRegionnfo.RegionCode == null)
            {
                objRegionnfo.RegionCode = "";
            }
            if (objRegionnfo.RegionName == null)
            {
                objRegionnfo.RegionName = "";
            }
            if (objRegionnfo.EffectiveFromDate == null)
            {
                objRegionnfo.EffectiveFromDate = "";
            }
            if (objRegionnfo.EffectiveFromDate1 == null)
            {
                objRegionnfo.EffectiveFromDate1 = "";
            }
            if (objRegionnfo.EffectiveToDate == null)
            {
                objRegionnfo.EffectiveToDate = "";
            }
            if (objRegionnfo.EffectiveToDate1 == null)
            {
                objRegionnfo.EffectiveToDate1 = "";
            }
            Object[] parameters = new Object[] { objRegionnfo.RegionCode, objRegionnfo.RegionName, objRegionnfo.EffectiveFromDate, objRegionnfo.EffectiveFromDate1, objRegionnfo.EffectiveToDate, objRegionnfo.EffectiveToDate1 };
            return dataAccess.LoadDataSet(parameters, "P_Adm_RegionListAll", "RegionList");
        }

        public DataSet SaveRegionMaster(clsRegion objRegion)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objRegion.RegionId,
                                               objRegion.RegionCode,
                                               objRegion.RegionName,
                                               objRegion.EffectiveFromDate,
                                               objRegion.EffectiveToDate,
                                               objRegion.LoginUserId,
                                               objRegion.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_Region_InsertUpdate", "Regiontab");
        }
    }
}
