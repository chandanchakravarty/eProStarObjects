using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class BM_IndustryMaster
    {
        DataAccess dataAccessDS = null;
        #region IndustryMaster
        public DataSet LoadIndustryMasterData(clsIndustryMaster objclsTemplateDefault)
        {
            object[] parameters = new object[] { objclsTemplateDefault.IndustryId, objclsTemplateDefault.IndustryCode, objclsTemplateDefault.IndustryName, objclsTemplateDefault.EffectiveFromDate, objclsTemplateDefault.EffectiveFromDate1, objclsTemplateDefault.EffectiveToDate, objclsTemplateDefault.EffectiveToDate1 };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_IndustryMaster_Select", "TM_IndustryMaster");

        }
        public DataSet LoadIndustryMasterDataAll(clsIndustryMaster objclsTemplateDefault)
        {
            object[] parameters = new object[] { objclsTemplateDefault.IndustryId };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_IndustryMaster_SelectAll", "TM_IndustryMasterAll");

        }
        #endregion

        public DataSet SaveIndustryMaster(clsIndustryMaster objIndustryMaster)
        {
            object[] parameters = new object[] { 
                                                    objIndustryMaster.IndustryId,
                                                    objIndustryMaster.IndustryCode,
                                                    objIndustryMaster.IndustryName,
                                                    objIndustryMaster.EffectiveFromDate,
                                                    objIndustryMaster.EffectiveToDate,
                                                    objIndustryMaster.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IndustryMaster_InsertUpdate", "TM_IndustryMaster");
        }
    }
}
