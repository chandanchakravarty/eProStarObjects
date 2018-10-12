using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class MotroDetailsManager
    {
        DataAccess dataAccess = null;
        
        public DataSet SaveMotorDetails(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objMotorDetails.RefNo, objMotorDetails.PolicyId, objMotorDetails.PolVersionId,
            objMotorDetails.VehicleType,objMotorDetails.RegistrationNo,
            objMotorDetails.Make,objMotorDetails.Model,objMotorDetails.EngineNo,objMotorDetails.ChassisNo,
            objMotorDetails.CubicCapacity,objMotorDetails.SeatingCapacity,objMotorDetails.TypeOfBody,
            objMotorDetails.NoOfClaimDiscount,objMotorDetails.FleetNo,objMotorDetails.RegistrationDate,
            objMotorDetails.ManufactureYear,objMotorDetails.CommecimalVehType,objMotorDetails.LicenceExpiryDate,
            objMotorDetails.Licensed,objMotorDetails.BusAirCon,objMotorDetails.BusType, objMotorDetails.UserID, 
            objMotorDetails.VehicleTypeID ,objMotorDetails.VehicleTypeName ,objMotorDetails.CoverageID ,objMotorDetails.CoverageName ,       
            objMotorDetails.BasicRate ,objMotorDetails.RatePercentage ,objMotorDetails.SumInsured ,objMotorDetails.Premium,objMotorDetails.MotorMultipleBilling,
            objMotorDetails.Excess,objMotorDetails.ZoneType,objMotorDetails.CCTonnage,objMotorDetails.VehicleLogBookNo,objMotorDetails.WindscreenSI,
            objMotorDetails.LoadingPer,objMotorDetails.LoadingAmt,objMotorDetails.AllRiderPer,objMotorDetails.AllRiderAmt,objMotorDetails.NCBPer,
            objMotorDetails.NCBAmt,objMotorDetails.WindscreenPer,objMotorDetails.WindscreenAmt,objMotorDetails.ADND,objMotorDetails.LLTP,objMotorDetails.LLOP,
            objMotorDetails.SRCC,objMotorDetails.RdoCassettePer,objMotorDetails.RdoCassetteAmt,objMotorDetails.Flood,objMotorDetails.TPWR,
            objMotorDetails.TotalPremium  };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorDetailsInsertUpdate", "PolicyMotorDetailsInsertUpdate");
        }
        public DataSet GetMotorDetails(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objMotorDetails.PolicyId, objMotorDetails.PolVersionId,objMotorDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorDetails", "PolicyMotorDetails");
        }
        public DataSet DeleteMotorDetails(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objMotorDetails.PolicyId, objMotorDetails.PolVersionId, objMotorDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorDetails_Delete", "PolicyMotorDetails");
        }
        public DataSet ResetMotorMutipleBill(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objMotorDetails.PolicyId, objMotorDetails.PolVersionId, objMotorDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorMutipleBill_Delete", "PolicyMotorDetails");
        }
        public DataSet GetBindMotorDetails(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { objMotorDetails.PolicyId, objMotorDetails.PolVersionId, objMotorDetails.VehicleType,objMotorDetails.RegistrationNo};
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorDetailsBind", "PolicyMotorDetailsBind");
        }
        public DataSet GetFillDowndownlist(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
           // string GSTType = dataAccess.GetScalerValue("select KeyValue from Sys_Params where KeyWord='GSTType'").ToString().Trim();
            Object[] parametes = new Object[1] { objMotorDetails.VehicleType };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorVehicleType", "PolicyMotorDetailsBind");
        }
        public DataSet GetFillMotorTriff(clsMotorDetails objMotorDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objMotorDetails.VehicleTypeID,objMotorDetails.CoverageID};
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorTariff", "PolicyMotorDetailsBind");
        }

        public DataSet GetFillCCDowndownlist(string vehType,string zoneval)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { vehType , zoneval };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_CCTonnage", "PolicyCCTonnageBind");
        }

    }
}
