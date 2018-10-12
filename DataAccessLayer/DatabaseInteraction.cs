/***************************************************
 Author         : Pravesh K Chandel
 Created Date   : 11 may 2016
 purpose        : DAL Class for Accounting module
 Reviewed by    :
 Modified by    :
 Modified Date  :
 
 ***************************************************/

using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace DataAccessLayer
{
    public class DatabaseInteraction
    {
        #region "Enums"
        public enum MaintainTransaction { YES, NO };
        public enum CloseConnection { YES, NO };
        public enum SetAutoCommit { ON, OFF };
        #endregion

        #region private/public variables
        public string mstrConnString = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];

        public string mstrIsInterfaceConnected = ConfigurationManager.AppSettings["IsInterfaceConnected"];
        public string SessionAccessString = "";
        private string mstrAutoNumbering = ConfigurationManager.AppSettings["AutoNumbering"];
        private SqlConnection lobjConnection = null;

        private CommandType mDbCommandType = CommandType.Text;
        private Hashtable transactionCache;
        private ArrayList parameterCollection;
        private SqlParameter[] commandParameters;
        private const string DEFAULT_TRANSACTION_NAME = "Default Transaction";
        private MaintainTransaction transactionRequired = MaintainTransaction.NO;
        private SetAutoCommit autoCommit = SetAutoCommit.OFF;

        public bool IsAutoNumbering()
        {
            if (mstrAutoNumbering == "F") return false;
            else return true;
        }

        public SqlParameter[] CommandParameters
        {
            get
            {
                try
                {
                    object[] objParams = parameterCollection.ToArray();
                    commandParameters = new SqlParameter[objParams.Length];
                    for (int i = 0; i < objParams.Length; i++)
                        commandParameters[i] = (SqlParameter)objParams[i];
                    return commandParameters;
                }
                catch (Exception objException)
                {
                    throw new Exception("Error while executing non-Query!", objException);
                }
            }
            set
            {
                try
                {
                    commandParameters = value;
                    for (int i = 0; i < commandParameters.Length; i++)
                        parameterCollection.Add(commandParameters[i]);
                }
                catch (Exception objException)
                {
                    throw new Exception("Error while executing non-Query!", objException);
                }
            }
        }
        #endregion

        #region "Constructors"
        public DatabaseInteraction(CommandType DbCommandType)
        {
            mDbCommandType = DbCommandType;
            parameterCollection = new ArrayList();
            transactionCache = new Hashtable();
        }
        public DatabaseInteraction(string ConnectionString)
        {
            mstrConnString = ConnectionString;
            parameterCollection = new ArrayList();
            transactionCache = new Hashtable();
        }
        public DatabaseInteraction(string ConnectionString, CommandType DbCommandType)
        {
            mstrConnString = ConnectionString;
            mDbCommandType = DbCommandType;
            parameterCollection = new ArrayList();
            transactionCache = new Hashtable();
        }
        public DatabaseInteraction(string ConnectionString, CommandType DbCommandType, MaintainTransaction transactionRequired, SetAutoCommit AutoCommit)
        {
            mstrConnString = ConnectionString;
            mDbCommandType = DbCommandType;
            parameterCollection = new ArrayList();
            transactionCache = new Hashtable();
            this.transactionRequired = transactionRequired;
            OpenConnection();
        }
        public DatabaseInteraction(CommandType DbCommandType, MaintainTransaction transactionRequired, SetAutoCommit AutoCommit)
        {
            mDbCommandType = DbCommandType;
            parameterCollection = new ArrayList();
            transactionCache = new Hashtable();
            this.transactionRequired = transactionRequired;
            OpenConnection();
        }
        #endregion

        #region Add Parameters
        /// <summary>
        /// adds a new sqlParameter to arraylist object: parameterCollection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pvalue"></param>
        public void AddParameter(string name, object pvalue)
        {
            parameterCollection.Add(new SqlParameter(name, pvalue));
        }
        /// <summary>
        /// adds a new sqlParameter to arraylist object: parameterCollection.		/// </summary>
        /// <param name="name"></param>
        /// <param name="pValue"></param>
        /// <param name="dbType"></param>
        public void AddParameter(string name, object pValue, SqlDbType dbType)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, dbType);
            objSqlParameter.Value = pValue;
            parameterCollection.Add(objSqlParameter);
        }
        /// <summary>
        /// adds a new sqlParameter to arraylist object: parameterCollection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pvalue"></param>
        /// <param name="direction"></param>
        public object AddParameter(string name, object pvalue, ParameterDirection direction)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, pvalue);
            objSqlParameter.Direction = direction;
            parameterCollection.Add(objSqlParameter);
            return objSqlParameter;
        }
        /// <summary>
        /// adds a new sqlParameter to arraylist object: parameterCollection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pValue"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        public object AddParameter(string name, object pValue, SqlDbType dbType, ParameterDirection direction)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, dbType);
            objSqlParameter.Value = pValue;
            objSqlParameter.Direction = direction;
            parameterCollection.Add(objSqlParameter);
            return objSqlParameter;
        }

        /// <summary>
        /// adds a new OUTPUT sqlParameter to arraylist object: parameterCollection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        public object AddParameter(string name, SqlDbType dbType, ParameterDirection direction)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, dbType);
            objSqlParameter.Direction = direction;
            parameterCollection.Add(objSqlParameter);
            return objSqlParameter;
        }

        /// <summary>
        /// adds a new sqlParameter to arraylist object: parameterCollection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pValue"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public object AddParameter(string name, object pValue, SqlDbType dbType, ParameterDirection direction, int size)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, dbType);
            objSqlParameter.Value = pValue;
            objSqlParameter.Direction = direction;
            objSqlParameter.Size = size;
            parameterCollection.Add(objSqlParameter);
            return objSqlParameter;
        }
        //public object GetParameterValue(string parameterName)
        //{
        //    object obj = null;
        //    SqlParameter[] objSqlParameter = commandParameters;
        //    for (int i = 0; i < objSqlParameter.Length; i++)
        //    {
        //        if (objSqlParameter[i].ParameterName.ToUpper().Equals(parameterName.ToUpper()) && (objSqlParameter[i].Direction == ParameterDirection.Output || objSqlParameter[i].Direction == ParameterDirection.InputOutput || objSqlParameter[i].Direction == ParameterDirection.ReturnValue))
        //        {
        //            obj = objSqlParameter[i].Value;
        //        }
        //    }
        //    return obj;
        //}
        /// <summary>
        /// reinitializes sql parameter collection.
        /// </summary>
        public void ClearParameteres()
        {
            //commandParameters = null;
            parameterCollection = new ArrayList();
        }
        #endregion

        #region getDataReader
        public SqlDataReader getDataReader(string commandText)
        {
            OpenConnection();
            return ExecuteReader(mDbCommandType, commandText);
        }
        //private void OpenConnection()
        //{
        //    if (lobjConnection == null)
        //        lobjConnection = new SqlConnection(mstrConnString);
        //    if (lobjConnection.State == ConnectionState.Closed)
        //        lobjConnection.Open();
        //}

        public SqlDataReader getDataReadernew(string pstrSqlQuery)
        {

            closeSqlConn();
            //Trace.Warn( ("GET DATA READER >>> " + pstrSqlQuery);
            lobjConnection = new SqlConnection(mstrConnString);

            //  Trace.Warn("Connection Timeout Period====" + lobjConnection.ConnectionTimeout.ToString());

            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.CommandTimeout = 0;
            lobjConnection.Open();
            SqlDataReader lobjDataReader = null;
            lobjDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return lobjDataReader;
        }
        public SqlDataReader getDataReaderNonClose(string pstrSqlQuery)
        {

            OpenConnection();
            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.CommandTimeout = 600;
            //lobjConnection.Open();
            SqlDataReader lobjDataReader = null;
            lobjDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return lobjDataReader;
        }
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            OpenConnection();
            // Pass through the call providing null for the set of SqlParameters
            if ((CommandParameters != null) && (CommandParameters.Length > 0))
            {
                if (transactionRequired == MaintainTransaction.YES)
                    return ExecuteReader(lobjConnection, GetSqlTransaction(), commandType, commandText, commandParameters);
                else
                    return ExecuteReader(lobjConnection, (SqlTransaction)null, commandType, commandText, commandParameters);
            }
            else
            {
                if (transactionRequired == MaintainTransaction.YES)
                    return ExecuteReader(lobjConnection, GetSqlTransaction(), commandType, commandText, (SqlParameter[])null);
                else
                    return ExecuteReader(lobjConnection, (SqlTransaction)null, commandType, commandText, (SqlParameter[])null);
            }
        }
        public SqlDataReader ExecuteReader(string spName)
        {
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            if ((CommandParameters != null) && (CommandParameters.Length > 0))
            {
                SqlParameter[] commandParameters = CommandParameters;
                //AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(lobjConnection, (SqlTransaction)null, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteReader(lobjConnection, (SqlTransaction)null, CommandType.StoredProcedure, spName, (SqlParameter[])null);
            }
        }
        private SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // Create a reader
                SqlDataReader dataReader;
                if (mustCloseConnection)
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    dataReader = cmd.ExecuteReader();
                bool canClear = true;
                foreach (SqlParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }

            finally
            {
               // lobjConnection.Close();
                //lobjConnection.Dispose();
                //SqlConnection.ClearPool(lobjConnection);               
            }
        }

        public DataTable getDataReader(string pstrSqlQuery, AuditLog_HeaderMaster objAuditLogHeader, bool isAuditRequired)
        {
            //closeSqlConn();
            //Trace.Warn( ("GET DATA READER >>> " + pstrSqlQuery);
            OpenConnection();
            SqlDataAdapter da = null;
            SqlTransaction sqlTrans = null;
            DataTable dt = new DataTable();
            string commandtext = pstrSqlQuery;
            //Trace.Warn("Connection Timeout Period====" + lobjConnection.ConnectionTimeout.ToString());
            try
            {
                //lobjConnection.Open();
                sqlTrans = lobjConnection.BeginTransaction();
                //SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection, sqlTrans);
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandTimeout = 0;
                bool closeConn = false;
                PrepareCommand(myCommand, lobjConnection, sqlTrans, mDbCommandType, commandtext, CommandParameters, out closeConn);
                da = new SqlDataAdapter(myCommand);
                da.Fill(dt);

                if (dt.Columns.Contains("PrimaryKeyValue"))
                {
                    if (objAuditLogHeader.TblPrimaryKeys.Trim() == "" && dt.Rows.Count > 0 && dt.Rows[0]["PrimaryKeyValue"] != null)
                    {
                        if (dt.Columns.Contains("Result") && (dt.Rows[0]["Result"].ToString().ToLower() == "y" || dt.Rows[0]["Result"].ToString().ToLower() == "1" || dt.Rows[0]["Result"].ToString().ToLower() == "true"))
                            objAuditLogHeader.TblPrimaryKeys = objAuditLogHeader.TblPrimaryKeysValues = dt.Rows[0]["PrimaryKeyValue"].ToString();
                    }

                }

                if (isAuditRequired && objAuditLogHeader.Trans_Desc != "" && objAuditLogHeader.TblPrimaryKeys.Trim() != "")
                {
                    myCommand = new SqlCommand("Txn_AuditLog", lobjConnection, sqlTrans);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@TransTypeID", objAuditLogHeader.TransTypeID);
                    myCommand.Parameters.AddWithValue("@RecordedBy", objAuditLogHeader.RecordedBy);
                    myCommand.Parameters.AddWithValue("@RecordedByName", objAuditLogHeader.RecordedByName);
                    myCommand.Parameters.AddWithValue("@RecFor", objAuditLogHeader.RecFor);
                    myCommand.Parameters.AddWithValue("@RecForClientID", objAuditLogHeader.RecForClientID);
                    myCommand.Parameters.AddWithValue("@RecForPolicyID", objAuditLogHeader.RecForPolicyID);
                    myCommand.Parameters.AddWithValue("@RecForPolicyVerID", objAuditLogHeader.RecForPolicyVerID);
                    myCommand.Parameters.AddWithValue("@RecForIDAddnl", objAuditLogHeader.RecForIDAddnl);
                    myCommand.Parameters.AddWithValue("@ScrMenuCode", objAuditLogHeader.ScrMenuCode);
                    myCommand.Parameters.AddWithValue("@TblName", objAuditLogHeader.TblName);
                    myCommand.Parameters.AddWithValue("@TblPrimaryKeys", objAuditLogHeader.TblPrimaryKeys);
                    myCommand.Parameters.AddWithValue("@TblPrimaryKeysValues", objAuditLogHeader.TblPrimaryKeysValues);
                    myCommand.Parameters.AddWithValue("@Trans_Desc", objAuditLogHeader.Trans_Desc);
                    myCommand.Parameters.AddWithValue("@TransLogDetails", objAuditLogHeader.TransLogDetails);
                    myCommand.Parameters.AddWithValue("@IsEndorse", objAuditLogHeader.IsEndorse);
                    myCommand.Parameters.AddWithValue("@Trans_Desc_Text", objAuditLogHeader.Trans_Desc_Text);
                    myCommand.Parameters.AddWithValue("@IsRenew", objAuditLogHeader.IsRenew);
                    myCommand.ExecuteNonQuery();
                }
                sqlTrans.Commit();

            }
            catch (SqlException sqlError)
            {
                sqlTrans.Rollback();
                throw sqlError;
            }
            finally
            {
                //lobjConnection.Close();
                CloseSqlConnection();
            }
            return dt;
        }
        #endregion

        #region Open/Close commit Connection
        public void CloseSqlConnection()
        {
            try
            {
                //Trace.Write("===>>>Attemting to close connection : Current Connection state = " + lobjConnection.State.ToString().Trim());
                lobjConnection.Close();
                lobjConnection = null;
                lobjConnection.Dispose();
                SqlConnection.ClearPool(lobjConnection);
                //Trace.Write("===>>>Successfully closed the connection");
            }
            catch (Exception e)
            {
                //Trace.Write("===>>>Exception. Unable to Close Connection = " + e.ToString().Trim()); 
            }
        }
        private void OpenConnection()
        {
            if (lobjConnection == null)
                lobjConnection = new SqlConnection(mstrConnString);
            if (lobjConnection.State == ConnectionState.Closed)
                lobjConnection.Open();
        }
        public void CommitTransaction(CloseConnection closeConnection)
        {
            CommitTransaction(DEFAULT_TRANSACTION_NAME, closeConnection);
        }
        public void RollbackTransaction(CloseConnection closeConnection)
        {
            RollbackTransaction(DEFAULT_TRANSACTION_NAME, closeConnection);
        }
        /// <summary>
        /// Commits the specified Transaction, closes the connection & removes transaction form cache.
        /// </summary>
        /// <param name="transactionName">Name of the transaction to commit.</param>
        public void CommitTransaction(string transactionName, CloseConnection closeConnection)
        {
            try
            {
                SqlTransaction objSqlTransaction = (SqlTransaction)transactionCache[transactionName];
                if (objSqlTransaction != null)
                {
                    objSqlTransaction.Commit();
                    transactionCache.Remove(transactionName);
                }
                if (closeConnection == CloseConnection.YES)
                    CloseSqlConnection();
            }
            catch (Exception objException)
            {
                throw new Exception("CAN NOT COMMIT! " + objException.ToString(), objException);
            }
        }
        public void RollbackTransaction(string transactionName, CloseConnection closeConnection)
        {
            try
            {
                SqlTransaction objSqlTransaction = (SqlTransaction)transactionCache[transactionName];
                if (objSqlTransaction != null)
                {
                    objSqlTransaction.Rollback();
                    transactionCache.Remove(transactionName);
                }
                if (closeConnection == CloseConnection.YES)
                    CloseSqlConnection();
            }
            catch (Exception objException)
            {
                throw new Exception("CAN NOT Rollback! " + objException.ToString(), objException);
            }
        }
        #endregion

        #region get Data Set
        public DataSet RunSQLWithDataSet(string sSQL)
        {
            CloseSqlConnection();
            DataSet oDataSet = new DataSet();
            //SqlDataAdapter oDataAdapter;
            //oDataAdapter = new SqlDataAdapter(sSQL,mstrConnString);

            lobjConnection = new SqlConnection(mstrConnString);
            SqlCommand oCommand = new SqlCommand(sSQL, lobjConnection);
            oCommand.CommandTimeout = 300;
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(oCommand);
            //Trace.Warn(sSQL);
            oDataAdapter.Fill(oDataSet, "Resultset");

            oDataAdapter.Dispose();
            oDataAdapter = null;
            lobjConnection.Close();
            return oDataSet;
        }

        public DataSet GetDataset(string commandText, string[] tableNames)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            bool mustCloseConnection = false;
            SqlTransaction objTransaction = transactionRequired == MaintainTransaction.YES ? GetTransactionObject(DEFAULT_TRANSACTION_NAME) : (SqlTransaction)null;
            PrepareCommand(command, this.lobjConnection, objTransaction, this.mDbCommandType, commandText, CommandParameters, out mustCloseConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            // Add the table mappings specified by the user
            if (tableNames != null && tableNames.Length > 0)
            {
                string tableName = "Table";
                for (int index = 0; index < tableNames.Length; index++)
                {
                    if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                    sqlDataAdapter.TableMappings.Add(tableName, tableNames[index]);
                    tableName += (index + 1).ToString();
                }
            }
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (mustCloseConnection || transactionRequired == MaintainTransaction.NO)
                CloseSqlConnection();

            return dataSet;
        }

        #endregion

        #region Execute Non Query
     
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            if (CommandParameters.Length == 0)
                return ExecuteNonQuery(GetTransactionObject(DEFAULT_TRANSACTION_NAME), commandType, commandText, (SqlParameter[])null);
            else
                return ExecuteNonQuery(GetTransactionObject(DEFAULT_TRANSACTION_NAME), commandType, commandText, CommandParameters);
        }
        public int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            if (CommandParameters.Length == 0)
                return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
            else
                return ExecuteNonQuery(transaction, commandType, commandText, CommandParameters);
        }
        public int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
        {
            if (CommandParameters == null || CommandParameters.Length == 0)
                return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);
            else
                return ExecuteNonQuery(connection, commandType, commandText, CommandParameters);
        }
        private int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }
        private int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }
        public int executeNonQuery(string pstrSqlQuery)
        {

            closeSqlConn();
            int lintTemp = 0;
            lobjConnection = new SqlConnection(mstrConnString);
            lobjConnection.Open();
            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.CommandTimeout = 600;
            lintTemp = myCommand.ExecuteNonQuery();
            closeSqlConn();
            return lintTemp;
        }
      
        public int executeNonQuery(string pstrSqlQuery, AuditLog_HeaderMaster objAuditLogHeader, bool isAuditRequired)
        {
            int lintTemp = 0;

            using (SqlConnection con = new SqlConnection(mstrConnString))
            {
                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                try
                {
                    SqlCommand myCommand = new SqlCommand(pstrSqlQuery, con, sqlTrans);
                    myCommand.CommandTimeout = 600;
                    bool mustCloseConnection = false;
                    if ((CommandParameters != null) && (CommandParameters.Length > 0))
                    {
                        PrepareCommand(myCommand, con, sqlTrans, mDbCommandType, pstrSqlQuery, CommandParameters, out mustCloseConnection);
                    }
                    lintTemp = myCommand.ExecuteNonQuery();

                    if (isAuditRequired && objAuditLogHeader.Trans_Desc != "" && objAuditLogHeader.TblPrimaryKeys.Trim() != "")
                    {
                        myCommand = new SqlCommand("Txn_AuditLog", con, sqlTrans);
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@TransTypeID", objAuditLogHeader.TransTypeID);
                        myCommand.Parameters.AddWithValue("@RecordedBy", objAuditLogHeader.RecordedBy);
                        myCommand.Parameters.AddWithValue("@RecordedByName", objAuditLogHeader.RecordedByName);
                        myCommand.Parameters.AddWithValue("@RecFor", objAuditLogHeader.RecFor);
                        myCommand.Parameters.AddWithValue("@RecForClientID", objAuditLogHeader.RecForClientID);
                        myCommand.Parameters.AddWithValue("@RecForPolicyID", objAuditLogHeader.RecForPolicyID);
                        myCommand.Parameters.AddWithValue("@RecForPolicyVerID", objAuditLogHeader.RecForPolicyVerID);
                        myCommand.Parameters.AddWithValue("@RecForIDAddnl", objAuditLogHeader.RecForIDAddnl);
                        myCommand.Parameters.AddWithValue("@ScrMenuCode", objAuditLogHeader.ScrMenuCode);
                        myCommand.Parameters.AddWithValue("@TblName", objAuditLogHeader.TblName);
                        myCommand.Parameters.AddWithValue("@TblPrimaryKeys", objAuditLogHeader.TblPrimaryKeys);
                        myCommand.Parameters.AddWithValue("@TblPrimaryKeysValues", objAuditLogHeader.TblPrimaryKeysValues);
                        myCommand.Parameters.AddWithValue("@Trans_Desc", objAuditLogHeader.Trans_Desc);
                        myCommand.Parameters.AddWithValue("@TransLogDetails", objAuditLogHeader.TransLogDetails);
                        myCommand.Parameters.AddWithValue("@IsEndorse", objAuditLogHeader.IsEndorse);
                        myCommand.Parameters.AddWithValue("@Trans_Desc_Text", objAuditLogHeader.Trans_Desc_Text);
                        myCommand.Parameters.AddWithValue("@IsRenew", objAuditLogHeader.IsRenew);
                        myCommand.ExecuteNonQuery();
                    }
                    sqlTrans.Commit();
                }
                catch (SqlException sqlError)
                {
                    sqlTrans.Rollback();
                    throw sqlError;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    SqlConnection.ClearPool(con);
                }
            }

            return lintTemp;
        }

        #endregion

        #region execute scaler
        public object ExecuteScalar(string sql)
        {
            string SPName = "";
            try
            {
                if (mDbCommandType == CommandType.StoredProcedure)
                    SPName = sql;
                object intResult;
                OpenConnection();
                if (transactionRequired == MaintainTransaction.YES)
                {
                    //extracting default transaction from cahce this logic is hidden form BL programmer.
                    intResult = ExecuteScalar(GetTransactionObject(DEFAULT_TRANSACTION_NAME), mDbCommandType, sql);
                    //transaction can not be auto commited here for further calls.
                    if (autoCommit == SetAutoCommit.ON) CommitTransaction(CloseConnection.YES);
                }
                else
                {
                    intResult = ExecuteNonQuery(lobjConnection, mDbCommandType, sql);
                    CommitTransaction(CloseConnection.YES);
                    //CloseSqlConnection(EDispose.YES);
                }

                return intResult;
            }
            catch (Exception objException)
            {
                CloseSqlConnection();
                throw new Exception("Error while executing non-Query! Store procedure :  " + SPName, objException);
            }

            finally
            {
                CloseSqlConnection();
            }
        }
        public object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }
        public object executeScalarQuery(string pstrSqlQuery)
        {

            object oTemp = null;
            lobjConnection = new SqlConnection(mstrConnString);

            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.CommandTimeout = 600;
            lobjConnection.Open();
            oTemp = myCommand.ExecuteScalar();
            CloseSqlConnection();
            return oTemp;
        }
        #endregion

        public void Main(string path)
        {
            try
            {
                // Create a reference to the current directory.
                DirectoryInfo di = new DirectoryInfo(path);
                // Create an array representing the files in the current directory.
                FileInfo[] fi = di.GetFiles();
                //Trace.Warn("The following files exist in the current directory:");
                // Print out the names of the files in the current directory.
                foreach (FileInfo fiTemp in fi)
                {
                    //Trace.Warn(fiTemp.Name);
                    try
                    {
                        fiTemp.Delete();
                    }
                    catch { }
                }
            }
            catch { }
        }
        public bool chkAccess(int pintMenuId)
        {
            bool lclResult = false;
            try
            {
                ////Trace.Warn((pintMenuId.ToString().Trim() + "="+Session["AccessString"].ToString().Trim().IndexOf(pintMenuId.ToString().Trim() + @"*") + "="); 
                //if (Session["AccessString"].ToString().Trim().IndexOf("*" + pintMenuId.ToString().Trim() + "*") >= 0) lclResult = true;
                if (SessionAccessString.Trim().IndexOf("*" + pintMenuId.ToString().Trim() + "*") >= 0) lclResult = true;
                else lclResult = false;
            }
            catch { lclResult = false; }
            ////Trace.Warn(("Menu Id " + pintMenuId.ToString().Trim() + " = " + lclResult.ToString().Trim());   
            return true;
        }

        #region Other Utility methods
        public string fstrFormatDecimal(decimal pdblValue)
        {
            return fstrFormatDecimal(pdblValue, false);
        }
        public string fstrFormatDecimal(decimal pdblValue, bool SupressZero)
        {
            string lstrFormattedValue = "";
            if (SupressZero == true) { if (pdblValue == 0) lstrFormattedValue = ""; }
            else
            {
                if (pdblValue < 0)
                    lstrFormattedValue = pdblValue.ToString("N", Thread.CurrentThread.CurrentCulture).Trim();
                //lstrFormattedValue = "(" + (-1 * pdblValue).ToString("N",Thread.CurrentThread.CurrentCulture).Trim() + ")"; 
                else lstrFormattedValue = pdblValue.ToString("N", Thread.CurrentThread.CurrentCulture).Trim();
            }
            return lstrFormattedValue;
        }
        public string fstrFormatDecimalWithZero(decimal pdblValue)
        {
            bool pbolIsNegetive = false;
            if (pdblValue < 0)
            {
                pbolIsNegetive = true;
                pdblValue = -1 * pdblValue;
            }
            string lstrFormattedValue = "";
            lstrFormattedValue = pdblValue.ToString("N", Thread.CurrentThread.CurrentCulture).Trim();
            if (pbolIsNegetive == true)
            {
                lstrFormattedValue = "(" + lstrFormattedValue.Trim() + ")";
            }
            return lstrFormattedValue;
        }
        public string fstrGetSafeString(string pStringValue, int pStringLength)
        {
            string lstrOutputString = "";
            if (pStringValue != null)
            {
                lstrOutputString = pStringValue.Replace("'", "''").Trim();
                int lintLength = lstrOutputString.Length;
                if (pStringLength <= lintLength) lstrOutputString = lstrOutputString.Substring(0, pStringLength);
            }
            return lstrOutputString;
        }
        public decimal fdecRoundDecimal(decimal pDecimalVal, int NoOfDigitsToRound)
        {
            //Trace.Warn(("Before Round = " + pDecimalVal.ToString("###0.0000").Trim()); 
            //Trace.Warn(("After Round = " + System.Math.Round(pDecimalVal, NoOfDigitsToRound).ToString("###0.0000").Trim());
            return System.Math.Round(pDecimalVal, NoOfDigitsToRound);
        }
        public string fstrDecimalToString(decimal pDecimalVal)
        {
            return fstrDecimalToString(pDecimalVal, 2, true);
        }
        public string fstrDecimalToString(decimal pDecimalVal, int NoOfDigitsToRound, bool FormatNegetiveValue)
        {
            string lstrFormat = "", lstrResult = "";
            for (int i = 1; i <= NoOfDigitsToRound; i++) lstrFormat = lstrFormat + "0";
            if (NoOfDigitsToRound != 0) lstrFormat = "0." + lstrFormat; else lstrFormat = "0";
            lstrFormat = "###,###,###,##" + lstrFormat;
            if (FormatNegetiveValue == true && pDecimalVal < 0) lstrResult = fdecRoundDecimal(System.Math.Abs(pDecimalVal), NoOfDigitsToRound).ToString(lstrFormat).Trim();
            else lstrResult = fdecRoundDecimal(pDecimalVal, NoOfDigitsToRound).ToString(lstrFormat).Trim();
            if (FormatNegetiveValue == true && pDecimalVal < 0) lstrResult = "(" + lstrResult + ")";
            return lstrResult;
        }
        public string GetSysParamValue(string sKeyWord)
        {
            string sSQL = "P_Sys_Params_Select '" + sKeyWord + "'";
            object sResult = ExecuteScalar(sSQL);
            return sResult.ToString();
        }
        public DataTable GetSysParamValue()
        {
            string sSQL = "P_Sys_Params_Select ''";
            DataTable dt = RunSQLWithDataSet(sSQL).Tables[0];
            return dt;
        }
        public DataTable GetDefaultCurr()
        {
            string sSQL = "AC_GetDefaultCurrency";
            DataTable dt = RunSQLWithDataSet(sSQL).Tables[0];
            return dt;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Begins a transaction if not already began, and adds to the transaction cache.
        /// </summary>
        /// <param name="transactionName"></param>
        /// <returns>Transaction object form cache.</returns>
        private SqlTransaction GetTransactionObject(string transactionName)
        {
            //If no transaction name is specified a default transaction is started/extracted
            if (transactionName == null || transactionName.Length == 0) transactionName = DEFAULT_TRANSACTION_NAME;
            if (!transactionCache.ContainsKey(transactionName))
                transactionCache.Add(transactionName, lobjConnection.BeginTransaction(transactionName));
            return (SqlTransaction)transactionCache[transactionName];
        }
        public SqlTransaction GetSqlTransaction()
        {
            return GetTransactionObject(DEFAULT_TRANSACTION_NAME);
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            //command.CommandTimeout = mCommandTimeOut;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }


        #endregion

        /// <summary>
        /// Added by Sheepu
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        #region CloseConnection
        public void closeSqlConn()
        {
            try
            {
                //Trace.Write("===>>>Attemting to close connection : Current Connection state = " + lobjConnection.State.ToString().Trim());
                lobjConnection.Close();
                lobjConnection = null;
                lobjConnection.Dispose();
                SqlConnection.ClearPool(lobjConnection);

                //Trace.Write("===>>>Successfully closed the connection");
            }
            catch (Exception e)
            {
                //Trace.Write("===>>>Exception. Unable to Close Connection = " + e.ToString().Trim()); 
            }
        }
        #endregion
        #region for getting record
        public DataSet GetDataset(string sSQL)
        {
            closeSqlConn();  
            DataSet oDataSet = new DataSet();
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(sSQL, mstrConnString);
            oDataAdapter.SelectCommand.CommandTimeout = 0;
            oDataAdapter.Fill(oDataSet, "Resultset");
            oDataAdapter.Dispose();
            oDataAdapter = null;
            return oDataSet;
        }

        #endregion


    }
}
