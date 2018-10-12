using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Transactions;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataAccess
    {
        protected Database dataBase = null;
        protected DataSet dataSet = null;
        DbConnection con = null;
        private DbTransaction objTransaction = null;
        private SqlTransaction objSQLTransaction = null;

        public DataAccess()
        {
            dataBase = DatabaseFactory.CreateDatabase("eProfessional_N");
        }

        public DataAccess(String Accounts)
        {
            dataBase = DatabaseFactory.CreateDatabase("Accounts");
        }

        public DataAccess(string connectionString, string from)
        {
            dataBase = DatabaseFactory.CreateDatabase(connectionString);
        }
        /// <summary>
        /// This method is used to get the data based on the query passed as string
        /// </summary>
        /// <param name="sqlQuery"> Sql Query to get the data from database</param>
        /// <param name="dataTableName">Reference data table name</param>
        /// <returns>DataSet</returns>
        public DataSet LoadDataSet(string sqlQuery, string dataTableName)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(dataBase.GetSqlStringCommand(sqlQuery), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetWithTransaction(string sqlQuery, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetSqlStringCommand(sqlQuery), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// This method is used to get the data from the database using the strored procedure based on 
        /// the parameters passed as arguments
        /// </summary>
        /// <param name="parameters"> Parameter Values</param>
        /// <param name="procName"> Strored procedure Name</param>
        /// <param name="dataTableName">Reference data table name</param>
        /// <returns>DataSet</returns>
        public DataSet LoadDataSet(object[] parameters, string procName, string dataTableName)
        {
            dataSet = new DataSet();    
            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetWithTimeout(object[] parameters, string procName, string dataTableName)
        {
            dataSet = new DataSet();
            DbCommand dcCommand = dataBase.GetStoredProcCommand(procName, parameters);
            dcCommand.CommandTimeout = 0;
            dataBase.LoadDataSet(dcCommand, dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetWithTransaction(object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet LoadDataSet(string prcQry)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(CommandType.Text, prcQry, dataSet, new string[] { "tab1" });
            return dataSet;
        }

        public DataSet LoadDataSetWithTimeout(string prcQry)
        {
            dataSet = new DataSet();
            DbCommand dcCommand = dataBase.GetSqlStringCommand(prcQry);
            dcCommand.CommandTimeout = 0;
            dataBase.LoadDataSet(dcCommand, dataSet, new string[] { "tab1" });
            return dataSet;
        }

        public DataSet LoadDataSetWithTransaction(string prcQry)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(objTransaction, CommandType.Text, prcQry, dataSet, new string[] { "tab1" });
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet LoadDataSets(object[] parameters, string procName, string[] dataTableName)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetsWithTimeOut(object[] parameters, string procName, string[] dataTableName)
        {
            dataSet = new DataSet();
            DbCommand dcCommand = dataBase.GetStoredProcCommand(procName, parameters);
            dcCommand.CommandTimeout = 0;
            dataBase.LoadDataSet(dcCommand, dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetsWithTransaction(object[] parameters, string procName, string[] dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet LoadDataSets(string procName, string[] dataTableName)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetsWithTransaction(string procName, string[] dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet LoadDataSetsParameter(object[] parameters, string procName, string[] dataTableName)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet LoadDataSetsParameterWithTransaction(object[] parameters, string procName, string[] dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// This method is used to insert and update the data into database
        /// </summary>
        /// <param name="parameters"> Parameter Values</param>
        /// <param name="procName">Strored procedure Name </param>
        /// <returns> int </returns>
        public DataSet SaveData(object[] parameters, string procName, string dataTableName)
        {
            dataSet = new DataSet();
            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
            return dataSet;
        }

        public DataSet SaveDataWithTransaction(object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();
            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, objTransaction);
                objTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// This method is used to get the Scalar Value from the given Stored Procedure based
        /// on the parameters
        /// </summary>
        /// <param name="parameters">Parameter Values</param>
        /// <param name="procName">Strored procedure Name </param>
        /// <returns> Object </returns>
        public object GetScalarValue(object[] parameters, string procName)
        {
            return dataBase.ExecuteScalar(dataBase.GetStoredProcCommand(procName, parameters));
        }


        public object  GetScalarValue(string procName)
        {
            return dataBase.ExecuteScalar(dataBase.GetStoredProcCommand(procName));
        }

        public object GetScalarValueWithTransaction(object[] parameters, string procName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();

            try
            {
                return dataBase.ExecuteScalar(dataBase.GetStoredProcCommand(procName, parameters), objTransaction);
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public object GetScalerValue(string sqlQuery)
        {
            return dataBase.ExecuteScalar(CommandType.Text, sqlQuery);
        }

        public object GetScalerValueWithTransaction(string sqlQuery)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();

            try
            {
                return dataBase.ExecuteScalar(objTransaction, CommandType.Text, sqlQuery);
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public SqlDataReader GetDataReader(object[] parameters, string procName)
        {
            return (SqlDataReader)dataBase.ExecuteReader(procName, parameters);
        }

        public SqlDataReader GetDataReader(string sqlquery)
        {
            return (SqlDataReader)dataBase.ExecuteReader(CommandType.Text, sqlquery);
        }
        public SqlDataReader GetDataReaderWithTransaction(object[] parameters, string procName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objTransaction = con.BeginTransaction();

            try
            {
                SqlDataReader data = (SqlDataReader)dataBase.ExecuteReader(objTransaction, procName, parameters);
                return data;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw ex;
            }
        }
        public void SqlBulkInsertData(string strTableName, DataRow[] dataRows)
        {
            SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["eProfessional_N"].ToString(), SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = strTableName;
            bulkCopy.WriteToServer(dataRows);
        }

        public void SqlBulkInsertData(string strTableName, DataTable dataTable)
        {
            SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["eProfessional_N"].ToString(), SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = strTableName;
            bulkCopy.WriteToServer(dataTable);
        }
     /// <summary>
     /// Method to passs datatable as a parameter into store procedure
     /// </summary>
     /// <param name="procedureName">Name of Store Procedure</param>
     /// <param name="strTVP">Table Value Parameter</param>
     /// <param name="dtTableName">Source datatable</param>

        //added by kavita kaushik//
        public DataSet SaveIHPremiumRatingMaster(DataTable dt)
        {
            object[] parameters = new object[] {dt };
            return LoadDataSet(parameters, "P_IH_PremiumRatingMaster_Insert", "IHPremiumMaster");

        }
        public DataSet get_IHPremiumData()
        {
            return LoadDataSet("get_Temp_IHPremiumData", "TM_IH_TempPremiumRating");

        }

        //end




        public int SqlInsertDataTable(string procedureName,string strTVP,DataTable dtTableName)
        {
                    
            SqlConnection sqlcon = null;
         
            try
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["eProfessional_N"].ToString());
                sqlcon.Open();
                
                SqlCommand scCmd = new SqlCommand(procedureName, sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvp = new SqlParameter(strTVP, SqlDbType.Structured);
                tvp.Value = dtTableName;                
                scCmd.Parameters.Add(tvp);
              
                int i = Convert.ToInt32(scCmd.ExecuteNonQuery());
                return i;
               
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        public int InseretDataTable_With_OtherParamters(string procedureName,Dictionary<string,object[]> objParameters)
        {

            SqlConnection sqlcon = null;

            try
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["eProfessional_N"].ToString());
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand(procedureName, sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string,object[]> item in objParameters)
                {
                    object[] objArray = item.Value;
                    SqlDbType _SqlDbType = (SqlDbType)item.Value[1];
                    SqlParameter tvp = new SqlParameter(item.Key, _SqlDbType);
                    tvp.Value = item.Value[0];
                    scCmd.Parameters.Add(tvp);
                }
                // Set ReturnValue Parameter
                SqlParameter RetParam = new SqlParameter("ReturnValue", DBNull.Value);
                RetParam.Direction = ParameterDirection.ReturnValue;
                scCmd.Parameters.Add(RetParam);

                Convert.ToInt32(scCmd.ExecuteNonQuery());

                int i = Convert.ToInt32(scCmd.Parameters["ReturnValue"].Value);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
            finally
            {
                sqlcon.Close();
            }
        }



        public DataSet SqlInsertDataTable(string procedureName, DataTable dtTableName)
        {
            try
            {
                object[] parameters = new object[] { dtTableName };
                return LoadDataSet(parameters, procedureName, "IHPremiumUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ExecuteNonQuery(string ProcName, object[] parameters)
        {
          return   dataBase.ExecuteNonQuery(ProcName, parameters);
        }

        public int ExecuteNonquery(string ProcName)
        {
            return dataBase.ExecuteNonQuery(ProcName);
        }

        public void ExecuteNonQuery(string strQuery)
        {
            dataBase.ExecuteNonQuery(CommandType.Text, strQuery);
        }

        public DataSet RecoveryProcessingUnit(string strTableName, DataTable dataTable, object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objSQLTransaction = (SqlTransaction)con.BeginTransaction();

            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(objSQLTransaction.Connection, SqlBulkCopyOptions.TableLock, objSQLTransaction);
                bulkCopy.DestinationTableName = strTableName;
                bulkCopy.WriteToServer(dataTable);

                dataSet = new DataSet();
                DbCommand dcCommand = dataBase.GetStoredProcCommand(procName, parameters);
                dcCommand.CommandTimeout = 0;
                dataBase.LoadDataSet(dcCommand, dataSet, dataTableName, (DbTransaction)objSQLTransaction);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Result"].ToString().Trim() == "N")
                    objSQLTransaction.Rollback();
                else
                    objSQLTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objSQLTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ValiDateRecoverySetup(string strTableName, DataTable dataTable, object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objSQLTransaction = (SqlTransaction)con.BeginTransaction();

            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(objSQLTransaction.Connection, SqlBulkCopyOptions.TableLock, objSQLTransaction);
                bulkCopy.DestinationTableName = strTableName;
                bulkCopy.WriteToServer(dataTable);

                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, (DbTransaction)objSQLTransaction);
                objSQLTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objSQLTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ClaimRecoveryApprovalUpdate(object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objSQLTransaction = (SqlTransaction)con.BeginTransaction();

            try
            {
                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Result"].ToString().Trim() == "N")
                    objSQLTransaction.Rollback();
                else
                    objSQLTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objSQLTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public DataSet RecoveryProcessingUnit(string strTableName, DataRow[] dataRow, object[] parameters, string procName, string dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objSQLTransaction = (SqlTransaction)con.BeginTransaction();

            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(objSQLTransaction.Connection, SqlBulkCopyOptions.TableLock, objSQLTransaction);
                bulkCopy.DestinationTableName = strTableName;
                bulkCopy.WriteToServer(dataRow);

                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, (DbTransaction)objSQLTransaction);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Result"].ToString().Trim() == "N")
                    objSQLTransaction.Rollback();
                else
                    objSQLTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objSQLTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet RecoveryProcessingUnit(string strTableName, DataTable dataTable, object[] parameters, string procName, string[] dataTableName)
        {
            con = dataBase.CreateConnection();
            con.Open();
            objSQLTransaction = (SqlTransaction)con.BeginTransaction();

            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(objSQLTransaction.Connection, SqlBulkCopyOptions.TableLock, objSQLTransaction);
                bulkCopy.DestinationTableName = strTableName;
                bulkCopy.WriteToServer(dataTable);

                dataSet = new DataSet();
                dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName, (DbTransaction)objSQLTransaction);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Result"].ToString().Trim() == "N")
                    objSQLTransaction.Rollback();
                else
                    objSQLTransaction.Commit();
                return dataSet;
            }
            catch (Exception ex)
            {
                objSQLTransaction.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

       //Added by Kavita 
        public int ExecuteScalar(string ProcName, object[] parameters)
        {
            try
            {
                return System.Convert.ToInt16(dataBase.ExecuteScalar(ProcName, parameters));
            }

            catch (Exception ex)
            {
                throw ex;
            }          
           
        }
        // end
    }
}
