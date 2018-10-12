using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class LedgerClassManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadLedgerClass(clsLedgerClass objLedgerClass)
        {
            object[] parameters = new object[1] { objLedgerClass.CompanyId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerClassDetail_Select", "LedgerClassSelect");

        }
        public DataSet LoadLedgerClassByClassId(int ClassId)
        {
            object[] parameters = new object[1] {ClassId };
            dataAccessDS = new DataAccess();
            string [] tablename=new [] {"LedgerCompanySelect","CompanyList"};
            return dataAccessDS.LoadDataSets(parameters, "P_TM_LedgerClassDetail_SelectByClassId", tablename);

        }
        public DataSet LoadLedgerClassTeamByClassId(int ClassId)
        {
            object[] parameters = new object[1] { ClassId };
            dataAccessDS = new DataAccess();
            string[] tablename = new[] { "LedgerTeamSelect", "TeamList" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_LedgerClassTeamDetail_SelectByClassId", tablename);

        }
        
        public DataSet SaveLedgerClass(string xmlLedgerFile)
        {
            DataSet dsResult = new DataSet();
            //bool flag = false;
            object[] parameters = new object[] { xmlLedgerFile};
            dataAccessDS = new DataAccess();
            dsResult=dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerClassDetail_InsertUpdate", "LedgrClassDetail");
            //if (dsResult.Tables["LedgrClassDetail"].Rows[0]["Result"].ToString().Contains("Success"))
            //{
            //    flag = true;
            //}
            return dsResult;
        }
        public DataSet SaveLedgerTeamClass(string xmlLedgerFile)
        {
            DataSet dsResult = new DataSet();
            //bool flag = false;
            object[] parameters = new object[] { xmlLedgerFile };
            dataAccessDS = new DataAccess();
            dsResult = dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerClassTeamDetail_InsertUpdate", "LedgrClassTeamDetail");
            //if (dsResult.Tables["LedgrClassDetail"].Rows[0]["Result"].ToString().Contains("Success"))
            //{
            //    flag = true;
            //}
            return dsResult;
        }
    }
}
