using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using LumenWorks.Framework.IO.Csv;

namespace eProStarServices
{
    public class BatchProcessMember
    {
        protected string mstrConStr = "";
        protected string mstrFolderPath = "";
        protected string mstrConnFolderName = "";
        protected string mstrSourceFilePath = "";
        protected string mstrCurrencySourceFilePath = "";
        protected string strCurrFileName = "";
        protected bool blDuplicate = false;
        protected bool blLogEnabled = false;
        protected DataTable dtSourceTble = null;
        private SqlBulkCopy bulkCopy = null;
        StreamWriter swLog = null;
        protected string strBatchId = "";
        protected string strRemarks = "";
        protected string strBatFileExt = "";
        protected int intTotalNoOfRecords = 0;
        protected int intInValidRecCnt = 0;
        protected int intValidRecCnt = 0;
        protected int intApprovalRecCnt = 0;
        protected int intSrNo = 0;
        protected string strUploadType = "";

        protected string _strInitialFilePath = String.Empty;
        protected string _strEnrolledFilePath = String.Empty;
        protected string _strMassAdjustmentFilePath = String.Empty;
        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader=null;
        public BatchProcessMember(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }
      
        public void beginProcess()
        {
            EventLogs.Publish("Member Upload Service Started for " + mClientCode, System.Diagnostics.EventLogEntryType.Information);
            ServiceUtility.WriteLog("Member Upload Service Started", mClientCode);
            mstrFolderPath = _ConfigReader.FolderPath.ToString();
            //int i = 0;
            //int iCount = System.Configuration.ConfigurationManager.ConnectionStrings.Count;
            //ServiceUtility.WriteLog("config", mClientCode);
            //for (i = 1; i < iCount; i++)
            {
                //mstrConnFolderName = _ConfigReader.Name; //System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                mstrConStr = _ConfigReader.ConnString; 
                mstrSourceFilePath = _ConfigReader.CSVSourceFilePath.ToString();
                ServiceUtility.WriteLog("Config1", mClientCode);
                mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

                if (!string.IsNullOrEmpty(mstrConStr.Trim()))
                {

                    ReadLoadSourceFile();
                    ServiceUtility.WriteLog("ReadLoadSourceFile", mClientCode);

                    ReadLoadSourceFile_EN();
                    ServiceUtility.WriteLog("ReadLoadSourceFile_EN", mClientCode);

                    ReadLoadSourceFile_MA();
                    ServiceUtility.WriteLog("ReadLoadSourceFile_MA", mClientCode);
                }
            }
            EventLogs.Publish("Member Upload Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        #region Initial Member Batch Upload
        private void ReadLoadSourceFile()
        {
            _strInitialFilePath = _ConfigReader.InitialFolderPath.ToString();
            if (!String.IsNullOrEmpty(_strInitialFilePath))
                mstrSourceFilePath = mstrSourceFilePath + "\\" + _strInitialFilePath;
            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);
            ServiceUtility.WriteLog("ReadLoadSourceFile_1", mClientCode);
            if (strFiles.Length > 0)
            {
                try
                {
                    WriteLog(" First Method ReadLoadSourceFile for Initial Upload :-" + mstrSourceFilePath);
                    WriteLog("File Process Started On " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    dtSourceTble = null;
                    strCurrFileName = strFiles[0];
                    strBatFileExt = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strUploadType = strCurrFileName.Substring(strCurrFileName.LastIndexOf("\\"), 5).ToString().Trim().Replace("\\", "");
                    ServiceUtility.WriteLog("ReadLoadSourceFile_2", mClientCode);
                    strRemarks = "";
                    if (strUploadType == "MED-")
                    {
                        DeleteWorkingTableMember(strBatchId);
                        ReadFileAndLoadDataTableMember(strCurrFileName);
                    }
                    else if (strUploadType == "LIF-")
                    {
                        DeleteWorkingTableMemberLife(strBatchId);
                        ReadFileAndLoadDataTableMemberLife(strCurrFileName);
                    }
                    ServiceUtility.WriteLog("ReadLoadSourceFile_3", mClientCode);
                    WriteLog(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    WriteLog("File Process completed");
                }
                catch (Exception ex)
                {
                    WriteLog("Error:");
                    WriteLog("~~~~~~");
                    WriteLog(ex.Message);
                    ServiceUtility.WriteLog(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }
        protected void ReadFileAndLoadDataTableMember(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberMedicalTbl();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null && (strArrCurrData.Length == 20))
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMember(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }

                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMember();
                    DataTransferToRealTableMember(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    //SendEMail("Vessel Upload Status - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), strBody);
                    refreshInputFolder();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }
        protected void ReadFileAndLoadDataTableMemberLife(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberLifeTbl();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null && (strArrCurrData.Length == 16))
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMemberLife(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }
                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMemberLife();
                    DataTransferToRealTableMemberLife(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    //SendEMail("Vessel Upload Status - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), strBody);
                    refreshInputFolder();

                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }
        private string GenerateTableDate(DataRow row, string strFieldName)
        {
            if (row[strFieldName].ToString().Trim().Contains("~*Error*~") || strFieldName.ToUpper() == "REMARKS")
                return "<td bgcolor=Orange>" + row[strFieldName].ToString().Trim().Replace("~*Error*~", "") + "</td>";
            else
                return "<td>" + row[strFieldName].ToString().Trim() + "</td>";
        }
        private void addInputRowToTableMember(string[] strArr, string Counter)
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
            drRowToAdd["PolicyNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -PolicyNo is mandatory";
                blParseError = true;
                sbInputString.Append("PolicyNo : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();
            drRowToAdd["SubsidiaryCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["CertNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["RelationshipType"] = strLocalTemp = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[4].Trim();
            drRowToAdd["Relationship"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("dependant"))
            {
                strTemp += " - Error -Relationship is mandatory, While Relation Type is Dependant.";
                blParseError = true;
                sbInputString.Append("Relationship : " + strTemp + "*~*");
            }

            strTemp = strArr[5].Trim();
            drRowToAdd["Sex"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Sex is mandatory";
                blParseError = true;
                sbInputString.Append("Sex : " + strTemp + "*~*");
            }

            strTemp = strArr[6].Trim();
            drRowToAdd["MemberName"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Member Name is mandatory";
                blParseError = true;
                sbInputString.Append("MemberName : " + strTemp + "*~*");
            }

            strTemp = strArr[7].Trim();
            drRowToAdd["DependantName"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("dependant"))
            {
                strTemp += " - Error -Dependant Name is mandatory, While Relation Type is Dependant.";
                blParseError = true;
                sbInputString.Append("Dependant Name : " + strTemp + "*~*");
            }

            strTemp = strArr[8].Trim();
            drRowToAdd["HKIDPassport"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[9].Trim();
            drRowToAdd["BirthDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -BirthDate is mandatory";
                blParseError = true;
                sbInputString.Append("BirthDate : " + strTemp + "*~*");
            }

            strTemp = strArr[10].Trim();
            drRowToAdd["Plan"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Plan is mandatory";
                blParseError = true;
                sbInputString.Append("Plan : " + strTemp + "*~*");
            }

            strTemp = strArr[11].Trim();
            drRowToAdd["EmploymentDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("employee"))
            {
                strTemp += " - Error -EmploymentDate is mandatory";
                blParseError = true;
                sbInputString.Append("EmploymentDate : " + strTemp + "*~*");
            }

            strTemp = strArr[12].Trim();
            drRowToAdd["EffectiveDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -EffectiveDate is mandatory";
                blParseError = true;
                sbInputString.Append("EffectiveDate : " + strTemp + "*~*");
            }

            strTemp = strArr[13].Trim();
            drRowToAdd["DepartmentName"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[14].Trim();
            drRowToAdd["BankCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[15].Trim();
            drRowToAdd["BranchCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[16].Trim();
            drRowToAdd["AccountNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[17].Trim();
            drRowToAdd["EmailAddress"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[18].Trim();
            drRowToAdd["DateFromCL"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[19].Trim();
            drRowToAdd["DateToUW"] = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            dtSourceTble.Rows.Add(drRowToAdd);
        }
        private void addInputRowToTableMemberLife(string[] strArr, string Counter)
        {
            bool blParseError = false;
            blDuplicate = false;
            StringBuilder sbInputString = new StringBuilder();
            string strTemp = "";
            DataRow drRowToAdd = dtSourceTble.NewRow();
            drRowToAdd["SrNo"] = intSrNo.ToString().Trim();
            drRowToAdd["RefNo"] = strBatchId.ToString().Trim();
            strTemp = strArr[0].Trim();
            drRowToAdd["PolicyNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -PolicyNo is mandatory";
                blParseError = true;
                sbInputString.Append("PolicyNo : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();
            drRowToAdd["CertNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["DType"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["Name"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Name is mandatory";
                blParseError = true;
                sbInputString.Append("Name : " + strTemp + "*~*");
            }

            strTemp = strArr[4].Trim();
            drRowToAdd["Sex"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Sex is mandatory";
                blParseError = true;
                sbInputString.Append("Sex : " + strTemp + "*~*");
            }

            strTemp = strArr[5].Trim();
            drRowToAdd["BirthDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -BirthDate is mandatory";
                blParseError = true;
                sbInputString.Append("BirthDate : " + strTemp + "*~*");
            }

            strTemp = strArr[6].Trim();
            drRowToAdd["Class"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[7].Trim();
            drRowToAdd["Salary"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[8].Trim();
            drRowToAdd["SumInsured"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[9].Trim();
            drRowToAdd["ADND"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[10].Trim();
            drRowToAdd["ADND2"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[11].Trim();
            drRowToAdd["TPD"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[12].Trim();
            drRowToAdd["EGP"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[13].Trim();
            drRowToAdd["EffectiveDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -EffectiveDate is mandatory";
                blParseError = true;
                sbInputString.Append("EffectiveDate : " + strTemp + "*~*");
            }

            strTemp = strArr[14].Trim();
            drRowToAdd["ExpiryDate"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[15].Trim();
            drRowToAdd["Remarks"] = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ParseMsg"] = sbInputString.ToString().Trim();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            dtSourceTble.Rows.Add(drRowToAdd);
        }
        private void ImportToDatabaseWorkingTblMember()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberWorking";
            bulkCopy.WriteToServer(dtSourceTble);
        }
        private void ImportToDatabaseWorkingTblMemberLife()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberLifeWorking";
            bulkCopy.WriteToServer(dtSourceTble);
        }
        private void DataTransferToRealTableMember(string strRefNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_EB_TransferMemberRealTable '" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
                refreshInputFolder();
            }
        }
        private void DataTransferToRealTableMemberLife(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_TransferMemberLifeRealTable '" + strRefNo + "'");
        }
        private void DeleteWorkingTableMember(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberWorkingDelete '" + strRefNo + "'");
        }
        private void DeleteWorkingTableMemberLife(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberLifeWorkingDelete '" + strRefNo + "'");
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
                myCommand.Transaction.Rollback();
                throw new Exception(ex.Message);
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
        private void CreateMemberMedicalTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("SubsidiaryCode");
            dtSourceTble.Columns.Add("CertNo");
            //dtSourceTble.Columns.Add("RelationshipCode");
            dtSourceTble.Columns.Add("RelationshipType");
            dtSourceTble.Columns.Add("Relationship");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("MemberName");
            dtSourceTble.Columns.Add("DependantName");
            dtSourceTble.Columns.Add("HKIDPassport");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Plan");
            dtSourceTble.Columns.Add("EmploymentDate");
            dtSourceTble.Columns.Add("EffectiveDate");
            dtSourceTble.Columns.Add("DepartmentName");
            dtSourceTble.Columns.Add("BankCode");
            dtSourceTble.Columns.Add("BranchCode");
            dtSourceTble.Columns.Add("AccountNo");
            dtSourceTble.Columns.Add("EmailAddress");
            dtSourceTble.Columns.Add("DateFromCL");
            dtSourceTble.Columns.Add("DateToUW");
            //dtSourceTble.Columns.Add("IDNo");
            //dtSourceTble.Columns.Add("ExpiryDate");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }
        private void CreateMemberLifeTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("CertNo");
            dtSourceTble.Columns.Add("DType");
            dtSourceTble.Columns.Add("Name");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Class");
            dtSourceTble.Columns.Add("Salary");
            dtSourceTble.Columns.Add("SumInsured");
            dtSourceTble.Columns.Add("ADND");
            dtSourceTble.Columns.Add("ADND2");
            dtSourceTble.Columns.Add("TPD");
            dtSourceTble.Columns.Add("EGP");
            dtSourceTble.Columns.Add("EffectiveDate");
            dtSourceTble.Columns.Add("ExpiryDate");
            dtSourceTble.Columns.Add("Remarks");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }
        protected void WriteLog(string strLogMsg)
        {
            EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }
        #endregion

        #region "Member Enrollment Batch Upload"
        private void ReadLoadSourceFile_EN()
        {
            mstrFolderPath = _ConfigReader.FolderPath.ToString();
            mstrSourceFilePath = _ConfigReader.CSVSourceFilePath.ToString();
            mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

            _strEnrolledFilePath = _ConfigReader.EnrolledFolderPath.ToString();
            if (!String.IsNullOrEmpty(_strEnrolledFilePath))
                mstrSourceFilePath = mstrSourceFilePath + "\\" + _strEnrolledFilePath;
            ServiceUtility.WriteLog("ReadLoadSourceFile_EN_1", mClientCode);
            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);
            if (strFiles.Length > 0)
            {
                try
                {
                    WriteLog(" First Method ReadLoadSourceFile for Enrolled Upload :-" + mstrSourceFilePath);
                    WriteLog("File Process Started On " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    dtSourceTble = null;
                    strCurrFileName = strFiles[0];
                    strBatFileExt = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strUploadType = strCurrFileName.Substring(strCurrFileName.LastIndexOf("\\"), 5).ToString().Trim().Replace("\\", "");
                    strRemarks = "";
                    ServiceUtility.WriteLog("ReadLoadSourceFile_EN_2", mClientCode);
                    if (strUploadType == "MED-")
                    {
                        DeleteWorkingTableMember_EN(strBatchId);
                        ReadFileAndLoadDataTableMember_EN(strCurrFileName);
                    }
                    else if (strUploadType == "LIF-")
                    {
                        DeleteWorkingTableMemberLife_EN(strBatchId);
                        ReadFileAndLoadDataTableMemberLife_EN(strCurrFileName);
                    }
                    ServiceUtility.WriteLog("ReadLoadSourceFile_EN_3", mClientCode);
                    WriteLog(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    WriteLog("File Process completed");
                }
                catch (Exception ex)
                {
                    WriteLog("Error:");
                    WriteLog("~~~~~~");
                    WriteLog(ex.Message);
                    ServiceUtility.WriteLog(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }

        private void DeleteWorkingTableMember_EN(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberWorkingDelete_EN '" + strRefNo + "'");
        }

        protected void ReadFileAndLoadDataTableMember_EN(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberMedicalTbl_EN();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null)
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMember_EN(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }
                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMember_EN();
                    DataTransferToRealTableMember_EN(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    refreshInputFolder();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }

        private void CreateMemberMedicalTbl_EN()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");

            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("SubsidiaryCode");
            dtSourceTble.Columns.Add("CertNo");
            dtSourceTble.Columns.Add("RelationshipType");
            dtSourceTble.Columns.Add("Relationship");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("MemberName");
            dtSourceTble.Columns.Add("DependantName");
            dtSourceTble.Columns.Add("HKIDPassport");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Plan");
            dtSourceTble.Columns.Add("EmploymentDate");
            dtSourceTble.Columns.Add("EffectiveDate");
            dtSourceTble.Columns.Add("DepartmentName");
            dtSourceTble.Columns.Add("BankCode");
            dtSourceTble.Columns.Add("BranchCode");
            dtSourceTble.Columns.Add("AccountNo");
            dtSourceTble.Columns.Add("EmailAddress");
            dtSourceTble.Columns.Add("DateFromCL");
            dtSourceTble.Columns.Add("DateToUW");
            dtSourceTble.Columns.Add("AdjRepNo");
            dtSourceTble.Columns.Add("AdjRepFromUWDate");
            dtSourceTble.Columns.Add("AdjRepToCLDate");
            dtSourceTble.Columns.Add("CardNo");
            dtSourceTble.Columns.Add("CardDispatchDate");

            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }

        private void addInputRowToTableMember_EN(string[] strArr, string Counter)
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
            drRowToAdd["PolicyNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -PolicyNo is mandatory";
                blParseError = true;
                sbInputString.Append("PolicyNo : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();
            drRowToAdd["SubsidiaryCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["CertNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["RelationshipType"] = strLocalTemp = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[4].Trim();
            drRowToAdd["Relationship"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("dependant"))
            {
                strTemp += " - Error -Relationship is mandatory, While Relation Type is Dependant.";
                blParseError = true;
                sbInputString.Append("Relationship : " + strTemp + "*~*");
            }

            strTemp = strArr[5].Trim();
            drRowToAdd["Sex"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Sex is mandatory";
                blParseError = true;
                sbInputString.Append("Sex : " + strTemp + "*~*");
            }

            strTemp = strArr[6].Trim();
            drRowToAdd["MemberName"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Member Name is mandatory";
                blParseError = true;
                sbInputString.Append("MemberName : " + strTemp + "*~*");
            }

            strTemp = strArr[7].Trim();
            drRowToAdd["DependantName"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("dependant"))
            {
                strTemp += " - Error -Dependant Name is mandatory, While Relation Type is Dependant.";
                blParseError = true;
                sbInputString.Append("Dependant Name : " + strTemp + "*~*");
            }

            strTemp = strArr[8].Trim();
            drRowToAdd["HKIDPassport"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[9].Trim();
            drRowToAdd["BirthDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -BirthDate is mandatory";
                blParseError = true;
                sbInputString.Append("BirthDate : " + strTemp + "*~*");
            }

            strTemp = strArr[10].Trim();
            drRowToAdd["Plan"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Plan is mandatory";
                blParseError = true;
                sbInputString.Append("Plan : " + strTemp + "*~*");
            }

            strTemp = strArr[11].Trim();
            drRowToAdd["EmploymentDate"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("employee"))
            {
                strTemp += " - Error -EmploymentDate is mandatory";
                blParseError = true;
                sbInputString.Append("EmploymentDate : " + strTemp + "*~*");
            }

            strTemp = strArr[12].Trim();
            drRowToAdd["EffectiveDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToLower().Equals("employee"))
            {
                strTemp += " - Error -EffectiveDate is mandatory";
                blParseError = true;
                sbInputString.Append("EffectiveDate : " + strTemp + "*~*");
            }

            strTemp = strArr[13].Trim();
            drRowToAdd["DepartmentName"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[14].Trim();
            drRowToAdd["BankCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[15].Trim();
            drRowToAdd["BranchCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[16].Trim();
            drRowToAdd["AccountNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[17].Trim();
            drRowToAdd["EmailAddress"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[18].Trim();
            drRowToAdd["DateFromCL"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Date From Client is mandatory";
                blParseError = true;
                sbInputString.Append("Date From Client : " + strTemp + "*~*");
            }


            strTemp = strArr[19].Trim();
            drRowToAdd["DateToUW"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Date To UW is mandatory";
                blParseError = true;
                sbInputString.Append("Date To UW : " + strTemp + "*~*");
            }

            strTemp = strArr[20].Trim();
            drRowToAdd["AdjRepNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[21].Trim();
            drRowToAdd["AdjRepFromUWDate"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[22].Trim();
            drRowToAdd["AdjRepToCLDate"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[23].Trim();
            drRowToAdd["CardNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[24].Trim();
            drRowToAdd["CardDispatchDate"] = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            dtSourceTble.Rows.Add(drRowToAdd);
        }

        private void ImportToDatabaseWorkingTblMember_EN()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberWorking_EN";
            bulkCopy.WriteToServer(dtSourceTble);
        }

        private void DataTransferToRealTableMember_EN(string strRefNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_EB_TransferMemberRealTable_EN '" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
                refreshInputFolder();
            }
        }

        private void DeleteWorkingTableMemberLife_EN(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberLifeWorkingDelete '" + strRefNo + "'");
        }

        protected void ReadFileAndLoadDataTableMemberLife_EN(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberLifeTbl_EN();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null && (strArrCurrData.Length == 16))
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMemberLife(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }
                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMemberLife_EN();
                    DataTransferToRealTableMemberLife_EN(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    //SendEMail("Vessel Upload Status - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), strBody);
                    refreshInputFolder();

                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }

        private void CreateMemberLifeTbl_EN()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("CertNo");
            dtSourceTble.Columns.Add("DType");
            dtSourceTble.Columns.Add("Name");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Class");
            dtSourceTble.Columns.Add("Salary");
            dtSourceTble.Columns.Add("SumInsured");
            dtSourceTble.Columns.Add("ADND");
            dtSourceTble.Columns.Add("ADND2");
            dtSourceTble.Columns.Add("TPD");
            dtSourceTble.Columns.Add("EGP");
            dtSourceTble.Columns.Add("EffectiveDate");
            dtSourceTble.Columns.Add("ExpiryDate");
            dtSourceTble.Columns.Add("Remarks");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }

        private void ImportToDatabaseWorkingTblMemberLife_EN()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberLifeWorking";
            bulkCopy.WriteToServer(dtSourceTble);
        }

        private void DataTransferToRealTableMemberLife_EN(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_TransferMemberLifeRealTable '" + strRefNo + "'");
        }

        #endregion

        #region "Mass Adjustment Batch Upload"
        private void ReadLoadSourceFile_MA()
        {
            mstrFolderPath = _ConfigReader.FolderPath.ToString();
            mstrSourceFilePath = _ConfigReader.CSVSourceFilePath.ToString();
            mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

            _strEnrolledFilePath = _ConfigReader.MassAdjustmentFolderPath.ToString();
            if (!String.IsNullOrEmpty(_strEnrolledFilePath))
                mstrSourceFilePath = mstrSourceFilePath + "\\" + _strEnrolledFilePath;
            ServiceUtility.WriteLog("ReadLoadSourceFile_MA_1", mClientCode);
            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);
            if (strFiles.Length > 0)
            {
                try
                {
                    WriteLog(" First Method ReadLoadSourceFile for Mass Adjustment Upload :-" + mstrSourceFilePath);
                    WriteLog("File Process Started On " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    dtSourceTble = null;
                    strCurrFileName = strFiles[0];
                    strBatFileExt = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strUploadType = strCurrFileName.Substring(strCurrFileName.LastIndexOf("\\"), 5).ToString().Trim().Replace("\\", "");
                    strRemarks = "";
                    ServiceUtility.WriteLog("ReadLoadSourceFile_MA_2", mClientCode);
                    if (strUploadType == "MED-")
                    {
                        DeleteWorkingTableMember_MA(strBatchId);
                        ReadFileAndLoadDataTableMember_MA(strCurrFileName);
                    }
                    else if (strUploadType == "LIF-")
                    {
                        DeleteWorkingTableMemberLife_MA(strBatchId);
                        ReadFileAndLoadDataTableMemberLife_MA(strCurrFileName);
                    }
                    ServiceUtility.WriteLog("ReadLoadSourceFile_MA_3", mClientCode);
                    WriteLog(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    WriteLog("File Process completed");
                }
                catch (Exception ex)
                {
                    WriteLog("Error:");
                    WriteLog("~~~~~~");
                    ServiceUtility.WriteLog(ex.Message,mClientCode);
                }
            }
            else
            {
                return;
            }
        }

        private void DeleteWorkingTableMember_MA(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberWorkingDelete_MA '" + strRefNo + "'");
        }

        protected void ReadFileAndLoadDataTableMember_MA(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberMedicalTbl_MA();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null)
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMember_MA(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }
                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMember_MA();
                    DataTransferToRealTableMember_MA(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    refreshInputFolder();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }

        private void CreateMemberMedicalTbl_MA()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");

            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("SubsidiaryCode");
            dtSourceTble.Columns.Add("CertNo");
            dtSourceTble.Columns.Add("RelationshipType");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("Name");
            dtSourceTble.Columns.Add("HKIDPassport");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Plan");

            dtSourceTble.Columns.Add("MemberStatus");
            dtSourceTble.Columns.Add("TerminationEffDate");
            dtSourceTble.Columns.Add("ReinstatementEffDate");
            dtSourceTble.Columns.Add("ChangeInPlanEffDate");
            dtSourceTble.Columns.Add("ChangeInPersonalInfoEffDate");

            dtSourceTble.Columns.Add("DepartmentName");
            dtSourceTble.Columns.Add("BankCode");
            dtSourceTble.Columns.Add("BranchCode");
            dtSourceTble.Columns.Add("AccountNo");
            dtSourceTble.Columns.Add("EmailAddress");
            dtSourceTble.Columns.Add("DateFromCL");
            dtSourceTble.Columns.Add("DateToUW");
            dtSourceTble.Columns.Add("AdjRepNo");
            dtSourceTble.Columns.Add("AdjRepFromUWDate");
            dtSourceTble.Columns.Add("AdjRepToCLDate");
            dtSourceTble.Columns.Add("ReinstatementCardNo");
            dtSourceTble.Columns.Add("CardDispatchDate");

            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }

        private void addInputRowToTableMember_MA(string[] strArr, string Counter)
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
            drRowToAdd["PolicyNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -PolicyNo is mandatory";
                blParseError = true;
                sbInputString.Append("PolicyNo : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();
            drRowToAdd["SubsidiaryCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["CertNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["RelationshipType"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[4].Trim();
            drRowToAdd["Sex"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Sex is mandatory";
                blParseError = true;
                sbInputString.Append("Sex : " + strTemp + "*~*");
            }

            strTemp = strArr[5].Trim();
            drRowToAdd["Name"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Member Name is mandatory";
                blParseError = true;
                sbInputString.Append("MemberName : " + strTemp + "*~*");
            }

            strTemp = strArr[6].Trim();
            drRowToAdd["HKIDPassport"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[7].Trim();
            drRowToAdd["BirthDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -BirthDate is mandatory";
                blParseError = true;
                sbInputString.Append("BirthDate : " + strTemp + "*~*");
            }

            strTemp = strArr[8].Trim();
            drRowToAdd["Plan"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Plan is mandatory";
                blParseError = true;
                sbInputString.Append("Plan : " + strTemp + "*~*");
            }

            strTemp = strArr[9].Trim();
            drRowToAdd["MemberStatus"] = strLocalTemp = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -MemberStatus is mandatory";
                blParseError = true;
                sbInputString.Append("MemberStatus : " + strTemp + "*~*");
            }

            strTemp = strArr[10].Trim();
            drRowToAdd["TerminationEffDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToUpper().Equals("TERMINATION"))
            {
                strTemp += " - Error -TerminationEffDate is mandatory, While Status is Termination.";
                blParseError = true;
                sbInputString.Append("TerminationEffDate : " + strTemp + "*~*");
            }

            strTemp = strArr[11].Trim();
            drRowToAdd["ReinstatementEffDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToUpper().Equals("REINSTATEMENT"))
            {
                strTemp += " - Error -ReinstatementEffDate is mandatory, While Status is Reinstatement.";
                blParseError = true;
                sbInputString.Append("ReinstatementEffDate : " + strTemp + "*~*");
            }

            strTemp = strArr[12].Trim();
            drRowToAdd["ChangeInPlanEffDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToUpper().Equals("CHANGE IN PLAN"))
            {
                strTemp += " - Error -ChangeInPlanEffDate is mandatory, While Status is Change in Plan.";
                blParseError = true;
                sbInputString.Append("ChangeInPlanEffDate : " + strTemp + "*~*");
            }

            strTemp = strArr[13].Trim();
            drRowToAdd["ChangeInPersonalInfoEffDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0 && strLocalTemp.ToUpper().Equals("CHANGE IN PERSONAL INFO"))
            {
                strTemp += " - Error -ChangeInPersonalInfoEffDate is mandatory, While Status is Change in Personal Info.";
                blParseError = true;
                sbInputString.Append("ChangeInPersonalInfoEffDate : " + strTemp + "*~*");
            }

            strTemp = strArr[14].Trim();
            drRowToAdd["DepartmentName"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[15].Trim();
            drRowToAdd["BankCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[16].Trim();
            drRowToAdd["BranchCode"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[17].Trim();
            drRowToAdd["AccountNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[18].Trim();
            drRowToAdd["EmailAddress"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[19].Trim();
            drRowToAdd["DateFromCL"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Date From Client is mandatory";
                blParseError = true;
                sbInputString.Append("Date From Client : " + strTemp + "*~*");
            }

            strTemp = strArr[20].Trim();
            drRowToAdd["DateToUW"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Date To UW is mandatory";
                blParseError = true;
                sbInputString.Append("Date To UW : " + strTemp + "*~*");
            }

            strTemp = strArr[21].Trim();
            drRowToAdd["AdjRepNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[22].Trim();
            drRowToAdd["AdjRepFromUWDate"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[23].Trim();
            drRowToAdd["AdjRepToCLDate"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[24].Trim();
            drRowToAdd["ReinstatementCardNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[25].Trim();
            drRowToAdd["CardDispatchDate"] = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            dtSourceTble.Rows.Add(drRowToAdd);
        }

        private void ImportToDatabaseWorkingTblMember_MA()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberWorking_MA";
            bulkCopy.WriteToServer(dtSourceTble);
        }

        private void DataTransferToRealTableMember_MA(string strRefNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_EB_TransferMemberRealTable_MA '" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
                refreshInputFolder();
            }
        }

        private void DeleteWorkingTableMemberLife_MA(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberLifeWorkingDelete '" + strRefNo + "'");
        }

        protected void ReadFileAndLoadDataTableMemberLife_MA(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateMemberLifeTbl_MA();
                    string strCurrLine = "";
                    string[] strArrCurrData = null;
                    int fieldCount = csvRdr.FieldCount;
                    csvRdr.ReadNextRecord();
                    csvRdr.MissingFieldAction = MissingFieldAction.ReturnNullValue;
                    while (csvRdr.ReadNextRecord())
                    {
                        strCurrLine = "";
                        for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                        {
                            strCurrLine += csvRdr[intLnp] + "|";
                        }
                        strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                        int ChkCurrLine = strCurrLine.Replace("|", "").Length;

                        strArrCurrData = strCurrLine.Replace("\r\n", " ").Split('|');
                        if (strArrCurrData != null && (strArrCurrData.Length == 16))
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableMemberLife(strArrCurrData, strArrCurrData[0].ToString());
                            }
                            catch
                            {
                                break;
                            }
                        }
                        intTotalNoOfRecords++;
                    }
                    csvRdr.Dispose();

                    DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                    DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                    intInValidRecCnt = drInvalidRows.Length;
                    intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                    intValidRecCnt = drValidRows.Length;
                    intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                    intTotalNoOfRecords = intInValidRecCnt + intValidRecCnt;

                    ImportToDatabaseWorkingTblMemberLife_MA();
                    DataTransferToRealTableMemberLife_MA(strBatchId);
                    string strBody = "Member Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    //SendEMail("Vessel Upload Status - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), strBody);
                    refreshInputFolder();

                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                ServiceUtility.WriteLog(ex.ToString());
            }
        }

        private void CreateMemberLifeTbl_MA()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("CertNo");
            dtSourceTble.Columns.Add("DType");
            dtSourceTble.Columns.Add("Name");
            dtSourceTble.Columns.Add("Sex");
            dtSourceTble.Columns.Add("BirthDate");
            dtSourceTble.Columns.Add("Class");
            dtSourceTble.Columns.Add("Salary");
            dtSourceTble.Columns.Add("SumInsured");
            dtSourceTble.Columns.Add("ADND");
            dtSourceTble.Columns.Add("ADND2");
            dtSourceTble.Columns.Add("TPD");
            dtSourceTble.Columns.Add("EGP");
            dtSourceTble.Columns.Add("EffectiveDate");
            dtSourceTble.Columns.Add("ExpiryDate");
            dtSourceTble.Columns.Add("Remarks");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
        }

        private void ImportToDatabaseWorkingTblMemberLife_MA()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "TM_MemberLifeWorking";
            bulkCopy.WriteToServer(dtSourceTble);
        }

        private void DataTransferToRealTableMemberLife_MA(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_TransferMemberLifeRealTable '" + strRefNo + "'");
        }

        #endregion

    }
}
