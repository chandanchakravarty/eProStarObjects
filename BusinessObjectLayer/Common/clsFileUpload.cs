using System;

namespace BusinessObjectLayer.Common
{
    public class clsFileUpload
    {
        public string Attach_ID { get; set; }
        public string Attach_Location { get; set; }
        public string Attach_InternalFileName { get; set; }
        public string Attach_DisplayFileName { get; set; }
        public string Attach_FileDesc { get; set; }
        public string Attach_For { get; set; }
        public string Attach_EntityID { get; set; }
        public string Pol_ClientID { get; set; }
        public string Pol_PolicyID { get; set; }
        public string Pol_PolicyVerID { get; set; }
        public string File_Type { get; set; }
        public string CreatedBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Mode { get; set; }
      
    }
    // added by kavita for check file upload status
    public class clscheckFileUploadStatus
    {
      
        public string Pol_PolicyID { get; set; }
        public string Pol_PolicyVerID { get; set; }
      
    }
    public class clscheckRIFileUploadStatus
    {
        public string TranRefNo { get; set; }
   }
    //end
}
