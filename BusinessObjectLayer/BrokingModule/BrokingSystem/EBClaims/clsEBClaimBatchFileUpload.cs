using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class clsEBClaimBatchFileUpload
    {        
        public string RefNo { get; set; }
        public string FileName { get; set; }
        public byte[] FilePath { get; set; }
        public string FileType { get; set; }
        public string UploadBy { get; set; }
        public string UploadFromDate { get; set; }
        public string UploadToDate { get; set; }
        public string EB_NonEB { get; set; }
    }
}
