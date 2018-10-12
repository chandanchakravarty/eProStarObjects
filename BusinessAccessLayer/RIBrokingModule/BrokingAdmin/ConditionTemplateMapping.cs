using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class ConditionTemplateMapping
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveConditionTemplateMapping(clsConditionTemplateMapping objclsConditionTemplateMapping)
        {
            object[] parameters = new object[] {  
                                               objclsConditionTemplateMapping.ConditionTemplateID,
                                               objclsConditionTemplateMapping.ConditionId,
                                               objclsConditionTemplateMapping.IsSelected
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionTemplateMapping_InsertUpdate", "TM_ConditionTemplateMapping");
        }
       public DataSet LoadConditionTemplateMapping(clsConditionTemplateMapping objclsConditionTemplateMapping)
        {
            object[] parameters = new object[] {  
                                               objclsConditionTemplateMapping.ConditionTemplateID,
                                               objclsConditionTemplateMapping.ClassId,
                                               objclsConditionTemplateMapping.SubClassId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ConditionTemplateMapping_Select", "TM_ConditionTemplateMapping");
        }

    }
}
