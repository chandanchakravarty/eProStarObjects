using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using BusinessObjectLayer.FlexServices.FlexIRM;
using LumenWorks.Framework.IO.Csv;

namespace BusinessAccessLayer.FlexServices.FlexIRM
{
    public class FlexClaimCsvToIRM
    {
        string mstrConStr = "";
        string mstrSourceFilePath = "";
        string mstringLookUpInterval = "";
        ExportManager objExportMan = null;
        protected Int64 AttachId = 0;
        protected string strCurrFileName = "";
        protected DataTable dtSourceTble = null;
        FlexAttachementList objAttachList = null;
        FlexAttachementList objFlex = null;
        ExportManager objExpManager = null;
        StreamWriter swLog;
        protected string strFileName = "";
        protected string BatchRefId = "";

        public FlexClaimCsvToIRM()
        {
            getFilePath();
        }

        public void beginProcess(StreamWriter sw)
        {
            ExtractFilesDataBeforeProcess();
            swLog = sw;
            loadSourceFile();
        }

        private void loadSourceFile()
        {
            DataSet dsFiles = new DataSet();
            objExportMan = new ExportManager();
            dsFiles = objExportMan.getAttachmentListByStatus("CLM", "PEND");
            string searchPattern = "csirm*.*";
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            swLog.WriteLine("Outside for Pending file Search");

            if (dsFiles != null && dsFiles.Tables.Count > 0 && dsFiles.Tables["TM_FlexAttachment_List"].Rows.Count > 0)
            {
                int rowCount = dsFiles.Tables["TM_FlexAttachment_List"].Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    try
                    {
                        swLog.WriteLine("File Process Started for IRM Claim");
                        swLog.WriteLine(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                        dtSourceTble = null;
                        AttachId = Convert.ToInt64(dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_ID"]);
                        BatchRefId = Convert.ToString(dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["BatchReferenceID"]);
                        strCurrFileName = mstrSourceFilePath + dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_InternalFileName"].ToString();
                        strFileName = dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_InternalFileName"].ToString();
                        changeStatus("INPROC");
                        ReadFileAndLoadDataTable(strCurrFileName);
                        saveDebitNoteDetail(dtSourceTble);
                        updateBatchSummary();
                        swLog.WriteLine(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                        swLog.WriteLine("File Process completed");
                    }
                    catch (Exception ex)
                    {
                        swLog.WriteLine("Error:");
                        swLog.WriteLine("~~~~~~");
                        swLog.WriteLine(ex.Message);
                    }
                }

            }
            else
            {
                return;
            }
        }

        int intTotalNoOfRecords = 0;
        int intInValidRecCnt = 0;
        int intValidRecCnt = 0;

        protected void ReadFileAndLoadDataTable(string strFileName)
        {
            try
            {
                intTotalNoOfRecords = 0;
                intInValidRecCnt = 0;
                intValidRecCnt = 0;
                bool blFileInvalid = false;
                swLog.WriteLine("Parsing File");
                using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))
                {
                    createDataTbl();
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

                        strArrCurrData = strCurrLine.Split('|');
                        if (strArrCurrData == null)
                        {
                            blFileInvalid = true;
                            break;
                        }
                        addInputRowToTable(strArrCurrData);
                        intTotalNoOfRecords++;
                    }
                }
                if (blFileInvalid)
                {
                    swLog.WriteLine("InValid File Format");
                    //handleInvalidFileFormat();
                    return;
                }
                //dtSourceTble.Rows.RemoveAt(0);
                DataRow[] drInvalidRows = dtSourceTble.Select("ParseResult='INVALID'");
                DataRow[] drValidRows = dtSourceTble.Select("ParseResult='VALID'");
                intInValidRecCnt = drInvalidRows.Length;
                intInValidRecCnt = (intInValidRecCnt < 0) ? 0 : intInValidRecCnt;
                intValidRecCnt = drValidRows.Length;
                intValidRecCnt = (intValidRecCnt < 0) ? 0 : intValidRecCnt;
                //updateBatchSummary(strBatchId, intTotalNoOfRecords, intValidRecCnt, intInValidRecCnt, 26);
                //createDebitNote();
                //updateBatchSummary(strBatchId, intTotalNoOfRecords, intValidRecCnt, intInValidRecCnt, 24);
                swLog.WriteLine("Moving file to processed folder");
                //refreshInputFolder();
            }
            catch (Exception e)
            {
                swLog.WriteLine(e.Message);
                PublishToEventLog(e.Message, EventLogEntryType.Error);
            }
        }

        private void ExtractFilesDataBeforeProcess()
        {
            string searchPattern = "csirm*.*";
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            if (strFiles.Length > 0)
            {
                for (int k = 0; k < strFiles.Length; k++)
                {
                    int lastIndex = strFiles[k].ToString().LastIndexOf(@"\");
                    string FileName = strFiles[k].ToString().Substring(lastIndex + 1);
                    SaveToDB(FileName);
                    //MoveToEntryFolder(FileName,mstrSourceFilePath);
                }
            }
        }

        public void SaveToDB(string fileName)
        {
            objFlex = new FlexAttachementList();
            objFlex.AttachID = Convert.ToInt32("0");
            string InternalFileName = fileName.Substring(0, fileName.Length - 4) + System.DateTime.Now.ToString().Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";
            //objFlex.AttachInternalFileName = InternalFileName; //Guid.NewGuid().ToString();
            objFlex.AttachInternalFileName = fileName; //Guid.NewGuid().ToString();
            objFlex.AttachDisplayFileName = fileName; //+ ".csv"; //Convert.ToString(ViewState["AttachFor"]) + btnFileUpload.FileName;
            objFlex.AttachFileDesc = "";
            //objFlex.AttachFor = Convert.ToString(ViewState["AttachFor"]);
            objFlex.AttachFor = "CLM";
            objFlex.User = "System";
            objExpManager = new ExportManager();
            DataSet dsResult = new DataSet();
            dsResult = objExpManager.saveFlexUploadDetail(objFlex);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                //lblMessage.Text = dsResult.Tables[0].Rows[0]["Result"].ToString();
                //hidAttachId.Value = dsResult.Tables[0].Rows[0]["Attach_ID"].ToString();
            }
        }

        protected void handleInvalidFileFormat()
        {
            swLog.WriteLine("Moving file to invalid file folder");
            //updateBatchSummary(strBatchId, 0, 0, 0, 29);
            string strSource = strCurrFileName;
            string strNewFile = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\InvalidFileFormat\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            File.Move(strSource, strNewFile);
        }

        private void createDataTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("D/N Date");
            dtSourceTble.Columns.Add("D/N Prefix");
            dtSourceTble.Columns.Add("Invoice 2nd Prefix");
            dtSourceTble.Columns.Add("D/N No");
            //dtSourceTble.Columns.Add("Suffix");
            dtSourceTble.Columns.Add("Is New DN No.");
            dtSourceTble.Columns.Add("Currency Code");
            dtSourceTble.Columns.Add("Cedant Code");
            dtSourceTble.Columns.Add("Billed Amount");
            dtSourceTble.Columns.Add("Settled Amount");
            dtSourceTble.Columns.Add("Outstanding Amount");
            dtSourceTble.Columns.Add("Settlement Date");
            dtSourceTble.Columns.Add("Receipt No.");
            //dtSourceTble.Columns.Add("Split No.");
            dtSourceTble.Columns.Add("RI Code");
            dtSourceTble.Columns.Add("Billed Amount (RI)");
            dtSourceTble.Columns.Add("Settled Amount (RI)");
            dtSourceTble.Columns.Add("Outstanding Amount (RI)");
            dtSourceTble.Columns.Add("Settlement Date (RI)");
            dtSourceTble.Columns.Add("Receipt No. (RI)");
            dtSourceTble.Columns.Add("Settlement Seq");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
            dtSourceTble.Columns.Add("BatchReferenceID");
            dtSourceTble.Columns.Add("CaseRefNo");
        }

        protected void refreshInputFolder()
        {
            string strSource = strCurrFileName;
            string strDestPath = mstrSourceFilePath + "ProcessedFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            //string strNewFile = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ProcessedFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            string strNewFile = strDestPath + "\\" + strFileName;
            File.Move(strSource, strNewFile);
        }

        private void createDebitNote()
        {
            int intLnpCnt = 1;
            DataSet dsReturn = null;
            string strResultDesc = "";
            string strTemp = "";
            foreach (DataRow drCurrRow in dtSourceTble.Rows)
            {
                strTemp = drCurrRow["ParseMsg"].ToString();
                if (drCurrRow["ParseResult"].ToString().Equals("INVALID"))
                {
                    insertBatchDetail(intLnpCnt, strTemp, 28);
                }
                else
                {
                    dsReturn = DebitNoteProcess(drCurrRow);
                    if (dsReturn.Tables.Count > 0 && dsReturn.Tables[0].Rows.Count > 0)
                    {
                        strResultDesc = dsReturn.Tables[0].Rows[0]["ResultDesc"].ToString();
                        strTemp += strResultDesc;
                        if (dsReturn.Tables[0].Rows[0]["Result"].ToString().ToUpper().Equals("N"))
                        {
                            insertBatchDetail(intLnpCnt, strTemp, 28);
                            intInValidRecCnt++;
                            intValidRecCnt = (intValidRecCnt > 0) ? intValidRecCnt - 1 : 0;
                        }
                        else
                        {
                            insertBatchDetail(intLnpCnt, strTemp, 27);
                        }
                    }
                }
                swLog.WriteLine("Input row Processed and its result : " + strTemp);
                intLnpCnt++;
            }
        }

        private DataSet DebitNoteProcess(DataRow drCurrRow)
        {
            DataSet dsToReturn = new DataSet();

            return dsToReturn;
        }

        public bool CreateNewFolder(string pFolderName)
        {
            System.IO.DirectoryInfo ObjDirectory = new System.IO.DirectoryInfo(pFolderName);
            try
            {
                ObjDirectory.Create();
                return true;
            }
            catch { return false; }
        }

        private void insertBatchDetail(int strDetailId, string strParseMsg, int strParseStatus)
        {

        }

        private void changeStatus(string strStaus)
        {
            DataSet dsResult = new DataSet();
            objAttachList = new FlexAttachementList();
            objAttachList.AttachID = AttachId;
            objAttachList.AttachFor = "CLM";
            objAttachList.Status = strStaus;
            objExportMan = new ExportManager();
            dsResult = objExportMan.updateAttachementList(objAttachList);
        }

        private void updateBatchSummary()
        {
            DataSet dsResult = new DataSet();
            objAttachList = new FlexAttachementList();
            objAttachList.AttachID = AttachId;
            objAttachList.AttachFor = "CLM";
            //objAttachList.BatchReferenceID = strBatchId;
            //if (intTotalNoOfRecords > 0)
            //    intTotalNoOfRecords = intTotalNoOfRecords - 1;
            objAttachList.TotalNoOfRecords = intTotalNoOfRecords;
            objAttachList.SuccessfulRecords = intTotalNoOfRecords - intInValidRecCnt;
            objAttachList.FailedRecords = intInValidRecCnt;
            string status = string.Empty;
            if (intTotalNoOfRecords != intValidRecCnt && intTotalNoOfRecords > 0)
                status = "PCOMP";
            if (intTotalNoOfRecords == intValidRecCnt && intTotalNoOfRecords > 0)
                status = "COMP";
            if (intValidRecCnt == 0)
                status = "FAIL";
            //else
            //    status = "PCOMP";
            objAttachList.Status = status;
            objExportMan = new ExportManager();
            dsResult = objExportMan.updateAttachementList(objAttachList);
        }

        private void addInputRowToTable(string[] strArr)
        {
            bool blParseError = false;
            StringBuilder sbInputString = new StringBuilder();
            string strTemp = "";
            DataRow drRowToAdd = dtSourceTble.NewRow();

            string clientCode = string.Empty;
            string debitNoteNo = string.Empty;
            string coverNoteNo = string.Empty;
            string UwCode = string.Empty;   

            strTemp = strArr[0].Trim();
            drRowToAdd["D/N Date"] = strTemp;   

            strTemp = strArr[1].Trim();
            drRowToAdd["D/N Prefix"] = strTemp;
            debitNoteNo += strTemp;

            strTemp = strArr[2].Trim();
            drRowToAdd["Invoice 2nd Prefix"] = strTemp;
            debitNoteNo += strTemp;

            strTemp = strArr[3].Trim();
            drRowToAdd["D/N No"] = strTemp;
            debitNoteNo += strTemp;

            //strTemp = strArr[4].Trim();
            //drRowToAdd["Suffix"] = strTemp;
            //debitNoteNo += strTemp;

            strTemp = strArr[4].Trim();
            drRowToAdd["Is New DN No."] = strTemp;

            strTemp = strArr[5].Trim();
            drRowToAdd["Currency Code"] = strTemp;

            strTemp = strArr[6].Trim();
            drRowToAdd["Cedant Code"] = strTemp;

            strTemp = strArr[7].Trim();
            drRowToAdd["Billed Amount"] = strTemp;

            strTemp = strArr[8].Trim();
            drRowToAdd["Settled Amount"] = strTemp;

            strTemp = strArr[9].Trim();
            drRowToAdd["Outstanding Amount"] = strTemp;

            strTemp = strArr[10].Trim();
            drRowToAdd["Settlement Date"] = strTemp;

            strTemp = strArr[11].Trim();
            drRowToAdd["Receipt No."] = strTemp;

            //strTemp = strArr[13].Trim();
            //drRowToAdd["Split No."] = strTemp;

            strTemp = strArr[12].Trim();
            drRowToAdd["RI Code"] = strTemp;

            strTemp = strArr[13].Trim();
            drRowToAdd["Billed Amount (RI)"] = strTemp;

            strTemp = strArr[14].Trim();
            drRowToAdd["Settled Amount (RI)"] = strTemp;

            strTemp = strArr[15].Trim();
            drRowToAdd["Outstanding Amount (RI)"] = strTemp;

            strTemp = strArr[16].Trim();
            drRowToAdd["Settlement Date (RI)"] = strTemp;

            strTemp = strArr[17].Trim();
            drRowToAdd["Receipt No. (RI)"] = strTemp;

            strTemp = strArr[18].Trim();
            drRowToAdd["Settlement Seq"] = strTemp;

            drRowToAdd["ParseMsg"] = sbInputString.ToString();

            drRowToAdd["BatchReferenceID"] = BatchRefId.ToString();

            //Procedure to check Validity of Debit Note Detal
            DataTable dtDetail = new DataTable("TM_IRMFlex_INV_CheckRecord");
            dtDetail = isExisted(debitNoteNo);
            if (!blParseError)
            {
                if (dtDetail != null)
                {
                    if (dtDetail.Rows.Count > 0)
                    {
                        blParseError = false;
                        drRowToAdd["CaseRefNo"] = dtDetail.Rows[0]["CaseRefNo"].ToString();
                        //drRowToAdd["ClientRefNo"] = dtDetail.Rows[0]["ClientRefNo"].ToString();
                        //drRowToAdd["UWRefNo"] = dtDetail.Rows[0]["UWRefNo"].ToString();
                        if (string.IsNullOrEmpty(dtDetail.Rows[0]["CaseRefNo"].ToString()))
                        {
                            blParseError = true;
                            drRowToAdd["ParseMsg"] = "Invalid Invoice Number.";
                        }
                    }
                    else
                    {
                        blParseError = true;
                    }
                }
                else
                {
                    blParseError = true;
                    drRowToAdd["CaseRefNo"] = "";
                    //drRowToAdd["ClientRefNo"] = "";
                    //drRowToAdd["UWRefNo"] = "";
                    drRowToAdd["ParseMsg"] = "Invalid Invoice Number.";
                }
            }

            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";
            dtSourceTble.Rows.Add(drRowToAdd);
        }

        public void getFilePath()
        {
            DataSet dsPath = new DataSet();
            objExportMan = new ExportManager();
            dsPath = objExportMan.getPathDetail("IRMClaimFlexUpload");
            if (dsPath.Tables["Sys_Params"].Rows.Count > 0)
            {
                mstrSourceFilePath = dsPath.Tables["Sys_Params"].Rows[0]["KeyValue"].ToString();
            }
        }

        public void PublishToEventLog(string strMessage, EventLogEntryType messageType)
        {
            if (EventLog.SourceExists("DebitNoteBatchProcess"))
            {
                try
                {
                    EventLog.WriteEntry("DebitNoteBatchProcess", strMessage, System.Diagnostics.EventLogEntryType.Error);
                }
                catch { }
            }
            else
            {
                try
                {
                    EventLog.CreateEventSource("DebitNoteBatchProcess", "DebitNoteBatchProcessErrors");
                    EventLog.WriteEntry("DebitNoteBatchProcess", strMessage, EventLogEntryType.Error, 222, 1);
                }
                catch { }
            }
        }

        public DataTable isExisted(string DebitNoteNo)
        {
            DataSet dsResult = new DataSet();
            objExportMan = new ExportManager();
            dsResult = objExportMan.checkClaimDetail(DebitNoteNo);
            return dsResult.Tables["TM_IRMFlex_INV_CheckRecord"];
        }

        public bool isNumeric(string val)
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public void saveDebitNoteDetail(DataTable dtDebitNote)
        {
            try
            {
                string strexpress = "ParseResult='VALID'";
                DataTable dtValidRecords = dtDebitNote.Clone();
                DataRow[] drow = dtDebitNote.Select(strexpress);
                foreach (DataRow dr in drow)
                {
                    dtValidRecords.ImportRow(dr);
                }
                if (dtValidRecords.Rows.Count > 0)
                {

                    objExportMan = new ExportManager();
                    objExportMan.saveDebitNoteDetailforClaim(dtValidRecords);

                    //Creating New CSV File for success Records
                    DataSet ds = new DataSet();
                    dtValidRecords.Rows.InsertAt(addHeader(dtValidRecords), 0);
                    //dtValidRecords.Columns.Remove("CaseRefNo");
                    //dtValidRecords.Columns.Remove("ClientRefNo");
                    //dtValidRecords.Columns.Remove("UWRefNo");
                    //dtValidRecords.Columns.Remove("SettlementAmount(AR)");
                    //dtValidRecords.Columns.Remove("SettlementAmount(AP)");
                    //dtValidRecords.Columns.Remove("ParseResult");
                    //dtValidRecords.Columns.Remove("BatchReferenceID");
                    ds.Tables.Add(dtValidRecords);
                    makeCsvForValidRecords(ds);
                }

                //Creating New CSV File for Failure Records
                string strInValidexpress = "ParseResult='INVALID'";
                DataSet dsInvalid = new DataSet();
                DataTable dtInvalidRecord = dtDebitNote.Clone();
                DataRow[] dvrow = dtDebitNote.Select(strInValidexpress);
                foreach (DataRow dr in dvrow)
                {
                    dtInvalidRecord.ImportRow(dr);
                }
                dtInvalidRecord.Rows.InsertAt(addHeader(dtInvalidRecord), 0);
                //dtInvalidRecord.Columns.Remove("CaseRefNo");
                //dtInvalidRecord.Columns.Remove("ClientRefNo");
                //dtInvalidRecord.Columns.Remove("UWRefNo");
                //dtInvalidRecord.Columns.Remove("SettlementAmount(AR)");
                //dtInvalidRecord.Columns.Remove("SettlementAmount(AP)");
                //dtInvalidRecord.Columns.Remove("ParseResult");
                //dtInvalidRecord.Columns.Remove("BatchReferenceID");
                dsInvalid.Tables.Add(dtInvalidRecord);
                makeCsvForInValidRecords(dsInvalid);

                refreshInputFolder();
            }
            catch (Exception ex)
            {

            }
        }

        public DataRow addHeader(DataTable dtTable)
        {
            DataRow drHeader = dtTable.NewRow();
            drHeader[0] = "D/N Date";
            drHeader[1] = "D/N Prefix";
            drHeader[2] = "Invoice 2nd Prefix";
            drHeader[3] = "D/N No";
            drHeader[4] = "Is New DN No.";
            drHeader[5] = "Currency Code";
            drHeader[6] = "Cedant Code";
            drHeader[7] = "Billed Amount";
            drHeader[8] = "Settled Amount";
            drHeader[9] = "Outstanding Amount";
            drHeader[10] = "Settlement Date";
            drHeader[11] = "Receipt No.";
            drHeader[12] = "RI Code";
            drHeader[13] = "Billed Amount (RI)";
            drHeader[14] = "Settled Amount (RI)";
            drHeader[15] = "Outstanding Amount (RI)";
            drHeader[16] = "Settlement Date (RI)";
            drHeader[17] = "Receipt No. (RI)";
            drHeader[18] = "Settlement Seq";
            drHeader[19] = "ParseMsg";
            drHeader[20] = "ParseResult";
            drHeader[21] = "BatchReferenceID";
            return drHeader; ;
        }

        public void makeCsvForValidRecords(DataSet dsRecord)
        {

            GenerateCsvFile objCSv = new GenerateCsvFile();
            string strDestPath = mstrSourceFilePath + "SuccessFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            //string FilePath = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\SuccessFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            string FilePath = strDestPath + "\\" + strFileName;
            objCSv.exportToCSVfile(dsRecord, ",", "\n", FilePath);
        }

        public void makeCsvForInValidRecords(DataSet dsRecord)
        {

            GenerateCsvFile objCSv = new GenerateCsvFile();
            string strDestPath = mstrSourceFilePath + "ExceptionFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            //string FilePath = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ExceptionFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            string FilePath = strDestPath + "\\" + strFileName;
            objCSv.exportToCSVfile(dsRecord, ",", "\n", FilePath);
        }

    }
}