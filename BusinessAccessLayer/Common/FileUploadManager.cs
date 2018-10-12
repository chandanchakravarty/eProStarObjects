using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.Common;
using DataAccessLayer;

namespace BusinessAccessLayer.Common
{
    public class FileUploadManager
    {
        DataAccess dataAccess = new DataAccess();

        public FileUploadManager() { }

        public DataSet SaveFile(FileUpload objFileUpload)
        {
            Object[] parametes = new Object[10] 
                                    { 
                                        objFileUpload.Code,
                                        objFileUpload.UploadFileName,
                                        objFileUpload.UploadFileSize,
                                        objFileUpload.UploadFilePath,
                                        objFileUpload.UploadFileType,
                                        objFileUpload.OriginalFileName,
                                        objFileUpload.UserIPAddress,
                                        objFileUpload.Remarks,
                                        objFileUpload.Module,
                                        objFileUpload.LoginUserId 
                                    };

            return dataAccess.SaveData(parametes, "P_Adm_FileUpload_InsertUpdate", "FileUpload");
        }
        public DataSet GetUploadedFiles(string code, string module)
        {
            Object[] parametes = new Object[2] { code, module };
            return dataAccess.SaveData(parametes, "P_Adm_GetUploadFiles", "FileUpload");
        }

        public DataSet DeleteUploadedFile(string fileRefNo)
        {
            Object[] parametes = new Object[1] { fileRefNo };
            return dataAccess.SaveData(parametes, "P_Adm_DeleteFileUpload", "FileUpload");
        }

    }
}
