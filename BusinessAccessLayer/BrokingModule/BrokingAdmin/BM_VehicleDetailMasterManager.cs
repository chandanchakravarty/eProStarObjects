using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_VehicleDetailMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadVehicleDetails(clsVehicleDetailMaster objVehicleDetail)
        {
            object[] parameter = new object[8] { objVehicleDetail.VehicleTypeID, objVehicleDetail.VehicleType, objVehicleDetail.Units, objVehicleDetail.SumInsured, objVehicleDetail.EffFromDate, objVehicleDetail.EffFromDate1, objVehicleDetail.EffToDate, objVehicleDetail.EffToDate1 };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_BM_VehicleDetailMaster_Select", "VehicleDetailSelect");
        }


        public DataSet SaveVehicleDetailMaster(clsVehicleDetailMaster objVehicleDetailMaster)
        {
            object[] parameters = new object[] { objVehicleDetailMaster.VehicleTypeID,
                                                    objVehicleDetailMaster.VehicleType,
                                                    objVehicleDetailMaster.Units,
                                                    objVehicleDetailMaster.SumInsured,
                                                    objVehicleDetailMaster.EffFromDate,
                                                    objVehicleDetailMaster.EffToDate,
                                                    objVehicleDetailMaster.User
                                              };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_VehicleDetail_InsUpd", "VehicleDetail_InsUpd");
        }
    }
}
