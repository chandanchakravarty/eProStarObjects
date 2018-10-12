using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.IO;
using BusinessAccessLayer.Common;
using BusinessObjectLayer.BrokingModule.Flex;

namespace BusinessAccessLayer.FlexServices.FlexBS
{
    /// <summary>
    /// Class is being used for Importing files from BS to Flex. 
    /// Effectively this calls is reading NWI-BS data and exporting into CSV format so that Flex-System can process.
    /// </summary>
    public class ImportManager
    {
        //ExportManager objExpManager = null;
        FlexBsToCsv objBstoCsv = null;
        DataAccess DataAccessDs = null;
        DataSet ds = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        public DataSet getDebitNoteDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexDebitNote_BSToFlex_Select", "TM_FlexDebitNote_BSToFlex");
        }

        public DataSet getCsvAttachmentList(string AttachFor, string FromDate, string ToDate)
        {
            object[] parameter = new object[] { AttachFor, FromDate, ToDate };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexBSToFlexCsvFile_List_Select", "TM_FlexBSToFlexCsvFile_List");
        }

        public DataSet SaveDebitNoteDetailToCsv(FlexBsToCsv objFlexcsv)
        {
            object[] parameter = new object[] { objFlexcsv.csvId,
                                                objFlexcsv.InternalFileName,
                                                objFlexcsv.DisplayFileName,
                                                objFlexcsv.ImportFor,
                                                objBstoCsv.FileType,
                                                objBstoCsv.Total_No_of_Records,
                                                objBstoCsv.BatchRefId,
            };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexBSToFlexCsvFile_List_InsertUpdate", "TM_FlexDebitNote_BSToFlex");
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

        public void startImporting()    
        {
            #region To Import Debit Note
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("FlexDownload");
            string ImportPath = dsPath.Tables[0].Rows[0]["KeyValue"].ToString();
            if (!Directory.Exists(ImportPath))
            {
                try
                {
                    CreateNewFolder(ImportPath);
                }
                catch { throw; }
            }

            ds = new DataSet();
            ds = getDebitNoteDetailToCsv();
            if (ds.Tables["TM_FlexDebitNote_BSToFlex"].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                string strFile = "DBN" + ".csv";

                string FilePath = ImportPath + strFile + "";
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);

                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "DBN";
                objBstoCsv.Total_No_of_Records = ds.Tables["TM_FlexDebitNote_BSToFlex"].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion

        }

        public DataSet getPathDetail(string keyWord)
        {
            object[] parameter = new object[1] {keyWord
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Sys_Params_Select", "Sys_Params");

        }

        public void startICAMImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("ICAMDownload");
            string ImportPath = dsPath.Tables[0].Rows[0]["KeyValue"].ToString();

            if (!Directory.Exists(ImportPath))
            {
                try
                {
                    CreateNewFolder(ImportPath);
                }
                catch { throw; }
            }

            ds = new DataSet();
            ds = getICAMDetailToCsv();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "CLIENT" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";

                string strFile = "CLIENT" + ".csv";
                string FilePath = ImportPath + strFile + "";
                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "ICAM";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public void startIACMImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IACMDownload");
            string ImportPath = dsPath.Tables[0].Rows[0]["KeyValue"].ToString();

            if (!Directory.Exists(ImportPath))
            {
                try
                {
                    CreateNewFolder(ImportPath);
                }
                catch { throw; }
            }

            ds = new DataSet();
            ds = getIACMDetailToCsv();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "ANALYSIS" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";

                string strFile = "ANALYSIS" + ".csv";
                string FilePath = ImportPath + strFile + "";
                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "IACM";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public void startIPDNImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IPDNDownload");
            string ImportPath = dsPath.Tables[0].Rows[0]["KeyValue"].ToString();

            if (!Directory.Exists(ImportPath))
            {
                try
                {
                    CreateNewFolder(ImportPath);
                }
                catch { throw; }
            }

            ds = new DataSet();
            ds = getIPDNDetailToCsv();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "IPDN" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";
                string strFile = "IPDN" + ".csv";
                string FilePath = ImportPath + strFile + "";

                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "IPDN";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public DataSet getIPDNDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexPostedDebitNote_BSToFlex_Select", "TM_FlexDebitNote_IRMToFlex");
        }

        public DataSet getICAMDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexICAM_IRMToFlex_Select", "TM_FlexDebitNote_IRMToFlex");
        }

        public DataSet getIACMDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexIACM_IRMToFlex_Select", "TM_FlexDebitNote_IRMToFlex");
        }

    }
}