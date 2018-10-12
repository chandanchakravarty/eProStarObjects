using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;


namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class BM_TemplateUnderWriter
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveBM_TemplateUnderWriter(clsBM_TemplateUnderWriter objclsBM_TemplateUnderWriter)
        {
            object[] parameters = new object[] {  
                                                objclsBM_TemplateUnderWriter.TemplateId,
                                                objclsBM_TemplateUnderWriter.UnderWriterId
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateUnderWriter_Insert", "TM_TemplateUnderWriter");
        }
        public DataSet LoadBM_TemplateUnderWriter(clsBM_TemplateUnderWriter objclsBM_TemplateUnderWriter)
        {
            object[] parameters = new object[] {  
                                                objclsBM_TemplateUnderWriter.TemplateId                                               
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateUnderWriter_Select", "TM_TemplateUnderWriter");
        }
        public DataSet DeleteBm_TemplateUnderWriter(clsBM_TemplateUnderWriter objclsBM_TemplateUnderWriter)
        {
            object[] parameters = new object[] {  
                                                objclsBM_TemplateUnderWriter.TemplateId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateUnderWriter_Delete", "TM_TemplateUnderWriter");
        }
    }
}
