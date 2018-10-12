using System;
using System.Data;
using DataAccessLayer;
//using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.Common;

namespace BusinessAccessLayer.Common
{
   public class clsFileUploadManager
    {
       DataAccess objDataAccess = null;

       public DataSet InsertUpdateDeleteFileUpload(clsFileUpload objFileUpload)
       {
          objDataAccess = new DataAccess();
           //Object[] parameters = new Object[15] {objFileUpload.Attach_ID, objFileUpload.Attach_Location,objFileUpload.Attach_DisplayFileName,objFileUpload.Attach_FileDesc,objFileUpload.Attach_For,objFileUpload.Attach_EntityID,objFileUpload.Pol_ClientID,objFileUpload.Pol_PolicyID,objFileUpload.Pol_PolicyVerID, objFileUpload.File_Type,objFileUpload.CreatedBy,objFileUpload.CreateDate,objFileUpload.ModifiedBy,objFileUpload.ModifiedDate };
           Object[] parameters = new Object[13] { objFileUpload.Attach_ID, objFileUpload.Attach_Location, objFileUpload.Attach_InternalFileName, objFileUpload.Attach_DisplayFileName, objFileUpload.Attach_FileDesc, objFileUpload.Attach_For, objFileUpload.Attach_EntityID, objFileUpload.Pol_ClientID, objFileUpload.Pol_PolicyID, objFileUpload.Pol_PolicyVerID, objFileUpload.File_Type, objFileUpload.CreatedBy, objFileUpload.Mode};
           return objDataAccess.LoadDataSet(parameters, "P_FileAttachDetails_InsertUpdateDelete", "TM_Attachment_List");
       }
       public DataSet GetFileAttachDetails(clsFileUpload objFileUpload)
       {
           objDataAccess = new DataAccess();
           Object[] parameters = new Object[3]{ objFileUpload.Attach_ID,objFileUpload.Attach_For,objFileUpload.Attach_EntityID};
           return objDataAccess.LoadDataSet(parameters, "P_GetFileAttachDetails", "TM_Attachment_List");
       }
       //Added By Rituraj for binding gridin file attachment
       public DataSet GetFiles(clsFileUpload objFileUpload)
       {
           objDataAccess = new DataAccess();
           Object[] parameters = new Object[2] { objFileUpload.Pol_PolicyID, objFileUpload.Pol_PolicyVerID};
           return objDataAccess.LoadDataSet(parameters, "P_GetFiles", "TM_Attachment_List");
       }
       //end
       // added by kavita to check the file upload status//
       public int check_FileUploadStatus(clscheckFileUploadStatus  objcheckfileupoadstatus)
       {
           objDataAccess = new DataAccess();
           Object[] parameters = new Object[2] { objcheckfileupoadstatus.Pol_PolicyID, objcheckfileupoadstatus.Pol_PolicyVerID };
          return  objDataAccess.ExecuteScalar("P_Pol_Check_FileUploadStatus", parameters);
       }
       //Added on 2nd Nov for Search File Name and Description 
       public DataSet SearchFiles(clsFileUpload objFileUpload)
       {
           objDataAccess = new DataAccess();
           Object[] parameters = new Object[4] { objFileUpload.Pol_PolicyID, objFileUpload.Pol_PolicyVerID,objFileUpload.Attach_DisplayFileName,objFileUpload.Attach_FileDesc  };
           return objDataAccess.LoadDataSet(parameters, "P_Get_SeacrhFileDescription", "TM_Get_SeacrhFileDescription");
       }
       //end
       public int check_RIFileUploadStatus(clscheckRIFileUploadStatus objcheckRIfileupoadstatus)
       {
           objDataAccess = new DataAccess();
           Object[] parameters = new Object[1] { objcheckRIfileupoadstatus.TranRefNo};
           return objDataAccess.ExecuteScalar("P_Pol_RICheck_FileUploadStatus", parameters);
       }

       //end of code

      ////////////////////////////
       //public DataSet LoadDataSet(object[] parameters, string procName, string dataTableName)
       //{
       //    dataSet = new DataSet();
       //    dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
       //    return dataSet;
       //}


       //public void ExecuteNonQuery(string ProcName, object[] parameters)
       //{
       //    dataBase.ExecuteNonQuery(ProcName, parameters);
       //}

       public int check_RIFileUploadStatus(clscheckFileUploadStatus clscheckfileupload)
       {
           throw new NotImplementedException();
       }
    }
    
}

