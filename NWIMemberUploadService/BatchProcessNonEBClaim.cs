using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using BusinessAccessLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using LumenWorks.Framework.IO.Csv;

namespace MemberUploadService
{
    public class BatchProcessNonEBClaim
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

        clsEBMemberUpload objclsEBMemberUpload = new clsEBMemberUpload();
        EBMemberManager objEBMemberManager = new EBMemberManager();
        public string strFilepath = "", strExcelConn = "";

        public BatchProcessNonEBClaim()
        {

        }

        public void beginProcess()
        {
            EventLogs.Publish("Non EB Claim Service Started", System.Diagnostics.EventLogEntryType.Information);
            mstrFolderPath = ConfigurationSettingReader.FolderPath.ToString();
            int i = 0;
            int iCount = System.Configuration.ConfigurationManager.ConnectionStrings.Count;
            for (i = 1; i < iCount; i++)
            {
                mstrConnFolderName = System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                mstrConStr = System.Configuration.ConfigurationManager.ConnectionStrings[i].ConnectionString;
                mstrSourceFilePath = ConfigurationSettingReader.CSVSourceFilePath.ToString();
                mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

                if (!string.IsNullOrEmpty(mstrConStr.Trim()))
                {
                    ReadLoadSourceFile();
                }
            }
            EventLogs.Publish("Non EB Claim Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        #region Initial Member Batch Upload
        private void ReadLoadSourceFile()
        {
            _strInitialFilePath = ConfigurationSettingReader.NonEBClaimFolderPath.ToString();
            if (!String.IsNullOrEmpty(_strInitialFilePath))
                mstrSourceFilePath = mstrSourceFilePath + "\\" + _strInitialFilePath;

            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);

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
                    strRemarks = "";
                    DeleteWorkingTableClaim(strBatchId);
                    ReadFileAndLoadDataTableMember(strCurrFileName);

                    WriteLog(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    WriteLog("File Process completed");
                }
                catch (Exception ex)
                {
                    WriteLog("Error:");
                    WriteLog("~~~~~~");
                    WriteLog(ex.Message);
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
                    CreateClaimTbl();
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
                        if (strArrCurrData != null && (strArrCurrData.Length == 22))
                        {
                            try
                            {
                                intSrNo = intSrNo + 1;
                                addInputRowToTableClaim(strArrCurrData, strArrCurrData[0].ToString());
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
                    string strBody = "EB Claim Upload Is Successfully.<br><br>";
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
            }
        }
        private string GenerateTableDate(DataRow row, string strFieldName)
        {
            if (row[strFieldName].ToString().Trim().Contains("~*Error*~") || strFieldName.ToUpper() == "REMARKS")
                return "<td bgcolor=Orange>" + row[strFieldName].ToString().Trim().Replace("~*Error*~", "") + "</td>";
            else
                return "<td>" + row[strFieldName].ToString().Trim() + "</td>";
        }
        private void addInputRowToTableClaim(string[] strArr, string Counter)
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
            drRowToAdd["DOL"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[1].Trim();
            drRowToAdd["DON"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[2].Trim();
            drRowToAdd["ConfirmationSlipNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -Confirmation Slip No is mandatory";
                blParseError = true;
                sbInputString.Append("ConfirmationSlipNo : " + strTemp + "*~*");
            }

            strTemp = strArr[3].Trim();
            drRowToAdd["Insured"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[4].Trim();
            drRowToAdd["TypeofInsurance"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -Type of Insurance is mandatory";
                blParseError = true;
                sbInputString.Append("TypeofInsurance : " + strTemp + "*~*");
            }

            strTemp = strArr[5].Trim();
            drRowToAdd["LossDetails"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[6].Trim();
            drRowToAdd["Insurer"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[7].Trim();
            drRowToAdd["Percent_Sahre"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[8].Trim();
            drRowToAdd["PolicyNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[9].Trim();
            drRowToAdd["POI_From"] = strTemp.ToString().Replace(",", ".");
           

            strTemp = strArr[10].Trim();
            drRowToAdd["POI_To"] = strTemp.ToString().Replace(",", ".");            

            strTemp = strArr[11].Trim();
            drRowToAdd["LossType"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[12].Trim();
            drRowToAdd["LossNature"] = strTemp.ToString().Replace(",", ".");            

            strTemp = strArr[13].Trim();
            drRowToAdd["Reserve"] = strTemp.ToString().Replace(",", ".");            

            strTemp = strArr[14].Trim();
            drRowToAdd["Recovery_Amt"] = strTemp.ToString().Replace(",", ".");            

            strTemp = strArr[15].Trim();
            drRowToAdd["Paid_Amt"] = strTemp.ToString().Replace(",", ".");            

            strTemp = strArr[16].Trim();
            drRowToAdd["Status"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[17].Trim();
            drRowToAdd["Status_Detail"] = strTemp.ToString().Replace(",", ".");
            
            strTemp = strArr[18].Trim();
            drRowToAdd["Status_Date"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[19].Trim();
            drRowToAdd["Surveyor"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[20].Trim();
            drRowToAdd["BoxNo"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[21].Trim();
            drRowToAdd["Remarks"] = strTemp.ToString().Replace(",", ".");            
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
            bulkCopy.DestinationTableName = "Temp_ClaimRegistration";
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
                ds = GetDataSet("P_TransferClaimRealTable '" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                refreshInputFolder();
            }
        }
        private void DataTransferToRealTableMemberLife(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_TransferMemberLifeRealTable '" + strRefNo + "'");
        }
        private void DeleteWorkingTableClaim(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_ClaimWorkingDelete '" + strRefNo + "'");
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
        private void CreateClaimTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");
            dtSourceTble.Columns.Add("DOL");
            dtSourceTble.Columns.Add("DON");
            dtSourceTble.Columns.Add("ConfirmationSlipNo");            
            dtSourceTble.Columns.Add("Insured");
            dtSourceTble.Columns.Add("TypeofInsurance");
            dtSourceTble.Columns.Add("LossDetails");
            dtSourceTble.Columns.Add("Insurer");
            dtSourceTble.Columns.Add("Percent_Sahre");
            dtSourceTble.Columns.Add("PolicyNo");
            dtSourceTble.Columns.Add("POI_From");
            dtSourceTble.Columns.Add("POI_To");
            dtSourceTble.Columns.Add("LossType");
            dtSourceTble.Columns.Add("LossNature");
            dtSourceTble.Columns.Add("Reserve");
            dtSourceTble.Columns.Add("Recovery_Amt");
            dtSourceTble.Columns.Add("Paid_Amt");
            dtSourceTble.Columns.Add("Status");
            dtSourceTble.Columns.Add("Status_Detail");
            dtSourceTble.Columns.Add("Status_Date");
            dtSourceTble.Columns.Add("Surveyor");
            dtSourceTble.Columns.Add("BoxNo");            
            dtSourceTble.Columns.Add("Remarks");
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

    }
}
