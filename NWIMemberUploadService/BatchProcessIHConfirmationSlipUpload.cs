using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using BusinessAccessLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using LumenWorks.Framework.IO.Csv;
using System.Configuration;
using DataAccessLayer;
using MemberUploadService;

namespace LawtonAsiaIHConfirmationUploadService
{
    public class BatchProcessIHConfirmationSlipUpload
    { 
        #region Attributes
        
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
        protected string sp = "";
        string strRtnDesc = "";

        protected string _strInitialFilePath = String.Empty;
        protected string _strEnrolledFilePath = String.Empty;
        protected string _strMassAdjustmentFilePath = String.Empty;

        clsEBMemberUpload objclsEBMemberUpload = new clsEBMemberUpload();
        EBMemberManager objEBMemberManager = new EBMemberManager();
        public string strFilepath = "", strExcelConn = "";
        public string strIhCorporatePolicyNo { get; set; }
        public string strUser { get; set; }

        #endregion
        public BatchProcessIHConfirmationSlipUpload()
        {

        }

        public void beginProcess()
        {
            EventLogs.Publish("Batch Process IH Confirmation Slip Service Started", System.Diagnostics.EventLogEntryType.Information);
            mstrFolderPath = ConfigurationSettingReader.FolderPath.ToString();

            int i = 0;
            int iCount = System.Configuration.ConfigurationManager.ConnectionStrings.Count;
            for (i = 1; i < iCount; i++)
            {
                mstrConnFolderName = System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                mstrConStr = System.Configuration.ConfigurationManager.ConnectionStrings["eProfessional_N"].ConnectionString;
                mstrSourceFilePath = ConfigurationSettingReader.CSVSourceFilePath.ToString();
                mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

                if (!string.IsNullOrEmpty(mstrConStr.Trim()))
                {
                    ReadLoadSourceFile();
                }
            }
            EventLogs.Publish("Batch Process IH Confirmation Slip Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        #region Initial IH Confirmation Slip Batch Upload
       
        private void ReadLoadSourceFile()
        {
            //System.Configuration.ConfigurationSettings.AppSettings["InitialFolderPath"];
            // ConfigurationManager.AppSettings["InitialFolderPath"]; 
            //ConfigurationSettingReader.InitialFolderPath.ToString();

            _strInitialFilePath = ConfigurationManager.AppSettings["IHConfirmationSliUploadPath"];

            if (!String.IsNullOrEmpty(_strInitialFilePath))
                mstrSourceFilePath =  _strInitialFilePath;

            //mstrSourceFilePath = "D:\\eProPlusOne\\Source_Code\\eProPlusOne\\TempUpload\\";
           

            string[] strFiles = Directory.GetFiles(mstrSourceFilePath);

            if (strFiles.Length > 0)
            {
                try 
                {
                    WriteLog("First Method ReadLoadSourceFile for Initial Upload :-" + mstrSourceFilePath);
                    WriteLog("File Process Started On " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    dtSourceTble = null;
                    strCurrFileName = strFiles[0];
                    strBatFileExt = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
                    strUploadType = strCurrFileName.Substring(strCurrFileName.LastIndexOf("\\"), 5).ToString().Trim().Replace("\\", "");
                    strRemarks = "";

                    DeleteWorkingTableIHConfirmationUpload(strBatchId);
                    ReadFileAndLoadDataTableIhCorPbatchUpload(strCurrFileName);

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
        protected void ReadFileAndLoadDataTableIhCorPbatchUpload(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                intApprovalRecCnt = 0;

                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    CreateIHCorporateBatchTbl();
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
                                addInputRowToTableIHConfirmationUpload(strArrCurrData, strArrCurrData[0].ToString());
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

                    ImportToDatabaseWorkingTblIHConfirmationSlipUpload();
                    DataTransferToRealTablePOlicy(strBatchId);
                    string strBody = "IH Confirmation Slip Upload Is Successfully.<br><br>";
                    strBody = strBody + "Process Date - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " <br>";
                    strBody = strBody + "Fail Records - " + intInValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Success Record - " + intValidRecCnt.ToString() + " <br>";
                    strBody = strBody + "Total Records - " + intTotalNoOfRecords.ToString() + " <br>";
                    //SendEMail("Reimbursement claim Upload Status - " + DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(), strBody);
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
        private void addInputRowToTableIHConfirmationUpload(string[] strArr, string Counter)
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

            drRowToAdd["Client"] = strTemp.ToString().Replace(",", ".");
            strTemp = strArr[1].Trim();
            drRowToAdd["InsuredName"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length == 0)
            {
                
                strTemp += " - Error -Insured Name is mandatory";
                blParseError = true;
                sbInputString.Append("Insured Name : " + strTemp + "*~*");
            }

            strTemp = strArr[2].Trim();
            drRowToAdd["SurName"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[3].Trim();
            drRowToAdd["Gender"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length > 0 &&(strTemp.ToUpper() != "MALE" || strTemp.ToUpper() != "FEMALE"))
            {
                
            }
            else
            {
                strTemp += " - Error -Gender is mandatory";
                blParseError = true;
                sbInputString.Append("Gender : " + strTemp + "*~*");   
            }
            strTemp = strArr[4].Trim();
            drRowToAdd["Nationality"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                
                strTemp += " - Error -Nationality is mandatory";
                blParseError = true;
                sbInputString.Append("Nationality : " + strTemp + "*~*");
            }
            
            strTemp = strArr[5].Trim();
            drRowToAdd["ResidentCountry"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Resident Country is mandatory";
                blParseError = true;
                sbInputString.Append("Resident Country : " + strTemp + "*~*");
            }
            
            strTemp = strArr[6].Trim();
            drRowToAdd["PIHCardNo"] = strTemp.ToString().Replace(",", ".");
            
            strTemp = strArr[7].Trim();
            drRowToAdd["Scheme"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Scheme is mandatory";
                blParseError = true;
                sbInputString.Append("Scheme : " + strTemp + "*~*");
            }
            
            strTemp = strArr[8].Trim();
            drRowToAdd["DOB"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Date Of Birth is mandatory";
                blParseError = true;
                sbInputString.Append("Date Of Birth : " + strTemp + "*~*");
            }
            
            strTemp = strArr[9].Trim();
            drRowToAdd["Program"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Program is mandatory";
                blParseError = true;
                sbInputString.Append("Program : " + strTemp + "*~*");
            }
            

            strTemp = strArr[10].Trim();
            drRowToAdd["PlanType"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Plan Type is mandatory";
                blParseError = true;
                sbInputString.Append("Plan Type : " + strTemp + "*~*");
            }
            
            strTemp = strArr[11].Trim();
            drRowToAdd["Deductible"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[12].Trim();
            drRowToAdd["Discount"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[13].Trim();
            drRowToAdd["StampDuty"] = strTemp.ToString().Replace(",", ".");

            strTemp = strArr[14].Trim();
            drRowToAdd["SBT"] = strTemp.ToString().Replace(",", ".");
            
            strTemp = strArr[15].Trim();
            drRowToAdd["Commission"] = strTemp.ToString().Replace(",", ".");

            strTemp = strIhCorporatePolicyNo;
            drRowToAdd["IHCorporatePolicyNo"] = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";

            strTemp = strUser;
            drRowToAdd["UserName"] = strTemp.ToString().Replace(",", ".");

            dtSourceTble.Rows.Add(drRowToAdd);

        }
       
        private void ImportToDatabaseWorkingTblIHConfirmationSlipUpload()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "Temp_IHConfirmationSlipUpload";
            bulkCopy.WriteToServer(dtSourceTble);
        }
       
        private void DataTransferToRealTablePOlicy(string strRefNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_Pol_IHConfirmationSlipUploadFromTempToReal'" + strRefNo + "'");
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                refreshInputFolder();
            }
        }
       
        private DataSet GetDSCombination(string _sp, string Code, string Name, string ConfirmationSlipNo)
        {
            DataAccess dataAccess = null;
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { Code, Name, ConfirmationSlipNo };
            return dataAccess.LoadDataSet(parameters, _sp, "ValidateCombination");
        }
        
        private void DeleteWorkingTableIHConfirmationUpload(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_IHConfirmationSlipWorkingDelete '" + strRefNo + "'");
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
        
        private void CreateIHCorporateBatchTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");

            dtSourceTble.Columns.Add("Client");
            dtSourceTble.Columns.Add("InsuredName");
            dtSourceTble.Columns.Add("SurName");
            dtSourceTble.Columns.Add("Gender");
            dtSourceTble.Columns.Add("Nationality");
            dtSourceTble.Columns.Add("ResidentCountry");
            dtSourceTble.Columns.Add("PIHCardNo");
            dtSourceTble.Columns.Add("Scheme");
            dtSourceTble.Columns.Add("DOB");
            dtSourceTble.Columns.Add("Program");
            dtSourceTble.Columns.Add("PlanType");
            dtSourceTble.Columns.Add("Deductible");
            dtSourceTble.Columns.Add("Discount");
            dtSourceTble.Columns.Add("StampDuty");
            dtSourceTble.Columns.Add("SBT");
            dtSourceTble.Columns.Add("Commission");
            dtSourceTble.Columns.Add("IHCorporatePolicyNo");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
            dtSourceTble.Columns.Add("UserName");

        }
        
        protected void WriteLog(string strLogMsg)
        {
          //  EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }
        #endregion

    }
}