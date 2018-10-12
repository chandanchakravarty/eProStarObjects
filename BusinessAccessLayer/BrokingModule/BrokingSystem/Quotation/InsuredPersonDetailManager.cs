using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class InsuredPersonDetailManager
    {
        DataAccess dataAccess = null;

        public DataSet SaveInsuredPersonDetails(clsInsuredPersonDetail objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[13] { objInsuredPersonDetails.RefNo, objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId,
            objInsuredPersonDetails.InsuredName,objInsuredPersonDetails.Surname,
            objInsuredPersonDetails.DOB,objInsuredPersonDetails.Gender,objInsuredPersonDetails.MaritalStatus,objInsuredPersonDetails.Nationality,
            objInsuredPersonDetails.CountryOfRes,objInsuredPersonDetails.StaffID,objInsuredPersonDetails.IsActive, objInsuredPersonDetails.UserID  };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonDetailsInsertUpdate", "PolicyInsuredPersonDetailsInsertUpdate");
        }

        public DataSet GetInsuredPersonDetails(clsInsuredPersonDetail objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonDetails", "PolicyInsuredPersonDetails");
        }

        public DataSet DeleteInsuredPersonDetails(clsInsuredPersonDetail objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonDetails_Delete", "PolicyInsuredPersonDetails");
        }

        public DataSet GetBindInsuredDetails(clsInsuredPersonDetail objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonDetailsBind", "PolicyInsuredPersonDetailsBind");
        }

        //public DataSet GetFillDowndownlist(clsInsuredPersonDetail objInsuredPersonDetails)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parametes = new Object[1] { objInsuredPersonDetails.VehicleType };
        //    return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorVehicleType", "PolicyMotorDetailsBind");
        //}

        //public DataSet GetFillInsuredPersonTriff(clsInsuredPersonDetail objInsuredPersonDetails)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parametes = new Object[2] { objInsuredPersonDetails.VehicleTypeID, objInsuredPersonDetails.CoverageID };
        //    return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_MotorTariff", "PolicyMotorDetailsBind");
        //}

    }
}
