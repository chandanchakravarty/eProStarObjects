using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class BM_TemplateMaster
    {
        DataAccess dataAccessDS = null;

        public DataSet LoadBM_TemplateMaster(clsBM_TemplateMaster objclsBM_TemplateMaster)
        {
            object[] parameters = new object[] { objclsBM_TemplateMaster.frmFor,objclsBM_TemplateMaster.ClassId, objclsBM_TemplateMaster.SubClassId, objclsBM_TemplateMaster.TemplateId,objclsBM_TemplateMaster.UWID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateMaster_Select", "TM_BM_TemplateMaster");

        }

        public DataSet LoadBM_TemplateMasterAll(clsBM_TemplateMaster objclsBM_TemplateMaster)
        {
            object[] parameters = new object[] { objclsBM_TemplateMaster.frmFor, objclsBM_TemplateMaster.MainClass, objclsBM_TemplateMaster.SubClass , objclsBM_TemplateMaster.TemplateName ,objclsBM_TemplateMaster.EffFromDate,objclsBM_TemplateMaster.EffFromDate1,objclsBM_TemplateMaster.EffToDate,objclsBM_TemplateMaster.EffToDate1};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateMaster_SelectAll", "TM_BM_TemplateMasterAll");

        }

        public DataSet SaveBM_TemplateMaster(clsBM_TemplateMaster objclsBM_TemplateMaster)
        {
            object[] parameters = new object[] {  
                                                  objclsBM_TemplateMaster.frmFor,
                                                  objclsBM_TemplateMaster.TemplateId,
                                                  objclsBM_TemplateMaster.TemplateName,
                                                  objclsBM_TemplateMaster.ClassId,
                                                  objclsBM_TemplateMaster.SubClassId,
                                                  objclsBM_TemplateMaster.EffFromDate ,
                                                  objclsBM_TemplateMaster.EffToDate ,
                                                  objclsBM_TemplateMaster.User,
                                                  objclsBM_TemplateMaster.Status, 
                                                  objclsBM_TemplateMaster.UnderWriterList
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_TemplateMaster_InsertUpdate", "TM_BM_TemplateMaster");
        }
    }
}
