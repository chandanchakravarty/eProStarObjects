using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class CorpGrpManager
    {
        public DataSet LoadCorporateGroupMasterData(ClsCorpGrpMaster objclsTemplateDefault)
        {      //, objclsTemplateDefault.SubClassId 
            object[] parameters = new object[] { 
                    objclsTemplateDefault.CorpGroupId,
                    objclsTemplateDefault.CorpGroupCode,
                    objclsTemplateDefault.CorpGroupType,
                    objclsTemplateDefault.CorpGroupDesc,
                    objclsTemplateDefault.EffectiveFromDate,
                    objclsTemplateDefault.EffectiveToDate,
                    objclsTemplateDefault.EffectiveFromDate1,
                    objclsTemplateDefault.EffectiveToDate1
            };

            return (new DataAccess()).LoadDataSet(parameters, "P_TM_CorporateGroupMaster_Select", "TM_CorporateGroupMaster");

        }
        public DataSet LoadCorporateGroupMasterDataAll(ClsCorpGrpMaster objclsTemplateDefault)
        {
            object[] parameters = new object[] { objclsTemplateDefault.CorpGroupId };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_CorporateGroupMaster_SelectAll", "TM_CorporateGroupMasterAll");

        }

        public DataSet SaveCGMaster(ClsCorpGrpMaster objCG)
        {

            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objCG.CorpGroupId,
                                                objCG.CorpGroupCode,
                                               objCG.CorpGroupType,
                                               objCG.CorpGroupDesc,
                                               objCG.EffectiveFromDate,
                                               objCG.EffectiveToDate,
                                               objCG.LoginUserId,
                                               objCG.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_CorporateGroup_InsertUpdate", "CorpGrp");
        }

        public DataSet LoadCorporateGroupMasterForDropDown(string CorpGroupType)
        {
            object[] parameters = new object[] { CorpGroupType };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_CorporateGroupMaster_SelectByCorpGroupType", "TM_CorporateGroupByGroupType");
        }
    }
}
