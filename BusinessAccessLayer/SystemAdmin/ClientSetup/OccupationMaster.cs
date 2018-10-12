using System;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
  public  class OccupationMaster
    {
      DataAccess dataAccessDS = null;
      public DataSet LoadOccupation(clsOccupationMaster objclsOccupationMaster)
      {
          object[] parameters = new object[1] { objclsOccupationMaster.Lookup_ID };
          dataAccessDS = new DataAccess();
          return dataAccessDS.LoadDataSet(parameters, "P_TM_OccupationMaster_Select", "TM_Lookups");

      }

      public DataSet SaveOccupation(clsOccupationMaster objclsOccupationMaster)
      {
          object[] parameters = new object[5] { objclsOccupationMaster.Lookup_ID,
                                                objclsOccupationMaster.Lookup_desc,
                                                objclsOccupationMaster.IsEditable,
                                                objclsOccupationMaster.User,
                                                objclsOccupationMaster.IsActive};
          dataAccessDS = new DataAccess();
          return dataAccessDS.LoadDataSet(parameters, "P_TM_OccupationMaster_InsertUpdate", "TM_Lookups");

      }
    }
}
