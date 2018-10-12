using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class TemplateDefault
    {
        DataAccess dataAccessDS = null;

        public DataSet LoadTemplateDefaultData(clsTemplateDefault objclsTemplateDefault)
        {      //, objclsTemplateDefault.SubClassId 
            object[] parameters = new object[] { objclsTemplateDefault.TemplateDefaultId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultData_Select", "TM_TemplateDefaultData");

        }


        public DataSet LoadTemplateDefaultDataAll(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] { objclsTemplateDefault.MainClass,objclsTemplateDefault.SubClass,objclsTemplateDefault.FieldName , objclsTemplateDefault.TemplateFieldDescription,objclsTemplateDefault.EffFromDate,objclsTemplateDefault.EffFromDate1,objclsTemplateDefault.EffToDate,objclsTemplateDefault.EffToDate1 
            };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultData_SelectAll", "TM_TemplateDefaultDataAll");

        }
        public DataSet LoadTemplateData(clsTemplateDefault objclsTemplateDefault)
        {      //, objclsTemplateDefault.SubClassId 
            object[] parameters = new object[] { objclsTemplateDefault.TemplateDefaultId, objclsTemplateDefault.SubClassId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_Selecttemplate", "TM_TemplateDefaultData");

        }

        public DataSet SaveTemplateDefaultData(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                 
                                                  objclsTemplateDefault.TemplateDefaultId ,
                                                  objclsTemplateDefault.ClassId,
                                                  objclsTemplateDefault.SubClassId,
                                                  objclsTemplateDefault.EffFromDate,
                                                  objclsTemplateDefault.EffToDate,
                                                  objclsTemplateDefault.User,
                                                  objclsTemplateDefault.Status
                                            
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultData_InsertUpdate", "TM_TemplateDefaultData");


        }

        public DataSet SaveTemplateDefaultDetails(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                objclsTemplateDefault.TemplateDefaultId,
                                                objclsTemplateDefault.TemplateID,
                                                objclsTemplateDefault.TemplateFieldDescription
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_Insert", "TM_TemplateDefaultDetails");
        }
        public DataSet LoadTemplateDefaultDetailsNew(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                objclsTemplateDefault.TemplateDefaultId , objclsTemplateDefault.SubClassId                                             
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_SelectNew", "TM_TemplateDefaultDetails");
        }

        public DataSet LoadTemplateDefaultDetails(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                objclsTemplateDefault.TemplateDefaultId                                               
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_select", "TM_TemplateDefaultDetails");
        }
        public DataSet LoadTemplateDefaultDetailsBySubclass(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                objclsTemplateDefault.SubClassId                                               
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_SelectBySubClassId", "TM_TemplateDefaultDetails");
        }

        public DataSet DeleteTemplateDefaultDetails(clsTemplateDefault objclsTemplateDefault)
        {
            object[] parameters = new object[] {  
                                                objclsTemplateDefault.TemplateDefaultId
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultDetails_Delete", "TM_TemplateDefaultDetails");
        }
    }
}
