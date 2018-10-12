using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class InterestMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadInterestMasterDetail(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { objclsInterestMaster.InterestId, objclsInterestMaster.ClassId, objclsInterestMaster.SubClassId, objclsInterestMaster.EffectiveDateFrom, objclsInterestMaster.EffectiveDateFrom1, objclsInterestMaster.EffectiveDateTo, objclsInterestMaster.EffectiveDateTo1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_InterestMaster_Select", "TM_InterestMaster");

        }
        public DataSet LoadInterestMasterDetails(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { objclsInterestMaster.InterestId, objclsInterestMaster.ClassId, objclsInterestMaster.SubClassId, objclsInterestMaster.EffectiveDateFrom, objclsInterestMaster.EffectiveDateFrom1, objclsInterestMaster.EffectiveDateTo, objclsInterestMaster.EffectiveDateTo1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_InterestMaster_Get", "TM_InterestMaster");

        }
        public DataSet SaveInterestMasterDetail(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { 
                                                 objclsInterestMaster.ClassId,
                                                 objclsInterestMaster.SubClassId,
                                                 objclsInterestMaster.InterestId,
                                                 objclsInterestMaster.Header,
                                                 objclsInterestMaster.InterestDescription,
                                                 objclsInterestMaster.SumInsured,
                                                 objclsInterestMaster.Valuation,
                                                 objclsInterestMaster.EffectiveDateFrom,
                                                 objclsInterestMaster.EffectiveDateTo,
                                                 objclsInterestMaster.User,
                                                 objclsInterestMaster.Status
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_InterestMaster_InsertUpdate", "TM_InterestMaster");
        }

        public DataSet LoadInterestPremiumTotal(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { objclsInterestMaster.PolicyId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_GET_PremiumBalance", "TM_Balance");

        }
        public DataSet LoadInterestInsuredInterestMasterDetail(clsInterestMaster objclsInterestMaster)
        {
            object[] parameters = new object[] { objclsInterestMaster.InterestId, objclsInterestMaster.ClassId, objclsInterestMaster.SubClassId, objclsInterestMaster.EffectiveDateFrom, objclsInterestMaster.EffectiveDateFrom1, objclsInterestMaster.EffectiveDateTo, objclsInterestMaster.EffectiveDateTo1,objclsInterestMaster.PolicyId,objclsInterestMaster.LocationInterestId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_POL_InterestInsured_InterestMaster_Select", "TM_InterestMaster");

        }
    }
}
