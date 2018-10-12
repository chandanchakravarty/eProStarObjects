using System;
using System.Configuration;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using BusinessAccessLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using System.Data;
using System.IO;
using System.Data.OleDb;
using DataAccessLayer;
using System.Web.UI.WebControls;
using System.Linq;



namespace eProStarServices
{
    public class BatchProcessRawClaim
    {
        clsEBMemberUpload objclsEBMemberUpload = new clsEBMemberUpload();
        EBMemberManager objEBMemberManager = new EBMemberManager();
        public string strFilepath = "", strExcelConn = "";


        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader=null;
        public BatchProcessRawClaim(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }
        protected void WriteLog(string strLogMsg)
        {
            EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }

        public void BeginProcess()
        {
            try
            {
                DataSet ds = new DataSet();
                objclsEBMemberUpload.FromBatch = "N";

                ds = objEBMemberManager.GetBatchRawClaimUpload(objclsEBMemberUpload,_ConfigReader.ConnString);

                if (ds != null)
                {
                    // EventLogs.WriteLogInFile("Row Counts: " + ds.Tables[0].Rows.Count.ToString(), System.Diagnostics.EventLogEntryType.Information);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // string path = ConfigurationSettingReader.FolderPath.ToString() + "../"; //
                        // string path = ConfigurationManager.AppSettings["InitialFolderPath"].ToString().Trim();
                        strFilepath = ds.Tables[0].Rows[0]["FilePath"].ToString().Replace("~\\", "");
                        string strRefNo = ds.Tables[0].Rows[0]["RefNo"].ToString();
                        // strFilepath = path + strFilepath;

                        WriteLog("strFilepath is  " + strFilepath);
                        if (File.Exists(strFilepath))
                        {
                            WriteLog(" is  Exist - Yes");

                            if (Path.GetExtension(strFilepath).ToUpper() == ".XLS")
                            {
                                WriteLog("strFil type is XLS  ");

                                // Excel 97-2003 
                                strExcelConn = _ConfigReader.ExcelConnXLS + strFilepath; // ConfigurationManager.ConnectionStrings["ExcelConnXLS"].ConnectionString + strFilepath;
                                // strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilepath + ";Extended Properties='Excel 8.0;HDR=YES;'";
                            }
                            else
                            {
                                WriteLog("strFil type is XLSX  ");

                                // Excel 2007
                                strExcelConn = _ConfigReader.ExcelConnXLSX + strFilepath;  //ConfigurationManager.ConnectionStrings["ExcelConnXLSX"].ConnectionString + strFilepath;
                                //strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilepath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                            }

                            DataTable dtExcel = RetrieveData(strExcelConn);

                            dtExcel = RemoveEmprtyRows(dtExcel);

                            //string fileName = Path.GetFileNameWithoutExtension(strFilepath);
                            //string[] strArray = fileName.Split(new char[] { '_' }, StringSplitOptions.None);
                            //string RefNo = strArray[0];
                            if (dtExcel.Columns.Contains("RefNo") == false)
                            {
                                dtExcel.Columns.Add("RefNo");
                            }
                            for (int i = 0; i < dtExcel.Rows.Count; i++)
                            {
                                dtExcel.Rows[i]["RefNo"] = strRefNo;

                            }
                            DataAccess objDataAcces = new DataAccess(_ConfigReader.ConnString,"service");
                            WriteLog("before SP  ");
                            objDataAcces.SqlInsertDataTable("P_EB_RawDataClaim_Insert", "Type_RAWCLAIM_Item", dtExcel);
                            WriteLog("before SP  ");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                ServiceUtility.WriteLog("Error in Raw Claim service for Client " + mClientCode + " : " + ex.Message);
            }
        }

        private DataTable RemoveEmprtyRows(DataTable dt)
        {
            var v = from m in dt.AsEnumerable() where m.ItemArray.Any(x => string.IsNullOrEmpty(x.ToString().Trim()) == false) select m;
            if (v.Count() > 0)
            {
                dt = v.CopyToDataTable();
            }
            return dt;
        }

        protected DataTable RetrieveData(string strConn)
        {
            DataTable dtExcel = new DataTable();
            DataTable dtExcelSchemaTable = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                WriteLog("before open Conn  ");

                conn.Open();
                WriteLog("after open Conn  ");

                dtExcelSchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                ListItemCollection items = new ListItemCollection();

                //string strSheetname = dtExcel.Rows[0]["TABLE_NAME"].ToString();
                for (int rowIndex = 0; rowIndex < dtExcelSchemaTable.Rows.Count; rowIndex++)
                {
                    string excelSheetName;
                    string lastCharacter = "";

                    excelSheetName = dtExcelSchemaTable.Rows[rowIndex]["TABLE_NAME"].ToString();
                    excelSheetName = excelSheetName.Replace("'", "");
                    lastCharacter = excelSheetName.Substring(excelSheetName.Length - 1, 1);
                    if (lastCharacter == "$")
                    {
                        items.Add(dtExcelSchemaTable.Rows[rowIndex]["TABLE_NAME"].ToString());
                    }
                }
                if (items.Count > 1)
                    return null;

                string sName;
                string query;

                sName = items[0].ToString();
                sName = sName.Replace("'", "");
                sName = sName.Replace("$", "");

                query = "";
                query = String.Format("select * from [{0}$]", sName);

                // Initialize an OleDbDataAdapter object. 


                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);

                // Fill the DataTable with data from the Excel spreadsheet. 
                da.Fill(dtExcel);
            }

            return dtExcel;
        }




    }
}
