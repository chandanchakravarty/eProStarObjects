using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class ConditionTemplate
    {
        DataAccess dataAccessDS = null;

        public DataSet LoadConditionTemplate(clsConditionTemplate objclsConditionTemplate)
        {
            object[] parameters = new object[] { objclsConditionTemplate.ClassID,objclsConditionTemplate.SubClassID,objclsConditionTemplate.ConditionTemplateID};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionTemplate_Select", "TM_ConditionTemplate");

        }

        public DataSet SaveConditionTemplate(clsConditionTemplate objclsConditionTemplate)
        {
            object[] parameters = new object[] {  
                                                  objclsConditionTemplate.ConditionTemplateID,
                                                  objclsConditionTemplate.ConditionTemplateName,
                                                  objclsConditionTemplate.ClassID,
                                                  objclsConditionTemplate.SubClassID,
                                                  objclsConditionTemplate.EffectiveDateFrom,
                                                  objclsConditionTemplate.EffectiveDateTo,
                                                  objclsConditionTemplate.User,
                                                  objclsConditionTemplate.Status,
                                                  objclsConditionTemplate.CopyTemplateID
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionTemplate_InsertUpdate", "TM_ConditionTemplate");

        
        }


    }
}
