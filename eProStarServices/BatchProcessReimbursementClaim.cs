using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using DataAccessLayer;

namespace eProStarServices
{
    public class BatchProcessReimbursementClaim
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
        protected string sp = "";
        string strRtnDesc = "";

        protected string _strInitialFilePath = String.Empty;
        protected string _strEnrolledFilePath = String.Empty;
        protected string _strMassAdjustmentFilePath = String.Empty;

        //clsEBMemberUpload objclsEBMemberUpload = new clsEBMemberUpload();
        //EBMemberManager objEBMemberManager = new EBMemberManager();
        public string strFilepath = "", strExcelConn = "";

        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader=null;
        public BatchProcessReimbursementClaim(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }

        public void beginProcess()
        {
            EventLogs.Publish("Batch Process Reimbursement Claim Service Started", System.Diagnostics.EventLogEntryType.Information);
            mstrFolderPath = _ConfigReader.FolderPath;// ConfigurationSettingReader.FolderPath.ToString();
            int i = 0;
            //int iCount = System.Configuration.ConfigurationManager.ConnectionStrings.Count;
            //for (i = 1; i < iCount; i++)
            {
                //mstrConnFolderName = System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                mstrConStr = _ConfigReader.ConnString;// System.Configuration.ConfigurationManager.ConnectionStrings["eProfessional_N"].ConnectionString;
                mstrSourceFilePath = _ConfigReader.CSVSourceFilePath;// ConfigurationSettingReader.CSVSourceFilePath.ToString();
                mstrSourceFilePath = mstrFolderPath; // +"\\" + mstrSourceFilePath;

                if (!string.IsNullOrEmpty(mstrConStr.Trim()))
                {
                    ReadLoadSourceFile();
                }
            }
            EventLogs.Publish("Batch Process Reimbursement Claim Service Completed", System.Diagnostics.EventLogEntryType.Information);
        }

        #region Initial Reimbursement Claim Batch Upload

        private void ReadLoadSourceFile()
        {
            //System.Configuration.ConfigurationSettings.AppSettings["InitialFolderPath"];
            // ConfigurationManager.AppSettings["InitialFolderPath"]; 
            //ConfigurationSettingReader.InitialFolderPath.ToString();

            _strInitialFilePath = _ConfigReader.ReClaimFolderPath; // ConfigurationManager.AppSettings["ReClaimFolderPath"];

            if (!String.IsNullOrEmpty(_strInitialFilePath))
                mstrSourceFilePath = mstrSourceFilePath + "\\" + _strInitialFilePath;

            // mstrSourceFilePath = "D:\\eProPlusOne\\Source_Code\\eProPlusOne\\TempUpload\\";
            // mstrSourceFilePath ="D:\\Sachin\\eProfessional_RI\\eProfessional_N\\InitialUpload\\ReClaim" ;

            if (!Directory.Exists(mstrSourceFilePath))
                Directory.CreateDirectory(mstrSourceFilePath);
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
                    DeleteWorkingTableMember(strBatchId);
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
                        if (strArrCurrData != null && (strArrCurrData.Length == 10))
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
                    string strBody = "EB Claim Upload Is Successfully.<br><br>";
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
        private void addInputRowToTableMember(string[] strArr, string Counter)
        {
            bool blParseError = false;
            blDuplicate = false;
            StringBuilder sbInputString = new StringBuilder();
            string strTemp = "";
            string strLocalTemp = string.Empty;
            string strConfirmationSlipNo = "";
            string strMemberCode = "";
            string strMemberName = "";
            string StrChkValidRecord = "";

            sbInputString.Append("");
            DataRow drRowToAdd = dtSourceTble.NewRow();
            drRowToAdd["SrNo"] = intSrNo.ToString().Trim();
            drRowToAdd["RefNo"] = strBatchId.ToString().Trim();

            strTemp = strArr[0].Trim();

            strMemberCode = strTemp.ToString().Replace(",", ".");

            drRowToAdd["MemberCode"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                //drRowToAdd["PolicyNo"] = "<td bgcolor=yellow>" + drRowToAdd["PolicyNo"] + "</td>";
                strTemp += " - Error -Member Code is mandatory";
                blParseError = true;
                sbInputString.Append("Member Code : " + strTemp + "*~*");
            }

            strTemp = strArr[1].Trim();

            strMemberName = strTemp.ToString().Replace(",", ".");

            drRowToAdd["MemberName"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Member Name is mandatory";
                blParseError = true;
                sbInputString.Append("Member Name : " + strTemp + "*~*");
            }
            strTemp = strArr[2].Trim();

            strConfirmationSlipNo = strTemp.ToString().Replace(",", ".");

            drRowToAdd["ConfirmationSlipNo"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -ConfirmationSlipNo is mandatory";
                blParseError = true;
                sbInputString.Append("Confirmation Slip No : " + strTemp + "*~*");
            }
            StrChkValidRecord = ValidateMemberCodeNameConfirmationSlipNo(strMemberCode, strMemberName, strConfirmationSlipNo);
            if (StrChkValidRecord != "Y")
            {
                strTemp += " - Error -Invalid Combination of MemberCode and Member Name and valid Confirmation Slip";
                blParseError = true;
                sbInputString.Append("Invalid Combination : " + strTemp + "*~*");
            }
            //else
            //{
            //    strTemp += " - Error -Invalid Combination of MemberCode and Member Name and valid Confirmation Slip";
            //    blParseError = true;
            //    sbInputString.Append("Invalid Combination : " + strTemp + "*~*");
            //}

            strTemp = strArr[3].Trim();
            drRowToAdd["ReceiptDate"] = strLocalTemp = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Receipt Date is mandatory";
                blParseError = true;
                sbInputString.Append("Receipt Date : " + strTemp + "*~*");
            }
            strTemp = strArr[4].Trim();
            drRowToAdd["ClaimType"] = strTemp.ToString().Replace(",", ".");

            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Claim Type is mandatory";
                blParseError = true;
                sbInputString.Append("Claim Type : " + strTemp + "*~*");
            }
            if (strTemp.Trim().Length > 0 && (strTemp.ToUpper().Trim() == "MEDICAL" || strTemp.ToUpper().Trim() == "LIFE" || strTemp.ToUpper().Trim() == "TPD" || strTemp.ToUpper().Trim() == "ADD"))
            {
                //strTemp += " - Error -Claim Type is out Of Scope";
                //    blParseError = true;
                //    sbInputString.Append("Claim Type : " + strTemp + "*~*");
            }
            else
            {
                strTemp += " - Error -Claim Type is out Of Scope";
                blParseError = true;
                sbInputString.Append("Claim Type : " + strTemp + "*~*");

            }

            strTemp = strArr[5].Trim();
            drRowToAdd["DiseaseCause"] = strTemp.ToString().Replace(",", ".");
            //if (strTemp.Trim().Length == 0)
            //{
            //    strTemp += " - Error -Disease\Cause is mandatory";
            //    blParseError = true;
            //    sbInputString.Append("Disease\Cause : " + strTemp + "*~*");
            //}
            strTemp = strArr[6].Trim();
            drRowToAdd["Hospital"] = strTemp.ToString().Replace(",", ".");
            //if (strTemp.Trim().Length == 0)
            //{
            //    strTemp += " - Error -Hospital is mandatory";
            //    blParseError = true;
            //    sbInputString.Append("Hospital : " + strTemp + "*~*");
            //}
            strTemp = strArr[7].Trim();
            drRowToAdd["ClaimAmount_bht"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Claim Amount is mandatory";
                blParseError = true;
                sbInputString.Append("Claim Amount : " + strTemp + "*~*");
            }

            strTemp = strArr[8].Trim();
            drRowToAdd["NotifyDate"] = strTemp.ToString().Replace(",", ".");
            if (strTemp.Trim().Length == 0)
            {
                strTemp += " - Error -Notify Date is mandatory.";
                blParseError = true;
                sbInputString.Append("Notify Date : " + strTemp + "*~*");
            }

            strTemp = strArr[9].Trim();
            drRowToAdd["PaidAmount"] = strTemp.ToString().Replace(",", ".");

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
            bulkCopy.DestinationTableName = "Temp_EB_ClaimRegistration";
            bulkCopy.WriteToServer(dtSourceTble);
        }
        private void ImportToDatabaseWorkingTblMemberLife()
        {
            bulkCopy = new SqlBulkCopy(mstrConStr, SqlBulkCopyOptions.TableLock);
            bulkCopy.DestinationTableName = "Temp_EB_ClaimRegistration";
            bulkCopy.WriteToServer(dtSourceTble);
        }
        private void DataTransferToRealTableMember(string strRefNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetDataSet("P_ReimbursementClaimTempToRealTable'" + strRefNo + "'");
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
            ds = GetDataSet("P_ReimbursementClaimTempToRealTable '" + strRefNo + "'");
        }
        private DataSet GetDSCombination(string _sp, string Code, string Name, string ConfirmationSlipNo)
        {
            DataAccess dataAccess = null;
            dataAccess = new DataAccess(_ConfigReader.ConnString, "service");
            Object[] parameters = new Object[3] { Code, Name, ConfirmationSlipNo };
            return dataAccess.LoadDataSet(parameters, _sp, "ValidateCombination");
        }

        private void DeleteWorkingTableMember(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_ReimbursementClaimWorkingDelete '" + strRefNo + "'");
        }
        private void DeleteWorkingTableMemberLife(string strRefNo)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet("P_EB_MemberLifeWorkingDelete '" + strRefNo + "'");
        }
        //private void ValidateMemberCode(string MemberCode)
        //{
        //    //DataSet ds = new DataSet();
        //    //ds = GetDataSet("ValidateMemberCode_Sp '" + MemberCode + "'");
        //}

        //private void ValidateConfirmationSlipNo(string ConfirmationSlipNo)
        //{
        //    //DataSet ds = new DataSet();
        //    //ds = GetDataSet("ValidateMemberConfirmationSlipEB_Sp'" + ConfirmationSlipNo + "'");

        //}
        private string ValidateMemberCodeNameConfirmationSlipNo(string Code, string Name, string ConfirmationSlipNo)
        {
            DataSet ds = new DataSet();
            strRtnDesc = "";
            sp = "ValidateMember_Name_Code_ConfirmationSlip_Sp";
            ds = GetDSCombination(sp, Code, Name, ConfirmationSlipNo);
            return strRtnDesc = ds.Tables[0].Rows[0][0].ToString();
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

            dtSourceTble.Columns.Add("MemberCode");
            dtSourceTble.Columns.Add("MemberName");
            dtSourceTble.Columns.Add("ConfirmationSlipNo");
            dtSourceTble.Columns.Add("ReceiptDate");
            dtSourceTble.Columns.Add("ClaimType");
            dtSourceTble.Columns.Add("DiseaseCause");
            dtSourceTble.Columns.Add("Hospital");
            dtSourceTble.Columns.Add("ClaimAmount_bht");
            dtSourceTble.Columns.Add("NotifyDate");
            dtSourceTble.Columns.Add("PaidAmount");

            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");

        }
        private void CreateMemberLifeTbl()
        {
            dtSourceTble = new DataTable();

            dtSourceTble.Columns.Add("SrNo");
            dtSourceTble.Columns.Add("RefNo");

            dtSourceTble.Columns.Add("MemberCode");
            dtSourceTble.Columns.Add("MemberName");
            dtSourceTble.Columns.Add("ConfirmationSlipNo");
            dtSourceTble.Columns.Add("ReceiptDate");
            dtSourceTble.Columns.Add("ClaimType");
            dtSourceTble.Columns.Add("DiseaseCause");
            dtSourceTble.Columns.Add("Hospital");
            dtSourceTble.Columns.Add("ClaimAmount_bht");
            dtSourceTble.Columns.Add("NotifyDate");
            dtSourceTble.Columns.Add("PaidAmount");

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
