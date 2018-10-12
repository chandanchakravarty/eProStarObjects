using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.RIClaimAdmin;

namespace BusinessAccessLayer.RIBrokingModule.RIClaimAdmin
{
    public class LocationMaster
    {
        DataAccess objDataAccess = null;
        public DataSet InsertUpdateLocationDescription(clsLocationMaster objclsLocationMaster)
        {
            objDataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objclsLocationMaster.LocationId ,objclsLocationMaster.LocationCode,objclsLocationMaster.LocationName, objclsLocationMaster.User, objclsLocationMaster.IsActive};
            return objDataAccess.LoadDataSet(parameters, "P_TM_LocationMaster_InsertUpdate", "TM_LocationMaster");
        }

        public DataSet GetLocationDescription(clsLocationMaster objclsLocationMaster)
        {
            objDataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objclsLocationMaster.LocationId };
            return objDataAccess.LoadDataSet(parameters, "P_TM_LocationDescription_Select", "TM_LocationMaster");
        }
    }
}
