using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class LedgerSubClassManager
    {
        DataAccess dataAccessDS = null;
        public DataSet  SaveLedgerSubClass(string xmlFile)
        {
            DataSet dsResult = new DataSet();
            bool flag = false;
            object[] parameters = new object[] { xmlFile };
            dataAccessDS = new DataAccess();
            dsResult = dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerSubClassDetail_InsertUpdate", "LedgrSubClassDetail");
            return dsResult;
        }
        public DataSet SaveLedgerSubClassCompany(string xmlFile)
        {
            DataSet dsResult = new DataSet();
            object[] parameters = new object[] { xmlFile };
            dataAccessDS = new DataAccess();
            dsResult = dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerSubClassCompanyDetail_InsertUpdate", "LedgrSubClassDetail");
            return dsResult;
        }
        public DataSet LoadSubClassByClassId(int classId)
        {

            DataSet dsResult = new DataSet();
            object[] parameters = new object[] { classId };
            dataAccessDS = new DataAccess();
            return  dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerSubClass_SelectByClassId", "LedgrSubClassSelect");
        
        }
        public DataSet LoadSubClass(int compId,int classId) // load only saved sub class
        {

            DataSet dsResult = new DataSet();
            object[] parameters = new object[] {compId, classId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerSubClass_SelectSubClass", "LedgrSubClass");

        }
    }
}
