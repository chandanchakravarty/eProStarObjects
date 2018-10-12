using DataAccessLayer;
using System.Data;
using System.IO;
using BusinessObjectLayer.RIBrokingModule.CoverNote;
using BusinessObjectLayer.RIBrokingModule.Invoice;
using BusinessObjectLayer.FlexServices.FlexIRM;

namespace BusinessAccessLayer.FlexServices.FlexIRM
{
    public class ExportManager
    {
        DataAccess DataAccessDs = null;
        string FilePath = string.Empty;

        public void startExporting()
        {
            getFilePath();
            string logPath = FilePath + "Logfile.txt";
            if (!Directory.Exists(FilePath))
            {
                try
                {
                    CreateNewFolder(FilePath);
                }
                catch { throw; }
            }
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                FlexDebitNoteCsvToBS objflexDN = new FlexDebitNoteCsvToBS();
                objflexDN.beginProcess(sw);
            }
        }

        public void startClaimExporting()
        {
            getClaimFilePath();
            string logPath = FilePath + "Logfile.txt";
            if (!Directory.Exists(FilePath))
            {
                try
                {
                    CreateNewFolder(FilePath);
                }
                catch { throw; }
            }
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                FlexClaimCsvToIRM objFlexCLM = new FlexClaimCsvToIRM();
                objFlexCLM.beginProcess(sw);
            }
        }

        public DataSet updateAttachementList(FlexAttachementList objAttachement)
        {
            object[] parameter = new object[7] {objAttachement.BatchReferenceID,
                                                objAttachement.AttachID,
                                                objAttachement.AttachFor,
                                                objAttachement.TotalNoOfRecords,
                                                objAttachement.SuccessfulRecords,
                                                objAttachement.FailedRecords,
                                                objAttachement.Status
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_Update", "P_TM_FlexAttachment_List_Update");
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

        public DataSet saveFlexUploadDetail(FlexAttachementList clsFlex)
        {
            object[] parameter = new object[7] {clsFlex.AttachID,
                                               clsFlex.AttachInternalFileName,
                                               clsFlex.AttachDisplayFileName,
                                               clsFlex.AttachFileDesc,
                                               clsFlex.AttachFor,
                                               clsFlex.FileType,
                                               clsFlex.User
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_InsertUpdate", "TM_FlexAttachment_List");
        }

        public DataSet ReuploadFlexDetail(FlexAttachementList clsFlex)
        {
            object[] parameter = new object[8] {clsFlex.AttachID,
                                               clsFlex.AttachInternalFileName,
                                               clsFlex.AttachDisplayFileName,
                                               clsFlex.AttachFileDesc,
                                               clsFlex.AttachFor,
                                               clsFlex.FileType,
                                               clsFlex.User,
                                               clsFlex.BatchReferenceID
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_Reupload", "TM_FlexAttachment_List");
        }

        public DataSet getFlexDNSettlementEnquiry()
        {
            object[] parameter = new object[] {
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexDN_OpenItem_SettlementEnquiry", "TM_FlexDN_OpenItem");
        }

        public DataSet getFlexUploadDetail(FlexAttachementList clsFlex, string fromDate, string toDate)
        {
            object[] parameter = new object[4] {clsFlex.AttachID,
                                                clsFlex.AttachFor,
                                                fromDate,
                                                toDate
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_Select", "TM_FlexAttachment_List_Select");
        }

        public DataSet getSysParamDetail(string keyWord)
        {
            object[] parameter = new object[1] {keyWord
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Sys_Params_Select", "Sys_Params");
        }

        public DataSet getDebitNoteDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public void setConnectionString()
        {
            DataAccessDs = new DataAccess();
        }

        public DataSet getAttachmentListByStatus(string AttchFor, string status)
        {

            object[] parameter = new object[] { AttchFor, status };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_SelectByStatus", "TM_FlexAttachment_List");
        }

        public DataSet checkDebitNoteDetail(string debitNote)
        {
            object[] parameter = new object[] { debitNote };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_IRMFlex_INV_CheckRecord", "TM_IRMFlex_INV_CheckRecord");
        }

        public DataSet checkClaimDetail(string debitNote)
        {
            object[] parameter = new object[] { debitNote };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_IRMFlex_CLM_CheckRecord", "TM_IRMFlex_INV_CheckRecord");
        }

        public void saveDebitNoteDetail(DataTable dtDebitNote)
        {
            DataAccessDs = new DataAccess();
            DataAccessDs.SqlInsertDataTable("P_IRMFlex_INV_OpenItem_InsertUpdate", "@IRMFlex_INV_OpenItem_Table", dtDebitNote);
        }

        public void saveDebitNoteDetailforClaim(DataTable dtDebitNote)
        {
            DataAccessDs = new DataAccess();
            DataAccessDs.SqlInsertDataTable("P_IRMFlex_CLM_OpenItem_InsertUpdate", "@IRMFlex_CLM_OpenItem_Table", dtDebitNote);
        }

        public DataSet getClaimInvoiceDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet saveClaimInvoiceDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet getPremiumInvoiceDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet savePremiumInvoiceDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet getAccountMasterDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet saveAccountMasterDetail()
        {
            object[] parameter = new object[] { };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "", "");
        }

        public DataSet getPathDetail(string keyWord)
        {
            object[] parameter = new object[1] { keyWord };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Sys_Params_Select", "Sys_Params");
        }

        public void getFilePath()
        {
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IRMFlex_INVLog");
            if (dsPath != null && dsPath.Tables.Count > 0 && dsPath.Tables["Sys_Params"].Rows.Count > 0)
            {
                FilePath = dsPath.Tables["Sys_Params"].Rows[0]["KeyValue"].ToString();
            }
        }

        public void getClaimFilePath()
        {
            DataSet dsPath = new DataSet();
            dsPath = getPathDetail("IRMFlex_CLMLog");
            if (dsPath != null && dsPath.Tables.Count > 0 && dsPath.Tables["Sys_Params"].Rows.Count > 0)
            {
                FilePath = dsPath.Tables["Sys_Params"].Rows[0]["KeyValue"].ToString();
            }
        }

        public DataSet getFlexRISettlementEnquiry(ClsRICNGeneralInformation objRIInfo, RIInvoiceSearch objRIInvoice)
        {
            object[] parameter = new object[] {objRIInfo.CedantCode,
                                                objRIInfo.CedantName,
                                                objRIInfo.CoverNoteNo,
                                                objRIInfo.PeriodFrom,
                                                objRIInfo.PeriodTo,
                                                objRIInvoice.InvoiceNo,
                                                objRIInvoice.DebitNoteFrom,
                                                objRIInvoice.DebitNoteTo
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_RI_GetSettlementEnquiry", "TM_FlexDN_OpenItem");
        }

    }
}
