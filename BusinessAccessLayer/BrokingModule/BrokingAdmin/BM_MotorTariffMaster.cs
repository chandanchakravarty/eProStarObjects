using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_MotorTariffMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadMotorTariffMaster(clsMotorTariffMaster objclsMotorTariffMaster)
        {
            object[] parameters = new object[] {objclsMotorTariffMaster.MotorTariffId, objclsMotorTariffMaster.Zone,objclsMotorTariffMaster.VehicleTypeId,objclsMotorTariffMaster.EffFromDate,objclsMotorTariffMaster.EffFromDate1,objclsMotorTariffMaster.EffToDate,objclsMotorTariffMaster.EffToDate1 
            };

            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MotorTariffMaster_Select", "TM_MotorTariffMaster");
        }
        public DataSet SaveMotorTariffMaster(clsMotorTariffMaster objclsMotorTariffMaster)
        {
            object[] parameters = new object[] { objclsMotorTariffMaster.MotorTariffId,
                                                    objclsMotorTariffMaster.Zone,
                                                    objclsMotorTariffMaster.VehicleTypeId,
                                                    objclsMotorTariffMaster.MotorcycleTypeId,
                                                    objclsMotorTariffMaster.MultiplyingFactor,
                                                    objclsMotorTariffMaster.EffFromDate,
                                                    objclsMotorTariffMaster.EffToDate,                                                    
                                                    objclsMotorTariffMaster.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MotorTariffMaster_Insert", "TM_MotorTariffMaster");

        }
        public object SaveMotortariffDetail(clsMotorTariffDetail objclsMotorTariffDetail)
        {
            object[] parameters = new object[] { 
                                                    objclsMotorTariffDetail.MotorTariffDetailId,
                                                    objclsMotorTariffDetail.MotorTariffId,
                                                    objclsMotorTariffDetail.UnitTypeFrom,
                                                    objclsMotorTariffDetail.UnitTypeTo,
                                                    objclsMotorTariffDetail.AdditionalTon,
                                                    objclsMotorTariffDetail.Comprehensive,
                                                    objclsMotorTariffDetail.ThirdParty,
                                                    objclsMotorTariffDetail.Act,
                                                    objclsMotorTariffDetail.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.GetScalarValue(parameters, "P_TM_MotorTariffDetail_InsertUpdate");
        }

        public DataSet LoadMotorTariffDetail(int MotorTariffDetailId)
        {
            object[] parameters = new object[] { MotorTariffDetailId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MotorTariffDetail_Select", "TM_MotorTariffDetail");

        }

        public object DeleteMotorTariffDetail(int MotorTariffDetailId)
        {
            object[] parameters = new object[] { MotorTariffDetailId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.GetScalarValue(parameters, "P_TM_MotorTariffDetail_Delete");
        }
    }
}
