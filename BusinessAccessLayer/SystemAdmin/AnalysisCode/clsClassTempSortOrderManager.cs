using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;
using DataAccessLayer;


namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsClassTempSortOrderManager
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveClassTemplateSortOrder(string fieldName, string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={fieldName,
                                  xmltempDetail
                                };
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ClassTemplate_SortOrder_InsertUpadte", "ClassTemplateSort");


        }
        public DataSet LoadClassTemplateSortOrder(int TempId,string fieldname)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { TempId, fieldname };
            string[] tables = { "ShortOrder" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_ClassTemplate_SortOrder_Select", tables);


        }
    }
}
