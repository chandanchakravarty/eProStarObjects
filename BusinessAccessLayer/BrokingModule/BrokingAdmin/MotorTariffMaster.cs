using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class MotorTariffMaster
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadMotorTariffMasterDetail(clsMotorTariffMaster objclsMotorTariffMaster)
        {
            object[] parameters = new object[] { objclsMotorTariffMaster.MotorTariffId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MotorTariffMaster_Select", "TM_MotorTariffMaster");

        }

        public DataSet SaveMotorTariffMasterDetail(clsMotorTariffMaster objclsMotorTariffMaster)
        {
            object[] parameters = new object[] { 
                                                
                                                 objclsMotorTariffMaster.MotorTariffId,
                                                 objclsMotorTariffMaster.MotorTariffName,
                                                 objclsMotorTariffMaster.VehicleTypeId,
                                                 objclsMotorTariffMaster.MotorCoverageId,
                                                 objclsMotorTariffMaster.BasicRate,
                                                 objclsMotorTariffMaster.RatePercentage,
                                                 objclsMotorTariffMaster.EffectiveDateFrom,
                                                 objclsMotorTariffMaster.EffectiveDateTo,
                                                 objclsMotorTariffMaster.User,
                                                 objclsMotorTariffMaster.Status
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_MotorTariffMaster_InsertUpdate", "TM_MotorTariffMaster");
        }
    }
}
