using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class clsNewPremiumRateManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadNewPremRate(clsNewPremiumRateMaster objNewPremRate)
        {
            object[] parameters = new object[1] {objNewPremRate.NewPremRateID};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_NewPremRateMaster_Select", "NewPremRateSelect");

        }

        public DataSet SaveNewPremRate(clsNewPremiumRateMaster objNewPremRate)
        {
            object[] parameters = new object[] { objNewPremRate.NewPremRateID,
                                                 objNewPremRate.ClassName,
                                                 objNewPremRate.SubClassID,
                                                 objNewPremRate.Description,
                                                 objNewPremRate.PremRate,
                                                 objNewPremRate.EffFromDate,
                                                 objNewPremRate.EffToDate,
                                                 objNewPremRate.Status,
                                                 objNewPremRate.LoginUserId,
                                                 objNewPremRate.PageMethod
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_NewPremRateMaster_InsertUpdate", "NewPremRate");

        }
   
    }
}
