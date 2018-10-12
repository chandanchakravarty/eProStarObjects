using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsBusinessNatureManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBusinessNature(clsBusinessNature objBusinessNature)
        {
            object[] parameters = new object[1] { objBusinessNature.BusinessNatureID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BusinessNatureMaster_Select", "BusinessNatureSelect");

        }
        public DataSet SaveBusinessNatureMaster(clsBusinessNature objBusinessNature)
        {
            object[] parameters = new object[] { objBusinessNature.BusinessNatureID,
                                                 objBusinessNature.AnalysisCategory,
                                                 objBusinessNature.BalBF_NRP,
                                                 objBusinessNature.BusinessNatureCode,
                                                 objBusinessNature.BusinessNatureDescription,
                                                 objBusinessNature.EffFromDate,
                                                 objBusinessNature.EffToDate,
                                                 objBusinessNature.Status,
                                                 objBusinessNature.LoginUserId,
                                                 objBusinessNature.PageMethod
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BusinessNatureMaster_InsertUpdate", "BusinessNatureDetail");

        }
    }
}
