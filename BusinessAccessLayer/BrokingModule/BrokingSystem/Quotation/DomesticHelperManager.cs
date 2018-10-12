using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
   public class DomesticHelperManager
    {

        DataAccess dataAccess = null;

        public DataSet SaveHelperDetails(clsDomesticHelperDet objDomesticHelperDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[11] { objDomesticHelperDetails.HelperNameId, objDomesticHelperDetails.PolicyId, objDomesticHelperDetails.PolVersionId,
             objDomesticHelperDetails.HelperName,objDomesticHelperDetails.DateOfBirth,objDomesticHelperDetails.PassportNo,objDomesticHelperDetails.Nationality,
             objDomesticHelperDetails.PlaceOfEmployment,objDomesticHelperDetails.POIFromDate,objDomesticHelperDetails.POIToDate,objDomesticHelperDetails.UserID };
            return dataAccess.LoadDataSet(parametes, "P_Pol_DomesticHelper_InsertUpdate", "P_Pol_DomesticHelper_InsertUpdate");
        }
        public DataSet GetHelperDetails(clsDomesticHelperDet objDomesticHelperDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objDomesticHelperDetails.PolicyId, objDomesticHelperDetails.PolVersionId, objDomesticHelperDetails.HelperNameId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_DomesticHelperDetails", "PolicyHelperDetails");
        }
        public DataSet DeleteHelperDetails(clsDomesticHelperDet objDomesticHelperDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objDomesticHelperDetails.PolicyId, objDomesticHelperDetails.PolVersionId, objDomesticHelperDetails.HelperNameId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_DomesticHelperDet_Delete", "PolicyHelperDetails");
        }
        public DataSet GetBindHelperDetails(clsDomesticHelperDet objDomesticHelperDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objDomesticHelperDetails.PolicyId, objDomesticHelperDetails.PolVersionId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_DomesticHelperDetailsBind", "PolicyHelperDetailsBind");
        }
    }
}
