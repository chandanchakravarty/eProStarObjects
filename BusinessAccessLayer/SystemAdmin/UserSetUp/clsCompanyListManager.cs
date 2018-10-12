using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsCompanyListManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadCompanyList(string GroupCode)
        {
            object[] parameters = new object[1] { GroupCode };
            dataAccessDS = new DataAccess();
            string[] tables = new string[2] { "CompanyListSelect", "CompanyName" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_UserGrpCompanyList_Select",tables );
        }
        public DataSet SaveCompanyList(string xmlCompanyFile)
        {
            DataSet dsResult = new DataSet();
            bool flag = false;
            object[] parameters = new object[] { xmlCompanyFile };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpCompanyList_InsertUpdate", "CompanyListDetail");

        }
    
    }
}
