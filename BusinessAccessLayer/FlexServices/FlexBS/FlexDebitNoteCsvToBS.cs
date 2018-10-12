using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using BusinessAccessLayer.Common;
using BusinessObjectLayer.FlexServices.FlexBS;
using LumenWorks.Framework.IO.Csv;
//using Microsoft.Office.Interop.Excel;

using Utility;

namespace BusinessAccessLayer.FlexServices.FlexBS
{
    public class FlexDebitNoteCsvToBS
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
        protected string BatchRefId="";
        public FlexDebitNoteCsvToBS()
        {
            //
            // TODO: Add constructor logic here
            //
          
            getFilePath();
        }
        public void beginProcess(StreamWriter sw)
        {
            DeleteSpecificRowsFromCSV("TOTAL");
            deleteFixRowsFromExcelFile();
            ExtractFilesDataBeforeProcess();
            swLog = sw;
            loadSourceFile();
        }

        public void DeleteSpecificRowsFromCSV(string Pstring)
        {
            string searchPattern = "nwh*.*";
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            if (strFiles.Length > 0)
            {
                for (int k = 0; k < strFiles.Length; k++)
                {
                    int lastIndex = strFiles[k].ToString().LastIndexOf(@"\");
                    string FileName = strFiles[k].ToString().Substring(lastIndex + 1);

                    string FullFilePath = mstrSourceFilePath + FileName;

                    string fileValues = File.ReadAllText(FullFilePath);
                    StreamWriter fileWriter = new StreamWriter(FullFilePath, false);

                    int index = fileValues.IndexOf(Pstring, StringComparison.CurrentCulture);
                    fileValues = fileValues.Substring(0, index-1);

                    fileWriter.Write(fileValues);
                    fileWriter.Close();
                }
            }
        }  

        public void deleteFixRowsFromExcelFile()
        {
            string searchPattern = "nwh*.*";
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            if (strFiles.Length > 0)
            {
                for (int k = 0; k < strFiles.Length; k++)
                {
                    int lastIndex = strFiles[k].ToString().LastIndexOf(@"\");
                    string FileName = strFiles[k].ToString().Substring(lastIndex + 1);

                    string FullFilePath = mstrSourceFilePath + FileName;
                    StreamReader fileReader = new StreamReader(FullFilePath);

                    CSVReader reader = new CSVReader(fileReader.BaseStream);
                    DataTable dtExcel = new DataTable();

                    foreach (object columnName_loopVariable in getColumns(false, FullFilePath))
                    {
                        dtExcel.Columns.Add(columnName_loopVariable.ToString());
                    }

                    string[] data;
                    while ((data = reader.GetCSVLine()) != null)
                    {
                        if(data.Length != 0)
                            dtExcel.Rows.Add(data);
                    }
                    fileReader.Close();

                    if (dtExcel != null && dtExcel.Rows.Count != 0)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            DataRow dtRowDelete = dtExcel.Rows[0];
                            dtRowDelete.Delete();
                        }
                        dtExcel.AcceptChanges();
                    }

                    File.Delete(FullFilePath);

                    using (StreamWriter writer = new StreamWriter(FullFilePath))
                    {
                        reader.WriteDataTableToCSV(dtExcel, writer, false);
                    }

                }
            }
        }

        private string FileName;
        public string[] getColumns(bool ColumnNames, string FullFilePath)
        {
            FileName = FullFilePath;             
            try
            {
                StreamReader fileReader = new StreamReader(FileName);
                int k = 0;
                string line = string.Empty;
                while (k < 6)
                {
                    line = fileReader.ReadLine();
                    k++;
                }
                //string line = fileReader.ReadToEnd();
                fileReader.Close();
                char[] sep = {','};
                string[] Columns = line.Split(sep,StringSplitOptions.None);
                if (ColumnNames)
                {
                    return Columns;
                }
                int i = 1;
                int c = 0;
                string[] columnsNames = new string[Columns.Length];
                foreach (string column in Columns)
                {
                    columnsNames[c] = "column" + i;
                    i += 1;
                    c += 1;
                }
                return columnsNames;
            }
            catch (Exception ex)
            {
                //log to file    
            }
            return null;
        }

        public DataTable ReturnData(bool ColumnNames, string FullFilePath)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (object columnName_loopVariable in getColumns(ColumnNames, FullFilePath))
                {
                    dt.Columns.Add(columnName_loopVariable.ToString());
                }
                StreamReader fileReader = new StreamReader(FileName);
                if (ColumnNames)
                {
                    fileReader.ReadLine();
                }
                string line = fileReader.ReadLine();
                while ((line != null))
                {
                    //line = line.Replace(Strings.Chr(34), "");
                    if (line.Split(',').GetLength(0) == dt.Columns.Count)
                    {
                        dt.Rows.Add(line.Split(','));
                        line = fileReader.ReadLine();
                    }
                    else
                    {
                        line = fileReader.ReadLine();
                    }
                }
                fileReader.Close();
                return dt;
            }
            catch (Exception ex)
            {
                //log to file
            }
            return null;
        }

        protected DataTable RetrieveData(string strConn, string FileName)
        {
            DataTable dtExcel = new DataTable();
            DataTable dtExcelSchemaTable = new DataTable();
            strConn = strConn.Replace(".csv", ".xlsx");

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                //conn.Open();
                //dtExcelSchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //ListItemCollection items = new ListItemCollection();

                ////string strSheetname = dtExcel.Rows[0]["TABLE_NAME"].ToString();
                //for (int rowIndex = 0; rowIndex < dtExcelSchemaTable.Rows.Count; rowIndex++)
                //{
                //    string excelSheetName;
                //    string lastCharacter = "";

                //    excelSheetName = dtExcelSchemaTable.Rows[rowIndex]["TABLE_NAME"].ToString();
                //    excelSheetName = excelSheetName.Replace("'", "");
                //    lastCharacter = excelSheetName.Substring(excelSheetName.Length - 1, 1);
                //    if (lastCharacter == "$")
                //    {
                //        items.Add(dtExcelSchemaTable.Rows[rowIndex]["TABLE_NAME"].ToString());
                //    }
                //}
                //if (items.Count > 1)
                //    return null;

                string sName;
                string query;

                sName = FileName.Replace(".csv", "").Replace(".xlsx", "").ToString();
                sName = sName.Replace("'", "");
                sName = sName.Replace("$", "");

                query = "";
                query = String.Format("select * from [{0}$]", sName);

                // Initialize an OleDbDataAdapter object. 


                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);

                // Fill the DataTable with data from the Excel spreadsheet. 
                da.Fill(dtExcel);

                //DataTable dp = dataset.Tables["Sheet1$"];
                for (int k = 0; k < 5; k++)
                {
                    DataRow dtRowDelete = dtExcel.Rows[k];
                    dtRowDelete.Delete();
                }
                dtExcel.AcceptChanges();
                da.Update(dtExcel);
                
                
                //dataset.Tables["" + FileName.Replace(".csv", "") + "$"].AcceptChanges();

                //adapter.Update(dataset.Tables["" + FileName.Replace(".csv", "") + "$"]);
            }

            return dtExcel;
        } 

        //private void deleteFixRowsFromExcelFile_WithExcelAtServer()
        //{
        //    string searchPattern = "nwh*.*";
        //    string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);
        //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        //    if (strFiles.Length > 0)
        //    {
        //        for (int k = 0; k < strFiles.Length; k++)
        //        {
        //            int lastIndex = strFiles[k].ToString().LastIndexOf(@"\");
        //            string FileName = strFiles[k].ToString().Substring(lastIndex + 1);
        //            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(mstrSourceFilePath + FileName, 1, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, null, false,false,false);

        //            try
        //            {
        //                Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
        //                foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
        //                {
        //                    Microsoft.Office.Interop.Excel.Range range = work.get_Range("A1", "A5"); // delete only top 5 rows (hard coded - as confirmed by the client)
        //                    Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow; 
        //                    entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
        //                }
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            finally
        //            {
        //                excelWorkbook.Save();
        //                excelWorkbook.Close(false, mstrSourceFilePath + FileName, false);
        //                excelApp.AlertBeforeOverwriting = false;
        //                excelApp.Quit();
        //            }
        //        }
        //    }
        //}

        private void ExtractFilesDataBeforeProcess()
        {
            string searchPattern = "nwh*.*";
            string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            if (strFiles.Length > 0)
            {
                for (int k = 0; k < strFiles.Length; k++)
                {
                    int lastIndex = strFiles[k].ToString().LastIndexOf(@"\");
                    string FileName = strFiles[k].ToString().Substring(lastIndex+1);
                    SaveToDB(FileName);
                    //MoveToEntryFolder(FileName,mstrSourceFilePath);
                }
            }
        }

        protected void MoveToEntryFolder(string strCurrFileName, string mstrSourceFilePath)
        {
            string strSource = strCurrFileName;
            string strDestPath = mstrSourceFilePath + "EntriedFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            string strNewFile = strDestPath + "\\" + strFileName;
            File.Move(strSource, strNewFile);
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
            objFlex.AttachFor = "DBN";
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

        private void loadSourceFile()
        {
            DataSet dsFiles = new DataSet();
            objExportMan = new ExportManager();
            dsFiles = objExportMan.getAttachmentListByStatus("DBN","PEND");
            //string searchPattern = "nwh*.*";
            //string[] strFiles = Directory.GetFiles(mstrSourceFilePath, searchPattern, SearchOption.TopDirectoryOnly);

            //if (strFiles.Length > 0)
            if (dsFiles.Tables["TM_FlexAttachment_List"].Rows.Count > 0)
            {
                int rowCount = dsFiles.Tables["TM_FlexAttachment_List"].Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {

                    try
                    {
                        swLog.WriteLine("File Process Started");
                        swLog.WriteLine(DateTime.Now.Date.ToString("dd/MM/yyyy") + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                       
                        dtSourceTble = null;
                        AttachId = Convert.ToInt64(dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_ID"]);
                        BatchRefId = Convert.ToString(dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["BatchReferenceID"]);
                        //strCurrFileName = mstrSourceFilePath + dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_InternalFileName"].ToString();
                        //strFileName = dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_InternalFileName"].ToString();
                        strCurrFileName = mstrSourceFilePath + dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_DisplayFileName"].ToString();
                        strFileName = dsFiles.Tables["TM_FlexAttachment_List"].Rows[i]["Attach_DisplayFileName"].ToString();

                        //strBatchId = strCurrFileName.Substring(strCurrFileName.LastIndexOf(".") + 1);
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


                string FullFilePath = mstrSourceFilePath + FileName;
                StreamReader fileReader = new StreamReader(strFileName);

                //using (CsvReader csvRdr = new CsvReader(new StreamReader(strFileName), false))

                CSVReader reader = new CSVReader(fileReader.BaseStream);
                //{
                    createDataTbl();
                    //string strCurrLine = "";
                    string[] strArrCurrData = null;
                    //int fieldCount = csvRdr.FieldCount;

                    string[] data;
                    while ((data = reader.GetCSVLine()) != null)
                    {
                        addInputRowToTable(data);
                        intTotalNoOfRecords++;
                    }
                    fileReader.Close();

                    //while (csvRdr.ReadNextRecord())
                    //{
                    //    //csvRdr.MoveTo(4);
                    //    int fieldCount = csvRdr.FieldCount;

                    //    strCurrLine = "";
                    //    for (int intLnp = 0; intLnp < fieldCount; intLnp++)
                    //    {
                    //        strCurrLine += csvRdr[intLnp].Replace('"',' ').Trim() + "|";
                    //    }
                    //    strCurrLine = strCurrLine.Substring(0, strCurrLine.LastIndexOf("|"));

                    //    strArrCurrData = strCurrLine.Split('|');
                    //    //strArrCurrData = strCurrLine.Split(',');

                    //    if (strArrCurrData == null)// || strArrCurrData.Length != 10)
                    //    {
                    //        blFileInvalid = true;
                    //        break;
                    //    }
                    //    addInputRowToTable(strArrCurrData);
                    //    intTotalNoOfRecords++;
                    //}

                //}
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
        protected void handleInvalidFileFormat()
        {
            swLog.WriteLine("Moving file to invalid file folder");
            
            //updateBatchSummary(strBatchId, 0, 0, 0, 29);
            string strSource = strCurrFileName;
            string strNewFile = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\InvalidFileFormat\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            File.Move(strSource, strNewFile);
        }

        /// <summary>
        /// To Move Processed Files into ProcessedFiles Directory.
        /// Directory should be exist at specified path.
        /// </summary>
        protected void refreshInputFolder()
        {
            string strSource = strCurrFileName;
            string strDestPath=mstrSourceFilePath+"ProcessedFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            //string strNewFile = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\ProcessedFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            string strNewFile = strDestPath +"\\"+ strFileName;
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
            objAttachList.AttachFor = "DBN";
            objAttachList.Status = strStaus;
            objExportMan = new ExportManager();
            dsResult = objExportMan.updateAttachementList(objAttachList);
        }
        private void updateBatchSummary()
        {
            DataSet dsResult = new DataSet();
            objAttachList = new FlexAttachementList();
            objAttachList.AttachID = AttachId;
            objAttachList.AttachFor="DBN";
            //objAttachList.BatchReferenceID = strBatchId;

            //if (intTotalNoOfRecords >0)
            //  intTotalNoOfRecords = intTotalNoOfRecords - 1;

            objAttachList.TotalNoOfRecords = intTotalNoOfRecords;
            objAttachList.SuccessfulRecords = intTotalNoOfRecords - intInValidRecCnt;
            objAttachList.FailedRecords = intInValidRecCnt;
            string status = string.Empty;
            if (intTotalNoOfRecords == intValidRecCnt && intTotalNoOfRecords > 0)
                status = "COMP";
             if (intValidRecCnt ==0)
                 status = "FAIL";

            else
                status = "PCOMP";
            objAttachList.Status =status;
            objExportMan=new ExportManager();
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
            string UwCode=string.Empty;
            strTemp = strArr[0];
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Client Code Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Client Code"] =clientCode= strTemp;

            strTemp = strArr[1].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Client Name Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Client Name"] =strTemp;
           
            strTemp = strArr[2].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: D/N Date Is Mandatory";
                blParseError = true;
            }
            else
            {
                if (strTemp.Length < 8 || strTemp.Length > 10)
                {
                    strTemp += " - Error -: Invalid D/N Date";
                    blParseError = true;
                }
            }
            drRowToAdd["D/N Date"] = strTemp;

            strTemp = strArr[3].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: D/N Prefix Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["D/N Prefix"] = strTemp;

            strTemp = strArr[4].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: D/N No Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["D/N No"] = strTemp;
            debitNoteNo = strArr[3].Trim() + strArr[4].Trim();

            strTemp = strArr[5].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Branch Code Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Branch Code"] = strTemp;
          
            strTemp = strArr[6].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Cover Note Part1 Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Cover Note Part1"] = strTemp;

            strTemp = strArr[7].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Cover Note Part2 Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Cover Note Part2"] = strTemp;

            strTemp = strArr[8].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: Cover Note Part3 Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["Cover Note Part3"] = strTemp;

            strTemp = strArr[9].Trim();
            drRowToAdd["Cover Note Part4"] = strTemp;

            coverNoteNo = strArr[6].Trim() +"-"+ strArr[7].Trim() +"-"+ strArr[8].Trim() +"-"+ strArr[9].Trim();
            strTemp = strArr[10].Trim();
            drRowToAdd["Policy No"] = strTemp;
                
            strTemp = strArr[11].Trim();
            drRowToAdd["Currency Code"] = strTemp;
           
            strTemp = strArr[12].Trim();
            if (!isNumeric(strTemp))
            {
                strTemp += " - Error -: Invalid Billed Amount(AR)";
                blParseError = true;
            }

            drRowToAdd["Billed Amount(AR)"] = strTemp;
           
            strTemp = strArr[13].Trim();

            if (!isNumeric(strTemp))
            {
                strTemp += " - Error -: Invalid Settled Amount(AR)";
                blParseError = true;
            }

            drRowToAdd["Settled Amount(AR)"] = strTemp;

            strTemp = strArr[14].Trim();
            if (!isNumeric(strTemp))
            {
                strTemp += " - Error -: Invalid Outstanding Amount(AR)";
                blParseError = true;
            }
            drRowToAdd["Outstanding Amount(AR)"] = strTemp;

            strTemp = strArr[15].Trim();
            drRowToAdd["Settlement Date(AR)"] = strTemp;

            strTemp = strArr[16].Trim();
            drRowToAdd["Cheque/Ref Number(AR)"] = strTemp;

            strTemp = strArr[17].Trim();
            drRowToAdd["Remarks(AR)"] = strTemp;

            strTemp = strArr[18].Trim();
            drRowToAdd["Split Number"] = strTemp;

            strTemp = strArr[19].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: U/W Code Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["U/W Code"] = strTemp;
            UwCode=strArr[19].Trim();

            strTemp = strArr[20].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {
                strTemp += " - Error -: U/W Name Is Mandatory";
                blParseError = true;
            }
            drRowToAdd["U/W Name"] = strTemp;

            strTemp = strArr[21].Trim();
            if (string.IsNullOrEmpty(strTemp))
            {

                strTemp += " - Error -: Billed Amount(AP) Is Mandatory";
                blParseError = true;
            }
            else
            {
                if (!isNumeric(strTemp))
                {
                    strTemp += " - Error -: Invalid Billed Amount(AP)";
                    blParseError = true;
                }
            }
            drRowToAdd["Billed Amount(AP)"] = strTemp;

            strTemp = strArr[22].Trim();
            if (!isNumeric(strTemp))
            {
                strTemp += " - Error -: Invalid Settled Amount(AP)";
                blParseError = true;
            }
            drRowToAdd["Settled Amount(AP)"] = strTemp;
            

            strTemp = strArr[23].Trim();
            if (!isNumeric(strTemp))
            {
                strTemp += " - Error -: Invalid Outstanding Amount(AP)";
                blParseError = true;
            }
            drRowToAdd["Outstanding Amount(AP)"] = strTemp;

            strTemp = strArr[24].Trim();
            drRowToAdd["Settlement Date(AP)"] = strTemp;

            strTemp = strArr[25].Trim();
            drRowToAdd["Cheque/Ref Number(AP)"] = strTemp;

            strTemp = strArr[26].Trim();
            drRowToAdd["Remarks(AP)"] = strTemp;

            drRowToAdd["ParseMsg"] = sbInputString.ToString();
            drRowToAdd["BatchReferenceID"] = BatchRefId.ToString();
            

            //Procedure to check Validity of Debit Note Detal
            DataTable dtDetail = new DataTable("TM_FlexDN_CheckRecord");
            dtDetail=isExisted(debitNoteNo, clientCode, coverNoteNo,UwCode);
            if (!blParseError) 
            {
            
                if (dtDetail != null)
                {
                    if (dtDetail.Rows.Count > 0)
                    {

                        blParseError = false;
                        drRowToAdd["CaseRefNo"] = dtDetail.Rows[0]["CaseRefNo"].ToString();
                        drRowToAdd["ClientRefNo"] = dtDetail.Rows[0]["ClientRefNo"].ToString();
                        drRowToAdd["UWRefNo"] = dtDetail.Rows[0]["UWRefNo"].ToString();
                        if (string.IsNullOrEmpty(dtDetail.Rows[0]["ClientRefNo"].ToString()))
                        {
                            blParseError = true;
                            drRowToAdd["ParseMsg"] = "Invalid Client Code.";
                        }
                        if (string.IsNullOrEmpty(dtDetail.Rows[0]["UWRefNo"].ToString()))
                        {
                            blParseError = true;
                            drRowToAdd["ParseMsg"] = "Invalid U/W Code.";
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
                    drRowToAdd["ClientRefNo"] = "";
                    drRowToAdd["UWRefNo"] = "";
                    drRowToAdd["ParseMsg"] = "Invalid Debit Note Number.";
                }
            }
            drRowToAdd["ParseResult"] = (blParseError) ? "INVALID" : "VALID";
            dtSourceTble.Rows.Add(drRowToAdd);
        }
       
        private void createDataTbl()
        {
            dtSourceTble = new DataTable();
            dtSourceTble.Columns.Add("Client Code");
            dtSourceTble.Columns.Add("Client Name");
            dtSourceTble.Columns.Add("D/N Date");
            dtSourceTble.Columns.Add("CaseRefNo");
            dtSourceTble.Columns.Add("D/N Prefix");
            dtSourceTble.Columns.Add("D/N No");
            dtSourceTble.Columns.Add("Branch Code");
            dtSourceTble.Columns.Add("Cover Note Part1");
            dtSourceTble.Columns.Add("Cover Note Part2");
            dtSourceTble.Columns.Add("Cover Note Part3");
            dtSourceTble.Columns.Add("Cover Note Part4");
            dtSourceTble.Columns.Add("Policy No");
            dtSourceTble.Columns.Add("Currency Code");
            dtSourceTble.Columns.Add("ClientRefNo");
            dtSourceTble.Columns.Add("Billed Amount(AR)");
            dtSourceTble.Columns.Add("Settled Amount(AR)");
            dtSourceTble.Columns.Add("Outstanding Amount(AR)");
            dtSourceTble.Columns.Add("SettlementAmount(AR)");
            dtSourceTble.Columns.Add("Settlement Date(AR)");
            dtSourceTble.Columns.Add("Cheque/Ref Number(AR)");
            dtSourceTble.Columns.Add("Remarks(AR)");
            dtSourceTble.Columns.Add("Split Number");
            dtSourceTble.Columns.Add("UWRefNo");
            dtSourceTble.Columns.Add("U/W Code");
            dtSourceTble.Columns.Add("U/W Name");
            dtSourceTble.Columns.Add("Billed Amount(AP)");
            dtSourceTble.Columns.Add("Settled Amount(AP)");
            dtSourceTble.Columns.Add("Outstanding Amount(AP)");
            dtSourceTble.Columns.Add("SettlementAmount(AP)");
            dtSourceTble.Columns.Add("Settlement Date(AP)");
            dtSourceTble.Columns.Add("Cheque/Ref Number(AP)");
            dtSourceTble.Columns.Add("Remarks(AP)");
            dtSourceTble.Columns.Add("ParseMsg");
            dtSourceTble.Columns.Add("ParseResult");
            dtSourceTble.Columns.Add("BatchReferenceID");

        }
        public void getFilePath()
        {
            DataSet dsPath = new DataSet();
            objExportMan = new ExportManager();
            dsPath = objExportMan.getPathDetail("FlexUpload");
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

        public DataTable isExisted(string DebitNoteNo,string clientCode,string CoverNote,string UWCode)
        {
            DataSet dsResult = new DataSet();
            objExportMan = new ExportManager();
            dsResult = objExportMan.checkDebitNoteDetail(DebitNoteNo,clientCode,CoverNote,UWCode);

            return dsResult.Tables["TM_FlexDN_CheckRecord"];
        
        
        }

        public bool isNumeric(string val )
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public void saveDebitNoteDetail(DataTable dtDebitNote)
        {
            try
            {
                //Creating New CSV File for success Records
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
                    objExportMan.saveDebitNoteDetail(dtValidRecords);

                    DataSet ds = new DataSet();
                    //dtValidRecords.Rows.InsertAt(addHeader(dtValidRecords), 0);
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

                //Creating New CSV File for fail Records
                string strInValidexpress = "ParseResult='INVALID'";
                DataSet dsInvalid = new DataSet();
                DataTable dtInvalidRecord = dtDebitNote.Clone();
                DataRow[] dvrow = dtDebitNote.Select(strInValidexpress);
                foreach (DataRow dr in dvrow)
                {
                    dtInvalidRecord.ImportRow(dr);
                }

                if (dtInvalidRecord.Rows.Count > 0)
                {
                    //dtInvalidRecord.Rows.InsertAt(addHeader(dtInvalidRecord), 0);
                    //dtInvalidRecord.Columns.Remove("CaseRefNo");
                    //dtInvalidRecord.Columns.Remove("ClientRefNo");
                    //dtInvalidRecord.Columns.Remove("UWRefNo");
                    //dtInvalidRecord.Columns.Remove("SettlementAmount(AR)");
                    //dtInvalidRecord.Columns.Remove("SettlementAmount(AP)");
                    //dtInvalidRecord.Columns.Remove("ParseResult");
                    //dtInvalidRecord.Columns.Remove("BatchReferenceID");

                    dsInvalid.Tables.Add(dtInvalidRecord);
                    makeCsvForInValidRecords(dsInvalid);
                }

                refreshInputFolder();
            }
            catch(Exception ex)
            {
            
            }
        }

        public DataRow addHeader(DataTable dtTable)
        {
            DataRow drHeader = dtTable.NewRow();
            drHeader[0] = "Client Code";
            drHeader[1] = "Client Name";
            drHeader[2] = "D/N Date";

            drHeader[3] = "Case Ref No";

            drHeader[4] = "D/N Prefix";
            drHeader[5] = "D/N No";
            drHeader[6] = "Branch Code";
            drHeader[7] = "Cover Note Part1";
            drHeader[8] = "Cover Note Part2";
            drHeader[9] = "Cover Note Part3";
            drHeader[10] = "Cover Note Part4";
            drHeader[11] = "Policy No";
            drHeader[12] = "Currency Code";

            drHeader[13] = "ClientRefNo";

            drHeader[14] = "Billed Amount(AR)";
            drHeader[15] = "Settled Amount(AR)";
            drHeader[16] = "Outstanding Amount(AR)";
            drHeader[17] = "SettlementAmount(AR)";

            drHeader[18] = "Settlement Date(AR)";

            drHeader[19] = "Cheque/Ref Number(AR)";
            drHeader[20] = "Remarks(AR)";
            drHeader[21] = "Split Number";

            drHeader[22] = "UWRefNo";

            drHeader[23] = "U/W Code";
            drHeader[24] = "U/W Name";
            drHeader[25] = "Billed Amount(AP)";
            drHeader[26] = "Settled Amount(AP)";
            drHeader[27] = "Outstanding Amount(AP)";

            drHeader[28] = "SettlementAmount(AP)";

            drHeader[29] = "Settlement Date(AP)";
            drHeader[30] = "Cheque/Ref Number(AP)";
            drHeader[31] = "Remarks(AP)";

            drHeader[32] = "ParseMsg";
            drHeader[33] = "ParseResult";
            drHeader[34] = "BatchReferenceID";
            return drHeader; ;
        }
        public void makeCsvForValidRecords(DataSet dsRecord)
        {

            GenerateCsvFile objCSv = new GenerateCsvFile();
            string strDestPath = mstrSourceFilePath +"SuccessFiles";
            if (!Directory.Exists(strDestPath))
            {
                try
                {
                    CreateNewFolder(strDestPath);
                }
                catch { throw; }
            }
            //string FilePath = strCurrFileName.Substring(0, strCurrFileName.LastIndexOf(@"\")) + @"\SuccessFiles\" + strCurrFileName.Substring(strCurrFileName.LastIndexOf(@"\") + 1);
            string FilePath = strDestPath+"\\"+ strFileName;

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
            string FilePath = strDestPath +"\\"+strFileName;
            objCSv.exportToCSVfile(dsRecord, ",", "\n", FilePath);
        }
    }
}