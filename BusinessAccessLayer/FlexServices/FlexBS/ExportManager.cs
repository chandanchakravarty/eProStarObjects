using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.FlexServices.FlexBS;
using System.IO;
using BusinessObjectLayer.RIBrokingModule.CoverNote;
using BusinessObjectLayer.RIBrokingModule.Invoice;

namespace BusinessAccessLayer.FlexServices.FlexBS
{
    public class ExportManager
    {
        DataAccess DataAccessDs = null;
        string FilePath = string.Empty;
        //FlexDebitNoteCsvToBS objFlexDebitNoteCsvToBS = new FlexDebitNoteCsvToBS();

        public void startExporting()
        {
            getFilePath();
            string logPath =FilePath + "Logfile.txt";
            if (!Directory.Exists(FilePath))
            {
                try
                {
                    CreateNewFolder(FilePath);
                }
                catch { throw; }
            }
            using (StreamWriter sw = new StreamWriter(logPath,true))
            {
                FlexDebitNoteCsvToBS objflexDN = new FlexDebitNoteCsvToBS();
                objflexDN.beginProcess(sw);
            }
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

        public DataSet getFlexDNSettlementEnquiry(string clientcode,string clientname,string covernoteno, string POIFromdate,string POITodate,string debitnoteno,string debitnotefromdate,string debitnotedateto,string enquiryby)
        {
            object[] parameter = new object[9] {clientcode,clientname ,covernoteno, POIFromdate,POITodate ,debitnoteno,debitnotefromdate,debitnotedateto,enquiryby };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexDN_OpenItem_SettlementEnquiry", "TM_FlexDN_OpenItem");

        }


        public DataSet getFlexUploadDetail(FlexAttachementList clsFlex,string fromDate,string toDate)
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
        public DataSet getAttachmentListByStatus(string AttchFor,string status)
        {

            object[] parameter = new object[] {AttchFor, status};
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexAttachment_List_SelectByStatus", "TM_FlexAttachment_List");
        }
        public DataSet checkDebitNoteDetail(string debitNote,string clientCode,string coverNote,string UWCode)
        {

            object[] parameter = new object[] {debitNote,clientCode,coverNote,UWCode };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_TM_FlexDN_CheckRecord", "TM_FlexDN_CheckRecord");
        }
        public void saveDebitNoteDetail(DataTable dtDebitNote)
        {
            DataAccessDs = new DataAccess();
            DataAccessDs.SqlInsertDataTable("P_FlexDN_OpenItem_InsertUpdate", "@FlexDN_OpenItem_Table", dtDebitNote);

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
            object[] parameter = new object[1] {keyWord
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_Sys_Params_Select", "Sys_Params");

        }
        public void getFilePath()
        {
            DataSet dsPath = new DataSet();
            // Change for Log File Path
            dsPath = getPathDetail("BSFlexLog");
            if (dsPath.Tables["Sys_Params"].Rows.Count > 0)
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

        public DataSet getFlexRIClaimSettlementEnquiry(ClsRICNGeneralInformation objRIInfo, RIInvoiceSearch objRIInvoice)
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
            return DataAccessDs.LoadDataSet(parameter, "P_RI_GetClaimSettlementEnquiry", "TM_FlexDN_OpenItem");
        }
    }
}
