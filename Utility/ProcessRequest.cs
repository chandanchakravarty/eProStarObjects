using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Utility
{
    public static class ProcessRequest
    {
        /// <summary>
        /// Meathod used to get filtered records according to user login 
        /// </summary>
        /// <param name="_dataTable">all records</param>
        /// <returns>filtered records</returns>
        public static DataTable getFilteredRecordsOnLoginUser(DataTable _dataTable)
        {
            if (_dataTable != null && System.Web.HttpContext.Current.Session["UsersUnderLoginUser"] != null)
            {
                string strFilter = System.Web.HttpContext.Current.Session["UsersUnderLoginUser"].ToString();
                //strFilter = strFilter.Replace("'", "''");
                DataView _dataView = new DataView(_dataTable);
                if (_dataTable.Columns.Contains("CreatedBy") == true && _dataTable.Columns.Contains("LastUpdatedBy") == true)
                {
                    _dataView.RowFilter = "CreatedBy in (" + strFilter + ") or LastUpdatedBy in (" + strFilter + ")";
                }
                _dataTable = _dataView.ToTable();
            }
            return _dataTable;
        }
        /// <summary>
        /// Assign filtered records to gridview
        /// </summary>
        /// <param name="gView">get data source from grid view and filter it</param>
        public static void assignValueToDataTable(GridView gView)
        {
            if (gView.DataSource == null) return;

            DataTable dtSource = new DataTable();
            DataTable dtDestination = new DataTable();
            if (gView.DataSource.GetType().Name == "DataView")
            {
                DataView dv = (DataView)gView.DataSource;
                dtSource = dv.ToTable();
            }
            else if (gView.DataSource.GetType().Name == "DataSet")
            {
                DataSet ds = (DataSet)gView.DataSource;
                dtSource = ds.Tables[0];
            }
            else if (gView.DataSource.GetType().Name == "DataTable")
            {
                dtSource = (DataTable)gView.DataSource;
            }
            else
            {
                return;
            }
            if (dtSource.Rows.Count == 0) return;
            dtDestination = Utility.ProcessRequest.getFilteredRecordsOnLoginUser(dtSource);
            if (dtDestination != null && dtDestination.Rows.Count == 0)
            {
                gView.EmptyDataText = "No Record(s) Found !";
                gView.EmptyDataRowStyle.CssClass = "EmptyDataRowStyle";
            }
            // gView.ShowHeaderWhenEmpty = true;
            gView.DataSource = dtDestination;
            gView.DataBind();

        }

         
        /// <summary>
        /// Converts the first Datatable of Input DataSet to Jason String 
        /// </summary>
        /// <param name="objDataSet">Dataset</param>
        /// <returns>Jason String</returns>
        public static string getJSONData(DataSet objDataSet)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 2147483644;
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in objDataSet.Tables[0].Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in objDataSet.Tables[0].Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
            }
            return serializer.Serialize(rows);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szConnStr"></param>
        /// <param name="szStoredProcString"></param>
        /// <param name="szCommandTimeout"></param>
        /// <returns></returns>
        public static DataSet CallSelStoredProcWithCmdTimeOut(string szConnStr, string szStoredProcString, int szCommandTimeout)
        {


            DataTable ldt = new DataTable();
            System.Data.DataSet dsk = new DataSet();

            SqlConnection lobjCon = new SqlConnection(szConnStr);
            SqlCommand lobjCmd = new SqlCommand();
            SqlDataAdapter lobjDA = new SqlDataAdapter();
            try
            {
                lobjCon.Open();
                lobjCmd.Connection = lobjCon;
                lobjCmd.CommandText = szStoredProcString;
                lobjCmd.CommandTimeout = szCommandTimeout;
                lobjCmd.CommandType = CommandType.Text;
                lobjDA.SelectCommand = lobjCmd;

                lobjDA.Fill(dsk);
                lobjCon.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (lobjCon.State == ConnectionState.Open) lobjCon.Close();
                if (lobjDA != null) lobjDA.Dispose();
                if (lobjCmd != null) lobjCmd.Dispose();
                if (lobjCon != null) lobjCon.Dispose();
            }
            return dsk;
        }

        /// <summary>
        /// Converts Date String From dd/MM/yyyy to MM/dd/yyyy Format
        /// </summary>
        /// <param name="strDate">string Date in dd/MM/yyyy Format</param>
        /// <returns>string Date in MM/dd/yyyy Format</returns>
        public static string DMYtoMDY(string strDate)
        {
            try
            {
                string strRetDate = "";
                var aryDate = strDate.Split('/');
                if (aryDate.Length > 1)
                {
                    strRetDate = aryDate[1] + "/" + aryDate[0] + "/" + aryDate[2];
                }

                return strRetDate;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsInput"></param>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public static DataSet FilterDataset(DataSet dsInput, string strFilter)
        {
            //string Filter = strFilter.Replace("*", "[*]");
            //DataSet dsResult = new DataSet();
            //DataRow[] ldrs = null;
            //dsResult = dsInput.Clone();
            //ldrs = dsInput.Tables[0].Select(Filter);
            //dsResult.Tables.Add();
            //foreach (DataRow dr in ldrs)
            //{
            //    dsResult.Tables[0].ImportRow(dr);
            //}

            //return dsResult;

            DataSet dsResult = new DataSet();
            string Filter = strFilter.Replace("*", "[*]");
            if (dsInput != null && dsInput.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsInput.Tables[0]);
                dv.RowFilter = Filter;
                dsResult = new DataSet();
                dsResult.Tables.Add(dv.ToTable());
            }
            return dsResult;

        }

        public static string ConvertColToString(DataSet dsInput, string strColName, string strOpr) 
        {
            string strResultSet = "";
            foreach (DataRow ndr in dsInput.Tables[0].Rows)
            {
                if (strResultSet == "")
                    strResultSet = ndr[strColName].ToString();
                else
                    strResultSet += strOpr + ndr[strColName].ToString();
 
            }
            return strResultSet;
        }
    }
}
