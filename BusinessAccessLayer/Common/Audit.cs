using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.Common
{
    public class Audit
    {

        public Audit()
        {
        }

        public DataSet GetPRHistoryList(string tableName, string mode, string MasterCode)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parametes = new Object[] { mode, tableName, MasterCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_PRGetHistoryList", "HistoryList");
        }

        public DataSet GetPDHistoryList(string tableName, string mode, string MasterCode)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parametes = new Object[] { tableName, mode, MasterCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_PDGetHistoryList", "HistoryList");
        }

        public DataSet GetAccountHistoryList(string tableName, string mode, string MasterCode)
        {
            DataAccess dataAccess = new DataAccess("Accounts");
            Object[] parametes = new Object[] { tableName, mode, MasterCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_AccountGetHistoryList", "HistoryList");
        }

        public DataSet GetAdminDetails(string tableName, string mode, string MasterCode)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parametes = new Object[] { tableName, mode, MasterCode };
            return dataAccess.LoadDataSet(parametes, "P_Adm_AdminGetHistory", "HistoryList");
        }

    }


}
