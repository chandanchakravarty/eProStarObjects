using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation;
using DataAccessLayer;
using Utility;

namespace eProStarServices
{
    public class BatchProcessVessel
    {
        protected string mstrConStr = "";
        protected string mstrFolderPath = "";
        protected string mstrConnFolderName = "";
        protected string mstrSourceFilePath = "";
        protected string strCurrFileName = "";
        protected string strBatchId = "";
        protected string strRemarks = "";
        protected string strBatFileExt = "";
        protected int intTotalNoOfRecords = 0;
        protected int intInValidRecCnt = 0;
        protected int intValidRecCnt = 0;
        protected int intApprovalRecCnt = 0;
        protected int intSrNo = 0;
        protected bool blDuplicate = false;
        protected string[] arrColumn;
        protected DataTable dtSourceTble = null;
        private SqlBulkCopy bulkCopy = null;

        clsVesselDetails objVesselDetails = new clsVesselDetails();
        VesselDetailManager objVesselDetailsManager = new VesselDetailManager();
        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader=null;
        public BatchProcessVessel(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }

        public void beginProcess()
        {
            EventLogs.Publish("Batch Process Vessel Service Started", System.Diagnostics.EventLogEntryType.Information);
            mstrConStr = _ConfigReader.ConnString;// System.Configuration.ConfigurationManager.ConnectionStrings["eProfessional_N"].ConnectionString;
            mstrSourceFilePath = _ConfigReader.FolderPath + "\\" + _ConfigReader.VesselFolderPath;
            //mstrFolderPath = ConfigurationSettingReader.VesselFolderPath.ToString();
            int i = 0;
            //int iCount = System.Configuration.ConfigurationManager.ConnectionStrings.Count;
            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);
            int iCount = strFiles.Length;
            for (i = 0; i < iCount; i++)
            {
                //mstrConnFolderName = System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                //mstrConStr = System.Configuration.ConfigurationManager.ConnectionStrings["eProfessional_N"].ConnectionString;
                //mstrSourceFilePath = ConfigurationSettingReader.CSVSourceFilePath.ToString();
                //mstrSourceFilePath = mstrFolderPath; 
                strCurrFileName = strFiles[i];
                if (!string.IsNullOrEmpty(mstrConStr.Trim()))
                {
                    ReadLoadSourceFile();
                }
            }
            EventLogs.Publish("Batch Process Vessel Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        #region Initial Member Batch Upload
        private void ReadLoadSourceFile()
        {
            //mstrSourceFilePath = ConfigurationSettingReader.VesselFolderPath;
            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);
            ServiceUtility.WriteLog("Before reading Vessel upload file in ReadLoadSourceFile method",_ConfigReader.ClientCode);
            if (strFiles.Length > 0)
            {
                try
                {
                    //strCurrFileName = strFiles[0];
                    ServiceUtility.WriteLog("First Method ReadLoadSourceFile for Initial Upload :- " + strCurrFileName + Environment.NewLine + "File Process Started On " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), _ConfigReader.ClientCode);
                    dtSourceTble = null;

                    strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);

                    strRemarks = "";
                    DeleteWorkingTable(strBatchId);
                    ReadFileAndLoadDataTable(strCurrFileName);
                    ServiceUtility.WriteLog("After reading Vessel upload file in ReadLoadSourceFile method", _ConfigReader.ClientCode);
                    WriteLog("File Process completed at " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                }
                catch (Exception ex)
                {
                    ServiceUtility.WriteLog("Error: " + ex.Message, _ConfigReader.ClientCode);
                }
            }
            else
            {
                return;
            }
        }
        protected void ReadFileAndLoadDataTable(string strFilepath)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                string error = "";
                DataTable dtExcel = new DataTable();
                error = ReadExcelFile(ref dtExcel, strFilepath);
                if (error.Trim().Length > 0)
                {
                    UpdateFileStatus(strBatchId, error);
                    //WriteLog("Unable to read excel file. Error Message:-" + Environment.NewLine + error);
                    ServiceUtility.WriteLog("Unable to read excel file. Error Message:-" + Environment.NewLine + error, mClientCode);
                    return;
                }

                if (ValidateExcel(dtExcel, 30, ref error, "Vessel", "Type", "Built", "GRT", "NRT", "BHP", "Class", "Flag", "Dimension", "Owner", "Managers", "Mortgagees", "InceptionDate", "ExpiryDate", "UnderwriterCode", "SubClassCode", "Currency", "SumInsured", "Rate", "Loading", "Share", "Premium", "Deductible", "Remarks", "DWT", "IMONo", "IVInsuredValue", "AOIInsuredValue", "AdditionalAssureds", "GeneralAverage") == false)
                {
                    UpdateFileStatus(strBatchId, error);
                    //WriteLog("Excel File format Issue:-" + Environment.NewLine + error);
                    ServiceUtility.WriteLog("Excel File format Issue:-" + Environment.NewLine + error, mClientCode);
                    return;
                }
                CreateTable();
                string strCurrLine = "";
                string[] strArrCurrData = null;
                int fieldCount = dtExcel.Columns.Count;
                foreach (DataRow dr in dtExcel.Rows)
                {
                    strCurrLine = "";
                    for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                    {
                        strCurrLine += dr[intLnp] + "|";
                    }
                    strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                    int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                    strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                    if (strArrCurrData != null && (strArrCurrData.Length == 30))
                    {
                        try
                        {
                            intSrNo = intSrNo + 1;
                            addInputRowToTable(strArrCurrData, strArrCurrData[0].ToString());
                        }
                        catch
                        {
                            break;
                        }
                    }
                    intTotalNoOfRecords++;
                }

                DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                intInValidRecCnt = drInvalidRows.Length;
                intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                intValidRecCnt = drValidRows.Length;
                intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                ImportToDatabaseWorkingTblMember();
                DataTransferToRealTable(strBatchId);
                //string strBody = "Member Upload Is Successfully.<br><br>";
                //strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                //strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                //strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                //strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                //refreshInputFolder();
            }
            catch (Exception ex)
            {
                UpdateStatus();
                WriteLog(ex.ToString());
            }
            finally
            {
                refreshInputFolder();
            }
        }

        private string GenerateTableDate(DataRow row, string strFieldName)
        {
            if (row[strFieldName].ToString().Trim().Contains("~*Error*~") || strFieldName.ToUpper() == "REMARKS")
                return "<td bgcolor=Orange>" + row[strFieldName].ToString().Trim().Replace("~*Error*~", "") + "</td>";
            else
                return "<td>" + row[strFieldName].ToString().Trim() + "</td>";
        }
        private void addInputRowToTable(string[] strArr, string Counter)
        {
            bool blParseError = false;
            blDuplicate = false;
            StringBuilder sbInputString = new StringBuilder();
            string strTemp = "";
            string strLocalTemp = string.Empty;

            sbInputString.Append("");
            DataRow drRowToAdd = dtSourceTble.NewRow();
            drRowToAdd["SrNo"] = intSrNo.ToString().Trim();
            drRowToAdd["RefNo"] = strBatchId.ToString().Trim();

            strTemp = strArr[0].Trim();
            drRowToAdd["Vessel"] = strTemp.Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Vessel name is mandatory";
                blParseError = true;
                sbInputString.Append("Vessel : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();
            drRowToAdd["Type"] = strTemp.Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["Built"] = strTemp.Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["GRT"] = strLocalTemp = strTemp.Replace(",", ".");

            strTemp = strArr[4].Trim();
            drRowToAdd["NRT"] = strTemp.Replace(",", ".");

            strTemp = strArr[5].Trim();
            drRowToAdd["BHP"] = strTemp.Replace(",", ".");

            strTemp = strArr[6].Trim();
            drRowToAdd["Class"] = strTemp.Replace(",", ".");

            strTemp = strArr[7].Trim();
            drRowToAdd["Flag"] = strTemp.Replace(",", ".");

            strTemp = strArr[8].Trim();
            drRowToAdd["Dimension"] = strTemp.Replace(",", ".");

            strTemp = strArr[9].Trim();
            drRowToAdd["DWT"] = strTemp.Trim();

            strTemp = strArr[10].Trim();
            drRowToAdd["IMONo"] = strTemp.Trim();

            strTemp = strArr[11].Trim();
            drRowToAdd["IVInsuredValue"] = strTemp.Trim();

            strTemp = strArr[12].Trim();
            drRowToAdd["AOIInsuredValue"] = strTemp.Trim();

            strTemp = strArr[13].Trim();
            drRowToAdd["AdditionalAssureds"] = strTemp.Trim();

            strTemp = strArr[14].Trim();
            drRowToAdd["GeneralAverage"] = strTemp.Trim();

            strTemp = strArr[15].Trim();
            drRowToAdd["Owner"] = strTemp.Replace(",", ".");

            strTemp = strArr[16].Trim();
            drRowToAdd["Managers"] = strTemp.Replace(",", ".");

            strTemp = strArr[17].Trim();
            drRowToAdd["Mortgagees"] = strTemp.Replace(",", ".");

            strTemp = strArr[18].Trim().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -InceptionDate is mandatory";
                blParseError = true;
                sbInputString.Append("InceptionDate : " + strTemp + "*~*");
            }
            drRowToAdd["InceptionDate"] = strTemp;

            strTemp = strArr[19].Trim().Replace(",", ".");
            drRowToAdd["ExpiryDate"] = strTemp;

            strTemp = strArr[20].Trim();
            drRowToAdd["UnderwriterCode"] = strTemp.Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -UnderwriterCode is mandatory";
                blParseError = true;
                sbInputString.Append("UnderwriterCode : " + strTemp + "*~*");
            }

            strTemp = strArr[21].Trim();
            drRowToAdd["SubClassCode"] = strTemp.Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -SubClassCode is mandatory";
                blParseError = true;
                sbInputString.Append("SubClassCode : " + strTemp + "*~*");
            }

            strTemp = strArr[22].Trim();
            drRowToAdd["Currency"] = strTemp.Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Currency is mandatory";
                blParseError = true;
                sbInputString.Append("Currency : " + strTemp + "*~*");
            }

            strTemp = strArr[23].Trim();
            drRowToAdd["SumInsured"] = string.IsNullOrEmpty(strTemp) ? "0" : strTemp; ;
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -SumInsured is mandatory";
                blParseError = true;
                sbInputString.Append("SumInsured : " + strTemp + "*~*");
            }
            //else if (strTemp.IndexOf('.') == -1)
            //{
            //    strTemp += " - Error -SumInsured must have 2 decimal places";
            //    blParseError = true;
            //    sbInputString.Append("SumInsured : " + strTemp + "*~*");
            //}

            strTemp = strArr[24].Trim();
            drRowToAdd["Rate"] = string.IsNullOrEmpty(strTemp) ? "0" : strTemp;

            strTemp = strArr[25].Trim();
            drRowToAdd["Loading"] = string.IsNullOrEmpty(strTemp) ? "0" : strTemp;

            strTemp = strArr[26].Trim();
            drRowToAdd["Share"] = string.IsNullOrEmpty(strTemp) ? "0" : strTemp;
            if (strTemp.Length == 0)
            {
                strTemp += " - Error -Share is mandatory";
                blParseError = true;
                sbInputString.Append("Share : " + strTemp + "*~*");
            }

            strTemp = strArr[27].Trim();
            drRowToAdd["Premium"] = string.IsNullOrEmpty(strTemp) ? "0" : strTemp;

            strTemp = strArr[28].Trim();
            drRowToAdd["Deductible"] = strTemp.Replace(",", ".");
            if (strTemp.Length > 50)
            {
                strTemp += " - Error -Deductible should not be more than 50 characters length";
                blParseError = true;
                sbInputString.Append("Deductible : " + strTemp + "*~*");
            }

            strTemp = strArr[29].Trim();
            drRowToAdd["Remarks"] = strTemp;
            if (strTemp.Length > 500)
            {
                strTemp += " - Error -Remarks should not be more than 500 characters length";
                blParseError = true;
                sbInputString.Append("Remarks : " + strTemp + "*~*");
            }

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            dtSourceTble.Rows.Add(drRowToAdd);
        }

        private void ImportToDatabaseWorkingTblMember()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_VesselWorking";
            bulkCopy.WriteToServer(dtSourceTble);
        }
        private void DataTransferToRealTable(string strRefNo)
        {
            try
            {
                //DataAccess dataAccessDS = null;
                DataSet ds = new DataSet();
                //object[] parameters = new object[] { strRefNo };
                //dataAccessDS = new DataAccess(_ConfigReader.ConnString,"service");
                //ds = dataAccessDS.LoadDataSet(parameters, "P_TransferVesselRealTable", "TransferVesselRealTable");
                ds = GetDataSet("P_TransferVesselRealTable '" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                UpdateStatus();
                ServiceUtility.WriteLog(ex.ToString(), mClientCode);
                //refreshInputFolder();
            }
        }

        private void DeleteWorkingTable(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_Vessel_UploadWorkingDelete '" + strRefNo + "'");
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
                //throw new Exception(ex.Message);
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
        protected void refreshInputFolder()
        {
            string strSource = strCurrFileName;
            if (!Directory.Exists(strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ProcessedFiles\"))
                Directory.CreateDirectory(strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ProcessedFiles\");
            string strNewFile = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ProcessedFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            if (File.Exists(strNewFile))
            {
                File.Delete(strNewFile);
            }
            File.Move(strSource, strNewFile);
        }
        private void CreateTable()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("Vessel");
            dtSourceTble.Columns.Add("Type");
            dtSourceTble.Columns.Add("Built");
            dtSourceTble.Columns.Add("GRT");
            dtSourceTble.Columns.Add("NRT");
            dtSourceTble.Columns.Add("BHP");
            dtSourceTble.Columns.Add("Class");
            dtSourceTble.Columns.Add("Flag");
            dtSourceTble.Columns.Add("Dimension");
            dtSourceTble.Columns.Add("DWT");
            dtSourceTble.Columns.Add("IMONo");
            dtSourceTble.Columns.Add("IVInsuredValue");
            dtSourceTble.Columns.Add("AOIInsuredValue");
            dtSourceTble.Columns.Add("AdditionalAssureds");
            dtSourceTble.Columns.Add("GeneralAverage");
            dtSourceTble.Columns.Add("Owner");
            dtSourceTble.Columns.Add("Managers");
            dtSourceTble.Columns.Add("Mortgagees");
            dtSourceTble.Columns.Add("InceptionDate");
            dtSourceTble.Columns.Add("ExpiryDate");
            dtSourceTble.Columns.Add("UnderwriterCode");
            dtSourceTble.Columns.Add("SubClassCode");
            dtSourceTble.Columns.Add("Currency");
            dtSourceTble.Columns.Add("SumInsured");
            dtSourceTble.Columns.Add("Rate");
            dtSourceTble.Columns.Add("Loading");
            dtSourceTble.Columns.Add("Share");
            dtSourceTble.Columns.Add("Premium");
            dtSourceTble.Columns.Add("Deductible");
            dtSourceTble.Columns.Add("Remarks");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }

        protected void WriteLog(string strLogMsg)
        {
            EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }
        private bool ValidateExcel(DataTable dtExcel, int columnCount, ref string error, params string[] columnArr)
        {
            if (clsExcelUploadUtility.genericValidationForExcel(dtExcel, columnCount, ref error, columnArr) == false) { return false; }
            for (var i = 0; i < dtExcel.Rows.Count; i++)
            {
                if (clsExcelUploadUtility.checkEmpty(dtExcel.Rows[i]["VESSEL"].ToString().Trim(), "Vessel", i + 2, ref error) == false) { return false; }
                if (clsExcelUploadUtility.validateDateField(dtExcel.Rows[i]["InceptionDate"].ToString().Trim(), "Inception Date", i + 2, "date", ref error) == false) { return false; }
                if (clsExcelUploadUtility.validateDateField(dtExcel.Rows[i]["ExpiryDate"].ToString().Trim(), "Expiry Date", i + 2, "date", ref error) == false) { return false; }
            }
            return true;
        }
        private string getFileExtension()
        {
            string strExt = "";
            try
            {
                objVesselDetails.FileName = "";
                objVesselDetails.RefNo = strBatchId;
                objVesselDetails.UploadFromDate = "";
                objVesselDetails.UploadToDate = "";
                objVesselDetails.frmFor = "";
                objVesselDetails.PolicyId = 0;
                objVesselDetails.PolVersionId = 0;
                DataSet dsDetails = new DataSet();
                dsDetails = objVesselDetailsManager.GetVesselBatchFileUploadList(objVesselDetails, _ConfigReader.ConnString);
                if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                    strExt = dsDetails.Tables[0].Rows[0]["FileType"].ToString();
            }
            catch (Exception ex)
            {
                WriteLog("Unable to get File extension:-" + Environment.NewLine + ex.Message);
            }
            return strExt;
        }
        public string ReadExcelFile(ref DataTable dtExcel, string filepath)
        {
            OleDbConnection oleExcelCon = new OleDbConnection();
            OleDbDataAdapter oleExcelAdp;
            OleDbCommand oleExcelCmd;
            DataTable schemaTable;
            DataView dvSheetName;
            DataTable filteredTable;

            string error = "";
            try
            {
                oleExcelCon.ConnectionString = _ConfigReader.ExcelConnXLSX + filepath;// ConfigurationManager.AppSettings["ExcelConnXLSX"].ToString();
                oleExcelCon.Open();
                schemaTable = oleExcelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                dvSheetName = new DataView(schemaTable);
                dvSheetName.RowFilter = "TABLE_NAME LIKE '%$'";
                filteredTable = dvSheetName.ToTable();
                if (filteredTable.Rows.Count == 1)
                {
                    for (int i = 0; i < filteredTable.Rows.Count; i++)
                    {
                        string strSql = "Select * From [" + filteredTable.Rows[i].ItemArray[2].ToString() + "]";
                        oleExcelCmd = new OleDbCommand(strSql, oleExcelCon);
                        oleExcelAdp = new OleDbDataAdapter(oleExcelCmd);
                        oleExcelAdp.Fill(dtExcel);
                    }
                }
                else
                    error = "Uploaded file should contain only one sheet with no Filter/Fixed Header.";
                oleExcelCon.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                oleExcelCon.Dispose();
            }
            return error;
        }
        private void UpdateStatus()
        {
            DataSet ds = new DataSet();

            objVesselDetails.RefNo = strBatchId;
            objVesselDetails.FilePath = null;
            objVesselDetails.Source = "Service";
            objVesselDetails.TotalRecord = intTotalNoOfRecords;
            objVesselDetails.SuccessRecord = intValidRecCnt;
            objVesselDetails.FailRecord = intInValidRecCnt;
            ds = objVesselDetailsManager.UpdateBatchUploadVessel(objVesselDetails, _ConfigReader.ConnString);
        }
        private void UpdateFileStatus(string strRefNo, string errorMessage)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_UpdateFileStatus '" + strRefNo + "'  ,  '" + errorMessage + "' ");
            }
            catch (Exception ex)
            {
                UpdateStatus();
                ServiceUtility.WriteLog(ex.ToString(), mClientCode);
            }
        }
        #endregion
    }
}
