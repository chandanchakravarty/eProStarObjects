using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_LocationInterestMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadLocationInterestDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameter = new object[6] { objLocationInterestDetail.LocationID, objLocationInterestDetail.Location, objLocationInterestDetail.Occupation, 
                objLocationInterestDetail.Construction, objLocationInterestDetail.PIAM, objLocationInterestDetail.SumInsuredValue };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_BM_LocationInterestMaster_Select", "LocationInterestSelect");
        }


        public DataSet SaveLocationInterestDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameters = new object[] { objLocationInterestDetail.LocationID,
                                                 objLocationInterestDetail.Location,
                                                 objLocationInterestDetail.Occupation,
                                                 objLocationInterestDetail.Construction,
                                                 objLocationInterestDetail.PIAM,
                                                 objLocationInterestDetail.SumInsuredValue,
                                                 objLocationInterestDetail.User
                                              };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_LocationInterestMasterDetail_InsUpd", "LocationInterestMasterDetail_InsUpd");
        }
        public DataSet DeleteLocationInterestDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameters = new object[] { objLocationInterestDetail.LocationID };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_DeleteLocationInterestMasterDetail", "LocationInterestMasterDetail_Delete");
        }
        public DataSet SavedInsuredInterest(clsInterestMaster objDetails)
        {
            object[] parameters = new object[] { objDetails.InterestIds,objDetails.PolicyId,objDetails.PolVersionId,objDetails.LocationInterestId,objDetails.Order,objDetails.InterestDescription };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_InsertInsuredInterest", "InsuredInterest_Insert");
        }

        public DataSet LoadInsuredInterestDetail(clsInterestMaster objclsInterestMaster)
        {
            object[] parameter = new object[] { objclsInterestMaster.PolicyId, objclsInterestMaster.PolVersionId,objclsInterestMaster.LocationInterestId,objclsInterestMaster.Construction,objclsInterestMaster.PIAM,objclsInterestMaster.isReload };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Pol_InsuredInterestDetail_Select", "InsuredInterestDetailSelect");
        }

        public DataSet DeleteInsuredInterestDetail(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { objclsInterestMaster.InterestId,objclsInterestMaster.PolicyId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_DeleteInsuredInterestDetail", "InsuredInterestDetail_Delete");
        }

        public DataSet UpdateInsuredInterest(clsInterestInsured objDetails)
        {
            object[] parameters = new object[] { objDetails.PolicyId,objDetails.SumInsured,objDetails.Remarks,objDetails.Premium,objDetails.InterestDescription,objDetails.Rates,objDetails.InterestId};
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_InsertInsuredUpdate", "InsuredInterest_Update");
        }
        public DataSet SaveInterestInsuredLocationInterestDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameters = new object[] { objLocationInterestDetail.LocationID,
                                                 objLocationInterestDetail.Location,
                                                 objLocationInterestDetail.Occupation,
                                                 objLocationInterestDetail.Construction,
                                                 objLocationInterestDetail.PIAM,
                                                 objLocationInterestDetail.SumInsuredValue,
                                                 objLocationInterestDetail.PolicyId,
                                                 objLocationInterestDetail.PolVersionId,
                                                 objLocationInterestDetail.QuotationNo,
                                                 objLocationInterestDetail.MainClassid,
                                                 objLocationInterestDetail.SubclassId,
                                                 objLocationInterestDetail.User
                                              };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_POL_InsuredInterest_LocationInterestDetail_InsertUpdate", "InsuredInterestLocationInterestDetail");
        }
        public DataSet LoadInterestInsuredLocationInterestDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameter = new object[7] { objLocationInterestDetail.LocationID, objLocationInterestDetail.Location, objLocationInterestDetail.Occupation, 
                objLocationInterestDetail.Construction, objLocationInterestDetail.PIAM, objLocationInterestDetail.SumInsuredValue,objLocationInterestDetail.PolicyId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_BM_InterestInsuredLocationInterest_Select", "LocationInterestInsuredInterestSelect");
        }
        public DataSet DeleteInterestInsuredLocationDetail(clsLocationInterestMaster objLocationInterestDetail)
        {
            object[] parameters = new object[] { objLocationInterestDetail.LocationID,objLocationInterestDetail.PolicyId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_POL_InsuredInterest_LocationInterestDetailDelete", "LocationInterestInsuredInterest_Delete");
        }
        public DataSet LoadInsuredRates(clsInterestMaster objclsInterestMaster)
        {
            object[] parameter = new object[] { objclsInterestMaster.Construction,objclsInterestMaster.PIAM,objclsInterestMaster.LocationInterestId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Pol_LoadInsuredRates", "LoadInsuredRates");
        }
    }
}
