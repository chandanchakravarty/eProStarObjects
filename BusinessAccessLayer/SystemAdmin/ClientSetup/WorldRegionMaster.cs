using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
  public  class WorldRegionMaster
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadWorldRegionMaster(clsWorldRegionMaster objWorldRegMaster)
        {
            object[] parameters = new object[6] { objWorldRegMaster.WorldRegId,
                                                  objWorldRegMaster.worldRegName, 
                                                  objWorldRegMaster.EffFromDate,
                                                  objWorldRegMaster.EffFromDate1, 
                                                  objWorldRegMaster.EffToDate, 
                                                  objWorldRegMaster.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_WorldRegionSummary_Select", "TM_WordRegions");
        }

        public DataSet SaveWorldRegionMaster(clsWorldRegionMaster objWorldRegMaster)
        {
            object[] parameters = new object[] { objWorldRegMaster.WorldRegId,
                                                 objWorldRegMaster.worldRegName,                                                 
                                                 objWorldRegMaster.EffFromDate,
                                                 objWorldRegMaster.EffToDate,
                                                 objWorldRegMaster.UserName,
                                                 objWorldRegMaster.Status,
                                                 objWorldRegMaster.PageMethod
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_SysAdm_CSetup_WORLDREGION_InsertUpdate", "TM_WordRegions");
        }
    }
}
