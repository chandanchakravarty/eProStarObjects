using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public  class BM_TemplateMapping
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveBM_TemplateMapping(clsBM_TemplateMapping objclsBM_TemplateMapping)
        {
            object[] parameters = new object[] {  
                                               
                                               objclsBM_TemplateMapping.TemplateId,
                                               objclsBM_TemplateMapping.HeaderId,
                                               objclsBM_TemplateMapping.IsSelected,
                                               objclsBM_TemplateMapping.OrderNo,
                                               objclsBM_TemplateMapping.UserId
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateMapping_InsertUpdate", "TM_BM_TemplateMapping");
        }
        public DataSet LoadBM_TemplateMapping(clsBM_TemplateMapping objclsBM_TemplateMapping)
        {
            object[] parameters = new object[] {  
                                               objclsBM_TemplateMapping.frmFor,
                                               objclsBM_TemplateMapping.TemplateId,
                                               objclsBM_TemplateMapping.ClassId,
                                               objclsBM_TemplateMapping.SubClassId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateMapping_Select", "TM_BM_TemplateMapping");
        }
    }
}
