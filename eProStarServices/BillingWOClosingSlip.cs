using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

using DataAccessLayer;
using Utility;

namespace eProStarServices
{
    public class BillingWOClosingSlip
    {
        protected string mstrConStr = "";

        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader = null;
        public BillingWOClosingSlip(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }

        public void beginProcess()
        {
            EventLogs.Publish("Batch Process Billing Without Closing Slip Service Started", System.Diagnostics.EventLogEntryType.Information);
            mstrConStr = _ConfigReader.ConnString;

            this.ExecuteMigrationScript();

            EventLogs.Publish("Batch Process Billing Without Closing Slip Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        private void ExecuteMigrationScript()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_MigScriptBillingWoClosingSlip");
            }
            catch (Exception ex)
            {
                ServiceUtility.WriteLog(ex.ToString());
            }
        }

        public DataSet GetDataSet(string pstrSqlQuery)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection lobjConnection = new SqlConnection(mstrConStr);
            lobjConnection.Open();
            SqlTransaction myTran = lobjConnection.BeginTransaction("APP_DB_Tran_DS");
            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.Transaction = myTran;
            myCommand.CommandTimeout = 0;
            try
            {
                SqlDataAdapter oDataAdapter = new SqlDataAdapter(myCommand);
                oDataAdapter.Fill(oDataSet, "Resultset");
                myCommand.Transaction.Commit();
                oDataAdapter.Dispose();
                oDataAdapter = null;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                myCommand.Transaction.Rollback();
            }
            finally
            {
                myTran.Dispose();
                myCommand.Dispose();
                if (lobjConnection != null && lobjConnection.State == ConnectionState.Open)
                {
                    lobjConnection.Close();
                }
            }
            return oDataSet;
        }

        protected void WriteLog(string strLogMsg)
        {
            EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }
    }
}
