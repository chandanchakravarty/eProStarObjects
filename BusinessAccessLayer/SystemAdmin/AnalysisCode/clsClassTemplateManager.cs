using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    
    public class clsClassTemplateManager
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveClassTemplate(clsClassTemplate objClassTemp,string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={objClassTemp.ClassTemplateID,
                                objClassTemp.ClassTemplateName,
                                objClassTemp.ClassID,
                                objClassTemp.UserId,
                                objClassTemp.IsActive,
                                xmltempDetail
                                };
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ClassTemplate_InsertUpadte", "ClassTemplate");
        
        
        }
        public DataSet LoadTemplateBySubClassTempIdForCov(int ClassTempId, int SubClassId, int UwCoverageId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId, SubClassId, UwCoverageId };
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_ClassTemplate_SelByClassTempIdForCov", tables);

        }

        public DataSet LoadTemplateByClassTempIdForCov(int ClassTempId, int UwCoverageId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId,  UwCoverageId };
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_ClassTemplate_SelByClassTempIdForCov", tables);

        }
        public DataSet LoadClassTemplate(int classId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = {classId};
            string[] tables = { "Template", "TemplateDetail" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_ClassTemplate_Select",tables );


        }
    }
}
