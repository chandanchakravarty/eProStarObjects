using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.IO;
using System.Diagnostics;
using BusinessObjectLayer.FlexServices.FlexIRM;

namespace BusinessAccessLayer.FlexServices.FlexIRM
{
    public class ImportManager
    {
        //ExportManager objExpManager = null;
        FlexBsToCsv objBstoCsv = null;
        DataAccess DataAccessDs = null;
        DataSet ds = null;

        public DataSet getDebitNoteDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexDebitNote_IRMToFlex_Select", "TM_FlexDebitNote_IRMToFlex");
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
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexIRMToFlexCsvFile_List_InsertUpdate", "TM_FlexDebitNote_IRMToFlex");
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
            dsPath = getPathDetail("IRMFlexDownload");
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

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "INV" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";

                string strFile = "INV" + ".csv";
                string FilePath = ImportPath + strFile + "";
                EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "INV";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public DataSet getPathDetail(string keyWord)
        {
            object[] parameter = new object[1] { keyWord };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Sys_Params_Select", "Sys_Params");
        }

        public void startICAMImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IRM_ICAMDownload");
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
                //string strFile = "IRMCLIENT" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";
                string strFile = "IRMCLIENT" + ".csv";

                string FilePath = ImportPath + strFile + "";
                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "IRM";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public DataSet getICAMDetailToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_IRM_FlexICAM_Select", "TM_IRM_FlexICAM_Select");
        }

        public void startPremiumDNImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IRM_DNDownload");
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
            ds = getPremiumDNToCsv();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "IRMDN" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";
                string strFile = "IRMDN" + ".csv";

                string FilePath = ImportPath + strFile + "";
                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "PDN";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public DataSet getPremiumDNToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_IRM_FlexDN_Select", "TM_IRM_FlexDN_Select");
        }

        public void startCLDNImporting()
        {
            #region To Import ICAM
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IRM_CLDownload");
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
            ds = getPremiumCLToCsv();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GenerateCsvFile objCSv = new GenerateCsvFile();
                //string strFile = "IRMCL" + System.DateTime.Now.ToString("yyyyMMdd").Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".csv";
                string strFile = "IRMCL" + ".csv";

                string FilePath = ImportPath + strFile + "";
                //EventLog.WriteEntry("NWI_IRMFlexProcess", "Importing Started Successfully", System.Diagnostics.EventLogEntryType.Error);
                objCSv.exportToCSVfile(ds, ",", "\n", FilePath);
                objBstoCsv = new FlexBsToCsv();
                objBstoCsv.csvId = 0;
                objBstoCsv.InternalFileName = strFile;
                objBstoCsv.ImportFor = "PCL";
                objBstoCsv.Total_No_of_Records = ds.Tables[0].Rows.Count;
                SaveDebitNoteDetailToCsv(objBstoCsv);
            }
            #endregion
        }

        public DataSet getPremiumCLToCsv()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_IRM_FlexCL_Select", "TM_IRM_FlexCL_Select");
        }

    }
}