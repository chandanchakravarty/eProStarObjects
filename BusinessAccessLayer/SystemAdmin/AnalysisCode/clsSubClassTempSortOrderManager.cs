using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;
using DataAccessLayer;
namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsSubClassTempSortOrderManager
    {

        DataAccess dataAccessDS = null;
        public DataSet SaveSubClassTemplateSortOrder(string fieldName, string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={fieldName,
                                  xmltempDetail
                                };
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassTemplate_SortOrder_InsertUpadte", "SubClassTemplateSort");


        }
        public DataSet SaveSubClassTemplateSortOrderForCoverage(string fieldName, string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={fieldName,
                                  xmltempDetail
                                };
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyUWCovDetails_SortOrder_InsertUpadte", "SubClassTemplateSort");


        }
        public DataSet LoadSubClassTemplateSortOrder(int TempId, string fieldname)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { TempId, fieldname };
            string[] tables = { "ShortOrder" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_SubClassTemplate_SortOrder_Select", tables);


        }
       
    }
}
